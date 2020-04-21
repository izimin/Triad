using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Ev;
using TriadCompiler.Parser.Common.Var;
using TriadCompiler.Parser.Common.Polus;
using TriadCompiler.Parser.Common.Statement;

namespace TriadCompiler.Parser.InfProcedure.Statement
    {
    internal class InfCase : CommonParser
        {
        /// <summary>
        /// Стартовые символы  условия в операторе case
        /// </summary>
        private static List<Key> caseConditionStartKeys = null;


        /// <summary>
        /// Стартовые символы  условия в операторе case
        /// </summary>
        private static List<Key> CaseConditionStartKeys
            {
            get
                {
                if ( caseConditionStartKeys == null )
                    {
                    caseConditionStartKeys = new List<Key>();

                    caseConditionStartKeys.Add( Key.In );
                    caseConditionStartKeys.Add( Key.Polus );
                    caseConditionStartKeys.Add( Key.Event );
                    }
                return caseConditionStartKeys;
                }
            }


        /// <summary>
        /// Оператор множественного выбора 
        /// </summary>        
        /// <param name="endKeys">Множество конечных символов</param> 
        /// <returns>Представление для генерации кода</returns>
        public static CodeStatement Parse( EndKeyList endKeys )
            {
            Accept( Key.Case );

            CodeConditionStatement ifStat = new CodeConditionStatement();

            //Ветка условия
            ifStat.Condition = CaseConditionList( endKeys.UniteWith( Key.Colon, Key.EndCase ) );

            Accept( Key.Colon );

            //Операторы
            ifStat.TrueStatements.AddRange( StatementList.Parse( endKeys.UniteWith( Key.Break, Key.EndCase ), StatementContext.Common ) );

            CodeConditionStatement ifParentStat, ifFirstStat;
            ifFirstStat = ifStat;

            while ( currKey == Key.Break )
                {
                GetNextKey();

                ifParentStat = ifStat;
                ifStat = new CodeConditionStatement();
                ifParentStat.FalseStatements.Add( ifStat );

                //Ветка условия
                ifStat.Condition = CaseConditionList( endKeys.UniteWith( Key.Colon, Key.EndCase ) );

                Accept( Key.Colon );

                //Операторы
                ifStat.TrueStatements.AddRange( StatementList.Parse( endKeys.UniteWith( Key.Break, Key.EndCase ), StatementContext.Common ) );
                }
            Accept( Key.EndCase );

            return ifFirstStat;
            }


        /// <summary>
        /// Ветка в операторе case
        /// </summary>
        /// <syntax>caseCondition{,caseCondition}</syntax>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <returns>Представление для генерации кода</returns>
        private static CodeExpression CaseConditionList( EndKeyList endKeys )
            {
            CodeExpression ifExprStat = CaseCondition( endKeys.UniteWith( Key.Comma ) );
            while ( currKey == Key.Comma )
                {
                Accept( Key.Comma );
                CodeExpression newCompareStat = CaseCondition( endKeys.UniteWith( Key.Comma ) );

                CodeExpression oldIfExprStat = ifExprStat;
                ifExprStat = new CodeBinaryOperatorExpression();
                ( ifExprStat as CodeBinaryOperatorExpression ).Left = oldIfExprStat;
                ( ifExprStat as CodeBinaryOperatorExpression ).Right = newCompareStat;
                ( ifExprStat as CodeBinaryOperatorExpression ).Operator = CodeBinaryOperatorType.BooleanOr;
                }

            return ifExprStat;
            }


        /// <summary>
        /// Имя объекта слежения в операторе case
        /// </summary>
        /// <syntax># polus PolusVar | event EventVar | in Variable # </syntax>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <returns>Представление для генерации кода</returns>
        private static CodeExpression CaseCondition( EndKeyList endKeys )
            {
            CodeMethodInvokeExpression compareMethod = new CodeMethodInvokeExpression();

            if ( !CaseConditionStartKeys.Contains( currKey ) )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongStartSymbol.IPCaseCondition, CaseConditionStartKeys );
                SkipTo( endKeys.UniteWith( CaseConditionStartKeys ) ); 
                }
            if ( caseConditionStartKeys.Contains( currKey ) )
                {
                //Имя spy-объекта в коде
                CodeObjectCreateExpression coreNameCode = new CodeObjectCreateExpression();

                ISpyType spyType = null;
                switch ( currKey )
                    {
                    //Переменная
                    case Key.In:
                        GetNextKey();
                        VarInfo varInfo = Variable.Parse( endKeys, true, false );
                        coreNameCode = varInfo.CoreNameCode;
                        spyType = varInfo.Type;
                        break;
                    //Полюс
                    case Key.Polus:
                        GetNextKey();
                        PolusInfo polusInfo = PolusVar.Parse( endKeys );
                        coreNameCode = polusInfo.CoreNameCode;
                        spyType = polusInfo.Type;
                        break;
                    //Событие
                    case Key.Event:
                        GetNextKey();
                        EventInfo eventInfo = EventVar.Parse( endKeys, true );
                        coreNameCode = eventInfo.CoreNameCode;
                        spyType = eventInfo.Type;
                        break;
                    }

                //Проверка, это spy-объект?
                if ( spyType != null && !spyType.IsSpyObject )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.Usage.NeedSpyObject );
                    }

                //Метод, сравнивающий spy-объекты
                compareMethod.Method = new CodeMethodReferenceExpression(
                    new CodeArgumentReferenceExpression( Builder.IProcedure.Handling.SpyObjectNameInDoHandling ),
                    Builder.CoreName.Compare );

                //Метод, возвращающий spy-объект по его имени
                CodeMethodInvokeExpression getSpyObjectMethod = new CodeMethodInvokeExpression();
                getSpyObjectMethod.Method = new CodeMethodReferenceExpression();
                getSpyObjectMethod.Method.MethodName = Builder.IProcedure.GetSpyObject;
                getSpyObjectMethod.Parameters.Add( coreNameCode );

                compareMethod.Parameters.Add( getSpyObjectMethod );
                }

            return compareMethod;
            }
        }
    }
