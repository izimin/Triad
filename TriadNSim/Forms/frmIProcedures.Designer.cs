namespace TriadNSim.Forms
{
    partial class frmIProcedures
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
            this.listViewStandartIP = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnArgsCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStandartIP = new System.Windows.Forms.TabPage();
            this.tabUserIP = new System.Windows.Forms.TabPage();
            this.btnAddIP = new System.Windows.Forms.Button();
            this.btnEditIP = new System.Windows.Forms.Button();
            this.btnDeleteIP = new System.Windows.Forms.Button();
            this.listViewUserIP = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabStandartIP.SuspendLayout();
            this.tabUserIP.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewStandartIP
            // 
            this.listViewStandartIP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnType,
            this.columnArgsCount});
            this.listViewStandartIP.FullRowSelect = true;
            this.listViewStandartIP.Location = new System.Drawing.Point(6, 6);
            this.listViewStandartIP.Name = "listViewStandartIP";
            this.listViewStandartIP.Size = new System.Drawing.Size(591, 246);
            this.listViewStandartIP.TabIndex = 0;
            this.listViewStandartIP.UseCompatibleStateImageBehavior = false;
            this.listViewStandartIP.View = System.Windows.Forms.View.Details;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 109;
            // 
            // columnType
            // 
            this.columnType.Text = "Описание";
            this.columnType.Width = 227;
            // 
            // columnArgsCount
            // 
            this.columnArgsCount.Text = "Количество аргументов";
            this.columnArgsCount.Width = 142;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabStandartIP);
            this.tabControl1.Controls.Add(this.tabUserIP);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(611, 281);
            this.tabControl1.TabIndex = 1;
            // 
            // tabStandartIP
            // 
            this.tabStandartIP.Controls.Add(this.listViewStandartIP);
            this.tabStandartIP.Location = new System.Drawing.Point(4, 22);
            this.tabStandartIP.Name = "tabStandartIP";
            this.tabStandartIP.Padding = new System.Windows.Forms.Padding(3);
            this.tabStandartIP.Size = new System.Drawing.Size(603, 255);
            this.tabStandartIP.TabIndex = 0;
            this.tabStandartIP.Text = "Standart IP";
            this.tabStandartIP.UseVisualStyleBackColor = true;
            // 
            // tabUserIP
            // 
            this.tabUserIP.Controls.Add(this.btnAddIP);
            this.tabUserIP.Controls.Add(this.btnEditIP);
            this.tabUserIP.Controls.Add(this.btnDeleteIP);
            this.tabUserIP.Controls.Add(this.listViewUserIP);
            this.tabUserIP.Location = new System.Drawing.Point(4, 22);
            this.tabUserIP.Name = "tabUserIP";
            this.tabUserIP.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserIP.Size = new System.Drawing.Size(603, 255);
            this.tabUserIP.TabIndex = 1;
            this.tabUserIP.Text = "Пользовательские ИП";
            this.tabUserIP.UseVisualStyleBackColor = true;
            // 
            // btnAddIP
            // 
            this.btnAddIP.Location = new System.Drawing.Point(240, 220);
            this.btnAddIP.Name = "btnAddIP";
            this.btnAddIP.Size = new System.Drawing.Size(115, 29);
            this.btnAddIP.TabIndex = 4;
            this.btnAddIP.Text = "Добавить";
            this.btnAddIP.UseVisualStyleBackColor = true;
            this.btnAddIP.Click += new System.EventHandler(this.btnAddIP_Click);
            // 
            // btnEditIP
            // 
            this.btnEditIP.Enabled = false;
            this.btnEditIP.Location = new System.Drawing.Point(361, 220);
            this.btnEditIP.Name = "btnEditIP";
            this.btnEditIP.Size = new System.Drawing.Size(115, 29);
            this.btnEditIP.TabIndex = 3;
            this.btnEditIP.Text = "Изменить";
            this.btnEditIP.UseVisualStyleBackColor = true;
            this.btnEditIP.Click += new System.EventHandler(this.btnEditIP_Click);
            // 
            // btnDeleteIP
            // 
            this.btnDeleteIP.Enabled = false;
            this.btnDeleteIP.Location = new System.Drawing.Point(482, 220);
            this.btnDeleteIP.Name = "btnDeleteIP";
            this.btnDeleteIP.Size = new System.Drawing.Size(115, 29);
            this.btnDeleteIP.TabIndex = 2;
            this.btnDeleteIP.Text = "Delete";
            this.btnDeleteIP.UseVisualStyleBackColor = true;
            this.btnDeleteIP.Click += new System.EventHandler(this.btnDeleteIP_Click);
            // 
            // listViewUserIP
            // 
            this.listViewUserIP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewUserIP.FullRowSelect = true;
            this.listViewUserIP.HideSelection = false;
            this.listViewUserIP.Location = new System.Drawing.Point(5, 6);
            this.listViewUserIP.Name = "listViewUserIP";
            this.listViewUserIP.Size = new System.Drawing.Size(592, 208);
            this.listViewUserIP.TabIndex = 1;
            this.listViewUserIP.UseCompatibleStateImageBehavior = false;
            this.listViewUserIP.View = System.Windows.Forms.View.Details;
            this.listViewUserIP.SelectedIndexChanged += new System.EventHandler(this.listViewUserIP_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 109;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Описание";
            this.columnHeader2.Width = 227;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Количество аргументов";
            this.columnHeader3.Width = 142;
            // 
            // frmIProcedures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 305);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIProcedures";
            this.Text = "Information procedures";
            this.Load += new System.EventHandler(this.frmIProcedures_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabStandartIP.ResumeLayout(false);
            this.tabUserIP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewStandartIP;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnType;
        private System.Windows.Forms.ColumnHeader columnArgsCount;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStandartIP;
        private System.Windows.Forms.TabPage tabUserIP;
        private System.Windows.Forms.ListView listViewUserIP;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnAddIP;
        private System.Windows.Forms.Button btnEditIP;
        private System.Windows.Forms.Button btnDeleteIP;
    }
}