using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
{
    /// <summary>
    /// Паросочетания
    /// </summary>
    public class Matching
    {
        /// <summary>
        /// поиск максимального паросочетания
        /// </summary>
        /// <param name="G">граф</param>
        /// <param name="u">индексы вершин 1 доли</param>
        /// <param name="v">индексы вершин 2 доли</param>
        public Matching(Graph G,int[] u,int[] v)
        {
            this.G = G;
            this.maxMatching = new List<Edge>();
            this.u = u;
            this.v = v;
            this.n = u.Length;
            this.k = v.Length;
            this.NC = G.NodeCount;
            this.matrix = new int[n, k];
            matrix = StandartFunctions.GetMatrix(G);
            this.nb = new int[k];
            this.used = new bool[n];
            FindMaxMatching();           
        }

        /// <summary>
        /// решение задачи о назначениях
        /// </summary>
        /// <param name="a">матрица затрат</param>
        public Matching(Graph G,int[,] a)
        {
            this.G = G;
            this.NC = a.Length/2;
            this.a = a;
            this.assign = new List<Edge>();
            this.mincol = new int[NC];
            this.minrow = new int[NC];
            this.vx = new bool[NC];
            this.vy = new bool[NC];
            this.xy = new int[NC];
            this.yx = new int[NC];
            AssignmentProblem();
        }

        /// <summary>
        /// решение задачи о назначениях
        /// </summary>
        private void AssignmentProblem()
        {
            for (int i = 0; i < NC; i++)
            {
                mincol[i] = infinity;
                minrow[i] = infinity;
                xy[i] = -1;
                yx[i] = -1;
            }
            for (int i = 0; i < NC; ++i)
                for (int j = 0; j < NC; ++j)
                    minrow[i] = Math.Min(minrow[i], a[i, j]);
            for (int j = 0; j < NC; ++j)
                for (int i = 0; i < NC; ++i)
                    mincol[j] = Math.Min(mincol[j], a[i, j] - minrow[i]);
            int c = 0;
            while (c < NC)
            {
                for (int i = 0; i < NC; i++)
                {
                    vx[i] = false;
                    vy[i] = false;
                }
                int k = 0;
                for (int i = 0; i < NC; ++i)
                    if (xy[i] == -1 && dotry(i)) ++k;
                c += k;
                if (k == 0)
                {
                    int z = infinity;
                    for (int i = 0; i < NC; ++i)
                        if (vx[i]) for (int j = 0; j < n; ++j)
                                if (!vy[j]) z = Math.Min(z, a[i, j] - minrow[i] - mincol[j]);
                    for (int i = 0; i < NC; ++i)
                    {
                        if (vx[i]) minrow[i] += z;
                        if (vy[i]) mincol[i] -= z;
                    }
                }
            }

            this.cost = 0;
            for (int i = 0; i < NC; ++i)
                this.cost += a[i,xy[i]];
            for (int i = 0; i < NC; ++i)
            {
                Edge e;
                e.nodefrom = G[i];
                e.nodeto = G[xy[i]+NC/2];
                e.inf = a[i, xy[i]];
                assign.Add(e);
            }

        }

        /// <summary>
        /// возвращает список ребер, максимального назначения
        /// </summary>
        public List<Edge> AssignNumber
        {
            get { return this.assign; }
        }

        /// <summary>
        /// минимальная суммарная стоимость задачи о назначениях
        /// </summary>
        public int MinAssignCost
        {
            get { return cost; }
        }

        private bool dotry(int i) 
        {
	        if (vx[i])  return false;
	        vx[i] = true;
	        for (int j=0; j<NC; ++j)
		        if (a[i,j]-minrow[i]-mincol[j] == 0)
			vy[j] = true;
	        for (int j=0; j<NC; ++j)
		        if (a[i,j]-minrow[i]-mincol[j] == 0 && yx[j] == -1) 
                {
			        xy[i] = j;
			        yx[j] = i;
			        return true;
                }
	        for (int j=0; j<NC; ++j)
		        if (a[i,j]-minrow[i]-mincol[j] == 0 && dotry (yx[j])) 
                {
			        xy[i] = j;
			        yx[j] = i;
			        return true;
		        }
	        return false;
        }

        /// <summary>
        /// поиск максимального паросочетания
        /// </summary>
        private void FindMaxMatching()
        {
            for (int i = 0; i < k; i++) nb[i] = -1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++) used[j] = false;
                find(i);
            }
            this.maxMatching.Clear();
            this.countEdgeInMaxMatching = 0;
            for (int i = 0; i < k; i++)
                if (nb[i] != -1) 
                {
                    Edge e;
                    e.nodefrom = G[u[nb[i]]];
                    e.nodeto = G[v[i]];
                    e.inf = 0;
                    maxMatching.Add(e);
                    countEdgeInMaxMatching++;
                }
        }

        /// <summary>
        /// алгоритм Куна поиска макс паросочетания
        /// </summary>
        /// <param name="s">вершина 1 доли</param>
        /// <returns>найдена ли увелич цепь</returns>
        private bool find(int s)
        {
            int t;
            if (used[s]) return false;
            used[s] = true;
            for (int i = 0; i < k; i++)
            {
                //ищем вершина смежную s вершине в другой доле
                if (matrix[u[s], v[i]] > 0) t = i;
                else continue;

                if (nb[t] == -1 || find(nb[t]))
                {
                    nb[t] = s;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// максимальное парасочетние
        /// </summary>
        public List<Edge> MaxMatching
        {
            get { return maxMatching; }
        }

        /// <summary>
        /// кол-во ребер в максимальном паросочетании
        /// </summary>
        public int CountEdgeInMaxMatching
        {
            get { return countEdgeInMaxMatching; }
        }


        //****задача о назначениях
        private int cost;
        /// <summary>
        /// список ребер решения задачи о назначении
        /// </summary>
        private List<Edge> assign;
        private int infinity = int.MaxValue;
        private int[] xy, yx;
        private bool[] vx, vy;
        private int[] minrow, mincol;
        private int[,] a;
        //*****maxmatching
        private int[] nb;
        private bool[] used;
        private int[,] matrix;
        /// <summary>
        /// кол-во вершин в графе
        /// </summary>
        private int NC;
        /// <summary>
        /// кол-во вершин в первой доле
        /// </summary>
        private int k;
        /// <summary>
        /// кол-во вершин во второй доле
        /// </summary>
        private int n;
        /// <summary>
        /// массив индексов вершин первой доли
        /// </summary>
        private int[] u;
        /// <summary>
        /// массив индексов вершин второй доли
        /// </summary>
        private int[] v;
        /// <summary>
        /// список вершин в порядке образования ребер которые образуют максимально парасочетание
        /// </summary>
        private List<Edge> maxMatching;
        /// <summary>
        /// кол-во ребер в максимальном паросочетании
        /// </summary>
        private int countEdgeInMaxMatching;
        private Graph G;
    }
}
