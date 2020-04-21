using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Declaration.Var;
using TriadCompiler.Parser.Common.Statement;
using TriadCompiler.Parser.Routine.Statement;
using TriadCompiler.Parser.InfProcedure.Statement;

namespace TriadCompiler
    {
    internal partial class InfProcedureParser
        {
        /// <summary>
        /// Множество стартовых символов оператора в ИП
        /// </summary>
        private static List<Key> startKeys = null;


        /// <summary>
        /// Стартовые символы оператора в ИП
        /// </summary>
        public static List<Key> StartKeys
            {
            get
                {
                if ( startKeys == null )
                    {
                    Key[] keySet = { Key.Identificator, Key.For, Key.Case, Key.While, 
                            Key.If, Key.Interlock, Key.Available, Key.Print, Key.Foreach };

                    startKeys = new List<Key>( keySet );
                    //Объявление переменных
                    startKeys.AddRange( TypeDeclaration.TypeStartKeys );
                    }
                return startKeys;
                }
            }


        /// <summary> 
        /// Оператор в информационной процедуре
        /// </summary>
        /// <param name="endKeys"> Множество конечных символов </param>
        /// <param name="context"> Текущий контекст </param>
        /// <returns> Представление для генерации кода </returns>
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
                    Fabric.Instance.Builder.AddVarDefinition( VarDeclaration.Parse( endKeys) );
                    }
                else
                    {
                    switch ( currKey )
                        {
                        case Key.Identificator:
                            //Оператор присваивания
                            statementList.AddRange( Assignement.Parse( endKeys, AssignContext.Common ) );
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
                        //Case оператор
                        case Key.Case:
                            if ( context != StatementContext.Handling )
                                err.Register( Err.Parser.Usage.Context.Case );
                            statementList.Add( InfCase.Parse( endKeys ) );
                            break;
                        //Available
                        case Key.Available:
                            statementList.AddRange( Available.Parse( endKeys ) );
                            break;
                        //Interlock
                        case Key.Interlock:
                            statementList.AddRange( Interlock.Parse( endKeys ) );
                            break;
                        //Отладочная печать
                        case Key.Print:
                            statementList.Add( Print.Parse( endKeys ) );
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
                err.Register( Err.Parser.WrongEndSymbol.Statement );
                SkipTo( endKeys );
                }
            return statementList;
            }
        }
    }
