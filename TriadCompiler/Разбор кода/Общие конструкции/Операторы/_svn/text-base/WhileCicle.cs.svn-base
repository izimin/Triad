using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Expr;

namespace TriadCompiler.Parser.Common.Statement
    {
    /// <summary>
    /// Разбор цикла while
    /// </summary>
    internal class WhileCicle : CommonParser
        {
        /// <summary>
        /// Условный цикл
        /// </summary>
        /// <syntax>While Expression Do StatementList EndWhile</syntax>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <param name="context">Текущий контекст</param>
        /// <returns>Представление для генерации кода</returns>
        public static CodeStatement Parse( EndKeyList endKeys, StatementContext context )
            {
            CodeIterationStatement whileStatement = new CodeIterationStatement();
            Accept( Key.While );

            ExprInfo exprInfo = Expression.Parse( endKeys.UniteWith( Key.EndWhile, Key.Do ) );

            whileStatement.TestExpression = exprInfo.Code;
            whileStatement.IncrementStatement = new CodeCommentStatement( " " );
            whileStatement.InitStatement = new CodeCommentStatement( " " );

            Condition.CheckConditionType( exprInfo );

            Accept( Key.Do );

            whileStatement.Statements.AddRange( StatementList.Parse( endKeys.UniteWith( Key.EndWhile ), context ) );

            Accept( Key.EndWhile );

            return whileStatement;
            }
        }
    }
