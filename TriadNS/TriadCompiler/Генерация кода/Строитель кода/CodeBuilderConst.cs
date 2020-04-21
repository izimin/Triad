using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Константы для создания кода
    /// </summary>
    internal struct Builder
        {
        /// <summary>
        /// Общие константы
        /// </summary>
        public struct Common
            {
            /// <summary>
            /// Название текущего пространства имен
            /// </summary>
            public const string Namespace = "TriadCore";
            /// <summary>
            /// Название метода, строящего экземпляр design типа
            /// </summary>
            public const string BuildMethod = "Build";
            /// <summary>
            /// Название класса множеств
            /// </summary>
            public const string SetClassName = "Set";
            //by jum
            /// <summary>
            /// Название класса вершин
            /// </summary>
            public const string NodeClassName = "Node";

            /// <summary>
            /// Инициализация массивов
            /// </summary>
            public struct ArrayInitializing
                {
                /// <summary>
                /// Имя класса-инициализатора
                /// </summary>
                public const string InitializingClass = "ArrayInitializer";
                /// <summary>
                /// Имя метода инициализации
                /// </summary>
                public const string InitializingMethod = "Initialize";
                /// <summary>
                /// Максимальная размерность массивов
                /// </summary>
                public const int MaxIndexCount = 3;
                }
            }


        /// <summary>
        /// Модельный переменные
        /// </summary>
        public struct Model
            {
            /// <summary>
            /// Имя базового для моделей класса
            /// </summary>
            public const string BaseClass = "GraphBuilder";
            /// <summary>
            /// Имя класса для представления моделей
            /// </summary>
            public const string ModelClass = "Graph";


            /// <summary>
            /// Наложение рутин
            /// </summary>
            public struct PutRoutine
                {
                /// <summary>
                /// Имя метода наложения рутины на все вершины графа
                /// </summary>
                public const string PutOnAllNodesMethod = "RegisterRoutineInAllNodes";
                /// <summary>
                /// Имя метода наложения рутины на одну вершину графа
                /// </summary>
                public const string PutOnOneNodeMethod = "RegisterRoutine";
                /// <summary>
                /// Имя метода, устанавливающего соответствие между полюсами рутины и вершины
                /// </summary>
                public const string AddPolusPairMethod = "AddPolusPair";
                /// <summary>
                /// Имя метода, очищающего список соответствий полюсов рутины и вершины
                /// </summary>
                public const string ClearPolusPairList = "ClearPolusPairList";
                }
            }


        /// <summary>
        /// Константы для имен объектов в ядре
        /// </summary>
        public struct CoreName
            {
            /// <summary>
            /// Имя класса для представления имен объектов в ядре
            /// </summary>
            public const string Name = "CoreName";
            /// <summary>
            /// Имя класса для представления диапазона имен объектов в ядре
            /// </summary>
            public const string Range = "CoreNameRange";
            /// <summary>
            /// Имя функции для сравнения
            /// </summary>
            public const string Compare = "Equals";
            }


        /// <summary>
        /// Константы для рутин
        /// </summary>
        public struct Routine
            {
            /// <summary>
            /// Название базового класса
            /// </summary>
            public const string BaseClass = "Routine";
            /// <summary>
            /// Имя переменной, хранящей текущее системное время
            /// </summary>
            public const string SystemTime = "SystemTime";
            /// <summary>
            /// Название функции обработки секции initialSet
            /// </summary>
            public const string Initial = "DoInitialize";

            /// <summary>
            /// Функции по работе с полюсами
            /// </summary>
            public struct Block
                {
                /// <summary>
                /// Имя функции для разблокировки полюса
                /// </summary>
                public const string Available = "UnblockPolus";
                /// <summary>
                /// Имя функции для блокировки полюса
                /// </summary>
                public const string Interlock = "BlockPolus";
                }

            /// <summary>
            /// Функции посылки сообщений
            /// </summary>
            public struct Send
                {
                /// <summary>
                /// Имя функции посылки сообщений
                /// </summary>
                public const string SendMessage = "SendMessageVia";
                /// <summary>
                /// Имя функции посылки сообщений через все выходные полюсы
                /// </summary>
                public const string SendMessageToAll = "SendMessageViaAllPoluses";
                }

            /// <summary>
            /// Имя функции отладочной печати
            /// </summary>
            public const string Print = "PrintMessage";

            /// <summary>
            /// Константы для обработки входящих сообщений
            /// </summary>
            public struct Receive
                {
                /// <summary>
                /// Название функции обработки сообщений
                /// </summary>
                public const string ReceiveMessage = "ReceiveMessageVia";
                /// <summary>
                /// Имя полюса, на который пришло сообщение
                /// </summary>
                public const string ReceivedPolus = "polusName";
                /// <summary>
                /// Имя пришедшего сообщения
                /// </summary>
                public const string ReceivedMessage = "message";
                /// <summary>
                /// Имя переменной, хранящей индекс полюса, принявшего сообщение
                /// </summary>
                public const string PolusIndex = "polusIndex";
                /// <summary>
                /// Имя метода, возращающего индекс полюса
                /// </summary>
                public const string GetPolusIndexMethod = "GetPolusIndex";
                }

            /// <summary>
            /// Планирование события
            /// </summary>
            public struct Shedule
                {
                ///// <summary>
                ///// Имя класса для регистрации обработчиков событий
                ///// </summary>
                //public const string EventHandler = "InternalEventHandler";
                /// <summary>
                /// Имя функции, планирующей события
                /// </summary>
                public const string EventShedule = "Sсhedule";
                /// <summary>
                /// Имя функции, отменяющей запланированные события
                /// </summary>
                public const string CancelEvent = "Cancel";
                }


            /// <summary>
            /// Имя функции, регистрирующей изменение значений переменных в рутине
            /// </summary>
            public const string DoVarChanging = "DoVarChanging";
            }


        /// <summary>
        /// Константы для структуры
        /// </summary>
        public struct Structure
            {
            /// <summary>
            /// Имя базового для структур класса
            /// </summary>
            public const string BaseClass = "GraphBuilder";
            /// <summary>
            /// Имя класса для представления графов
            /// </summary>
            public const string GraphClass = "Graph";

            /// <summary>
            /// Константы, относящиеся к построению структурных выражений
            /// </summary>
            public struct BuildExpr
                {
                /// <summary>
                /// Операции над графами
                /// </summary>
                public struct DinamicOperation
                    {
                    /// <summary>
                    /// Операция слияния
                    /// </summary>
                    public const string Unite = "Add";
                    /// <summary>
                    /// Операция вычитания
                    /// </summary>
                    public const string Substract = "Subtract";
                    /// <summary>
                    /// Операция пересечения
                    /// </summary>
                    public const string Intersect = "Multiply";
                    /// <summary>
                    /// Имя метода добавления дуги к графу
                    /// </summary>
                    public const string AddArcInGraph = "AddArc";
                    /// <summary>
                    /// Имя метода добавления ребра к графу
                    /// </summary>
                    public const string AddEdgeInGraph = "AddEdge";
                    }

                /// <summary>
                /// Декларативные операции
                /// </summary>
                public struct DeclareOperation
                    {
                    /// <summary>
                    /// Название метода объявления одиночной вершины в графе
                    /// </summary>
                    public const string DeclareNodeInGraph = "DeclareNode";
                    /// <summary>
                    /// Название метода объявления полюса в вершине
                    /// </summary>
                    public const string DecalarePolusInNode = "DeclarePolus";
                    /// <summary>
                    /// Название метода объявления полюса во всех вершинах графа
                    /// </summary>
                    public const string DeclarePolusInAllNodesInGraph = "DeclarePolusInAllNodes";
                    /// <summary>
                    /// Название метода доопределяющего граф
                    /// </summary>
                    public const string Complete = "CompleteGraph";
                    }


                /// <summary>
                /// Константы, относящиеся к стеку генерации структурного выражения
                /// </summary>
                public struct Stack
                    {
                    /// <summary>
                    /// Имя push метода
                    /// </summary>
                    public const string Push = "PushGraph";
                    /// <summary>
                    /// Имя pushNew метода
                    /// </summary>
                    public const string PushNew = "PushEmptyGraph";
                    
                    /// <summary>
                    /// Имя pushPath метода
                    /// </summary>
                    public const string PushNewUndirectPath = "PushEmptyUndirectPathGraph";
                    /// <summary>
                    /// Имя pushDPath метода
                    /// </summary>
                    public const string PushNewDirectPath = "PushEmptyDirectPathGraph";
                    /// <summary>
                    /// Имя pushCicle метода
                    /// </summary>
                    public const string PushNewUndirectCicle = "PushEmptyUndirectCicleGraph";
                    /// <summary>
                    /// Имя pushDCicle метода
                    /// </summary>
                    public const string PushNewDirectCicle = "PushEmptyDirectCicleGraph";
                    /// <summary>
                    /// Имя pushStar метода
                    /// </summary>
                    public const string PushNewUndirectStar = "PushEmptyUndirectStarGraph";
                    /// <summary>
                    /// Имя pushDStar метода
                    /// </summary>
                    public const string PushNewDirectStar = "PushEmptyDirectStarGraph";

                    /// <summary>
                    /// Имя pop метода
                    /// </summary>
                    public const string Pop = "PopGraph";
                    /// <summary>
                    /// Имя, по которому можно обратиться к самому верхнему элементу стека
                    /// </summary>
                    public const string First = "FirstInStackGraph";
                    /// <summary>
                    /// Имя, по которому можно обратиться ко второму элементу стека
                    /// </summary>
                    public const string Second = "SecondInStackGraph";
                    }
                }
            }

        /// <summary>
        /// Константы для информационной процедуры
        /// </summary>
        public struct IProcedure
            {
            /// <summary>
            /// Название базового класса
            /// </summary>
            public const string BaseClass = "IProcedure";
            /// <summary>
            /// Название функции получения значения для переменной в информационных процедурах
            /// </summary>
            public const string GetValueForVar = "GetSpyVarValue";
            /// <summary>
            /// Название функции установления значения для переменной в информационных процедурах
            /// </summary>
            public const string SetValueForVar = "SetSpyVarValue";
            /// <summary>
            /// Название функции, регистрирующей обработчик на изменение объекта, за которым следит информационная процедура 
            /// </summary>
            public const string RegisterSpyHandler = "RegisterSpyHandler";
            /// <summary>
            /// Название функции, регистрирующей в информационной процедуре spy-объект
            /// </summary>
            public const string RegisterSpyObject = "RegisterSpyObject";


            /// <summary>
            /// Секция handling
            /// </summary>
            public struct Handling
                {
                /// <summary>
                /// Секция обработки
                /// </summary>
                public const string DoHandling = "DoHandling";
                /// <summary>
                /// Имя изменившегося объекта в секции handling
                /// </summary>
                public const string SpyObjectNameInDoHandling = "spyObject";
                /// <summary>
                /// Имя поля в spy-объекте, содержащее пришедшее сообщение
                /// </summary>
                public const string MessageField = "Data";
                }


            /// <summary>
            /// Секция заключительной обработки
            /// </summary>
            public const string DoProcessing = "DoProcessing";
            /// <summary>
            /// Название функции, регистрирующей все spy-объекты в ИП
            /// </summary>
            public const string RegisterAllSpyObjects = "RegisterSpyObjects";
            /// <summary>
            /// Название функции, возращающей все out-переменные в ИП
            /// </summary>
            public const string GetOutVariables = "GetOutVariables";
            /// <summary>
            /// Функция получения объекта слежения
            /// </summary>
            public const string GetSpyObject = "GetSpyObject";
            /// <summary>
            /// Тип объекта слежения
            /// </summary>
            public const string SpyObject = "SpyObject";

            }

        /// <summary>
        /// Константы для условий моделирования
        /// </summary>
        public struct ICondition
            {
            /// <summary>
            /// Название базового класса
            /// </summary>
            public const string BaseClass = "ICondition";
            /// <summary>
            /// Метод, проверяющий условия окончания моделирования
            /// </summary>
            public const string DoCheck = "DoCheck";
            /// <summary>
            /// Метод, создающий ИП
            /// </summary>
            public const string AddIProcedure = "AddIProcedure";
            /// <summary>
            /// Метод, возвращающий добавленную ИП
            /// </summary>
            public const string GetIProcedure = "GetIProcedure";
            /// <summary>
            /// Метод, инициализирующий зарегистрированную ИП
            /// </summary>
            public const string InitializeIProcedure = "InitializeIProcedure";
            /// <summary>//by jum
            /// Граф модели
            /// </summary>
            public const string CurrentModel = "CurrentModel";
            }

        /// <summary>
        /// Константы для дизайна
        /// </summary>
        public struct Design
            {
            /// <summary>
            /// Метод начала моделирования 
            /// </summary>
            public const string BaseClass = "Design";
            /// <summary>
            /// Метод начала моделирования 
            /// </summary>
            public const string DoSimulate = "DoSimulate";
            /// <summary>
            /// Метод, возвращающий добавленное условие моделирования
            /// </summary>
            public const string GetICondition = "GetICondition";
            /// <summary>
            /// Функция создания объекта слежения
            /// </summary>
            public const string CreateSpyObject = "CreateSpyObject";
            /// <summary>
            /// Имя класса типа spy-объектов
            /// </summary>
            public const string SpyObjectType = "SpyObjectType";
            }        
        };

    }
