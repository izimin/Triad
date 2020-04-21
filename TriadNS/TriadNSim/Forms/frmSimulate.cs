using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TriadNSim.Ontology;
using System.Reflection;
using TriadCore;

namespace TriadNSim.Forms
{
    public partial class frmSimulate : Form
    {
        private SimulationInfo simInfo;

        public frmSimulate(SimulationInfo simInfo)
        {
            InitializeComponent();
            this.simInfo = simInfo;
            numericUpDown1.Maximum = Int32.MaxValue;
            numericUpDown1.Value = simInfo.TerminateTime;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;

            simInfo.TerminateTime = Convert.ToInt32(numericUpDown1.Value);

            if (checkedListBox1.CheckedItems.Count > 0)
            {
                COWLOntologyManager ontologyManager = frmMain.Instance.OntologyManager;
                List<string> references = new List<string>();
                foreach (var indiv in ontologyManager.GetIndividuals(ontologyManager.GetClass("ComputerNetworkRoutine")))
                {
                    Routine r = ontologyManager.CreateRoutine(indiv);
                    if (r.AssemblyPath.Length != 0)
                    {
                        references.Add(r.AssemblyPath);
                    }
                }

                foreach (InfProcedure iprocedure in frmMain.Instance.userIProcedures)
                {
                    references.Add(Application.StartupPath + "\\" + iprocedure.Name + ".dll");
                }

                foreach (int index in checkedListBox1.CheckedIndices)
                {
                    SimCondition simCond = frmMain.Instance.simConditions[index];
                    string sPath = Application.StartupPath + "\\" + frmChangeSimCondition.CompiledFileNameTxt;
                    frmChangeSimCondition.CompileTo(simCond.Code, sPath);
                    Assembly ass = frmMain.GenerateAssemblyFromFile(sPath, references.ToArray());
                    Type type = ass.GetTypes()[0];
                    ConstructorInfo construct = type.GetConstructors()[0];
                    ICondition iCondition = (ICondition)construct.Invoke(new object[] { simInfo.TerminateTime });
                    simInfo.SimContitons.Add(iCondition);
                }
            }
            Close();
        }

        private void frmSimulate_Load(object sender, EventArgs e)
        {
            foreach (var simCond in frmMain.Instance.simConditions)
            {
                string sName = simCond.Description;
                if (sName.Length > 0)
                    sName += " ( " + simCond.Name + " )";
                else
                    sName = simCond.Name;
                checkedListBox1.Items.Add(sName);
            }
        }
    }
}
