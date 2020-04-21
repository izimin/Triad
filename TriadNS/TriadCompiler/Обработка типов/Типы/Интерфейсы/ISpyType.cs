using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Интерфейс типа spy-объекта
    /// </summary>
    public interface ISpyType : ICommonType
        {
        /// <summary>
        /// Признак spy-объекта
        /// </summary>
        bool IsSpyObject
            {
            get;
            set;
            }
        }
    }
