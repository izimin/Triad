using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TriadCompiler
    {
    /// <summary>
    /// Константы Input
    /// </summary>
    public struct InputConst
        {
        /// <summary>
        /// Код конца файла.
        /// </summary>
        public const char EndOfFile = (char)0;
        /// <summary>
        /// Сообщение об ошибке чтения файла
        /// </summary>
        public const string CouldNotReadFileMessage = "Файл с кодом не читается";
        /// <summary>
        /// Размер табуляции, измеренный в пробелах
        /// </summary>
        public const int TabSize = 7;
        };


    /// <summary>
    /// Класс Input отвечает за абстрактные операции по вводу данных.
    /// Данные можно читать построчно при помощи переопределяемой функции GetLine.
    /// Эта функция должна возвращать null  в случае, когда данные кончились.
    /// </summary>
    public class Input
        {
        /// <summary>
        /// Построчное чтение
        /// </summary>
        /// <returns>Прочитанный символ (null, если читать нечего)</returns>
        public virtual string GetLine()
            {
            return "";
            }
        };


    /// <summary>
    /// Класс InputFile отвечает за операции по вводу данных из файлов.
    /// Данные можно читать построчно при помощи функции GetLine.
    /// Если данные в файле прочитаны, то GetLine возвращает null.
    /// Конструктору нужно передать имя читаемого файла.
    /// </summary>
    internal class InputFile : Input
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="fileName">Имя читаемого файла</param>
        public InputFile( string fileName )
            {
            try
                {
                FileStream fs = new FileStream( fileName, FileMode.Open, FileAccess.Read, FileShare.Read );
                fileToRead = new StreamReader( fs, System.Text.Encoding.Default );
                }
            catch ( IOException e )
                {
                throw new IOException( InputConst.CouldNotReadFileMessage, e );
                }
            }


        /// <summary>
        /// Построчное чтение
        /// </summary>
        /// <returns>Прочитанный символ (null, если читать нечего)</returns>
        public override string GetLine()
            {
            string lastLine = "";
            try
                {
                lastLine = fileToRead.ReadLine();
                }
            //Конец файла
            catch ( System.IO.EndOfStreamException )
                {
                lastLine = null;
                }
            catch ( IOException e )
                {
                throw new IOException( InputConst.CouldNotReadFileMessage, e );
                }
            return lastLine;
            }


        //Дескриптор читаемого файла
        private StreamReader fileToRead;
        };
    }
