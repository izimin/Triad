using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Var;
using TriadCompiler.Parser.Common.Expr;

namespace TriadCompiler.Parser.Common.Statement
    {
    /// <summary>
    /// Оператор перебора элементов в мн-ве
    /// </summary>
    class Foreach : CommonParser
        {
        /// <summary>
        /// Число вызовов разбора оператора
        /// </summary>
        private static int invokeCount = 0;


        /// <summary>
        /// Разбор оператора
        /// </summary>
        /// <syntax>Foreach Variable In Expression Do StatementList EndF</syntax>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <param name="context">Текущий контекст</param>
        /// <returns>Представление для генерации кода</returns>
        public static CodeStatementCollection Parse( EndKeyList endKeys, StatementContext context )
            {
            CodeStatementCollection statList = new CodeStatementCollection();

            Accept( Key.Foreach );

            VarInfo varInfo = Variable.Parse( endKeys.UniteWith( Key.In, Key.EndFor ), /*Allow range*/ false, /*Allow array*/ false );

            //Предварительная проверка типа переменной
            if ( varInfo.HasNoError )
                //Если переменная - это массив
                if ( varInfo.Type is IndexedType )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.Usage.NeedNotIndexed );
                    }
                //Если переменная - это множество
                else if ( varInfo.Type is SetType )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.Usage.NeedNotSet );
                    }
                
            
            Accept( Key.In );

            ExprInfo exprInfo = Expression.Parse( endKeys.UniteWith( Key.Do, Key.EndFor ) );

            //Если выражение было разобрано правильно
            if ( exprInfo.HasNoError )
                {
                //Выражение должно быть массивом или множеством
                exprInfo.IsIndexedOrSet();

                //Если переменная была разобрана правильно
                if ( varInfo.HasNoError )
                    //Если тип переменной совпадает с типом выражения
                    if ( varInfo.Type.Code != exprInfo.Type.Code &&
                        // ... и выражение имеет тип
                        !( exprInfo.Type is EmptySetType ) )
                        {
                        Fabric.Instance.ErrReg.Register( Err.Parser.Usage.Foreach.IncompatibleTypes );
                        }
                }

            Accept( Key.Do );

            CodeStatementCollection internalStatList = StatementList.Parse( endKeys.UniteWith( Key.EndFor ), context );

            Accept( Key.EndFor );

            if ( exprInfo.HasNoError && varInfo.HasNoError )
                statList.AddRange( GenerateCode( varInfo, exprInfo, internalStatList ) );
            
            return statList;
            }


        /// <summary>
        /// Сгенерировать код
        /// </summary>
        /// <param name="varInfo">Описание переменной-счетчика</param>
        /// <param name="exprInfo">Описание множества</param>
        /// <param name="internalStatList">Список внутренних операторов</param>
        /// <returns>Сгенерированный код</returns>
        private static CodeStatementCollection GenerateCode( VarInfo varInfo, ExprInfo exprInfo, CodeStatementCollection internalStatList )
            {
            CodeStatementCollection statList = new CodeStatementCollection();
 
            //Генерируем переменную - итератор
            CodeVariableDeclarationStatement enumeratorStat = new CodeVariableDeclarationStatement();
            enumeratorStat.Name = GetEnumeratorName();

            enumeratorStat.Type = new CodeTypeReference( "IEnumerator" );

            //Заключаем выражение - мн-во в скобки
            exprInfo.InsertFirst( "(" );
            exprInfo.Append( ")" );

            //Генерируем начальное выражение
            CodeMethodInvokeExpression initStat = new CodeMethodInvokeExpression();
            initStat.Method.MethodName = "GetEnumerator";
            initStat.Method.TargetObject = exprInfo.Code;
            enumeratorStat.InitExpression = initStat;
            statList.Add( enumeratorStat );

            //Генерируем означивание переменной-счетчика
            CodeAssignStatement assignStat = new CodeAssignStatement();
            assignStat.Left = varInfo.Code;
            assignStat.Right = new CodeSnippetExpression(
                "(" + CodeBuilder.GetBaseTypeString( varInfo.Type ) + ")" + GetEnumeratorName() + ".Current" );

            //Генерируем цикл
            CodeIterationStatement loopStat = new CodeIterationStatement();
            loopStat.InitStatement = new CodeCommentStatement( "" );
            CodeMethodInvokeExpression testStat = new CodeMethodInvokeExpression();
            testStat.Method.MethodName = "MoveNext";
            testStat.Method.TargetObject = new CodeArgumentReferenceExpression( GetEnumeratorName() );
            loopStat.TestExpression = testStat;
            loopStat.IncrementStatement = new CodeCommentStatement( "" );

            loopStat.Statements.Add( assignStat );
            loopStat.Statements.AddRange( internalStatList );
            statList.Add( loopStat );

            invokeCount++;
            return statList;
            }


        /// <summary>
        /// Получить имя счетчика
        /// </summary>
        /// <returns></returns>
        private static string GetEnumeratorName()
            {
            return "___enum" + invokeCount.ToString();
            }

        }
    }
