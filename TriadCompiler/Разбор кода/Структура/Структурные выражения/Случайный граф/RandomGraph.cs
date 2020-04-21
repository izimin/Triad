using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Structure.StructExpr.Node;
using TriadCompiler.Parser.Common.Expr;
using TriadCompiler.Parser.Common.Statement;

namespace TriadCompiler.Parser.Structure.StructExpr.RandGraph
{
    class RandomGraph:CommonParser
    {
        public static CodeStatementCollection Parse(EndKeyList endKeys, string createRandGraphMethodName)
        {
            CodeStatementCollection resultStatList = new CodeStatementCollection();

            if(currKey!=Key.LeftPar)
            {
                //регистрация ошибки, добавить в список
                Fabric.Instance.ErrReg.Register(Err.Parser.WrongStartSymbol.StructConstant, Key.LeftPar);
                SkipTo(endKeys.UniteWith(Key.LeftPar));
            }

            if(currKey==Key.LeftPar)
            {
                Accept(Key.LeftPar);

                //Создаем пустой граф
                CodeMethodInvokeExpression createRandGraph = new CodeMethodInvokeExpression();
                createRandGraph.Method.TargetObject = new CodeThisReferenceExpression();

                resultStatList.Add(new CodeExpressionStatement(createRandGraph));
                createRandGraph.Method.MethodName = createRandGraphMethodName;

                //объявление вершин
                resultStatList.AddRange(NodeDeclaration.Parse(endKeys.UniteWith(Key.Comma, Key.RightPar)));
                //добавление этих вершин в граф
                resultStatList.AddRange(StructExpression.ExpressionCode(Key.Plus));

                while(currKey==Key.Comma)
                {
                    Accept(Key.Comma);
                    //объявление вершин
                    resultStatList.AddRange(NodeDeclaration.Parse(endKeys.UniteWith(Key.Comma, Key.RightPar)));
                    //добавление этих вершин в граф
                    resultStatList.AddRange(StructExpression.ExpressionCode(Key.Plus));
                }

                //Вызов метода CompleteGraph
                CodeMethodInvokeExpression completeGraph = new CodeMethodInvokeExpression(
                    new CodeMethodReferenceExpression(new CodeThisReferenceExpression(),
                    Builder.Structure.BuildExpr.Stack.First),
                    Builder.Structure.BuildExpr.DeclareOperation.Complete);
                //Добавление параметров
                completeGraph.Parameters.Add(new CodePrimitiveExpression());
                
            }
            return null;
        }
    }
}
