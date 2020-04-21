using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TriadNSim.Forms
{
    public partial class ModifyRelation : Form
    {
        private List<Polus> ObjFromPoluses;
        private List<Polus> ObjToPoluses;

        public Boolean Success; 
        public Polus From;
        public Polus To;

        public ModifyRelation(Link oLink)
        {
            InitializeComponent();
            Success = false;
            NetworkObject oFrom = oLink.FromCP.Owner as NetworkObject;
            NetworkObject oTo = oLink.ToCP.Owner as NetworkObject;
            if (oFrom != null && oTo != null)
            {
                lblObj1Name.Text = oFrom.Name;
                lblObj2Name.Text = oTo.Name;
                Dictionary<string, bool> dictFrom = new Dictionary<string, bool>();
                Dictionary<string, bool> dictTo = new Dictionary<string, bool>();
                if (oFrom.Routine != null || oTo.Routine != null)
                {
                    foreach (object obj in oFrom.drawingPanel.Shapes)
                    {
                        if (obj is Link)
                        {
                            Link link = obj as Link;
                            if (link == oLink)
                                continue;
                            string polusName = link.FromCP.Owner == oFrom ? link.PolusFrom : (link.ToCP.Owner == oFrom ? link.PolusTo : null);
                            if (polusName != null && polusName != string.Empty)
                                dictFrom[polusName] = true;
                            polusName = link.FromCP.Owner == oTo ? link.PolusFrom : (link.ToCP.Owner == oTo ? link.PolusTo : null);
                            if (polusName != null && polusName != string.Empty)
                                dictTo[polusName] = true;
                        }
                    }
                }
                
                if (oFrom.Routine != null)
                {
                    ObjFromPoluses = oFrom.Routine.Poluses;
                    foreach (Polus polus in ObjFromPoluses)
                    {
                        if (!dictFrom.ContainsKey(polus.Name))
                            cmbObjFromPolus.Items.Add(polus.Name);
                    }
                }
                else
                {
                    ObjFromPoluses = null;
                    cmbObjFromPolus.Items.Add("?");
                }
                if (oTo.Routine != null)
                {
                    ObjToPoluses = oTo.Routine.Poluses;
                    foreach (Polus polus in ObjToPoluses)
                    {
                        if (!dictTo.ContainsKey(polus.Name))
                            cmbObjToPolus.Items.Add(polus.Name);
                    }
                }
                else
                {
                    ObjToPoluses = null;
                    cmbObjToPolus.Items.Add("?");
                }
                if (cmbObjFromPolus.Items.Count > 0)
                    cmbObjFromPolus.SelectedIndex = 0;
                if (cmbObjToPolus.Items.Count > 0)
                    cmbObjToPolus.SelectedIndex = 0;
                if (oLink.PolusFrom != null && oLink.PolusFrom.Length > 0)
                    cmbObjFromPolus.SelectedItem = oLink.PolusFrom;
                if (oLink.PolusFrom != null && oLink.PolusFrom.Length > 0)
                    cmbObjToPolus.SelectedItem = oLink.PolusTo;
                if (cmbObjFromPolus.Items.Count == 1 && cmbObjToPolus.Items.Count == 1)
                {
                    StorePoluses();
                    Success = true;
                }
            }
        }

        private void UpdateOKBtn()
        {
            if (cmbObjFromPolus.SelectedIndex >= 0 && cmbObjToPolus.SelectedIndex >= 0)
                btnOk.Enabled = true;
            else
                btnOk.Enabled = false;
        }

        private void cmbObj1OutPolus_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateOKBtn();
        }

        private void cmbObj2InPolus_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateOKBtn();
        }

        private void cmbObj2OutPolus_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateOKBtn();
        }

        private void cmbObjInPolus_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateOKBtn();
        }

        private void StorePoluses()
        {
            From = null;
            To = null;
            if (ObjFromPoluses != null)
            {
                foreach (Polus polus in ObjFromPoluses)
                {
                    if (polus.Name == (cmbObjFromPolus.SelectedItem as string))
                        From = polus;
                }
            }
            if (ObjToPoluses != null)
            {
                foreach (Polus polus in ObjToPoluses)
                {
                    if (polus.Name == (cmbObjToPolus.SelectedItem as string))
                        To = polus;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            StorePoluses();
            Success = true;
        }

        private void ModifyRelation_Load(object sender, EventArgs e)
        {

        }

    }
}
