using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Информация о  символьной константе.
    /// </summary>
    /// <syntax>Значение у поля indexStringCode должно быть CharValue</syntax>
    internal class CharSymbol : Symbol
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public CharSymbol()
            {
            this.code = Key.CharValue;
            this.value = (char)0;
            }


        /// <summary>
        /// Символьное значение символа
        /// </summary>
        private char value;


        /// <summary>
        /// Символьное значение символа
        /// </summary>
        public char Value
            {
            get { return this.value; }
            set { this.value = value; }
            }
        };
    }
