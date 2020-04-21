using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Declaration.Var;
using TriadCompiler.Parser.Common.Statement;
using TriadCompiler.Parser.Common.Function;
using TriadCompiler.Parser.Structure.Statement;
using TriadCompiler.Parser.Model.Declaration.DesignVariable;
using TriadCompiler.Parser.Model.Statement;

namespace TriadCompiler
    {
    /// <summary>
    /// Часть парсера модели, отвечающая за разбор операторов
    /// </summary>
    internal partial class ModelParser
        {
        /// <summary>
        /// Множество стартовых символов оператора в модели
        /// </summary>
        private static List<Key> modelStatementSet = null;


        /// <summary>
        /// Стартовые символы оператора в модели
        /// </summary>
        private static List<Key> StartKeys
            {
            get
                {
                if ( modelStatementSet == null )
                    {
                    Key[] keySet = { Key.Identificator, Key.For, Key.While, Key.If, Key.Structure,
                        Key.Routine, Key.Model, Key.Let, Key.Put, Key.Foreach , Key.Print /*by jum*/};

                    modelStatementSet = new List<Key>( keySet );
                    //Объявление переменных
                    modelStatementSet.AddRange( TypeDeclaration.TypeStartKeys );
                    }
                return modelStatementSet;
                }
            }


        /// <summary> 
        /// Оператор в модели
        /// </summary>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <param name="context">Текущий контекст</param>
        /// <returns> Представление для генерации кода </returns>
        /// <syntax> StructVarDeclaration | StructAssignement | Assignement | IfStatement | WhileStatement |
        /// ForStatement | DesignTypeConstructor </syntax>
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
                //by jum
                if ( TypeDeclaration.TypeStartKeys.Contains( currKey ) && currKey != Key.Graph)
                    {
                    Fabric.Instance.Builder.AddVarDefinition( VarDeclaration.Parse( endKeys ) );
                    }
                else
                    {
                    switch ( currKey )
                        {
                        case Key.Identificator:
                            string identName = ( currSymbol as IdentSymbol ).Name;

                            //Вызов функции
                            if ( CommonArea.Instance.IsFunctionRegistered( identName ) )
                                {
                                CodeStatement methodInvoke = new CodeExpressionStatement( FunctionInvoke.Parse( endKeys ).Code );
                                statementList.Add( methodInvoke );
                                }
                            //Структурное присваивание
                            else if ( CommonArea.Instance.IsGraphRegistered( identName ) )
                                {
                                statementList.AddRange( StructAssignement.Parse( endKeys ) );
                                }
                            //Обычное присваивание
                            else
                                {
                                statementList.AddRange( Assignement.Parse( endKeys, AssignContext.Common ) );
                                }
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
                        //Объявление графовой переменной
                        //by jum
                        case Key.Graph:
                        case Key.Structure:
                        //Объявление переменной-рутины
                        case Key.Routine:
                        //Объявление модельной переменной
                        case Key.Model:
                            statementList.AddRange(DesignVarDeclaration.Parse( endKeys ));
                            break;
                        //Конструктор design переменной
                        case Key.Let:
                            statementList.AddRange( Let.Parse( endKeys ) );
                            break;
                        //Оператор наложения рутины
                        case Key.Put:
                            statementList.AddRange( PutRoutine.Parse( endKeys ) );
                            break;
                        //Оператор перебора элементов мн-ва
                        case Key.Foreach:
                            statementList.AddRange( Foreach.Parse( endKeys, context ) );
                            break;
                        //by jum
                        //Отладочная печать
                        case Key.Print:
                            statementList.Add(Print.Parse(endKeys));
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
