using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

using tom;

namespace TriadPad
    {
    /// <summary>
    /// Режим работы операции поиска окончания слова
    /// </summary>
    public enum FindWordBreakMode
        {
        /// <summary>
        /// Перейти на начало слова до указанной позиции
        /// </summary>
        MoveWordLeft = 4,
        /// <summary>
        /// Перейти на начало слова после указанной позиции
        /// </summary>
        MoveWordRigth = 5,
        /// <summary>
        /// Перейти на конец слова до указанной позиции
        /// </summary>
        LeftBreak = 6,
        /// <summary>
        /// Перейти на конец слова после указанной позиции
        /// </summary>
        RigthBreak = 7
        }


    /// <summary>
    /// Все, что относится к редактированию RichTextBoxEx
    /// </summary>
    public partial class RichTextBoxEx
        {
        /// <summary>
        /// Для отслеживания вложенных вызовов
        /// </summary>
        private int updating = 0;
        private IntPtr oldEventMask = IntPtr.Zero;

        //Константы из Platform SDK.
        private const int EM_SETEVENTMASK = WM_USER + 69;
        private const int WM_SETREDRAW = 0x000B;
        private const int EM_FINDWORDBREAK = WM_USER + 76;


        /// <summary>
        /// Для вызова до начала редактирования текста в окне
        /// </summary>
        public void BeginUpdate()
            {
            //Для отслеживания вложенных вызовов
            ++updating;

            if ( updating > 1 )
                return;

            //Предотвращает появление любых событий на элементе
            oldEventMask = SendMessage( new HandleRef( this, Handle ), EM_SETEVENTMASK, IntPtr.Zero, IntPtr.Zero );

            //Предотвращает перерисовку элемента
            SendMessage( new HandleRef( this, Handle ), WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero );
            }


        /// <summary>
        /// Для вызова после редактирования текста в окне
        /// </summary>
        public void EndUpdate()
            {
            //Для отслеживания вложенных вызовов
            --updating;

            if ( updating > 0 )
                return;

            //Разрешает перерисовку элемента
            SendMessage( new HandleRef( this, Handle ), WM_SETREDRAW, new IntPtr( 1 ), IntPtr.Zero );

            //Разрешает появление событий
            SendMessage( new HandleRef( this, Handle ), EM_SETEVENTMASK, IntPtr.Zero, oldEventMask );
            }


        /// <summary>
        /// Номер первой строки, содержащей выделение
        /// </summary>
        public int SelectedFirstLineNumber
            {
            get
                {
                return this.GetLineFromCharIndex( this.GetFirstCharIndexOfCurrentLine() );
                }
            }


        /// <summary>
        /// Номер последней строки, содержащей выделение
        /// </summary>
        public int SelectedLastLineNumber
            {
            get
                {
                return this.GetLineFromCharIndex( this.GetFirstCharIndexOfCurrentLine() + this.SelectionLength );
                }
            }


        /// <summary>
        /// Номер первого выделенного символа в текущей строке
        /// </summary>
        public int SelectedChInCurrLine
            {
            get
                {
                return this.SelectionStart - this.GetFirstCharIndexOfCurrentLine();
                }
            }


        /// <summary>
        /// Вырезать текущую строку
        /// </summary>
        public void CutCurrentLine()
            {
            //Если в окне есть текст
            if ( this.TextLength > 0 )
                {
                this.BeginUpdate();
                //Номер текущей строки
                int currLineNumber = this.GetLineFromCharIndex( this.SelectionStart );
                this.SelectionStart = this.GetFirstCharIndexFromLine( currLineNumber );
                this.SelectionLength = this.Lines[ currLineNumber ].Length + 1;
                this.Cut();
                this.EndUpdate();
                //this.Invalidate();
                }
            }


        /// <summary>
        /// Вырезать строку
        /// </summary>
        /// <param name="lineNumber">Номер строки</param>
        public void RemoveLine( int lineNumber )
            {
            if ( lineNumber < 0 )
                return;

            int lineStartChNumber = this.GetFirstCharIndexFromLine( lineNumber );
            if ( lineStartChNumber != -1 )
                {
                this.SelectionStart = lineStartChNumber;
                CutCurrentLine();
                }
            }


        /// <summary>
        /// Создать интерфейс ITextDocument
        /// </summary>
        /// <returns>ITextDocument</returns>
        public ITextDocument CreateTomInterface()
            {
            //IRichEditOle интерфейс
            IntPtr theRichEditOle = IntPtr.Zero;

            //Сначала получаем IRichEditOle
            if ( SendMessage( new HandleRef( this, Handle ), EM_GETOLEINTERFACE, IntPtr.Zero, out theRichEditOle ) == IntPtr.Zero )
                {
                throw new System.ComponentModel.Win32Exception();
                }

            try
                {
                //Затем ITextDocument, который должен реализовывать IRichEditOle
                ITextDocument theTextDoc = (ITextDocument)Marshal.GetTypedObjectForIUnknown( theRichEditOle, typeof( ITextDocument ) );
                return theTextDoc;
                }
            finally
                {
                Marshal.Release( theRichEditOle );
                }
            }


        /// <summary>
        /// Заменить старый текст
        /// </summary>
        /// <param name="oldTextStartCh">Номер первого символа старого текста</param>
        /// <param name="oldTextLength">Длина старого текста</param>
        /// <param name="newText">Новый текст</param>
        public void ReplaceText( int oldTextStartCh, int oldTextLength, string newText )
            {
            //Если это недопустимый номер символа
            if ( oldTextStartCh < 0 )
                //Проверку ( oldTextStartCh >= this.TextLength ) т.к. это очень медленно
                return;
            //Если это недопустимая длина
            if ( oldTextLength <= 0 )
                return;

            ITextDocument textDocument = this.CreateTomInterface();
            ITextRange textRange = textDocument.Range( oldTextStartCh, oldTextStartCh + oldTextLength );
            textRange.Text = newText;

            Marshal.ReleaseComObject( textDocument );
            Marshal.ReleaseComObject( textRange );
            }


        /// <summary>
        /// Заменить старый текст в строке
        /// </summary>
        /// <remarks>Эта функция выполняется медленно, т.к. обращается к this.Lines[ lineNumber ]</remarks>
        /// <param name="lineNumber">Номер старой строки</param>
        /// <param name="newText">Текст новой строки</param>
        public void ReplaceText( int lineNumber, string newText )
            {
            ReplaceText( this.GetFirstCharIndexFromLine( lineNumber ),
                this.Lines[ lineNumber ].Length, newText );
            }


        /// <summary>
        /// Операция поиска границ слов
        /// </summary>
        /// <param name="mode">Режим работы</param>
        /// <param name="startChNumber">Номер стартового символа</param>
        /// <returns>Номер искомого символа</returns>
        public int FindWordBreak( FindWordBreakMode mode, int startChNumber )
            {
            IntPtr result = SendMessage( new HandleRef( this, Handle ), EM_FINDWORDBREAK, new IntPtr( (int)mode ), new IntPtr( startChNumber ) );
            return result.ToInt32();
            }


        /// <summary>
        /// Начало старого выделения
        /// </summary>
        private int oldSelectionStart = 0;
        /// <summary>
        /// Длина старого выделения
        /// </summary>
        private int oldSelectionLength = 0;
        private int oldFirstVisibleLineNumber = 0;

        /// <summary>
        /// Сохранить текущее выделение
        /// </summary>
        public void SaveCurrentSelection()
            {
            this.oldSelectionStart = this.SelectionStart;
            this.oldSelectionLength = this.SelectionLength;
            this.oldFirstVisibleLineNumber = this.FirstVisibleLineNumber;
            }


        /// <summary>
        /// Восстановить текущее выделение
        /// </summary>
        public void RestoreSelection()
            {
            int textLength = this.TextLength;

            //Восстанавливаем позицию курсора
            if ( this.oldSelectionStart < textLength )
                this.SelectionStart = this.oldSelectionStart;
            else
                this.SelectionStart = textLength;

            //Восстанавливаем длину выделения
            if ( this.oldSelectionStart + this.oldSelectionLength <= textLength )
                this.SelectionLength = this.oldSelectionLength;
            else
                this.SelectionLength = 0;

            //Восстанавливаем позицию прокрутки
            if ( this.FirstVisibleLineNumber != this.oldFirstVisibleLineNumber )
                this.Scroll( this.oldFirstVisibleLineNumber );
            }


        private const int EM_SETMARGINS = 0x00D3;
        private const int EC_LEFTMARGIN = 0x0001;
        private const int EC_RIGHTMARGIN = 0x0002;


        /// <summary>
        /// Отступ текста от границы слева
        /// </summary>
        public int LeftMargin
            {
            set
                {
                SendMessage( new HandleRef( this, Handle ), EM_SETMARGINS, new IntPtr( EC_LEFTMARGIN ), new IntPtr( value ) );
                }
            }




        }

    }