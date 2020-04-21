using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Обобщенный контейнер переменнных
    /// </summary>
    public class CommonArea
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        private CommonArea()
            {
            AddArea();
            }


        /// <summary>
        /// Получить экземпляр класса
        /// </summary>
        public static CommonArea Instance
            {
            get
                {
                if ( instance == null )
                    instance = new CommonArea();
                return instance;
                }
            }


        /// <summary>
        /// Создать новую область
        /// </summary>
        public static void CreateNewArea()
            {
            if ( instance != null )
                {
                instance.RemoveAllAreas();

                instance = null;
                }
            }


        /// <summary>
        /// Добавить переменную указанного типа в текущую область видимости
        /// </summary>
        /// <param name="varType">Тип переменной</param>
        public void Register( ICommonType varType )
            {
            //Если нет ни одной области видимости
            if ( areaList.Count == 0 )
                return;
            Area area = areaList[ areaList.Count - 1 ];
            //Если ошибка приведения типов
            if ( area == null )
                return;

            //Если объект с таким именем уже есть в этой области видимости
            if ( area.typeList.ContainsKey( varType.Name ) )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.Usage.DeclaredAgain );
                area.typeList[ varType.Name ].Add( varType );
                }
            else
                {
                //Новый список типов
                List<ICommonType> typeList = new List<ICommonType>();
                typeList.Add( varType );
                //Добавляем переменную в список
                area.typeList.Add( varType.Name, typeList );
                }
            }



        /// <summary>
        /// Проверить, зарегистрирован ли указанный тип с указанным именем
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="isRequiredType">Тип</param>
        /// <returns>True, если зарегистрирован</returns>
        private bool IsSomeTypeRegistered( string name, IsRequiredType isRequiredType )
            {
            for ( int areaIndex = areaList.Count - 1 ; areaIndex >= 0 ; areaIndex-- )
                {
                Area area = areaList[ areaIndex ];
                if ( area == null )
                    return false;

                //Если такое имя используется
                if ( area.typeList.ContainsKey( name ) )
                    foreach ( ICommonType type in area.typeList[ name ] )
                        if ( isRequiredType( type ) )
                            return true;
                }
            return false;
            }



        /// <summary>
        /// Проверить, зарегистрирован ли граф с таким именем
        /// </summary>
        /// <param name="varName">Имя переменной</param>
        /// <returns>True, если зарегистрирован</returns>
        public bool IsGraphRegistered( string varName )
            {
            return IsSomeTypeRegistered( varName, delegate( ICommonType type )
                {
                    if ( type is IDesignVarType )
                        if ((type as IDesignVarType).TypeCode == DesignTypeCode.Structure)
                            return true;
                    return false;
                });
            }


        //======by jum======
        /// <summary>
        /// Проверить, зарегистрирована ли вершина с таким именем
        /// </summary>
        /// <param name="varName">Имя переменной</param>
        /// <returns>True, если зарегистрирован</returns>
        public bool IsNodeRegistered( string varName )
        {
            return IsSomeTypeRegistered(varName, delegate(ICommonType type)
            {
                if (type is VarType)
                    if ((type as VarType).Code == TypeCode.Node)
                        return true;
                return false;
            });
        }


        /// <summary>
        /// Проверить, зарегистрирована ли функция с таким именем
        /// </summary>
        /// <param name="functionName">Имя функции</param>
        /// <returns>True, если зарегистрирована</returns>
        public bool IsFunctionRegistered( string functionName )
            {
            return IsSomeTypeRegistered( functionName, delegate( ICommonType type )
                {
                    return type is FunctionType;
                } );
            }


        /// <summary>
        /// Проверить, зарегистрирована ли ИП с таким именем
        /// </summary>
        /// <param name="functionName">Имя ИП</param>
        /// <returns>True, если зарегистрирована</returns>
        public bool IsIProcedureRegistered( string functionName )
            {
            return IsSomeTypeRegistered( functionName, delegate( ICommonType type )
                {
                    return type is IProcedureType;
                } );
            }


        /// <summary>
        /// Проверить, зарегистрировано ли событие с таким именем
        /// </summary>
        /// <param name="eventName">Имя события</param>
        /// <returns>True, если зарегистрировано</returns>
        public bool IsEventRegistered( string eventName )
            {
            return IsSomeTypeRegistered( eventName, delegate( ICommonType type )
                {
                    return type is EventType;
                } );
            }


        /// <summary>
        /// Функция проверки соответствия типа
        /// </summary>
        /// <param name="type">Проверяемый тип</param>
        /// <returns>True, если тип подходит</returns>
        private delegate bool IsRequiredType( ICommonType type );


        /// <summary>
        /// Получить требуемый тип
        /// </summary>
        /// <param name="usedName">Использованное имя</param>
        /// <returns>Требуемый тип</returns>
        public T GetType<T>( string usedName )
            where T : class
            {
            Area area;

            //Признак того, что на указанное имя зарегистрирован пустой тип
            bool emptyTypeExists = false;

            for ( int areaIndex = areaList.Count - 1 ; areaIndex >= 0 ; areaIndex-- )
                {
                area = areaList[ areaIndex ];

                if ( area == null )
                    return null;

                //Если такое имя зарегистрировано
                if ( area.typeList.ContainsKey( usedName ) )
                    foreach ( ICommonType type in area.typeList[ usedName ] )
                        //Если это пустой тип
                        if ( type == null )
                            {
                            emptyTypeExists = true;
                            continue;
                            }
                        //Если этот тип подходит
                        else if ( type is T )
                            {
                            return (T)type;
                            }
                }

            if ( emptyTypeExists )
                return null;

            //Используем последнюю область видимости
            area = areaList[ areaList.Count - 1 ];

            //Если это имя встречается в первый раз
            if ( !area.typeList.ContainsKey( usedName ) )
                {
                area.typeList.Add( usedName, new List<ICommonType>() );
                
                //Регистрируем пустой тип
                area.typeList[ usedName ].Add( null );
                }

            Fabric.Instance.ErrReg.Register( Err.Parser.Usage.NotDeclared );

            return null;
            }


        /// <summary>
        /// Добавить новую область видимости
        /// </summary>
        public void AddArea()
            {
            areaList.Add( new Area() );
            }


        /// <summary>
        /// Удалить текущую область видимости
        /// </summary>
        public void RemoveArea()
            {
            if ( areaList.Count == 0 )
                return;

            areaList.RemoveAt( areaList.Count - 1 );
            }


        /// <summary>
        /// Очистить все области видимости переменных
        /// </summary>
        public void RemoveAllAreas()
            {
            while ( this.areaList.Count != 0 )
                RemoveArea();
            }



        /// <summary>
        /// Экземпляр этого класса
        /// </summary>
        private static CommonArea instance = null;

        /// <summary>
        /// Область видимости
        /// </summary>
        public class Area
            {
            /// <summary>
            /// Список зарегистрированных типов
            /// Каждому имени сопоставляется список типов, которые его используют
            /// </summary>
            public SortedList<string, List<ICommonType>> typeList = new SortedList<string, List<ICommonType>>();
            }

        /// <summary>
        /// Список областей видимости
        /// </summary>
        private List<Area> areaList = new List<Area>();
        }
    }
