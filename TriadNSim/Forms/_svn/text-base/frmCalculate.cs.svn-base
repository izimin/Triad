using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DrawingPanel;
using TriadCore;
using TriadNSim.Calculators;
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace TriadNSim.Forms
{
    public partial class frmCalculate : Form
    {
        public frmCalculate(DrawingPanel.DrawingPanel panel)
        {
            InitializeComponent();
            drawingPanel = panel;
            ArrayList array = drawingPanel.Shapes;
            foreach (BaseObject obj in array)
            {
                if (obj is NetworkObject)
                {
                    cmbPathTo.Items.Add(obj.Name);
                    cmbPathFrom.Items.Add(obj.Name);
                }
            }
            if (cmbPathTo.Items.Count < 2)
            {
                checkShortestPath.Enabled = false;
                checkAllShortestPath.Enabled = false;
            }
            else
            {
                cmbPathTo.SelectedIndex = 0;
                cmbPathFrom.SelectedIndex = 1;
                checkAllShortestPath.Checked = true;
                checkShortestPath.Checked = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkShortestPath.Checked)
            {
                cmbPathTo.Enabled = true;
                cmbPathFrom.Enabled = true;
            }
            else
            {
                cmbPathTo.Enabled = false;
                cmbPathFrom.Enabled = false;
            }   
        }

        private bool IsAllUnselected()
        {
            return (IsAllVertexPropertiesUnselected() && !checkShortestPath.Checked && !checkOverallProperties.Checked);
        }

        private bool IsAllVertexPropertiesUnselected()
        {
            return (!checkDegree.Checked && !checkSCC.Checked && !checkClusteringCoefficient.Checked && IsAllCentralityUnselected());
        }
        
        private bool IsAllCentralityUnselected()
        {
            return (!checkDegreeCentrality.Checked && !checkBetweennessCentrality.Checked && !checkClosenessCentrality.Checked && !checkEigenvectorCentrality.Checked);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (IsAllUnselected())
            {
                Util.ShowErrorBox("Ничего не выделено");
                return;
            }
            Cursor = Cursors.WaitCursor;
            try
            {
                ToExcel();
            }
            catch
            {
                Util.ShowErrorBox("Ошибка создания отчета в Excel");
            }
            Cursor = Cursors.Default;
            Visible = false;
            GC.Collect();
            DialogResult = DialogResult.OK;
        }

        private void ToExcel()
        {
            Graph oGraph = new Graph();
            List<NetworkObject> lstObjects = new List<NetworkObject>();
            List<Link> lstLinks = new List<Link>();
            foreach (BaseObject obj in drawingPanel.Shapes)
            {
                if (obj is NetworkObject)
                {
                    oGraph.DeclareNode(new CoreName(obj.Name));
                    lstObjects.Add(obj as NetworkObject);
                }
                else if (obj is Link)
                    lstLinks.Add(obj as Link);
            }
            CoreName polus = new CoreName("p1");
            oGraph.DeclarePolusInAllNodes(polus);
            foreach (Link link in lstLinks)
            {
                oGraph.AddEdge(new CoreName(link.FromCP.Owner.Name), polus, new CoreName(link.ToCP.Owner.Name), polus);
            }

            Microsoft.Office.Interop.Excel.Application oExcelApplication = new Microsoft.Office.Interop.Excel.Application();
            object oMissing = Missing.Value;
            Workbook oBook = oExcelApplication.Workbooks.Add(oMissing);
            Worksheet oSheet;
            Range oRng;
            int iSheets = 0;
            if (checkOverallProperties.Checked)
            {
                iSheets++;
                int iDiameter = StandartFunctions.GetGraphDiameter(oGraph);

                oSheet = oBook.Sheets.get_Item(iSheets) as Worksheet;
                oSheet.Name = "Общие хар-ки";
                oSheet.Cells[1, 1] = "Хар-ка";
                oSheet.Cells[1, 2] = "Значение";
                oRng = oSheet.get_Range(oSheet.Cells[1, 1], oSheet.Cells[1, 2]);
                oRng.Font.Color = 16711680; //blue
                oRng.Font.Bold = true;

                oSheet.Cells[2, 1] = "Кол-во ребер";
                oSheet.Cells[2, 2] = lstLinks.Count;
                oSheet.Cells[3, 1] = "Кол-во вершин";
                oSheet.Cells[3, 2] = lstObjects.Count;
                oSheet.Cells[4, 1] = "Плотность";
                double density = (2 * lstLinks.Count / (lstObjects.Count * (lstObjects.Count - 1) * 1.0f)); // для ориентиров надо еще /  на 2
                oSheet.Cells[4, 2] = lstLinks.Count > 0 ? density : 0;
                oSheet.Cells[5, 1] = "Диаметр";
                oSheet.Cells[5, 2] = iDiameter;
                (oSheet.Cells[1, 1] as Range).AutoFilter(1, oMissing, XlAutoFilterOperator.xlAnd, oMissing, oMissing);
                (oSheet.get_Range(oSheet.Cells[1, 1], oSheet.Cells[5, 2]) as Range).Columns.AutoFit();
            }

            if (!IsAllVertexPropertiesUnselected())
            {
                iSheets++;
                int[] aiNodeDegree = null;
                if (checkDegree.Checked || checkDegreeCentrality.Checked)
                {
                    aiNodeDegree = new int[oGraph.NodeCount];
                    for (int i = 0; i < oGraph.NodeCount; i++)
                    {
                        if (checkDegree.Checked || checkDegreeCentrality.Checked)
                            aiNodeDegree[i] = StandartFunctions.GetNodeDegree(oGraph[i]);
                    }
                }

                int[] aiScc = null;
                if (checkSCC.Checked)
                    aiScc = StandartFunctions.GetStronglyConnectedComponents(oGraph);

                Dictionary<CoreName, Double> oClusteringCoefficients = null;
                if (checkClusteringCoefficient.Checked)
                    (new ClusteringCoefficient()).Calculate(oGraph, out oClusteringCoefficients);
                
                Dictionary<CoreName, Single> oBetweennessCentralities = null;
                if (checkBetweennessCentrality.Checked)
                    (new BetweennessCentrality()).Calculate(oGraph, out oBetweennessCentralities);

                Dictionary<CoreName, Double> oClosenessCentralities = null;
                if (checkClosenessCentrality.Checked)
                    (new ClosenessCentrality()).Calculate(oGraph, out oClosenessCentralities);

                Dictionary<CoreName, Double> oEigenvectorCentralities = null;
                if (checkEigenvectorCentrality.Checked)
                    (new EigenvectorCentrality()).Calculate(oGraph, out oEigenvectorCentralities);

                oSheet = oBook.Sheets.get_Item(iSheets) as Worksheet;
                oSheet.Name = "Хар-ки вершин";
                oSheet.Cells[1, 1] = "Вершина";
                int iMaxCol = 1;
                int iDegreeCol, iSccCol, iClusteringCoeffCol, iDegreeCentralityCol,
                    iBetweennessCentralityCol, iClosenessCentralityCol, iEigenvectorCentralityCol;
                iDegreeCol = iSccCol = iClusteringCoeffCol = -1;
                iDegreeCentralityCol = iBetweennessCentralityCol = iClosenessCentralityCol = iEigenvectorCentralityCol = -1;
                if (checkDegree.Checked)
                {
                    iMaxCol++;
                    iDegreeCol = iMaxCol;
                    oSheet.Cells[1, iMaxCol] = "Степень";
                }
                if (checkSCC.Checked)
                {
                    iMaxCol++;
                    iSccCol = iMaxCol;
                    oSheet.Cells[1, iMaxCol] = "№ Сильно связной компоненты";
                }
                if (checkClusteringCoefficient.Checked)
                {
                    iMaxCol++;
                    iClusteringCoeffCol = iMaxCol;
                    oSheet.Cells[1, iMaxCol] = "Коэффициент кластеризации";
                }
                if (checkDegreeCentrality.Checked)
                {
                    iMaxCol++;
                    iDegreeCentralityCol = iMaxCol;
                    oSheet.Cells[1, iMaxCol] = "Degree Centrality";
                }
                if (checkBetweennessCentrality.Checked)
                {
                    iMaxCol++;
                    iBetweennessCentralityCol = iMaxCol;
                    oSheet.Cells[1, iMaxCol] = "Betweenness Centrality";
                }
                if (checkClosenessCentrality.Checked)
                {
                    iMaxCol++;
                    iClosenessCentralityCol = iMaxCol;
                    oSheet.Cells[1, iMaxCol] = "Closeness Centrality";
                }
                if (checkEigenvectorCentrality.Checked)
                {
                    iMaxCol++;
                    iEigenvectorCentralityCol = iMaxCol;
                    oSheet.Cells[1, iMaxCol] = "Eigenvector Centrality";
                }
                oRng = oSheet.get_Range(oSheet.Cells[1, 1], oSheet.Cells[1, iMaxCol]);
                oRng.Font.Color = 16711680;
                oRng.Font.Bold = true;
                for (int i = 0; i < lstObjects.Count; i++)
                {
                    oSheet.Cells[2 + i, 1] = lstObjects[i].Name;
                    if (iDegreeCol > 0)
                        oSheet.Cells[2 + i, iDegreeCol] = aiNodeDegree[i];
                    if (iClusteringCoeffCol > 0)
                        oSheet.Cells[2 + i, iClusteringCoeffCol] = oClusteringCoefficients[new CoreName(lstObjects[i].Name)];
                    if (iDegreeCentralityCol > 0)
                    {
                        double dDegreeCentrality = 0;
                        if (lstObjects.Count > 1)
                            dDegreeCentrality = aiNodeDegree[i] / ((lstObjects.Count - 1) * 1.0f);
                        oSheet.Cells[2 + i, iDegreeCentralityCol] = dDegreeCentrality;
                    }
                    if (iBetweennessCentralityCol > 0)
                        oSheet.Cells[2 + i, iBetweennessCentralityCol] = oBetweennessCentralities[new CoreName(lstObjects[i].Name)];
                    if (iClosenessCentralityCol > 0)
                        oSheet.Cells[2 + i, iClosenessCentralityCol] = oClosenessCentralities[new CoreName(lstObjects[i].Name)];
                    if (iEigenvectorCentralityCol > 0)
                        oSheet.Cells[2 + i, iEigenvectorCentralityCol] = oEigenvectorCentralities[new CoreName(lstObjects[i].Name)];
                    if (iSccCol > 0)
                        oSheet.Cells[2 + i, iSccCol] = aiScc[i];
                }
                (oSheet.Cells[1, 1] as Range).AutoFilter(1, oMissing, XlAutoFilterOperator.xlAnd, oMissing, oMissing);
                oRng.Columns.AutoFit();
            }
            if (checkAllShortestPath.Checked || checkShortestPath.Checked)
            {
                iSheets++;
                CoreName NodeFrom = new CoreName(cmbPathTo.SelectedItem as string);
                CoreName NodeTo = new CoreName(cmbPathFrom.SelectedItem as string);
                Set shpath = StandartFunctions.FindShortestPath(oGraph, oGraph[NodeFrom], oGraph[NodeTo]);

                oSheet = oBook.Sheets.get_Item(iSheets) as Worksheet;
                oSheet.Name = "Кр. путь";
                
                if (checkShortestPath.Checked)
                {
                    oSheet.Cells[1, 1] = "Кратчайший путь между " + NodeFrom.BaseName + " и " + NodeTo.BaseName + ":";
                    oRng = oSheet.get_Range(oSheet.Cells[1, 1], oSheet.Cells[1, 7]);
                    oRng.Merge(oMissing);
                    oRng.Font.Color = 16711680;
                    oRng.Font.Bold = true;
                    oRng.Columns.AutoFit();
                    int iMaxCol = 0;
                    foreach (Node node in shpath)
                    {
                        iMaxCol++;
                        oSheet.Cells[2, iMaxCol] = node.Name.BaseName;
                    }
                    if (shpath.Size == 0)
                    {
                        iMaxCol++;
                        oSheet.Cells[2, iMaxCol] = "Такого пути нет";
                    }
                }

                if (checkAllShortestPath.Checked)
                {
                    int iRow = 1;
                    if (checkShortestPath.Checked)
                        iRow = 4;
                    oSheet.Cells[iRow, 1] = "Кратчайшие расстояния между всеми элментами";
                    oRng = oSheet.get_Range(oSheet.Cells[iRow, 1], oSheet.Cells[iRow, 7]);
                    oRng.Merge(oMissing);
                    oRng.Font.Color = 16711680;
                    oRng.Font.Bold = true;
                    oRng.Columns.AutoFit();

                    UInt16[,] aui16AllPairsShortestPathLengths;
                    (new AllShortestPathCalculator()).Calculate(oGraph, out aui16AllPairsShortestPathLengths);

                    Int32 i = 0;
                    foreach (Node oNodeI in oGraph.Nodes)
                    {
                        Int32 j = 0;
                        foreach (Node oNodeJ in oGraph.Nodes)
                        {
                            UInt16 ui16Path = aui16AllPairsShortestPathLengths[i, j];
                            if (ui16Path == UInt16.MaxValue)
                                ui16Path = 0;
                            oSheet.Cells[i + iRow + 2, j + 2] = ui16Path;
                            j++;
                            if (i == 0)
                            {
                                oSheet.Cells[iRow + 1, j + 1] = oNodeJ.Name.BaseName;
                            }
                        }
                        i++;
                        oSheet.Cells[i + iRow + 1, 1] = oNodeI.Name.BaseName;
                    }
                }

                oRng = oSheet.get_Range(oSheet.Cells[1, 1], oSheet.Cells[oGraph.NodeCount+ 1, oGraph.NodeCount + 1]);
                oRng.Columns.AutoFit();
            }

            oExcelApplication.Visible = true;
            oRng = null;
            oSheet = null;
            oBook = null;
            oExcelApplication = null;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            checkDegree.Checked = true;
            checkOverallProperties.Checked = true;
            checkClusteringCoefficient.Checked = true;
            if (checkShortestPath.Enabled)
                checkShortestPath.Checked = true;
            if (checkAllShortestPath.Enabled)
                checkAllShortestPath.Checked = true;
            checkSCC.Checked = true;
            checkDegreeCentrality.Checked = true;
            checkBetweennessCentrality.Checked = true;
            checkClosenessCentrality.Checked = true;
            checkEigenvectorCentrality.Checked = true;
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            checkDegree.Checked = false;
            checkOverallProperties.Checked = false;
            checkClusteringCoefficient.Checked = false;
            if (checkShortestPath.Enabled)
                checkShortestPath.Checked = false;
            if (checkAllShortestPath.Enabled)
                checkAllShortestPath.Checked = false;
            checkSCC.Checked = false;
            checkDegreeCentrality.Checked = false;
            checkBetweennessCentrality.Checked = false;
            checkClosenessCentrality.Checked = false;
            checkEigenvectorCentrality.Checked = false;
        }

        private DrawingPanel.DrawingPanel drawingPanel;
    }
}
