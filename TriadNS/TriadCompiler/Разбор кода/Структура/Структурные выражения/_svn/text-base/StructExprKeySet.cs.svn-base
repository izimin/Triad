using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler.Parser.Structure.StructExpr
    {
    /// <summary>
    /// Множества символов, связанные со структурными выражениями
    /// </summary>
    internal static class StructExprKeySet
        {
        /// <summary>
        /// Множества операций
        /// </summary>
        public class Operation
            {

            /// <summary>
            /// Множество всех операций
            /// </summary>
            private static List<Key> allSet = null;
            /// <summary>
            /// Множество операций сложения
            /// </summary>
            private static List<Key> structAddSet = null;
            /// <summary>
            /// Множество операций умножения
            /// </summary>
            private static List<Key> structMultSet = null;


            /// <summary>
            /// Все операции
            /// </summary>
            public static List<Key> All
                {
                get
                    {
                    if ( allSet == null )
                        {
                        allSet = new List<Key>();

                        allSet.AddRange( Add );
                        allSet.AddRange( Mult );
                        }
                    return allSet;
                    }
                }


            /// <summary>
            /// Множество операций структурного сложения
            /// </summary>
            public static List<Key> Add
                {
                get
                    {
                    if ( structAddSet == null )
                        {
                        Key[] keySet = { Key.Plus, Key.Minus };

                        structAddSet = new List<Key>( keySet );
                        }
                    return structAddSet;
                    }
                }


            /// <summary>
            /// Множество операций структурного умножения
            /// </summary>
            public static List<Key> Mult
                {
                get
                    {
                    if ( structMultSet == null )
                        {
                        Key[] keySet = { Key.Star };

                        structMultSet = new List<Key>( keySet );
                        }
                    return structMultSet;
                    }
                }

            }

        }
    }
