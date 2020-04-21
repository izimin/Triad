using System;
using System.Collections.Generic;
using System.Text;

using TriadCompiler.Parser.Common.Expr;

namespace TriadCompiler.Parser.Common.Expr.SimpleExpr
    {
    /// <summary>
    /// Проверка типов для простого выражения в арифметическом выражении
    /// </summary>
    internal partial class SimpleExpression
        {
        /// <summary>
        /// Совместимость типов на уровне Addend
        /// </summary>
        /// <param name="prevType">Тестируемый тип</param>
        /// <param name="nextType">Тестируемый тип</param>
        /// <param name="operation">Код операции</param>
        /// <returns>Результирующий тип после выполнения операции</returns>
        private static IExprType CheckTypeInAddend( IExprType prevType, IExprType nextType, Key operation )
            {
            //Если хотя бы один из типов пустой скаляр
            if ( prevType == null || nextType == null )
                return null;

            //Если хотя бы один из типов - это массив
            if ( prevType is VarArrayType || nextType is VarArrayType )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.Usage.NeedNotIndexed );
                return null;
                }

            //Если оба аргумента - это множества
            if ( prevType is SetType && nextType is SetType )
                {
                //Если операция недопустима
                if ( operation != Key.Plus && operation != Key.Minus )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.WrongType.InPlus );
                    return null;
                    }

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
                        return prevType;
                    else
                        return nextType;
                    }

                Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.WrongType.InPlus );
                return null;
                }
            //by jum
            //операции над вершинами
            else if (prevType.Code == TypeCode.Node && nextType.Code == TypeCode.Node)
            {
                //Если операция недопустима
                if ( operation != Key.Plus && operation != Key.Minus )
                {
                   Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.WrongType.InPlus );
                   return null;
                }
                return new VarType( TypeCode.Node );
            }
            //Если оба аргумента - скаляры
            else if ( !( prevType is SetType ) && !( nextType is SetType ) )
                {
                switch ( operation )
                    {
                    //Сложение
                    case Key.Plus:
                    //Вычитание
                    case Key.Minus:
                        //Целые или вещественные числа
                        if ( ( prevType.Code == TypeCode.Integer || prevType.Code == TypeCode.Real ) &&
                            ( nextType.Code == TypeCode.Integer || nextType.Code == TypeCode.Real ) )
                            {
                            //Только целые числа
                            if ( prevType.Code == TypeCode.Integer && nextType.Code == TypeCode.Integer )
                                return new VarType( TypeCode.Integer );
                            else
                                return new VarType( TypeCode.Real );
                            }
                        //Конкатенация строк (возможен только + )
                        else if ( prevType.Code == TypeCode.String && nextType.Code == TypeCode.String && operation == Key.Plus )
                            {
                            return new VarType( TypeCode.String );
                            }
                        else
                            {
                            Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.WrongType.InPlus );
                            return null;
                            }
                        

                    //Логическое ИЛИ
                    case Key.Or:
                        //Boolean | Boolean
                        if ( prevType.Code == TypeCode.Boolean && nextType.Code == TypeCode.Boolean )
                            {
                            return new VarType( TypeCode.Boolean );
                            }
                        //Битовые строки
                        else if ( prevType.Code == TypeCode.Bit && nextType.Code == TypeCode.Bit )
                            {
                            return new VarType( TypeCode.Bit );
                            }
                        else
                            {
                            Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.WrongType.InOrAnd );
                            return null;
                            }
                        
                    }
                }

            Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.WrongType.InPlus );
            return null;
            }


        /// <summary>
        /// Совместимость типов в операции minus
        /// </summary>
        /// <param name="type">Тестируемый тип</param>
        /// <returns>Результирующий тип после выполнения операции</returns>
        private static IExprType CheckTypeInMinusAddend( IExprType type )
            {
            //Если тип пустой
            if ( type == null )
                return null;

            //Если это множество
            if ( type is SetType )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.Usage.NeedNotSet );
                return null;
                }

            //Если это массив
            if ( type is VarArrayType )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.Usage.NeedNotIndexed );
                return null;
                }

            //Если это скаляр и недопустимые типы
            if ( type.Code != TypeCode.Integer && type.Code != TypeCode.Real )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.Usage.WrongMinusUsage );
                return null;
                }
            
            return type;
            }
        }
    }
