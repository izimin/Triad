using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TriadNSim.Ontology;

namespace TriadNSim.Forms
{
    public partial class frmRoutines : Form
    {
        IOWLClass nodeClass;
        IOWLClass routClass;
        Dictionary<ListViewItem, bool> internalObjects = new Dictionary<ListViewItem, bool>();

        public frmRoutines(IOWLClass nodeClass)
        {
            InitializeComponent();
            COWLOntologyManager ontologyManager = frmMain.Instance.OntologyManager;
            this.nodeClass = nodeClass;
            this.routClass = ontologyManager.GetRoutineClass(nodeClass);
            foreach (var indiv in ontologyManager.GetIndividuals(routClass))
            {
                IOWLClass cls = ontologyManager.GetIndividualClass(indiv);
                string sPath = ontologyManager.GetStrIndividualProp(indiv, ontologyManager.dataPropAssemblyPath);
                ListViewItem item = new ListViewItem(cls.Name);
                item.SubItems.Add(cls.Comment);
                lstRoutines.Items.Add(item);
                if (sPath == null || sPath.Length == 0)
                    internalObjects[item] = true;
            }
            if (lstRoutines.Items.Count > 0)
                lstRoutines.Items[0].Selected = true;
            else
                btnDelete.Enabled = false;
        }

        private void lstRoutines_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem item = lstRoutines.SelectedItems.Count > 0 ? lstRoutines.SelectedItems[0] : null;
            btnDelete.Enabled = item != null && !internalObjects.ContainsKey(item);
        }

        private void frmRoutines_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ListViewItem item = lstRoutines.SelectedItems[0];
            COWLOntologyManager manager = frmMain.Instance.OntologyManager;
            manager.RemoveClass(manager.GetClass(item.Text));
            manager.SaveOntology(frmMain.sOntologyPath);
            lstRoutines.Items.Remove(item);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            COWLOntologyManager manager = frmMain.Instance.OntologyManager;
            frmChangeRoutine frm = new frmChangeRoutine(frmMain.Instance.Panel);
            frm.OnNameChecked += delegate(object s, CancelEventArgs args)
            {
                if (manager.GetClass(frm.DesignTypeName) != null)
                    args.Cancel = true;
                else
                {
                    foreach (ListViewItem item in lstRoutines.Items)
                    {
                        if (item.Text.Equals(frm.DesignTypeName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            args.Cancel = true;
                            break;
                        }
                    }
                }
            };
            string sCode = "routine R" + nodeClass.Name + "(InOut pol)\nendrout";
            frm.SetObject(null);
            frm.Code = sCode;
            frm.ShowDialog();
            if (frm.Successed)
            {
                manager.AddInstance(routClass, frm.ResultRoutine);
                manager.SaveOntology(frmMain.sOntologyPath);
                frmChangeRoutine.SaveLastCompiledRoutine(frm.ResultRoutine.Name + ".dll");
                ListViewItem item = new ListViewItem(frm.ResultRoutine.Name);
                lstRoutines.Items.Add(item);
            }
        }
    }
}
