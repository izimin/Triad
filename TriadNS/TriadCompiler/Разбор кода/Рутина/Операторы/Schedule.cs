using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Ev;
using TriadCompiler.Parser.Common.Expr;

namespace TriadCompiler.Parser.Routine.Statement
    {
    /// <summary>
    /// Разбор оператора планирования событий
    /// </summary>
    internal class Schedule : CommonParser
        {
        /// <summary>
        /// Оператор планирования
        /// </summary>
        /// <syntax>SCHEDULE Identificator{,Identificator} At Expression</syntax>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <returns>Представление для генерации кода</returns>  
        public static CodeStatement Parse( EndKeyList endKeys )
            {
            CodeMethodInvokeExpression sheduleStatement = new CodeMethodInvokeExpression();
            sheduleStatement.Method = new CodeMethodReferenceExpression( null,
                Builder.Routine.Shedule.EventShedule );

            Accept( Key.Shedule );

            //Имя события
            EventInfo eventInfo = EventVar.Parse( endKeys.UniteWith( Key.Comma, Key.In ), false );
            
            sheduleStatement.Parameters.Add( eventInfo.MethodRefCode ); 

            while ( currKey == Key.Comma )
                {
                GetNextKey();
                
                //Имя события
                eventInfo = EventVar.Parse( endKeys.UniteWith( Key.Comma, Key.In ), false );

                sheduleStatement.Parameters.Add( eventInfo.MethodRefCode ); 
                }

            Accept( Key.In );

            ExprInfo exprInfo = Expression.Parse( endKeys );

            sheduleStatement.Parameters.Insert( 0, exprInfo.Code );

            //Проверка выражения
            exprInfo.IsNotIndexed();
            exprInfo.IsNotSet();
            exprInfo.IsIntegerOrReal();
            exprInfo.NotNegativeIntegerOrReal();

            return new CodeExpressionStatement( sheduleStatement );
            }
        }
    }
