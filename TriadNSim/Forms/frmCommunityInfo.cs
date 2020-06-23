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
using TriadNSim.Data.Enums;

namespace TriadNSim.Forms
{
    public partial class frmCommunityInfo : Form
    {
        private Community curCommunity = null;
        public frmCommunityInfo(string communityId)
        {
            InitializeComponent();
            curCommunity = frmMain.dictCommunities[communityId];
            lblName.Text = curCommunity.Name;
            lblUrl.Text = curCommunity.CommunityUrl;
            lblTotal.Text = $@"Всего событий: {curCommunity.Events.Count}";

            foreach (var communityEvent in curCommunity.Events)
            {
                dgvEvents.Rows.Add(communityEvent.ToString(), communityEvent.DateEvent.ToString(),
                    communityEvent.EventType == EventTypeEnum.Offline || communityEvent.EventType == EventTypeEnum.Online ? "" : communityEvent.getUrl());
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            frmAddEvent frmAddEvent = new frmAddEvent();
            if (frmAddEvent.ShowDialog() == DialogResult.OK)
            {
                return;
            }
        }
    }
}
