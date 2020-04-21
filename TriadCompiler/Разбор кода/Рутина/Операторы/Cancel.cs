using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Ev;

namespace TriadCompiler.Parser.Routine.Statement
    {
    /// <summary>
    /// Разбор оператора отмена событий
    /// </summary>
    internal class Cancel : CommonParser
        {
        /// <summary>
        /// Оператор отмены событий 
        /// </summary>
        /// <syntax>Cancel Identificator {,Identificator}</syntax>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <returns>Представление для генерации кода</returns>
        public static CodeStatement Parse( EndKeyList endKeys )
            {
            //Создаем вызов функции cancel
            CodeMethodInvokeExpression cancelStat = new CodeMethodInvokeExpression();
            cancelStat.Method = new CodeMethodReferenceExpression( null, Builder.Routine.Shedule.CancelEvent );

            Accept( Key.Cancel );

            //Имя события
            EventInfo eventInfo = EventVar.Parse( endKeys.UniteWith( Key.Comma, Key.In ), false );

            while ( currKey == Key.Comma )
                {
                GetNextKey();

                //Имя события
                eventInfo = EventVar.Parse( endKeys.UniteWith( Key.Comma, Key.In ), false );
                }

            return new CodeExpressionStatement( cancelStat );
            }
        }
    }
