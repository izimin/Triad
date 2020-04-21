using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Expr;

namespace TriadCompiler.Parser.Common.Statement
    {
    /// <summary>
    /// Разбор условного оператора
    /// </summary>
    internal class Condition : CommonParser
        {
        /// <summary>
        /// Условный оператор
        /// </summary>
        /// <syntax>If Expression Then StatementList [Else StatementList] EndIf</syntax>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <param name="context">Текущий контекст</param>
        /// <returns>Представление для генерации кода</returns>
        public static CodeStatement Parse( EndKeyList endKeys, StatementContext context )
            {
            CodeConditionStatement isStatement = new CodeConditionStatement();
            Accept( Key.If );

            ExprInfo exprInfo = Expression.Parse( endKeys.UniteWith( Key.EndIf, Key.Else, Key.Then ) );

            isStatement.Condition = exprInfo.Code;
            CheckConditionType( exprInfo );

            Accept( Key.Then );

            isStatement.TrueStatements.AddRange( StatementList.Parse( endKeys.UniteWith( Key.Else, Key.EndIf ), context ) );

            if ( currKey == Key.Else )
                {
                GetNextKey();
                isStatement.FalseStatements.AddRange( StatementList.Parse( endKeys.UniteWith( Key.EndIf ), context ) );
                }

            Accept( Key.EndIf );
            return isStatement;
            }


        /// <summary>
        /// Проверить совместимость типов в условии оператора if или while
        /// </summary>
        /// <param name="conditionInfo">Информация об условии</param>
        public static void CheckConditionType( ExprInfo conditionInfo )
            {
            conditionInfo.IsNotIndexed();
            conditionInfo.IsNotSet();
            //Тип условия должен быть логическим
            conditionInfo.IsBoolean();
            //Условия не должно задаваться константным выражением
            conditionInfo.IsNotConstant();
            }
        }
    }
