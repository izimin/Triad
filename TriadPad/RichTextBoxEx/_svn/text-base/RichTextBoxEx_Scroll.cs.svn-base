using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace TriadPad
    {
    /// <summary>
    /// Команды прокрутки
    /// </summary>
    public enum ScrollBarCommand : int
        {
        /// <summary>
        /// Одна строка вверх
        /// </summary>
        LineUp = 0,
        /// <summary>
        /// Одна строка вниз
        /// </summary>
        LineDown = 1,
        /// <summary>
        /// Одна страница вверх
        /// </summary>
        PageUp = 2,
        /// <summary>
        /// Одна страница вниз
        /// </summary>
        PageDown = 3,
        /// <summary>
        /// На самый верх
        /// </summary>
        Top = 6,
        /// <summary>
        /// На самый низ
        /// </summary>
        Bottom = 7
        }


    /// <summary>
    /// Направление прокрутки
    /// </summary>
    public enum ScrollDirection
        {
        /// <summary>
        /// Вертикальная
        /// </summary>
        Vertical,
        /// <summary>
        /// Горизонтальная
        /// </summary>
        Horizontal
        }


    /// <summary>
    /// Все, что относится к прокрутке
    /// </summary>
     public partial class RichTextBoxEx
        {
        /// <summary>
        /// Вертикальная прокрутка
        /// </summary>
        private const int WM_VSCROLL = 0x0115;
        /// <summary>
        /// Горизонтальная прокрутка
        /// </summary>
        private const int WM_HSCROLL = 0x0114;
        private const int SB_VERT = 1;
        private const int SB_HORZ = 0;
        private const int WM_USER = 0x0400;
        private const int EM_SETSCROLLPOS = WM_USER + 222;
        private const int EM_GETOLEINTERFACE = WM_USER + 60;
        private const int EM_LINESCROLL = 0x00B6;

        /// <summary>
        /// Точка
        /// </summary>
        [StructLayout( LayoutKind.Sequential )]
        private struct POINT
            {
            public int X;
            public int Y;
            }


        //API функция получения позиции прокрутки
        [DllImport( "user32", CharSet = CharSet.Auto )]
        private static extern int GetScrollPos( HandleRef hWnd, int nBar ); 


        /// <summary>
        /// Прокрутка
        /// </summary>
        /// <param name="direction">Направление</param>
        /// <param name="command">Команда прокрутки</param>
        public void Scroll( ScrollDirection direction, ScrollBarCommand command )
            {
            if ( direction == ScrollDirection.Vertical )
                SendMessage( new HandleRef( this, Handle ), WM_VSCROLL, new IntPtr( (int)command ), IntPtr.Zero );
            else if ( direction == ScrollDirection.Horizontal )
                SendMessage( new HandleRef( this, Handle ), WM_HSCROLL, new IntPtr( (int)command ), IntPtr.Zero );
            }


        /// <summary>
        /// Прокрутить
        /// </summary>
        /// <remarks>Позицию можно получать с помощью свойства ScrollPosition</remarks>
        /// <param name="position">Конечная позиция</param>
        public void Scroll( Point position )
            {
            POINT point;
            point.X = position.X;
            point.Y = position.Y;
            IntPtr lPoint = Marshal.AllocCoTaskMem( Marshal.SizeOf( point ) ); ;
            Marshal.StructureToPtr( point, lPoint, false );
            
            SendMessage( new HandleRef( this, Handle ), EM_SETSCROLLPOS, IntPtr.Zero, lPoint );

            Marshal.FreeCoTaskMem( lPoint );
            }


        /// <summary>
        /// Прокрутить
        /// </summary>
        /// <param name="lineIndex">Номер строки, на которую нужно перейти</param>
        public void Scroll( int lineIndex )
            {
            //Если это недопустимый номер строки
            if ( lineIndex < 0 || lineIndex >= this.Lines.Length )
                return;

            this.SelectionStart = this.GetFirstCharIndexFromLine( lineIndex );
            this.ScrollToCaret();
            }


        /// <summary>
        /// Прокрутить
        /// </summary>
        /// <param name="vLineCount">На сколько строк по вертикали</param>
        public void ScrollV( int vLineCount )
            {
            SendMessage( new HandleRef( this, Handle ), EM_LINESCROLL, IntPtr.Zero, new IntPtr( vLineCount ) );
            }


        /// <summary>
        /// Текущая позиция прокрутки
        /// </summary>
        public Point ScrollPosition
            {
            get
                {
                return new Point( ScrollHPosition, ScrollVPosition );
                }
            }


        /// <summary>
        /// Текущая позиция вертикальной прокрутки
        /// </summary>
        public int ScrollVPosition
            {
            get
                {
                return GetScrollPos( new HandleRef( this, Handle ), SB_VERT );
                }
            }


        /// <summary>
        /// Текущая позиция горизонтальной прокрутки
        /// </summary>
        public int ScrollHPosition
            {
            get
                {
                return GetScrollPos( new HandleRef( this, Handle ), SB_HORZ );
                }
            }


        /// <summary>
        /// Номер первой видимой строки
        /// </summary>
        public int FirstVisibleLineNumber
            {
            get
                {
                return this.GetLineFromCharIndex( this.GetCharIndexFromPosition(
                    this.ClientRectangle.Location ) );
                }
            }


        /// <summary>
        /// Номер последней видимой строки
        /// </summary>
        public int LastVisibleLineNumber
            {
            get
                {
                Point rightBottomPoint = new Point( this.ClientRectangle.Right, this.ClientRectangle.Bottom );
                return this.GetLineFromCharIndex( this.GetCharIndexFromPosition( rightBottomPoint ) );
                }
            }


        /// <summary>
        /// Номер первого видимого символа
        /// </summary>
        public int FirstVisibleChNumber
            {
            get
                {
                return this.GetFirstCharIndexFromLine( FirstVisibleLineNumber );
                }
            }


        /// <summary>
        /// Номер последнего видимого символа
        /// </summary>
        public int LastVisibleChNumber
            {
            get
                {
                int lastVisibleLineNumber = LastVisibleLineNumber;
                if ( lastVisibleLineNumber < this.Lines.Length )
                    return this.GetFirstCharIndexFromLine( lastVisibleLineNumber ) + this.Lines[ lastVisibleLineNumber ].Length - 1;
                else
                    return 0;
                }
            }
        }
    }
