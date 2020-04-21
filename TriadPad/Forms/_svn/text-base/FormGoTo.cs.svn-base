using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TriadPad.Forms
    {
    /// <summary>
    /// Диалог перехода на новую строку
    /// </summary>
    internal partial class FormGoTo : Form
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        protected FormGoTo()
            {
            InitializeComponent();
            }


        /// <summary>
        /// Экземпляр класса
        /// </summary>
        public static FormGoTo Instance
            {
            get
                {
                if ( instance == null )
                    instance = new FormGoTo();
                return instance;
                }
            }


        /// <summary>
        /// Перейти на новую сроку в окне редактирования
        /// </summary>
        /// <param name="rtb">Окно редактирования</param>
        public void Go( RichTextBoxEx rtb )
            {
            this.editRtb = rtb;
            int lineNumberMax = rtb.Lines.Length - 1;
            this.lTextLineRange.Text = String.Format( "Номер строки ( 0 - {0} )", lineNumberMax );
            this.nudLineNumber.Maximum = lineNumberMax;
            this.nudLineNumber.Value = rtb.SelectedFirstLineNumber;

            this.nudLineNumber.Focus();
            this.ShowDialog();
            rtb.Focus();
            }


        //Кнопка - Перейти
        private void btGo_Click( object sender, EventArgs e )
            {
            this.editRtb.Scroll( (int)this.nudLineNumber.Value );
            this.Close();
            }


        //Кнопка - Отмена
        private void buttonCancel_Click( object sender, EventArgs e )
            {
            this.Close();
            }


        /// <summary>
        /// Экземпляр класса
        /// </summary>
        private static FormGoTo instance = null;
        /// <summary>
        /// Окно редактирования
        /// </summary>
        private RichTextBoxEx editRtb = null;

        }
    }