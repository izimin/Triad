using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Тип обычной design переменной
    /// </summary>
    internal class DesignVarType : IDesignVarType, IExprType // By jum
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="varName">Имя переменной</param>
        /// <param name="typeCode">Тип design переменной</param>
        public DesignVarType( string varName, DesignTypeCode typeCode )
            {
            this.varName = varName;
            this.typeCode = typeCode;
            }

      
        ///
        /// <summary>
        /// Имя
        /// </summary>
        public string Name
            {
            get
                {
                return varName;
                }
            set
                {
                this.varName = value;
                }
            }


        /// <summary>
        /// Тип design переменной
        /// </summary>
        public DesignTypeCode TypeCode
            {
            get
                {
                return this.typeCode;
                }
            }

        //===============By jum=============
        public DesignVarType(DesignTypeCode typeCode)
        {
            this.typeCode = typeCode;
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
        /// Признак spy-объекта
        /// </summary>
        public bool IsSpyObject
        {
            get { return isSpyObject; }
            set { isSpyObject = value; }
        }
        /// <summary>
        /// Код типа элементов множества
        /// </summary>
        private TypeCode code;
        /// <summary>
        /// Признак spy-объекта
        /// </summary>
        private bool isSpyObject = false;


        /// <summary>
        /// Продублировать тип
        /// </summary>
        /// <returns>Дубль</returns>
        public IExprType Clone()
        {
            return new DesignVarType(this.TypeCode);
        }
        //====================================

        /// <summary>
        /// Имя переменной
        /// </summary>
        private string varName = string.Empty;
        /// <summary>
        /// Тип дизайн-переменной
        /// </summary>
        private DesignTypeCode typeCode = DesignTypeCode.Structure;
        }

    }
