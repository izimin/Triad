using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Информация об идентификаторе.
    /// Значение у поля indexStringCode должно быть Identificator
    /// </summary>
    internal class IdentSymbol : Symbol
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public IdentSymbol()
            {
            this.code = Key.Identificator;
            this.name = "";
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        public IdentSymbol( string name )
            : this()
            {
            this.name = name;
            }

        
        /// <summary>
        /// Строковое значение символа 
        /// </summary>
        public string Name
            {
            get
                {
                return name;
                }
            set
                {
                if ( value == null )
                    throw new ArgumentNullException( "Name" );
                name = value;
                }
            }


        // Строковое значение символа 
        private string name = "";
        };
    }
