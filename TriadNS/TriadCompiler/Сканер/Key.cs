using System;
using System.Collections.Generic;

namespace TriadCompiler
    {
    /// <summary>
    /// Коды лексем. Численные значения у некоторых элементов указаны явно,
    /// так как такие же коды имеют ошибки вида "Должен идти символ..." 
    /// </summary>
    public enum Key
        {
        /// <summary>
        /// Идентфикатор
        /// </summary>
        Identificator = 1,

        /// <summary>
        /// Умножение
        /// </summary>
        Star = 2,

        /// <summary>
        /// Деление
        /// </summary>
        Slash = 3,

        /// <summary>
        /// Равенство
        /// </summary>
        Equal = 4,

        /// <summary>
        /// Запятая
        /// </summary>
        Comma = 5,

        /// <summary>
        /// Точка с запятой
        /// </summary>
        Semicolon = 6,

        /// <summary>
        /// Двоеточие
        /// </summary>
        Colon = 7,

        /// <summary>
        /// Точка
        /// </summary>
        Point,

        /// <summary>
        /// Возведение в степень
        /// </summary>
        Power = 9,

        /// <summary>
        /// Открывающаяся скобка
        /// </summary>
        LeftPar = 10,

        /// <summary>
        /// Закрывающаяся скобка
        /// </summary>
        RightPar = 11,

        /// <summary>
        /// Открывающаяся квадратная скобка
        /// </summary>
        LeftBracket = 12,

        /// <summary>
        /// Закрывающаяся квадратная скобка
        /// </summary>
        RightBracket = 13,

        /// <summary>
        /// Меньше
        /// </summary>
        Later = 16,

        /// <summary>
        /// Больше
        /// </summary> 
        Greater = 17,

        /// <summary>
        /// Меньше или равно
        /// </summary>
        LaterEqual = 18,

        /// <summary>
        /// Больше или равно
        /// </summary>
        GreaterEqual = 19,

        /// <summary>
        /// Не равно
        /// </summary>
        NotEqual = 20,

        /// <summary>
        /// Плюс
        /// </summary>
        Plus = 21,

        /// <summary>
        /// Минус
        /// </summary>
        Minus = 22,

        /// <summary>
        /// Отрицание
        /// </summary>
        Not = 23,

        /// <summary>
        /// Или
        /// </summary>
        Or = 24,

        /// <summary>
        /// И
        /// </summary>
        And = 25,

        /// <summary>
        /// Присваивание
        /// </summary>
        Assign = 26,

        /// <summary>
        /// Графическое обозначение дуги
        /// </summary>
        Connection = 27,

        /// <summary>
        /// Строка
        /// </summary>
        StringValue = 28,

        /// <summary>
        /// Левая фигурная скобка
        /// </summary>
        LeftFigurePar = 29,

        /// <summary>
        /// Правая фигурная скобка
        /// </summary>
        RightFigurePar = 30,

        /// <summary>
        /// Остаток от деления
        /// </summary>
        ResidueOfDivision = 31,

        /// <summary>
        /// Целое число
        /// </summary>
        IntegerValue,

        /// <summary>
        /// Логическая константа (true или false)
        /// </summary>
        BooleanValue,

        /// <summary>
        /// Вещественное число
        /// </summary>
        RealValue,

        /// <summary>
        /// Символ (буква)
        /// </summary>
        CharValue,

        /// <summary>
        /// Строка бит 
        /// </summary>
        BitStringValue,

        /// <summary>
        /// Код конца файла 
        /// </summary>
        EndOfFile,

        /// <summary>
        /// Начало рутины
        /// </summary>
        Routine = 50,

        /// <summary>
        /// Конец рутины
        /// </summary>
        EndRoutine = 51,

        /// <summary>
        /// Указание времени
        /// </summary>
        In = 52,

        /// <summary>
        /// Начало секции initialSet
        /// </summary>
        Initial = 53,

        /// <summary>
        /// Конец секции initialSet
        /// </summary>
        EndInitial = 54,

        /// <summary>
        /// Начало секции событие
        /// </summary>
        Event = 55,

        /// <summary>
        /// Конец секции событие
        /// </summary>
        EndEvent = 56,

        /// <summary>
        /// Конец условия в операторе if
        /// </summary>
        Then = 57,

        /// <summary>
        /// Начало секции итераций оператора цикла
        /// </summary>
        Do = 58,

        /// <summary>
        /// Коней цикла while
        /// </summary>
        EndWhile = 59,

        /// <summary>
        /// Конец цикла for
        /// </summary>
        EndFor = 60,

        /// <summary>
        /// Направление возрастания в цикле for
        /// </summary>
        To = 61,

        /// <summary>
        /// Конец оператора case
        /// </summary>
        EndCase = 62,

        /// <summary>
        /// Спецификация базового типа
        /// </summary>
        Of = 64,

        /// <summary>
        /// Шаг в цикле for
        /// </summary>
        By = 65,

        /// <summary>
        /// Конец условного оператора if
        /// </summary>
        EndIf = 66,

        /// <summary>
        /// Указание выходов в операторе посылки сообщений
        /// </summary>
        Through = 67,

        /// <summary>
        /// Конец объявления структуры
        /// </summary>
        EndStructure = 68,

        /// <summary>
        /// Начало тела структуры
        /// </summary>
        Define = 69,

        /// <summary>
        /// Указание типа создаваемой модельной переменной
        /// </summary>
        Be = 70,

        /// <summary>
        /// Указание имени файла
        /// </summary>
        From = 71,

        /// <summary>
        /// Конец описания модели
        /// </summary>
        EndModel = 72,

        /// <summary>
        /// Указание объекта наложения
        /// </summary>
        On = 73,

        /// <summary>
        /// Конец информационной процедуры
        /// </summary>
        EndInf = 74,

        /// <summary>
        /// Конец описания условий моделирования
        /// </summary>
        EndCond = 75,

        /// <summary>
        /// Конец секции обработки информационной процедуры
        /// </summary>
        EndHandling = 76,

        /// <summary>
        /// Конец секции заключительной обработки информационной процедуры
        /// </summary>
        EndProcessing = 77,

        /// <summary>
        /// Конец design
        /// </summary>
        EndDesign = 78,

        /// <summary>
        /// Направление убывания в цикле for
        /// </summary>
        DownTo,

        /// <summary>
        /// Массив
        /// </summary>
        Array,

        /// <summary>
        /// Разблокирование входных полюсов
        /// </summary>
        Available,

        /// <summary>
        /// Логический тип
        /// </summary>
        Boolean,

        /// <summary>
        /// Битовая строка
        /// </summary>
        Bit,

        /// <summary>
        /// Оператор break в операторе выбора
        /// </summary>
        Break,

        /// <summary>
        /// Отмена событий
        /// </summary>
        Cancel,

        /// <summary>
        /// Оператор case
        /// </summary>
        Case,

        /// <summary>
        /// Символьный тип
        /// </summary>
        Char,

        /// <summary>
        /// Начало вспомогательной ветви операторов в if
        /// </summary>
        Else,

        /// <summary>
        /// Начало цикла for
        /// </summary>
        For,

        /// <summary>
        /// Начало оператора if
        /// </summary>
        If,

        /// <summary>
        /// Входной тип полюса
        /// </summary>
        Input,

        /// <summary>
        /// Выходной тип полюса
        /// </summary>
        Output,

        /// <summary>
        /// Целочисленный тип
        /// </summary>
        Integer,

        /// <summary>
        /// Блокирование выходных полюсов
        /// </summary>
        Interlock,

        /// <summary>
        /// Неопределеный тип
        /// </summary>
        Notype,

        /// <summary>
        /// Оператор посылки сообщений
        /// </summary>
        Out,

        /// <summary>
        /// Вещественный тип
        /// </summary>
        Real,

        /// <summary>
        /// Оператор планирования событий
        /// </summary>
        Shedule,

        /// <summary>
        /// Строковый тип
        /// </summary>
        String,

        /// <summary>
        /// Начало оператора while
        /// </summary>
        While,

        /// <summary>
        /// Отладочная печать
        /// </summary>
        Print,

        /// <summary>
        /// Начало объявления структуры
        /// </summary>
        Structure,

        /// <summary>
        /// Объявление вершины
        /// </summary>
        Node,

        /// <summary>
        /// Объявление полюса
        /// </summary>
        Polus,

        /// <summary>
        /// Универсальный полюс
        /// </summary>
        InOut,

        /// <summary>
        /// Объявление дуги
        /// </summary>
        Arc,

        /// <summary>
        /// Объявление ребра
        /// </summary>
        Edge,

        /// <summary>
        /// Граф - ненаправленное кольцо
        /// </summary>
        UndirectCycle,

        /// <summary>
        /// Граф - направленное кольцо
        /// </summary>
        DirectCycle,

        /// <summary>
        /// Граф - ненаправленная цепочка
        /// </summary>
        UndirectPath,

        /// <summary>
        /// Граф - направленная цепочка
        /// </summary>
        DirectPath,

        /// <summary>
        /// Граф - ненаправленная звезда
        /// </summary>
        UndirectStar,

        /// <summary>
        /// Граф - направленная звезда
        /// </summary>
        DirectStar,

        /// <summary>
        /// Секция Include
        /// </summary>
        Include,

        /// <summary>
        /// Модель
        /// </summary>
        Model,

        /// <summary>
        /// Информационная процедура
        /// </summary>
        IProcedure,

        /// <summary>
        /// Условия моделирования
        /// </summary>
        SimCondition,

        /// <summary>
        /// Дизайн
        /// </summary>
        Design,

        /// <summary>
        /// Конструктор модельной переменной
        /// </summary>
        Let,

        /// <summary>
        /// Оператор начала моделирования
        /// </summary>
        Simulate,

        /// <summary>
        /// Оператор наложения
        /// </summary>
        Put,

        /// <summary>
        /// Начало секции обработки информационной процедуры
        /// </summary>
        Handling,

        /// <summary>
        /// Начало секции заключительной обработки информационной процедуры
        /// </summary>
        Processing,

        /// <summary>
        /// Пассивная переменная
        /// </summary>
        Passive,

        /// <summary>
        /// Оператор окончания моделирования
        /// </summary>
        Eor,

        /// <summary>
        /// Объявление множества
        /// </summary>
        Set,

        /// <summary>
        /// Оператор перебора элементов мн-ва
        /// </summary>
        Foreach,

        /// <summary>
        /// Пустой символ
        /// </summary>
        Nil,
        //by jum
        /// <summary>
        /// объявление графа
        /// </summary>
        Graph
        };


    /// <summary>
    /// Контейнер ключевых идентификаторов
    /// </summary>
    internal class KeyIdentificatorContainer
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        static KeyIdentificatorContainer()
            {
            FillKeyIdentificatorTable();
            }

        /// <summary>
        /// Заполнить таблицу ключевых идентификаторов
        /// </summary>
        private static void FillKeyIdentificatorTable()
            {
            //Рутина
            keyIdentificatorTable.Add( "ROUTINE", Key.Routine );
            keyIdentificatorTable.Add( "ENDROUT", Key.EndRoutine );

            //Секция инициализации
            keyIdentificatorTable.Add( "INITIAL", Key.Initial );
            keyIdentificatorTable.Add( "ENDI", Key.EndInitial );

            //Событие
            keyIdentificatorTable.Add( "EVENT", Key.Event );
            keyIdentificatorTable.Add( "ENDE", Key.EndEvent );

            //Планирование событий
            keyIdentificatorTable.Add( "SCHEDULE", Key.Shedule );
            keyIdentificatorTable.Add( "IN", Key.In );

            //Условный оператор
            keyIdentificatorTable.Add( "IF", Key.If );
            keyIdentificatorTable.Add( "THEN", Key.Then );
            keyIdentificatorTable.Add( "ELSE", Key.Else );
            keyIdentificatorTable.Add( "ENDIF", Key.EndIf );

            //Цикл while
            keyIdentificatorTable.Add( "WHILE", Key.While );
            keyIdentificatorTable.Add( "DO", Key.Do );
            keyIdentificatorTable.Add( "ENDW", Key.EndWhile );

            //Цикл for
            keyIdentificatorTable.Add( "FOR", Key.For );
            keyIdentificatorTable.Add( "TO", Key.To );
            keyIdentificatorTable.Add( "DOWNTO", Key.DownTo );
            keyIdentificatorTable.Add( "BY", Key.By );
            keyIdentificatorTable.Add( "ENDF", Key.EndFor );

            //Оператор case
            keyIdentificatorTable.Add( "CASE", Key.Case );
            keyIdentificatorTable.Add( "BREAK", Key.Break );
            keyIdentificatorTable.Add( "ENDC", Key.EndCase );

            //Оператор foreach
            keyIdentificatorTable.Add( "FOREACH", Key.Foreach );

            //Оператор cancel
            keyIdentificatorTable.Add( "CANCEL", Key.Cancel );

            //Типы
            keyIdentificatorTable.Add( "BOOLEAN", Key.Boolean );
            keyIdentificatorTable.Add( "BIT", Key.Bit );
            keyIdentificatorTable.Add( "CHAR", Key.Char );
            keyIdentificatorTable.Add( "INTEGER", Key.Integer );
            keyIdentificatorTable.Add( "REAL", Key.Real );
            keyIdentificatorTable.Add( "STRING", Key.String );
            keyIdentificatorTable.Add( "ARRAY", Key.Array );
            keyIdentificatorTable.Add( "SET", Key.Set );
            keyIdentificatorTable.Add( "OF", Key.Of );
            keyIdentificatorTable.Add( "NOTYPE", Key.Notype );

            //Посылка сообщений
            keyIdentificatorTable.Add( "OUT", Key.Out );
            keyIdentificatorTable.Add( "THROUGH", Key.Through );

            //Типы полюсов
            keyIdentificatorTable.Add( "INOUT", Key.InOut );
            keyIdentificatorTable.Add( "INPUT", Key.Input );
            keyIdentificatorTable.Add( "OUTPUT", Key.Output );

            //Действия над полюсами
            keyIdentificatorTable.Add( "AVAILABLE", Key.Available );
            keyIdentificatorTable.Add( "INTERLOCK", Key.Interlock );

            //Структура
            keyIdentificatorTable.Add( "STRUCTURE", Key.Structure );
            keyIdentificatorTable.Add( "DEF", Key.Define );
            keyIdentificatorTable.Add( "ENDSTR", Key.EndStructure );

            //Отладочная печать
            keyIdentificatorTable.Add( "PRINT", Key.Print );

            //Структурные переменные
            keyIdentificatorTable.Add( "NODE", Key.Node );
            keyIdentificatorTable.Add( "ARC", Key.Arc );
            keyIdentificatorTable.Add( "EDGE", Key.Edge );
            //by jum
            keyIdentificatorTable.Add( "GRAPH", Key.Graph);

            //Структурные константы
            keyIdentificatorTable.Add( "CYCLE", Key.UndirectCycle );
            keyIdentificatorTable.Add( "DCYCLE", Key.DirectCycle );
            keyIdentificatorTable.Add( "PATH", Key.UndirectPath );
            keyIdentificatorTable.Add( "DPATH", Key.DirectPath );
            keyIdentificatorTable.Add( "STAR", Key.UndirectStar );
            keyIdentificatorTable.Add( "DSTAR", Key.DirectStar );

            //Секция Include
            keyIdentificatorTable.Add( "INCLUDE", Key.Include );
            keyIdentificatorTable.Add( "FROM", Key.From );

            //Модель
            keyIdentificatorTable.Add( "MODEL", Key.Model );
            keyIdentificatorTable.Add( "ENDMOD", Key.EndModel );

            //Информационная процедура
            keyIdentificatorTable.Add( "INFPROCEDURE", Key.IProcedure );
            keyIdentificatorTable.Add( "ENDINF", Key.EndInf );

            keyIdentificatorTable.Add( "HANDLING", Key.Handling );
            keyIdentificatorTable.Add( "ENDH", Key.EndHandling );

            keyIdentificatorTable.Add( "PROCESSING", Key.Processing );
            keyIdentificatorTable.Add( "ENDP", Key.EndProcessing );

            keyIdentificatorTable.Add( "PASSIVE", Key.Passive );
            keyIdentificatorTable.Add( "POLUS", Key.Polus );
            
            //Условия моделирования
            keyIdentificatorTable.Add( "SIMCONDITION", Key.SimCondition );
            keyIdentificatorTable.Add( "ENDCOND", Key.EndCond );

            //Дизайн
            keyIdentificatorTable.Add( "DESIGN", Key.Design );           
            keyIdentificatorTable.Add( "ENDDES", Key.EndDesign );           
            keyIdentificatorTable.Add( "SIMULATE", Key.Simulate );                       

            //Конструктор модельной переменной
            keyIdentificatorTable.Add( "LET", Key.Let );
            keyIdentificatorTable.Add( "BE", Key.Be );

            //Оператор наложения
            keyIdentificatorTable.Add( "PUT", Key.Put );
            keyIdentificatorTable.Add( "ON", Key.On );

            //Оператор окончания моделирования
            keyIdentificatorTable.Add( "EOR", Key.Eor );
            }


        /// <summary>
        /// Проверить, есть ли идентификатор в списке ключевых идентификаторов
        /// </summary>
        /// <param name="keyIdentificatorStringCode">Строковое значение идентификатора</param>
        /// <returns>True, если содержит</returns>
        public static bool Contains( string keyIdentificatorStringCode )
            {
            keyIdentificatorStringCode = TransformIdentificatorStringCode( keyIdentificatorStringCode );

            return keyIdentificatorTable.ContainsKey( keyIdentificatorStringCode );
            }


        /// <summary>
        /// Получить код ключевого идентфикатора
        /// </summary>
        /// <param name="keyIdentificatorStringCode">Строковое значение идентификатора</param>
        /// <returns>Код ключевого идентификатора</returns>
        public static Key GetKeyIdentificator( string keyIdentificatorStringCode )
            {
            keyIdentificatorStringCode = TransformIdentificatorStringCode( keyIdentificatorStringCode );

            if ( !Contains( keyIdentificatorStringCode ) )
                throw new ArgumentOutOfRangeException( "keyIdentificatorStringCode" );

            return keyIdentificatorTable[ keyIdentificatorStringCode ];
            }


        /// <summary>
        /// Преобразование, используемое для всех идентификаторов
        /// </summary>
        /// <param name="identificatorStringCode">Строковое значение идентификатора</param>
        /// <returns>Приведенное строковое значение идентификатора</returns>
        private static string TransformIdentificatorStringCode( string identificatorStringCode )
            {
            return identificatorStringCode.ToUpper();
            }


        /// <summary>
        /// Таблица ключевых идентификаторов
        /// </summary>
        private static Dictionary<string, Key> keyIdentificatorTable = new Dictionary<string, Key>();
        }
    }
