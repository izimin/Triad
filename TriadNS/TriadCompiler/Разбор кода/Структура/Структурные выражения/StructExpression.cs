using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Structure.StructExpr.Add;

namespace TriadCompiler.Parser.Structure.StructExpr
    {
    /// <summary>
    /// Разбор струтурных выражений
    /// </summary>
    internal partial class StructExpression : CommonParser
        {
        /// <summary>
        /// Структурное выражение
        /// </summary>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <syntax>StructAddend {StructAdd StructAddend }</syntax>
        /// <returns></returns>
        public static CodeStatementCollection Parse( EndKeyList endKeys )
            {
            CodeStatementCollection resultStatList = new CodeStatementCollection();

            resultStatList.AddRange( Addend.Parse( endKeys.UniteWith( StructExprKeySet.Operation.Add ) ) );

            while ( StructExprKeySet.Operation.Add.Contains( currKey ) )
                {
                //Код текущей операции
                Key currOperation = currKey;

                GetNextKey();
                resultStatList.AddRange( Addend.Parse( endKeys.UniteWith( StructExprKeySet.Operation.Add ) ) );

                //Генерация кода
                resultStatList.AddRange( ExpressionCode( currOperation ) );
                }

            return resultStatList;
            }


        /// <summary>
        /// Сгенерировать код для структурного выражения
        /// </summary>
        /// <param name="operation">Выполняемая операция</param>
        /// <returns>Сгенерированный код</returns>
        public static CodeStatementCollection ExpressionCode( Key operation )
            {
            CodeStatementCollection resultStatList = new CodeStatementCollection();

            //Генерируем выполнение операции
            CodeExpression resultExpr = new CodeExpression();

            switch ( operation )
                {
                //Слияние
                case Key.Plus:
                    CodeFieldReferenceExpression resultGraph = new CodeFieldReferenceExpression(
                        new CodeThisReferenceExpression(), Builder.Structure.BuildExpr.Stack.Second );
                    CodeFieldReferenceExpression addGraph = new CodeFieldReferenceExpression(
                        new CodeThisReferenceExpression(), Builder.Structure.BuildExpr.Stack.First );

                    resultExpr = new CodeMethodInvokeExpression( resultGraph, Builder.Structure.BuildExpr.DinamicOperation.Unite,
                        addGraph );
                    break;

                //Вычитание
                case Key.Minus:
                    resultGraph = new CodeFieldReferenceExpression(
                        new CodeThisReferenceExpression(), Builder.Structure.BuildExpr.Stack.Second );
                    addGraph = new CodeFieldReferenceExpression(
                        new CodeThisReferenceExpression(), Builder.Structure.BuildExpr.Stack.First );

                    resultExpr = new CodeMethodInvokeExpression( resultGraph, Builder.Structure.BuildExpr.DinamicOperation.Substract,
                        addGraph );
                    break;

                default:
                    throw new ArgumentOutOfRangeException( "Недопустимый код операции" );
                }

            resultStatList.Add( new CodeExpressionStatement( resultExpr ) );

            //Генерируем очистку стека
            CodeExpression clearStackStat = new CodeMethodInvokeExpression( new CodeThisReferenceExpression(),
                Builder.Structure.BuildExpr.Stack.Pop );
            resultStatList.Add( new CodeExpressionStatement( clearStackStat ) );

            return resultStatList;
            }
        
        }
    }
