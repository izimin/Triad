using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Множество
    /// </summary>
    public class Set
        {
        /// <summary>
        /// Список элементов множества
        /// </summary>
        private Dictionary<object, object> valueList = new Dictionary<object, object>();


        /// <summary>
        /// Конструктор
        /// </summary>
        public Set()
            {
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="anotherSet">Инициирующее мн-во</param>
        private Set( Set anotherSet )
            {
            if ( anotherSet != null )
                foreach ( object value in anotherSet )
                    this.AddValue( value );
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="valueList">Элементы множества</param>
        public Set( params object[] valueList )
            {
            if ( valueList != null )
                foreach ( object value in valueList )
                    this.AddValue( value );
            }


        /// <summary>
        /// Получить перечислитель всех элементов множества
        /// </summary>
        /// <returns></returns>
        public IEnumerator<object> GetEnumerator()
            {
            return this.valueList.Values.GetEnumerator();
            }


        /// <summary>
        /// Проверить, есть ли указанный элемент в текущем множестве
        /// </summary>
        /// <param name="value">Указанный элемент</param>
        /// <returns>True, если элемент есть в множестве</returns>
        public bool In( object value )
            {
            if ( value != null )
                return this.valueList.ContainsKey( value );
            else
                return true;
            }



        /// <summary>
        /// Добавить элемент в множество
        /// </summary>
        /// <param name="value">Элемент</param>
        /// <returns>Изменившееся множество</returns>
        public void AddValue( object value )
            {
            if ( value == null )
                return;

            if ( !this.valueList.ContainsKey( value ) )
                {
                this.valueList.Add( value, value );
                }

            return;
            }


        /// <summary>
        /// Объединить текущее множество с переданным
        /// </summary>
        /// <param name="anotherSet">Переданное множество</param>
        /// <returns>Объединенное множество</returns>
        public Set Unite( Set anotherSet )
            {
            Set resultSet = new Set();

            if ( anotherSet == null )
                return resultSet;

            foreach ( object value in this )
                resultSet.AddValue( value );

            foreach ( object value in anotherSet )
                resultSet.AddValue( value );

            return resultSet;            
            }


        /// <summary>
        /// Удалить элемент из множества
        /// </summary>
        /// <param name="value">Удаляемый элемент</param>
        public void RemoveValue( object value )
            {
            if ( value == null )
                return;

            if ( this.valueList.ContainsKey( value ) )
                this.valueList.Remove( value );
            }


        /// <summary>
        /// Вычесть из текущего множества указанное
        /// </summary>
        /// <param name="anotherSet">Множество, которое вычитается</param>
        /// <returns>Итоговое множество</returns>
        public Set Subtract( Set anotherSet )
            {
            Set resultSet = new Set( this );

            if ( anotherSet == null )
                return resultSet;

            foreach ( object value in anotherSet )
                resultSet.RemoveValue( value );

            return resultSet;
            }


        /// <summary>
        /// Пересечь текущее множество с указанным
        /// </summary>
        /// <param name="anotherSet">Указанное множество</param>
        /// <returns>Итоговое множество</returns>
        public Set Intersect( Set anotherSet )
            {
            Set resultSet = new Set();

            if ( anotherSet == null )
                return resultSet;

            foreach ( object value in this )
                if ( anotherSet.In( value ) )
                    resultSet.AddValue( value );

            foreach ( object value in anotherSet )
                if ( this.In( value ) )
                    resultSet.AddValue( value );

            return resultSet;
            }


        /// <summary>
        /// Размер множества
        /// </summary>
        /// <returns>Число элементов множества</returns>
        public int Size
            {
            get
                {
                return this.valueList.Count;
                }
            }


        /// <summary>
        /// Проверить, совпадают ли текущее и указанное множества
        /// </summary>
        /// <param name="anotherSet">Указанное множество</param>
        /// <returns>True, если множества совпадают</returns>
        public bool Equal( Set anotherSet )
            {
            if ( anotherSet == null )
                return false;

            if ( this.Size != anotherSet.Size )
                return false;

            foreach ( object value in this )
                if ( !anotherSet.In( value ) )
                    return false;

            return true;
            }


        /// <summary>
        /// Проверить, что текущее множество НЕ совпадает с указанным
        /// </summary>
        /// <param name="anotherSet">Указанное множество</param>
        /// <returns>True, если множества НЕ совпадают</returns>
        public bool NotEqual( Set anotherSet )
            {
            return !Equal( anotherSet );
            }


        /// <summary>
        /// Проверить, что текущее множество является подмножеством указанного
        /// </summary>
        /// <param name="anotherSet">Указанное множество</param>
        /// <returns>True, если текущее множество является подмножеством указанного</returns>
        public bool IsSubsetOf( Set anotherSet )
            {
            if ( anotherSet == null )
                return false;

            foreach ( object value in this )
                if ( !anotherSet.In( value ) )
                    return false;

            return true;
            }


        /// <summary>
        /// Проверить, что текущее множество является надмножеством указанного
        /// </summary>
        /// <param name="anotherSet">Указанное множество</param>
        /// <returns>True, если текущее множество является надмножеством указанного</returns>
        public bool IsSupersetOf( Set anotherSet )
            {
            if ( anotherSet == null )
                return true;

            foreach ( object value in anotherSet )
                if ( !this.In( value ) )
                    return false;

            return true;
            }


        /// <summary>
        /// Операция объединения множеств
        /// </summary>
        /// <param name="set1"></param>
        /// <param name="set2"></param>
        /// <returns></returns>
        public static Set operator +( Set set1, Set set2 )
            {
            if ( set1 == null )
                return set2;

            return set1.Unite( set2 );
            }



        /// <summary>
        /// Операция вычитания множеств
        /// </summary>
        /// <param name="set1"></param>
        /// <param name="set2"></param>
        /// <returns></returns>
        public static Set operator -( Set set1, Set set2 )
            {
            if ( set1 == null )
                return null;

            return set1.Subtract( set2 );
            }


        /// <summary>
        /// Операция пересечения множеств
        /// </summary>
        /// <param name="set1"></param>
        /// <param name="set2"></param>
        /// <returns></returns>
        public static Set operator *( Set set1, Set set2 )
            {
            if ( set1 == null )
                return null;

            return set1.Intersect( set2 );
            }


        /// <summary>
        /// Проверка, что первое множество является надмножеством второго
        /// </summary>
        /// <param name="set1"></param>
        /// <param name="set2"></param>
        /// <returns></returns>
        public static bool operator >=( Set set1, Set set2 )
            {
            if ( set1 == null )
                return false;

            return set1.IsSupersetOf( set2 );
            }


        /// <summary>
        /// Проверка, что первое множество является подмножеством второго
        /// </summary>
        /// <param name="set1"></param>
        /// <param name="set2"></param>
        /// <returns></returns>
        public static bool operator <=( Set set1, Set set2 )
            {
            if ( set1 == null )
                return true;

            return set1.IsSubsetOf( set2 );
            }

        }
    }
