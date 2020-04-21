using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
{
    /// <summary>
    /// максимальный поток
    /// </summary>
    public class MaxFlow
    {
        /// <summary>
        /// поиск максимального потока
        /// </summary>
        /// <param name="G">граф</param>
        /// <param name="s">источник</param>
        /// <param name="t">сток</param>
        /// <param name="t">список дуг с пропускн способностями</param>
        public MaxFlow(Graph G, Node s, Node t,List<Arc> c)
        {
            this.NC = G.NodeCount;
            this.g = G;
            this.maxflowvalue = 0;
            this.maxFlow = new List<Arc>();
            this.c = new int[NC, NC];
            this.F = new int[NC, NC];
            this.prev = new int[NC];
            this.used = new bool[NC];
            this.d = new int[NC];
            foreach (Arc arc in c)
            {
                int z = StandartFunctions.GetNodeIndex(G, arc.nodefrom);
                int x = StandartFunctions.GetNodeIndex(G, arc.nodeto);
                this.c[z, x] = arc.inf;
            }
            this.snode = StandartFunctions.GetNodeIndex(G, s);
            this.tnode = StandartFunctions.GetNodeIndex(G, t);
            for (int i = 0; i < NC; i++) 
                for (int j=0;j<NC;j++) F[i, j] = 0;
            FindMaxFlow();
        }

        /// <summary>
        /// величина максимального потока
        /// </summary>
        public int GetMaxFlowValue
        {
            get { return maxflowvalue; }
        }

        /// <summary>
        /// максимальный поток
        /// </summary>
        public List<Arc> GetMaxFlow
        {
            get { return maxFlow; }
        }

        /// <summary>
        /// есть ли расстояние из источника в сток в остаточной сети(поиск в ширину)
        /// </summary>
        private bool FindPath
        {
            get
            {
                for (int i = 0; i < NC; i++) used[i] = false;
                Queue<int> q = new Queue<int>();
                q.Enqueue(snode);
                used[snode] = true;
                prev[snode] = -1;

                while (q.Count > 0)
                {
                    int i = q.Dequeue();
                    for (int j = 0; j < NC; j++)
                    {
                        if (!used[j] && (c[i, j] - F[i, j]) > 0) //если вершина j не посещена и дуга не насыщена
                        {
                            used[j] = true; //посетили j вершину
                            q.Enqueue(j);
                            prev[j] = i;
                        }
                    }
                }
                return used[tnode]; //нашли ли путь до стока
            }
        }
        /// <summary>
        /// Форда - Фалкерсона
        /// </summary>
        private void FindMaxFlow()
        {
            int d, k, flow = 0;
            while (FindPath) //пока существ путь от s к t в остат сети
            {
                d = infinity;
                //ищем ребро на этом пути с миним неиспользов пропуск способ
                k = tnode;
                while (k != snode)
                {
                    d = Math.Min(d, c[prev[k], k] - F[prev[k], k]);
                    k = prev[k];
                }

                //идем по найд пути от s к t и корректируем ост сеть
                k = tnode;
                while (k != snode)
                {
                    F[prev[k], k] += d;//в обе стороны корректир
                    F[k, prev[k]] -= d;
                    k = prev[k];
                }
                flow += d;
            }
            this.maxflowvalue = flow;//велич макс потока
            for (int i = 0; i < NC; i++)
                for (int j = 0; j < NC; j++)
                    if (F[i, j] > 0)
                    {
                        Arc a;
                        a.inf = F[i, j];
                        a.nodefrom = g[i];
                        a.nodeto = g[j];
                        maxFlow.Add(a);
                    }

        }

        /// <summary>
        /// максимальный поток
        /// </summary>
        private int maxflowvalue;
        /// <summary>
        /// кол-во вершин в графe
        /// </summary>
        private int NC;
        /// <summary>
        /// поток
        /// </summary>
        private int[,] F;
        /// <summary>
        /// пропускные способности
        /// </summary>
        private int[,] c;
        /// <summary>
        /// источник
        /// </summary>
        private int snode;
        /// <summary>
        /// сток
        /// </summary>
        private int tnode;
        /// <summary>
        /// номер предыдущей вершины
        /// </summary>
        private int[] prev;
        /// <summary>
        /// кратч расстояние от источника
        /// </summary>
        private int[] d;
        /// <summary>
        /// посещалась ли  i вершина
        /// </summary>
        private bool[] used;
        /// <summary>
        /// бесконечность
        /// </summary>
        private int infinity = int.MaxValue;
        /// <summary>
        /// найденный макс поток
        /// </summary>
        private List<Arc> maxFlow;
        private Graph g;

    }
}
