using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

namespace TriadCompiler.Parser.Common.Function
    {
    /// <summary>
    /// Информация о разобранном вызове функции
    /// </summary>
    class FunctionInfo
        {
        /// <summary>
        /// Тип функции
        /// </summary>
        public FunctionType Type = new FunctionType();
        /// <summary>
        /// Код вызова функции
        /// </summary>
        private CodeMethodInvokeExpression code = new CodeMethodInvokeExpression();
        /// <summary>
        /// Строковое представление кода
        /// </summary>
        private string strCode = string.Empty;


        /// <summary>
        /// Строковое представление
        /// </summary>
        public string StrCode
            {
            get
                {
                return this.strCode;
                }
            set
                {
                this.strCode = value;
                }
            }


        /// <summary>
        /// Представление в виде кода
        /// </summary>
        public CodeMethodInvokeExpression Code
            {
            get
                {
                return this.code;
                }
            set
                {
                this.code = value;
                }
            }
        }
    }
