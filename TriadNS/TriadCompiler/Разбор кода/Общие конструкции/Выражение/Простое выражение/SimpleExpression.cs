using System;
using System.Collections.Generic;
using System.Text;

using TriadCompiler.Parser.Common.Expr;
using TriadCompiler.Parser.Common.Expr.Add;

namespace TriadCompiler.Parser.Common.Expr.SimpleExpr
    {
    /// <summary>
    /// Разбор простого выражения в арифметическом выражении
    /// </summary>
    internal partial class SimpleExpression : CommonParser
        {
        /// <summary>
        /// Множество операций сложения
        /// </summary>
        private static List<Key> addSet = null;


        /// <summary>
        /// Множество операций сложения
        /// </summary>
        private static List<Key> AddKeys
            {
            get
                {
                if ( addSet == null )
                    {
                    Key[] keySet = { Key.Plus, Key.Minus, Key.Or };

                    addSet = new List<Key>( keySet );
                    }
                return addSet;
                }
            }


        /// <summary>
        /// Простое выражение
        /// </summary>
        /// <syntax>[-]Addend {ADD_OP Addend}</syntax>
        /// <param name="endKeys">Множество конечных символов</param>
        public static ExprInfo Parse( EndKeyList endKeys )
            {
            bool minusWasUsed = false;
            if ( currKey == Key.Minus )
                {
                GetNextKey();
                minusWasUsed = true;
                }

            ExprInfo info = Addend.Parse( endKeys.UniteWith( AddKeys ) );

            //Проверка использование минуса
            if ( minusWasUsed )
                {
                //Проверка типа
                info.Type = CheckTypeInMinusAddend( info.Type );

                if ( info.HasNoError )
                    info.Value = info.Value.CalculateWith( Key.Minus );

                //Генерация кода
                info.InsertFirst( "-" );
                }

            while ( AddKeys.Contains( currKey ) )
                {
                ExprInfo nextAddendInfo = new ExprInfo();
                Key addendOperation = currKey;
                GetNextKey();

                nextAddendInfo = Addend.Parse( endKeys.UniteWith( AddKeys ) );

                //Генерация кода
                BuildStringCodeForSimpleExpression( info, nextAddendInfo, addendOperation );

                //Проверка типов
                info.Type = CheckTypeInAddend( info.Type, nextAddendInfo.Type, addendOperation );

                if ( info.HasNoError )
                    info.Value = info.Value.CalculateWith( addendOperation, nextAddendInfo.Value );
                }
            return info;
            }
        }
    }
