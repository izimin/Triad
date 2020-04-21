using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler.Parser.Common.Expr.Fact
    {
    /// <summary>
    /// Проверка типов для множителя в арифметическом выражении
    /// </summary>
    internal partial class Factor
        {
        /// <summary>
        /// Совместимость типов в операции not
        /// </summary>
        /// <param name="type">Тестируемый тип</param>
        /// <returns>Результирующий тип после выполнения операции</returns>
        private static IExprType CheckTypeInNotFactor( IExprType type )
            {
            //Если это пустой тип
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

            //Если это скаляр и тип не логический и не битовый
            if ( type.Code != TypeCode.Boolean && type.Code != TypeCode.Bit )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.Need.BooleanOrBit );
                return null;
                }
            return type;
            }


        /// <summary>
        /// Совместимость типов на уровне SimpleFactor
        /// </summary>
        /// <param name="prevType">Тестируемый тип</param>
        /// <param name="nextType">Тестируемый тип</param>
        /// <returns>Результирующий тип после выполнения операции</returns>
        private static IExprType CheckTypeInSimpleFactor( IExprType prevType, IExprType nextType )
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
            //Если хотя бы один из типов - это множество
            if ( prevType is SetType || nextType is SetType )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.Usage.NeedNotSet );
                return null;
                }

            //Если это не целый или вещественный
            if ( prevType.Code != TypeCode.Integer && prevType.Code != TypeCode.Real ||
                nextType.Code != TypeCode.Integer && nextType.Code != TypeCode.Real )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.WrongType.InArrow );
                return null;
                }

            //Если в степень возводятся целые числа
            if ( prevType.Code == TypeCode.Integer && nextType.Code == TypeCode.Integer )
                return new VarType( TypeCode.Integer );
            else
                return new VarType( TypeCode.Real );
            }
        }
    }
