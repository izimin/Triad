using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Объект слежения
    /// </summary>
    public class SpyObject
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="realName">Имя переменной, полюса или события в объекте</param>
        /// <param name="objectContainer">Объект-контейнер</param>
        public SpyObject( CoreName realName, ReflectionObject objectContainer )
            {
            this.realName = realName;
            this.objectContainer = objectContainer;
            }


        /// <summary>
        /// Функция сравнения
        /// </summary>
        /// <param name="other">Сравниваемый объект слежения</param>
        /// <returns></returns>
        public virtual bool Equals( SpyObject other )
            {
            return this.realName.Equals( other.realName );
            }


        /// <summary>
        /// Функция сравнения
        /// </summary>
        /// <param name="otherArray">Массив объектов</param>
        /// <returns>True, если совпадет хотя бы с одним элементом массива</returns>
        public bool Equals( SpyObject[] otherArray )
            {
            foreach ( SpyObject other in otherArray )
                if ( other.Equals( this ) )
                    return true;
            return false;
            }


        /// <summary>
        /// Строковое представление
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            {
            return this.RealName.ToString();
            }


        /// <summary>
        /// Настоящее имя объекта
        /// </summary>
        public CoreName RealName
            {
            get { return realName; }
            set {this.realName = value; }
            }


        /// <summary>
        /// Дополнительная информация
        /// </summary>
        public string Data
            {
            get { return data; }
            set { data = value; }
            }


        /// <summary>
        /// Объект-контейнер
        /// </summary>
        public ReflectionObject Container
            {
            get { return objectContainer; }
            }



        /// <summary>
        /// Создать копию
        /// </summary>
        /// <returns></returns>
        public virtual SpyObject Clone()
            {
            return new SpyObject( this.RealName, this.Container );
            }


        /// <summary>
        /// Объект-контейнер
        /// </summary>
        private ReflectionObject objectContainer = null;
        /// <summary>
        /// Имя объекта
        /// </summary>
        private CoreName realName = new CoreName( string.Empty );
        /// <summary>
        /// Дополнительная информация (например, пришедшее сообщение у полюса)
        /// </summary>
        private string data = string.Empty;
        }

    }
