using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using TriadCore;

namespace TriadNSim.Calculators
{
    public class AllShortestPathCalculator
    {
        private const UInt16 infinity = UInt16.MaxValue;

        public AllShortestPathCalculator()
        {
        }

        public void Calculate(Graph graph, out UInt16[,] allPairsPathLengths)
        {
            Debug.Assert(graph != null);

            _Calculate(graph, out allPairsPathLengths);
        }

        protected void _Calculate(Graph oGraph, out UInt16[,] aui16AllPairsPathLengths)
        {
            Debug.Assert(oGraph != null);

            Int32 iNodes = oGraph.NodeCount;

            aui16AllPairsPathLengths = null;
            try
            {
                aui16AllPairsPathLengths = new UInt16[iNodes, iNodes];
            }
            catch (OutOfMemoryException)
            {
            }

            Int32 i = 0;
            Int32 j = 0;
            UInt16 ui16IJPathLength;

            foreach (Node oNodeI in oGraph.Nodes)
            {
                j = 0;

                foreach (Node oNodeJ in oGraph.Nodes)
                {
                    ui16IJPathLength = 0;
                    if (i != j)
                    {
                        ui16IJPathLength = (UInt16)StandartFunctions.FindShortestPath(oGraph, oNodeI, oNodeJ).Size;
                    }
                    if (ui16IJPathLength == 0)
                        ui16IJPathLength = infinity;
                    else
                        ui16IJPathLength--;
                    aui16AllPairsPathLengths[i, j] = ui16IJPathLength;

                    j++;
                }

                i++;
            }
        }
    }
}
