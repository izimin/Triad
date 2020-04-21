using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using TriadCore;

namespace TriadNSim.Calculators
{
    public class BetweennessCentrality
    {
        public BetweennessCentrality()
        {
        }

        public void Calculate(Graph graph, out Dictionary<CoreName, Single> betweennessCentralities)
        {
            Debug.Assert(graph != null);

            _Calculate(graph, out betweennessCentralities);
        }

        protected void _Calculate(Graph oGraph, out Dictionary<CoreName, Single> oBetweennessCentralities)
        {
            Debug.Assert(oGraph != null);

            Int32 iNodes = oGraph.NodeCount;

            Boolean bGraphIsDirected = false;

            oBetweennessCentralities = new Dictionary<CoreName, Single>(iNodes);

            foreach (Node oNode in oGraph.Nodes)
            {
                oBetweennessCentralities.Add(oNode.Name, 0);
            }

            Stack<Node> S = new Stack<Node>();


            Dictionary<CoreName, LinkedList<Node>> P =
                new Dictionary<CoreName, LinkedList<Node>>();

            Dictionary<CoreName, Int32> sigma = new Dictionary<CoreName, Int32>();
            Dictionary<CoreName, Int32> d = new Dictionary<CoreName, Int32>();
            Queue<Node> Q = new Queue<Node>();
            Dictionary<CoreName, Single> delta = new Dictionary<CoreName, Single>();

            Int32 iCalculations = 0;
            Single MaximumCb = 0;

            foreach (Node s in oGraph.Nodes)
            {
                S.Clear();
                P.Clear();
                sigma.Clear();
                d.Clear();
                Q.Clear();
                delta.Clear();

                foreach (Node oNode in oGraph.Nodes)
                {
                    sigma.Add(oNode.Name, 0);
                    d.Add(oNode.Name, -1);
                    delta.Add(oNode.Name, 0);
                }

                sigma[s.Name] = 1;
                d[s.Name] = 0;
                Q.Enqueue(s);

                while (Q.Count > 0)
                {
                    Node v = Q.Dequeue();
                    S.Push(v);

                    foreach (Node w in StandartFunctions.GetAdjacentNodes(v))
                    {
                        if (d[w.Name] < 0)
                        {
                            Q.Enqueue(w);
                            d[w.Name] = d[v.Name] + 1;
                        }

                        if (d[w.Name] == d[v.Name] + 1)
                        {
                            sigma[w.Name] += sigma[v.Name];

                            LinkedList<Node> PofW;

                            if (!P.TryGetValue(w.Name, out PofW))
                            {
                                PofW = new LinkedList<Node>();
                                P.Add(w.Name, PofW);
                            }

                            PofW.AddLast(v);
                        }
                    }
                }

                while (S.Count > 0)
                {
                    Node w = S.Pop();

                    LinkedList<Node> PofW;

                    if (P.TryGetValue(w.Name, out PofW))
                    {
                        foreach (Node v in PofW)
                        {
                            Debug.Assert(sigma[w.Name] != 0);

                            delta[v.Name] +=
                                ((Single)sigma[v.Name] / (Single)sigma[w.Name])
                                * (1.0F + delta[w.Name]);
                        }
                    }

                    if (w.Name != s.Name)
                    {
                        Single CbOfW = oBetweennessCentralities[w.Name] + delta[w.Name];
                        MaximumCb = Math.Max(MaximumCb, CbOfW);
                        oBetweennessCentralities[w.Name] = CbOfW;
                    }
                }

                iCalculations++;
            }

            if (!bGraphIsDirected)
            {
                MaximumCb /= 2.0F;
            }

            foreach (Node oNode in oGraph.Nodes)
            {
                Single ThisCb;

                if (!oBetweennessCentralities.TryGetValue(oNode.Name, out ThisCb))
                {
                    Debug.Assert(false);
                }

                if (!bGraphIsDirected)
                {
                    ThisCb /= 2.0F;
                }

                if (MaximumCb != 0)
                {
                    ThisCb /= MaximumCb;
                }

                oBetweennessCentralities[oNode.Name] = ThisCb;
            }
        }
    }
}