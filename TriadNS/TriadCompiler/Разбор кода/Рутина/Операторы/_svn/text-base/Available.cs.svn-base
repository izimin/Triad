using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Polus;

namespace TriadCompiler.Parser.Routine.Statement
    {
    /// <summary>
    /// Разбор оператора разблокирования полюсов
    /// </summary>
    internal class Available : CommonParser
        {
        /// <summary>
        /// Оператор разблокирования входов 
        /// </summary>
        /// <syntax>Available PolusVariable {,PolusVariable}</syntax>
        /// <param name="endKeys">Множество конечных символов</param> 
        /// <returns>Представление для генерации кода</returns>
        public static CodeStatementCollection Parse( EndKeyList endKeys )
            {
            CodeStatementCollection resultStatList = new CodeStatementCollection();

            Accept( Key.Available );

            PolusInfo polusInfo = PolusVar.Parse( endKeys.UniteWith( Key.Comma ) );

            //Если это не входной полюс
            if ( polusInfo.Type != null )
                if ( !polusInfo.Type.IsInput )
                    Fabric.Instance.ErrReg.Register( Err.Parser.Type.Polus.Need.Input );

            //Создаем вызов функции available
            CodeMethodInvokeExpression availableStat = new CodeMethodInvokeExpression();
            availableStat.Method = new CodeMethodReferenceExpression( null, Builder.Routine.Block.Available );
            //Указываем разблокируемый полюс
            availableStat.Parameters.Add( polusInfo.CoreNameCode );
            resultStatList.Add( availableStat );

            while ( currKey == Key.Comma )
                {
                GetNextKey();

                polusInfo = PolusVar.Parse( endKeys.UniteWith( Key.Comma ) );

                //Если это не входной полюс
                if ( polusInfo.Type != null )
                    if ( !polusInfo.Type.IsInput )
                        Fabric.Instance.ErrReg.Register( Err.Parser.Type.Polus.Need.Input );

                //Создаем вызов функции available
                availableStat = new CodeMethodInvokeExpression();
                availableStat.Method = new CodeMethodReferenceExpression( null, Builder.Routine.Block.Available );
                //Указываем разблокируемый полюс
                availableStat.Parameters.Add( polusInfo.CoreNameCode );
                resultStatList.Add( availableStat );
                }

            return resultStatList;
            }
        }
    }
