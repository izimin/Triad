using System;
using System.Collections.Generic;
using System.Text;

using TriadCompiler.Parser.Common.Declaration.Var;
using System.CodeDom;

namespace TriadCompiler.Parser.Model.Declaration.DesignVariable
    {
    /// <summary>
    /// Разбор объявления дизайн-переменных
    /// </summary>
    internal class DesignVarDeclaration : CommonParser
        {
        /// <summary>
        /// Список объявлений design переменных
        /// </summary>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <sysntax>Structure | Routine | Model | InfProcedure | ModelCondition
        /// DesignVarDeclaration {,DesignVarDeclaration}</sysntax>
        public static CodeStatementCollection Parse( EndKeyList endKeys )
            {
            CodeStatementCollection resultStatList = new CodeStatementCollection();
            DesignTypeCode varTypeCode = DesignTypeCode.Structure;
            switch ( currKey )
                {
                //Структурная переменная
                //by jum
                case Key.Graph:
                case Key.Structure:
                    varTypeCode = DesignTypeCode.Structure;
                    break;
                //Переменная - рутина
                case Key.Routine:
                    varTypeCode = DesignTypeCode.Routine;
                    break;
                //Модельная переменная
                case Key.Model:
                    varTypeCode = DesignTypeCode.Model;
                    break;
                }

            GetNextKey();

            resultStatList.AddRange(DesignDeclaration( endKeys.UniteWith( Key.Comma ), varTypeCode ));

            while ( currKey == Key.Comma )
                {
                Accept( Key.Comma );
                resultStatList.AddRange(DesignDeclaration( endKeys.UniteWith( Key.Comma ), varTypeCode ));
                }
            return resultStatList;
            }


        /// <summary>
        /// Объявление design переменной
        /// </summary>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <param name="designTypeCode">Тип design переменной</param>
        /// <syntax>Identificator # RangeDeclaration #</syntax>
        private static CodeStatementCollection DesignDeclaration( EndKeyList endKeys, DesignTypeCode designTypeCode )
            {
                CodeStatementCollection resultStatList = new CodeStatementCollection();
                if ( currKey != Key.Identificator )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.WrongStartSymbol.DesignVarDeclaration, Key.Identificator );
                    SkipTo( endKeys.UniteWith( Key.Identificator ) );
                    }

                if ( currKey == Key.Identificator )
                    {
                    IDesignVarType designVarType = null;
                    string varName = "";

                    if ( currKey == Key.Identificator )
                        {
                        varName = ( currSymbol as IdentSymbol ).Name;
                        designVarType = new DesignVarType( varName, designTypeCode );
                        }

                    Accept( Key.Identificator );

                    if ( currKey == Key.LeftBracket )
                        {
                        DesignVarArrayType arrayType = new DesignVarArrayType( varName, designTypeCode );

                        TypeDeclaration.RangeDeclaration( endKeys.UniteWith( Key.Comma, Key.RightBracket ), arrayType );
                        designVarType = arrayType;
                        }

                    //Регистрируем графовую переменную
                    CommonArea.Instance.Register( designVarType );

                    //Генерируем код
                    resultStatList = TriadCompiler.CodeBuilder.GetDesignVarDefinitionStatements(designVarType);

                    if ( !endKeys.Contains( currKey ) )
                        {
                        Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.DesignVarDeclaration, endKeys.GetLastKeys() );
                        SkipTo( endKeys );
                        }
                    }
                return resultStatList;
            }
        }
    }
