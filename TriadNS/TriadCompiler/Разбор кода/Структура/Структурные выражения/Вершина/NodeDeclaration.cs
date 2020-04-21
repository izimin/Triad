using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.ObjectRef;
using TriadCompiler.Parser.Structure.StructExpr.Fact;

namespace TriadCompiler.Parser.Structure.StructExpr.Node
    {
    /// <summary>
    /// –азбор объ€влени€ вершины в структурном выражении
    /// </summary>
    internal class NodeDeclaration : CommonParser
        {
        /// <summary>
        /// ќбъ€вление вершины в структурном выражении
        /// </summary>
        /// <param name="endKeys">ћножество конечных символов</param>
        /// <syntax>ObjectReference # ObjectReference  {,ObjectReference } #</syntax>
        public static CodeStatementCollection Parse( EndKeyList endKeys )
            {
            CodeStatementCollection resultStatList = new CodeStatementCollection();

            if ( currKey != Key.Identificator )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongStartSymbol.NodeDeclaration, Key.Identificator );
                SkipTo( endKeys.UniteWith( Key.Identificator ) );
                }
            if ( FactorKeySet.Start.Factor.Contains( currKey ) )
                {
                //—оздаем пустой граф
                CodeMethodInvokeExpression createGraphStat = new CodeMethodInvokeExpression(
                    new CodeThisReferenceExpression(), Builder.Structure.BuildExpr.Stack.PushNew );
                resultStatList.Add( new CodeExpressionStatement( createGraphStat ) );

                //–азбираем им€ вершины
                ObjectRefInfo nodeInfo = ObjectReference.Parse( endKeys.UniteWith( Key.Later ), true );

                //ќбъ€вл€ем в текущем графе вершину
                CodeMethodInvokeExpression declareNodeStat = new CodeMethodInvokeExpression(
                    new CodeFieldReferenceExpression( new CodeThisReferenceExpression(), Builder.Structure.BuildExpr.Stack.First ),
                    Builder.Structure.BuildExpr.DeclareOperation.DeclareNodeInGraph,
                    nodeInfo.CoreNameCode );
                resultStatList.Add( new CodeExpressionStatement( declareNodeStat ) );

                //≈сли у вершины объ€влены полюсы
                if ( currKey == Key.Later )
                    {
                    Accept( Key.Later );

                    ObjectRefInfo polusInfo = ObjectReference.Parse( endKeys.UniteWith( Key.Comma, Key.Greater ), true );

                    //√енерируем объ€вление полюса
                    CodeMethodInvokeExpression declarePolusStat = new CodeMethodInvokeExpression(
                        new CodeFieldReferenceExpression( new CodeThisReferenceExpression(), Builder.Structure.BuildExpr.Stack.First ),
                        Builder.Structure.BuildExpr.DeclareOperation.DeclarePolusInAllNodesInGraph,
                        polusInfo.CoreNameCode );
                    resultStatList.Add( new CodeExpressionStatement( declarePolusStat ) );

                    while ( currKey == Key.Comma )
                        {
                        Accept( Key.Comma );
                        polusInfo = ObjectReference.Parse( endKeys.UniteWith( Key.Comma, Key.Greater ), true );

                        //√енерируем объ€вление полюса
                        declarePolusStat = new CodeMethodInvokeExpression(
                            new CodeFieldReferenceExpression( new CodeThisReferenceExpression(), Builder.Structure.BuildExpr.Stack.First ),
                            Builder.Structure.BuildExpr.DeclareOperation.DeclarePolusInAllNodesInGraph,
                            polusInfo.CoreNameCode );
                        resultStatList.Add( new CodeExpressionStatement( declarePolusStat ) );
                        }

                    Accept( Key.Greater );
                    }

                if ( !endKeys.Contains( currKey ) )
                    {
                    //«десь выводить в качестве допустимых все структурные операции нельз€
                    Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.NodeDeclaration, endKeys.GetLastKeys() );
                    SkipTo( endKeys );
                    }
                }

            return resultStatList;
            }
        }
    }
