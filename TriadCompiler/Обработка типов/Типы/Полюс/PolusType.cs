using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {     
    /// <summary>
    /// Тип стандартных полюсов.
    /// </summary>
    public class PolusType : IPolusType
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="isInput">Признак того, что тип полюса Input</param>
        /// <param name="isOutput">Признак того, что тип полюса Output</param>
        public PolusType( bool isInput, bool isOutput )
            {
            this.isInput = isInput;
            this.isOutput = isOutput;
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="isInput">Признак того, что тип полюса Input</param>
        /// <param name="isOutput">Признак того, что тип полюса Output</param>
        /// <param name="isSpyObject">Признак spy-объекта</param>
        public PolusType( bool isInput, bool isOutput, bool isSpyObject )
            : this( isInput, isOutput )
            {
            this.isSpyObject = isSpyObject;
            }


        /// <summary>
        /// Проверка того, что тип полюса - Input
        /// </summary>
        public bool IsInput
            {
            get
                {
                return isInput;
                }
            }


        /// <summary>
        /// Проверка того, что тип полюса - Output
        /// </summary>
        public bool IsOutput
            {
            get
                {
                return isOutput;
                }
            }


        /// <summary>
        /// Имя полюса
        /// </summary>
        public string Name
            {
            get
                {
                return this.polusName;
                }
            set
                {
                this.polusName = value;
                }
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
        /// Имя полюса
        /// </summary>
        private string polusName = string.Empty;
        /// <summary>
        /// Признак входного полюса
        /// </summary>
        private bool isInput = true;
        /// <summary>
        /// Признак выходного полюса
        /// </summary>
        private bool isOutput = true;
        /// <summary>
        /// Признак spy-объекта
        /// </summary>
        private bool isSpyObject = false;
        };    
    }
