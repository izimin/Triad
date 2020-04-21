using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using TriadCompiler;
using TriadNSim.Ontology;

namespace TriadNSim.Forms
{
    public partial class frmEditPolus : Form
    {
        private int index = 0;
        private List<Polus> poluses;
        Dictionary<string, string> routineNames;
        ToolTip toolTip;

        public frmEditPolus(Routine rout)
        {
            InitializeComponent();
            this.poluses = rout.Poluses;
            int lblX = panel1.Size.Width / 3;
            int top = 8;
            int PolusCount = poluses.Count;
            toolTip = new ToolTip();

            COWLOntologyManager ontologyManager = frmMain.Instance.OntologyManager;
            IOWLClass superClass = ontologyManager.GetClass("ComputerNetworkRoutine");
            List<IOWLClass> routines = ontologyManager.GetSubClasses(superClass);
            routines.Insert(0, superClass);
            routineNames = new Dictionary<string, string>();
            string[] items = new string[routines.Count + 1];
            for (int i = 0, nCount = routines.Count; i < nCount; i++)
            {
                IOWLClass item = routines[i];
                string sItemName = item.Comment;
                if (sItemName.Trim().Length == 0)
                    sItemName = item.Name;
                routineNames[sItemName] = item.Name;
                items[i] = sItemName;
            }
            items[routines.Count] = rout.Name;
            routineNames[rout.Name] = rout.Name;

            Size sz = new Size(panel1.Size.Width / 2 + 10, 14);
            Size szLbl = new Size(44, 14);
            for (int i = 0; i < PolusCount; i++)
            {
                Label lbl = new Label();
                lbl.Text = poluses[i].Name + ":";
                lbl.Location = new Point(8, top);
                lbl.Size = szLbl;
                lbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
                //lbl.TabIndex = ;

                ComboBox cmb = new ComboBox();
                cmb.Location = new Point(szLbl.Width + 12, top);
                cmb.Size = sz;
                cmb.Items.AddRange(items);
                cmb.DropDownStyle = ComboBoxStyle.DropDownList;
                cmb.Tag = i;
                cmb.DrawMode = DrawMode.OwnerDrawFixed;
                cmb.DrawItem += cmb_DrawItem;
                cmb.DropDownClosed += cmb_DropDownClosed;
                cmb.SelectedIndex = 0;

                CheckBox chk = new CheckBox();
                chk.Location = new Point(szLbl.Width + sz.Width + 20, top + 4);
                chk.AutoSize = true;
                chk.Checked = true;
                chk.Tag = i;

                panel1.Controls.Add(lbl);
                panel1.Controls.Add(cmb);
                panel1.Controls.Add(chk);
                top += sz.Height + 12;
            }
        }

        private void cmb_DropDownClosed(object sender, EventArgs e)
        {
            toolTip.Hide(sender as ComboBox);
        }

        private void cmb_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            string text = cmb.GetItemText(cmb.Items[e.Index]);
            e.DrawBackground();
            using (SolidBrush br = new SolidBrush(e.ForeColor))
            { 
                e.Graphics.DrawString(text, e.Font, br, e.Bounds); 
            }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                SizeF sz = e.Graphics.MeasureString(text, e.Font);
                if (sz.Width > e.Bounds.Width)
                {
                    if (cmb.DroppedDown)
                    {
                        toolTip.SetToolTip(cmb, "");
                        toolTip.Show(text, cmb, e.Bounds.Right, e.Bounds.Bottom);
                    }
                    else if (toolTip.GetToolTip(cmb) == "")
                        toolTip.SetToolTip(cmb, text);
                }
                else
                    toolTip.Hide(cmb);
            }
            e.DrawFocusRectangle();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (Control control in panel1.Controls)
            {
                if (control is ComboBox)
                {
                    ComboBox cmb = control as ComboBox;
                    int nIndex = (int)cmb.Tag;
                    poluses[nIndex].CanConnectedWith = routineNames[cmb.SelectedItem.ToString()];
                }
                else if (control is CheckBox)
                {
                    CheckBox chk = control as CheckBox;
                    int nIndex = (int)chk.Tag;
                    poluses[nIndex].IsRequired = chk.Checked;
                }
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
