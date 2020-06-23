namespace TriadNSim.Forms
{
    partial class frmAddCommunity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddCommunity));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddCommunity = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dgvCommunity = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.clmnIdUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnIsFriend = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunity)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnAddCommunity, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.dgvCommunity, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.metroTextBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 1, 10, 10);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 456F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(390, 581);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // btnAddCommunity
            // 
            this.btnAddCommunity.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnAddCommunity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnAddCommunity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddCommunity.BorderRadius = 0;
            this.btnAddCommunity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnAddCommunity.ButtonText = "Добавить сообщество";
            this.btnAddCommunity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCommunity.DisabledColor = System.Drawing.Color.Gainsboro;
            this.btnAddCommunity.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddCommunity.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddCommunity.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAddCommunity.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnAddCommunity.Iconimage")));
            this.btnAddCommunity.Iconimage_right = null;
            this.btnAddCommunity.Iconimage_right_Selected = null;
            this.btnAddCommunity.Iconimage_Selected = null;
            this.btnAddCommunity.IconMarginLeft = 0;
            this.btnAddCommunity.IconMarginRight = 0;
            this.btnAddCommunity.IconRightVisible = true;
            this.btnAddCommunity.IconRightZoom = 0D;
            this.btnAddCommunity.IconVisible = true;
            this.btnAddCommunity.IconZoom = 40D;
            this.btnAddCommunity.IsTab = false;
            this.btnAddCommunity.Location = new System.Drawing.Point(10, 534);
            this.btnAddCommunity.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddCommunity.Name = "btnAddCommunity";
            this.btnAddCommunity.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnAddCommunity.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(103)))), ((int)(((byte)(88)))));
            this.btnAddCommunity.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAddCommunity.Padding = new System.Windows.Forms.Padding(5);
            this.btnAddCommunity.selected = false;
            this.btnAddCommunity.Size = new System.Drawing.Size(370, 35);
            this.btnAddCommunity.TabIndex = 12;
            this.btnAddCommunity.Text = "Добавить сообщество";
            this.btnAddCommunity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddCommunity.Textcolor = System.Drawing.Color.Black;
            this.btnAddCommunity.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // dgvCommunity
            // 
            this.dgvCommunity.AllowUserToAddRows = false;
            this.dgvCommunity.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCommunity.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCommunity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCommunity.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvCommunity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCommunity.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommunity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCommunity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommunity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnIdUser,
            this.clmnName,
            this.clmnIsFriend});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCommunity.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCommunity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCommunity.DoubleBuffered = true;
            this.dgvCommunity.EnableHeadersVisualStyles = false;
            this.dgvCommunity.HeaderBgColor = System.Drawing.Color.LightGray;
            this.dgvCommunity.HeaderForeColor = System.Drawing.Color.Black;
            this.dgvCommunity.Location = new System.Drawing.Point(10, 83);
            this.dgvCommunity.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.dgvCommunity.MaximumSize = new System.Drawing.Size(0, 500);
            this.dgvCommunity.MinimumSize = new System.Drawing.Size(0, 200);
            this.dgvCommunity.Name = "dgvCommunity";
            this.dgvCommunity.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCommunity.RowHeadersVisible = false;
            this.dgvCommunity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommunity.Size = new System.Drawing.Size(370, 451);
            this.dgvCommunity.TabIndex = 10;
            // 
            // clmnIdUser
            // 
            this.clmnIdUser.FillWeight = 84.46536F;
            this.clmnIdUser.HeaderText = "ID";
            this.clmnIdUser.Name = "clmnIdUser";
            this.clmnIdUser.ReadOnly = true;
            // 
            // clmnName
            // 
            this.clmnName.FillWeight = 124.1641F;
            this.clmnName.HeaderText = "Имя";
            this.clmnName.Name = "clmnName";
            this.clmnName.ReadOnly = true;
            // 
            // clmnIsFriend
            // 
            this.clmnIsFriend.FillWeight = 91.37056F;
            this.clmnIsFriend.HeaderText = "Подписан";
            this.clmnIsFriend.Name = "clmnIsFriend";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(13, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Наименование";
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(336, 2);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTextBox1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.metroTextBox1.Lines = new string[0];
            this.metroTextBox1.Location = new System.Drawing.Point(13, 25);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(364, 30);
            this.metroTextBox1.TabIndex = 5;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Подписчики";
            // 
            // frmAddCommunity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 581);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmAddCommunity";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление сообщества";
            this.Load += new System.EventHandler(this.frmAddCommunity_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvCommunity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private Bunifu.Framework.UI.BunifuFlatButton btnAddCommunity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnIdUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmnIsFriend;
    }
}