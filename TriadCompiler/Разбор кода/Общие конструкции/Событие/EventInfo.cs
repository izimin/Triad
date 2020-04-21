using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

namespace TriadCompiler.Parser.Common.Ev
    {
    /// <summary>
    /// Описание события
    /// </summary>
    class EventInfo
        {
        /// <summary>
        /// Тип полюса
        /// </summary>
        public EventType Type = null;
        /// <summary>
        /// Представление имени в коде
        /// </summary>
        public CodeObjectCreateExpression CoreNameCode = new CodeObjectCreateExpression();
        /// <summary>
        /// Представление метода, которым представлено событие
        /// </summary>
        public CodeMethodReferenceExpression MethodRefCode = new CodeMethodReferenceExpression();
        /// <summary>
        /// Строковое представление
        /// </summary>
        public string StrCode = string.Empty;
        }
    }
