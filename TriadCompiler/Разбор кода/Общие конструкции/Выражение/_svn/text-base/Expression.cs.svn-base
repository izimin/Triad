using System;
using System.Collections.Generic;
using System.Text;

using TriadCompiler.Parser.Common.Expr.SimpleExpr;

namespace TriadCompiler.Parser.Common.Expr
    {
    /// <summary>
    /// Разбор арифметических выражений
    /// </summary>
     internal partial class Expression : CommonParser
        {
        /// <summary>
        /// Множество операций сравнения
        /// </summary>
        private static List<Key> relationSet = null;


        /// <summary>
        /// Множество операций отношения
        /// </summary>
        private static List<Key> RelationKeys
            {
            get
                {
                if ( relationSet == null )
                    {
                    Key[] keySet = { Key.Equal, Key.NotEqual, Key.Greater, Key.GreaterEqual, Key.Later, Key.LaterEqual, Key.In };

                    relationSet = new List<Key>( keySet );
                    }
                return relationSet;
                }
            }


        /// <summary>
        /// Выражение
        /// </summary>
        /// <syntax>SimpleExpression [REL_OP SimpleExpression]</syntax>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <returns>Собранная информация</returns>
         public static ExprInfo Parse( EndKeyList endKeys )
            {
            ExprInfo info = new ExprInfo();

            info = SimpleExpression.Parse( endKeys.UniteWith( RelationKeys ) );

            //Если дальше идет операция отношения
            if ( RelationKeys.Contains( currKey ) )
                {
                Key relationOperation = currKey;
                GetNextKey();

                ExprInfo rightSimpleExprInfo = new ExprInfo();
                rightSimpleExprInfo = SimpleExpression.Parse( endKeys );

                //Генерация кода
                BuildStringCodeForExpression( info, relationOperation, rightSimpleExprInfo );

                //Проверка типов
                info.Type = CheckTypeInSimpleExpression( info.Type, rightSimpleExprInfo.Type, relationOperation );

                if ( info.HasNoError )
                    info.Value = info.Value.CalculateWith( relationOperation, rightSimpleExprInfo.Value );
                }

            return info;
            }
        
        }
    }
