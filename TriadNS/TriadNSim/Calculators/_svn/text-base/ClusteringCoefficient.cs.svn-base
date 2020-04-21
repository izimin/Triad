using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using TriadCore;

namespace TriadNSim.Calculators
{
    public class ClusteringCoefficient
    {
        public ClusteringCoefficient()
        {
        }

        public void Calculate(Graph graph, out Dictionary<CoreName, double> clusteringCoefficients)
        {
            Debug.Assert(graph != null);

            _Calculate(graph, out clusteringCoefficients);
        }

        private void _Calculate(Graph graph, out Dictionary<CoreName, double> ClusteringCoefficients)
        {
            Debug.Assert(graph != null);

            int iNodes = graph.NodeCount;

           ClusteringCoefficients =
                new Dictionary<CoreName, double>(iNodes);

            foreach (Node node in graph.Nodes)
            {
                ClusteringCoefficients.Add(node.Name,
                    CalculateClusteringCoefficient(node));
            }
        }

        protected double CalculateClusteringCoefficient(Node node)
        {
            Debug.Assert(node != null);

            Set AdjacentNodes = StandartFunctions.GetAdjacentNodes(node);
            int iAdjacentNodes = 0;
            CoreName NodeName = node.Name;

            Dictionary<CoreName, Char> AdjacentNodesDictionary =
                new Dictionary<CoreName, Char>();

            foreach (Node AdjacentNode in AdjacentNodes)
            {
                CoreName AdjNodeName = AdjacentNode.Name;
                if (NodeName == AdjNodeName)
                    continue;

                AdjacentNodesDictionary.Add(AdjNodeName, ' ');

                iAdjacentNodes++;
            }

            if (iAdjacentNodes == 0)
                return (0);

            Dictionary<CoreName, Char> EdgesInNeighborhoodDictionary =
                new Dictionary<CoreName, Char>();

            foreach (Node AdjacentNode in AdjacentNodes)
            {
                if (NodeName == AdjacentNode.Name)
                    continue;

                foreach (Edge IncidentEdge in StandartFunctions.GetIncidentEdges(AdjacentNode))
                {
                    if (AdjacentNodesDictionary.ContainsKey(
                        StandartFunctions.GetEdgeAdjacentNode(IncidentEdge, AdjacentNode).Name))
                    {
                        EdgesInNeighborhoodDictionary[new CoreName(IncidentEdge.nodefrom.Name.BaseName + IncidentEdge.nodeto.Name.BaseName)] = ' ';
                    }
                }
            }

            double dNumerator = (double)EdgesInNeighborhoodDictionary.Count;

            Debug.Assert(iAdjacentNodes > 0);

            double dDenominator = CalculateEdgesInFullyConnectedNeighborhood(
                iAdjacentNodes, true);

            if (dDenominator == 0)
            {
                return (0);
            }

            return (dNumerator / dDenominator);
        }

        protected int CalculateEdgesInFullyConnectedNeighborhood(int iAdjacentNodes, bool bGraphIsDirected)
        {
            Debug.Assert(iAdjacentNodes >= 0);

            return ((iAdjacentNodes * (iAdjacentNodes - 1)) /
                (bGraphIsDirected ? 1 : 2));
        }
    }
}
