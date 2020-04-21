using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Expr;
using TriadCompiler.Parser.Common.Var;
using TriadCompiler.Parser.Common.Statement;

namespace TriadCompiler.Parser.Common.Function
    {
    /// <summary>
    /// Разбор вызова функции
    /// </summary>
    internal class FunctionInvoke : CommonParser
        {
        /// <summary>
        /// Разбор вызова фунцкии
        /// </summary>
        /// <syntax>Identificator ParameterList</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <returns>Представление для генерации кода</returns>
        public static FunctionInfo Parse( EndKeyList endKeys )
            {
            FunctionInfo info = new FunctionInfo();

            string functionName = ( currSymbol as IdentSymbol ).Name;
            GetNextKey();

            info.Type = CommonArea.Instance.GetType<FunctionType>( functionName );

            List<ExprInfo> paramExprList = ParameterList( endKeys, info.Type, Key.LeftPar, Key.RightPar );

            //Генерация кода вызова функции
            CodeMethodInvokeExpression methodInvoke = new CodeMethodInvokeExpression();
            methodInvoke.Method = new CodeMethodReferenceExpression();
            methodInvoke.Method.MethodName = info.Type.MethodCodeName;

            info.StrCode = info.Type.MethodCodeName + "(";
            for ( int index = 0; index < paramExprList.Count; index++ )
                {
                methodInvoke.Parameters.Add( paramExprList[ index ].Code );
                info.StrCode += paramExprList[ index ].StrCode;
                if ( index != paramExprList.Count - 1 )
                    info.StrCode += ",";
                }
            info.StrCode += ")";

            info.Code = methodInvoke;

            return info;
            }


        /// <summary>
        /// Разбор списка параметров вызова функции
        /// </summary>
        /// <syntax>( {Expression} )</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <param name="type">Тип функции</param>
        /// <param name="openPar">Символ открывающейся скобки</param>
        /// <param name="closePar">Символ закрывающейся скобки</param>
        /// <returns>Список выражений, представляющих параметры</returns>
        public static List<ExprInfo> ParameterList( EndKeyList endKeys, ParameterList<IExprType> type, Key openPar, Key closePar )
            {
            List<ExprInfo> paramExprList = new List<ExprInfo>();

            if ( currKey != openPar )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongStartSymbol.FunctionParameterList, openPar );
                SkipTo( endKeys.UniteWith( openPar ) );
                }
            if ( currKey == openPar )
                {
                GetNextKey();

                //Счетчик параметров
                IEnumerator<IExprType> paramEnumerator = null;
                if ( type != null )
                    {
                    paramEnumerator = type.GetEnumerator();
                    paramEnumerator.MoveNext();
                    }

                //Если это не пустой список параметров
                if ( currKey != closePar )
                    {
                    ExprInfo exprInfo = Expression.Parse( endKeys.UniteWith( closePar, Key.Comma ) );

                    //Проверка параметра
                    CheckParameterType( paramEnumerator, exprInfo.Type );

                    //Указываем параметры конструктору
                    paramExprList.Add( exprInfo );

                    while ( currKey == Key.Comma )
                        {
                        GetNextKey();

                        exprInfo = Expression.Parse( endKeys.UniteWith( closePar, Key.Comma ) );

                        if ( type != null )
                            //Проверка параметра
                            CheckParameterType( paramEnumerator, exprInfo.Type );

                        //Указываем параметры конструктору
                        paramExprList.Add( exprInfo );
                        }
                    }

                //Если были указаны не все параметры
                if ( type != null )
                    if ( paramEnumerator.Current != null )
                        {
                        Fabric.Instance.ErrReg.Register( Err.Parser.Usage.ParameterList.NotEnoughParameters );
                        }

                Accept( closePar );

                if ( !endKeys.Contains( currKey ) )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.FunctionParameterList, endKeys.GetLastKeys() );
                    SkipTo( endKeys );
                    }
                }

            return paramExprList;
            }


        /// <summary>
        /// Проверить параметр
        /// </summary>
        /// <param name="paramEnumerator">Счетчик типов параметров</param>
        /// <param name="varType">Фактический тип</param>
        public static void CheckParameterType( IEnumerator<IExprType> paramEnumerator, IExprType varType )
            {
            if ( paramEnumerator.Current != null )
                {
                Assignement.CheckVarTypes( paramEnumerator.Current, varType );

                paramEnumerator.MoveNext();
                }
            //Столько индексов объявлено не было
            else
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.Usage.ParameterList.TooManyParameters );
                }
            }
        }
    }
