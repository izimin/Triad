using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace TriadNSim.Forms
{
    public partial class frmGraphConst : Form
    {
        public frmMain f1;
        public frmGraphConst(frmMain f)
        {
            InitializeComponent();
            f1 = f;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox2.Image = imageList1.Images[checkedListBox1.SelectedIndex];
            if ((checkedListBox1.SelectedIndex == 3)||(checkedListBox1.SelectedIndex == 4)||(checkedListBox1.SelectedIndex == 5))
            { numericUpDown2.Enabled = true; }
            else { numericUpDown2.Enabled = false; }
        }
        
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var list = sender as CheckedListBox;
            if (e.NewValue == CheckState.Checked)
                foreach (int index in list.CheckedIndices)
                    if (index != e.Index)
                        list.SetItemChecked(index, false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedIndices.Count!=0) 
            { 
                if ((numericUpDown1.Value != 0) || ((numericUpDown2.Value != 0) && (numericUpDown2.Enabled = false))) 
                {
                        f1.GraphConst(this,checkedListBox1.SelectedIndex, Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value));
                        MessageBox.Show("Графовая константа построена!");    
                    Close();
                }
                 else { MessageBox.Show("Ошибка! Количество вершин(N) и уровней(M) не может равняться 0!");}
            }
            else { MessageBox.Show("Ошибка! Не выбран тип графовой константы!"); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
