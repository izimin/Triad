using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;


namespace TriadCore
{
    /// <summary>
    /// стандартные функции слоя структур
    /// </summary>
    public static class StandartFunctions
    {
        ///<summary>
        ///выделяет слой структуры в модели М
        ///</summary>
        public static Graph GetGraphWithoutRoutines(Graph M)
        {
            Graph N;
            N = M.Clone();
            foreach (Node node in N.Nodes)
            {
                N[node.Name].NodeRoutine = null;
            }
            return N;
         }

        /// <summary>
        /// выделяет слой рутин в модели М|выделяет элементарную рутину наложенную на вершину модели
        /// </summary>
        /// <param name="M">Модель</param>
        /// <returns></returns>
        public static Set GetRoutines(Graph M)
        {
            Set routines = new Set();
            foreach (Node node in M.Nodes)
            {
                if (M[node.Name].NodeRoutine != null)
                    routines.AddValue(M[node.Name].NodeRoutine);
            }
            return routines;
        }

        /// <param name="node">вершина модели</param>
        public static Routine GetRoutine(Node node)
        {
            return node.NodeRoutine;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="G"></param>
        /// <param name="RoutineNames"></param>
        /// <returns></returns>
        public static Set GetNodes(Graph G, Set RoutineNames)
        {
            Set nodes = new Set();
            foreach (Node node in G.Nodes)
            {
                Routine nodeRoutine = node.NodeRoutine;
                if (nodeRoutine != null && RoutineNames.In(nodeRoutine.GetType().Name))
                    nodes.AddValue(node);
            }
            return nodes;
        }

        /// <summary>
        /// находит множество вершин графа
        /// </summary>
        /// <param name="G">граф</param>
        /// <returns></returns>
        public static Set GetNodeSet(Graph G)
        {
            Set nodeSet = new Set();
            foreach (Node node in G.Nodes)
                nodeSet.AddValue(node);
            return nodeSet;
        }

        /// <summary>
        /// множество смежных по выходу вершин
        /// </summary>
        /// <param name="N">вершина</param>
        /// <returns></returns>
        public static Set GetAdjacentNodesOut(Node N)
        {
            Set nodeOut = new Set();
            //если нет полюсов то нет смежных вершин
            if (N.HasPoluses())
            {
                foreach (Polus polus in N.Poluses)
                    foreach (Polus outpolus in polus.TargetOutputPoluses)
                        if (!(outpolus.BaseNode.Equals(N) || nodeOut.In(outpolus.BaseNode))) nodeOut.AddValue(outpolus.BaseNode);
               
            }
            return nodeOut;
        }

        /// <summary>
        /// множество инцидентных ребер
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static Set GetIncidentEdges(Node N)
        {
            Set IncidentEdges = new Set();
            if (N.HasPoluses())
            {
                foreach (Polus polus in N.Poluses)
                {
                    foreach (Polus outpolus in polus.TargetOutputPoluses)
                    {
                        if (!(outpolus.BaseNode.Equals(N)))
                        {
                            Edge edge;
                            edge.nodefrom = N;
                            edge.nodeto = outpolus.BaseNode;
                            edge.inf = 0;
                            IncidentEdges.AddValue(edge);
                        }
                    }
                    foreach (Polus inpolus in polus.TargetInputPoluses)
                    {
                        if (!(inpolus.BaseNode.Equals(N)))
                        {
                            Edge edge;
                            edge.nodefrom = inpolus.BaseNode;
                            edge.nodeto = N;
                            edge.inf = 0;
                            IncidentEdges.AddValue(edge);
                        }
                    }
                }

            }
            return IncidentEdges;
        }

        public static Node GetEdgeAdjacentNode(Edge edge, Node node)
        {
            if (edge.nodefrom == node)
                return edge.nodeto;
            if (edge.nodeto == node)
                return edge.nodefrom;
            return null;
        }

        /// <summary>
        /// множество смежных по входу вершин
        /// </summary>
        /// <param name="N">вершина</param>
        /// <returns></returns>
        public static Set GetAdjacentNodesIn(Node N)
        {
            Set nodeIn = new Set();
            //если полюса у вершины
            if (N.HasPoluses())
            {
                foreach (Polus polus in N.Poluses)
                    foreach (Polus inpolus in polus.TargetInputPoluses)
                        if (!(inpolus.BaseNode.Equals(N) || nodeIn.In(inpolus.BaseNode))) nodeIn.AddValue(inpolus.BaseNode);
            }
            return nodeIn;
        }

        /// <summary>
        /// множество смежных вершин
        /// </summary>
        /// <param name="N">вешина</param>
        /// <returns></returns>
        public static Set GetAdjacentNodes(Node N)
        {
            return GetAdjacentNodesIn(N).Intersect(GetAdjacentNodesOut(N));
        }

                    
        /// <summary>
        /// множество имен вершин графа
        /// </summary>
        /// <param name="G">граф</param>
        /// <returns></returns>
        public static Set GetNodeNames(Graph G)
        {
            Set NameSet = new Set();
            foreach (Node node in G.Nodes)
                NameSet.AddValue(node.Name.ToString());
            return NameSet;
        }

        /// <summary>
        /// массив имен вершин графа
        /// </summary>
        /// <param name="G">граф</param>
        /// <returns>массив</returns>
        public static string[] GetArrayOfNodeNames(Graph G)
        {
            int NC = GetNodeCount(G);
            string[] s = new string[NC];
            for (int i = 0; i < NC; i++)
                s[i] = G[i].Name.ToString();
            return s;
        }

        /// <summary>
        /// число вершин в графе
        /// </summary>
        /// <param name="G">граф</param>
        /// <returns></returns>
        public static int GetNodeCount(Graph G)
        {
            return G.NodeCount; 
        }

        /// <summary>
        /// степень вершины
        /// </summary>
        /// <param name="node">вершина</param>
        /// <returns></returns>
        public static int GetNodeDegree(Node node)
        {
            int degree;
            Set s = new Set();
            s = GetAdjacentNodes(node);
            degree = s.Size;
            return degree;
        }

        /// <summary>
        /// степень вершины по входам
        /// </summary>
        /// <param name="node">вершина</param>
        /// <returns></returns>
        public static int GetNodeDegreeIn(Node node)
        {
            int degree;
            Set s = new Set();
            s = GetAdjacentNodesIn(node);
            degree = s.Size;
            return degree;
        }

        /// <summary>
        /// степень вершины по выходам
        /// </summary>
        /// <param name="node">вершина</param>
        /// <returns></returns>
        public static int GetNodeDegreeOut(Node node)
        {
            int degree;
            Set s = new Set();
            s = GetAdjacentNodesOut(node);
            degree = s.Size;
            return degree;
        }

        /// <summary>
        /// получить матрицу смежности графа
        /// </summary>
        /// <param name="G">граф</param>
        /// <returns>матрица смежности</returns>
        public static int[,] GetMatrix(Graph G)
        {
            int NC = G.NodeCount;
            int[,] Matrix = new int[NC, NC];
            Set s = new Set();

            //заполнение матрицы
            for (int i = 0; i < NC; i++)
            {
                s = GetAdjacentNodesOut(G[i]);//получим список вершин в которые идут дуги из G[i]
                for (int j = 0; j < NC; j++)
                    if (s.In(G[j])) Matrix[i, j] = 1;
                    else Matrix[i, j] = 0;
            }
            return Matrix;
        }

        /// <summary>
        /// находит диаметр графа
        /// </summary>
        /// <param name="G">граф</param>
        /// <returns>диаметр</returns>
        public static int GetGraphDiameter(Graph G)
        {
            int NC = G.NodeCount;
            int ei;//эксцентриситет i верш
            int xj;//расстояние от i до j
            int maxdist;
            int maxexc = 0;
            int infinity = int.MaxValue;//бесконечность
            Set s = new Set();

            for (int i = 0; i < NC; i++)
            {
                maxdist = 0;
                //находим расстояние от i вершины до всех
                for (int j = 0; j < NC; j++)
                {
                    if (i == j) xj = 0;
                    else
                    {
                        s = FindShortestPath(G, G[i], G[j]);
                        if (s.Size == 0) xj = infinity;
                        else xj = s.Size - 1;
                    }
                    if (maxdist < xj) maxdist = xj;
                }
                ei = maxdist;//ексц это макс расст от вершины i до остальных вершин
                if (ei > maxexc) maxexc = ei;//ищем макс эксц вершин графа
            }
            if (maxexc == infinity)
                maxexc = -1;
            return maxexc;//макс эксц вершин есть диаметр
        }

        /// <summary>
        /// индекс вершины в графе
        /// </summary>
        /// <param name="G">граф</param>
        /// <param name="node">вершина</param>
        /// <returns>индекс,-1 если вершины нет в графе</returns>
        public static int GetNodeIndex(Graph G, Node node)
        {
            int ind = -1;
            int NC = G.NodeCount;
            for (int i = 0; i < NC; i++)
            {
                if (G[i].Equals(node))
                {
                    ind = i;
                    break;
                }
            }
            return ind;
        }

        #region Алгоритмы над графами

        /// <summary>
        /// поиск кратчайшего пути между 2 вершинами
        /// </summary>
        /// <param name="G">граф</param>
        /// <param name="nodefrom">начальная вершина</param>
        /// <param name="nodeto">конечная вершина</param>
        /// <returns>список вершин, в порядке образования пути</returns>
        public static Set FindShortestPath(Graph G, Node nodefrom, Node nodeto)
        {
            ShortestPath sp = new ShortestPath(G, nodefrom, nodeto);
            List<Node> shPath = sp.shortestPath;
            Set shortestPath = new Set();
            if (shPath != null)
                foreach (Node node in shPath)
                    shortestPath.AddValue(node);
            return shortestPath;
        }

        /// <summary>
        /// минимимальное остовное дерево (Алг. Прима)
        /// </summary>
        /// <param name="G">неориентированный граф</param>
        /// <param name="l">список ребер графа с весами</param>
        /// <returns>список ребер миним остовного дерева</returns>
        public static List<Edge> MinSpanningTree(Graph G,List<Edge> l)
        {
            SpanningTree spanningtree = new SpanningTree(G, l);
            return spanningtree.MinSpanningTree();
        }

        /// <summary>
        /// максимимальное остовное дерево (Алг. Прима)
        /// </summary>
        /// <param name="G">неориентированный граф</param>
        /// <param name="l">список ребер графа с весами</param>
        /// <returns>список ребер макс остовного дерева</returns>
        public static List<Edge> MaxSpanningTree(Graph G, List<Edge> l)
        {
            SpanningTree spanningtree = new SpanningTree(G, l);
            return spanningtree.MaxSpanningTree();
        }

        /// <summary>
        /// величина максимального потока
        /// </summary>
        /// <param name="G">граф</param>
        /// <param name="s">источник</param>
        /// <param name="t">сток</param>
        /// <param name="l">список дуг с пропускными способностями</param>
        /// <returns>величина поток</returns>
        public static int MaxFlowValue(Graph G, Node s, Node t,List<Arc> l)
        {
            MaxFlow maxflow = new MaxFlow(G, s, t,l);
            return maxflow.GetMaxFlowValue;
        }

        /// <summary>
        /// максимальный поток
        /// </summary>
        /// <param name="G">граф</param>
        /// <param name="s">источник</param>
        /// <param name="t">сток</param>
        /// <param name="l">список дуг с пропускными способностями</param>
        /// <returns>список дуг потока</returns>
        public static List<Arc> MaxFlow(Graph G, Node s, Node t, List<Arc> l)
        {
            MaxFlow maxflow = new MaxFlow(G, s, t, l);
            return maxflow.GetMaxFlow;
        }

        /// <summary>
        /// поиск максимального паросочетания
        /// </summary>
        /// <param name="G">двудольный граф</param>
        /// <param name="u">индексы веришн 1 доли</param>
        /// <param name="v">индексы вершин 2 доли</param>
        /// <returns>список веришин в порядке образования ребер макс паросоч</returns>
        public static List<Edge> MaxMatching(Graph G, int[] u, int[] v)
        {
            Matching matching = new Matching(G, u, v);
            return matching.MaxMatching;
        }
        
        /// <summary>
        /// сильно связные компоненты графа
        /// </summary>
        /// <param name="G">граф</param>
        /// <returns>массив,i значение-номер компоненты которой принадл i вершина</returns>
        public static int[] GetStronglyConnectedComponents(Graph G)
        {
            Scc scc = new Scc(G);
            return scc.GetScc;
        }

        /// <summary>
        /// задача о назначениях
        /// </summary>
        /// <param name="G">граф</param>
        /// <param name="a">матрица затрат</param>
        /// <returns>список ребер минимального назначения</returns>
        public static List<Edge> AssignProblem(Graph G,int[,] a)
        {
            Matching matching=new Matching(G,a);
            return matching.AssignNumber;
        }

        #endregion
    }
   
}
