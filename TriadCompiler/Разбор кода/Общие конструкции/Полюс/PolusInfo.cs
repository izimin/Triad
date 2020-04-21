using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

namespace TriadCompiler.Parser.Common.Polus
    {
    /// <summary>
    /// Информация о полюсе-переменной
    /// </summary>
    class PolusInfo
        {
        /// <summary>
        /// Тип полюса
        /// </summary>
        public IPolusType Type = null;
        /// <summary>
        /// Представление в коде
        /// </summary>
        public CodeObjectCreateExpression CoreNameCode = new CodeObjectCreateExpression();
        }
    }
