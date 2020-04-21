using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Declaration.Var;
using TriadCompiler.Parser.Common.Statement;
using TriadCompiler.Parser.Routine.Statement;

namespace TriadCompiler
    {
    internal partial class RoutineParser
        {
        /// <summary>
        /// Множество стартовых символов оператора в рутине
        /// </summary>
        private static List<Key> routineStatementSet = null;


        /// <summary>
        /// Стартовые символы оператора в рутине
        /// </summary>
        public static List<Key> StartKeys
            {
            get
                {
                if ( routineStatementSet == null )
                    {
                    Key[] keySet = { Key.Identificator, Key.For, Key.Case, Key.While, Key.Shedule, Key.Out,
                            Key.If, Key.Cancel, Key.Interlock, Key.Available, Key.Print, Key.Foreach };

                    routineStatementSet = new List<Key>( keySet );
                    //Объявление переменных
                    routineStatementSet.AddRange( TypeDeclaration.TypeStartKeys );
                    }
                return routineStatementSet;
                }
            }


        /// <summary>
        /// Обобщенный оператор
        /// </summary>
        /// <syntax>ПУСТО | Assignement | IfStatement | VariableDeclaration |
        /// WhileStatement | ForStatement | caseStatement | sheduleStatement |
        /// outStatement | cancelStatement | interlockStatement | availableStatement |
        /// writeStatement</syntax>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <param name="context">Текущий контекст</param>
        /// <returns>Представление для генерации кода (=null, если это пустой оператор)</returns>
        public override CodeStatementCollection Statement( EndKeyList endKeys, StatementContext context )
            {
            CodeStatementCollection statementList = new CodeStatementCollection();
            if ( !StartKeys.Contains( currKey ) &&
                 !endKeys.Contains( currKey ) )
                {
                err.Register( Err.Parser.WrongStartSymbol.Statement, StartKeys );
                SkipTo( endKeys.UniteWith( StartKeys ) );
                }
            if ( StartKeys.Contains( currKey ) )
                {
                //Объявление переменных
                if ( TypeDeclaration.TypeStartKeys.Contains( currKey ) )
                    {
                    if ( context != StatementContext.Initial )
                        err.Register( Err.Parser.Usage.Context.VarDeclaration );
                    // by jum
                    Dictionary<IExprType, CodeExpression> dict = VarDeclaration.Parse(endKeys);
                    (designTypeInfo as RoutineInfo).Variables.AddRange(dict.Keys);
                    Fabric.Instance.Builder.AddVarDefinition(dict);
                    }
                else
                    {
                    switch ( currKey )
                        {
                        //Присваивание
                        case Key.Identificator:
                            statementList.AddRange( Assignement.Parse( endKeys, AssignContext.Routine ) );
                            break;
                        //Условный оператор
                        case Key.If:
                            statementList.Add( Condition.Parse( endKeys, context ) );
                            break;
                        //Цикл While
                        case Key.While:
                            statementList.Add( WhileCicle.Parse( endKeys, context ) );
                            break;
                        //Цикл For
                        case Key.For:
                            statementList.Add( ForCicle.Parse( endKeys, context ) );
                            break;
                        //Выбор Case
                        case Key.Case:
                            if ( context != StatementContext.MessageEvent )
                                err.Register( Err.Parser.Usage.Context.Case );
                            statementList.Add( Case.Parse( endKeys, context ) );
                            break;
                        //Оператор отладочной печати
                        case Key.Print:
                            statementList.Add( Print.Parse( endKeys ) );
                            break;
                        //Оператор планирования
                        case Key.Shedule:
                            statementList.Add( Schedule.Parse( endKeys ) );
                            break;
                        //Оператор out
                        case Key.Out:
                            statementList.AddRange( OutStatement.Parse( endKeys ) );
                            break;
                        //Оператор отмены событий
                        case Key.Cancel:
                            statementList.Add( Cancel.Parse( endKeys ) );
                            break;
                        //Оператор блокирования входов
                        case Key.Interlock:
                            statementList.AddRange( Interlock.Parse( endKeys ) );
                            break;
                        //Оператор разблокирования входов
                        case Key.Available:
                            statementList.AddRange( Available.Parse( endKeys ) );
                            break;
                        //Оператор перебора элементов мн-ва
                        case Key.Foreach:
                            statementList.AddRange( Foreach.Parse( endKeys, context ) );
                            break;
                        }
                    }
                }
            

            if ( !endKeys.Contains( currKey ) )
                {
                err.Register( Err.Parser.WrongEndSymbol.Statement, endKeys.GetLastKeys() );
                SkipTo( endKeys );
                }
            return statementList;
            }
        }
    }
