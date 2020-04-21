using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Диапазон имен сущностей ядра
    /// </summary>
    public class CoreNameRange
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="arrayName">Имя массива имен</param>
        /// <param name="firstLastIndexList">Нижние и верхние границы индексов</param>
        public CoreNameRange( string arrayName, params int[] firstLastIndexList )
            {
            if ( ( firstLastIndexList.Length % 2 ) != 0 )
                throw new ArgumentException( "Не хватает последнего верхнего индекса" );

            List<int> lowIndexList = new List<int>();
            List<int> highIndexList = new List<int>();

            for ( int paramIndex = 0 ; paramIndex < firstLastIndexList.Length ; paramIndex += 2 )
                {
                int lowIndex = firstLastIndexList[ paramIndex ];
                int highIndex = firstLastIndexList[ paramIndex + 1 ];

                if ( lowIndex < 0 )
                    throw new ArgumentOutOfRangeException( "Нижний индекс диапазона " +
                        arrayName + " не может быть меньше нуля" );
                if ( lowIndex > highIndex )
                    throw new ArgumentOutOfRangeException( "Нижний индекс диапазона " +
                        arrayName + " не может быть больше верхнего" );

                lowIndexList.Add( lowIndex );
                highIndexList.Add( highIndex );
                }

            List<int> currIndex = new List<int>( lowIndexList );

            do
                {
                this.coreNameList.Add( new CoreName( arrayName, currIndex.ToArray() ) );
                }
            while ( IncrementIndex( currIndex, 0, lowIndexList, highIndexList ) );
            }


        /// <summary>
        /// Увеличить текущий индекс
        /// </summary>
        /// <param name="currIndex">Текущий индекс</param>
        /// <param name="currIndexNumber">Номер изменяемого индекса</param>
        /// <param name="lowIndex">Нижний индекс</param>
        /// <param name="highIndex">Верхний индекс</param>
        /// <returns>True, если индекс успешно изменен</returns>
        public static bool IncrementIndex( List<int> currIndex, int currIndexNumber, List<int> lowIndex, List<int> highIndex )
            {
            if ( currIndexNumber >= currIndex.Count )
                return false;

            if ( currIndex[ currIndexNumber ] < highIndex[ currIndexNumber ] )
                {
                currIndex[ currIndexNumber ]++;
                return true;
                }
            else
                {
                currIndex[ currIndexNumber ] = lowIndex[ currIndexNumber ];
                return IncrementIndex( currIndex, currIndexNumber + 1, lowIndex, highIndex );
                }
            }


        /// <summary>
        /// Получить перечислитель имен из диапазона
        /// </summary>
        /// <returns></returns>
        public IEnumerator<CoreName> GetEnumerator()
            {
            return this.coreNameList.GetEnumerator();
            }


        /// <summary>
        /// Число имен в диапазоне
        /// </summary>
        public int ItemCount
            {
            get
                {
                return this.coreNameList.Count;
                }
            }


        /// <summary>
        /// Получение имени диапазона по индексу
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>Имя</returns>
        public CoreName this[ int index ]
            {
            get
                {
                if ( index < 0 || index >= this.coreNameList.Count )
                    throw new ArgumentOutOfRangeException( "Индекс вышел за пределы диапазона" );

                return this.coreNameList[ index ];
                }
            }


        /// <summary>
        /// Имена сущностей попадающих в диапазон
        /// </summary>
        private List<CoreName> coreNameList = new List<CoreName>();
        }
    }
