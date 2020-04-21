using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace TriadCore
    {
    /// <summary>
    /// Базовый класс, предполагающий работу с внутренними объектами этого класса
    /// </summary>
    public class ReflectionObject
        {
        /// <summary>
        /// Обработчики изменения объектов
        /// </summary>
        protected SortedList<CoreName, List<SpyHandler>> spyHandlerList =
            new SortedList<CoreName, List<SpyHandler>>();


        /// <summary>
        /// Получить копию
        /// </summary>
        /// <returns></returns>
        public ReflectionObject Clone()
            {
            ReflectionObject newObject = this.MemberwiseClone() as ReflectionObject;
            //Копируем список обработчиков
            newObject.spyHandlerList = new SortedList<CoreName, List<SpyHandler>>();
            foreach ( KeyValuePair<CoreName, List<SpyHandler>> pair in this.spyHandlerList )
                newObject.spyHandlerList.Add( pair.Key, pair.Value );
            
            return newObject;
            }


        /// <summary>
        /// Зарегистрировать обработчик изменения объекта
        /// </summary>
        /// <param name="objectInfo">Объект слежения</param>
        /// <param name="handler">Обработчик</param>
        public void RegisterSpyHandler( SpyObject objectInfo, SpyHandler handler )
            {
            ReflectionObject objectContainer = objectInfo.Container;
            if ( objectContainer.spyHandlerList.ContainsKey( objectInfo.RealName ) )
                objectContainer.spyHandlerList[ objectInfo.RealName ].Add( handler );
            else
                {
                List<SpyHandler> handlerList = new List<SpyHandler>();
                handlerList.Add( handler );
                objectContainer.spyHandlerList.Add( objectInfo.RealName, handlerList );
                }
            }


        /// <summary>
        /// Зарегистрировать обработчик изменения диапазона объектов
        /// </summary>
        /// <param name="objectInfoArray">Диапазон</param>
        /// <param name="handler">Обработчик</param>
        public void RegisterSpyHandler( SpyObject[] objectInfoArray, SpyHandler handler )
            {
            foreach ( SpyObject objectInfo in objectInfoArray )
                RegisterSpyHandler( objectInfo, handler );
            }


        /// <summary>
        /// Удалить все обработчики изменений переменных
        /// </summary>
        public void RemoveAllVarChangeHandlers()
            {
            this.spyHandlerList.Clear();
            }


        /// <summary>
        /// Системное время
        /// </summary>
        protected virtual double SystemTime
            {
            get
                {
                return 0;
                }
            } 


        /// <summary>
        /// Получить значение внутренней переменной
        /// </summary>
        /// <param name="varName">Имя переменной</param>
        /// <returns>Значение переменной</returns>
        public object GetValueForVar( CoreName varName )
            {
            Type selfType = this.GetType();
            FieldInfo fieldInfo = selfType.GetField( varName.BaseName, BindingFlags.NonPublic | 
                BindingFlags.Instance );
            
            //Если это обычная переменная
            if ( fieldInfo != null )
                {
                //Если это неиндексированная переменная
                if ( !varName.IsIndexed )
                    {
                    return fieldInfo.GetValue( this );
                    }
                //Если это массив
                else
                    {
                    return ( (Array)fieldInfo.GetValue( this ) ).GetValue( varName.IndexArray );
                    }
                }
            //Если это свойство
            else
                {
                PropertyInfo propertyInfo = selfType.GetProperty( varName.BaseName, BindingFlags.NonPublic | 
                    BindingFlags.Instance );

                if ( propertyInfo != null )
                    {
                    //Если это неиндексированная переменная
                    if ( !varName.IsIndexed )
                        {
                        return propertyInfo.GetValue( this, null );
                        }
                    //Если это массив
                    else
                        {
                        return ( (Array)propertyInfo.GetValue( this, null ) ).GetValue( varName.IndexArray );
                        }
                    }
                else
                    {
                    throw new ArgumentException( "Переменная " + varName + " не является внутренней переменной " + this.ToString() );
                    }
                }
            }


        /// <summary>
        /// Установить значение внутренней переменной  
        /// </summary>
        /// <param name="varName">Имя переменной</param>
        /// <param name="value">Значение переменной</param>
        public void SetValueForVar( CoreName varName, object value )
            {
            Type selfType = this.GetType();
            FieldInfo fieldInfo = selfType.GetField( varName.BaseName, BindingFlags.NonPublic | BindingFlags.Instance );
            if ( fieldInfo != null )
                {
                //Если это неиндексированная переменная
                if ( !varName.IsIndexed )
                    {
                    fieldInfo.SetValue( this, value );
                    }
                //Если это массив
                else
                    {
                    ( (Array)fieldInfo.GetValue( this ) ).SetValue( value, varName.IndexArray );
                    }
                }
            //Если это свойство
            else
                {
                PropertyInfo propertyInfo = selfType.GetProperty( varName.BaseName, BindingFlags.NonPublic |
                    BindingFlags.Instance );

                if ( propertyInfo != null )
                    {
                    //Если это неиндексированная переменная
                    if ( !varName.IsIndexed )
                        {
                        propertyInfo.SetValue( this, value, null );
                        object val = propertyInfo.GetValue( this, null );
                        }
                    //Если это массив
                    else
                        {
                        ( (Array)propertyInfo.GetValue( this, null ) ).SetValue( value, varName.IndexArray );
                        }
                    }
                else
                    {
                    throw new ArgumentException( "Переменная " + varName + " не является внутренней переменной " + this.ToString() );
                    }                
                }
            }



        /// <summary>
        /// Вызов обработчиков изменения переменной
        /// </summary>
        /// <param name="varName">Имя переменной</param>
        protected void DoVarChanging( CoreName varName )
            {
            //Вызов обработчиков изменения переменной
            if ( this.spyHandlerList.ContainsKey( varName ) )
                foreach ( SpyHandler handler in this.spyHandlerList[ varName ] )
                    {
                    handler.Invoke( new SpyVar( varName, this ), this.SystemTime );
                    }
            }

        
        }
    }
