using System;
using System.Collections.Generic;
using System.Text;

using TriadCompiler.Code.Generator;

namespace TriadCompiler
    {
    /// <summary>
    /// Режимы работы компилятора
    /// </summary>
    internal enum CodeBuilderMode
        {
        /// <summary>
        /// Компиляция модели
        /// </summary>
        BuildModel,
        /// <summary>
        /// Компиляция рутин
        /// </summary>
        BuildRoutine,
        /// <summary>
        /// Компиляция структур
        /// </summary>
        BuildStructure,
          /// <summary>
        /// Компиляция информационных процедур
        /// </summary>
        BuildIProcedure,
        /// <summary>
        /// Компиляция условий моделирования
        /// </summary>
        BuildICondition,
        /// <summary>
        /// Компиляция дизайна
        /// </summary>
        BuildDesign,
        /// <summary>
        /// Тестирование модели
        /// </summary>
        TestModel,
        /// <summary>
        /// Тестирование рутин
        /// </summary>
        TestRoutine,
        /// <summary>
        /// Тестирование структур
        /// </summary>
        TestStructure,
        /// <summary>
        /// Тестирование информационных процедур
        /// </summary>
        TestIProcedure,
        /// <summary>
        /// Тестирование условий моделирования
        /// </summary>
        TestICondition,
        /// <summary>
        /// Тестирование дизайна
        /// </summary>
        TestDesign
        }


    /// <summary>
    /// Фабрика для классов для текущего режима компиляции
    /// </summary>
    internal abstract class Fabric
        {
        /// <summary>
        /// Защищенный конструктор
        /// </summary>
        protected Fabric()
            {
            }

        /// <summary>
        /// Экземпляр фабрики (одиночка)
        /// </summary>
        public static Fabric Instance
            {
            get
                {
                if ( instance == null )
                    switch ( compileMode )
                        {
                        //Трансляция моделей
                        case CodeBuilderMode.BuildModel:
                            instance = new ModelCompileFabric();
                            break;
                        //Трансляция структур
                        case CodeBuilderMode.BuildStructure:
                            instance = new StructureCompileFabric();
                            break;
                        //Трансляция рутин
                        case CodeBuilderMode.BuildRoutine:
                            instance = new RoutineCompileFabric();
                            break;
                        //Трансляция ИП
                        case CodeBuilderMode.BuildIProcedure:
                            instance = new IProcedureCompileFabric();
                            break;
                        //Трансляция условий моделирования
                        case CodeBuilderMode.BuildICondition:
                            instance = new IConditionCompileFabric();
                            break;
                        //Трансляция дизайна
                        case CodeBuilderMode.BuildDesign:
                            instance = new DesignCompileFabric();
                            break;
                        //Тестирование рутин
                        case CodeBuilderMode.TestRoutine:
                            instance = new RoutineTestFabric();
                            break;
                        //Тестирование структур
                        case CodeBuilderMode.TestStructure:
                            instance = new StructureTestFabric();
                            break;
                        //Тестирование моделей
                        case CodeBuilderMode.TestModel:
                            instance = new ModelTestFabric();
                            break;
                        //Тестирование информационных процедур
                        case CodeBuilderMode.TestIProcedure:
                            instance = new IProcedureTestFabric();
                            break;
                        //Тестирование условий моделирования
                        case CodeBuilderMode.TestICondition:
                            instance = new IConditionTestFabric();
                            break;
                        //Тестирование дизайна
                        case CodeBuilderMode.TestDesign:
                            instance = new DesignTestFabric();
                            break;
                        default:
                            throw new InvalidOperationException( "Недопустимый режим работы фабрики классов" );
                        }
                return instance;
                }
            set
                {
                instance = value;
                }
            }


        /// <summary>
        /// Текущий ввод-вывод
        /// </summary>
        public static IO IO
            {
            get
                {
                return currentIO;
                }
            set
                {
                currentIO = value;              
                }
            }


        /// <summary>
        /// Подготовить фабрику классов для новой компиляции
        /// </summary>
        public static void ReloadFabric( CodeBuilderMode mode )
            {
            //Если фабрика уже создана
            if ( instance != null )
                {
                //Перезагружаем сканнер в любом случае
                scanner.Reload();

                //Если режим работы не изменился, то перезагружаем все классы
                if ( compileMode == mode )
                    {
                    //Очищаем регистратор ошибок
                    Instance.ErrReg.Reload(); 
                 
                    //Перезагружаем построитель кода
                    Instance.Builder.Reload();
                    }
                //Если режим работы изменился, то создаем новую фабрику
                else
                    {
                    compileMode = mode;
                    instance = null;
                    }
                }
            //Иначе просто создаем новую фабрику
            else
                {                
                compileMode = mode;
                }
            }


        /// <summary>
        /// Получить регистратор ошибок
        /// </summary>
        public virtual ErrorReg ErrReg
            {
            get
                {
                if ( this.err == null )
                    this.err = new ErrorReg();
                return this.err;
                }
            }


        /// <summary>
        /// Получить сканер символов
        /// </summary>
        public Scanner Scanner
            {
            get
                {
                return scanner;
                }
            }


        /// <summary>
        /// Получить построитель кода
        /// </summary>
        public virtual CodeBuilder Builder
            {
            get
                {
                if ( this.codeBuilder == null )
                    this.codeBuilder = new CodeBuilder();
                return this.codeBuilder;
                }
            set
                {
                this.codeBuilder = value;
                }
            }


        /// <summary>
        /// Получить парсер
        /// </summary>
        public virtual CommonParser Parser
            {
            get
                {
                throw new InvalidOperationException( "Неизвестный парсер" );
                }
            set
                {
                this.parser = value;
                }
            }


        /// <summary>
        /// Экземпляр этого класса
        /// </summary>
        private static Fabric instance = null;
        /// <summary>
        /// Текущий режим
        /// </summary>
        private static CodeBuilderMode compileMode = CodeBuilderMode.BuildStructure;
        /// <summary>
        /// Текущий ввод-вывод
        /// </summary>
        private static IO currentIO = new IO( new Input(), new Output() );

        /// <summary>
        /// Регистратор ошибок
        /// </summary>
        protected ErrorReg err = null;
        /// <summary>
        /// Сканер символов
        /// </summary>
        protected static Scanner scanner = new Scanner();
        /// <summary>
        /// Парсер
        /// </summary>
        protected CommonParser parser = null;
        /// <summary>
        /// Построитель кода
        /// </summary>
        protected CodeBuilder codeBuilder = null;
        /// <summary>
        /// Генератор кода
        /// </summary>
        protected CommonGenerator codeGenerator = null;
        }


    /// <summary>
    /// Фабрика классов для компиляции модели
    /// </summary>
    internal class ModelCompileFabric : Fabric
        {
        /// <summary>
        /// Получить парсер
        /// </summary>
        public override CommonParser Parser
            {
            get
                {
                if ( this.parser == null )
                    this.parser = new ModelParser();
                return this.parser;
                }
            }


        /// <summary>
        /// Получить построитель кода
        /// </summary>
        public override CodeBuilder Builder
            {
            get
                {
                if ( this.codeBuilder == null )
                    this.codeBuilder = new GraphCodeBuilder();
                return this.codeBuilder;
                }
            }
        }

    
    /// <summary>
    /// Фабрика классов для компиляции структур
    /// </summary>
    internal class StructureCompileFabric : Fabric
        {
        /// <summary>
        /// Получить парсер
        /// </summary>
        public override CommonParser Parser
            {
            get
                {
                if ( this.parser == null )
                    this.parser = new StructureParser();
                return this.parser;
                }
            }

        /// <summary>
        /// Получить построитель кода
        /// </summary>
        public override CodeBuilder Builder
            {
            get
                {
                if ( this.codeBuilder == null )
                    this.codeBuilder = new GraphCodeBuilder();
                return this.codeBuilder;
                }
            }
        }


    /// <summary>
    /// Фабрика классов для компиляции рутин
    /// </summary>
    internal class RoutineCompileFabric : Fabric
        {
        /// <summary>
        /// Получить парсер
        /// </summary>
        public override CommonParser Parser
            {
            get
                {
                if ( this.parser == null )
                    this.parser = new RoutineParser();
                return this.parser;
                }
            }

        /// <summary>
        /// Получить построитель кода
        /// </summary>
        public override CodeBuilder Builder
            {
            get
                {
                if ( this.codeBuilder == null )
                    this.codeBuilder = new RoutineCodeBuilder();
                return this.codeBuilder;
                }
            }
        }


    /// <summary>
    /// Фабрика классов для компиляции информационных процедур
    /// </summary>
    internal class IProcedureCompileFabric : Fabric
        {
        /// <summary>
        /// Получить парсер
        /// </summary>
        public override CommonParser Parser
            {
            get
                {
                if ( this.parser == null )
                    this.parser = new InfProcedureParser();
                return this.parser;
                }
            }

        /// <summary>
        /// Получить построитель кода
        /// </summary>
        public override CodeBuilder Builder
            {
            get
                {
                if ( this.codeBuilder == null )
                    this.codeBuilder = new IProcedureCodeBuilder();
                return this.codeBuilder;
                }
            }
        }


    /// <summary>
    /// Фабрика классов для компиляции условий моделирования
    /// </summary>
    internal class IConditionCompileFabric : Fabric
        {
        /// <summary>
        /// Получить парсер
        /// </summary>
        public override CommonParser Parser
            {
            get
                {
                if ( this.parser == null )
                    this.parser = new SimConditionParser();
                return this.parser;
                }
            }


        /// <summary>
        /// Получить построитель кода
        /// </summary>
        public override CodeBuilder Builder
            {
            get
                {
                if ( this.codeBuilder == null )
                    this.codeBuilder = new IConditionCodeBuilder();
                return this.codeBuilder;
                }
            }
        }


    /// <summary>
    /// Фабрика классов для компиляции дизайна
    /// </summary>
    internal class DesignCompileFabric : Fabric
        {
        /// <summary>
        /// Получить парсер
        /// </summary>
        public override CommonParser Parser
            {
            get
                {
                if ( this.parser == null )
                    this.parser = new DesignParser();
                return this.parser;
                }
            }


        /// <summary>
        /// Получить построитель кода
        /// </summary>
        public override CodeBuilder Builder
            {
            get
                {
                if ( this.codeBuilder == null )
                    this.codeBuilder = new GraphCodeBuilder();
                return this.codeBuilder;
                }
            }
        }



    /// <summary>
    /// Фабрика классов для тестирования модели
    /// </summary>
    internal class ModelTestFabric : ModelCompileFabric
        {
        /// <summary>
        /// Получить регистратор ошибок
        /// </summary>
        public override ErrorReg ErrReg
            {
            get
                {
                if ( this.err == null )
                    this.err = new TestErrorReg();
                return this.err;
                }
            }
        }


    /// <summary>
    /// Фабрика классов для тестирования рутин
    /// </summary>
    internal class RoutineTestFabric : RoutineCompileFabric
        {
        /// <summary>
        /// Получить регистратор ошибок
        /// </summary>
        public override ErrorReg ErrReg
            {
            get
                {
                if ( this.err == null )
                    this.err = new TestErrorReg();
                return this.err;
                }
            }
        }


    /// <summary>
    /// Фабрика классов для тестирования структур
    /// </summary>
    internal class StructureTestFabric : StructureCompileFabric
        {
        /// <summary>
        /// Получить регистратор ошибок
        /// </summary>
        public override ErrorReg ErrReg
            {
            get
                {
                if ( this.err == null )
                    this.err = new TestErrorReg();
                return this.err;
                }
            }
        }


    /// <summary>
    /// Фабрика классов для тестирования информационных процедур
    /// </summary>
    internal class IProcedureTestFabric : IProcedureCompileFabric
        {
        /// <summary>
        /// Получить регистратор ошибок
        /// </summary>
        public override ErrorReg ErrReg
            {
            get
                {
                if ( this.err == null )
                    this.err = new TestErrorReg();
                return this.err;
                }
            }
        }


    /// <summary>
    /// Фабрика классов для тестирования условий моделирования
    /// </summary>
    internal class IConditionTestFabric : IConditionCompileFabric
        {
        /// <summary>
        /// Получить регистратор ошибок
        /// </summary>
        public override ErrorReg ErrReg
            {
            get
                {
                if ( this.err == null )
                    this.err = new TestErrorReg();
                return this.err;
                }
            }
        }


    /// <summary>
    /// Фабрика классов для тестирования дизайна
    /// </summary>
    internal class DesignTestFabric : DesignCompileFabric
        {
        /// <summary>
        /// Получить регистратор ошибок
        /// </summary>
        public override ErrorReg ErrReg
            {
            get
                {
                if ( this.err == null )
                    this.err = new TestErrorReg();
                return this.err;
                }
            }
        }
        
    }