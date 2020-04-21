using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Информация о  битовой строке.
    /// </summary>
    /// <syntax>Значение у поля indexStringCode должно быть BitStringValue</syntax>
    internal class BitStringSymbol : Symbol
        {
        /// <summary>
        /// Битовое значение символа
        /// </summary>
        private Int64 value;


        /// <summary>
        /// Конструктор
        /// </summary>
        public BitStringSymbol()
            {
            this.code = Key.BitStringValue;
            this.value = 0;
            }


        /// <summary>
        /// Битовое значение символа
        /// </summary>
        public Int64 Value
            {
            get { return this.value; }
            set { this.value = value; }
            }
        };
    }
