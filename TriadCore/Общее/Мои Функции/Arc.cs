using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
{
    public struct Arc
    {
        /// <summary>
        /// начальная вершина
        /// </summary>
        public Node nodefrom;
        /// <summary>
        /// конечная вершина
        /// </summary>
        public Node nodeto;
        /// <summary>
        /// информационное поле
        /// </summary>
        public int inf;
    }

    public struct Edge
    {
        public Node nodefrom;
        public Node nodeto;
        public int inf;
    }
        
}