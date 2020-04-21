using System;
using System.Collections.Generic;
using System.Text;


namespace TriadCompiler.Parser.Common.Expr
    {
    /// <summary>
    /// Генерация кода для арифметических выражений
    /// </summary>
    internal partial class Expression : CommonParser
        {
        /// <summary>
        /// Построить символьное представление выражения
        /// </summary>
        /// <param name="info">Данные о левом простом выражении</param>
        /// <param name="relationOperation">Операция сравнения</param>
        /// <param name="rightSimpleExprInfo">Данные о правом простом выражении</param>
        private static void BuildStringCodeForExpression( ExprInfo info, Key relationOperation, ExprInfo rightSimpleExprInfo )
            {
            if ( info.HasNoError && rightSimpleExprInfo.HasNoError )
                {
                switch ( relationOperation )
                    {
                    case Key.Equal:
                        info.Append( "==" );
                        info.Append( rightSimpleExprInfo.StrCode );
                        break;

                    case Key.NotEqual:
                        info.Append( "!=" );
                        info.Append( rightSimpleExprInfo.StrCode );
                        break;

                    case Key.Later:
                        if ( info.Type.Code == TypeCode.String )
                            {
                            info.InsertFirst( "String.Compare(" );
                            info.Append( "," );
                            info.Append( rightSimpleExprInfo.StrCode );
                            info.Append( ")<0" );
                            }
                        else
                            {
                            info.Append( "<" );
                            info.Append( rightSimpleExprInfo.StrCode );
                            }
                        break;

                    case Key.LaterEqual:
                        if ( info.Type.Code == TypeCode.String )
                            {
                            info.InsertFirst( "String.Compare(" );
                            info.Append( "," );
                            info.Append( rightSimpleExprInfo.StrCode );
                            info.Append( ")<=0" );
                            }
                        else
                            {
                            info.Append( "<=" );
                            info.Append( rightSimpleExprInfo.StrCode );
                            }
                        break;

                    case Key.Greater:
                        if ( info.Type.Code == TypeCode.String )
                            {
                            info.InsertFirst( "String.Compare(" );
                            info.Append( "," );
                            info.Append( rightSimpleExprInfo.StrCode );
                            info.Append( ")>0" );
                            }
                        else
                            {
                            info.Append( ">" );
                            info.Append( rightSimpleExprInfo.StrCode );
                            }
                        break;

                    case Key.GreaterEqual:
                        if ( info.Type.Code == TypeCode.String )
                            {
                            info.InsertFirst( "String.Compare(" );
                            info.Append( "," );
                            info.Append( rightSimpleExprInfo.StrCode );
                            info.Append( ")>=0" );
                            }
                        else
                            {
                            info.Append( ">=" );
                            info.Append( rightSimpleExprInfo.StrCode );
                            }
                        break;

                    case Key.In:
                        info.InsertFirst( "(" + rightSimpleExprInfo.StrCode + ").In(" );
                        info.Append( ")" );
                        break;
                    }
                }
            }

        }
    }
