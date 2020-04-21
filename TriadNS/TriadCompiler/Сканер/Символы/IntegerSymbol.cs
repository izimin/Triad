using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Информация о целой константе.
    /// </summary>
    /// <syntax>Значение поля indexStringCode должно быть IntegerValue</syntax>
    internal class IntegerSymbol : Symbol
        {
        /// <summary>
        /// Целое значение символа
        /// </summary> 
        private int value;


        /// <summary>
        /// Конструктор
        /// </summary>
        public IntegerSymbol()
            {
            this.code = Key.IntegerValue;
            this.value = 0;
            }


        /// <summary>
        /// Целое значение символа
        /// </summary> 
        public int Value
            {
            get { return this.value; }
            set { this.value = value; }
            }
        };
    }
