using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
{
    class BaklyOktusGraph:Graph
    {
        public BaklyOktusGraph()
            :base(new CoreName("Неизвестный случайный граф Бакли-Остгуса"))
        { }

        public BaklyOktusGraph(CoreName name)
            :base(name)
        { }

        public void CompleteGraph(int k, int a)
        {
            int[] degree = new int[NodeCount * k];
            degree[0] = 2;
            AddEdge(this[0].Name, this[0][0].Name, this[0].Name, this[0][0].Name);
            for (int i = 0; i < NodeCount * k; i++)
            {
                int j = 0;
                int p = Rand.RandomIn(1, (i + 1) * 2);
                int pDegree = degree[j]+a-1;
                while (p > pDegree && j < i)
                {
                    j++;
                    pDegree += degree[j]+a-1;
                }
                AddEdge(this[i / k].Name, this[i / k][j / k].Name, this[j / k].Name, this[j / k][i / k].Name);
                degree[i]++;
                degree[j]++;
            }
        }
    }
}
