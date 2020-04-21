using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Интерфейс, который реализуют типы полюсов
    /// </summary>
    public interface IPolusType : ISpyType
        {
        bool IsInput
            {
            get;
            }

        bool IsOutput
            {
            get;
            }
        }
    }
