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
    public partial class frmAddElement : Form
    {
        private List<string> parentNames;
        private COWLOntologyManager ontologyManager;
        public string Name;
        public string ParentName;
        private Bitmap _bmp = null;

        public Bitmap Bmp
        {
            get
            {
                return _bmp;
            }
            set
            {
                if (value != null)
                {
                    _bmp = value;
                    pictureBox1.Image = value;
                }
            }
        }

        public frmAddElement()
        {
            InitializeComponent();
            parentNames = new List<string>();
            ontologyManager = frmMain.Instance.OntologyManager;
            string sSuperClassName = "ComputerNetworkNode";
            cmbParent.Items.Add(ontologyManager.GetClass(sSuperClassName).Comment);
            parentNames.Add(sSuperClassName);
            List<IOWLClass> elements = ontologyManager.GetComputerNetworkElements();
            foreach (IOWLClass elem in elements)
            {
                string sElementName = elem.Comment.Trim();
                if (sElementName.Length == 0)
                    sElementName = elem.Name;
                cmbParent.Items.Add(sElementName);
                parentNames.Add(elem.Name);
            }
            cmbParent.SelectedIndex = 0;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            string sName = txtName.Text.Trim();
            if (sName.Length == 0 || frmMain.Instance.ContainsElement(sName))
            {
                Util.ShowErrorBox("Недопустимое имя");
                txtName.Focus();
                txtName.SelectAll();
                return;
            }
            Name = sName;
            ParentName = parentNames[cmbParent.SelectedIndex];
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Bmp = frmMain.LoadImage("Изображение элемента");
        }

    }
}
