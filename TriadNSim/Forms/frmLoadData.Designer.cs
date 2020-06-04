namespace TriadNSim.Forms
{
    partial class frmLoadData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoadData));
            this.btnLoadFromDevice = new Bunifu.Framework.UI.BunifuFlatButton();
            this.tbUrl = new Bunifu.Framework.UI.BunifuTextbox();
            this.btnCancel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnLoadFromServer = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panelUploadFromServer = new System.Windows.Forms.Panel();
            this.btnBack = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnOk = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ofdLoadOwl = new System.Windows.Forms.OpenFileDialog();
            this.ofdLoadXes = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelUploadFromServer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadFromDevice
            // 
            this.btnLoadFromDevice.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnLoadFromDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadFromDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnLoadFromDevice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadFromDevice.BorderRadius = 0;
            this.btnLoadFromDevice.ButtonText = "Из локального хранилища";
            this.btnLoadFromDevice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadFromDevice.DisabledColor = System.Drawing.Color.Gray;
            this.btnLoadFromDevice.Iconcolor = System.Drawing.Color.Transparent;
            this.btnLoadFromDevice.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnLoadFromDevice.Iconimage")));
            this.btnLoadFromDevice.Iconimage_right = null;
            this.btnLoadFromDevice.Iconimage_right_Selected = null;
            this.btnLoadFromDevice.Iconimage_Selected = null;
            this.btnLoadFromDevice.IconMarginLeft = 0;
            this.btnLoadFromDevice.IconMarginRight = 0;
            this.btnLoadFromDevice.IconRightVisible = true;
            this.btnLoadFromDevice.IconRightZoom = 0D;
            this.btnLoadFromDevice.IconVisible = true;
            this.btnLoadFromDevice.IconZoom = 60D;
            this.btnLoadFromDevice.IsTab = false;
            this.btnLoadFromDevice.Location = new System.Drawing.Point(9, 86);
            this.btnLoadFromDevice.Name = "btnLoadFromDevice";
            this.btnLoadFromDevice.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnLoadFromDevice.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnLoadFromDevice.OnHoverTextColor = System.Drawing.Color.White;
            this.btnLoadFromDevice.selected = false;
            this.btnLoadFromDevice.Size = new System.Drawing.Size(405, 60);
            this.btnLoadFromDevice.TabIndex = 6;
            this.btnLoadFromDevice.Text = "Из локального хранилища";
            this.btnLoadFromDevice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLoadFromDevice.Textcolor = System.Drawing.Color.White;
            this.btnLoadFromDevice.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadFromDevice.Click += new System.EventHandler(this.btnLoadFromDevice_Click);
            // 
            // tbUrl
            // 
            this.tbUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUrl.BackColor = System.Drawing.SystemColors.Control;
            this.tbUrl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbUrl.BackgroundImage")));
            this.tbUrl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tbUrl.ForeColor = System.Drawing.Color.SeaGreen;
            this.tbUrl.Icon = ((System.Drawing.Image)(resources.GetObject("tbUrl.Icon")));
            this.tbUrl.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tbUrl.Location = new System.Drawing.Point(9, 21);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(405, 60);
            this.tbUrl.TabIndex = 7;
            this.tbUrl.text = " ";
            // 
            // btnCancel
            // 
            this.btnCancel.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.BorderRadius = 0;
            this.btnCancel.ButtonText = "Отмена";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DisabledColor = System.Drawing.Color.Gray;
            this.btnCancel.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCancel.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnCancel.Iconimage")));
            this.btnCancel.Iconimage_right = null;
            this.btnCancel.Iconimage_right_Selected = null;
            this.btnCancel.Iconimage_Selected = null;
            this.btnCancel.IconMarginLeft = 0;
            this.btnCancel.IconMarginRight = 0;
            this.btnCancel.IconRightVisible = true;
            this.btnCancel.IconRightZoom = 0D;
            this.btnCancel.IconVisible = true;
            this.btnCancel.IconZoom = 40D;
            this.btnCancel.IsTab = false;
            this.btnCancel.Location = new System.Drawing.Point(9, 152);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnCancel.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnCancel.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCancel.selected = false;
            this.btnCancel.Size = new System.Drawing.Size(405, 60);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Textcolor = System.Drawing.Color.White;
            this.btnCancel.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLoadFromServer
            // 
            this.btnLoadFromServer.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnLoadFromServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadFromServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnLoadFromServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadFromServer.BorderRadius = 0;
            this.btnLoadFromServer.ButtonText = "Из удаленного сервера";
            this.btnLoadFromServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadFromServer.DisabledColor = System.Drawing.Color.Gray;
            this.btnLoadFromServer.Iconcolor = System.Drawing.Color.Transparent;
            this.btnLoadFromServer.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnLoadFromServer.Iconimage")));
            this.btnLoadFromServer.Iconimage_right = null;
            this.btnLoadFromServer.Iconimage_right_Selected = null;
            this.btnLoadFromServer.Iconimage_Selected = null;
            this.btnLoadFromServer.IconMarginLeft = 0;
            this.btnLoadFromServer.IconMarginRight = 0;
            this.btnLoadFromServer.IconRightVisible = true;
            this.btnLoadFromServer.IconRightZoom = 0D;
            this.btnLoadFromServer.IconVisible = true;
            this.btnLoadFromServer.IconZoom = 60D;
            this.btnLoadFromServer.IsTab = false;
            this.btnLoadFromServer.Location = new System.Drawing.Point(9, 20);
            this.btnLoadFromServer.Name = "btnLoadFromServer";
            this.btnLoadFromServer.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnLoadFromServer.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnLoadFromServer.OnHoverTextColor = System.Drawing.Color.White;
            this.btnLoadFromServer.selected = false;
            this.btnLoadFromServer.Size = new System.Drawing.Size(405, 60);
            this.btnLoadFromServer.TabIndex = 6;
            this.btnLoadFromServer.Text = "Из удаленного сервера";
            this.btnLoadFromServer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLoadFromServer.Textcolor = System.Drawing.Color.White;
            this.btnLoadFromServer.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadFromServer.Click += new System.EventHandler(this.btnLoadFromServer_Click);
            // 
            // panelUploadFromServer
            // 
            this.panelUploadFromServer.Controls.Add(this.btnOk);
            this.panelUploadFromServer.Controls.Add(this.tbUrl);
            this.panelUploadFromServer.Controls.Add(this.btnBack);
            this.panelUploadFromServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUploadFromServer.Location = new System.Drawing.Point(0, 0);
            this.panelUploadFromServer.Name = "panelUploadFromServer";
            this.panelUploadFromServer.Size = new System.Drawing.Size(422, 233);
            this.panelUploadFromServer.TabIndex = 8;
            this.panelUploadFromServer.Visible = false;
            // 
            // btnBack
            // 
            this.btnBack.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.BorderRadius = 0;
            this.btnBack.ButtonText = "     Назад";
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.DisabledColor = System.Drawing.Color.Gray;
            this.btnBack.Iconcolor = System.Drawing.Color.Transparent;
            this.btnBack.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnBack.Iconimage")));
            this.btnBack.Iconimage_right = null;
            this.btnBack.Iconimage_right_Selected = null;
            this.btnBack.Iconimage_Selected = null;
            this.btnBack.IconMarginLeft = 0;
            this.btnBack.IconMarginRight = 0;
            this.btnBack.IconRightVisible = true;
            this.btnBack.IconRightZoom = 0D;
            this.btnBack.IconVisible = true;
            this.btnBack.IconZoom = 60D;
            this.btnBack.IsTab = false;
            this.btnBack.Location = new System.Drawing.Point(9, 153);
            this.btnBack.Name = "btnBack";
            this.btnBack.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnBack.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnBack.OnHoverTextColor = System.Drawing.Color.White;
            this.btnBack.selected = false;
            this.btnBack.Size = new System.Drawing.Size(405, 60);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "     Назад";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBack.Textcolor = System.Drawing.Color.White;
            this.btnBack.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnOk
            // 
            this.btnOk.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOk.BorderRadius = 0;
            this.btnOk.ButtonText = "Ок";
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.DisabledColor = System.Drawing.Color.Gray;
            this.btnOk.Iconcolor = System.Drawing.Color.Transparent;
            this.btnOk.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnOk.Iconimage")));
            this.btnOk.Iconimage_right = null;
            this.btnOk.Iconimage_right_Selected = null;
            this.btnOk.Iconimage_Selected = null;
            this.btnOk.IconMarginLeft = 0;
            this.btnOk.IconMarginRight = 0;
            this.btnOk.IconRightVisible = true;
            this.btnOk.IconRightZoom = 0D;
            this.btnOk.IconVisible = true;
            this.btnOk.IconZoom = 90D;
            this.btnOk.IsTab = false;
            this.btnOk.Location = new System.Drawing.Point(9, 87);
            this.btnOk.Name = "btnOk";
            this.btnOk.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnOk.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnOk.OnHoverTextColor = System.Drawing.Color.White;
            this.btnOk.Padding = new System.Windows.Forms.Padding(20, 20, 60, 20);
            this.btnOk.selected = false;
            this.btnOk.Size = new System.Drawing.Size(405, 60);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Ок";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOk.Textcolor = System.Drawing.Color.White;
            this.btnOk.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ofdLoadOwl
            // 
            this.ofdLoadOwl.Filter = "OWL files|*.owl";
            // 
            // ofdLoadXes
            // 
            this.ofdLoadXes.Filter = "XES files|*.xes";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelUploadFromServer);
            this.panel1.Controls.Add(this.btnLoadFromServer);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnLoadFromDevice);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 233);
            this.panel1.TabIndex = 9;
            // 
            // frmLoadData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 233);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLoadData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Загрузка файла";
            this.panelUploadFromServer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuFlatButton btnLoadFromDevice;
        private Bunifu.Framework.UI.BunifuTextbox tbUrl;
        private Bunifu.Framework.UI.BunifuFlatButton btnCancel;
        private Bunifu.Framework.UI.BunifuFlatButton btnLoadFromServer;
        private System.Windows.Forms.Panel panelUploadFromServer;
        private Bunifu.Framework.UI.BunifuFlatButton btnBack;
        private Bunifu.Framework.UI.BunifuFlatButton btnOk;
        private System.Windows.Forms.OpenFileDialog ofdLoadOwl;
        private System.Windows.Forms.OpenFileDialog ofdLoadXes;
        private System.Windows.Forms.Panel panel1;
    }
}