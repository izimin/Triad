using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler.Parser.Common.Expr
    {
    /// <summary>
    /// Семантическая проверка арифметических выражений
    /// </summary>
    internal partial class Expression : CommonParser
        {
        /// <summary>
        /// Множество допустимых типов в операторе отношения
        /// </summary>
        private static List<TypeCode> relationOpTypeSet = null;


        /// <summary>
        /// Допустимые типы в операторе отношения
        /// </summary>
        private static List<TypeCode> RelOpTypes
            {
            get
                {
                if ( relationOpTypeSet == null )
                    {
                    TypeCode[] keySet = { TypeCode.Boolean, TypeCode.Char, TypeCode.Integer, 
                        TypeCode.Real, TypeCode.String, TypeCode.Bit, TypeCode.UndefinedType };

                    relationOpTypeSet = new List<TypeCode>( keySet );
                    }
                return relationOpTypeSet;
                }
            }


        /// <summary>
        /// Совместимость типов на уровне SimpleExpression
        /// Notype совместим с любым типом
        /// </summary>
        /// <param name="prevType">Тестируемый тип</param>
        /// <param name="nextType">Тестируемый тип</param>
        /// <param name="operation">Код операции</param>
        /// <returns>Результирующий тип после выполнения операции</returns>
        private static IExprType CheckTypeInSimpleExpression( IExprType prevType, IExprType nextType, Key operation )
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

            bool typesAreCompatible = false;

            //Если оба аргумента - множества
            if ( prevType is SetType && nextType is SetType )
                {
                //Если операция над множествами не является допустимой
                if ( ! new List<Key>( new[] { Key.Equal, Key.NotEqual, Key.LaterEqual, Key.GreaterEqual } ).Contains( operation ) )
                    {                    
                    }
                //Если у множеств неодинаковый тип
                else if ( prevType.Code != nextType.Code )
                    {
                    //Если у одного из мн-в неопределенный тип
                    if ( prevType.Code == TypeCode.UndefinedType ||
                        nextType.Code == TypeCode.UndefinedType )
                        {
                        typesAreCompatible = true;
                        }
                    //Если одно из множеств непустое
                    else if ( prevType is EmptySetType || nextType is EmptySetType )
                        {
                        typesAreCompatible = true;
                        }
                    }
                else
                    typesAreCompatible = true;
                }
            //Если первый аргумент - это скаляр, а второй - это множество
            else if ( !( prevType is SetType ) && nextType is SetType )
                {
                //Если операция не является допустимой
                if ( operation != Key.In )
                    {
                    }
                //Если у множества и скаляра неодинаковый тип
                else if ( prevType.Code != nextType.Code )
                    {
                    //Если множество пустое
                    if ( nextType is EmptySetType )
                        {
                        typesAreCompatible = true;
                        }
                    //Если тип множества не определен
                    if ( nextType.Code == TypeCode.UndefinedType )
                        {
                        typesAreCompatible = true;
                        }
                    //Если целое число проверяется на включение в вещественное мн-во
                    else if ( prevType.Code == TypeCode.Integer &&
                        nextType.Code == TypeCode.Real )
                        {
                        typesAreCompatible = true;
                        }
                    }
                else
                    typesAreCompatible = true;
                }
            //Если оба аргументы - это скаляры
            else if ( !( prevType is SetType ) && !( nextType is SetType ) )
                {
                //Если типы выражений недопустимые
                if ( !RelOpTypes.Contains( prevType.Code ) ||
                     !RelOpTypes.Contains( nextType.Code ) )
                    {
                    }
                //Если операция недопустима
                else if ( operation == Key.In )
                    {
                    }
                //Если типы выражений не совпадают
                else if ( prevType.Code != nextType.Code )
                    {
                    //Если это преведение целого к вещественному
                    if ( ( prevType.Code == TypeCode.Integer && nextType.Code == TypeCode.Real ) ||
                        ( nextType.Code == TypeCode.Integer && prevType.Code == TypeCode.Real ) )
                        {
                        typesAreCompatible = true;
                        }
                    }
                //Если оба аргумента имеют логический тип
                else if ( prevType.Code == TypeCode.Boolean )
                    {
                    //И операция допустимая
                    if ( operation == Key.Equal || operation == Key.NotEqual )
                        typesAreCompatible = true;
                    }
                //Если оба аргумента имеют неопределенный тип
                else if ( prevType.Code == TypeCode.UndefinedType )
                    {
                    //И операция допустимая
                    if ( operation == Key.Equal || operation == Key.NotEqual )
                        typesAreCompatible = true;
                    }
                else
                    typesAreCompatible = true;
                }


            if ( typesAreCompatible )
                return new VarType( TypeCode.Boolean );
            else
                {
                //Несовместимые типы
                Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.WrongType.InSimpleExpr );

                return null;
                }
            }

        }
    }
