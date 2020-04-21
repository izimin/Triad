using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

namespace TriadCompiler.Parser.SimCondition.Statement
    {
    /// <summary>
    /// Разбор оператора окончания моделирования
    /// </summary>
    class Eor : CommonParser
        {
        /// <summary>
        /// Разобрать оператор окончания моделирования
        /// </summary>
        /// <syntax>Eor</syntax>
        /// <param name="endKeys">Допустимые конечные символы</param>
        /// <returns>Представление оператора в коде</returns>
        public static CodeStatement Parse( EndKeyList endKeys )
            {
            Accept( Key.Eor );

            //Создаем оператор, возращающий false
            CodeMethodReturnStatement returnStat = new CodeMethodReturnStatement();
            returnStat.Expression = new CodePrimitiveExpression( false );

            return returnStat;
            }
        }
    }
