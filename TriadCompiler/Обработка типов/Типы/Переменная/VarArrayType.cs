using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Тип массивов.
    /// </summary>
    internal class VarArrayType : IndexedType, IExprType
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="typeCode">Код базового типа</param>
        public VarArrayType( TypeCode typeCode )
            {
            this.Code = typeCode;
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="typeCode">Код базового типа</param>
        /// <param name="varName">Имя переменной</param>
        public VarArrayType( TypeCode typeCode, string varName )
            {
            this.code = typeCode;
            this.varName = varName;
            }


        /// <summary>
        /// Код типа переменной
        /// </summary>
        public TypeCode Code
            {
            get
                {
                return code;
                }
            set
                {
                code = value;
                }
            }


        /// <summary>
        /// Имя переменной переменной
        /// </summary>
        public string Name
            {
            get { return varName; }
            set { varName = value; }
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
        /// Создать копию
        /// </summary>
        /// <returns></returns>
        public IExprType Clone()
            {
            VarArrayType cloneType = new VarArrayType( this.code, this.varName );
            foreach ( int indexLimit in this )
                cloneType.arrIndexMaxSizeList.Add( indexLimit );
            return cloneType;
            }


        /// <summary>
        /// Имя массива
        /// </summary>
        private string varName;
        /// <summary>
        /// Признак spy-объекта
        /// </summary>
        private bool isSpyObject = false;
        /// <summary>
        /// Код базового типа массива
        /// </summary>
        private TypeCode code;
        }
    }
