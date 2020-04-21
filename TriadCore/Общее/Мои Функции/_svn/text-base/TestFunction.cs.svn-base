using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
{
    /// <summary>
    /// класс для тестирования функций
    /// </summary>
    public static class TestFunction
    {
        public static void Test()
        {
            TestNodeDegree();
            TestNodeDegreeIn();
            TestNodeDegreeOut();
            TestMaxMatching();
            TestMaxFlow();
            TestScc();
            TestShortestPath();
            TestAssignProblem();
            TestGraphDiameter();
        }

        public static void TestGraphDiameter()
        {
            Graph g = new Graph(new CoreName("Graph1"));
            CoreName A = new CoreName("a");
            CoreName B = new CoreName("b");
            g.DeclareNode(A);
            g.DeclareNode(B);
            CoreName p1 = new CoreName("p1");
            CoreName p2 = new CoreName("p2");
            CoreName q1 = new CoreName("q1");
            CoreName q2 = new CoreName("q2");
            g[A].DeclarePolus(p1);
            g[A].DeclarePolus(p2);
            g[B].DeclarePolus(q1);
            g[B].DeclarePolus(q2);
            g.AddEdge(A, p1, B, q1);
            if (StandartFunctions.GetGraphDiameter(g) != 1)
                throw new TestFailedException();
        }

        public static void TestNodeDegree()
        {
            //тестирование функций на определение степени вешины
            CoreName d = new CoreName("aaaa");
            Graph g = new Graph(d);
            CoreName d1 = new CoreName("a");
            CoreName d2 = new CoreName("b");
            CoreName d3 = new CoreName("c");
            CoreName d4 = new CoreName("d");
            g.DeclareNode(d1);
            g.DeclareNode(d2);
            g.DeclareNode(d3);
            g.DeclareNode(d4);
            CoreName p1 = new CoreName("p1");
            CoreName p2 = new CoreName("p2");
            CoreName p3 = new CoreName("p3");
            CoreName p4 = new CoreName("p4");
            g[d1].DeclarePolus(p1);
            g[d2].DeclarePolus(p2);
            g[d2].DeclarePolus(p3);
            g[d1].DeclarePolus(p4);
            g.AddArc(d1, p1, d2, p2);
            g.AddArc(d1, p4, d2, p3);
            g.AddArc(d2, p3, d1, p4);
            g.AddArc(d2, p2, d1, p1);
            if (StandartFunctions.GetNodeDegree(g[d1]) != 1)
                throw new TestFailedException();
            if (StandartFunctions.GetNodeDegree(g[d2]) != 1)
                throw new TestFailedException();
            if (StandartFunctions.GetNodeDegree(g[d3]) != 0)
                throw new TestFailedException();
            if (StandartFunctions.GetNodeDegree(g[d4]) != 0)
                throw new TestFailedException();

            g[d2].RemoveAllPoluses();
            g[d2].DeclarePolus(p2);
            g[d3].DeclarePolus(p3);
            g.AddEdge(d1, p1, d2, p2);
            g.AddEdge(d1, p4, d3, p3);
            if (StandartFunctions.GetNodeDegree(g[d1]) != 2)
                throw new TestFailedException();
            if (StandartFunctions.GetNodeDegree(g[d2]) != 1)
                throw new TestFailedException();
            if (StandartFunctions.GetNodeDegree(g[d3]) != 1)
                throw new TestFailedException();

            g.AddEdge(d2, p2, d3, p3);
            if (StandartFunctions.GetNodeDegree(g[d2]) != 2)
                throw new TestFailedException();
            if (StandartFunctions.GetNodeDegree(g[d3]) != 2)
                throw new TestFailedException();

        }

        public static void TestNodeDegreeIn()
        {
            CoreName d = new CoreName("aaaa");
            Graph g = new Graph(d);
            CoreName d1 = new CoreName("a");
            CoreName d2 = new CoreName("b");
            CoreName d3 = new CoreName("c");
            CoreName d4 = new CoreName("d");
            g.DeclareNode(d1);
            g.DeclareNode(d2);
            g.DeclareNode(d3);
            g.DeclareNode(d4);
            CoreName p1 = new CoreName("p1");
            CoreName p2 = new CoreName("p2");
            CoreName p3 = new CoreName("p3");
            CoreName p4 = new CoreName("p4");
            CoreName p5 = new CoreName("p5");
            CoreName p6 = new CoreName("p6");
            CoreName p7 = new CoreName("p7");
            CoreName p8 = new CoreName("p8");
            g[d1].DeclarePolus(p1);
            g[d1].DeclarePolus(p2);
            g[d2].DeclarePolus(p3);
            g[d2].DeclarePolus(p4);
            g[d3].DeclarePolus(p5);
            g[d3].DeclarePolus(p6);
            g[d4].DeclarePolus(p7);
            g[d4].DeclarePolus(p8);

            g.AddArc(d1, p1, d2, p3);
            g.AddArc(d1, p2, d3, p5);
            g.AddArc(d2, p4, d1, p1);
            g.AddArc(d3, p5, d1, p2);
            g.AddArc(d4, p7, d1, p2);
            g.AddArc(d4, p8, d3, p6);
            g.AddArc(d2, p3, d4, p8);
            g.AddArc(d2, p4, d4, p7);
            g.AddArc(d1, p1, d1, p2);
            if (StandartFunctions.GetNodeDegreeIn(g[d1]) != 3)
                throw new TestFailedException();
            if (StandartFunctions.GetNodeDegreeIn(g[d2]) != 1)
                throw new TestFailedException();
            if (StandartFunctions.GetNodeDegreeIn(g[d3]) != 2)
                throw new TestFailedException();
            if (StandartFunctions.GetNodeDegreeIn(g[d4]) != 1)
                throw new TestFailedException();


        }

        public static void TestNodeDegreeOut()
        {
            CoreName d = new CoreName("aaaa");
            Graph g = new Graph(d);
            CoreName d1 = new CoreName("a");
            CoreName d2 = new CoreName("b");
            CoreName d3 = new CoreName("c");
            CoreName d4 = new CoreName("d");
            g.DeclareNode(d1);
            g.DeclareNode(d2);
            g.DeclareNode(d3);
            g.DeclareNode(d4);
            CoreName p1 = new CoreName("p1");
            CoreName p2 = new CoreName("p2");
            CoreName p3 = new CoreName("p3");
            CoreName p4 = new CoreName("p4");
            CoreName p5 = new CoreName("p5");
            CoreName p6 = new CoreName("p6");
            CoreName p7 = new CoreName("p7");
            CoreName p8 = new CoreName("p8");
            g[d1].DeclarePolus(p1);
            g[d1].DeclarePolus(p2);
            g[d2].DeclarePolus(p3);
            g[d2].DeclarePolus(p4);
            g[d3].DeclarePolus(p5);
            g[d3].DeclarePolus(p6);
            g[d4].DeclarePolus(p7);
            g[d4].DeclarePolus(p8);

            g.AddArc(d1, p1, d2, p3);
            g.AddArc(d1, p2, d3, p5);
            g.AddArc(d2, p4, d1, p1);
            g.AddArc(d3, p5, d1, p2);
            g.AddArc(d4, p7, d1, p2);
            g.AddArc(d4, p8, d3, p6);
            g.AddArc(d2, p3, d4, p8);
            g.AddArc(d2, p4, d4, p7);
            g.AddArc(d1, p1, d1, p2);
            if (StandartFunctions.GetNodeDegreeOut(g[d1]) != 2)
                throw new TestFailedException();
            if (StandartFunctions.GetNodeDegreeOut(g[d2]) != 2)
                throw new TestFailedException();
            if (StandartFunctions.GetNodeDegreeOut(g[d3]) != 1)
                throw new TestFailedException();
            if (StandartFunctions.GetNodeDegreeOut(g[d4]) != 2)
                throw new TestFailedException();
        }

        public static void TestMaxMatching()
        {
            CoreName d = new CoreName("aaaa");
            Graph g = new Graph(d);
            CoreName node1 = new CoreName("a");
            CoreName node2 = new CoreName("b");
            CoreName node3 = new CoreName("c");
            CoreName node4 = new CoreName("d");
            CoreName node5 = new CoreName("e");
            CoreName node6 = new CoreName("f");
            CoreName node7 = new CoreName("g");
            CoreName node8 = new CoreName("h");
            CoreName polus1 = new CoreName("polus1");
            g.DeclareNode(node1);
            g.DeclareNode(node2);
            g.DeclareNode(node3);
            g.DeclareNode(node4);
            g.DeclareNode(node5);
            g.DeclareNode(node6);
            g.DeclareNode(node7);
            g.DeclareNode(node8);
            g.DeclarePolusInAllNodes(polus1);
            g.AddEdge(node1, polus1, node6, polus1);
            g.AddEdge(node2, polus1, node5, polus1);
            g.AddEdge(node3, polus1, node8, polus1);
            g.AddEdge(node4, polus1, node5, polus1);
            g.AddEdge(node4, polus1, node6, polus1);
            g.AddEdge(node4, polus1, node7, polus1);
            g.AddEdge(node4, polus1, node8, polus1);
            int[] p = new int[4];
            p[0] = 0; p[1] = 1; p[2] = 2; p[3] = 3;
            int[] t = new int[4];
            t[0] = 4; t[1] = 5; t[2] = 6; t[3] = 7;
            List<Edge> l = new List<Edge>();
            l = StandartFunctions.MaxMatching(g, p, t);
            string st = null;
            foreach (Edge e in l)
            {
                st += Convert.ToString(StandartFunctions.GetNodeIndex(g, e.nodefrom));
                st += Convert.ToString(StandartFunctions.GetNodeIndex(g, e.nodeto));
            }

            if (st != "14053627")
                throw new TestFailedException();

            CoreName graph2 = new CoreName("g1");
            Graph g2 = new Graph(d);
            g2.DeclareNode(node1);
            g2.DeclareNode(node2);
            g2.DeclareNode(node3);
            g2.DeclareNode(node4);
            g2.DeclareNode(node5);
            g2.DeclareNode(node6);
            g2.DeclareNode(node7);
            g2.DeclarePolusInAllNodes(polus1);
            g2.AddEdge(node1, polus1, node4, polus1);
            g2.AddEdge(node1, polus1, node5, polus1);
            g2.AddEdge(node1, polus1, node6, polus1);
            g2.AddEdge(node2, polus1, node4, polus1);
            g2.AddEdge(node2, polus1, node7, polus1);
            g2.AddEdge(node3, polus1, node7, polus1);
            int[] p1 = new int[3];
            p1[0] = 0; p1[1] = 1; p1[2] = 2;
            int[] t1 = new int[4];
            t1[0] = 3; t1[1] = 4; t1[2] = 5; t1[3] = 6;
            l.Clear();
            l = StandartFunctions.MaxMatching(g2, p1, t1);
            st = null;
            foreach (Edge e in l)
            {
                st += Convert.ToString(StandartFunctions.GetNodeIndex(g2, e.nodefrom));
                st += Convert.ToString(StandartFunctions.GetNodeIndex(g2, e.nodeto));
            }

            if (st != "130426")
                throw new TestFailedException();
        }

        private static void TestMaxFlow()
        {
            Graph g = new Graph();
            CoreName n1 = new CoreName("s");
            CoreName n2 = new CoreName("a");
            CoreName n3 = new CoreName("b");
            CoreName n4 = new CoreName("t");
            g.DeclareNode(n1);
            g.DeclareNode(n2);
            g.DeclareNode(n3);
            g.DeclareNode(n4);
            CoreName polus1 = new CoreName("polus1");
            g.DeclarePolusInAllNodes(polus1);
            g.AddArc(n1, polus1, n2, polus1);
            g.AddArc(n1, polus1, n3, polus1);
            g.AddArc(n2, polus1, n3, polus1);
            g.AddArc(n2, polus1, n4, polus1);
            g.AddArc(n3, polus1, n4, polus1);
            List<Arc> l = new List<Arc>();
            Arc a;
            a.nodefrom = g[0]; a.nodeto = g[1]; a.inf = 5;
            l.Add(a);
            a.nodefrom = g[0]; a.nodeto = g[2]; a.inf = 4;
            l.Add(a);
            a.nodefrom = g[1]; a.nodeto = g[2]; a.inf = 3;
            l.Add(a);
            a.nodefrom = g[1]; a.nodeto = g[3]; a.inf = 3;
            l.Add(a);
            a.nodefrom = g[2]; a.nodeto = g[3]; a.inf = 7;
            l.Add(a);
            List<Arc> mf = new List<Arc>();
            mf = StandartFunctions.MaxFlow(g, g[0], g[3], l);
            string s = null;
            foreach (Arc arc in mf)
            {
                s += Convert.ToString(arc.inf);
            }
            if (s != "54236")
                throw new TestFailedException();

            int flowvalue = StandartFunctions.MaxFlowValue(g, g[0], g[3], l);
            if (flowvalue != 9)
                throw new TestFailedException();
        }

        private static void TestAssignProblem()
        {
            int[,] a = new int[2, 2];
            a[0, 0] = 6; a[0, 1] = 5;
            a[1, 0] = 7; a[1, 1] = 9;
            Graph G = new Graph();
            CoreName n1 = new CoreName("a");
            CoreName n2 = new CoreName("b");
            CoreName n3 = new CoreName("c");
            CoreName n4 = new CoreName("d");
            CoreName polus = new CoreName("polus1");
            G.DeclareNode(n1);
            G.DeclareNode(n2);
            G.DeclareNode(n3);
            G.DeclareNode(n4);
            G.DeclarePolusInAllNodes(polus);
            G.AddEdge(n1, polus, n3, polus);
            G.AddEdge(n2, polus, n3, polus);
            G.AddEdge(n1, polus, n4, polus);
            G.AddEdge(n2, polus, n4,polus);
            Matching matching = new Matching(G, a);
            List<Edge> l=new List<Edge>();
            l = matching.AssignNumber;
            string s = null;
            foreach (Edge edge in l)
            {
                s += Convert.ToString(StandartFunctions.GetNodeIndex(G, edge.nodeto));
            }
            if (s != "21")
                throw new TestFailedException();
        }

        /// <summary>
        /// тестирование функции нахождения сильно связных компонент графа
        /// </summary>
        private static void TestScc()
        {
            Graph g = new Graph();
            CoreName n1 = new CoreName("a");
            CoreName n2 = new CoreName("b");
            CoreName n3 = new CoreName("c");
            CoreName n4 = new CoreName("d");
            CoreName n5 = new CoreName("e");
            CoreName polus1 = new CoreName("polus1");
            g.DeclareNode(n1);
            g.DeclareNode(n2);
            g.DeclareNode(n3);
            g.DeclareNode(n4);
            g.DeclareNode(n5);
            g.DeclarePolusInAllNodes(polus1);
            g.AddArc(n1, polus1, n2, polus1);
            g.AddArc(n2, polus1, n3, polus1);
            g.AddArc(n3, polus1, n1, polus1);
            g.AddArc(n2, polus1, n4, polus1);
            g.AddEdge(n4, polus1, n5, polus1);
            int[] m = StandartFunctions.GetStronglyConnectedComponents(g);
            string s = null;
            for (int i = 0; i < m.Length; i++)
                s += Convert.ToString(m[i]);

            if (s != "11122")
                throw new TestFailedException();
        }

        private static void TestShortestPath()
        {
            //int NC=6;
             /*Matrix[0, 0] = 0;Matrix[0, 1] = 1;Matrix[0, 2] = 0;Matrix[0, 3] = 0;
            Matrix[0, 4] = 1;Matrix[0, 5] = 3;Matrix[1, 0] = 1;Matrix[1, 1] = 0;
            Matrix[1, 2] = 5;Matrix[1, 3] = 0;Matrix[1, 4] = 0;Matrix[1, 5] = 1;
            Matrix[2, 0] = 0;Matrix[2, 1] = 5;Matrix[2, 2] = 0;Matrix[2, 3] = 5;
            Matrix[2, 4] = 20;Matrix[2, 5] = 1;Matrix[3, 0] = 0;Matrix[3, 1] = 0;
            Matrix[3, 2] = 5;Matrix[3, 3] = 0;Matrix[3, 4] = 3;Matrix[3, 5] = 2;
            Matrix[4, 0] = 1;Matrix[4, 1] = 0;Matrix[4, 2] = 20;Matrix[4, 3] = 3;
            Matrix[4, 4] = 0;Matrix[4, 5] = 10;Matrix[5, 0] = 3;Matrix[5, 1] = 1;
            Matrix[5, 2] = 1;Matrix[5, 3] = 2;Matrix[5, 4] = 10;Matrix[5, 5] = 0;
            */
            //nf = 3, nt = 6 - null
            //nf = 0, nt = 2  Path-2 5 1 0. Lenght- 3

        }
    }
}
