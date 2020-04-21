using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler.Parser.Common.Expr.SimpleExpr
    {
    /// <summary>
    /// Генерация кода для простого выражени в арифметическом выражении
    /// </summary>
    internal partial class SimpleExpression : CommonParser
        {
        /// <summary>
        /// Генерация кода в простом выражении
        /// </summary>
        /// <param name="info">Информация о всем простом выражении</param>
        /// <param name="nextAddendInfo">Информация о текущем слагаемом</param>
        /// <param name="addendOperation">Операция сложения</param>
        private static void BuildStringCodeForSimpleExpression( ExprInfo info, ExprInfo nextAddendInfo, Key addendOperation )
            {
            if ( info.HasNoError && nextAddendInfo.HasNoError )
                {
                switch ( addendOperation )
                    {
                    case Key.Plus:
                        info.Append( "+" );
                        info.Append( nextAddendInfo.StrCode );
                        break;

                    case Key.Minus:
                        info.Append( "-" );
                        info.Append( nextAddendInfo.StrCode );
                        break;

                    case Key.Or:
                        if ( nextAddendInfo.Type.Code == TypeCode.Bit )
                            {
                            info.Append( "|" );
                            info.Append( nextAddendInfo.StrCode );
                            }
                        else
                            {
                            info.Append( "||" );
                            info.Append( nextAddendInfo.StrCode );
                            }
                        break;
                    }
                }
            }

        }
    }
