using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Специальный словарь
    /// </summary>
    /// <typeparam name="TKey">Ключ</typeparam>
    /// <typeparam name="TValue">Значение</typeparam>
    [Serializable]
    public class CoreNameDictionary<TKey, TValue> : Dictionary<TKey, TValue>
        where TValue : class
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public CoreNameDictionary()
            {
            }



        /// <summary>
        /// Получить значение по индексу
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>Искомое значение</returns>
        public TValue this[ int index ]
            {
            get
                {
                if ( index < 0 || index >= this.Count )
                    throw new ArgumentOutOfRangeException( "index" );

                int indexCurr = 0;
                TValue resultItem = null;

                foreach ( TValue currItem in this.Values )
                    {
                    if ( indexCurr == index )
                        {
                        resultItem = currItem;
                        break;
                        }
                    indexCurr++;
                    }

                return resultItem;
                }
            }
        }
    }
