using System;
using System.Collections.Generic;
using System.Text;

using TriadCompiler.Parser.Common.Declaration.Var;

namespace TriadCompiler.Parser.InfProcedure.Header
    {
    /// <summary>
    /// Разбор секции out-переменных
    /// </summary>
    internal class InfOutSection : CommonParser
        {
        /// <summary>
        /// Разбор секции out-переменных
        /// </summary>
        /// <syntax> SingleOutSection # SingleOutSection #</syntax>
        /// <param name="endKeys">Допустимые конечные символы</param>
        /// <returns>Список типов переменных</returns>
        public static List<IExprType> Parse( EndKeyList endKeys )
            {
            List<IExprType> varTypeList = new List<IExprType>();

            do
                varTypeList.AddRange( SingleOutSection( endKeys.UniteWith( Key.LeftFigurePar ) ) );
            while ( currKey == Key.LeftFigurePar );

            return varTypeList;
            }


        /// <summary>
        /// Разбор одной секции
        /// </summary>
        /// <syntax>{ VarDeclaration #,VarDeclaration# }</syntax>
        /// <param name="endKeys">Допустимые конечные символы</param>
        /// <returns>Список типов переменных</returns>
        private static List<IExprType> SingleOutSection( EndKeyList endKeys )
            {
            List<IExprType> varTypeList = new List<IExprType>();

            if ( currKey == Key.LeftFigurePar )
                {
                GetNextKey();

                varTypeList.AddRange( VarDeclaration.Parse( endKeys.UniteWith( Key.Semicolon, Key.RightFigurePar ),
                    VarDeclarationContext.Common ) );

                while ( currKey == Key.Semicolon )
                    {
                    GetNextKey();
                    varTypeList.AddRange( VarDeclaration.Parse( endKeys.UniteWith( Key.Semicolon, Key.RightFigurePar ),
                        VarDeclarationContext.Common ) );
                    }

                Accept( Key.RightFigurePar );
                }
            if ( !endKeys.Contains( currKey ) )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.SingleHeader, endKeys.GetLastKeys() );
                SkipTo( endKeys );
                }

            //Генерируем код
            foreach ( IExprType varType in varTypeList )
                if ( varType != null )
                    {
                    ( Fabric.Instance.Builder as IProcedureCodeBuilder ).AddOutVariable( varType );
                    }

            return varTypeList;
            }
        }
    }
