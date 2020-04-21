using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Параметризованный тип
    /// </summary>
    /// <typeparam name="ItemType">Тип элемента</typeparam>
    public class ParameterList<ItemType>
        {
        /// <summary>
        /// Добавить параметр
        /// </summary>
        /// <param name="paramType">Тип параметра</param>
        public void AddParameter( ItemType paramType )
            {
            this.paramList.Add( paramType );
            }


        /// <summary>
        /// Добавить список параметров
        /// </summary>
        /// <param name="paramTypeList">Список типов параметров</param>
        public void AddParameterList( List<ItemType> paramTypeList )
            {
            this.paramList.AddRange( paramTypeList );
            }


        /// <summary>
        /// Получить счетчик параметров
        /// </summary>
        /// <returns></returns>
        public IEnumerator<ItemType> GetEnumerator()
            {
            return this.paramList.GetEnumerator();
            }


        /// <summary>
        /// Число параметров
        /// </summary>
        public int ParameterCount
            {
            get
                {
                return this.paramList.Count;
                }
            }

        //by jum
        public List<ItemType> ToList()
        {
            return paramList;
        }

        /// <summary>
        /// Список параметров
        /// </summary>
        private List<ItemType> paramList = new List<ItemType>();
        }
    }
