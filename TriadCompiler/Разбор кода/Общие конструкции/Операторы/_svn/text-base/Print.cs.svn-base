using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Expr;

namespace TriadCompiler.Parser.Common.Statement
    {
    /// <summary>
    /// Разбор оператора отладочной печати
    /// </summary>
    internal class Print : CommonParser
        {
        /// <summary>
        /// Оператор отладочной печати
        /// </summary>
        /// <syntax>WriteLine Expression</syntax>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <returns>Представление для генерации кода</returns>  
        public static CodeStatement Parse( EndKeyList endKeys )
            {
            CodeMethodInvokeExpression writeStat = new CodeMethodInvokeExpression();
            writeStat.Method = new CodeMethodReferenceExpression( null, Builder.Routine.Print );
            Accept( Key.Print );

            ExprInfo exprInfo = Expression.Parse( endKeys );

            if ( exprInfo.HasNoError && exprInfo.IsNotIndexed() && exprInfo.IsNotSet() )
                {
                //Тип выражения может быть любым
                writeStat.Parameters.Add( exprInfo.Code );
                }

            return new CodeExpressionStatement( writeStat );
            }
        }
    }
