using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TriadCompiler
    {
    /// <summary>
    /// Константы Output
    /// </summary>
    public struct OutputConst
        {
        /// <summary>
        /// Сообщение об ошибке записи в файла с листингом 
        /// </summary>
        public const string CouldNotWriteToFileMessage = "Ошибка записи в файл с листингом";
        };


    /// <summary>
    /// Класс Output отвечает за операции по выводу информации.
    /// Данные можно выводить построчно при помощи функции PrintLine.
    /// </summary>
    public class Output
        {
        /// <summary>
        /// Вывести строчку
        /// </summary>
        /// <param name="line">Выводимая строка</param>
        public virtual void PrintLine( String line )
        { }

        /// <summary>
        /// Вывести строчку без перевода строки
        /// </summary>
        /// <param name="line">Выводимая строка</param>
        public virtual void Print( String line )
        { }

        };


    /// <summary>
    /// Класс OutputFile отвечает за операции по выводу информации в файл.
    /// Данные можно выводить построчно при помощи функции PrintLine.
    /// В конструктор нужно передать имя файла, куда идет запись
    /// </summary>
    internal class OutputFile : Output
        {
        /// <summary>
        /// 	<para> Конструктор класса <see cref="OutputFile"/> .</para>
        /// </summary>
        /// <param name="fileName"> Имя читаемого файла
        /// </param>
        public OutputFile( string fileName )
            {
            if ( fileName == null )
                throw new ArgumentNullException( "sourceFileName" );

            try
                {
                fileToWrite = new StreamWriter( fileName );
                }
            catch ( IOException e )
                {
                throw new IOException( OutputConst.CouldNotWriteToFileMessage, e );
                }
            }


        /// <summary>
        /// Вывести строчку
        /// </summary>
        /// <param name="line"> Выводимая строка
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// 	<para>Значение аргумента <paramref Name="line"/> равно <langword Name="null"/>.</para>
        /// </exception>
        public override void PrintLine( String line )
            {
            if ( line == null )
                throw new ArgumentNullException( "line" );

            try
                {
                fileToWrite.WriteLine( line );
                fileToWrite.Flush();
                }
            catch ( IOException e )
                {
                throw new IOException( OutputConst.CouldNotWriteToFileMessage, e );
                }
            }


        /// <summary> Вывести строчку без перевода строки
        /// </summary>
        /// <param name="line"> Выводимая строка
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// 	<para>Значение аргумента <paramref Name="line"/> равно <langword Name="null"/>.</para>
        /// </exception>
        public override void Print( String line )
            {
            if ( line == null )
                throw new ArgumentNullException( "line" );

            try
                {
                fileToWrite.Write( line );
                fileToWrite.Flush();
                }
            catch ( IOException e )
                {
                throw new IOException( OutputConst.CouldNotWriteToFileMessage, e );
                }
            }


        //Целевой файл
        private StreamWriter fileToWrite;
        };


    /// <summary>
    /// Класс ConsoleOutput отвечает за операции по выводу информации на консоль.
    /// Данные можно выводить построчно при помощи функции PrintLine.
    /// В конструктор нужно передать имя файла, куда идет запись
    /// </summary>
    internal class ConsoleOutput : Output
        {
        /// <summary>
        /// 	<para> Конструктор класса <see cref="ConsoleOutput"/> .</para>
        /// </summary>
        public ConsoleOutput()
            {
            }


        /// <summary> Вывести строчку
        /// </summary>
        /// <param name="line"> Выводимая строка
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// 	<para>Значение аргумента <paramref Name="line"/> равно <langword Name="null"/>.</para>
        /// </exception>
        public override void PrintLine( String line )
            {
            if ( line == null )
                throw new ArgumentNullException( "line" );

            Console.WriteLine( line );
            }


        /// <summary> Вывести строчку без перевода строки
        /// </summary>
        /// <param name="line"> Выводимая строка
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// 	<para>Значение аргумента <paramref Name="line"/> равно <langword Name="null"/>.</para>
        /// </exception>
        public override void Print( String line )
            {
            if ( line == null )
                throw new ArgumentNullException( "line" );

            Console.Write( line );
            }
        };

    }
