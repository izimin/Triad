using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
{
    public class ShortestPath
    {
        /// <summary>
        /// нахождение кратчайшего расстояния между 2 вершинами графа
        /// </summary>
        /// <param name="G">граф</param>
        /// <param name="nodefrom">начальная вершины</param>
        /// <param name="nodeto">конечная вершина</param>
        public ShortestPath(Graph G, Node nodefrom, Node nodeto)
        {
            this.G = G;
            this.NC = G.NodeCount;
            this.nf = StandartFunctions.GetNodeIndex(G, nodefrom);
            this.nt = StandartFunctions.GetNodeIndex(G, nodeto);
            this.matrix = new int[NC, NC];
            matrix = StandartFunctions.GetMatrix(G);
            this.l = new List<Node>();
            Dijkstra();
        }

        /// <summary>
        /// нахождение кратчайшего расстояние между 2 вершинами графа
        /// </summary>
        private void Dijkstra()
        {         
            int[] x = new int[NC];//x[i]=0 если кратч путь в i вершину не найден, иначе =1
            int[] length = new int[NC];//length[i]-длина кратчайшего пути из начальной вершины в i
            int[] prevnode = new int[NC];//prevnode[i]-вершина предшествующ вершине i на кратч пути
            int indexnow;//текущ вершина
         
            for (int i = 0; i < NC; i++)
            {
                length[i] = infinity;//изначально все кратч пути из начальной в другие = бесконечн
                x[i] = 0;//кратч путей нет для всех вершин
            }

            prevnode[nf] = 0;//т.к начальная вершина
            length[nf] = 0;//из начальной в начальн кратч путь = 0
            x[nf] = 1;//для начальной вершины есть кратч путь
            indexnow = nf;

            while (true)
            {
                // перебир все вершины смежные к текущей,ищем для них кратч путь
                for (int i = 0; i < NC; i++)
                {
                    if (matrix[indexnow, i] == 0) continue; //u и v несмежны
                    //Если для i вершиы не найден кратч путь,и новый путь в i короче старого
                    if (x[i] == 0 && length[i] > length[indexnow] + matrix[indexnow, i])
                    {
                        length[i] = length[indexnow] + matrix[indexnow, i];//сохр более короткую длину 
                        prevnode[i] = indexnow;//indexnow->i часть пути из начальной->i
                    }
                }

                // Ищем из всех путей самый короткий
                int w = infinity;
                indexnow = -1;   //v-вершина в которую будет найден новый кратчайший путь
                for (int i = 0; i < NC; i++)
                {
                    // если для вершины не найден кратч путь и длина пути в вершину i меньше уже найденной
                    if (x[i] == 0 && length[i] < w)
                    {
                        indexnow = i; //текущ вершин=i
                        w = length[i];
                    }
                }

                if (indexnow == -1)
                {
                    //Нет пути из начальной в конечную веришну
                    l = null;
                    break;
                }

                if (indexnow == nt) //нашли
                {
                    //Кратчайший путь из нач в конечную
                    int i;
                    int[] path = new int[NC];
                    int nodeinpath = 0;
                    i = nt;
                    while (i != nf)
                    {
                        path[nodeinpath] = i;
                        nodeinpath++;
                        i = prevnode[i];
                    }
                    path[nodeinpath] = nf;
                    //добавляем соответств вершины в наш список
                    for (i = nodeinpath; i >= 0; i--) l.Add(G[path[i]]);
                    pathlenght=length[nt]; //длина пути
                    break;
                }
                x[indexnow] = 1;
            }
        }

        public List<Node> shortestPath
        {
            get { return l; }
        }

        public int PathLenght
        {
            get { return pathlenght; }
        }


        private Graph G;
        /// <summary>
        /// номер начальной вершины
        /// </summary>
        private int nf;
        /// <summary>
        /// номер конечной вершины
        /// </summary>
        private int nt;
        /// <summary>
        /// кол-во вершин в графе
        /// </summary>
        private int NC;
        private int infinity = int.MaxValue;
        private int[,] matrix;
        /// <summary>
        /// кратчайший путь
        /// </summary>
        private List<Node> l;
        /// <summary>
        /// длина пути
        /// </summary>
        private int pathlenght;
    }
}
