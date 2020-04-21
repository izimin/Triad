using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Structure.StructExpr.Fact;

namespace TriadCompiler.Parser.Structure.StructExpr.Add
    {
    /// <summary>
    /// Разбор слагаемого в структурном выражении
    /// </summary>
    internal class Addend : CommonParser
        {
        /// <summary>
        /// Структурное слагаемое
        /// </summary>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <syntax>StructFactor { structMultOP StructFactor }</syntax>
        public static CodeStatementCollection Parse( EndKeyList endKeys )
            {
            CodeStatementCollection resultStatList = new CodeStatementCollection();

            resultStatList.AddRange( Factor.Parse( endKeys.UniteWith( StructExprKeySet.Operation.Mult ) ) );
            while ( StructExprKeySet.Operation.Mult.Contains( currKey ) )
                {
                //Код текущей операции
                Key currOperation = currKey;

                GetNextKey();
                resultStatList.AddRange( Factor.Parse( endKeys.UniteWith( StructExprKeySet.Operation.Mult ) ) );

                //Генерация кода
                resultStatList.AddRange( AddendCode( currOperation ) );
                }

            return resultStatList;
            }


        /// <summary>
        /// Сгенерировать код для структурного слагаемого
        /// </summary>
        /// <param name="operation">Код операции</param>
        /// <returns>Сгенерированный код</returns>
        private static CodeStatementCollection AddendCode( Key operation )
            {
            CodeStatementCollection resultStatList = new CodeStatementCollection();

            //Генерируем выполнение операции
            CodeExpression resultExpr = new CodeExpression();

            switch ( operation )
                {
                //Слияние
                case Key.Star:
                    CodeFieldReferenceExpression resultGraph = new CodeFieldReferenceExpression(
                        new CodeThisReferenceExpression(), Builder.Structure.BuildExpr.Stack.Second );
                    CodeFieldReferenceExpression addGraph = new CodeFieldReferenceExpression(
                        new CodeThisReferenceExpression(), Builder.Structure.BuildExpr.Stack.First );

                    resultExpr = new CodeMethodInvokeExpression( resultGraph, Builder.Structure.BuildExpr.DinamicOperation.Intersect,
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
