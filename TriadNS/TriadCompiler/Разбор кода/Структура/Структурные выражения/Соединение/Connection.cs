using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.ObjectRef;

namespace TriadCompiler.Parser.Structure.StructExpr.Conn
    {
    /// <summary>
    /// Разбор соединения в структурном выражении
    /// </summary>
    internal class Connection : CommonParser
        {
        /// <summary>
        /// Дуга или ребро, соединяющая полюса
        /// </summary>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <param name="createConnectionMethodName">Имя метода, создающего соединение</param>
        /// <syntax>Arc | Edge ConnectionTerminalNode -- ConnectionTerminalNode</syntax>
        /// <returns>Сгенерированный код</returns>
        public static CodeStatementCollection Parse( EndKeyList endKeys, string createConnectionMethodName )
            {
            CodeStatementCollection resultStatList = new CodeStatementCollection();

            if ( currKey != Key.LeftPar )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongStartSymbol.Connection, Key.LeftPar );
                SkipTo( endKeys.UniteWith( Key.LeftPar ) );
                }
            if ( currKey == Key.LeftPar )
                {
                Accept( Key.LeftPar );

                //Создаем пустой граф
                CodeMethodInvokeExpression createGraphStat = new CodeMethodInvokeExpression(
                    new CodeThisReferenceExpression(), Builder.Structure.BuildExpr.Stack.PushNew );
                resultStatList.Add( createGraphStat );

                //Вызов метода добавления соединения
                CodeMethodInvokeExpression addConnectionStat = new CodeMethodInvokeExpression();

                //Вызов метода добавления дуги
                addConnectionStat.Method = new CodeMethodReferenceExpression(
                    new CodeFieldReferenceExpression( new CodeThisReferenceExpression(), Builder.Structure.BuildExpr.Stack.First ),
                    createConnectionMethodName );


                //Начало соединения
                resultStatList.AddRange( ConnectionEndPoint( endKeys.UniteWith( Key.Connection, Key.RightPar ), addConnectionStat ) );

                Accept( Key.Connection );

                //Конец соединения
                resultStatList.AddRange( ConnectionEndPoint( endKeys.UniteWith( Key.RightPar ), addConnectionStat ) );

                resultStatList.Add( addConnectionStat );

                Accept( Key.RightPar );

                if ( !endKeys.Contains( currKey ) )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.Connection, StructExprKeySet.Operation.All );
                    SkipTo( endKeys );
                    }
                }

            return resultStatList;
            }


        /// <summary>
        /// Один из концов дуги или ребра
        /// </summary>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <param name="addConnectionStat">Ссылка на метод, формирующий соединение</param>
        /// <returns>Сгенерированный код</returns>
        /// <synatx>ObjectReference . ObjectReference</synatx>
        private static CodeStatementCollection ConnectionEndPoint( EndKeyList endKeys, CodeMethodInvokeExpression addConnectionStat )
            {
            CodeStatementCollection resultStatList = new CodeStatementCollection();

            //Имя первой вершины
            CodeObjectCreateExpression nodeNameCode = ObjectReference.Parse( endKeys.UniteWith( Key.Point ), false ).CoreNameCode;

            //Объявляем в текущем графе эту вершину
            CodeMethodInvokeExpression declareNodeStat = new CodeMethodInvokeExpression(
                new CodeFieldReferenceExpression( new CodeThisReferenceExpression(), Builder.Structure.BuildExpr.Stack.First ),
                Builder.Structure.BuildExpr.DeclareOperation.DeclareNodeInGraph,
                nodeNameCode );
            resultStatList.Add( new CodeExpressionStatement( declareNodeStat ) );

            Accept( Key.Point );

            //Имя полюса вершины
            CodeObjectCreateExpression polusNameCode = ObjectReference.Parse( endKeys, false ).CoreNameCode;

            //Объявляем этот полюс в вершине
            declareNodeStat.Parameters.Add( polusNameCode );

            //Добавляем вершину в параметры функции добавления соединения
            addConnectionStat.Parameters.Add( nodeNameCode );
            //Добавляем полюс вершины в параметры функции добавления соединения
            addConnectionStat.Parameters.Add( polusNameCode );

            return resultStatList;
            }
        }
    }
