using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using TriadPad.Properties;

namespace TriadPad.Forms
    {
    /// <summary>
    /// Форма настройки параметров компиляции
    /// </summary>
    public partial class FormOptions : Form
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public FormOptions()
            {
            InitializeComponent();
            }        


        //Кнопка - Задать цвет граничных ключевых слов
        private void btPickBorderKeyColor_Click( object sender, EventArgs e )
            {
            this.colorDialog.Color = Options.Instance.SyntaxBoundColor;
            if ( this.colorDialog.ShowDialog() == DialogResult.OK )
                {
                Options.Instance.SyntaxBoundColor = this.colorDialog.Color;
                }
            }


        //Кнопка - Задать цвет типов
        private void btPickTypeKeyColor_Click( object sender, EventArgs e )
            {
            this.colorDialog.Color = Options.Instance.SyntaxTypeColor; 
            if ( this.colorDialog.ShowDialog() == DialogResult.OK )
                {
                Options.Instance.SyntaxTypeColor = this.colorDialog.Color;
                }
            }


        //Кнопка - Задать цвет комментариев
        private void btPickCommentColor_Click( object sender, EventArgs e )
            {
            this.colorDialog.Color = Options.Instance.SyntaxCommentColor;
            if ( this.colorDialog.ShowDialog() == DialogResult.OK )
                {
                Options.Instance.SyntaxCommentColor = this.colorDialog.Color;
                }
            }


        //Кнопка - Задать цвет операторов
        private void btPickOperatorKeyColor_Click( object sender, EventArgs e )
            {
            this.colorDialog.Color = Options.Instance.SyntaxOperatorColor;
            if ( this.colorDialog.ShowDialog() == DialogResult.OK )
                {
                Options.Instance.SyntaxOperatorColor = this.colorDialog.Color;
                }
            }


        //Кнопка - Задать шрифт текста в окне редактирования
        private void btSetTextFont_Click( object sender, EventArgs e )
            {
            this.fontDialog.Font = Options.Instance.TextFont;
            if ( this.fontDialog.ShowDialog() == DialogResult.OK )
                {
                Options.Instance.TextFont = this.fontDialog.Font;
                }
            }


        //Кнопка - Задать местоположение результирующих сборок
        private void btSetCompiledDllPath_Click( object sender, EventArgs e )
            {
            this.folderBrowserDialog.SelectedPath = Options.Instance.CompiledDllPath;
            
            //Если указана текущая папка
            if ( this.folderBrowserDialog.SelectedPath == "." )
                {
                this.folderBrowserDialog.SelectedPath = Environment.CurrentDirectory;
                }
            if ( this.folderBrowserDialog.ShowDialog() == DialogResult.OK )
                {
                Options.Instance.CompiledDllPath = this.folderBrowserDialog.SelectedPath;
                }
            }



        //Показ формы
        private void FormOptions_Shown( object sender, EventArgs e )
            {
            FillMenuHotKeyList();

            //Читаем параметры
            this.cbShowFullErrInfo.Checked = Options.Instance.ShowRichCompileErrorMessage;
            this.cbSyntaxHighlighting.Checked = Options.Instance.SyntaxHighlighting;
            this.cbSaveTextIndentation.Checked = Options.Instance.SaveTextIndentation;
            this.cbCursorPosition.Checked = Options.Instance.ShowCursorPosition;
            this.cbForcedScrollBars.Checked = Options.Instance.ForcedScrollBars;
            this.nudMaxRecentFileListLength.Value = Options.Instance.RecentFileListMaxLength;
            this.cbLineNumbers.Checked = Options.Instance.ShowLineNumbers;

            //Читаем режим компиляции
            switch ( Options.Instance.CompilationMode )
                {
                case CompilationMode.Model:
                    this.rbCompileModel.Checked = true;
                    break;
                case CompilationMode.Routine:
                    this.rbCompileRoutine.Checked = true;
                    break;
                case CompilationMode.Structure:
                    this.rbCompileStructure.Checked = true;
                    break;
                case CompilationMode.Design:
                    this.rbCompileDesign.Checked = true;
                    break;
                case CompilationMode.IProcedure:
                    this.rbCompileIProcedure.Checked = true;
                    break;
                case CompilationMode.ICondition:
                    this.rbCompileICondition.Checked = true;
                    break;
                }
            }

        //Кнопка - OK
        private void btOK_Click( object sender, EventArgs e )
            {
            //Сохраняем параметры (проверки - чтобы зря время не тратить)
            if ( Options.Instance.ShowRichCompileErrorMessage != this.cbShowFullErrInfo.Checked )
                Options.Instance.ShowRichCompileErrorMessage = this.cbShowFullErrInfo.Checked;
            if (  Options.Instance.SyntaxHighlighting != this.cbSyntaxHighlighting.Checked )
                Options.Instance.SyntaxHighlighting = this.cbSyntaxHighlighting.Checked;
            if ( Options.Instance.SaveTextIndentation != this.cbSaveTextIndentation.Checked ) 
                Options.Instance.SaveTextIndentation = this.cbSaveTextIndentation.Checked;
            if ( Options.Instance.ShowCursorPosition != this.cbCursorPosition.Checked ) 
                Options.Instance.ShowCursorPosition = this.cbCursorPosition.Checked;
            if ( Options.Instance.ForcedScrollBars != this.cbForcedScrollBars.Checked )
                Options.Instance.ForcedScrollBars = this.cbForcedScrollBars.Checked;
            if ( Options.Instance.RecentFileListMaxLength != (int)this.nudMaxRecentFileListLength.Value )
                Options.Instance.RecentFileListMaxLength = (int)this.nudMaxRecentFileListLength.Value;
            if ( Options.Instance.ShowLineNumbers != this.cbLineNumbers.Checked ) 
            Options.Instance.ShowLineNumbers = this.cbLineNumbers.Checked;

            //Устанавливаем режим компиляции
            if ( this.rbCompileModel.Checked )
                Options.Instance.CompilationMode = CompilationMode.Model;
            else if ( this.rbCompileStructure.Checked )
                Options.Instance.CompilationMode = CompilationMode.Structure;
            else if ( this.rbCompileRoutine.Checked )
                Options.Instance.CompilationMode = CompilationMode.Routine;
            else if ( this.rbCompileDesign.Checked )
                Options.Instance.CompilationMode = CompilationMode.Design;
            else if ( this.rbCompileIProcedure.Checked )
                Options.Instance.CompilationMode = CompilationMode.IProcedure;
            else if ( this.rbCompileICondition.Checked )
                Options.Instance.CompilationMode = CompilationMode.ICondition;
            
            this.DialogResult = DialogResult.OK;
            }


        //Кнопка - отмена
        private void btCancel_Click( object sender, EventArgs e )
            {
            this.DialogResult = DialogResult.Cancel;
            }


        /// <summary>
        /// Используемые горячие клавиши
        /// </summary>
        private Dictionary<ToolStripMenuItem, Keys> hotKeyList = new Dictionary<ToolStripMenuItem, Keys>();


        /// <summary>
        /// Заполнить список команд меню
        /// </summary>
        private void FillMenuHotKeyList()
            {
            this.hotKeyList.Clear();

            Operations.FillSpecialList( this.lvHotKeys, FormMain.Instance.HotKeyMenuList.GetEnumerator(), 
                delegate( ToolStripMenuItem menuItem )
                    {
                    ListViewItem newItem = new ListViewItem( menuItem.Text );
                    newItem.SubItems.Add( menuItem.ShortcutKeys.ToString() );
                    newItem.Tag = menuItem;
                    this.hotKeyList.Add( menuItem, menuItem.ShortcutKeys );
                    return newItem;
                    } );
            }


        //Настройка горячей клавиши
        private void lvHotKeys_MouseDoubleClick( object sender, MouseEventArgs e )
            {
            foreach ( ListViewItem selectedItem in this.lvHotKeys.SelectedItems )
                {
                ToolStripMenuItem menuItem = selectedItem.Tag as ToolStripMenuItem;
                if ( menuItem == null )
                    return;

                if ( FormHotKey.Instance.GetHotKey( menuItem.ShortcutKeys ) ) 
                    {
                    Keys newHotKey = FormHotKey.Instance.HotKey;
                    
                    //Если горячая клавиша изменилась
                    if ( newHotKey != menuItem.ShortcutKeys )
                        {
                        //Если эта клавиша ранее не использовалась
                        if ( !this.hotKeyList.ContainsValue( newHotKey ) || newHotKey == Keys.None )
                            {
                            try
                                {
                                menuItem.ShortcutKeys = newHotKey;
                                this.hotKeyList[ menuItem ] = newHotKey;
                                }
                            catch ( InvalidEnumArgumentException )
                                {
                                MessageBox.Show( "Выбрана недопустимая горячая клавиша", "Ошибка", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error );
                                }
                            }
                        else
                            {
                            MessageBox.Show( "Выбранная горячая клавиша уже используется", "Ошибка", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error );
                            }
                        }
                    }
                }

            FillMenuHotKeyList();
            }

        }
    }