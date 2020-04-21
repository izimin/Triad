using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TriadCompiler;

namespace TriadPad
    {

    /// <summary>
    /// Класс для ввода кода из RichEdit
    /// </summary>
    public class InputRichEdit : Input
        {
        /// <summary>
        /// 	<para> Конструктор класса <see cref="InputRichEdit"/> .</para>
        /// </summary>
        /// <param Name="textBox"> Контрол откуда идет чтение
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// 	<para>Значение аргумента <paramref Name="textBox"/> равно <langword Name="null"/>.</para>
        /// </exception>
        public InputRichEdit( RichTextBox textBox )
            {
            if ( textBox == null )
                throw new ArgumentNullException( "textBox" );

            this.textBox = textBox;
            }


        /// <summary>
        /// Построчное чтение
        /// </summary>
        /// <returns>Прочитанный символ (null, если читать нечего)</returns>
        public override string GetLine()
            {
            if ( nextLineNumber < textBox.Lines.Length )
                {
                nextLineNumber++;
                return textBox.Lines[ nextLineNumber - 1 ];
                }
            else
                return null;
            }



        /// <summary>
        /// Читаемый контрол
        /// </summary>
        private RichTextBox textBox;

        /// <summary>
        /// Номер строки для следующего чтения
        /// </summary>
        private uint nextLineNumber = 0;
        }

    /// <summary>
    /// Класс для вывода кода в RichEdit
    /// </summary>
    public class OutputRichEdit : Output
        {
        /// <summary>
        /// 	<para> Конструктор класса <see cref="OutputRichEdit"/> .</para>
        /// </summary>
        /// <param Name="textBox">
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// 	<para>Значение аргумента <paramref Name="textBox"/> равно <langword Name="null"/>.</para>
        /// </exception>
        public OutputRichEdit( RichTextBox textBox )
            {
            if ( textBox == null )
                throw new ArgumentNullException( "textBox" );

            this.textBox = textBox;
            textBox.Clear();
            }

        /// <summary>
        /// Вывести строчку без перевода строки
        /// </summary>
        /// <param Name="line">Выводимая строка</param>
        /// <exception cref="ArgumentNullException">
        /// 	<para>Значение аргумента <paramref Name="line"/> равно <langword Name="null"/>.</para>
        /// </exception>
        public override void Print( string line )
            {
            if ( line == null )
                throw new ArgumentNullException( "line" );

            textBox.AppendText( line );
            }

        /// <summary>
        /// Вывести строчку
        /// </summary>
        /// <param Name="line">Выводимая строка</param>
        /// <exception cref="ArgumentNullException">
        /// 	<para>Значение аргумента <paramref Name="line"/> равно <langword Name="null"/>.</para>
        /// </exception>
        public override void PrintLine( string line )
            {
            if ( line == null )
                throw new ArgumentNullException( "line" );

            if ( textBox.Lines.Length != 0 )
                line = "\n" + line;

            textBox.AppendText( line );
            }

        /// <summary>
        /// Контрол для записи
        /// </summary>
        private RichTextBox textBox;
        }


    /// <summary>
    /// Описание возникшей ошибки
    /// </summary>
    public class ErrorDescription
        {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        /// <param name="lineNumber">Номер строки с ошибкой</param>
        /// <param name="chNumber">Номер символа, где возникла ошибка</param>
        public ErrorDescription( string message, int lineNumber, int chNumber )
            {
            if ( message == null )
                throw new ArgumentNullException( "message" );

            this.message = message;
            this._lineNumber = lineNumber;
            this._chNumber = chNumber;
            }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        private string message;
        /// <summary>
        /// Номер строки с ошибкой
        /// </summary>
        private int _lineNumber;
        /// <summary>
        /// Номер символа, где возникла ошибка
        /// </summary>
        private int _chNumber;

        /// <summary>
        /// Номер строки с ошибкой
        /// </summary>
        public int lineNumber
            {
            get
                {
                return _lineNumber; 
                }
            }

        /// <summary>
        /// Номер символа, где возникла ошибка
        /// </summary>
        public int chNumber
            {
            get
                {
                return _chNumber;
                }
            }


        /// <summary>
        /// Строковое предсатвление
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            {
            return message;
            }
        }


    /// <summary>
    /// Класс для составления списка ошибок и мест их возникновения
    /// </summary>
    public class IOErrorListener : IOListing
        {
        /// <summary>
        /// 	<para> Конструктор класса <see cref="IOErrorListener"/> .</para>
        /// </summary>
        /// <param Name="input"> Источник кода
        /// </param>
        /// <param Name="output"> Приемник листинга
        /// </param>
        public IOErrorListener( Input input, Output output )
            : base( input, output )
            {
            }

        /// <summary>
        /// Показ ошибки
        /// </summary>
        /// <param Name="message">Текст сообщения</param>
        /// <exception cref="ArgumentNullException">
        /// 	<para>Значение аргумента <paramref Name="message"/> равно <langword Name="null"/>.</para>
        /// </exception>
        public override void ShowError( string message )
            {
            if ( message == null )
                throw new ArgumentNullException( "message" );

            ErrorDescription error = new ErrorDescription( message, this.lineNumber, this.linePosition ); ;
            registeredErrors.Add( error );
            base.ShowError( message );
            }

        /// <summary>
        /// Получить зарегистрированные ошибки
        /// </summary>
        /// <returns>Список описаний ошибок</returns>
        public ErrorDescription[] getRegisteredErrors()
            {
            ErrorDescription[] resultList = new ErrorDescription[ registeredErrors.Count ];
            registeredErrors.CopyTo( resultList );
            return resultList;
            }

        /// <summary>
        /// Список зарегистрированных ошибок
        /// </summary>
        private List<ErrorDescription> registeredErrors = new List<ErrorDescription>();
        }

    }
