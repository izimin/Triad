using System;
using System.Collections.Generic;
using System.Text;

using TriadCompiler.Parser.Common.Expr;

namespace TriadCompiler.Parser.Common.Expr.Add
    {
    /// <summary>
    /// Генерация кода для слагаемого в арифметическом выражении
    /// </summary>
    internal partial class Addend
        {
        /// <summary>
        /// Генерация кода в слагаемом
        /// </summary>
        /// <param name="info">Информация о всем слагаемом</param>
        /// <param name="nextFactorInfo">Информация о текущем множителе</param>
        /// <param name="multiplierOperation">Операция умножения</param>
        private static void BuildStringCodeForAddend( ExprInfo info, ExprInfo nextFactorInfo, Key multiplierOperation )
            {
            if ( info.HasNoError && nextFactorInfo.HasNoError )
                {
                switch ( multiplierOperation )
                    {
                    //Умножение
                    case Key.Star:
                        info.Append( "*" );
                        info.Append( nextFactorInfo.StrCode );
                        break;

                    //Деление
                    case Key.Slash:
                        info.Append( "/" );
                        info.Append( nextFactorInfo.StrCode );
                        break;

                    //Логическое И
                    case Key.And:
                        if ( nextFactorInfo.Type.Code == TypeCode.Bit )
                            {
                            info.Append( "&" );
                            info.Append( nextFactorInfo.StrCode );
                            }
                        else
                            {
                            info.Append( "&&" );
                            info.Append( nextFactorInfo.StrCode );
                            }
                        break;

                    //Остаток от деления
                    case Key.ResidueOfDivision:
                        info.Append( "%" );
                        info.Append( nextFactorInfo.StrCode );
                        break;
                    }
                }
            }
        }
    }
