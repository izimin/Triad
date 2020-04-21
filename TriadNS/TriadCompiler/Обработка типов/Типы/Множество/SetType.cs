using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Тип множества
    /// </summary>
    class SetType : IExprType
        {
        /// <summary>
        /// Имя множества
        /// </summary>
        private string setName;
        /// <summary>
        /// Код типа элементов множества
        /// </summary>
        private TypeCode code;
        /// <summary>
        /// Признак spy-объекта
        /// </summary>
        private bool isSpyObject = false;


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="code">Код типа элементов множества</param>
        public SetType( TypeCode code )
            {
            this.code = code;
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="code">Код типа элементов множества</param>
        /// <param name="setName">Имя множества</param>
        public SetType( TypeCode code, string setName )
            {
            this.code = code;
            this.setName = setName;
            }


        /// <summary>
        /// Код типа переменной
        /// </summary>
        public TypeCode Code
            {
            get { return code; }
            set { code = value; }
            }


        /// <summary>
        /// Имя переменной переменной
        /// </summary>
        public string Name
            {
            get { return setName; }
            set { setName = value; }
            }


        /// <summary>
        /// Признак spy-объекта
        /// </summary>
        public bool IsSpyObject
            {
            get { return isSpyObject; }
            set { isSpyObject = value; }
            }


        /// <summary>
        /// Продублировать тип
        /// </summary>
        /// <returns>Дубль</returns>
        public IExprType Clone()
            {
            return new SetType( this.code );
            }
        }
    }
