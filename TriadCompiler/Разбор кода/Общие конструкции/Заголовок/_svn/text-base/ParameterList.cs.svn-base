using System;
using System.Collections.Generic;
using System.Text;

using TriadCompiler.Parser.Common.Declaration.Var;

namespace TriadCompiler.Parser.Common.Header
    {
    /// <summary>
    /// Разбор списка параметров объекта
    /// </summary>
    internal class ParameterSection : CommonParser
        {
        /// <summary>
        /// Список параметров
        /// </summary>
        /// <syntax> SingleParameterList {SingleParameterList}</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <param name="context">Контекст</param>
        /// <returns>Множество объявленных типов</returns>
        public static List<IExprType> Parse( EndKeyList endKeys, VarDeclarationContext context )
            {
            List<IExprType> varTypeList = new List<IExprType>();

            do
                varTypeList.AddRange( SingleParameterList( endKeys.UniteWith( Key.LeftBracket ), context ) );
            while ( currKey == Key.LeftBracket );
            
            return varTypeList;
            }

        
        /// <summary>
        /// Отдельный список параметров
        /// </summary>
        /// <syntax>[ VariableDeclaration {;VariableDeclaration} ]</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <param name="context">Констекст</param>
        /// <returns>Множество объявленных типов</returns>
        private static List<IExprType> SingleParameterList( EndKeyList endKeys, VarDeclarationContext context )
            {
            List<IExprType> varTypeList = new List<IExprType>();

            if ( currKey == Key.LeftBracket )
                {
                GetNextKey();

                varTypeList.AddRange( VarDeclaration.Parse( endKeys.UniteWith( Key.Semicolon, Key.RightBracket ), context ) );

                while ( currKey == Key.Semicolon )
                    {
                    GetNextKey();
                    varTypeList.AddRange( VarDeclaration.Parse( endKeys.UniteWith( Key.Semicolon, Key.RightBracket ), context ) );
                    }

                Accept( Key.RightBracket );
                }
            if ( !endKeys.Contains( currKey ) )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.SingleHeader, endKeys.GetLastKeys() );
                SkipTo( endKeys );
                }

            return varTypeList;
            }        

        }
    }
