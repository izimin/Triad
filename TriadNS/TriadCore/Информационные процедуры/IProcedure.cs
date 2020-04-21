using System;
using System.Collections.Generic;


namespace TriadCore
    {
    /// <summary>
    /// Обобщенная информационная процедура
    /// </summary>
    public class IProcedure : ReflectionObject
        {
        /// <summary>
        /// Список зарегистрированных в ИП объектов слежения
        /// </summary>
        protected SortedList<CoreName, SpyObject> spyObjectList = new SortedList<CoreName, SpyObject>();


        /// <summary>
        /// Процесс инициализации
        /// </summary>
        public virtual void DoInitialize()
            {
            //Пусто
            }


        /// <summary>
        /// Основная процедура обработки(ее используем в обработчиках для  
        /// дальнейшего определения, на какое изменение сработала ИП)
        /// </summary>
        /// <param name="objectInfo">Объект слежения, на изменение которого реагируем</param>
        /// <param name="systemTime">Модельное время на объекте</param>
        protected virtual void DoHandling( SpyObject objectInfo, double systemTime )
            {
            //Пусто
            }


        /// <summary>
        /// Отладочная печать
        /// </summary>
        /// <param name="message">Сообщение</param>
        protected void PrintMessage( object message )
            {
                if (message != null)
                {
                    Console.WriteLine("ИП: {0} \t {1} ", this, message);
                    Logger.Instance.AddRecord(new LoggerRecord(-1, "ИП " + this.ToString(), message.ToString()));
                }
            }


        /// <summary>
        /// Зарегистрировать объект слежения
        /// </summary>
        /// <param name="objectInfo">Объект слежения</param>
        /// <param name="formalName">Формальное имя объекта</param>
        protected void RegisterSpyObject( SpyObject objectInfo, CoreName formalName )
            {
            if ( !this.spyObjectList.ContainsKey( formalName ) )
                {
                this.spyObjectList.Add( formalName, objectInfo );
                }
            }


        /// <summary>
        /// Зарегистрировать диапазон объектов слежения
        /// </summary>
        /// <param name="objectInfoArray">Массив объектов слежения</param>
        /// <param name="formalNameRange">Диапазон имен</param>
        protected void RegisterSpyObject( SpyObject[] objectInfoArray, CoreNameRange formalNameRange )
            {
            for ( int index = 0 ; index < formalNameRange.ItemCount && index < objectInfoArray.Length ; index++ )
                RegisterSpyObject( objectInfoArray[ index ], formalNameRange[ index ] );

            //Добавляем spy-объект, отвечающий за целый массив
            //Он нужен, чтобы получать значение сразу всего массива
            if ( objectInfoArray.Length > 0 && formalNameRange.ItemCount > 0 )
                {
                SpyObject arraySpyObject = objectInfoArray[ 0 ].Clone();
                arraySpyObject.RealName = new CoreName( arraySpyObject.RealName.BaseName );
                this.spyObjectList.Add( new CoreName( formalNameRange[ 0 ].BaseName ), arraySpyObject );
                }
            }


        /// <summary>
        /// Получить объект слежения
        /// </summary>
        /// <param name="objectName">Имя объекта</param>
        /// <returns>Объект</returns>
        protected SpyObject GetSpyObject( CoreName objectName )
            {
            //Если это зарегистрированный объект
            if ( this.spyObjectList.ContainsKey( objectName ) )
                return this.spyObjectList[ objectName ];

            throw new ArgumentOutOfRangeException( "Объект " + this +
                " не содержит spy-объекта " + objectName );
            }


        /// <summary>
        /// Получить диапазон объектов слежения
        /// </summary>
        /// <param name="objectNameRange">Имя диапазона</param>
        /// <returns>Объект</returns>
        protected SpyObject[] GetSpyObject( CoreNameRange objectNameRange )
            {
            List<SpyObject> objectInfoList = new List<SpyObject>();

            foreach ( CoreName objectName in objectNameRange )
                {
                objectInfoList.Add( GetSpyObject( objectName ) );
                }

            return objectInfoList.ToArray();
            }


        /// <summary>
        /// Получить значение spy-переменной (обычной или in/passive)
        /// </summary>
        /// <param name="varName">Имя переменной</param>
        protected object GetSpyVarValue( CoreName varName )
            {
            //Если это объект слежения
            if ( this.spyObjectList.ContainsKey( varName ) )
                {
                SpyVar spyVarInfo = this.spyObjectList[ varName ] as SpyVar;

                //Если объект слежения - это переменная
                if ( spyVarInfo != null )
                    {
                    return spyVarInfo.Value;
                    }
                }
            

            return null;
            }


        /// <summary>
        /// Задать значение spy-переменной
        /// </summary>
        /// <param name="varName">Имя переменной</param>
        /// <param name="value">Значение</param>
        protected void SetSpyVarValue( CoreName varName, object value )
            {
            //Если это объект слежения
            if ( this.spyObjectList.ContainsKey( varName ) )
                {
                SpyVar spyVarInfo = this.spyObjectList[ varName ] as SpyVar;

                //Если объект слежения - это переменная
                if ( spyVarInfo != null )
                    {
                    spyVarInfo.Value = value;
                    }
                }
            }


        /// <summary>
        /// Заблокировать полюс
        /// </summary>
        /// <param name="polusName">Имя полюса</param>
        protected void BlockPolus( CoreName polusName )
            {
            //Если есть такой объект слежения
            if ( this.spyObjectList.ContainsKey( polusName ) )
                {
                SpyPolus spyPolusInfo = this.spyObjectList[ polusName ] as SpyPolus;

                //Если это полюс
                if ( spyPolusInfo != null )
                    {
                    spyPolusInfo.BlockPolus();
                    }
                }
            }


        /// <summary>
        /// Заблокировать диапазон полюсов
        /// </summary>
        /// <param name="polusNameRange">Диапазон</param>
        protected void BlockPolus( CoreNameRange polusNameRange )
            {
            foreach ( CoreName polusName in polusNameRange )
                BlockPolus( polusName );
            }



        /// <summary>
        /// Разблокировать полюс
        /// </summary>
        /// <param name="polusName">Имя полюса</param>
        protected void UnblockPolus( CoreName polusName )
            {
            //Если есть такой объект слежения
            if ( this.spyObjectList.ContainsKey( polusName ) )
                {
                SpyPolus spyPolusInfo = this.spyObjectList[ polusName ] as SpyPolus;

                //Если это полюс
                if ( spyPolusInfo != null )
                    {
                    spyPolusInfo.UnblockPolus();
                    }
                }
            }



        /// <summary>
        /// Разблокировать диапазон полюсов
        /// </summary>
        /// <param name="polusNameRange">Диапазон</param>
        protected void UnblockPolus( CoreNameRange polusNameRange )
            {
            foreach ( CoreName polusName in polusNameRange )
                UnblockPolus( polusName );
            }
        }
    }
