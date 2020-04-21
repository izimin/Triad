using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using TriadPad.Forms;

namespace TriadPad
    {
    /// <summary>
    /// «адание гор€чих клавиш
    /// </summary>
    partial class Options
        {
        /// <summary>
        /// —писок гор€чих клавиш
        /// </summary>
        private SortedList<string, Keys> hotKeyList = new SortedList<string, Keys>();


        /// <summary>
        /// «аполнить список гор€чих клавиш
        /// </summary>
        private void FillHotkeyList()
            {
            if ( this.hotKeyList == null )
                this.hotKeyList = new SortedList<string, Keys>();

            foreach ( ToolStripMenuItem menuItem in FormMain.Instance.HotKeyMenuList )
                {
                if ( !this.hotKeyList.ContainsKey( menuItem.Name ) )
                    this.hotKeyList.Add( menuItem.Name, menuItem.ShortcutKeys );
                else
                    this.hotKeyList[ menuItem.Name ] = menuItem.ShortcutKeys;
                }
            }


        /// <summary>
        /// «адать гор€чие клавиши
        /// </summary>
        private void SetHotkeys()
            {
            if ( this.hotKeyList == null )
                return;

            foreach ( KeyValuePair<string, Keys> pair in this.hotKeyList )
                {
                ToolStripMenuItem menuItem;
                if ( FormMain.Instance.GetMenuItem( pair.Key, out menuItem ) )
                    {
                    menuItem.ShortcutKeys = pair.Value;
                    }
                }
            }
        }
    }
