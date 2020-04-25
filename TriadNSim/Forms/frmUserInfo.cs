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
using TriadNSim.Data;
using TriadNSim.Data.Enums;

namespace TriadNSim.Forms
{
    public partial class frmUserInfo : Form
    {
        private string id;
        private Person person;
        public frmUserInfo(string id)
        {
            InitializeComponent();
            this.id = id;
            person = frmMain.dictPeople[id];
            pbUserPhoto.ImageLocation = person.PhotoUrl;
            lblName.Text = person.FirstName + " " + person.LastName;
            lblGender.Text = person.Gender == GenderEnum.Female ? "Ж" : "М";
            lblUrl.Text = person.ProfileUrl;
            lblCommunity.Text = String.Join(", ", person.CommunityIds.Select(x => frmMain.dictCommunities[x].Name));
            lblTotal.Text = $@"Всего событий: {person.Events.Count}";

            foreach (var personEvent in person.Events)
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
