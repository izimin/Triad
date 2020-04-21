using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Expr;
using TriadCompiler.Parser.Common.Polus;

namespace TriadCompiler.Parser.Routine.Statement
    {
    /// <summary>
    /// Разбор оператора посылик сообщений
    /// </summary>
    internal class OutStatement : CommonParser
        {
        /// <summary>
        /// Оператор посылки сообщений
        /// </summary>
        /// <syntax>Out Expression #Through PolusVariable {,PolusVariable}#</syntax>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <returns>Представление для генерации кода</returns>
        public static CodeStatementCollection Parse( EndKeyList endKeys )
            {
            CodeStatementCollection resultStatList = new CodeStatementCollection();

            Accept( Key.Out );

            ExprInfo messageExprInfo = Expression.Parse( endKeys.UniteWith( Key.Through ) );

            messageExprInfo.IsNotIndexed();
            messageExprInfo.IsNotSet();
            //Тип должен быть строковым
            messageExprInfo.IsString();

            //Если указаны полюса
            if ( currKey == Key.Through )
                {
                Accept( Key.Through );

                PolusInfo polusInfo = PolusVar.Parse( endKeys.UniteWith( Key.Comma ) );

                //Если это не выходной полюс
                if ( polusInfo.Type != null )
                    if ( !polusInfo.Type.IsOutput )
                        Fabric.Instance.ErrReg.Register( Err.Parser.Type.Polus.Need.Output );

                //Создаем вызов метода out
                CodeMethodInvokeExpression outStat = new CodeMethodInvokeExpression();
                outStat.Method = new CodeMethodReferenceExpression( null, Builder.Routine.Send.SendMessage );

                //Создаем сообщение
                outStat.Parameters.Add( messageExprInfo.Code );
                outStat.Parameters.Add( polusInfo.CoreNameCode );
                resultStatList.Add( outStat );

                while ( currKey == Key.Comma )
                    {
                    GetNextKey();

                    polusInfo = PolusVar.Parse( endKeys.UniteWith( Key.Comma ) );

                    //Если это не выходной полюс
                    if ( polusInfo.Type != null )
                        if ( !polusInfo.Type.IsOutput )
                            Fabric.Instance.ErrReg.Register( Err.Parser.Type.Polus.Need.Output );

                    //Создаем вызов метода out
                    outStat = new CodeMethodInvokeExpression();
                    outStat.Method = new CodeMethodReferenceExpression( null, Builder.Routine.Send.SendMessage );
                    //Создаем сообщение
                    outStat.Parameters.Add( messageExprInfo.Code );
                    outStat.Parameters.Add( polusInfo.CoreNameCode );
                    resultStatList.Add( outStat );
                    }
                }
            //Если полюса не указаны
            else
                {
                //Создаем вызов метода out
                CodeMethodInvokeExpression outStat = new CodeMethodInvokeExpression();
                outStat.Method = new CodeMethodReferenceExpression( null, Builder.Routine.Send.SendMessageToAll );

                //Создаем сообщение
                outStat.Parameters.Add( messageExprInfo.Code );
                resultStatList.Add( outStat );
                }

            return resultStatList;
            }
        }
    }
