using System;
using System.Collections.Generic;
using System.Text;

using TriadCompiler.Parser.Common.Expr;
using TriadCompiler.Parser.Common.Expr.Fact;

namespace TriadCompiler.Parser.Common.Expr.Add
    {
    /// <summary>
    /// Разбор слагаемого в арифметическом выражении
    /// </summary>
    internal partial class Addend : CommonParser
        {
        /// <summary>
        /// Множество операций умножения
        /// </summary>
        private static List<Key> multSet = null;


        /// <summary>
        /// Множество операций умножения
        /// </summary>
        private static List<Key> MultKeys
            {
            get
                {
                if ( multSet == null )
                    {
                    Key[] keySet = { Key.Star, Key.Slash, Key.And, Key.ResidueOfDivision };

                    multSet = new List<Key>( keySet );
                    }
                return multSet;
                }
            }


        /// <summary>
        /// Слагаемое
        /// </summary>
        /// <syntax>Factor {MULT_OP Factor}</syntax>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <returns>Информация о слагаемом</returns>
        public static ExprInfo Parse( EndKeyList endKeys )
            {
            ExprInfo info = Factor.Parse( endKeys.UniteWith( MultKeys ) );

            while ( MultKeys.Contains( currKey ) )
                {
                ExprInfo nextFactorInfo = new ExprInfo();
                Key multiplierOperation = currKey;
                GetNextKey();

                nextFactorInfo = Factor.Parse( endKeys.UniteWith( MultKeys ) );

                //Генерация кода
                BuildStringCodeForAddend( info, nextFactorInfo, multiplierOperation );

                //Проверка типов
                info.Type = CheckTypeInFactor( info.Type, nextFactorInfo.Type, multiplierOperation );

                if ( info.HasNoError )
                    info.Value = info.Value.CalculateWith( multiplierOperation, nextFactorInfo.Value );
                }
            return info;
            }
        }
    }
