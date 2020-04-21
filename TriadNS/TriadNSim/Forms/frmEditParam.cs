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

namespace TriadNSim.Forms
{
    public partial class frmEditParam : Form
    {
        private string[] descriptions;
        private int index = 0;
        private List<IExprType> parameters;
        public List<object> Values;
        public string[] Descriptions 
        {
            set
            {
                descriptions = value;
                txtDescription.Text = descriptions[index];
            }
            get
            {
                return descriptions;
            }
        }

        public frmEditParam(List<IExprType> parameters, List<object> paramValues = null)
        {
            InitializeComponent();
            btnCancel.CausesValidation = false;
            label1.Text = "";
            this.parameters = parameters;
            int lblX = panel1.Size.Width / 3;
            int top = 8;
            int ParamCount = parameters.Count;
            descriptions = new string[ParamCount];
            txtDescription.ReadOnly = paramValues != null;
            if (paramValues != null)
                Values = paramValues;
            else
            {
                Values = new List<object>();
                Values.AddRange(new object[ParamCount]);
            }
            Size sz = new Size(panel1.Size.Width / 3, 14);
            for (int i = 0; i < ParamCount; i++)
            {
                Label lbl = new Label();
                lbl.Text = parameters[i].Name + ":";
                lbl.Location = new Point(8, top);
                lbl.Size = sz;
                lbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
                //lbl.TabIndex = ;

                TextBox txt = new TextBox();
                txt.Location = new Point(sz.Width + 12, top);
                txt.Size = sz;
                if (Values[i] != null)
                    txt.Text = Values[i].ToString();

                panel1.Controls.Add(lbl);
                panel1.Controls.Add(txt);
                top += sz.Height + 12;
                txt.Tag = i;
                txt.GotFocus += new EventHandler(txt_GotFocus);
                txt.Validating += new CancelEventHandler(txt_Validating);
                //txt.Validated += new EventHandler(txt_Validated);
            }
        }

        void txt_Validated(object sender, EventArgs e)
        {
            //errorProvider1.SetError(sender as TextBox, "");
        }

        void txt_Validating(object sender, CancelEventArgs e)
        {
            CheckValue(sender as TextBox);
        }

        private bool CheckValue(TextBox txt)
        {
            int nIndex = (int)txt.Tag;
            if (!IsValid(txt.Text, parameters[nIndex].Code))
            {
                txt.SelectAll();
                errorProvider1.SetError(txt, parameters[nIndex].Code.ToString());
                return false;
            }
            errorProvider1.SetError(txt, "");
            return true;
        }

        private bool IsValid(string value, TriadCompiler.TypeCode code)
        {
            bool bRes = true;
            switch (code)
            {
                case TriadCompiler.TypeCode.Boolean:
                    {
                        bool bValue;
                        bRes = Boolean.TryParse(value, out bValue);
                    }
                    break;
                case TriadCompiler.TypeCode.Integer:
                    {
                        int nValue;
                        bRes = Int32.TryParse(value, out nValue);
                    }
                    break;
                case TriadCompiler.TypeCode.Real:
                    {
                        double dValue;
                        bRes = Double.TryParse(value, out dValue);
                    }
                    break;
            }
            return bRes;
        }

        void txt_GotFocus(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            int nIndex = (int)txt.Tag;
            lblDescription.Text = parameters[nIndex].Name;
            descriptions[index] = txtDescription.Text;
            txtDescription.Text = descriptions[nIndex];
            index = nIndex;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            descriptions[index] = txtDescription.Text;
            bool bRes = true;
            foreach (Control control in panel1.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txt = control as TextBox;
                    Values[(int)txt.Tag] = txt.Text;
                    if (!CheckValue(txt))
                        bRes = false;
                }
            }
            if (bRes)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
    }
}
