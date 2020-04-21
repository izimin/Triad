using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Security.Permissions;

using tom;

namespace TriadPad
    {
    /// <summary>
    /// Расширенный RichTextBox
    /// </summary>
    public partial class RichTextBoxEx : RichTextBox
        {
        /// <summary>
        /// LoadLibrary
        /// </summary>
        /// <param name="libname"></param>
        /// <returns></returns>
        [DllImport( "kernel32.dll", CharSet = CharSet.Auto, SetLastError = true )]
        public static extern IntPtr LoadLibrary( string libname );

        private static IntPtr RichEditModuleHandle;
        private const string RichEditDllV3 = "RichEd20.dll";
        private const string RichEditDllV41 = "Msftedit.dll";

        private const string RichEditClassV3A = "RichEdit20A";
        private const string RichEditClassV3W = "RichEdit20W";
        private const string RichEditClassV41W = "RICHEDIT50W";


        /// <summary>
        /// Задание информации для создания контрола
        /// </summary>
        protected override CreateParams CreateParams
            {
            [SecurityPermission( SecurityAction.LinkDemand, UnmanagedCode = true )]
            get
                {
                if ( RichEditModuleHandle == IntPtr.Zero )
                    {
                    //попытаемся загрузить реализацию RichEdit v4.1 (Msftedit.dll, WinXP + SP1)
                    RichEditModuleHandle = LoadLibrary( RichEditDllV41 );
                    if ( RichEditModuleHandle == IntPtr.Zero )
                        {
                        MessageBox.Show( "Используем Richedit 2.0" );
                        //нет такой dll, используем стандартную реализацию (Riched20.dll)
                        return base.CreateParams;
                        }
                    }

                //используем более новую реализацию richedit'а
                CreateParams theParams = base.CreateParams;
                theParams.ClassName = RichEditClassV41W;
                return theParams;
                }
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        public RichTextBoxEx()
            {
            }

        
        /// <summary>
        /// Необходимость автоматического выравнивания текста
        /// </summary>
        private bool checkIndentation = false;        
        /// <summary>
        /// Необходимость вставки новой строки
        /// </summary>
        private bool insertNewLine = false;
        /// <summary>
        /// Последняя позиция курсора
        /// </summary>
        private int selectionStartOld = 0;


        /// <summary>
        /// Необходимость автоматического выравнивания текста
        /// </summary>
        public bool SaveIndentation
            {
            get
                {
                return checkIndentation;
                }
            set
                {
                checkIndentation = value;
                }
            }


        /// <summary>
        /// Обработка нажатия клавиш
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown( KeyEventArgs e )
            {
            //Если добавляется новая строка
            if ( this.checkIndentation && e.KeyCode == Keys.Enter )
                {
                insertNewLine = true;
                //Сохраняем позицию курсора
                selectionStartOld = this.SelectionStart;
                }

            base.OnKeyDown( e );
            }


        /// <summary>
        /// Нужно ли обрабатывать событие изменения текста
        /// </summary>
        private bool generateTextChangeEvent = true;


        /// <summary>
        /// Нужно ли обрабатывать событие изменения текста
        /// </summary>
        public bool GenerateTextChangeEvent
            {
            get { return generateTextChangeEvent; }
            set { generateTextChangeEvent = value; }
            }

        
        /// <summary>
        /// Обработка изменения текста
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged( EventArgs e )
            {
            if ( !generateTextChangeEvent )
                return;

            //Если нужно вставить новую строку
            if ( insertNewLine )
                {
                ITextDocument currTextDocument = this.CreateTomInterface();
                ITextRange currTextRange = currTextDocument.Range( 0, 0 );

                //Номер текущей строки
                int currLineNumber = this.GetLineFromCharIndex( selectionStartOld );

                //Текущая строка
                string currLine = this.Lines[ currLineNumber ];
                //Позиция курсора в текущей строке
                int cursorOffset = selectionStartOld - this.GetFirstCharIndexFromLine( currLineNumber );

                //Начало новой строки
                StringBuilder insertedStr = new StringBuilder();
                for ( int index = 0 ; index < currLine.Length ; index++ )
                    {
                    if ( index >= cursorOffset )
                        break;

                    char ch = currLine[ index ];

                    //Вставляем в новую строку только пробелы
                    if ( ch == ' ' )
                        insertedStr.Append( " " );
                    // и табуляции
                    else if ( ch == '\t' )
                        insertedStr.Append( "\t" );
                    //, идущие в начале предыдущей строки
                    else
                        break;
                    }

                currTextRange.SetRange( selectionStartOld + 1, selectionStartOld + 1 );
                currTextRange.Text = insertedStr.ToString();

                Marshal.ReleaseComObject( currTextDocument );
                Marshal.ReleaseComObject( currTextRange );

                //Восстанавливаем позицию курсора
                this.SelectionStart = this.GetFirstCharIndexFromLine( currLineNumber + 1 ) + insertedStr.Length;

                insertNewLine = false;
                }
            

            base.OnTextChanged( e );
            }


        /// <summary>
        /// Очистить форматирование текста
        /// </summary>
        public void ClearTextFormatting()
            {
            this.BeginUpdate();

            this.SaveCurrentSelection();

            //Закрашиваем все черным
            this.SelectionStart = 0;
            this.SelectionLength = this.TextLength;
            this.SelectionColor = Color.Black;

            this.RestoreSelection();

            this.EndUpdate();
            this.Invalidate();
            }


        //API функция посылки сообщений
        [DllImport( "user32.dll", CharSet = CharSet.Auto, SetLastError = false )]
        static extern IntPtr SendMessage( HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam );
        [DllImport( "User32.dll", CharSet = CharSet.Auto, SetLastError = false )]
        private static extern IntPtr SendMessage( HandleRef hWnd, uint message, IntPtr wParam, out IntPtr lParam );
        }
    }
