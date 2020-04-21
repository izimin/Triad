namespace TriadNSim.Forms
{
    partial class ModifyRelation
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
            this.cmbObjFromPolus = new System.Windows.Forms.ComboBox();
            this.cmbObjToPolus = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblObj1Name = new System.Windows.Forms.Label();
            this.lblObj2Name = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbObjFromPolus
            // 
            this.cmbObjFromPolus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbObjFromPolus.FormattingEnabled = true;
            this.cmbObjFromPolus.Location = new System.Drawing.Point(12, 41);
            this.cmbObjFromPolus.Name = "cmbObjFromPolus";
            this.cmbObjFromPolus.Size = new System.Drawing.Size(120, 21);
            this.cmbObjFromPolus.TabIndex = 1;
            this.cmbObjFromPolus.SelectedIndexChanged += new System.EventHandler(this.cmbObj1OutPolus_SelectedIndexChanged);
            // 
            // cmbObjToPolus
            // 
            this.cmbObjToPolus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbObjToPolus.FormattingEnabled = true;
            this.cmbObjToPolus.Location = new System.Drawing.Point(162, 41);
            this.cmbObjToPolus.Name = "cmbObjToPolus";
            this.cmbObjToPolus.Size = new System.Drawing.Size(120, 21);
            this.cmbObjToPolus.TabIndex = 2;
            this.cmbObjToPolus.SelectedIndexChanged += new System.EventHandler(this.cmbObj2InPolus_SelectedIndexChanged);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(12, 72);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(120, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Применить";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(162, 72);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "полюс";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "полюс";
            // 
            // lblObj1Name
            // 
            this.lblObj1Name.AutoSize = true;
            this.lblObj1Name.Location = new System.Drawing.Point(12, 25);
            this.lblObj1Name.MaximumSize = new System.Drawing.Size(120, 13);
            this.lblObj1Name.Name = "lblObj1Name";
            this.lblObj1Name.Size = new System.Drawing.Size(0, 13);
            this.lblObj1Name.TabIndex = 11;
            // 
            // lblObj2Name
            // 
            this.lblObj2Name.AutoSize = true;
            this.lblObj2Name.Location = new System.Drawing.Point(159, 25);
            this.lblObj2Name.MaximumSize = new System.Drawing.Size(120, 13);
            this.lblObj2Name.Name = "lblObj2Name";
            this.lblObj2Name.Size = new System.Drawing.Size(0, 13);
            this.lblObj2Name.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "-->";
            // 
            // ModifyRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 107);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblObj2Name);
            this.Controls.Add(this.lblObj1Name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbObjToPolus);
            this.Controls.Add(this.cmbObjFromPolus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ModifyRelation";
            this.Text = "Редактирование связи";
            this.Load += new System.EventHandler(this.ModifyRelation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbObjFromPolus;
        private System.Windows.Forms.ComboBox cmbObjToPolus;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblObj1Name;
        private System.Windows.Forms.Label lblObj2Name;
        private System.Windows.Forms.Label label5;
    }
}