using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler.Parser.Common.Header
    {
    /// <summary>
    /// Разбор заголовка объекта
    /// </summary>
    internal class Header : CommonParser
        {
        /// <summary>
        /// Заголовок объекта
        /// </summary>
        /// <syntax>{ ParameterList | Interface }</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <returns>Список типов параметров</returns>
        public static List<IExprType> Parse( EndKeyList endKeys )
            {
            List<IExprType> paramTypeList = new List<IExprType>();

            while ( currKey == Key.LeftBracket || currKey == Key.LeftPar )
                {
                //Список параметров
                if ( currKey == Key.LeftBracket )
                    {
                    List<IExprType> varTypeList = ParameterSection.Parse( endKeys.UniteWith( Key.LeftPar ), 
                        VarDeclarationContext.Common );

                    foreach ( IExprType varType in varTypeList )
                        if ( varType != null )
                            {
                            //Добавляем эту переменную в параметры конструктору
                            Fabric.Instance.Builder.AddParameterInConstructor( varType, varType.Name );
                            //Объявляем переменную внутри класса
                            Fabric.Instance.Builder.AddVarDefinition( varType );
                            }

                    paramTypeList.AddRange( varTypeList );
                    }
                //Интерфейс
                else if ( currKey == Key.LeftPar )
                    Interface.Parse( endKeys.UniteWith( Key.LeftBracket ) );
                }

            return paramTypeList;
            }
        }
    }
