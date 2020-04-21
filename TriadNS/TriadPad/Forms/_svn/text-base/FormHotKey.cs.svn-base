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
    /// Форма выбора горячих клавиш
    /// </summary>
    public partial class FormHotKey : Form
        {
        /// <summary>
        /// Экземпляр класса
        /// </summary>
        private static FormHotKey instance = null;
        /// <summary>
        /// Горячая клавиша
        /// </summary>
        private Keys hotKey = Keys.None;
        /// <summary>
        /// Список доступных клавиш
        /// </summary>
        private Dictionary<string, Keys> availableKeyList = new Dictionary<string, Keys>();


        /// <summary>
        /// Конструктор формы
        /// </summary>
        private FormHotKey()
            {
            InitializeComponent();
            FillFormKeyList();

            if ( this.cbKey.Items.Count > 0 )
                this.cbKey.SelectedIndex = 0;
            }


        /// <summary>
        /// Экземпляр класса
        /// </summary>
        public static FormHotKey Instance
            {
            get
                {
                if ( instance == null )
                    instance = new FormHotKey();
                return instance;
                }
            }


        /// <summary>
        /// Горячая клавиша
        /// </summary>
        public Keys HotKey
            {
            get { return hotKey; }
            }


        /// <summary>
        /// Заполнить список доступных клавиш
        /// </summary>
        private void FillAvailableKeyList()
            {
            this.availableKeyList.Clear();

            //Добавляем буквы
            int currKey;
            for ( currKey = (int)Keys.A ; currKey < (int)Keys.Z ; currKey++ )
                this.availableKeyList.Add( ( (Keys)currKey ).ToString(), (Keys)currKey );

            //Добавляем цифры
            for ( currKey = (int)Keys.D0 ; currKey < (int)Keys.D9 ; currKey++ )
                this.availableKeyList.Add( ( (Keys)currKey ).ToString(), (Keys)currKey );
            for ( currKey = (int)Keys.NumPad0 ; currKey < (int)Keys.NumPad9 ; currKey++ )
                this.availableKeyList.Add( ( (Keys)currKey ).ToString(), (Keys)currKey );

            //Добавляем функциональные клавиши
            for ( currKey = (int)Keys.F1; currKey < (int)Keys.F12 ; currKey++ )
                this.availableKeyList.Add( ( (Keys)currKey ).ToString(), (Keys)currKey );

            //Добавляем специальные клавиши
            this.availableKeyList.Add( ( Keys.End ).ToString(), Keys.End );
            this.availableKeyList.Add( ( Keys.Home ).ToString(), Keys.Home );
            this.availableKeyList.Add( ( Keys.Delete ).ToString(), Keys.Delete );
            this.availableKeyList.Add( ( Keys.PageDown ).ToString(), Keys.PageDown );
            this.availableKeyList.Add( ( Keys.PageUp ).ToString(), Keys.PageUp );
            this.availableKeyList.Add( ( Keys.None ).ToString(), Keys.None );
            }


        /// <summary>
        /// Отобразить горячую клавишу
        /// </summary>
        /// <param name="currKey">Клавиша</param>
        private void ShowCurrentKey( Keys currKey )
            {
            this.cbControl.Checked = ( currKey & Keys.Control ) == Keys.Control;
            currKey &= ~Keys.Control;
            this.cbShift.Checked = ( currKey & Keys.Shift ) == Keys.Shift;
            currKey &= ~Keys.Shift;
            this.cbAlt.Checked = ( currKey & Keys.Alt ) == Keys.Alt;
            currKey &= ~Keys.Alt;

            this.cbKey.SelectedItem = currKey;
            }


        /// <summary>
        /// Получить сочетание горячих клавиш
        /// </summary>
        /// <param name="currKey">Текущая горячая клавиша</param>
        /// <returns>Сочетание клавиш</returns>
        public bool GetHotKey( Keys currKey )
            {
            this.hotKey = currKey;

            ShowCurrentKey( currKey ); 

            if ( this.ShowDialog() == DialogResult.OK )
                {
                this.hotKey = (Keys)this.cbKey.SelectedItem;

                if ( this.hotKey != Keys.None )
                    {
                    if ( this.cbShift.Checked )
                        this.hotKey |= Keys.Shift;
                    else
                        this.hotKey &= ~Keys.Shift;

                    if ( this.cbControl.Checked )
                        this.hotKey |= Keys.Control;
                    else
                        this.hotKey &= ~Keys.Control;

                    if ( this.cbAlt.Checked )
                        this.hotKey |= Keys.Alt;
                    else
                        this.hotKey &= ~Keys.Alt;
                    }
                return true;
                }
            return false;
            }



        /// <summary>
        /// Заполнить список клавиш на форме
        /// </summary>
        private void FillFormKeyList()
            {
            FillAvailableKeyList();

            this.cbKey.Items.Clear();
            foreach ( Keys key in this.availableKeyList.Values )
                {
                this.cbKey.Items.Add( key );
                }
            }


        //Кнопка - OK
        private void btOk_Click( object sender, EventArgs e )
            {
            this.DialogResult = DialogResult.OK;
            }


        //Кнопка - Отмена
        private void btCancel_Click( object sender, EventArgs e )
            {
            this.DialogResult = DialogResult.Cancel;
            }

        }
    }