using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Имя для идентификации сущностей ядра
    /// </summary>
    public class CoreName : IComparable
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param polusName="BaseName">Имя массива</param>
        /// <param polusName="Index">Индекс в массиве</param>
        public CoreName( string baseName, params int[] indexList )
            {
            if ( baseName == null )
                throw new ArgumentNullException( "Пустое базовое имя" );

            this.baseName = baseName;
            this.indexList = new List<int>( indexList );
            }


        /// <summary>
        /// Проверка на идексированное имя
        /// </summary>
        public bool IsIndexed
            {
            get
                {
                return ( this.indexList.Count != 0 );
                }
            }


        /// <summary>
        /// Базовое имя
        /// </summary>
        public string BaseName
            {
            get
                {
                return baseName;
                }
            }


        /// <summary>
        /// Индексы
        /// </summary>
        public ReadOnlyCollection<int> Indices
            {
            get
                {
                return this.indexList.AsReadOnly();
                }
            }


        /// <summary>
        /// Массив индексов
        /// </summary>
        public int[] IndexArray
            {
            get
                {
                return indexList.ToArray();
                }
            }


        /// <summary>
        /// Символьное представление имени
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            {
            StringBuilder result = new StringBuilder( BaseName );
            if ( indexList.Count != 0 )
                {
                result.Append( "[" );

                for ( int index = 0 ; index < this.indexList.Count ; index++ )
                    {
                    result.Append( indexList[ index ].ToString() );
                    if ( index != this.indexList.Count - 1 )
                        result.Append( "," );
                    }
                result.Append( "]" );
                }

            return result.ToString();
            }


        /// <summary>
        /// Сравнение имен
        /// </summary>
        /// <param name="obj">Другое имя</param>
        /// <returns></returns>
        public override bool Equals( object obj )
            {
            if ( obj == null )
                throw new ArgumentNullException( "Передан пустой объект" );

            CoreName otherName = obj as CoreName;

            //Если передано было не имя
            if ( otherName == null )
                return false;

            //Если базовые имена не совпадают
            if ( this.baseName != otherName.baseName )
                return false;
            else
                {
                //Если размерности не совпадают
                if ( this.indexList.Count != otherName.indexList.Count )
                    return false;

                //Проверяем совпадение всех индексов
                for ( int index = 0; index < this.indexList.Count; index++ )
                    if ( this.indexList[ index ] != otherName.indexList[ index ] )
                        return false;

                return true;
                }
            }


        /// <summary>
        /// Сравнение с диапазоном имен
        /// </summary>
        /// <param name="coreNameRange">Диапазон имен</param>
        /// <returns></returns>
        public bool Equals( CoreNameRange coreNameRange )
            {
            if ( coreNameRange == null )
                throw new ArgumentNullException( "coreNameRange" );

            IEnumerator<CoreName> enumerator = coreNameRange.GetEnumerator();
            while ( enumerator.MoveNext() )
                if ( this.Equals( enumerator.Current ) )
                    {
                    return true;
                    }
            return false;
            }



        /// <summary>
        /// Операция сравнения
        /// Эта функция используется при хранении CoreName в SortedList
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo( object obj )
            {
            CoreName otherName = obj as CoreName;

            if ( otherName != null )
                {
                if ( this.baseName != otherName.baseName )
                    return this.baseName.CompareTo( otherName.baseName );
                else
                    {
                    for ( int index = 0 ; index < this.indexList.Count && index < otherName.indexList.Count ; index++ )
                        if ( this.indexList[ index ] != otherName.indexList[ index ] )
                            return this.indexList[ index ].CompareTo( otherName.indexList[ index ] );

                    return this.indexList.Count.CompareTo( otherName.indexList.Count );
                    }
                }
            else
                return -1;
            }


        /// <summary>
        /// Хеш
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
            {
            int hashNameCode = this.baseName.GetHashCode();

            int indexHashCode = 0;
            foreach ( int index in this.indexList )
                indexHashCode ^= index.GetHashCode();

            return hashNameCode ^ indexHashCode;
            }


        /// <summary>
        /// Базовое имя
        /// </summary>
        private string baseName = string.Empty;
        /// <summary>
        /// Индексы
        /// </summary>
        private List<int> indexList = new List<int>();
        }
    }
