using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
{
    class CopyGraph:Graph
    {
        public CopyGraph()
            :base(new CoreName("Неизвестный граф модели копирования"))
        { }

        public CopyGraph(CoreName name)
            :base(name)
        { }

        public void CompleteGraph(int m, double p)
        {
            List<List<int>> fGraph = new List<List<int>>();
            //создаем граф с m+1 вершинами и m ссылками
            for(int i=0;i<=m;i++)
            {
                fGraph.Add(new List<int>());
                for (int j = 0; j <= m; j++)
                    if (i != j)
                    {
                        fGraph[i].Add(j);
                        AddEdge(this[i].Name, this[i][j].Name, this[j].Name, this[j][i].Name);
                    }
            }
            for (int i=m+1;i<NodeCount;i++)
            {
                int randVert = Rand.RandomIn(0, i);
                for(int j=0;j<m;j++)
                {
                    int to;
                    if (Rand.RandomReal() < p)
                        to = Rand.RandomIn(0, i);
                    else
                        to = fGraph[randVert][j];
                    fGraph[i].Add(to);
                    AddEdge(this[i].Name, this[i][to].Name, this[to].Name, this[to][i].Name);
                }
            }
        }
    }
}
