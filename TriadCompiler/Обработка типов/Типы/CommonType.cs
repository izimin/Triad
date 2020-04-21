using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Любой тип
    /// </summary>
    public interface ICommonType
        {
        /// <summary>
        /// Имя переменной
        /// </summary>
        string Name
            {
            get;
            set;
            }


        
        }

    /// <summary>
    /// Интерфейс индексированного типа
    /// </summary>
    public interface IIndexedType
    {
        void SetNewIndex(int indexMaxValue);

        int IndexCount
        {
            get;
        }

        bool IsValidIndex(int indexValue, int indexNumber);

        int GetUpperBound(int indexNumber);
    }

    /// <summary>
    /// Обобщенный индексированный тип
    /// </summary>
    internal class IndexedType : IIndexedType
        {
        /// <summary>
        /// Задать новый индекс
        /// </summary>
        /// <param name="indexMaxValue">Верхняя граница изменения индекса</param>
        /// <exception cref="ArgumentException">Левая граница индекса больше, чем правая
        /// </exception>
        public void SetNewIndex( int indexMaxValue )
            {
            if ( indexMaxValue < 0 )
                throw new ArgumentException( "Верхняя граница изменения индекса должна быть неотрицательна" );

            arrIndexMaxSizeList.Add( indexMaxValue );
            }


        /// <summary>
        /// Получить размерность массива
        /// </summary>
        public int IndexCount
            {
            get
                {
                return arrIndexMaxSizeList.Count;
                }
            }


        /// <summary>
        /// Проверка принадлежности значения индекса его объевленному диапазону
        /// </summary>
        /// <param name="indexValue">Значение индекса</param>
        /// <param name="indexNumber">Порядковый номер индекса</param>
        /// <returns>true, если значение индекса попадает в границы</returns>
        public bool IsValidIndex( int indexValue, int indexNumber )
            {
            if ( indexNumber > arrIndexMaxSizeList.Count - 1 )
                return false;
            else if ( indexNumber < 0 )
                return false;

            return ( 0 <= indexValue ) && ( indexValue < arrIndexMaxSizeList[ indexNumber ] );
            }

        /// <summary>
        /// Получить верхнюю границу индекса
        /// </summary>
        /// <param name="indexNumber">Порядковый номер индекса</param>
        /// <returns>верхняя граница</returns>
        public int GetUpperBound(int indexNumber)
        {
            if (indexNumber < 0 || indexNumber > arrIndexMaxSizeList.Count)
                throw new ArgumentOutOfRangeException();

            return arrIndexMaxSizeList[indexNumber];
        }

        /// <summary>
        /// Получить счетчик по верхним границам индексов
        /// </summary>
        /// <returns></returns>
        public IEnumerator<int> GetEnumerator()
            {
            return this.arrIndexMaxSizeList.GetEnumerator();
            }


        //Верхние границы индексов массива
        protected List<int> arrIndexMaxSizeList = new List<int>();
        }
    }
