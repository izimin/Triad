using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Expr;

namespace TriadCompiler.Parser.SimCondition.Statement
    {
    /// <summary>
    /// Разбор вызова ИП (генерация кода)
    /// </summary>
    internal partial class IPCall
        {
        /// <summary>
        /// Сгенерировать код, создающий экземпляр ИП
        /// </summary>
        /// <param name="ipName">Имя ИП</param>
        /// <param name="ipNumber">Порядковый номер ИП</param>
        /// <param name="paramExprInfoList">Список параметров</param>
        /// <returns>Код</returns>
        public static CodeStatementCollection GenerateIProcedureCreation( string ipName, int ipNumber, List<ExprInfo> paramExprInfoList )
            {
            CodeStatementCollection statList = new CodeStatementCollection();

            CodeObjectCreateExpression createStat = new CodeObjectCreateExpression();
            createStat.CreateType = new CodeTypeReference( ipName );

            //Добавляем параметры ИП
            foreach ( ExprInfo exprInfo in paramExprInfoList )
                {
                createStat.Parameters.Add( exprInfo.Code );
                }

            //Вызываем метод, создающий ИП
            CodeMethodInvokeExpression addIpStat = new CodeMethodInvokeExpression();
            addIpStat.Method = new CodeMethodReferenceExpression();
            addIpStat.Method.MethodName = Builder.ICondition.AddIProcedure;

            addIpStat.Parameters.Add( createStat );
            addIpStat.Parameters.Add( new CodePrimitiveExpression( ipNumber ) );

            //Помещаем этот метод в функцию инициализации
            statList.Add( addIpStat );

            return statList;
            }


        /// <summary>
        /// Сгенерировать код, инициализирующий ИП
        /// </summary>
        /// <param name="ipNumber">Порядковый номер ИП</param>
        /// <returns>Код</returns>
        public static CodeStatementCollection GenerateIProcedureInitialization( int ipNumber )
            {
            CodeStatementCollection statList = new CodeStatementCollection();

            CodeMethodInvokeExpression initStat = new CodeMethodInvokeExpression();
            initStat.Method = new CodeMethodReferenceExpression();
            initStat.Method.MethodName = Builder.ICondition.InitializeIProcedure;
            initStat.Parameters.Add( new CodePrimitiveExpression( ipNumber ) );

            statList.Add( initStat );

            return statList;
            }


        /// <summary>
        /// Получить код, возвращающий добавленную ИП
        /// </summary>
        /// <param name="ipName">Имя ИП</param>
        /// <param name="ipCallNumber">Порядковый номер ИП</param>
        /// <returns>Код</returns>
        private static CodeExpression GetIProcedureCode( string ipName, int ipCallNumber )
            {
            return new CodeSnippetExpression( "((" + ipName + ")" + Builder.ICondition.GetIProcedure +
                "(" + ipCallNumber.ToString() + "))" );
            }
        }
    }
