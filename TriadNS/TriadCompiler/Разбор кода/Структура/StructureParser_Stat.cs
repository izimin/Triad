using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Declaration.Var;
using TriadCompiler.Parser.Common.Statement;
using TriadCompiler.Parser.Structure.Statement;
using TriadCompiler.Parser.Model.Declaration.DesignVariable;

namespace TriadCompiler
    {
    /// <summary>
    /// Разбор операторов в структуре
    /// </summary>
    internal partial class StructureParser
        {
        /// <summary>
        /// Множество стартовых символов оператора в структуре
        /// </summary>
        private static List<Key> structureStatementSet = null;


        /// <summary>
        /// Стартовые символы оператора в структуре
        /// </summary>
        private static List<Key> StartKeys
            {
            get
                {
                if ( structureStatementSet == null )
                    {
                    Key[] keySet = { Key.Identificator, Key.For, Key.While, Key.If, Key.Structure,
                        Key.Let, Key.Foreach };

                    structureStatementSet = new List<Key>( keySet );
                    //Объявление переменных
                    structureStatementSet.AddRange( TypeDeclaration.TypeStartKeys );
                    }
                return structureStatementSet;
                }
            }


        /// <summary> 
        /// Оператор в структуре
        /// </summary>
        /// <param name="endKeys"> Множество конечных символов </param>
        /// <param name="context"> Текущий контекст </param>
        /// <returns> Представление для генерации кода </returns>
        /// <syntax> StructVarDeclaration | StructAssignement | Assignement | IfStatement | WhileStatement |
        /// ForStatement | DesignTypeConstructor | Print </syntax>
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
                    Fabric.Instance.Builder.AddVarDefinition( VarDeclaration.Parse( endKeys) );
                    }
                else
                    {
                    switch ( currKey )
                        {
                        //Присваивание
                        case Key.Identificator:
                            //Структурное
                            if ( CommonArea.Instance.IsGraphRegistered( ( currSymbol as IdentSymbol ).Name ) )
                                {
                                statementList.AddRange( StructAssignement.Parse( endKeys ) );
                                }
                            //Обычное
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
                        case Key.Structure:
                            statementList.AddRange(DesignVarDeclaration.Parse( endKeys ));
                            break;
                        //Конструктор модельной переменной
                        case Key.Let:
                            statementList.AddRange( Let.Parse( endKeys ) );
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
