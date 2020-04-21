using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace TriadPad.Forms
    {
    /// <summary>
    /// Все, что относится к печати в главной форме
    /// </summary>
    partial class FormMain
        {
        /// <summary>
        /// Задать параметры печати
        /// </summary>
        private void SetPrintParameters()
            {
            this.pageSetupDialog.ShowDialog();
            }


        /// <summary>
        /// Печать листинга программы
        /// </summary>
        private void PrintCurrentDocument()
            {
            if ( this.printDialog.ShowDialog() == DialogResult.OK )
                {
                this.rtbText.PrintRichTextContents( this.printDialog.PrinterSettings, this.pageSetupDialog.PageSettings );
                }
            }


        /// <summary>
        /// Предварительный просмотр
        /// </summary>
        private void PrintPreviewDocument()
            {
            this.printPreviewDialog.Document = this.rtbText.GetPrintDocument( this.printDialog.PrinterSettings,
                this.pageSetupDialog.PageSettings );
            this.printPreviewDialog.ShowDialog();
            }
        }
    }
