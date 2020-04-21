using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TriadPad
    {
    /// <summary>
    /// Опции, касающиеся недавно использованных файлов
    /// </summary>
    partial class Options
        {
        /// <summary>
        /// Список недавно использованных файлов
        /// </summary>
        private List<string> recentFileList = new List<string>();
        /// <summary>
        /// Максимальная длина списка недавно использованных файлов
        /// </summary>
        private int recentFileListMaxLength = 5;


        /// <summary>
        /// Применить опции, связанные со списком последних использованных файлов
        /// </summary>
        private void SetRecentFileOptions()
            {
            this.RecentFileListMaxLength = this.recentFileListMaxLength;
            }


        /// <summary>
        /// Максимальная длина списка недавно использованных файлов
        /// </summary>
        public int RecentFileListMaxLength
            {
            get 
                {
                return recentFileListMaxLength;
                }
            set 
                {
                recentFileListMaxLength = value;
                CheckRecentFileListLength();
                ShowRecentFiles();
                }
            }


        /// <summary>
        /// Проверить длину списка недавно использованных файлов
        /// </summary>
        private void CheckRecentFileListLength()
            {
            //Если список слишком длинный
            while ( this.recentFileList.Count > this.recentFileListMaxLength &&
                this.recentFileList.Count > 0 )
                {
                //Удаляем лишние файлы
                this.recentFileList.RemoveAt( 0 );
                }
            }


        /// <summary>
        /// Добавить недавно использованный файл
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        public void AddRecentFile( string fileName )
            {
            //Если такого файла еще не было
            if ( !this.recentFileList.Contains( fileName ) )
                {
                this.recentFileList.Add( fileName );
                }
            CheckRecentFileListLength();

            ShowRecentFiles();
            }


        /// <summary>
        /// Обработчик нажатия на недавно использованный файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecentFileMenuItem_Click( object sender, EventArgs e )
            {
            if ( sender is ToolStripMenuItem )
                {
                string fileName = ( sender as ToolStripMenuItem ).Text;
                
                //Если такой файл есть
                if ( File.Exists( fileName ) )
                    Forms.FormMain.Instance.OpenFile( fileName );
                else
                    ShowRecentFiles();
                }
            }


        /// <summary>
        /// Показать недавно использованные файлы
        /// </summary>
        private void ShowRecentFiles()
            {            
            //На случай испорченного файла сериализации
            if ( this.recentFileList == null )
                this.recentFileList = new List<string>();

            ToolStripMenuItem recentFilesItem = Forms.FormMain.Instance.RecentFilesMenuItem;
            recentFilesItem.DropDownItems.Clear();

            //Список потерянных файлов
            List<string> lostFileList = new List<string>();

            foreach ( string fileName in this.recentFileList )
                if ( File.Exists( fileName ) )
                    {
                    //Добавляем элемент меню
                    ToolStripMenuItem newItem = new ToolStripMenuItem();
                    newItem.Text = fileName;
                    newItem.Click += RecentFileMenuItem_Click;
                    recentFilesItem.DropDownItems.Add( newItem );
                    }
                else
                    lostFileList.Add( fileName );

            //Удаляем потерянные файлы
            foreach ( string lostFileName in lostFileList )
                this.recentFileList.Remove( lostFileName );
            }
        }
    }
