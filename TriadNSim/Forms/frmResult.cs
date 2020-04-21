using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TriadNSim.Forms
{
    public partial class frmResult : Form
    {
        public frmResult()
        {
            InitializeComponent();
        }

        public void Fill()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView1.Rows.Add(TriadCore.Logger.Instance.Records.Count);
            int nIndex = 0;
            foreach (TriadCore.LoggerRecord record in TriadCore.Logger.Instance.Records)
            {
                DataGridViewRow row = dataGridView1.Rows[nIndex];
                row.Cells[0].Value = record.SystemTime;
                row.Cells[1].Value = record.ObjectName;
                row.Cells[2].Value = record.Message;
                nIndex++;
            }
            if (Simulation.Instance.IPResults.Count > 0)
            {
                dataGridView2.Rows.Add(Simulation.Instance.IPResults.Count);
                nIndex = 0;
                foreach (IPResult ipRes in Simulation.Instance.IPResults)
                {
                    DataGridViewRow row = dataGridView2.Rows[nIndex];
                    row.Cells[0].Value = ipRes.Name;
                    row.Cells[1].Value = ipRes.SpyObject.Name;
                    row.Cells[2].Value = ipRes.Result.ToString();
                    string strDescription = "Number of processed messages";
                    if (ipRes.Description.Contains("потер"))
                        strDescription = "Number of lost messages";
                    //row.Cells[3].Value = ipRes.Description;
                    row.Cells[3].Value = strDescription;
                    nIndex++;
                }
                splitContainer1.Panel2Collapsed = false;
            }
            else
                splitContainer1.Panel2Collapsed = true;
        }

        private void frmResult_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
