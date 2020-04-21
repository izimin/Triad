using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;

using TriadPad.Properties;

namespace TriadPad.Forms
    {
    /// <summary>
    /// Главная форма
    /// </summary>
    public partial class FormMain : Form
        {
        /// <summary>
        /// Экземпляр формы
        /// </summary>
        private static FormMain instance = null;
        /// <summary>
        /// Список пунктов меню с горячими клавишами
        /// </summary>
        private List<ToolStripMenuItem> hotKeyMenuList = new List<ToolStripMenuItem>();
        /// <summary>
        /// Список пунктов меню с горячими клавишами
        /// </summary>
        public ReadOnlyCollection<ToolStripMenuItem> HotKeyMenuList = null;

        /// <summary>
        /// Конструктор
        /// </summary>
        private FormMain()
            {
            InitializeComponent();

            //Устанавливаем свойства окна редактирования
            InitializeRtbEdit();

            this.pageSetupDialog.PageSettings = new PageSettings();

            FillHotKeyMenuList();
            this.HotKeyMenuList = new ReadOnlyCollection<ToolStripMenuItem>( hotKeyMenuList );
            }


        /// <summary>
        /// Экземпляр формы
        /// </summary>
        public static FormMain Instance
            {
            get
                {
                if ( instance == null )
                    instance = new FormMain();
                return instance;
                }
            }


        /// <summary>
        /// Меню - список недавно использованных файлов
        /// </summary>
        public ToolStripMenuItem RecentFilesMenuItem
            {
            get
                {
                return this.tsmiRecentFiles;
                }
            }


        //Загрузка формы
        private void FormMain_Load( object sender, EventArgs e )
            {
            //Устанавливаем позицию формы
            this.Location = new Point( Settings.Default.FormMainLocationX, Settings.Default.FormMainLocationY );
            this.Size = new Size( Settings.Default.FormMainWidth, Settings.Default.FormMainHeight );
            this.WindowState = Properties.Settings.Default.FormMainState;
            }



        //Старт формы
        private void FormMain_Shown( object sender, EventArgs e )
            {
            //Читаем файл с опциями
            if ( File.Exists( Settings.Default.OptionFileName ) )
                {
                Options.Instance.OpenFromFile( Settings.Default.OptionFileName );
                }
            //Используем опции по умолчанию
            else
                {
                Options.Instance.SetOptions();
                }

            this.tsmiNewFile_Click( this, null );
            }


        //После закрытия главной формы
        private void FormMain_FormClosed( object sender, FormClosedEventArgs e )
            {
            //Сохраняем опции
            Options.Instance.SaveToFile( Settings.Default.OptionFileName );

            //Сохраняем старую позицию формы
            Settings.Default.FormMainState = this.WindowState;
            if ( this.WindowState == FormWindowState.Normal )
                {
                Settings.Default.FormMainLocationX = this.Location.X;
                Settings.Default.FormMainLocationY = this.Location.Y;
                Settings.Default.FormMainWidth = this.Width;
                Settings.Default.FormMainHeight = this.Height;
                }
            else
                {
                Settings.Default.FormMainLocationX = this.RestoreBounds.Location.X;
                Settings.Default.FormMainLocationY = this.RestoreBounds.Location.Y;
                Settings.Default.FormMainWidth = this.RestoreBounds.Size.Width;
                Settings.Default.FormMainHeight = this.RestoreBounds.Size.Height;
                }
            Settings.Default.Save();
            }


        /// <summary>
        /// Запрлнить список пунктов меню с горячими клавишами
        /// </summary>
        private void FillHotKeyMenuList()
            {
            this.hotKeyMenuList.Add( this.tsmiNewFile );
            this.hotKeyMenuList.Add( this.tsmiOpenFile );
            this.hotKeyMenuList.Add( this.tsmiSaveFile );
            this.hotKeyMenuList.Add( this.tsmiSaveAsFile );
            this.hotKeyMenuList.Add( this.tsmiPrint );
            this.hotKeyMenuList.Add( this.tsmiQuickPrint );
            this.hotKeyMenuList.Add( this.tsmiPrintPreview );
            this.hotKeyMenuList.Add( this.tsmiPrintSetup );
            this.hotKeyMenuList.Add( this.tsmiCutCurrentLine );
            this.hotKeyMenuList.Add( this.tsmiComment );
            this.hotKeyMenuList.Add( this.tsmiUncomment );
            this.hotKeyMenuList.Add( this.tsmiIncreaseIndent );
            this.hotKeyMenuList.Add( this.tsmiDecreaseIndent );
            this.hotKeyMenuList.Add( this.tsmiToLower );
            this.hotKeyMenuList.Add( this.tsmiToUpper );
            this.hotKeyMenuList.Add( this.tsmiSelectAll );
            this.hotKeyMenuList.Add( this.tsmiFind );
            this.hotKeyMenuList.Add( this.tsmiGoTo );
            this.hotKeyMenuList.Add( this.tsmiReplace );
            this.hotKeyMenuList.Add( this.tsmiTranslate );
            this.hotKeyMenuList.Add( this.tsmiCompile );
            this.hotKeyMenuList.Add( this.tsmiCompileAndRun );
            this.hotKeyMenuList.Add( this.tsmiRun );
            }


        /// <summary>
        /// Получить пункт меню по его имени
        /// </summary>
        /// <param name="menuItemName">Имя пункта меню</param>
        /// <param name="menuItem">Пункт меню</param>
        /// <returns>Успех поиска</returns>
        public bool GetMenuItem( string menuItemName, out ToolStripMenuItem menuItem )
            {
            foreach ( ToolStripMenuItem menuContainer in this.menuStrip.Items )
                if ( GetMenuItem( menuContainer, menuItemName, out menuItem ) )
                    return true;
            menuItem = null;
            return false;
            }


        /// <summary>
        /// Получить пункт меню по его имени
        /// </summary>
        /// <param name="container">Меню-контейнер</param>
        /// <param name="menuItemName">Имя пункта меню</param>
        /// <param name="menuItem">Пункт меню</param>
        /// <returns>Успех поиска</returns>
        private bool GetMenuItem( ToolStripMenuItem container, string menuItemName, out ToolStripMenuItem menuItem )
            {
            if ( container.DropDownItems.ContainsKey( menuItemName ) )
                {
                ToolStripItem item = container.DropDownItems[ menuItemName ];
                if ( item is ToolStripMenuItem )
                    {
                    menuItem = item as ToolStripMenuItem;
                    return true;
                    }
                else
                    {
                    menuItem = null;
                    return false;
                    }
                }
            else
                {
                foreach ( ToolStripItem menuContainer in container.DropDownItems )
                    if ( menuContainer is ToolStripMenuItem )
                        if ( GetMenuItem( menuContainer as ToolStripMenuItem, menuItemName, out menuItem ) )
                            return true;
                menuItem = null;
                return false;
                }
            }


          }
    }