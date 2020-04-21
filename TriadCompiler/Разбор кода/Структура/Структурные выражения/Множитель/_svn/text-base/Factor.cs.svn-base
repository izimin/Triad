using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Model.DesignVar;
using TriadCompiler.Parser.Structure.StructExpr.Node;
using TriadCompiler.Parser.Structure.StructExpr.Conn;
using TriadCompiler.Parser.Structure.StructExpr.Const;

namespace TriadCompiler.Parser.Structure.StructExpr.Fact
{
    /// <summary>
    /// Разбор множителя в структурном выражении
    /// </summary>
    internal class Factor : CommonParser
    {
        /// <summary>
        /// Структурный множитель
        /// </summary>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <syntax>NodeDeclaration | DesignVariable | ( StructExpression )
        /// | Connection | StructConstant </syntax>
        public static CodeStatementCollection Parse(EndKeyList endKeys)
        {
            CodeStatementCollection resultStatList = new CodeStatementCollection();

            if (!FactorKeySet.Start.Factor.Contains(currKey))
            {
                Fabric.Instance.ErrReg.Register(Err.Parser.WrongStartSymbol.StructFactor, FactorKeySet.Start.Factor);
                SkipTo(endKeys.UniteWith(FactorKeySet.Start.Factor));
            }
            if (FactorKeySet.Start.Factor.Contains(currKey))
            {
                switch (currKey)
                {
                    case Key.Identificator:
                        //By jum
                        //уже созданная вершина
                        if (CommonArea.Instance.IsNodeRegistered((currSymbol as IdentSymbol).Name))
                        {
                            string nodeVarStringCode = (currSymbol as IdentSymbol).Name;
                            Accept( Key.Identificator );
                            resultStatList.AddRange( NodeAddVarCode(nodeVarStringCode) );
                        }
                        //Графовая переменная
                        else
                        {
                            string graphVarStringCode = DesignVariable.Parse(endKeys, DesignTypeCode.Structure).StrCode;
                            //Генерация кода
                            resultStatList.Add(GraphVarCode(graphVarStringCode));
                        }                
                        break;

                    //Вершина
                    case Key.Node:
                        Accept(Key.Node);

                        resultStatList.AddRange(NodeDeclaration.Parse(endKeys));
                        break;

                    //Структурное выражение
                    case Key.LeftPar:
                        Accept(Key.LeftPar);

                        resultStatList.AddRange(StructExpression.Parse(endKeys.UniteWith(Key.RightPar)));

                        Accept(Key.RightPar);

                        if (!endKeys.Contains(currKey))
                        {
                            Fabric.Instance.ErrReg.Register(Err.Parser.WrongEndSymbol.ExprInPar, endKeys.GetLastKeys());
                            SkipTo(endKeys);
                        }
                        break;

                    //Соединение
                    case Key.Arc:
                        Accept(Key.Arc);
                        resultStatList.AddRange(Connection.Parse(endKeys,
                            Builder.Structure.BuildExpr.DinamicOperation.AddArcInGraph));
                        break;
                    case Key.Edge:
                        Accept(Key.Edge);
                        resultStatList.AddRange(Connection.Parse(endKeys,
                            Builder.Structure.BuildExpr.DinamicOperation.AddEdgeInGraph));
                        break;

                    //Структурная константа
                    case Key.UndirectCycle:
                        Accept(Key.UndirectCycle);
                        resultStatList.AddRange(Constant.Parse(endKeys, Builder.Structure.BuildExpr.Stack.PushNewUndirectCicle));
                        break;
                    case Key.UndirectPath:
                        Accept(Key.UndirectPath);
                        resultStatList.AddRange(Constant.Parse(endKeys, Builder.Structure.BuildExpr.Stack.PushNewUndirectPath));
                        break;
                    case Key.UndirectStar:
                        Accept(Key.UndirectStar);
                        resultStatList.AddRange(Constant.Parse(endKeys, Builder.Structure.BuildExpr.Stack.PushNewUndirectStar));
                        break;
                    case Key.DirectCycle:
                        Accept(Key.DirectCycle);
                        resultStatList.AddRange(Constant.Parse(endKeys, Builder.Structure.BuildExpr.Stack.PushNewDirectCicle));
                        break;
                    case Key.DirectPath:
                        Accept(Key.DirectPath);
                        resultStatList.AddRange(Constant.Parse(endKeys, Builder.Structure.BuildExpr.Stack.PushNewDirectPath));
                        break;
                    case Key.DirectStar:
                        Accept(Key.DirectStar);
                        resultStatList.AddRange(Constant.Parse(endKeys, Builder.Structure.BuildExpr.Stack.PushNewDirectStar));
                        break;
                }
            }

            return resultStatList;
        }


        /// <summary>
        /// Сгенерировать код для обращения к графовой переменной в структурном выражении
        /// </summary>
        /// <param name="graphVarStringCode">Строковый код графовой переменной</param>
        /// <returns>Сгенерированный код</returns>
        public static CodeStatement GraphVarCode(string graphVarStringCode)
        {
            CodeMethodInvokeExpression resultStat = new CodeMethodInvokeExpression(
                new CodeThisReferenceExpression(), Builder.Structure.BuildExpr.Stack.Push,
                new CodeArgumentReferenceExpression(graphVarStringCode));

            return new CodeExpressionStatement(resultStat);
        }


        //By jum
        /// <summary>
        /// Сгенерировать код для добавления вершины к графовой переменной в структурном выражении
        /// </summary>
        /// <param name="nodeVarStrinCode">Строковый код переменной обозначающей вершину</param>
        /// <returns>Сгенерированный код</returns>
        public static CodeStatementCollection NodeAddVarCode(string nodeVarStrinCode)
        {
            CodeStatementCollection resultStatList = new CodeStatementCollection();
            
            //Создаем пустой граф
            CodeMethodInvokeExpression createGraphStat = new CodeMethodInvokeExpression(
                new CodeThisReferenceExpression(), Builder.Structure.BuildExpr.Stack.PushNew);
            resultStatList.Add(new CodeExpressionStatement(createGraphStat));

            //Объявляем в текущем графе вершину
            CodeMethodInvokeExpression AddNodeStat = new CodeMethodInvokeExpression(
                new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), Builder.Structure.BuildExpr.Stack.First),
                Builder.Structure.BuildExpr.DinamicOperation.Unite, new CodeArgumentReferenceExpression(nodeVarStrinCode));
            resultStatList.Add(new CodeExpressionStatement(AddNodeStat));

            return resultStatList;
        }

    }
}
