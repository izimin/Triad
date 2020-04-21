using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using TriadCore;

namespace TriadNSim.Calculators
{
    public class ClosenessCentrality
    {
        public ClosenessCentrality()
        {
        }

        public void Calculate(Graph graph, out Dictionary<CoreName, Double> closenessCentralities)
        {
            Debug.Assert(graph != null);

            _Calculate(graph, out closenessCentralities);
        }

        protected void _Calculate(Graph oGraph, out Dictionary<CoreName, Double> oClosenessCentralities)
        {
            Debug.Assert(oGraph != null);

            oClosenessCentralities = new Dictionary<CoreName, Double>(oGraph.NodeCount);

            UInt16[,] aui16AllPairsShortestPathLengths;

            (new AllShortestPathCalculator()).Calculate(oGraph, out aui16AllPairsShortestPathLengths);

            //вычисляем ClosenessCentrality
            Int32 i = 0;

            foreach (Node oNodeI in oGraph.Nodes)
            {
                Int32 j = 0;
                Int32 iPathLengthSum = 0;
                Int32 iOtherVerticesInConnectedComponent = 0;

                foreach (Node oNodeJ in oGraph.Nodes)
                {
                    if (i != j)
                    {
                        UInt16 ui16PathLength =
                            aui16AllPairsShortestPathLengths[i, j];

                        if (ui16PathLength != UInt16.MaxValue)
                        {
                            iPathLengthSum += ui16PathLength;
                            iOtherVerticesInConnectedComponent++;
                        }
                    }

                    j++;
                }

                Double dClosenessCentrality;

                if (iOtherVerticesInConnectedComponent == 0)
                {
                    dClosenessCentrality = 0;
                }
                else
                {
                    dClosenessCentrality = (Double)iPathLengthSum /
                        (Double)iOtherVerticesInConnectedComponent;
                }

                oClosenessCentralities.Add(oNodeI.Name, dClosenessCentrality);

                i++;
            }
        }
    }
}
