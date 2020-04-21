using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Var;
using TriadCompiler.Parser.Common.Expr;

namespace TriadCompiler.Parser.Common.Statement
    {
    /// <summary>
    /// Разбор цикла со счетчиком
    /// </summary>
    internal class ForCicle : CommonParser
        {
        /// <summary>
        /// Цикл со счетчиком
        /// </summary>
        /// <syntax>For Variable := Expression [ By Expression ] To Expression Do StatementList EndFor</syntax>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <param name="context">Текущий контекст</param>
        /// <returns>Представление для генерации кода</returns>
        public static CodeStatement Parse( EndKeyList endKeys, StatementContext context )
            {
            CodeIterationStatement forStatement = new CodeIterationStatement();
            Accept( Key.For );

            VarInfo indexVarInfo = Variable.Parse( endKeys.UniteWith( Key.Assign, Key.EndFor ), false, false );

            //Тип переменной должен быть целым
            if ( indexVarInfo.HasNoError )
                if ( indexVarInfo.Type.Code != TypeCode.Integer )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.Need.Integer );
                    }

            Accept( Key.Assign );

            ExprInfo initialExprInfo = Expression.Parse( endKeys.UniteWith( Key.By, Key.To, Key.DownTo, Key.EndFor ) );

            //Генерация кода
            forStatement.InitStatement = new CodeAssignStatement( indexVarInfo.Code,
                initialExprInfo.Code );


            //Индикатор ошибки в начальном выражении
            bool errorInInitialExpr = !initialExprInfo.IsNotIndexed();
            errorInInitialExpr |= !initialExprInfo.IsNotSet();
            //Тип выражения должен быть целым
            errorInInitialExpr |= !initialExprInfo.IsInteger();

            ExprInfo stepExprInfo = new ExprInfo();

            //Если указан шаг изменения индекса
            if ( currKey == Key.By )
                {
                Accept( Key.By );

                stepExprInfo = Expression.Parse( endKeys.UniteWith( Key.To, Key.DownTo, Key.EndFor ) );

                stepExprInfo.IsNotIndexed();
                stepExprInfo.IsNotSet();
                //Тип выражения должен быть целым
                stepExprInfo.IsInteger();
                //Тип выражения должен быть константой
                stepExprInfo.IsConstant();
                //Константа должна быть положительной
                stepExprInfo.PositiveIntegerOrReal();
                }
            //По умолчанию увеличиваем на 1
            else
                {
                stepExprInfo.Append( "1" );
                }


            //Направление изменения индекса
            bool growingDirect = true;

            if ( currKey == Key.To )
                {
                Accept( Key.To );
                }
            else if ( currKey == Key.DownTo )
                {
                Accept( Key.DownTo );
                growingDirect = false;
                }
            else
                Accept( Key.To );

            ExprInfo terminalExprInfo = Expression.Parse( endKeys.UniteWith( Key.Do, Key.EndFor ) );

            bool errorInTerminalExpr = !terminalExprInfo.IsNotIndexed();
            errorInTerminalExpr |= !terminalExprInfo.IsNotSet();
            //Тип выражения должен быть целым
            errorInTerminalExpr |= !terminalExprInfo.IsInteger();

            //Если оба выражения правильные
            if ( !errorInInitialExpr && !errorInTerminalExpr )
                    //Если начальное выражение и конечное были вычисляемы
                    if ( initialExprInfo.Value.IsConstant && terminalExprInfo.Value.IsConstant )
                        if ( growingDirect && ( initialExprInfo.Value as IntegerValue ).Value >
                                          ( terminalExprInfo.Value as IntegerValue ).Value )
                            {
                            Fabric.Instance.ErrReg.Register( Err.Parser.Usage.For.InitExprIsGreaterThanTerminal );
                            }
                        else if ( !growingDirect && ( initialExprInfo.Value as IntegerValue ).Value <
                                          ( terminalExprInfo.Value as IntegerValue ).Value )
                            {
                            Fabric.Instance.ErrReg.Register( Err.Parser.Usage.For.InitExprIsLowerThanTerminal );
                            }


            CodeBinaryOperatorExpression compareStatementCode = new CodeBinaryOperatorExpression();
            compareStatementCode.Left = indexVarInfo.Code;
            compareStatementCode.Right = terminalExprInfo.Code;

            CodeAssignStatement stepStatementCode = new CodeAssignStatement();
            stepStatementCode.Left = indexVarInfo.Code;
            CodeBinaryOperatorExpression stepExprCode = new CodeBinaryOperatorExpression();
            stepStatementCode.Right = stepExprCode;

            stepExprCode.Left = indexVarInfo.Code;
            stepExprCode.Right = stepExprInfo.Code;

            if ( growingDirect )
                {
                compareStatementCode.Operator = CodeBinaryOperatorType.LessThanOrEqual;
                stepExprCode.Operator = CodeBinaryOperatorType.Add;
                }
            else
                {
                compareStatementCode.Operator = CodeBinaryOperatorType.GreaterThanOrEqual;
                stepExprCode.Operator = CodeBinaryOperatorType.Subtract;
                }

            forStatement.TestExpression = compareStatementCode;
            forStatement.IncrementStatement = stepStatementCode;

            Accept( Key.Do );

            forStatement.Statements.AddRange( StatementList.Parse( endKeys.UniteWith( Key.EndFor ), context ) );

            Accept( Key.EndFor );

            return forStatement;
            }
        }
    }
