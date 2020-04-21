using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Тип, описывающий информационную процедуру
    /// </summary>
    public class IProcedureType : ParameterList<ISpyType>, ICommonType
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="typeName">Имя типа</param>
        public IProcedureType( string typeName )
            {
            this.Name = typeName;
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="typeName">Имя типа</param>
        /// <param name="returnedType">Возращаемое значение</param>
        public IProcedureType( string typeName, TypeCode returnedType )
            {
            this.Name = typeName;
            this.returnedType = returnedType;
            }


        /// <summary>
        /// Код типа результата
        /// Это свойство переопределяется в IConditionType
        /// </summary>
        public virtual TypeCode ReturnCode
            {
            get
                {
                return returnedType;
                }
            set
                {
                this.returnedType = value;
                }
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

        //By jum
        /// <summary>
        /// Описание
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        /// <summary>
        /// Код типа результата
        /// </summary>
        private TypeCode returnedType = TypeCode.Void;
        /// <summary>
        /// Имя ИП
        /// </summary>
        private string typeName = string.Empty;
        /// <summary>
        /// Имя ИП в коде
        /// </summary>
        private string description = string.Empty;
        /// <summary>
        /// Список out-переменных
        /// </summary>
        public ParameterList<IExprType> OutVarList = new ParameterList<IExprType>();
        /// <summary>
        /// Список параметров ИП
        /// </summary>
        public ParameterList<IExprType> ParamVarList = new ParameterList<IExprType>(); 
        }
    }
