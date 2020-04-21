using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Инициализатор массивов
    /// </summary>
    public static class ArrayInitializer
        {
        /// <summary>
        /// Проинициализировать
        /// </summary>
        /// <param name="array">Инициализируемый массив</param>
        /// <param name="objectToClone">Объект, копиями которого производится инициализация</param>
        public static void Initialize( object array, ICreatable objectToClone )
            {
            if ( array is Array )
                {
                Array objectArray = array as Array;

                if ( objectArray.Length == 0 )
                    return;

                //Текущий индекс
                List<int> currIndex = new List<int>();
                List<int> minIndex = new List<int>();
                //Вехний индекс
                List<int> maxIndex = new List<int>();

                for ( int index = 0 ; index < objectArray.Rank ; index++ )
                    {
                    currIndex.Add( 0 );
                    minIndex.Add( 0 );
                    maxIndex.Add( objectArray.GetUpperBound( index ) );
                    }

                do
                    {
                    objectArray.SetValue( objectToClone.CreateNew(), currIndex.ToArray() );
                    }
                while ( CoreNameRange.IncrementIndex( currIndex, 0, minIndex, maxIndex ) );
                }
            }

        }
    }
