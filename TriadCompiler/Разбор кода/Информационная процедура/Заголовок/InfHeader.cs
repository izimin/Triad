using System;
using System.Collections.Generic;
using System.Text;

using TriadCompiler.Parser.Common.Header;

namespace TriadCompiler.Parser.InfProcedure.Header
    {
    /// <summary>
    /// Разбор заголовка объекта
    /// </summary>
    internal class InfHeader : CommonParser
        {
        /// <summary>
        /// Стартовые символа заголовка ИП
        /// </summary>
        private static List<Key> startKeys = null;

        /// <summary>
        /// Стартовые символа заголовка ИП
        /// </summary>
        public static List<Key> StartKeys
            {
            get
                {
                if ( startKeys == null )
                    {
                    startKeys = new List<Key>();

                    startKeys.Add( Key.LeftFigurePar );
                    startKeys.Add( Key.LeftPar );
                    startKeys.Add( Key.LeftBracket );
                    }
                return startKeys;
                }
            }


        /// <summary>
        /// Заголовок объекта
        /// </summary>
        /// <syntax>{ ParameterList | Interface | OutList }</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <param name="ipType">Тип ИП</param>
        public static void Parse( EndKeyList endKeys, IProcedureType ipType )
            {
            while ( StartKeys.Contains( currKey ) )
                {
                //Список параметров
                if ( currKey == Key.LeftBracket )
                    {
                    ipType.ParamVarList.AddParameterList( ParameterSection.Parse( endKeys.UniteWith( Key.LeftPar, Key.LeftFigurePar ), 
                        VarDeclarationContext.Common ) );

                    foreach ( IExprType varType in ipType.ParamVarList )
                        if ( varType != null )
                            {
                            //Добавляем эту переменную в параметры конструктору
                            Fabric.Instance.Builder.AddParameterInConstructor( varType, varType.Name );
                            //Объявляем переменную внутри класса
                            Fabric.Instance.Builder.AddVarDefinition( varType );
                            }
                    }
                //Интерфейс
                else if ( currKey == Key.LeftPar )
                    {
                    ipType.AddParameterList( InfInterface.Parse( endKeys.UniteWith( Key.LeftBracket, Key.LeftFigurePar ) ) );
                    }
                //Список out-переменных
                else if ( currKey == Key.LeftFigurePar )
                    {
                    ipType.OutVarList.AddParameterList( InfOutSection.Parse( endKeys.UniteWith( Key.LeftBracket, Key.LeftPar ) ) );
                    }
                }
            }
        }
    }
