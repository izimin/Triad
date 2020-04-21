using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DrawingPanel
{
    public partial class PrintPreviewFrm : Form
    {
        public PrintPreviewFrm()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.docToPrint.Print();
        }

        private void On_Resize(object sender, EventArgs e)
        {
            this.PrintPreviewControl1.Width = this.Width - 10;
            this.PrintPreviewControl1.Height = this.Height - this.toolStrip1.Height - 37;

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.PrintPreviewControl1.Zoom = (float)System.Convert.ToDouble(toolStripMenuItem2.Text) / 100;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.PrintPreviewControl1.Zoom = (float)System.Convert.ToDouble(toolStripMenuItem3.Text) / 100; 
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.PrintPreviewControl1.Zoom = (float)System.Convert.ToDouble(toolStripMenuItem4.Text) / 100; 
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            this.PrintPreviewControl1.Zoom = (float)System.Convert.ToDouble(toolStripMenuItem5.Text) / 100; 
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.PrintPreviewControl1.Zoom = (float)System.Convert.ToDouble(toolStripMenuItem6.Text) / 100; 
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            this.PrintPreviewControl1.Zoom = (float)System.Convert.ToDouble(toolStripMenuItem7.Text) / 100; 
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            this.PrintPreviewControl1.Zoom = (float)System.Convert.ToDouble(toolStripMenuItem8.Text) / 100; 
        }

        private void PrintPreviewControl1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }
    }
}