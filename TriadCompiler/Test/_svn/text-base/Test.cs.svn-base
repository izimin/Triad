using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace TriadCompiler
    {
    /// <summary>
    /// Константы Test
    /// </summary>
    internal struct TestConst
        {
        /// <summary>
        /// Файл, содержащий список файлов с текстами тестов и файлов с кодами ошибок для рутин
        /// </summary>
        public const string RoutineTestFileList = "..\\..\\Test\\File\\Routine\\TestList.txt";
        /// <summary>
        /// Файл, содержащий список файлов с текстами тестов и файлов с кодами ошибок для структур
        /// </summary>
        public const string StructureTestFileList = "..\\..\\Test\\File\\Structure\\TestList.txt";
        /// <summary>
        /// Файл, содержащий список файлов с текстами тестов и файлов с кодами ошибок для моделей
        /// </summary>
        public const string ModelTestFileList = "..\\..\\Test\\File\\Model\\TestList.txt";
        /// <summary>
        /// Файл, содержащий список файлов с текстами тестов и файлов с кодами ошибок для инф. процедур
        /// </summary>
        public const string IProcedureFileList = "..\\..\\Test\\File\\InfProcedure\\TestList.txt";
        /// <summary>
        /// Файл, содержащий список файлов с текстами тестов и файлов с кодами ошибок для условий моделирования
        /// </summary>
        public const string IConditionFileList = "..\\..\\Test\\File\\SimCondition\\TestList.txt";

        /// <summary>
        /// Сообщение об ошибке открытия файла
        /// </summary>
        public const string CanNotReadTestFileListMessage = "Нельзя прочитать файл со списком тестов";
        /// <summary>
        /// Сообщение о неверном формате кода ожидаемой ошибки
        /// </summary>
        public const string WrongFormatErrorMessage = "Неверный формат кода сообщения об ошибке";
        /// <summary>
        /// Сообщение о неожидаемой ошибке
        /// </summary>
        public const string ErrorWasNotExpectedMessage = "Неожидаемая ошибка";
        /// <summary>
        /// Сообщение об отсутствии ожидаемой ошибки
        /// </summary>
        public const string ExpectedErrorIsMissing = "Отсутствие ожидаемой ошибки";
        };
    


    /// <summary>
    /// Возможные объекты тестирования
    /// </summary>
    [Flags]
    internal enum ObjectForTesting
        {
        /// <summary>
        /// Структура
        /// </summary>
        Structure = 1,
        /// <summary>
        /// Рутина
        /// </summary>
        Routine = 2,
        /// <summary>
        /// Модель
        /// </summary>
        Model = 4,
        /// <summary>
        /// Информационная процедура
        /// </summary>
        InfProcedure = 8,
        /// <summary>
        /// Условия моделирования
        /// </summary>
        SimCondition = 16,
        /// <summary>
        /// Дезайн
        /// </summary>
        Design = 32
        }    


    /// <summary>
    /// Предназначен для тестирования
    /// </summary>
    internal class Test
            {
            /// <summary>
            /// Начать тестирование
            /// </summary>
            /// <param name="objectForTesting">Объект для тестирования</param>
            public static void Start( ObjectForTesting objectForTesting )
                {                
                try
                    {
                    //Тестирование рутин
                    if ( ( (short)objectForTesting & (short)ObjectForTesting.Routine ) == (short)ObjectForTesting.Routine )
                        {
                        Console.WriteLine( "\n\tТестирование рутин" );
                        DoTestList( TestConst.RoutineTestFileList, CompilerFacade.TestRoutine );
                        }

                    //Тестирование структур
                    if ( ( (short)objectForTesting & (short)ObjectForTesting.Structure ) == (short)ObjectForTesting.Structure )
                        {
                        Console.WriteLine( "\n\tТестирование структур" );
                        DoTestList( TestConst.StructureTestFileList, CompilerFacade.TestStructure );
                        }


                    //Тестирование моделей                    
                    if ( ( ( short )objectForTesting & ( short )ObjectForTesting.Model ) == ( short )ObjectForTesting.Model )
                        {
                        Console.WriteLine( "\n\tТестирование моделей" );
                        DoTestList( TestConst.ModelTestFileList, CompilerFacade.TestModel );
                        }
                    
                    //Тестирование информационных процедур
                    if ( ( (short)objectForTesting & (short)ObjectForTesting.InfProcedure ) == (short)ObjectForTesting.InfProcedure )
                        {
                        Console.WriteLine( "\n\tТестирование информационных процедур" );
                        DoTestList( TestConst.IProcedureFileList, CompilerFacade.TestIProcedure );
                        }

                    //Тестирование условий моделирования
                    if ( ( (short)objectForTesting & (short)ObjectForTesting.SimCondition ) == (short)ObjectForTesting.SimCondition )
                        {
                        Console.WriteLine( "\n\tТестирование условий моделирования" );
                        DoTestList( TestConst.IConditionFileList, CompilerFacade.TestICondition );
                        }
                    }
                catch ( IOException e )
                    {
                    throw new IOException( TestConst.CanNotReadTestFileListMessage, e );
                    }
                }


        /// <summary>
        /// Функция тестирования
        /// </summary>
        /// <param name="io">Ввод-вывод</param>
        /// <param name="fileName">Имя файла</param>
        private delegate void TestMethod( IO io, string fileName );

        
        /// <summary>
        /// Выполнить список тестов
        /// </summary>
        /// <param name="testListFileName">Имя файла с тестами</param>
        /// <param name="testMethod">Метод тестирования</param>
        private static void DoTestList( string testListFileName, TestMethod testMethod )
            {
            using ( StreamReader testListFile = new StreamReader( testListFileName ) )
                {
                string codeFileName = "";
                Output output = new ConsoleOutput();

                string testDirPath = Path.GetDirectoryName( testListFileName );
                //Чтение файла со списком тестов для рутин 
                while ( testListFile.Peek() >= 0 )
                    {
                    codeFileName = testListFile.ReadLine();
                    InputFile input = new InputFile( testDirPath + "\\" + codeFileName );
                    IOTest io = new IOTest( input, output );
                    Console.WriteLine( "Проверка файла <" + codeFileName + ">" );
                    testMethod( io, codeFileName );
                    }
                }
            }
            }
        }
