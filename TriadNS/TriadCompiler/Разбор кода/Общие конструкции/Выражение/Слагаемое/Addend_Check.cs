using System;
using System.Collections.Generic;
using System.Text;

using TriadCompiler.Parser.Common.Statement;

namespace TriadCompiler.Parser.Common.Expr.Add
    {
    /// <summary>
    /// Проверка типов для слагаемого в арифметическом выражении
    /// </summary>
    internal partial class Addend
        {
        /// <summary>
        /// Проверить совместимость типов на уровне Factor
        /// </summary>
        /// <param name="prevType">Тестируемый тип</param>
        /// <param name="nextType">Тестируемый тип</param>
        /// <param name="operation">Код операции</param>
        /// <returns>Результирующий тип после выполнения операции</returns>
        private static IExprType CheckTypeInFactor( IExprType prevType, IExprType nextType, Key operation )
            {
            //Если хотя бы один из типов пустой
            if ( prevType == null || nextType == null )
                return null;

            //Если хотя бы один из типов - это массив
            if ( prevType is VarArrayType || nextType is VarArrayType )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.Usage.NeedNotIndexed );
                return null;
                }

            //Если один из типов множество, а второй нет
            if ( ( prevType is SetType && !( nextType is SetType ) ) ||
                ( !( prevType is SetType ) && nextType is SetType ) ) 
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.WrongType.InStarSlash );
                return null;
                }

            IExprType resultType = null;

            //Если аргументы - два множества
            if ( prevType is SetType && nextType is SetType )
                {
                switch ( operation )
                    {
                    //Умножение
                    case Key.Star:

                        //Если тип одного из мн-в неопределен
                        if ( prevType.Code == TypeCode.UndefinedType ||
                            nextType.Code == TypeCode.UndefinedType )
                            {
                            return new SetType( TypeCode.UndefinedType );
                            }

                        //Если типы множеств совпадают
                        if ( prevType.Code == nextType.Code ||
                            //Или одно из множеств пустое
                            prevType is EmptySetType || nextType is EmptySetType )
                            {
                            //Если первое множество непустое
                            if ( !( prevType is EmptySetType ) )
                                resultType = prevType;
                            else
                                resultType = nextType;
                            }
                        //Если типы множеств не совпадают
                        else
                            {
                            Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.WrongType.InStarSlash );
                            resultType = null;
                            }
                        break;
                    //Во всех остальных случаях
                    default:
                        Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.WrongType.InStarSlash );
                        break;
                    }
                }
            //by jum
            //операции над вершинами
            else if (prevType.Code == TypeCode.Node && nextType.Code == TypeCode.Node)
            {
                //Если операция недопустима
                if (operation != Key.Star)
                {
                    Fabric.Instance.ErrReg.Register(Err.Parser.Type.Var.WrongType.InStarSlash);
                    return null;
                }
                return new VarType(TypeCode.Node);
            }
            //Если аргументы - это два скаляра
            else
                {               
                switch ( operation )
                    {
                    //Умножение
                    case Key.Star:
                        //Real*Integer | Integer*Real
                        if ( prevType.Code == TypeCode.Integer && nextType.Code == TypeCode.Real ||
                            prevType.Code == TypeCode.Real && nextType.Code == TypeCode.Integer )
                            {
                            resultType = new VarType( TypeCode.Real );
                            }
                        //Integer*Integer
                        else if ( prevType.Code == TypeCode.Integer && nextType.Code == TypeCode.Integer )
                            {
                            resultType = new VarType( TypeCode.Integer );
                            }
                        //Real*Real
                        else if ( prevType.Code == TypeCode.Real && nextType.Code == TypeCode.Real )
                            {
                            resultType = new VarType( TypeCode.Real );
                            }
                        else
                            {
                            Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.WrongType.InStarSlash );
                            }
                        break;

                    //Деление
                    case Key.Slash:
                        //Integer/Real | Real/Integer
                        if ( prevType.Code == TypeCode.Integer && nextType.Code == TypeCode.Real ||
                             prevType.Code == TypeCode.Real && nextType.Code == TypeCode.Integer )
                            {
                            resultType = new VarType( TypeCode.Real );
                            }
                        //Integer/Integer
                        else if ( prevType.Code == TypeCode.Integer && nextType.Code == TypeCode.Integer )
                            {
                            resultType = new VarType( TypeCode.Real );
                            }
                        //Real/Real
                        else if ( prevType.Code == TypeCode.Real && nextType.Code == TypeCode.Real )
                            {
                            resultType = new VarType( TypeCode.Real );
                            }
                        else
                            {
                            Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.WrongType.InStarSlash );
                            }
                        break;

                    //Логическое И
                    case Key.And:
                        //Boolean & Boolean
                        if ( prevType.Code == TypeCode.Boolean && nextType.Code == TypeCode.Boolean )
                            {
                            resultType = new VarType( TypeCode.Boolean );
                            }
                        //Bit & Bit
                        else if ( prevType.Code == TypeCode.Bit && nextType.Code == TypeCode.Bit )
                            {
                            resultType = new VarType( TypeCode.Bit );
                            }
                        else
                            {
                            Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.WrongType.InOrAnd );
                            }
                        break;
                    //Остаток от деления
                    case Key.ResidueOfDivision:
                        //Integer % Integer
                        if ( prevType.Code == TypeCode.Integer && nextType.Code == TypeCode.Integer )
                            {
                            resultType = new VarType( TypeCode.Integer );
                            }
                        else
                            {
                            Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.WrongType.InResidueOfDivision );
                            }
                        break;
                    }
                }

            return resultType;
            }
        }
    }
