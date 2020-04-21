using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Уникальное имя полюса
    /// </summary>
    public class UniquePolusName
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="polusName">Имя полюса</param>
        /// <param name="nodeName">Имя вершины</param>
        public UniquePolusName( CoreName polusName, CoreName nodeName )
            {
            this.nodeName = nodeName;
            this.polusName = polusName;
            }


        /// <summary>
        /// Имя полюса
        /// </summary>
        public CoreName PolusName
            {
            get
                {
                return this.polusName;
                }
            }


        /// <summary>
        /// Имя вершины
        /// </summary>
        public CoreName NodeName
            {
            get
                {
                return this.nodeName;
                }
            }


        /// <summary>
        /// Функция сравнения
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals( object obj )
            {
            UniquePolusName name = obj as UniquePolusName;
            if ( name == null )
                return false;
            else
                return polusName.Equals( name.polusName ) && nodeName.Equals( name.nodeName );
            }


        /// <summary>
        /// Хеш функция
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
            {
            return polusName.GetHashCode() ^ nodeName.GetHashCode();
            }


        /// <summary>
        /// Строковое имя
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            {
            return nodeName.ToString() + "." + polusName.ToString();
            }


        private CoreName polusName;
        private CoreName nodeName;
        }
    }
