using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using TriadCore;

namespace TriadNSim.Calculators
{
    public class EigenvectorCentrality
    {
        public EigenvectorCentrality()
        {}

        public void Calculate(Graph graph, out Dictionary<CoreName, Double> eigenvectorCentralities)
        {
            Debug.Assert(graph != null);

            _Calculate(graph, out eigenvectorCentralities);

        }

        protected void _Calculate(Graph oGraph, out Dictionary<CoreName, Double> oEigenvectorCentralities)
        {
            Debug.Assert(oGraph != null);

            Int32 iNodes = oGraph.NodeCount;

            oEigenvectorCentralities =
                new Dictionary<CoreName, Double>(iNodes);

            Int32[,] aiMatrix =  new Int32[iNodes, iNodes];
            aiMatrix = StandartFunctions.GetMatrix(oGraph);

            Double dLambda = -1;
            Double dNewLambda = -1;
            Double[] adE = new Double[iNodes];
            Int32 i;

            for (i = 0; i < iNodes; i++)
            {
                adE[i] = 1;
            }

            Int32 iIterations = 0;

            while (true)
            {
                if (iIterations == MaximumIterations)
                {
                    break;
                }

                if (iIterations >= 2)
                {
                    if (
                        dLambda == 0
                        ||
                        ((100.0 * Math.Abs(dNewLambda - dLambda)) / dLambda)
                            <= LambdaDifferencePercentForEquality
                        )
                    {
                        break;
                    }
                }

                dLambda = dNewLambda;

                dNewLambda = Steps1To3(oGraph, adE, aiMatrix);

                iIterations++;
            }

            i = 0;
            foreach (Node oNode in oGraph.Nodes)
            {
                oEigenvectorCentralities.Add(oNode.Name, adE[i]);
                i++;
            }
        }

        protected Double Steps1To3 (Graph oGraph, Double[] adE, Int32[,] aiMatrix)
        {
            Debug.Assert(oGraph != null);
            Debug.Assert(adE != null);

            Int32 iNodes = oGraph.NodeCount;
            Double[] adEStar = new Double[iNodes];
            Int32 i = 0;
            Int32 j = 0;

            // шаг 1
            foreach (Node oNodeI in oGraph.Nodes)
            {
                Double dEiStar = 0;
                j = 0;

                foreach (Node oNodeJ in oGraph.Nodes)
                {
                    if (i != j && aiMatrix[i,j] == 1)
                    {
                        dEiStar += adE[j];
                    }

                    j++;
                }

                adEStar[i] = dEiStar;
                i++;
            }

            //шаг 2
            Double dLambda = 0;

            for (i = 0; i < iNodes; i++)
            {
                dLambda += Math.Pow(adEStar[i], 2);
            }

            dLambda = Math.Sqrt(dLambda);

            //шаг 3
            for (i = 0; i < iNodes; i++)
            {
                if (dLambda != 0)
                {
                    adE[i] = adEStar[i] / dLambda;
                }
                else
                {
                    adE[i] = 0;
                }
            }

            return (dLambda);
        }

        protected const Double LambdaDifferencePercentForEquality = 0.0001;
        protected const Int32 MaximumIterations = 100;

    }
}
