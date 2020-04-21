using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Информация о строковой константе.
    /// </summary>
    /// <syntax>Значение поля indexStringCode всегда StringValue</syntax>
    internal class StringSymbol : Symbol
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public StringSymbol()
            {
            this.code = Key.StringValue;
            this.Value = "";
            }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="value">Значение</param>
        public StringSymbol( string value )
            : this()
            {
            this.value = value;
            }


        /// <summary>
        /// Код символа
        /// </summary>
        /// <Name>Code</Name>
        public override Key Code
            {
            get
                {
                return code;
                }
            }


        /// <summary>
        /// Строковое значение символа 
        /// </summary>
        public string Value
            {
            get
                {
                return value;
                }
            set
                {
                if ( value == null )
                    throw new ArgumentNullException( "Name" );
                this.value = value;
                }
            }

        // Строковое значение символа 
        private string value = "";
        };
    }
