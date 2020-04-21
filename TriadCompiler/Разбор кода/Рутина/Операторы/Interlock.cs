using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Polus;

namespace TriadCompiler.Parser.Routine.Statement
    {
    /// <summary>
    /// Разбор оператора блокирования полюса
    /// </summary>
    internal class Interlock : CommonParser
        {
        /// <summary>
        /// Оператор блокирования входов
        /// </summary>
        /// <syntax>Iterlock PolusVariable {,PolusVariable}</syntax>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <returns>Представление для генерации кода</returns>
        public static CodeStatementCollection Parse( EndKeyList endKeys )
            {
            CodeStatementCollection resultStatList = new CodeStatementCollection();

            Accept( Key.Interlock );

            PolusInfo polusInfo = PolusVar.Parse( endKeys.UniteWith( Key.Comma ) );

            //Если это не входной полюс
            if ( polusInfo.Type != null )
                if ( !polusInfo.Type.IsInput )
                    Fabric.Instance.ErrReg.Register( Err.Parser.Type.Polus.Need.Input );

            //Создаем вызов функции interlock
            CodeMethodInvokeExpression interlockStat = new CodeMethodInvokeExpression();
            interlockStat.Method = new CodeMethodReferenceExpression( null, Builder.Routine.Block.Interlock );
            //Указываем блокируемый полюс
            interlockStat.Parameters.Add( polusInfo.CoreNameCode );
            resultStatList.Add( interlockStat );

            while ( currKey == Key.Comma )
                {
                GetNextKey();
                polusInfo = PolusVar.Parse( endKeys.UniteWith( Key.Comma ) );

                //Если это не входной полюс
                if ( polusInfo.Type != null )
                    if ( !polusInfo.Type.IsInput )
                        Fabric.Instance.ErrReg.Register( Err.Parser.Type.Polus.Need.Input );

                //Создаем вызов функции interlock
                interlockStat = new CodeMethodInvokeExpression();
                interlockStat.Method = new CodeMethodReferenceExpression( null, Builder.Routine.Block.Interlock );
                //Указываем блокируемый полюс
                interlockStat.Parameters.Add( polusInfo.CoreNameCode );
                resultStatList.Add( interlockStat );
                }

            return resultStatList;
            }
        }
    }
