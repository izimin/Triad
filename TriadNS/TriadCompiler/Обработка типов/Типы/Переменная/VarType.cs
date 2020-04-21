using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Тип стандартных переменных.
    /// </summary>
    [Serializable] // by jum УБРАТЬ! временно т.к. не сохранялись ИП + public
    public class VarType : IExprType
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="code">Код типа</param>
        public VarType( TypeCode code )
            {
            this.code = code;
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="code">Код типа</param>
        /// <param name="varName">Имя переменной</param>
        public VarType( TypeCode code, string varName )
            {
            this.code = code;
            this.varName = varName;
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="code">Код типа</param>
        /// <param name="varName">Имя переменной</param>
        /// <param name="isSpyObject">Признак spy-объекта</param>
        public VarType( TypeCode code, string varName, bool isSpyObject )
            : this( code, varName )
            {
            this.isSpyObject = isSpyObject;
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
            return new VarType( this.code, this.varName );
            }



        /// <summary>
        /// Имя переменной
        /// </summary>
        private string varName;
        /// <summary>
        /// Код типа переменной
        /// </summary>
        private TypeCode code;
        /// <summary>
        /// Признак spy-объекта
        /// </summary>
        private bool isSpyObject = false;
        };   

    }
