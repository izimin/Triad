using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
{
    //сильносвязанные компоненты
    public class Scc
    {

        public Scc(Graph G)
        {
            this.NC = G.NodeCount;
            this.matrix = new int[NC, NC];
            this.matrix = StandartFunctions.GetMatrix(G);
            this.edges = new int[NC, NC];
            this.edgesT = new int[NC, NC];
            this.edges_c = new int[NC];
            this.edgesT_c = new int[NC];
            this.components = new int[NC];
            GetAllArrays();       
            this.f = new int[NC];
            this.used = new int[NC];
            StrConnComp();
        }

        /// <summary>
        /// поиск в глубину
        /// </summary>
        /// <param name="node">вершина</param>
        void dfs(int node)
        {
            used[node] = 1;

            for (int i = 0; i < edges_c[node]; i++)
                if (used[edges[node, i]] == 0)
                    dfs(edges[node, i]);

            f[last_f++] = node;
        }

        /// <summary>
        /// поиск в глубину для GТ
        /// </summary>
        /// <param name="node"></param>
        void dfsT(int node)
        {
            used[node] = 1;

            for (int i = 0; i < edgesT_c[node]; i++)
                if (used[edgesT[node, i]] == 0)
                    dfsT(edgesT[node, i]);

            this.components[node] = component; //сильносвяз компоненты
        }

        private void StrConnComp()
        {
            for (int i = 0; i < NC; i++) used[i] = 0;
            for (int i = 0; i < NC; i++) if (used[i]++ == 0) dfs(i);
            for (int i = 0; i < NC; i++) used[i] = 0;
            while (--last_f >= 0)
                if (used[f[last_f]] == 0)
                {
                    dfsT(f[last_f]);
                    component++;
                }
        }

        private void GetAllArrays()
        {
            for (int i = 0; i < NC; i++)
                for (int j = 0; j < NC; j++)
                    if (matrix[i, j] != 0)
                    {
                        edges[i, edges_c[i]] = j;
                        edges_c[i] += 1;
                    }
            
            for (int i = 0; i < NC; i++)
                for (int j = 0; j < edges_c[i]; j++)
                    edgesT[edges[i, j], edgesT_c[edges[i, j]]++] = i;

        }
        /// <summary>
        /// массив где i значение это номер компоненты i вершины
        /// </summary>
        public int[] GetScc
        {
            get { return components; }
        }

        /// <summary>
        /// кол-во вершин
        /// </summary>
        private int NC;
        private int[,] matrix;
        private int[,] edges, edgesT;
        /// <summary>
        /// кол-во ребер
        /// </summary>
        private int[] edges_c, edgesT_c;
        private int[] components;
        private int component = 1;//номер компоненты (кол-во)
        private int[] used;// посещенна ли вершина
        private int[] f;// предварит расстан вершин
        private int last_f = 0;
    }
}