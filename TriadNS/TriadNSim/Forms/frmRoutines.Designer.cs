namespace TriadNSim.Forms
{
    partial class frmRoutines
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
            this.lstRoutines = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bntClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstRoutines
            // 
            this.lstRoutines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstRoutines.FullRowSelect = true;
            this.lstRoutines.Location = new System.Drawing.Point(12, 12);
            this.lstRoutines.Name = "lstRoutines";
            this.lstRoutines.Size = new System.Drawing.Size(320, 154);
            this.lstRoutines.TabIndex = 10;
            this.lstRoutines.UseCompatibleStateImageBehavior = false;
            this.lstRoutines.View = System.Windows.Forms.View.Details;
            this.lstRoutines.SelectedIndexChanged += new System.EventHandler(this.lstRoutines_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Имя";
            this.columnHeader1.Width = 77;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Описание";
            this.columnHeader2.Width = 227;
            // 
            // bntClose
            // 
            this.bntClose.Location = new System.Drawing.Point(257, 174);
            this.bntClose.Name = "bntClose";
            this.bntClose.Size = new System.Drawing.Size(75, 23);
            this.bntClose.TabIndex = 11;
            this.bntClose.Text = "Закрыть";
            this.bntClose.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(93, 174);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 174);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmRoutines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bntClose;
            this.ClientSize = new System.Drawing.Size(341, 204);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.bntClose);
            this.Controls.Add(this.lstRoutines);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRoutines";
            this.Text = "Рутины";
            this.Load += new System.EventHandler(this.frmRoutines_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstRoutines;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button bntClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
    }
}