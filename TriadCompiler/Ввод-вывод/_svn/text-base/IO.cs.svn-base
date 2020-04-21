using System;
using System.IO;
using System.Text;


namespace TriadCompiler
    {
    /// <summary>
    /// Константы IO
    /// </summary>
    public struct IOConst
        {
        /// <summary>
        /// Максимальное число ошибок в одной строке
        /// </summary>
        public const int MaxErrorCountInLine = 20;
        /// <summary>
        /// Сообщение о превышении max числа ошибок в строке
        /// </summary>
        public const string TooManyErrorsInLineMessage = "Too many err in line";
        }


    /// <summary>
    /// Класс IO - абстрактный класс, обеспечивающий по-символьный ввод при помощи
    /// функции GetCh и показ ошибок при помощи ShowError
    /// </summary>
    public class IO
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="input">Ввод</param>
        /// <param name="output">Вывод</param>
        public IO( Input input, Output output )
            {
            this.input = input;
            this.output = output;
            }


        /// <summary>
        /// Начать считывать символы со следующей строки.
        /// Следующим считанным символом станет пробел.
        /// </summary>
        public virtual void SetNextString()
            {
            }

        /// <summary>
        /// Посимвольный ввод
        /// </summary>
        /// <returns>Прочитанный символ</returns>
        public virtual char GetCh()
            {
            return InputConst.EndOfFile;
            }


        /// <summary>
        /// Показ ошибки
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        public virtual void ShowError( string message )
            {}


        /// <summary>
        /// Ввод
        /// </summary>
        public Input Input
            {
            get
                {
                return this.input;
                }
			}


		/// <summary>
		/// Вывод
		/// </summary>
		public Output Output
			{
			get
				{
				return this.output;
				}
			}


        /// <summary>
        /// Класс, отвечающий за вывод листинга
        /// </summary>
        protected Output output;
		/// <summary>
		/// Ввод текста
		/// </summary>
		protected Input input;
        };


    /// <summary>
    /// Класс IOListing - класс, обеспечивающий по-символьный ввод при помощи
    /// функции GetCh и показ ошибок при помощи ShowError.
    /// При этом он формирует листинг программы.
    /// В конструктор класса должны передаваться классы, отвечающие за
    /// ввод данных и запись листинга 
    /// </summary>
    public class IOListing : IO
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="input">Класс, который отвечает за чтение информации</param>
        /// <param name="output">Отвечает за печать листинга</param>
        public IOListing( Input input, Output output )
            : base ( input, output )
            {
            lastLine = input.GetLine();
            }

        
        /// <summary>
        /// Начать считывать символы со следующей строки.
        /// Следующим считанным символом станет пробел.
        /// </summary>
        public override void SetNextString()
            {
            linePosition = lastLine.Length - 1;
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
            if ( lastLine == null )
                {
                //Печатаем все ненапечатанные ошибки
                PrintAllErrorsInLastLine();
                return ch;
                }

            //Если прочитана не вся последняя строка
            if ( linePosition < lastLine.Length - 1 )
                {
                linePosition++;
                ch = lastLine[ linePosition ];

                //Учет табуляций
                if ( ch == '\t' )
                    {
                    tabCountInCurrLine ++;
                    }
                }
            //Печатаем пробел в конце строки (чтобы строки не "слипались")
            else if ( linePosition == lastLine.Length - 1 )
                {
                ch = ' ';
                linePosition++;
                }
            //Иначе, если файл не прочитан полностью, то читаем следующую непустую строку
            else
                {
                do
                    {
                    //Печатаем текущую строку в файл листинга
                    output.PrintLine( lastLine );

                    //Печатаем все ошибки в этой строке
                    PrintAllErrorsInLastLine();

                    lastLine = Input.GetLine();
                    lineNumber++;

                    //Если файл прочитан полностью, то возвращем ch = EndOfFile
                    if ( lastLine == null )
                        {
                        return ch;
                        }
                    }
                while ( lastLine == "" );

                linePosition = 0;
                tabCountInCurrLine = 0;

                ch = lastLine[ 0 ];

                //Учет табуляций
                if ( ch == '\t' )
                    {
                    tabCountInCurrLine++;
                    }
                }
            return ch;
            }


        /// <summary>
        /// Показ ошибки
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        /// <exception cref="ArgumentNullException">
        /// 	<para>Значение аргумента <paramref Name="message"/> равно <langword Name="null"/>.</para>
        /// </exception>
        public override void ShowError( string message )
            {
            if ( message == null )
                throw new ArgumentNullException( "message" );

            //Если сообщений в строке не много
            if ( errorCountInLastLine < IOConst.MaxErrorCountInLine - 1 )
                {
                errorsInLastLine[ errorCountInLastLine ].message = message;
                errorsInLastLine[ errorCountInLastLine ].position = linePosition + tabCountInCurrLine * InputConst.TabSize;
                errorCountInLastLine++;
                }
            //Осталось одна позиция для ошибки
            else if ( errorCountInLastLine == IOConst.MaxErrorCountInLine - 1 )
                {
                errorsInLastLine[ errorCountInLastLine ].message = IOConst.TooManyErrorsInLineMessage;
                errorsInLastLine[ errorCountInLastLine ].position = 0;
                errorCountInLastLine++;
                }
            //Нет места для новых ошибок
            else
            { }
            }


        /// <summary>
        /// Напечатать все ошибки, относящиеся к последней строке
        /// исходного файла (они добавляются функцией PrintError)
        /// </summary>
        private void PrintAllErrorsInLastLine()
            {
            //Строка вида "_____^"
            StringBuilder marker = new StringBuilder();

            for ( int messageIndex = 0; messageIndex < errorCountInLastLine; messageIndex++ )
                {
                marker.Length = 0;
                for ( int chIndex = 0; chIndex < errorsInLastLine[ messageIndex ].position; chIndex++ )
                    {
                    marker.Append( ' ' );
                    }
                marker.Append( "^ " );
                output.PrintLine( marker + errorsInLastLine[ messageIndex ].message );
                }
            errorCountInLastLine = 0;
            }


        //Последняя прочитанная из файла кода строка
        private string lastLine = "";
        /// <summary>
        /// Номер текущей строки
        /// </summary>
        protected int lineNumber = 0;
        /// <summary>
        /// Позиция текущего символа в последней прочитанной строке
        /// </summary>
        protected int linePosition = -1;
        /// <summary>
        /// Число табуляций в последней строке
        /// </summary>
        protected int tabCountInCurrLine = 0;

        //Структура сообщения об ошибке
        private struct ErrorMessage
            {
            public string message;
            public int position;
            };

        //Сообщения об ошибках для текущей строки исходного файла
        private ErrorMessage[] errorsInLastLine = new ErrorMessage[ IOConst.MaxErrorCountInLine ];
        
        //Число ошибок в текущей строке
        private int errorCountInLastLine = 0;
        };
    }


