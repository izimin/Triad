namespace TriadPad.Forms
    {
    partial class FormFind
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
            this.btFindNext = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btFindRestart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbFind = new System.Windows.Forms.ComboBox();
            this.cbWholeWord = new System.Windows.Forms.CheckBox();
            this.cbFindUp = new System.Windows.Forms.CheckBox();
            this.cbMatchCase = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btFindNext
            // 
            this.btFindNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btFindNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFindNext.Location = new System.Drawing.Point( 140, 80 );
            this.btFindNext.Name = "btFindNext";
            this.btFindNext.Size = new System.Drawing.Size( 120, 23 );
            this.btFindNext.TabIndex = 1;
            this.btFindNext.Text = "Найти далее";
            this.btFindNext.UseVisualStyleBackColor = true;
            this.btFindNext.Click += new System.EventHandler( this.btFindNext_Click );
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Location = new System.Drawing.Point( 277, 80 );
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size( 120, 23 );
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Закрыть";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btFindRestart
            // 
            this.btFindRestart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btFindRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFindRestart.Location = new System.Drawing.Point( 3, 80 );
            this.btFindRestart.Name = "btFindRestart";
            this.btFindRestart.Size = new System.Drawing.Size( 120, 23 );
            this.btFindRestart.TabIndex = 3;
            this.btFindRestart.Text = "Начать сначала";
            this.btFindRestart.UseVisualStyleBackColor = true;
            this.btFindRestart.Click += new System.EventHandler( this.btFindRestart_Click );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.cbFind );
            this.groupBox1.Controls.Add( this.cbWholeWord );
            this.groupBox1.Controls.Add( this.cbFindUp );
            this.groupBox1.Controls.Add( this.cbMatchCase );
            this.groupBox1.Location = new System.Drawing.Point( 3, 1 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 396, 73 );
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Что нужно найти";
            // 
            // cbFind
            // 
            this.cbFind.FormattingEnabled = true;
            this.cbFind.Location = new System.Drawing.Point( 12, 20 );
            this.cbFind.Name = "cbFind";
            this.cbFind.Size = new System.Drawing.Size( 373, 21 );
            this.cbFind.TabIndex = 0;
            // 
            // cbWholeWord
            // 
            this.cbWholeWord.AutoSize = true;
            this.cbWholeWord.Location = new System.Drawing.Point( 142, 46 );
            this.cbWholeWord.Name = "cbWholeWord";
            this.cbWholeWord.Size = new System.Drawing.Size( 104, 17 );
            this.cbWholeWord.TabIndex = 2;
            this.cbWholeWord.Text = "Слово целиком";
            this.cbWholeWord.UseVisualStyleBackColor = true;
            // 
            // cbFindUp
            // 
            this.cbFindUp.AutoSize = true;
            this.cbFindUp.Location = new System.Drawing.Point( 286, 47 );
            this.cbFindUp.Name = "cbFindUp";
            this.cbFindUp.Size = new System.Drawing.Size( 88, 17 );
            this.cbFindUp.TabIndex = 3;
            this.cbFindUp.Text = "Снизу вверх";
            this.cbFindUp.UseVisualStyleBackColor = true;
            // 
            // cbMatchCase
            // 
            this.cbMatchCase.AutoSize = true;
            this.cbMatchCase.Location = new System.Drawing.Point( 12, 46 );
            this.cbMatchCase.Name = "cbMatchCase";
            this.cbMatchCase.Size = new System.Drawing.Size( 99, 17 );
            this.cbMatchCase.TabIndex = 1;
            this.cbMatchCase.Text = "Учет регистра";
            this.cbMatchCase.UseVisualStyleBackColor = true;
            // 
            // FormFind
            // 
            this.AcceptButton = this.btFindNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size( 400, 109 );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.btCancel );
            this.Controls.Add( this.btFindRestart );
            this.Controls.Add( this.btFindNext );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFind";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поиск";
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout();
            this.ResumeLayout( false );

            }

        #endregion

        protected internal System.Windows.Forms.Button btFindNext;
        protected internal System.Windows.Forms.Button btCancel;
        protected internal System.Windows.Forms.Button btFindRestart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbFind;
        private System.Windows.Forms.CheckBox cbWholeWord;
        private System.Windows.Forms.CheckBox cbMatchCase;
        protected System.Windows.Forms.CheckBox cbFindUp;
        }
    }