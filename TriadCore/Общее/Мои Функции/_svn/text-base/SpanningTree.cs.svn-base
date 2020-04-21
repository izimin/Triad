using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
{
    /// <summary>
    /// остовное дерево
    /// </summary>
    public class SpanningTree
    {
        private Graph G;
        private int NC;
        private int[,] matrix;
        private int infinity = int.MaxValue;
        private List<Edge> minSpanningTree;
        private List<Edge> maxSpanningTree;

        public SpanningTree(Graph G, List<Edge> l)
        {
            this.G = G;
            this.NC = G.NodeCount;
            this.matrix = new int[NC, NC];
            foreach (Edge edge in l)
            {
                int z = StandartFunctions.GetNodeIndex(G, edge.nodefrom);
                int x = StandartFunctions.GetNodeIndex(G, edge.nodeto);
                matrix[z, x] = edge.inf;
                matrix[x, z] = edge.inf;
            }

            //если нет ребра то расстояние = бесконечности
            for (int i = 0; i < NC; i++)
                for (int j = 0; j < NC; j++)
                    if (i != j && matrix[i, j] == 0) matrix[i, j] = infinity;

            this.maxSpanningTree = new List<Edge>();
            this.minSpanningTree = new List<Edge>();
        }

        /// <summary>
        /// поиск минимального остовного дерева
        /// </summary>
        /// <returns></returns>
        public List<Edge> MinSpanningTree()
        {
            minSpanningTree.Clear();
            int[] lowcost = new int[NC];//значение стоимости ребра (i,closest[i])
            int[] closest = new int[NC];//содержит для i вершины из V\U вершину из U(ребро мин стоим)
            int i, j, k, min;//k-номер найд вершины, min-lowcost[k]

            for (i = 1; i < NC; i++)
            {
                //первоночально в множестве U одна вершина
                lowcost[i] = matrix[0, i];
                closest[i] = 0;
            }

            for (i = 1; i < NC; i++)
            {
                //поискс вне множества U наилучшей вершины k,
                //имеющей инцидентное ребро оканчив в множестве U
                min = lowcost[1];
                k = 1;
                for (j = 2; j < NC; j++)
                    if (lowcost[j] < min)
                    {
                        min = lowcost[j];
                        k = j;
                    }

                //добавление ребра в список
                Edge a;
                a.nodefrom = G[k]; a.nodeto = G[closest[k]]; a.inf = matrix[k, closest[k]];
                minSpanningTree.Add(a);

                lowcost[k] = infinity; //к добавляется в множ U
                for (j = 1; j < NC; j++) //корректировка стоимостей в U
                    if (matrix[k, j] < lowcost[j] && lowcost[j] < infinity)
                    {
                        lowcost[j] = matrix[k, j];
                        closest[j] = k;
                    }
            }
            return minSpanningTree;
        }
        /// <summary>
        /// поиск максимального остовного дерева
        /// </summary>
        /// <returns></returns>
        public List<Edge> MaxSpanningTree()
        {
            minSpanningTree.Clear();
            int[] morecost = new int[NC];//значение стоимости ребра (i,closest[i])
            int[] closest = new int[NC];//содержит для i вершины из V\U вершину из U(ребро мин стоим)
            int i, j, k, max;//k-номер найд вершины, max-morecost[k]

            for (i = 1; i < NC; i++)
            {
                //первоночально в множестве U одна вершина
                morecost[i] = matrix[0, i];
                closest[i] = 0;
            }

            for (i = 1; i < NC; i++)
            {
                //поискс вне множества U наилучшей вершины k,
                //имеющей инцидентное ребро оканчив в множестве U
                max = -1;
                k = 0;
                for (j = 1; j < NC; j++)
                    if (morecost[j] > max && morecost[j]<infinity)
                    {
                        max = morecost[j];
                        k = j;
                    }

                //добавление ребра в список
                Edge a;
                a.nodefrom = G[k]; a.nodeto = G[closest[k]]; a.inf = matrix[k, closest[k]];
                maxSpanningTree.Add(a);

                morecost[k] = infinity; //к добавляется в множ U
                for (j = 1; j < NC; j++) //корректировка стоимостей в U
                    if (matrix[k, j] > morecost[j] && morecost[j] < infinity)
                    {
                        morecost[j] = matrix[k, j];
                        closest[j] = k;
                    }
            }
            return maxSpanningTree;
        }

    }
}
