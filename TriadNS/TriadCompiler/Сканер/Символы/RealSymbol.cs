using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Информация о вещественной константе.
    /// </summary>
    /// <syntax>Значение поля indexStringCode должно быть RealValue</syntax>
    internal class RealSymbol : Symbol
        {
        /// <summary>
        /// Вещественное значение символа
        /// </summary> 
        private double value;


        /// <summary>
        /// Конструктор
        /// </summary>
        public RealSymbol()
            {
            this.code = Key.RealValue;
            this.value = 0.0;
            }

        /// <summary>
        /// Вещественное значение символа
        /// </summary> 
        public double Value
            {
            get { return this.value; }
            set { this.value = value; }
            }
        };

    }
