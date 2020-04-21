using System;
using System.Collections.Generic;
using System.Text;

using TriadCompiler.Parser.Common.Expr;

namespace TriadCompiler.Parser.Common.Expr.Const
    {
    /// <summary>
    /// Разбор арифметических констант
    /// </summary>
    class Constant : CommonParser
        {
        /// <summary>
        /// Константа
        /// </summary>
        /// <syntax>StringValue | CharValue | IntegerValue | RealValue | BitStringValue</syntax>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <returns>Информация о константе</returns>
        public static ExprInfo Parse( EndKeyList endKeys )
            {
            ExprInfo info = new ExprInfo();

            switch ( currKey )
                {
                //Строковая константа
                case Key.StringValue:
                    info.Value = new StringValue( ( currSymbol as StringSymbol ).Value );
                    info.Append( "\"" );
                    info.Append( ( currSymbol as StringSymbol ).Value );
                    info.Append( "\"" );
                    GetNextKey();
                    info.Type = new VarType( TypeCode.String );
                    break;
                //Символьная константа
                case Key.CharValue:
                    info.Value = new CharValue( ( currSymbol as CharSymbol ).Value );
                    info.Append( "'" );
                    info.Append( ( currSymbol as CharSymbol ).Value.ToString() );
                    info.Append( "'" );
                    GetNextKey();
                    info.Type = new VarType( TypeCode.Char );
                    break;
                //Целая константа
                case Key.IntegerValue:
                    info.Value = new IntegerValue( ( currSymbol as IntegerSymbol ).Value );
                    info.Append( ( currSymbol as IntegerSymbol ).Value.ToString() );
                    GetNextKey();
                    info.Type = new VarType( TypeCode.Integer );
                    break;
                //Вещественная константа
                case Key.RealValue:
                    info.Value = new RealValue( ( currSymbol as RealSymbol ).Value );
                    info.Append( ( currSymbol as RealSymbol ).Value.ToString() );
                    //Заменим запятые на точки в символьном представлении числа
                    info.Replace( ",", "." );
                    GetNextKey();
                    info.Type = new VarType( TypeCode.Real );
                    break;
                //Битовая константа
                case Key.BitStringValue:
                    info.Value = new BitStringValue( ( currSymbol as BitStringSymbol ).Value );
                    info.Append( "(" );
                    info.Append( ( currSymbol as BitStringSymbol ).Value.ToString() );
                    info.Append( ")" );
                    GetNextKey();
                    info.Type = new VarType( TypeCode.Bit );
                    break;
                //Логическая константа
                case Key.BooleanValue:
                    info.Value = new BooleanValue( ( currSymbol as BooleanSymbol ).Value );
                    //Чтобы было не True, а true
                    info.Append( ( currSymbol as BooleanSymbol ).Value.ToString().ToLower() );
                    GetNextKey();
                    info.Type = new VarType( TypeCode.Boolean );
                    break;
                //Пустой символ nil
                case Key.Nil:
                    info.Value = new NilValue();
                    info.Append( "null" );
                    GetNextKey();
                    info.Type = new VarType( TypeCode.UndefinedType );
                    break;
                }

            if ( !endKeys.Contains( currKey ) )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.Constant, endKeys.GetLastKeys() );
                SkipTo( endKeys );
                }
            return info;
            }
        }
    }
