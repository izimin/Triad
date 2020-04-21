using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TriadCore
    {
    /// <summary>
    /// Найдена ошибка в ходе тестирования
    /// </summary>
    [Serializable]
    public class TestFailedException : Exception
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public TestFailedException()
            {
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message">Сообщение</param>
        public TestFailedException( string message )
            : base( message )
            {
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="innerException">Вложенное исключение</param>
        public TestFailedException( string message, Exception innerException )
            : base( message, innerException )
            {
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="si"></param>
        /// <param name="sc"></param>
        protected TestFailedException( SerializationInfo si, StreamingContext sc )
            : base( si, sc )
            {
            }
        }


    /// <summary>
    /// Стандартный класс для тестирования
    /// </summary>
    public class TestCommon
        {
        /// <summary>
        /// Событие начала тестирования
        /// </summary>
        protected event EventHandler OnTest = null;

        
        /// <summary>
        /// Начать тестирирование
        /// </summary>
        public void DoTest()
            {
            bool testFailed = false;
            Console.WriteLine( "Start testing (" + this.GetType().Name + ")" );
            if ( OnTest != null )
                {
                foreach ( EventHandler function in OnTest.GetInvocationList() )
                    {
                    try
                        {
                        function.Invoke( this, new EventArgs() );
                        }
                    catch ( TestFailedException )
                        {
                        Console.WriteLine( "\tTesting <" + function.Method.Name + "> failed (не выполнено условие проверки)" );
                        testFailed = true;
                        }
                    catch ( ApplicationException e )
                        {
                        Console.WriteLine( "\tTesting <" + function.Method.Name + "> failed (" + e.Message + ")" );
                        testFailed = true;
                        }
                    }
                }
            if ( !testFailed )
                {
                Console.WriteLine( "OK" );
                }
            else
                {
                Console.WriteLine( "FAILED" );
                }
            }
        }
    }
