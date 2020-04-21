using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Expr;
using TriadCompiler.Parser.Common.Var;

namespace TriadCompiler.Parser.Common.Statement
    {
    /// <summary>
    /// Констект вызова оператора присваивания
    /// </summary>
    internal enum AssignContext
        {
        /// <summary>
        /// В рутине
        /// </summary>
        Routine,
        /// <summary>
        /// Где-то еще
        /// </summary>
        Common
        }

    /// <summary>
    /// Разбор оператора присваивания переменных
    /// </summary>
    internal class Assignement : CommonParser
        {
        /// <summary>
        /// Оператор присваивания
        /// </summary>
        /// <syntax>Variable := Expression</syntax>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <param name="context">Контекст вызова</param>
        /// <returns>Представление для генерации кода</returns>
        public static CodeStatementCollection Parse( EndKeyList endKeys, AssignContext context )
            {
            CodeStatementCollection resultStatList = new CodeStatementCollection();

            VarInfo varInfo = Variable.Parse( endKeys.UniteWith( Key.Assign ), false, true );
            
            Accept( Key.Assign );

            ExprInfo exprInfo = Expression.Parse( endKeys );

            CheckVarTypes( varInfo.Type, exprInfo.Type );


            //Генерация кода
            CodeAssignStatement assignStatement = new CodeAssignStatement();
            assignStatement.Left = new CodeFieldReferenceExpression( null, varInfo.StrCode.ToString() );
            assignStatement.Right = exprInfo.Code;
            resultStatList.Add( assignStatement );

            //В рутине нужно следить за изменением переменных,
            //поэтому генерим дополнительный код
            if ( context == AssignContext.Routine )
                {
                //Если это не присваивание массивов
                if ( !( varInfo.Type is VarArrayType ) )
                    {
                    CodeMethodInvokeExpression doVarChangeStat = new CodeMethodInvokeExpression();
                    doVarChangeStat.Method = new CodeMethodReferenceExpression();
                    doVarChangeStat.Method.MethodName = Builder.Routine.DoVarChanging;
                    doVarChangeStat.Parameters.Add( varInfo.CoreNameCode );

                    resultStatList.Add( doVarChangeStat );
                    }
                }

            return resultStatList;
            }



        /// <summary>
        /// Проверить типы в операторе присваивания
        /// </summary>
        /// <param name="varType">Информация о переменной</param>
        /// <param name="exprType">Тип выражения</param>
        /// <returns>True, если все в порядке</returns>
        public static bool CheckVarTypes( IExprType varType, IExprType exprType )
            {
            //Проверить совместимость типов в операторе assign
            bool typesArePermissible = true;

            //Если хотя бы один из типов пустой
            if ( varType == null || exprType == null )
                {
                return true;
                }

            //Если индексированность переменной и выражения не совпадают
            else if ( varType is IndexedType != exprType is IndexedType )
                {
                typesArePermissible = false;
                }

            //Если множественность переменной и выражения не совпадают
            else if ( varType is SetType != exprType is SetType )
                {
                typesArePermissible = false;
                }
            //by jum
            else if ( varType is DesignVarType != exprType is DesignVarType )
                {
                typesArePermissible = false;
                }
            else
                {
                //by jum
                if (varType is DesignVarType && exprType is DesignVarType)
                {
                    if ( ( varType as DesignVarType ).TypeCode != ( exprType as DesignVarType ).TypeCode )
                    {
                        typesArePermissible = false;
                    }
                }
                //Если приравниваются массивы
                if ( varType is IndexedType && exprType is IndexedType )
                    {
                     //Если коды массивов не совпадают
                    if ( varType.Code != exprType.Code )
                        {
                        typesArePermissible = false;
                        }

                    //И размерности массивов не совпадают
                    else if ( ( varType as IndexedType ).IndexCount != ( exprType as IndexedType ).IndexCount )
                        {
                        Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.WrongType.NotCompatibleDimensionArrayInAssign );
                        return false;
                        }
                    }
                //Если приравниваются множества
                else if ( varType is SetType && exprType is SetType )
                    {
                    //Если тип мн-ва слева не определен
                    if ( varType.Code == TypeCode.UndefinedType )
                        {
                        typesArePermissible = true;
                        }
                    //Если коды множеств не совпадают
                    else if ( varType.Code != exprType.Code &&
                        // и выражение - это не пустое множество
                        !( exprType is EmptySetType ) )
                        {
                        typesArePermissible = false;
                        }
                    }
                //Если приравниваются скаляры
                else
                    {
                    //Если тип переменной слева не определен
                    if ( varType.Code == TypeCode.UndefinedType )
                        {
                        typesArePermissible = true;
                        }
                    //Если коды переменных не совпадают
                    else if ( varType.Code != exprType.Code &&
                        // и не идет присваивание целого к вещественному
                        ( varType.Code != TypeCode.Real || exprType.Code != TypeCode.Integer ) )
                        {
                        typesArePermissible = false;
                        }
                    }

                }

            //Если типы не совместимы
            if ( !typesArePermissible )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.WrongType.InAssign );
                }

            return typesArePermissible;
            }


        /// <summary>
        /// Проверить присваивание полюсов
        /// </summary>
        /// <param name="varType">Тип полюса-переменной</param>
        /// <param name="exprType">Тип полюсного выражения</param>
        public static void CheckPolusTypes( IPolusType varType, IPolusType exprType )
            {
            //Проверить совместимость типов в операторе assign
            bool typesArePermissible = false;

            //Если один из типов является неопределенным
            if ( varType == null || exprType == null )
                {
                typesArePermissible = true;
                }

            //Если индексированность совпадает
           if ( varType is IndexedType == exprType is IndexedType )
                {
                //Если происходит присваивание массивов
                if ( varType is IndexedType && exprType is IndexedType )
                    {
                    //И размерности массивов не совпадают
                    if ( ( varType as IndexedType ).IndexCount != ( exprType as IndexedType ).IndexCount )
                        {
                        Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.WrongType.NotCompatibleDimensionArrayInAssign );
                        return;
                        }
                    }
                typesArePermissible = true;
                }

            //Если типы не совместимы
            if ( !typesArePermissible )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.WrongType.InAssign );
                }
            }
        }
    }
