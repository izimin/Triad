using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Для тестирования
    /// </summary>
    internal class IOTest : IO
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="input">Класс, который отвечает за чтение информации</param>
        /// <param name="output">Отвечает за печать листинга</param>
        public IOTest( Input input, Output output )
            : base( input, output )
            {
            lineLast = input.GetLine();
            }


        /// <summary>
        /// Начать считывать символы со следующей строки.
        /// Следующим считанным символом станет пробел.
        /// </summary>
        public override void SetNextString()
            {
            linePos = lineLast.Length - 1;
            }


        /// <summary>
        /// Посимвольный ввод
        /// </summary>
        /// <returns>Прочитанный символ</returns>
        public override char GetCh()
            {
            //Возвращаемый символ
            char ch = InputConst.EndOfFile;

            //Если файл полностью прочитан, то возвращем ch = EndOfFile
            if ( lineLast == null )
                {
                return ch;
                }

            //Если прочитана не вся последняя строка
            if ( linePos < lineLast.Length - 1 )
                {
                linePos++;
                ch = lineLast[ linePos ];
                }
            //Печатаем пробел в конце строки (чтобы строки не "слипались")
            else if ( linePos == lineLast.Length - 1 )
                {
                ch = ' ';
                linePos++;
                }
            //Иначе, если файл не прочитан полностью, то читаем следующую непустую строку
            else
                {
                //Если на предыдущей строке остались неудаленные ожидаемые ошибки
                if ( expectedErrorCodeList.Count > 0 )
                    {
                    foreach ( int errorCode in expectedErrorCodeList )
                        {
                        output.PrintLine( "\t(" + currLineNumber + "): " +
                            TestConst.ExpectedErrorIsMissing + " - " + errorCode );
                        }
                    expectedErrorCodeList.Clear();
                    }
                do
                    {
                    lineLast = Input.GetLine();
                    currLineNumber++;

                    //Если файл прочитан полностью, то возвращем ch = EndOfFile
                    if ( lineLast == null )
                        {
                        return ch;
                        }

                    if ( lineLast != "" )
                        {
                        //Если это коды ожидаемых ошибок
                        string errorListStr = lineLast.TrimStart( ' ', '\t' );
                        if ( errorListStr != "" )
                            {
                            if ( errorListStr[ 0 ] == '$' )
                                {
                                try
                                    {
                                    string[] errorCodeStringList = errorListStr.TrimStart( '$' ).Split( ',' );
                                    foreach ( string errorCodeString in errorCodeStringList )
                                        {
                                        //Код этой ошибки уже был распознан
                                        if ( recognizedErrorCodeList.ContainsKey( errorCodeString ) )
                                            {
                                            expectedErrorCodeList.Add( recognizedErrorCodeList[ errorCodeString ]  );
                                            }
                                        else
                                            {
                                            int errorCode = Int32.Parse( errorCodeString );
                                            recognizedErrorCodeList.Add( errorCodeString, errorCode );
                                            expectedErrorCodeList.Add( errorCode );
                                            }
                                        }
                                    }
                                catch ( FormatException e )
                                    {
                                    throw new FormatException( TestConst.WrongFormatErrorMessage, e );
                                    }
                                lineLast = "";
                                }
                            }
                        }

                    }
                while ( lineLast == "" );

                linePos = 0;
                ch = lineLast[ 0 ];

                }
            return ch;
            }


        /// <summary>
        /// Протестировать ошибку (проверить ожидаема ли она)
        /// </summary>
        /// <param name="errorCode">Код ошибки</param>
        public void TestError( uint errorCode )
            {
            if ( expectedErrorCodeList.Count > 0 )
                {
                //Ошибка соответствует ожидаемой
                if ( expectedErrorCodeList[ 0 ] == errorCode )
                    {
                    expectedErrorCodeList.RemoveAt( 0 );
                    }
                else
                    {
                    output.PrintLine( "\t(" + currLineNumber + "): "
                        + TestConst.ErrorWasNotExpectedMessage + " - " + errorCode );
                    }
                }
            else
                {
                output.PrintLine( "\t(" + currLineNumber + "): "
                    + TestConst.ErrorWasNotExpectedMessage + " - " + errorCode );
                }
            }


        //Последняя прочитанная из файла кода строка
        private string lineLast = "";
        //Позиция текущего символа в последней прочитанной строке
        private int linePos = -1;
        //Номер текущей строки
        private int currLineNumber = 1;

        /// <summary>
        /// Таблица уже распознанных целых чисел (нужна для оптимизации)
        /// </summary>
        private static Dictionary<string, int> recognizedErrorCodeList = new Dictionary<string, int>();


        //Список кодов ожидаемых ошибок в текущей строке
        List<int> expectedErrorCodeList = new List<int>();
        };
    }
