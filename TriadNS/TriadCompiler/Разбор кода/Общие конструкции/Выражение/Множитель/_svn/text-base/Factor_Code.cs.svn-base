using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler.Parser.Common.Expr.Fact
    {
    /// <summary>
    /// Генерация кода для множителя в арифметическом выражении
    /// </summary>
    internal partial class Factor
        {
        /// <summary>
        /// Сгенерировать строковое представление для отрицания множителя
        /// </summary>
        /// <param name="info">Информация о множителе</param>
        private static void BuildStringCodeForNotFactor( ExprInfo info )
            {
            if ( info.HasNoError )
                {
                if ( info.Type.Code == TypeCode.Boolean )
                    {
                    info.InsertFirst( "!" );
                    }
                else if ( info.Type.Code == TypeCode.Bit )
                    {
                    info.InsertFirst( "(-1)^" );
                    }
                }
            }


        /// <summary>
        /// Сгенерировать строковое представление для множителя
        /// </summary>
        /// <param name="info">Информация о всем множителе</param>
        /// <param name="nextSimpleFactorInfo">Информация о текущес простом множителе</param>
        private static void BuildStringCodeForFactor( ExprInfo info, ExprInfo nextSimpleFactorInfo )
            {
            if ( info.HasNoError && nextSimpleFactorInfo.HasNoError )
                {
                if ( info.Type.Code == TypeCode.Integer && nextSimpleFactorInfo.Type.Code == TypeCode.Integer )
                    {
                    info.InsertFirst( "(int)Math.Pow(" );
                    info.Append( "," );
                    info.Append( nextSimpleFactorInfo.StrCode );
                    info.Append( ")" );
                    }
                else
                    {
                    info.InsertFirst( "Math.Pow(" );
                    info.Append( "," );
                    info.Append( nextSimpleFactorInfo.StrCode );
                    info.Append( ")" );
                    }
                }
            }
        }
    }
