namespace TriadPad.Forms
    {
    partial class FormReplace
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
            {
            if ( disposing && ( components != null ) )
                {
                components.Dispose();
                }
            base.Dispose( disposing );
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
            {
            this.btReplace = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbReplace = new System.Windows.Forms.ComboBox();
            this.btFindNextAndReplace = new System.Windows.Forms.Button();
            this.btReplaceAll = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btFindNext
            // 
            this.btFindNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btFindNext.Location = new System.Drawing.Point( 142, 132 );
            this.btFindNext.TabIndex = 2;
            // 
            // btCancel
            // 
            this.btCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btCancel.Location = new System.Drawing.Point( 279, 161 );
            this.btCancel.TabIndex = 7;
            // 
            // btFindRestart
            // 
            this.btFindRestart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btFindRestart.Location = new System.Drawing.Point( 3, 132 );
            this.btFindRestart.TabIndex = 4;
            // 
            // btReplace
            // 
            this.btReplace.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btReplace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btReplace.Location = new System.Drawing.Point( 279, 132 );
            this.btReplace.Name = "btReplace";
            this.btReplace.Size = new System.Drawing.Size( 120, 23 );
            this.btReplace.TabIndex = 3;
            this.btReplace.Text = "Заменить";
            this.btReplace.UseVisualStyleBackColor = true;
            this.btReplace.Click += new System.EventHandler( this.btReplace_Click );
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add( this.cbReplace );
            this.groupBox3.Location = new System.Drawing.Point( 3, 76 );
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size( 396, 50 );
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Чем нужно заменить";
            // 
            // cbReplace
            // 
            this.cbReplace.FormattingEnabled = true;
            this.cbReplace.Location = new System.Drawing.Point( 12, 19 );
            this.cbReplace.Name = "cbReplace";
            this.cbReplace.Size = new System.Drawing.Size( 373, 21 );
            this.cbReplace.TabIndex = 0;
            // 
            // btFindNextAndReplace
            // 
            this.btFindNextAndReplace.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btFindNextAndReplace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFindNextAndReplace.Location = new System.Drawing.Point( 3, 161 );
            this.btFindNextAndReplace.Name = "btFindNextAndReplace";
            this.btFindNextAndReplace.Size = new System.Drawing.Size( 120, 23 );
            this.btFindNextAndReplace.TabIndex = 5;
            this.btFindNextAndReplace.Text = "Найти и заменить";
            this.btFindNextAndReplace.UseVisualStyleBackColor = true;
            this.btFindNextAndReplace.Click += new System.EventHandler( this.btFindNextAndReplace_Click );
            // 
            // btReplaceAll
            // 
            this.btReplaceAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btReplaceAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btReplaceAll.Location = new System.Drawing.Point( 142, 161 );
            this.btReplaceAll.Name = "btReplaceAll";
            this.btReplaceAll.Size = new System.Drawing.Size( 120, 23 );
            this.btReplaceAll.TabIndex = 6;
            this.btReplaceAll.Text = "Заменить все";
            this.btReplaceAll.UseVisualStyleBackColor = true;
            this.btReplaceAll.Click += new System.EventHandler( this.btReplaceAll_Click );
            // 
            // FormReplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 400, 191 );
            this.Controls.Add( this.groupBox3 );
            this.Controls.Add( this.btReplaceAll );
            this.Controls.Add( this.btFindNextAndReplace );
            this.Controls.Add( this.btReplace );
            this.Name = "FormReplace";
            this.Text = "Найти и заменить";
            this.Controls.SetChildIndex( this.btFindNext, 0 );
            this.Controls.SetChildIndex( this.btFindRestart, 0 );
            this.Controls.SetChildIndex( this.btCancel, 0 );
            this.Controls.SetChildIndex( this.btReplace, 0 );
            this.Controls.SetChildIndex( this.btFindNextAndReplace, 0 );
            this.Controls.SetChildIndex( this.btReplaceAll, 0 );
            this.Controls.SetChildIndex( this.groupBox3, 0 );
            this.groupBox3.ResumeLayout( false );
            this.ResumeLayout( false );

            }

        #endregion

        private System.Windows.Forms.Button btReplace;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbReplace;
        private System.Windows.Forms.Button btFindNextAndReplace;
        private System.Windows.Forms.Button btReplaceAll;
        }
    }