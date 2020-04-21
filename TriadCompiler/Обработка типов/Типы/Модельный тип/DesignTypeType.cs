using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Тип типа переменнной
    /// </summary>
    public class DesignTypeType : ParameterList<IExprType>, ICommonType
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="typeName">Имя типа</param>
        /// <param name="typeCode">Код типа</param>
        public DesignTypeType( string typeName, DesignTypeCode typeCode )
            {
            this.Code = typeCode;
            this.Name = typeName;
            }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name
            {
            get
                {
                return typeName;
                }
            set
                {
                typeName = value;
                }
            }


        /// <summary>
        /// Код типа
        /// </summary>
        public DesignTypeCode Code
            {
            get
                {
                return typeCode;
                }
            set
                {
                this.typeCode = value;
                }
            }


        /// <summary>
        /// Имя дизайн-типа
        /// </summary>
        private string typeName = "";
        /// <summary>
        /// Код типа
        /// </summary>
        private DesignTypeCode typeCode = DesignTypeCode.Structure;
        }

    }
