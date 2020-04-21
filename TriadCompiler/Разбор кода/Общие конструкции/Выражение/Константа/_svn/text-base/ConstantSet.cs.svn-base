using System;
using System.Collections.Generic;
using System.Text;

using TriadCompiler.Parser.Common.Statement;

namespace TriadCompiler.Parser.Common.Expr.Const
    {
    /// <summary>
    /// Константное множество
    /// </summary>
    class ConstantSet : CommonParser
        {
        /// <summary>
        /// Константное множество
        /// </summary>
        /// <syntax>[ { Constant { , Constant } } ]</syntax>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <returns>Информация о константе</returns>
        public static ExprInfo Parse( EndKeyList endKeys )
            {
            ExprInfo info = new ExprInfo();
            info.Value = new SetValue();
            info.Append( "new Set(" );
            //Тип пустого мн-ва
            info.Type = new EmptySetType();

            Accept( Key.LeftBracket );

            //Тип первой константы в множестве
            IExprType firstItemType = null;

            if ( currKey != Key.RightBracket )
                {
                ExprInfo exprInfo = Expression.Parse( endKeys.UniteWith( Key.Comma, Key.RightBracket ) );

                if ( exprInfo.HasNoError && exprInfo.IsNotIndexed() && exprInfo.IsNotSet() )
                    {
                    //Сохраняем тип первой константы, только если она допустима
                    firstItemType = exprInfo.Type;

                    info.Type = new SetType( exprInfo.Type.Code );

                    //Заносим элемент в множество
                    SetValue setValue = info.Value as SetValue;

                    setValue.AddValue( exprInfo.Value );
                    info.Append( exprInfo.StrCode );
                    }


                while ( currKey == Key.Comma )
                    {
                    Accept( Key.Comma );

                    exprInfo = Expression.Parse( endKeys.UniteWith( Key.Comma, Key.RightBracket ) );

                    if ( exprInfo.HasNoError && exprInfo.IsNotIndexed() && exprInfo.IsNotSet() )
                        {
                        //Есди тип предыдущего элемента был недопустимый
                        if ( firstItemType == null )
                            {
                            firstItemType = exprInfo.Type;
                            info.Type = new SetType( exprInfo.Type.Code );
                            }

                        //Проверяем, совпадает ли тип следующих констант с первой константой
                        if ( Assignement.CheckVarTypes( firstItemType, exprInfo.Type ) )
                            {
                            //Заносим элемент в множество
                            SetValue setValue = info.Value as SetValue;

                            setValue.AddValue( exprInfo.Value );
                            info.Append( "," + exprInfo.StrCode );
                            }
                        }
                    }
                }            

            Accept( Key.RightBracket );

            info.Append( ")" );

            if ( !endKeys.Contains( currKey ) )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.ConstantSet, endKeys.GetLastKeys() );
                SkipTo( endKeys );
                }

            return info;
            }


        }
    }
