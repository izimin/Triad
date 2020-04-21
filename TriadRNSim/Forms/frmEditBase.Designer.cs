namespace TriadRNSim.Forms
{
    partial class frmEditBase
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
            this.splitContainerText = new System.Windows.Forms.SplitContainer();
            this.numberLabel = new System.Windows.Forms.Label();
            this.rtbText = new TriadPad.RichTextBoxEx();
            this.lvErrors = new System.Windows.Forms.ListView();
            this.chNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbОК = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerText)).BeginInit();
            this.splitContainerText.Panel1.SuspendLayout();
            this.splitContainerText.Panel2.SuspendLayout();
            this.splitContainerText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerText
            // 
            this.splitContainerText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerText.Location = new System.Drawing.Point(0, 0);
            this.splitContainerText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainerText.Name = "splitContainerText";
            // 
            // splitContainerText.Panel1
            // 
            this.splitContainerText.Panel1.Controls.Add(this.numberLabel);
            // 
            // splitContainerText.Panel2
            // 
            this.splitContainerText.Panel2.Controls.Add(this.rtbText);
            this.splitContainerText.Size = new System.Drawing.Size(651, 324);
            this.splitContainerText.SplitterDistance = 49;
            this.splitContainerText.SplitterWidth = 5;
            this.splitContainerText.TabIndex = 1;
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Location = new System.Drawing.Point(8, 1);
            this.numberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(24, 153);
            this.numberLabel.TabIndex = 1;
            this.numberLabel.Text = "1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n10\r\n";
            this.numberLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // rtbText
            // 
            this.rtbText.AutoWordSelection = true;
            this.rtbText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbText.EnableAutoDragDrop = true;
            this.rtbText.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbText.GenerateTextChangeEvent = true;
            this.rtbText.HideSelection = false;
            this.rtbText.Location = new System.Drawing.Point(0, 0);
            this.rtbText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbText.Name = "rtbText";
            this.rtbText.SaveIndentation = false;
            this.rtbText.Size = new System.Drawing.Size(597, 324);
            this.rtbText.TabIndex = 0;
            this.rtbText.Text = "";
            this.rtbText.WordWrap = false;
            // 
            // lvErrors
            // 
            this.lvErrors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNumber,
            this.chMessage,
            this.chLine,
            this.chColumn});
            this.lvErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvErrors.FullRowSelect = true;
            this.lvErrors.GridLines = true;
            this.lvErrors.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvErrors.HideSelection = false;
            this.lvErrors.Location = new System.Drawing.Point(0, 0);
            this.lvErrors.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvErrors.MultiSelect = false;
            this.lvErrors.Name = "lvErrors";
            this.lvErrors.Size = new System.Drawing.Size(200, 57);
            this.lvErrors.TabIndex = 1;
            this.lvErrors.UseCompatibleStateImageBehavior = false;
            this.lvErrors.View = System.Windows.Forms.View.Details;
            this.lvErrors.SelectedIndexChanged += new System.EventHandler(this.lvErrors_SelectedIndexChanged);
            // 
            // chNumber
            // 
            this.chNumber.Text = "№";
            // 
            // chMessage
            // 
            this.chMessage.Text = "Сообщение об ошибке";
            this.chMessage.Width = 650;
            // 
            // chLine
            // 
            this.chLine.Text = "Строка";
            // 
            // chColumn
            // 
            this.chColumn.Text = "Столбец";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainer.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.lvErrors);
            this.splitContainer.Panel2Collapsed = true;
            this.splitContainer.Size = new System.Drawing.Size(651, 401);
            this.splitContainer.SplitterDistance = 243;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainerText);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txtDescription);
            this.splitContainer1.Size = new System.Drawing.Size(651, 374);
            this.splitContainer1.SplitterDistance = 324;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(104, 9);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(529, 22);
            this.txtDescription.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbОК,
            this.tsbCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(651, 27);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbОК
            // 
            this.tsbОК.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbОК.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbОК.Name = "tsbОК";
            this.tsbОК.Size = new System.Drawing.Size(52, 24);
            this.tsbОК.Text = "Apply";
            this.tsbОК.Click += new System.EventHandler(this.tsbОК_Click);
            // 
            // tsbCancel
            // 
            this.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(57, 24);
            this.tsbCancel.Text = "Cancel";
            this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // frmEditBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 401);
            this.Controls.Add(this.splitContainer);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmEditBase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Edit IP";
            this.Activated += new System.EventHandler(this.ChangeRoutine_Activated);
            this.splitContainerText.Panel1.ResumeLayout(false);
            this.splitContainerText.Panel1.PerformLayout();
            this.splitContainerText.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerText)).EndInit();
            this.splitContainerText.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        protected TriadPad.RichTextBoxEx rtbText;
        protected System.Windows.Forms.SplitContainer splitContainerText;
        protected System.Windows.Forms.Label numberLabel;
        protected System.Windows.Forms.ListView lvErrors;
        protected System.Windows.Forms.ColumnHeader chNumber;
        protected System.Windows.Forms.ColumnHeader chMessage;
        protected System.Windows.Forms.ColumnHeader chLine;
        protected System.Windows.Forms.ColumnHeader chColumn;
        protected System.Windows.Forms.SplitContainer splitContainer;
        protected System.Windows.Forms.ToolStrip toolStrip1;
        protected System.Windows.Forms.ToolStripButton tsbОК;
        protected System.Windows.Forms.ToolStripButton tsbCancel;
        protected System.Windows.Forms.SplitContainer splitContainer1;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox txtDescription;
    }
}