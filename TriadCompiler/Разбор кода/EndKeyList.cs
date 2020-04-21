using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Множество допустимых конечных символов
    /// </summary>
    public class EndKeyList
        {
        /// <summary>
        /// Проверка, содержится ли указанный символ в множестве
        /// </summary>
        /// <param name="key">Указанный символ</param>
        /// <returns>True, если содержится</returns>
        public bool Contains( Key key )
            {
            foreach ( List<Key> keyList in this.allowedKeys )
                if ( keyList.Contains( key ) )
                    return true;
            return false;
            }


        /// <summary>
        /// Объединение текущего и переданных множеств символов
        /// </summary>
        /// <param name="keyList">Множества символов</param>
        /// <returns>Итоговое множество</returns>
        public EndKeyList UniteWith( List<Key> keyList )
            {
            EndKeyList newKeyList = this.Clone();
            newKeyList.allowedKeys.Add( keyList );
            return newKeyList;
            }


        /// <summary>
        /// Объединение множества символов с отдельными символами
        /// </summary>
        /// <param name="keys">Отдельные символы</param>
        /// <returns>Итоговое множество</returns>
        public EndKeyList UniteWith( params Key[] keys )
            {
            EndKeyList newKeyList = this.Clone();
            List<Key> newKeys = new List<Key>();

            foreach ( Key key in keys )
                //Чтобы символы не повторялись
                if ( !this.Contains( key ) )
                    {
                    newKeys.Add( key );
                    }

            //Если есть, что добавлять
            if ( newKeys.Count > 0 )
                newKeyList.allowedKeys.Add( newKeys );
            
            return newKeyList;
            }


        /// <summary>
        /// Получить список последний раз добавленных символов
        /// </summary>
        /// <returns>Список символов</returns>
        public List<Key> GetLastKeys()
            {
            if ( this.allowedKeys.Count > 0 )
                return this.allowedKeys[ this.allowedKeys.Count - 1 ];
            else
                return null;
            }


        /// <summary>
        /// Копировать множество символов
        /// </summary>
        /// <returns>Новое множество</returns>
        public EndKeyList Clone()
            {
            EndKeyList newKeyList = new EndKeyList();
            foreach ( List<Key> keyList in this.allowedKeys )
                {
                List<Key> keys = new List<Key>();
                foreach ( Key key in keyList )
                    keys.Add( key );
                newKeyList.allowedKeys.Add( keys );
                }
            return newKeyList;
            }


        /// <summary>
        /// Список допустимых значений
        /// </summary>
        private List<List<Key>> allowedKeys = new List<List<Key>>();
        }
    }
