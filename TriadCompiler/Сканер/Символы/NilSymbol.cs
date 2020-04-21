using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Пустой символ nil
    /// </summary>
    class NilSymbol : Symbol
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public NilSymbol()
            {
            this.code = Key.Nil;
            }
        }
    }
