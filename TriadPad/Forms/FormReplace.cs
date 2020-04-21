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
    /// Форма поиска и замены
    /// </summary>
    internal partial class FormReplace : FormFind
        {
        /// <summary>
        /// Экземпляр формы
        /// </summary>
        private static FormReplace instance = null;


        /// <summary>
        /// Конструктор
        /// </summary>
        protected FormReplace()
            {
            InitializeComponent();
            }


        /// <summary>
        /// Экземпяр формы
        /// </summary>
        public static new FormReplace Instance
            {
            get
                {
                if ( instance == null )
                    instance = new FormReplace();
                return instance;
                }
            }


        /// <summary>
        /// Найти и заменить текст в окне редактирования
        /// </summary>
        /// <param name="rtb">Окно редактирования</param>
        public void Replace( RichTextBoxEx rtb )
            {
            Find( rtb );
            }


        //Кнопка - Заменить
        private void btReplace_Click( object sender, EventArgs e )
            {
            string replaceText = this.cbReplace.Text;
            //Сохраняем историю замен
            if ( replaceText != string.Empty && !this.cbReplace.Items.Contains( replaceText ) )
                this.cbReplace.Items.Add( replaceText );

            //Если поиск идет сверху вниз
            if ( !this.cbFindUp.Checked )
                this.findStartChNumber = this.editRtb.SelectionStart + this.cbReplace.Text.Length;
            else
                this.findStartChNumber = this.editRtb.SelectionStart;

            this.editRtb.ReplaceText( this.editRtb.SelectionStart, this.editRtb.SelectionLength, this.cbReplace.Text );            
            }


        //Кнопка найти далее и заменить
        private void btFindNextAndReplace_Click( object sender, EventArgs e )
            {
            this.btFindNext_Click( this, EventArgs.Empty );
            this.btReplace_Click( this, EventArgs.Empty );
            }


        //Кнопка - Заменить все
        private void btReplaceAll_Click( object sender, EventArgs e )
            {
            this.editRtb.BeginUpdate();

            //Кнопка - Начать сначала
            this.btFindRestart_Click( this, EventArgs.Empty );

            int findCount = 0;
            while ( this.FindNext() )
                {
                this.btReplace_Click( this, EventArgs.Empty );
                findCount++;
                }

            this.editRtb.EndUpdate();
            this.editRtb.Invalidate();
            MessageBox.Show( String.Format( "Всего замен сделано:  {0}", findCount ), "Внимание",
                MessageBoxButtons.OK, MessageBoxIcon.Information );
            }

        }
    }