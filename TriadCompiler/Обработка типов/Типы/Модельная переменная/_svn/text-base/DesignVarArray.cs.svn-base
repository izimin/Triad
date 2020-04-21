using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Тип идексированной design переменной
    /// </summary>
    internal class DesignVarArrayType : IndexedType, IDesignVarType
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="varName">Имя переменной</param>
        /// <param name="typeCode">Тип design переменной</param>
        public DesignVarArrayType( string varName, DesignTypeCode typeCode )
            {
            this.varName = varName;
            this.typeCode = typeCode;
            }


        /// <summary>
        /// Имя графа
        /// </summary>
        public string Name
            {
            get
                {
                return this.varName;
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
