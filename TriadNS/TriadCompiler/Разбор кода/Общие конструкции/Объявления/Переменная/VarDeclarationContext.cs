using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Контекст разбора параметров
    /// </summary>
    internal enum VarDeclarationContext
        {
        /// <summary>
        /// Общий
        /// </summary>
        Common,
        /// <summary>
        /// Список spy-объектов
        /// </summary>
        SpyObjectList,
        /// <summary>
        /// Секция подключения
        /// </summary>
        IncludeSection
        }
    }
