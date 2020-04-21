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
    /// Форма поиска текста в оне редактирования
    /// </summary>
    internal partial class FormFind : Form
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        protected FormFind()
            {
            InitializeComponent();
            }


        /// <summary>
        /// Экземпляр формы
        /// </summary>
        public static FormFind Instance
            {
            get
                {
                if ( instance == null )
                    instance = new FormFind();
                return instance;
                }
            }


        /// <summary>
        /// Найти текст в окне редактирования
        /// </summary>
        /// <param name="rtb">Окно редактирования</param>
        public void Find( RichTextBoxEx rtb )
            {
            this.editRtb = rtb;

            this.cbFind.Text = rtb.SelectedText;
            this.findStartChNumber = rtb.SelectionStart;

            this.ShowDialog();
            rtb.Focus();
            }


        //Кнопка - Найти
        protected void btFindNext_Click( object sender, EventArgs e )
            {
            if ( !FindNext() )
                MessageBox.Show( "Ничего не найдено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }


        /// <summary>
        /// Найти далее
        /// </summary>
        /// <returns>Успех поиска</returns>
        protected bool FindNext()
            {
            string findText = this.cbFind.Text;
            //Сохраняем историю поиска
            if ( findText != string.Empty && !this.cbFind.Items.Contains( findText ) )
                this.cbFind.Items.Add( findText );

            //Опции поиска
            RichTextBoxFinds findOptions = RichTextBoxFinds.None;

            if ( this.cbMatchCase.Checked )
                findOptions |= RichTextBoxFinds.MatchCase;
            else if ( this.cbWholeWord.Checked )
                findOptions |= RichTextBoxFinds.WholeWord;
            else if ( this.cbFindUp.Checked )
                findOptions |= RichTextBoxFinds.Reverse;

            int chFindNumber = -1;

            //Поиск сверху вниз
            if ( !this.cbFindUp.Checked )
                chFindNumber = this.editRtb.Find( this.cbFind.Text, this.findStartChNumber, this.editRtb.TextLength + 1, findOptions );
            //Поиск снизу вверх
            else if ( this.findStartChNumber != 0 )
                chFindNumber = this.editRtb.Find( this.cbFind.Text, 0, this.findStartChNumber, findOptions );

            //Если ничего не найдено
            if ( chFindNumber == -1 )
                {
                this.editRtb.SelectionLength = 0;                
                return false;
                }
            else
                {
                //Выделяем найденное слово
                this.editRtb.BeginUpdate();

                //Поиск сверху вниз
                if ( !this.cbFindUp.Checked )
                    this.findStartChNumber = chFindNumber + this.cbFind.Text.Length;
                //Поиск снизу вверх
                else
                    this.findStartChNumber = chFindNumber;

                this.editRtb.SelectionStart = chFindNumber;
                this.editRtb.SelectionLength = this.cbFind.Text.Length;

                this.editRtb.EndUpdate();
                return true;
                }
            }


        //Кнопка - Начать сначала
        protected void btFindRestart_Click( object sender, EventArgs e )
            {
            //Поиск сверху вниз
            if ( !this.cbFindUp.Checked )
                {
                this.findStartChNumber = 0;
                this.editRtb.SelectionStart = 0;
                this.editRtb.SelectionLength = 0;
                }
            //Поиск снизу вверх
            else
                {
                this.findStartChNumber = this.editRtb.TextLength;
                this.editRtb.SelectionStart = this.editRtb.TextLength;
                this.editRtb.SelectionLength = 0;
                }
            }


        /// <summary>
        /// Экземпляр формы
        /// </summary>
        private static FormFind instance = null;
        /// <summary>
        /// Окно редактирования
        /// </summary>
        protected RichTextBoxEx editRtb = null;
        /// <summary>
        /// Позиция начала поиска
        /// </summary>
        protected int findStartChNumber = 0;

        }
    }