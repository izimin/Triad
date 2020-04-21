using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.ObjectRef;

namespace TriadCompiler.Parser.Common.Var
    {
    /// <summary>
    /// Информация о переменной
    /// </summary>
    internal class VarInfo : ObjectRefInfo
        {
        /// <summary>
        /// Тип переменной
        /// </summary>
        public IExprType Type = null;


        /// <summary>
        /// Признак того, что переменная была разобрана правильно
        /// </summary>
        public bool HasNoError
            {
            get
                {
                return this.Type != null;
                }
            }


        /// <summary>
        /// Представление в виде кода
        /// </summary>
        public CodeExpression Code
            {
            get
                {
                return new CodeSnippetExpression( StrCode.ToString() );
                }
            }

        }
    }
