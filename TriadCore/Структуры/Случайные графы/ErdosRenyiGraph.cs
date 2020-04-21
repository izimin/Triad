using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
{
    /// <summary>
    /// Модель Эрдеша – Реньи
    /// </summary>
    class ErdosRenyiGraph :Graph
    {
        public ErdosRenyiGraph()
            :base(new CoreName("Неизвестный случайный граф Ердеша-Реньи"))
        {
        }

        public ErdosRenyiGraph(CoreName name)
            :base(name)
        {
        }

        public void CompleteGraph(double p)
        {
            for(int i=0;i<this.NodeCount-1;i++)
                for(int j=i;j<NodeCount;j++)
                {
                    if (Rand.RandomReal() < p)
                        AddEdge(this[i].Name, this[i][j].Name, this[j].Name, this[j][i].Name);
                }
        }
    }
}
