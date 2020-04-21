using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace TriadPad
    {
    /// <summary>
    /// Все, что относится к печати в RichTextBoxEx
    /// </summary>
    public partial class RichTextBoxEx
        {
        /// <summary>
        /// The EM_FORMATRANGE message formats a range of text in a rich edit control for a specific device.
        /// </summary>
        private const Int32 EM_FORMATRANGE = WM_USER + 57;

        /// <summary>
        /// This structure defines the coordinates of the upper-left and lower-right corners of a rectangle. 
        /// </summary>
        [StructLayout( LayoutKind.Sequential )]
        private struct RECT
            {
            public Int32 left;
            public Int32 top;
            public Int32 right;
            public Int32 bottom;
            }


        /// <summary>
        /// The CHARRANGE structure specifies a range of characters in a rich edit control.
        /// </summary>
        [StructLayout( LayoutKind.Sequential )]
        private struct CHARRANGE
            {
            /// <summary>
            /// Character position index immediately preceding the first character in the range. 
            /// </summary>
            public Int32 cpMin;
            /// <summary>
            /// Character position immediately following the last character in the range. 
            /// </summary>
            public Int32 cpMax;
            }

        [StructLayout( LayoutKind.Sequential )]
        private struct FORMATRANGE
            {
            /// <summary>
            /// Device to render to.
            /// </summary>
            public IntPtr hdc;
            /// <summary>
            /// Target device to format for. 
            /// </summary>
            public IntPtr hdcTarget;
            /// <summary>
            /// Area to render to. Units are measured in twips. 
            /// </summary>
            public RECT rc;
            /// <summary>
            /// Entire area of rendering device. Units are measured in twips. 
            /// </summary>
            public RECT rcPage;
            /// <summary>
            /// CHARRANGE structure that specifies the range of text to format. 
            /// </summary>
            public CHARRANGE chrg;
            }


        /// <summary>
        /// Calculate or render the contents of our RichTextBox for printing
        /// </summary>
        /// <param name="measureOnly">If true, only the calculation is performed, otherwise the text is rendered as well </param>
        /// <param name="e">The PrintPageEventArgs object from the PrintPage event</param>
        /// <param name="charFrom">Index of first character to be printed</param>
        /// <param name="charTo">Index of last character to be printed</param>
        /// <returns>(Index of last character that fitted on the page) + 1</returns>
        public int FormatRange( bool measureOnly, PrintPageEventArgs e, int charFrom, int charTo )
            {
            // Specify which characters to print
            CHARRANGE cr;
            cr.cpMin = charFrom;
            cr.cpMax = charTo;

            // Specify the area inside page margins
            RECT rc;
            rc.top = HundredthInchToTwips( e.MarginBounds.Top );
            rc.bottom = HundredthInchToTwips( e.MarginBounds.Bottom );
            rc.left = HundredthInchToTwips( e.MarginBounds.Left );
            rc.right = HundredthInchToTwips( e.MarginBounds.Right );

            // Specify the page area
            RECT rcPage;
            rcPage.top = HundredthInchToTwips( e.PageBounds.Top );
            rcPage.bottom = HundredthInchToTwips( e.PageBounds.Bottom );
            rcPage.left = HundredthInchToTwips( e.PageBounds.Left );
            rcPage.right = HundredthInchToTwips( e.PageBounds.Right );

            // Get device context of output device
            IntPtr hdc = e.Graphics.GetHdc();

            // Fill in the FORMATRANGE struct
            FORMATRANGE fr;
            fr.chrg = cr;
            fr.hdc = hdc;
            fr.hdcTarget = hdc;
            fr.rc = rc;
            fr.rcPage = rcPage;

            // Non-Zero wParam means render, Zero means measure
            IntPtr wParam = new IntPtr( measureOnly ? 0 : 1 );

            // Allocate memory for the FORMATRANGE struct and
            // copy the contents of our struct to this memory
            IntPtr lParam = Marshal.AllocCoTaskMem( Marshal.SizeOf( fr ) );
            Marshal.StructureToPtr( fr, lParam, false );

            // Send the actual Win32 message
            // This message returns the index of the last character that fits in the region, plus one.
            IntPtr res = SendMessage( new HandleRef( this, Handle ), EM_FORMATRANGE, wParam, lParam );

            // Free allocated memory
            Marshal.FreeCoTaskMem( lParam );

            // and release the device context
            e.Graphics.ReleaseHdc( hdc );

            return res.ToInt32();
            }


        /// <summary>
        /// Convert between 1/100 inch (unit used by the .NET framework) and twips (1/1440 inch, used by Win32 API calls)
        /// </summary>
        /// <param name="n">Value in 1/100 inch</param>
        /// <returns>Value in twips</returns>
        private Int32 HundredthInchToTwips( int n )
            {
            return (Int32)( n * 14.4 );
            }


        /// <summary>
        /// Free cached data from rich edit control after printing
        /// </summary>
        private void FormatRangeDone()
            {
            IntPtr lParam = new IntPtr( 0 );
            SendMessage( new HandleRef( this, Handle ), EM_FORMATRANGE, IntPtr.Zero, lParam );
            }


        /// <summary>
        /// Печать содержимого RichTextBox
        /// </summary>
        /// <param name="printerSettings">Настройки принтера</param>
        /// <param name="pageSettings">Параметры страницы</param>
        public void PrintRichTextContents( PrinterSettings printerSettings, PageSettings pageSettings )
            {
            PrintDocument printDoc = GetPrintDocument( printerSettings, pageSettings );

            // Start printing process
            try
                {
                printDoc.Print();
                }
            catch
            { }
            }


        /// <summary>
        /// Получить объект, используемый для печати
        /// </summary>
        /// <param name="printerSettings">Настройки принтера</param>
        /// <param name="pageSettings">Параметры страницы</param>
        /// <returns></returns>
        public PrintDocument GetPrintDocument( PrinterSettings printerSettings, PageSettings pageSettings )
            {
            PrintDocument printDoc = new PrintDocument();

            printDoc.PrinterSettings = printerSettings;
            printDoc.DefaultPageSettings = pageSettings;

            printDoc.BeginPrint += new PrintEventHandler( printDoc_BeginPrint );
            printDoc.PrintPage += new PrintPageEventHandler( printDoc_PrintPage );
            printDoc.EndPrint += new PrintEventHandler( printDoc_EndPrint );

            return printDoc;
            }


        /// <summary>
        /// Печать содержимого RichTextBox
        /// </summary>
        public void PrintRichTextContents()
            {
            PrintRichTextContents( new PrinterSettings(), new PageSettings() ); 
            }


        /// <summary>
        /// Variable to trace text to print for pagination
        /// </summary> 
        private int firstCharOnPage;


        //Обработчик начала печати
        private void printDoc_BeginPrint( object sender, PrintEventArgs e )
            {
            // Start at the beginning of the text
            firstCharOnPage = 0;
            }


        //Обработчик печати страницы
        private void printDoc_PrintPage( object sender, PrintPageEventArgs e )
            {
            // make the RichTextBoxEx calculate and render as much text as will
            // fit on the page and remember the last character printed for the
            // beginning of the next page
            firstCharOnPage = this.FormatRange( false, e, firstCharOnPage, this.TextLength );

            // check if there are more pages to print
            if ( firstCharOnPage < this.TextLength )
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
            }


        //Обработчик окончания печати
        private void printDoc_EndPrint( object sender, PrintEventArgs e )
            {
            // Clean up cached information
            this.FormatRangeDone();
            }


        }
    }
