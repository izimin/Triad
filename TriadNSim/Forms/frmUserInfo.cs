using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using TriadNSim.Data;
using TriadNSim.Data.Enums;

namespace TriadNSim.Forms
{
    public partial class frmUserInfo : MaterialForm
    {
        private string id;
        private Person curUser;
        public frmUserInfo(string userId)
        {
            InitializeComponent();
            curUser = frmMain.dictPeople[userId];
            pbUserPhoto.ImageLocation = curUser.PhotoUrl;
            lblName.Text = curUser.FirstName + " " + curUser.LastName;
            lblGender.Text = curUser.Gender == GenderEnum.Female ? "Ж" : "М";
            lblUrl.Text = curUser.ProfileUrl;
            lblCommunity.Text = String.Join(", ", curUser.CommunityIds.Select(x => frmMain.dictCommunities[x].Name));
            lblTotal.Text = $@"Всего событий: {curUser.Events.Count}";

            foreach (var personEvent in curUser.Events)
            {
                dgvEvents.Rows.Add(personEvent.ToString(), personEvent.DateEvent.ToString(), 
                    personEvent.EventType == EventTypeEnum.Offline || personEvent.EventType == EventTypeEnum.Online ? "" : personEvent.getUrl());
            }
        }

        private void dgvEvents_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
