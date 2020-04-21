using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Model.DesignVar;
using TriadCompiler.Parser.Structure.StructExpr;
//by jum
using TriadCompiler.Parser.Common.Function;
using TriadCompiler.Parser.Common.Expr;

namespace TriadCompiler.Parser.Structure.Statement
{
    /// <summary>
    /// Разбор оператора присваивания
    /// </summary>
    internal class StructAssignement : CommonParser
    {
        /// <summary>
        /// Построение графовой модели
        /// </summary>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <syntax>DesignVariable := StructExpression</syntax>
        public static CodeStatementCollection Parse(EndKeyList endKeys)
        {
            string varResultStringCode = DesignVariable.Parse(endKeys.UniteWith(Key.Assign), DesignTypeCode.Structure).StrCode;

            Accept(Key.Assign);

            //by Jum
            ExprInfo exprInfo = null;
            CodeStatementCollection statList = null;
            bool bIsFunction = false;
            if (currKey == Key.Identificator)
            {
                string identName = (currSymbol as IdentSymbol).Name;
                //вызов функции
                if (CommonArea.Instance.IsFunctionRegistered( identName ))
                {
                    bIsFunction = true;
                    statList = new CodeStatementCollection();
                    exprInfo = Expression.Parse(endKeys);

                    CheckDesignTypes( new DesignVarType( DesignTypeCode.Structure ), exprInfo.Type );

                    string graphVarStringCode = exprInfo.StrCode;
               
                    //Генерация кода
                    CodeMethodInvokeExpression resultStat = new CodeMethodInvokeExpression(
                    new CodeThisReferenceExpression(), Builder.Structure.BuildExpr.Stack.Push,
                    new CodeArgumentReferenceExpression( graphVarStringCode ) );
                    statList.Add( new CodeExpressionStatement( resultStat ) );
                }
            }
            if (!bIsFunction)
                statList = StructExpression.Parse( endKeys );

            //Генерация кода
            CodeAssignStatement assignStat = new CodeAssignStatement();
            assignStat.Left = new CodeArgumentReferenceExpression(varResultStringCode);

            //Вызов метода pop
            assignStat.Right = new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(
                new CodeThisReferenceExpression(), Builder.Structure.BuildExpr.Stack.Pop));

            statList.Add(assignStat);

            return statList;
        }

        //By Jum
        /// <summary>
        /// проверить совместимость design типов в операторе присваивания
        /// </summary>
        /// <param name="varType">тип переменной</param>
        /// <param name="exprType">тип присваиваемого выражения</param>
        /// <returns></returns>
        public static bool CheckDesignTypes(IExprType varType, IExprType exprType)
        {
            bool typesArePermissible = true;
            //Если хотя бы один из типов пустой
            if (varType == null || exprType == null)
            {
                return true;
            }
            else if (varType is IDesignVarType && exprType is IDesignVarType)
            {
                if ((varType as IDesignVarType).TypeCode != (exprType as IDesignVarType).TypeCode)
                {
                    typesArePermissible = false;
                }
            }
            else 
            {
                typesArePermissible = false;
            }
            //Если типы не совместимы
            if (!typesArePermissible)
            {
                Fabric.Instance.ErrReg.Register(Err.Parser.Type.Var.WrongType.InAssign);
            }

            return typesArePermissible;
        }
    }
}
