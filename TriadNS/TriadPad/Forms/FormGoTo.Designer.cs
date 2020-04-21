namespace TriadPad.Forms
    {
    partial class FormGoTo
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
            this.btGo = new System.Windows.Forms.Button();
            this.nudLineNumber = new System.Windows.Forms.NumericUpDown();
            this.lTextLineRange = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            ( (System.ComponentModel.ISupportInitialize)( this.nudLineNumber ) ).BeginInit();
            this.SuspendLayout();
            // 
            // btGo
            // 
            this.btGo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGo.Location = new System.Drawing.Point( 36, 47 );
            this.btGo.Name = "btGo";
            this.btGo.Size = new System.Drawing.Size( 120, 23 );
            this.btGo.TabIndex = 1;
            this.btGo.Text = "Перейти";
            this.btGo.UseVisualStyleBackColor = true;
            this.btGo.Click += new System.EventHandler( this.btGo_Click );
            // 
            // nudLineNumber
            // 
            this.nudLineNumber.Location = new System.Drawing.Point( 12, 21 );
            this.nudLineNumber.Name = "nudLineNumber";
            this.nudLineNumber.Size = new System.Drawing.Size( 270, 20 );
            this.nudLineNumber.TabIndex = 0;
            // 
            // lTextLineRange
            // 
            this.lTextLineRange.AutoSize = true;
            this.lTextLineRange.Location = new System.Drawing.Point( 9, 5 );
            this.lTextLineRange.Name = "lTextLineRange";
            this.lTextLineRange.Size = new System.Drawing.Size( 79, 13 );
            this.lTextLineRange.TabIndex = 3;
            this.lTextLineRange.Text = "Номер строки";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point( 162, 47 );
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size( 120, 23 );
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler( this.buttonCancel_Click );
            // 
            // FormGoTo
            // 
            this.AcceptButton = this.btGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size( 294, 75 );
            this.Controls.Add( this.lTextLineRange );
            this.Controls.Add( this.nudLineNumber );
            this.Controls.Add( this.buttonCancel );
            this.Controls.Add( this.btGo );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGoTo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Переход на другую строку";
            ( (System.ComponentModel.ISupportInitialize)( this.nudLineNumber ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

            }

        #endregion

        private System.Windows.Forms.Button btGo;
        private System.Windows.Forms.NumericUpDown nudLineNumber;
        private System.Windows.Forms.Label lTextLineRange;
        private System.Windows.Forms.Button buttonCancel;
        }
    }