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
    public partial class frmIConditions : Form
    {
        public frmIConditions()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmChangeSimCondition frmSimCond = new frmChangeSimCondition();
            string sNewSimCond = "simcondition IC[real terminateTime]\ndef\nif SystemTime >= terminateTime then\neor\nendif\nendcond";
            frmSimCond.Code = sNewSimCond;
            frmSimCond.ShowDialog();
            if (frmSimCond.Successed)
            {
                SimCondition simCond = new SimCondition();
                simCond.Code = frmSimCond.Code;
                simCond.Name = frmSimCond.DesignTypeName;
                simCond.Description = frmSimCond.Description;
                AddSimCondition(simCond);
                frmMain.Instance.simConditions.Add(simCond);
                frmMain.Instance.SaveSimConditions();
            }
        }

        private void AddSimCondition(SimCondition simCond)
        {
            ListViewItem item = new ListViewItem();
            item.Text = simCond.Name;
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, simCond.Description));
            listViewIC.Items.Add(item);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmChangeSimCondition frmSimCond = new frmChangeSimCondition();
            int nIndex = listViewIC.SelectedItems[0].Index;
            string sName = listViewIC.SelectedItems[0].Text;
            SimCondition EditSimCond = frmMain.Instance.GetSimCondition(sName);
            frmSimCond.SetSimCondition(EditSimCond);
            frmSimCond.ShowDialog();
            if (frmSimCond.Successed)
            {
                EditSimCond.Name = listViewIC.Items[nIndex].Text = frmSimCond.DesignTypeName;
                EditSimCond.Description = listViewIC.Items[nIndex].SubItems[1].Text = frmSimCond.Description;
                EditSimCond.Code = frmSimCond.Code;
                frmMain.Instance.SaveSimConditions();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int nIndex = listViewIC.SelectedItems[0].Index;
            frmMain.Instance.DeleteSimCondition(listViewIC.SelectedItems[0].Text);
            listViewIC.Items.RemoveAt(nIndex);
        }

        private void frmIConditions_Load(object sender, EventArgs e)
        {
            foreach (var simCond in frmMain.Instance.simConditions)
                AddSimCondition(simCond);
        }
    }
}
