using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TriadNSim.Data;

namespace TriadNSim.Forms
{
    public partial class frmIp : Form
    {
        public frmIp(Dictionary<string, Person> dictPeople, Dictionary<string, Community> dictCommunities)
        {
            InitializeComponent();
            dgvIp.Rows.Add("IPCountEvents", "Количество определеного события", 1);
            foreach (var item in dictPeople)
            {
                dgvElements.Rows.Add(item.Value.Id, item.Value.FirstName + " " + item.Value.LastName, true);
            }

            foreach (var item in dictCommunities)
            {
                dgvElements.Rows.Add(item.Value.Id, item.Value.Name, true);
            }
        }
    }
}
