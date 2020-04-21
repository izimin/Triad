using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Коды ошибок
    /// </summary>
    internal struct Err
        {
        /// <summary>
        /// Ошибки лексического разбора
        /// </summary>
        public struct Lexer
            {
            /// <summary>
            /// Максимальная длина строки бит
            /// </summary>
            public const int BitStringIsTooLong = 64;
            /// <summary>
            /// Неверный формат записи символа
            /// </summary>
            public const int WrongCharFormat = 100;
            /// <summary>
            /// Незакрытый комментарий
            /// </summary>
            public const int NotClosedCommentary = 101;
            /// <summary>
            /// Незакрытая строка
            /// </summary>
            public const int NotClosedString = 102;
            /// <summary>
            /// Неизвестный символ
            /// </summary>
            public const int UnknownChar = 103;
            /// <summary>
            /// Неверный формат вещественного числа
            /// </summary>
            public const int WrongRealFormat = 104;
            /// <summary>
            /// Неверный формат целого числа
            /// </summary>
            public const int WrongIntegerFormat = 105;
            /// <summary>
            /// Незакрытая битовая строка
            /// </summary>
            public const int NotClosedBitString = 106;
            /// <summary>
            /// Недопустимый символ в битовой строке
            /// </summary>
            public const int WrongSymbolInBitSTring = 107;
            /// <summary>
            /// Слишком длинная битовая строка
            /// </summary>
            public const int TooLongBitString = 108;
            }


        /// <summary>
        /// Ошибки синтаксического и семантического разбора
        /// </summary>
        public struct Parser
            {
            /// <summary>
            /// Неверный тип
            /// </summary>
            public struct Type
                {
                /// <summary>
                /// Неверный тип переменной
                /// </summary>
                public struct Var
                    {
                    /// <summary>
                    /// Неизвестный тип переменной
                    /// </summary>
                    public const int Unknown = 150;

                    /// <summary>
                    /// Нужен другой тип
                    /// </summary>
                    public struct Need
                        {
                        /// <summary>
                        /// Должно быть целое
                        /// </summary>
                        public const int Integer = 155;
                        /// <summary>
                        /// Тип выражения должен быть целым или вещественным
                        /// </summary>
                        public const int IntegerOrReal = 163;
                        /// <summary>
                        /// Необходим логический тип
                        /// </summary>
                        public const int Boolean = 168;
                        /// <summary>
                        /// Тип выражения должен быть строковым
                        /// </summary>
                        public const int String = 172;
                        /// <summary>
                        /// Тип выражения должен быть логическим или битовым
                        /// </summary> 
                        public const int BooleanOrBit = 173;
                        }

                    /// <summary>
                    /// Недопустимый в этом контексте тип
                    /// </summary>
                    public struct WrongType
                        {
                        /// <summary>
                        /// Несовместимые типы в простом выражении
                        /// </summary>
                        public const int InSimpleExpr = 302;
                        /// <summary>
                        /// Несовместимые типы в операторе assign
                        /// </summary>
                        public const int InAssign = 308;
                        /// <summary>
                        /// Недопустимые типы в операции +
                        /// </summary>
                        public const int InPlus = 303;
                        /// <summary>
                        /// Недопустимые типы в операции Or/And
                        /// </summary>
                        public const int InOrAnd = 304;
                        /// <summary>
                        /// Недопустимые типы в операции Star/Slash
                        /// </summary>
                        public const int InStarSlash = 306;
                        /// <summary>
                        /// Недопустимые типы в операции Residue of division (остаток от деления)
                        /// </summary>
                        public const int InResidueOfDivision = 325;
                        /// <summary>
                        /// Недопустимые типы в операции ARROW
                        /// </summary>
                        public const int InArrow = 307;
                        /// <summary>
                        /// Массив имеют раличные размерности
                        /// </summary>
                        public const int NotCompatibleDimensionArrayInAssign = 310;
                        /// <summary>
                        /// Недопустимые типы при возврате значения функции
                        /// </summary>
                        public const int InReturn = 311;
                        }
                    }

                /// <summary>
                /// Неверный тип полюса
                /// </summary>
                public struct Polus
                    {
                    /// <summary>
                    /// Нужен другой тип полюса
                    /// </summary>
                    public struct Need
                        {
                        /// <summary>
                        /// Тип полюса должен быть Output
                        /// </summary>
                        public const int Output = 165;
                        /// <summary>
                        /// Тип полюса должен быть Input
                        /// </summary>
                        public const int Input = 166;
                        }
                    }
                }


            /// <summary>
            /// Недопустимое значение
            /// </summary>
            public struct Value
                {
                /// <summary>
                /// Нужно другое значение
                /// </summary>
                public struct Need
                    {
                    /// <summary>
                    /// Должна быть константа
                    /// </summary>
                    public const int Constant = 156;
                    /// <summary>
                    /// Выражение должно быть неотрицательным
                    /// </summary>
                    public const int NotNegative = 169;
                    /// <summary>
                    /// Шаг в цикле for должен быть положительным
                    /// </summary>
                    public const int Positive = 171;
                    /// <summary>
                    /// Значение выражения не должно быть константой
                    /// </summary>
                    public const int NotConstant = 159;
                    }
                }


            /// <summary>
            /// Неверный контекст
            /// </summary>
            public struct Usage
                {
                /// <summary>
                /// Неверное употребление знака минус
                /// </summary>
                public const int WrongMinusUsage = 151;

                /// <summary>
                /// Объект с таким именем уже описан
                /// </summary>
                public const int DeclaredAgain = 300;
                /// <summary>
                /// Объект с таким именем не был описан
                /// </summary>
                public const int NotDeclared = 301;
                /// <summary>
                /// Использование индексированного типа не допускается
                /// </summary>
                public const int NeedNotIndexed = 305;
                /// <summary>
                /// Необходим spy-объект
                /// </summary>
                public const int NeedSpyObject = 311;
                /// <summary>
                /// Необходимо указать диапазон объектов
                /// </summary>
                public const int NeedRange = 323;
                /// <summary>
                /// Диапазоны объектов не допустимы
                /// </summary>
                public const int NeedNotRange = 324;
                /// <summary>
                /// Тип-множество здесь недопустимо
                /// </summary>
                public const int NeedNotSet = 313;
                /// <summary>
                /// Необходим массив или мн-во
                /// </summary>
                public const int NeedIndexedOrSet = 314;
                /// <summary>
                /// Тип выражения не может быть приведен к указанному типу
                /// </summary>
                public const int UnableToCastType = 315;


                /// <summary>
                /// Неверное использование полюса
                /// </summary>
                public struct Polus
                    {
                    /// <summary>
                    /// Нижняя граница диапазона превосходит верхнюю
                    /// </summary>
                    public const int LowIndexIsGreaterThanTopInRange = 320;
                    }


                /// <summary>
                /// Неверное использование событий
                /// </summary>
                public struct Event
                    {
                    /// <summary>
                    /// Обращение к неописанному имени события
                    /// </summary> 
                    public const int NotDeclared = 311;
                    /// <summary>
                    /// Событие с таким именем уже было описано
                    /// </summary>
                    public const int DeclaredAgain = 312;
                    }


                /// <summary>
                /// Неверное использование design переменной
                /// </summary>
                public struct DesignVar
                    {
                    /// <summary>
                    /// Тип design переменной не соответствует типу design типа
                    /// </summary>
                    public const int NotCompatibleWithDesignType = 318;
                    /// <summary>
                    /// Неожидаемый тип design переменной
                    /// </summary>
                    public const int NotExpectedTypeCode = 316;
                    }


                /// <summary>
                /// Модельный тип
                /// </summary>
                public struct DesignType
                    {
                    /// <summary>
                    /// Модельный тип с таким именем описан не был
                    /// </summary>
                    public const int NotDeclared = 315;
                    }


                /// <summary>
                /// Информационная процедура
                /// </summary>
                public struct IProcedure
                    {
                    /// <summary>
                    /// ИП не возращается никакого значения
                    /// </summary>
                    public const int NoReturnedValue = 312;
                    }


                /// <summary>
                /// Список параметров
                /// </summary>
                public struct ParameterList
                    {
                    /// <summary>
                    /// Указаны не все параметры
                    /// </summary>
                    public const int NotEnoughParameters = 321;
                    /// <summary>
                    /// Указаны лишние параметры
                    /// </summary>
                    public const int TooManyParameters = 322;
                    }


                /// <summary>
                /// Неверное использование массива
                /// </summary>
                public struct Array
                    {
                    /// <summary>
                    /// Переменная не является массивом
                    /// </summary>
                    public const int VarIsNotArray = 157;
                    /// <summary>
                    /// Указаны не все индексы
                    /// </summary>
                    public const int LostIndex = 158;
                    /// <summary>
                    /// Указаны лишние индексы
                    /// </summary>
                    public const int TooManyIndexes = 317;
                    /// <summary>
                    /// Это не индексированная переменная
                    /// </summary>
                    public const int ArrayIsNotVar = 164;
                    /// <summary>
                    /// Индекс выходит за допустимые границы
                    /// </summary>
                    public const int OutOfArrayBound = 160;
                    }


                /// <summary>
                /// Неверное использование цикла for
                /// </summary>
                public struct For
                    {
                    /// <summary>
                    /// Значение начального выражения в цикле for to больше конечного
                    /// </summary>
                    public const int InitExprIsGreaterThanTerminal = 161;
                    /// <summary>
                    /// Значение начального выражения в цикле for downto меньше конечного
                    /// </summary>
                    public const int InitExprIsLowerThanTerminal = 162;
                    }

                
                /// <summary>
                /// Неверное использование цикла foreach
                /// </summary>
                public struct Foreach
                    {
                    /// <summary>
                    /// Тип переменной-счетчика и множества/массива не совпадают
                    /// </summary>
                    public const int IncompatibleTypes = 174;
                    }

                
                /// <summary>
                /// Недопустимый констект
                /// </summary>
                public struct Context
                    {
                    /// <summary>
                    /// Неверный контекст Case
                    /// </summary>
                    public const int Case = 167;
                    /// <summary>
                    /// Недопустимый контекст объявления переменной
                    /// </summary>
                    public const int VarDeclaration = 152;
                    }
                }


            /// <summary>
            /// Неверные начальные символы
            /// </summary>
            public struct WrongStartSymbol
                {
                /// <summary>
                /// Рутина
                /// </summary>
                public const int Routine = 200;
                /// <summary>
                /// Тип
                /// </summary>
                public const int Type = 201;
                /// <summary>
                /// Объявление полюса
                /// </summary>
                public const int PolusDeclaration = 202;
                /// <summary>
                /// Имя полюса в объявлении
                /// </summary>
                public const int PolusDeclarationName = 204;
                /// <summary>
                /// Имя переменной в объявлении
                /// </summary>
                public const int VarDeclarationName = 205;
                /// <summary>
                /// Простой множитель
                /// </summary>
                public const int SimpleFactor = 207;
                /// <summary>
                /// Оператор
                /// </summary>
                public const int Statement = 209;
                /// <summary>
                /// Объявление события
                /// </summary>
                public const int EventDeclarationName = 211;
                /// <summary>
                /// Структура
                /// </summary>
                public const int Structure = 212;
                /// <summary>
                /// Объявление структурной переменной
                /// </summary>
                public const int StuctVarDeclaration = 213;
                /// <summary>
                /// Структурный множитель
                /// </summary>
                public const int StructFactor = 214;
                /// <summary>
                /// Объявление design переменной
                /// </summary>
                public const int DesignVarDeclaration = 215;
                /// <summary>
                /// Объявления вершины
                /// </summary>
                public const int NodeDeclaration = 218;
                /// <summary>
                /// Соединение
                /// </summary>
                public const int Connection = 220;
                /// <summary>
                /// Структурная константа
                /// </summary>
                public const int StructConstant = 222;
                /// <summary>
                /// Секция include
                /// </summary>
                public const int IncludeSection = 223;
                /// <summary>
                /// Модель
                /// </summary>
                public const int Model = 224;
                /// <summary>
                /// Модель
                /// </summary>
                public const int HeaderName = 225;
                /// <summary>
                /// Список параметров функции
                /// </summary>
                public const int FunctionParameterList = 226;
                /// <summary>
                /// Информационная процедура
                /// </summary>
                public const int IProcedure = 227;
                /// <summary>
                /// Условия моделирования
                /// </summary>
                public const int ICondition = 228;
                /// <summary>
                /// Объявление spy-объекта
                /// </summary>
                public const int SpyObjectDeclaration = 231;
                /// <summary>
                /// Ссылка на объект или диапазон объектов
                /// </summary>
                public const int ObjectReference = 232;
                /// <summary>
                /// Условие в операторе case ИП
                /// </summary>
                public const int IPCaseCondition = 221;
                /// <summary>
                /// Дизайн
                /// </summary>
                public const int Design = 233;
                /// <summary>
                /// Spy-объект
                /// </summary>
                public const int SpyObject = 234;
                }


            /// <summary>
            /// Неверные конечные символы
            /// </summary>
            public struct WrongEndSymbol
                {
                /// <summary>
                /// Тип
                /// </summary>
                public const int Type = 250;
                /// <summary>
                /// Имя полюса в его объявлении
                /// </summary>
                public const int PolusDeclarationName = 252;
                /// <summary>
                /// Секция инициализации
                /// </summary>
                public const int InitialPart = 253;
                /// <summary>
                /// Событие
                /// </summary>
                public const int Event = 254;
                /// <summary>
                /// Константа
                /// </summary>
                public const int Constant = 255;
                /// <summary>
                /// Имя переменной в объявлении
                /// </summary>
                public const int VarDeclarationName = 256;
                /// <summary>
                /// Оператор
                /// </summary>
                public const int Statement = 257;
                /// <summary>
                /// Индекс переменной
                /// </summary>
                public const int PolusVarIndex = 259;
                /// <summary>
                /// Выражение в скобках
                /// </summary>
                public const int ExprInPar = 260;
                /// <summary>
                /// Рутина
                /// </summary>
                public const int Routine = 261;
                /// <summary>
                /// Имя события
                /// </summary>
                public const int EventDeclarationName = 262;
                /// <summary>
                /// Структура
                /// </summary>
                public const int Structure = 263;
                /// <summary>
                /// Объявление вершины
                /// </summary>
                public const int NodeDeclaration = 265;
                /// <summary>
                /// Объявление design переменной
                /// </summary>
                public const int DesignVarDeclaration = 267;
                /// <summary>
                /// Одиночный заголовок
                /// </summary>
                public const int SingleHeader = 268;
                /// <summary>
                /// Структурная константа
                /// </summary>
                public const int StructConstant = 269;
                /// <summary>
                /// Соединение
                /// </summary>
                public const int Connection = 273;
                /// <summary>
                /// Секция include
                /// </summary>
                public const int IncludeSection = 275;
                /// <summary>
                /// Модель
                /// </summary>
                public const int Model = 276;
                /// <summary>
                /// Имя модели
                /// </summary>
                public const int HeaderName = 277;
                /// <summary>
                /// Список параметров функции
                /// </summary>
                public const int FunctionParameterList = 278;
                /// <summary>
                /// Секция обработки информационной процедуры
                /// </summary>
                public const int Handling = 279;
                /// <summary>
                /// Секция заключительной обработки информационной процедуры
                /// </summary>
                public const int Processing = 280;
                /// <summary>
                /// Информационная процедура
                /// </summary>
                public const int IProcedure = 281;
                /// <summary>
                /// Условия моделирования
                /// </summary>
                public const int ICondition = 282;
                /// <summary>
                /// Ссылка на объект или диапазон объектов
                /// </summary>
                public const int ObjectReference = 283;
                /// <summary>
                /// Дизайн
                /// </summary>
                public const int Design = 284;
                /// <summary>
                /// Константное множество
                /// </summary>
                public const int ConstantSet = 285;

                }
            }

        public struct Generator
            {
            /// <summary>
            /// Неверное имя файла
            /// </summary>
            public const int InvalidFileName = 350;
            /// <summary>
            /// Ошибка компиляции
            /// </summary>
            public const int Compilation = 351;
            }
        };

    }
