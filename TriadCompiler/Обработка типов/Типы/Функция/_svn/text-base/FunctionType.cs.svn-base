using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Тип функции
    /// </summary>
    internal class FunctionType : ParameterList<IExprType>, ICommonType
        {
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
        /// Имя функции в сгенерированном коде
        /// </summary>
        public string MethodCodeName
            {
            get
                {
                return this.strCode;
                }
            set
                {
                this.strCode = value;
                }
            }


        /// <summary>
        /// Тип, возращаемый функцией
        /// </summary>
        public IExprType ReturnedType
            {
            get
                {
                return this.returnedType;
                }
            set
                {
                this.returnedType = value;
                }
            }


        /// <summary>
        /// Имя типа
        /// </summary>
        private string typeName = string.Empty;
        /// <summary>
        /// Имя функции в сгенерированном коде
        /// </summary>
        private string strCode = string.Empty;
        /// <summary>
        /// Тип, возращаемый функцией
        /// </summary>
        private IExprType returnedType = null;
        }    
    }
