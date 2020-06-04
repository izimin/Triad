using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using java.lang;
using java.net;
using TriadNSim.Data;
using Exception = System.Exception;

namespace TriadNSim.Forms
{
    public partial class frmLoadData : Form
    {
        private TypeFileEnum typeFile;

        public frmLoadData(TypeFileEnum typeFile)
        {
            InitializeComponent();

            this.typeFile = typeFile;
            
            tbUrl.text = TypeFileEnum.OWL.Equals(typeFile)
                ? "http://35.188.194.23/onto/social-model.owl"
                : "http://35.188.194.23/logs/log.xes";
        }

        private void btnLoadFromDevice_Click(object sender, EventArgs e)
        {
            OpenFileDialog curOpenFileDialog = TypeFileEnum.OWL.Equals(typeFile) ? ofdLoadOwl : ofdLoadXes;

            try
            {
                if (curOpenFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Не удалось открыть файл :(");
            }

            frmMain.FileName = curOpenFileDialog.FileName;
            DialogResult = DialogResult.OK;
            Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                var fileName = TypeFileEnum.OWL.Equals(typeFile) ? "social-model.owl" : "log.xes";
                WebClient myWebClient = new WebClient();
                myWebClient.DownloadFile(tbUrl.text.Trim(), fileName);
                frmMain.FileName = Application.StartupPath + "\\" + fileName;
            }
            catch (SocketException)
            {
                MessageBox.Show("Не удалось загрузить файл с сервера :(");
                DialogResult = DialogResult.Cancel;
                Close();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnLoadFromServer_Click(object sender, EventArgs e)
        {
            panelUploadFromServer.Visible = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            panelUploadFromServer.Visible = false;
        }
    }
}
