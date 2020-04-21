using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    ///Информация о логической константе (true или false)
    /// </summary>
    /// <syntax>Значение у поля indexStringCode должно быть BitStringValue</syntax>
    internal class BooleanSymbol : Symbol
        {
        /// <summary>
        /// Битовое значение символа
        /// </summary>
        private bool value;


        /// <summary>
        /// Конструктор
        /// </summary>
        public BooleanSymbol()
            {
            this.code = Key.BooleanValue;
            this.value = false;
            }

        /// <summary>
        /// Конструктор
        /// </summary>
        public BooleanSymbol( bool value )
            : this()
            {
            this.value = value;
            }


        /// <summary>
        /// Битовое значение символа
        /// </summary>
        public bool Value
            {
            get { return this.value; }
            set { this.value = value; }
            }
        };
    }
