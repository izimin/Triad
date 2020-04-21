using System;
using System.Collections.Generic;
using System.Text;

using TriadCompiler.Parser.Common.Var;
using TriadCompiler.Parser.Common.Expr;
using TriadCompiler.Parser.Common.Expr.Const;
using TriadCompiler.Parser.Common.Function;
using TriadCompiler.Parser.Common.Declaration.Var;

namespace TriadCompiler.Parser.Common.Expr.SimpleFact
    {
    /// <summary>
    /// Разбор простого множителя в арифметическом выражении
    /// </summary>
    internal class SimpleFactor : CommonParser
        {
        /// <summary>
        /// Множество стартовых символов простого множителя
        /// </summary>
        private static List<Key> simpleFactorSet = null;
        /// <summary>
        /// Множество стартовых символов константы
        /// </summary>
        private static List<Key> constantSet = null;
        
        /// <summary>
        /// Стартовые символы простого множителя
        /// </summary>
        private static List<Key> SimpleFactorStartKeys
            {
            get
                {
                if ( simpleFactorSet == null )
                    {
                    Key[] keySet = { Key.Identificator, Key.LeftPar, Key.BitStringValue, Key.StringValue,
                            Key.CharValue, Key.RealValue, Key.IntegerValue, Key.BooleanValue, Key.Nil, Key.LeftBracket };

                    simpleFactorSet = new List<Key>( keySet );
                    }

                return simpleFactorSet;
                }
            }


        /// <summary>
        /// Стартовые символы константы
        /// </summary>
        private static List<Key> ConstantStartKeys
            {
            get
                {
                if ( constantSet == null )
                    {
                    Key[] keySet = { Key.BitStringValue, Key.StringValue, Key.CharValue, Key.RealValue, 
                            Key.IntegerValue, Key.BooleanValue, Key.Nil };

                    constantSet = new List<Key>( keySet );
                    }
                return constantSet;
                }
            }


        /// <summary>
        /// Простой множитель
        /// </summary>
        /// <syntax>Constant | Variable | ( Expression )</syntax>
        /// <param name="endKeys">Допустимые конечные символы</param>
        /// <returns>Информация о выражении</returns>
        public static ExprInfo Parse( EndKeyList endKeys )
            {
            ExprInfo info = new ExprInfo();
            if ( !SimpleFactorStartKeys.Contains( currKey ) )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongStartSymbol.SimpleFactor, SimpleFactorStartKeys );
                SkipTo( endKeys.UniteWith( SimpleFactorStartKeys ) );
                }

            if ( SimpleFactorStartKeys.Contains( currKey ) )
                {
                //Константа
                if ( ConstantStartKeys.Contains( currKey ) )
                    {
                    info = Constant.Parse( endKeys );
                    }
                else if ( currKey == Key.Identificator )
                    {
                    string identName = ( currSymbol as IdentSymbol ).Name;
                    
                    //Вызов функции
                    if ( CommonArea.Instance.IsFunctionRegistered( identName ) )
                        {
                        FunctionInfo functionInfo = FunctionInvoke.Parse( endKeys );
                        info.Type = functionInfo.Type.ReturnedType;
                        info.Append( functionInfo.StrCode );
                        }
                    //Переменная
                    else
                        {
                        //=====By jum=====
                        VarInfo varInfo;
                        if (CommonArea.Instance.IsGraphRegistered( identName ))
                        {
                            varInfo = Variable.ParseGraphOrNode(endKeys);
                        }
                        else
                            varInfo = Variable.Parse( endKeys, false, true );
                        info.Type = varInfo.Type;
                        info.Append( varInfo.StrCode );
                        }
                    }
                //Если это константное множество
                else if ( currKey == Key.LeftBracket )
                    {
                    info = ConstantSet.Parse( endKeys );
                    }
                //Выражение в скобках или преведение типов
                else if ( currKey == Key.LeftPar )
                    {
                    Accept( Key.LeftPar );

                    //Если это приведение типов
                    if ( TypeDeclaration.SimpleTypeStartKeys.Contains( currKey ) )
                        {
                        info = TypeCast( endKeys );
                        }
                    //Выражение в скобках
                    else
                        {
                        info = Expression.Parse( endKeys.UniteWith( Key.RightPar ) );

                        info.InsertFirst( "(" );
                        info.Append( ")" );
                        Accept( Key.RightPar );
                        }

                    if ( !endKeys.Contains( currKey ) )
                        {
                        Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.ExprInPar );
                        SkipTo( endKeys );
                        }
                    }
                }
            return info;
            }


        /// <summary>
        /// Приведение типов
        /// </summary>
        /// <param name="endKeys">Допустимые конечные символы</param>
        /// <returns>Информация о выражении</returns>
        private static ExprInfo TypeCast( EndKeyList endKeys )
            {
            ExprInfo info = new ExprInfo();
            //Делаем значение выражения неконстантным
            info.Value = new ConstValue();

            //Тип, к которому приводится выражение
            VarType castType = TypeDeclaration.SimpleType( endKeys.UniteWith( Key.RightPar ) );

            Accept( Key.RightPar );

            ExprInfo exprInfo = Expression.Parse( endKeys );
            info.Append( exprInfo.StrCode );

            if ( castType != null && exprInfo.HasNoError )
                {
                if ( CheckCastTypes( castType, exprInfo ) )
                    {
                    info.Type = castType;

                    info.InsertFirst( "(" + CodeBuilder.GetBaseTypeString( castType ) + ")" );
                    }
                }

            return info;
            }


        /// <summary>
        /// Проверить
        /// </summary>
        /// <param name="castType">Тип, к которому нужно привести</param>
        /// <param name="exprInfo">Описание выражения</param>
        /// <returns>True, если приведение допустимо</returns>
        private static bool CheckCastTypes( VarType castType, ExprInfo exprInfo )
            {
            IExprType exprType = exprInfo.Type;

            //Если выражение - это массив
            if ( exprType is IndexedType )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.Usage.NeedNotIndexed );
                return false;
                }

            //Если выражение - это множество
            if ( exprType is SetType )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.Usage.NeedNotSet );
                return false;
                }

            //Если тип выражения не определен
            if ( exprType.Code == TypeCode.UndefinedType )
                //Если это не значение Nil
                if ( !( exprInfo.Value is NilValue ) )
                    {
                    // ...то допустимы любые приведения
                    return true;
                    }

            //Если выражение приводится к его собственному типу
            if ( exprType.Code == castType.Code )
                {
                return true;
                }

            //Если выражение приводится к неопределенному типу
            if ( castType.Code == TypeCode.UndefinedType )
                {
                return true;
                }

            //Если идет приведение между вещественным, целым, битовым или символьным
            if ( ( castType.Code == TypeCode.Real ||
                castType.Code == TypeCode.Integer ||
                castType.Code == TypeCode.Char ||
                castType.Code == TypeCode.Bit ) &&

                ( exprType.Code == TypeCode.Real ||
                exprType.Code == TypeCode.Integer ||
                exprType.Code == TypeCode.Char ||
                exprType.Code == TypeCode.Bit ) )
                {
                return true;
                }

            Fabric.Instance.ErrReg.Register( Err.Parser.Usage.UnableToCastType );
            return false;
            }

        }
    }
