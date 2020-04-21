using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Structure.StructExpr.Node;

namespace TriadCompiler.Parser.Structure.StructExpr.Const
    {
    /// <summary>
    /// Разбор графовой константы в структурном выражении
    /// </summary>
    internal class Constant : CommonParser
        {
        /// <summary>
        /// Структурная константа
        /// </summary>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <param name="createConstGraphMethosName">Название метода, создающего структурную константу</param>
        /// <syntax>DirectCycle | UndirectCycle | DirectPath | UndirectPath |
        /// DirectStar | UndirectStar ( NodeDeclarationInExpr , { NodeDeclarationInExpr } ) </syntax>
        /// <returns>Сгенерированный код</returns>
        public static CodeStatementCollection Parse( EndKeyList endKeys, string createConstGraphMethosName )
            {
            CodeStatementCollection resultStatList = new CodeStatementCollection();

            if ( currKey != Key.LeftPar )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongStartSymbol.StructConstant, Key.LeftPar );
                SkipTo( endKeys.UniteWith( Key.LeftPar ) );
                }
            if ( currKey == Key.LeftPar )
                {
                Accept( Key.LeftPar );

                //Создаем пустой граф
                CodeMethodInvokeExpression createGraphStat = new CodeMethodInvokeExpression();
                createGraphStat.Method.TargetObject = new CodeThisReferenceExpression();

                resultStatList.Add( new CodeExpressionStatement( createGraphStat ) );
                createGraphStat.Method.MethodName = createConstGraphMethosName;

                //Объявление вершины
                resultStatList.AddRange( NodeDeclaration.Parse( endKeys.UniteWith( Key.Comma, Key.RightPar ) ) );

                //Код добавления этой вершины в граф-константу
                resultStatList.AddRange( StructExpression.ExpressionCode( Key.Plus ) );

                while ( currKey == Key.Comma )
                    {
                    Accept( Key.Comma );

                    //Объявление вершины
                    resultStatList.AddRange( NodeDeclaration.Parse( endKeys.UniteWith( Key.Comma, Key.RightPar ) ) );

                    //Код добавления этой вершины в граф-константу
                    resultStatList.AddRange( StructExpression.ExpressionCode( Key.Plus ) );
                    }

                //Вызов метода completeGraph
                CodeMethodInvokeExpression completeGraphStat = new CodeMethodInvokeExpression(
                    new CodeFieldReferenceExpression( new CodeThisReferenceExpression(),
                                                    Builder.Structure.BuildExpr.Stack.First ),
                    Builder.Structure.BuildExpr.DeclareOperation.Complete );

                resultStatList.Add( new CodeExpressionStatement( completeGraphStat ) );

                Accept( Key.RightPar );

                if ( !endKeys.Contains( currKey ) )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.StructConstant, StructExprKeySet.Operation.All );
                    SkipTo( endKeys );
                    }
                }

            return resultStatList;
            }


        
        }
    }
