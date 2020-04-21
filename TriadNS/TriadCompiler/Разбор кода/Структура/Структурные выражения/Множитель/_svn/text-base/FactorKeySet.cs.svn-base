using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler.Parser.Structure.StructExpr.Fact
    {
    /// <summary>
    /// Множества символов, связанные со структурным множителем
    /// </summary>
    internal static class FactorKeySet
        {
        /// <summary>
        /// Множество стартовых символов
        /// </summary>
        public static class Start
            {
            /// <summary>
            /// Множество стартовых символов структурного множителя
            /// </summary>
            private static List<Key> structFactorSet = null;


            /// <summary>
            /// Стартовые символы структурного множителя
            /// </summary>
            public static List<Key> Factor
                {
                get
                    {
                    if ( structFactorSet == null )
                        {
                        Key[] keySet = { Key.Node, Key.Identificator, Key.LeftPar, Key.Arc, Key.Edge,
                            Key.DirectCycle, Key.DirectPath, Key.DirectStar, 
                            Key.UndirectCycle, Key.UndirectPath, Key.UndirectStar };

                        structFactorSet = new List<Key>( keySet );
                        }

                    return structFactorSet;
                    }
                }
            }
        }
    }
