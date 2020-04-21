using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TriadPad
    {
    /// <summary>
    /// Опции, связанные с редактированием
    /// </summary>
    partial class Options
        {
        /// <summary>
        /// Применить опции редактирования к системе
        /// </summary>
        private void SetEditOptions()
            {
            this.TextFont = this.textFont;

            //Чтобы десять раз синтаксис не подсвечивать
            Forms.Syntax.Instance.Enabled = false;

            this.SyntaxCommentColor = this.syntaxCommentColor;
            this.SyntaxTypeColor = this.syntaxTypeColor;
            this.SyntaxOperatorColor = this.syntaxOperatorColor;
            this.SyntaxBoundColor = this.syntaxBoundColor;

            Forms.Syntax.Instance.Enabled = true;
            //Cвойство подсветки нужно устанавливать после задания цветов подсветки и шрифта
            this.SyntaxHighlighting = this.syntaxHighlighting;

            this.ShowCursorPosition = this.showCursorPosition;
            this.ForcedScrollBars = this.forcedScrollBars;
            this.SaveTextIndentation = this.saveTextIndentation;
            this.ShowLineNumbers = this.showLineNumbers;

            Forms.FormMain.Instance.RtbText.Invalidate();
            }


        /// <summary>
        /// Подсветка синтаксиса
        /// </summary>
        private bool syntaxHighlighting = true;


        /// <summary>
        /// Подсветка синтаксиса
        /// </summary>
        public bool SyntaxHighlighting
            {
            get
                {
                return syntaxHighlighting;
                }
            set
                {
                syntaxHighlighting = value;
                TriadPad.Forms.Syntax.Instance.Enabled = value;
                TriadPad.Forms.FormMain.Instance.RtbText.ClearTextFormatting();
                TriadPad.Forms.Syntax.Instance.ClearHistory();
                TriadPad.Forms.Syntax.Instance.Select( TriadPad.Forms.FormMain.Instance.RtbText );
                }
            }


        /// <summary>
        /// Автоматическая поддержка отступов
        /// </summary>
        private bool saveTextIndentation = true;


        /// <summary>
        /// Автоматическая поддержка отступов
        /// </summary>
        public bool SaveTextIndentation
            {
            get
                {
                return saveTextIndentation;
                }
            set
                {
                saveTextIndentation = value;
                TriadPad.Forms.FormMain.Instance.RtbText.SaveIndentation = value;
                }
            }


        /// <summary>
        /// Задание цвета подсветки типов
        /// </summary>
        private Color syntaxTypeColor = Color.DarkRed;


        /// <summary>
        /// Задание цвета подсветки типов
        /// </summary>
        public Color SyntaxTypeColor
            {
            get
                {
                return syntaxTypeColor;
                }
            set
                {
                syntaxTypeColor = value;
                TriadPad.Forms.Syntax.Instance.ClearHistory();
                TriadPad.Forms.Syntax.Instance.Select( TriadPad.Forms.FormMain.Instance.RtbText );
                }
            }


        /// <summary>
        /// Задание цвета подсветки операторов
        /// </summary>
        private Color syntaxOperatorColor = Color.Indigo;


        /// <summary>
        /// Задание цвета подсветки операторов
        /// </summary>
        public Color SyntaxOperatorColor
            {
            get
                {
                return syntaxOperatorColor;
                }
            set
                {
                syntaxOperatorColor = value;
                TriadPad.Forms.Syntax.Instance.ClearHistory();
                TriadPad.Forms.Syntax.Instance.Select( TriadPad.Forms.FormMain.Instance.RtbText );
                }
            }


        /// <summary>
        /// Задание цвета подсветки границ
        /// </summary>
        private Color syntaxBoundColor = Color.Blue;


        /// <summary>
        /// Задание цвета подсветки границ
        /// </summary>
        public Color SyntaxBoundColor
            {
            get
                {
                return syntaxBoundColor;
                }
            set
                {
                syntaxBoundColor = value;
                TriadPad.Forms.Syntax.Instance.ClearHistory();
                TriadPad.Forms.Syntax.Instance.Select( TriadPad.Forms.FormMain.Instance.RtbText );
                }
            }


        /// <summary>
        /// Задание цвета подсветки комментариев
        /// </summary>
        private Color syntaxCommentColor = Color.DarkGreen;


        /// <summary>
        /// Задание цвета подсветки комментариев
        /// </summary>
        public Color SyntaxCommentColor
            {
            get
                {
                return syntaxCommentColor;
                }
            set
                {
                syntaxCommentColor = value;
                TriadPad.Forms.Syntax.Instance.ClearHistory();
                TriadPad.Forms.Syntax.Instance.Select( TriadPad.Forms.FormMain.Instance.RtbText );
                }
            }


        /// <summary>
        /// Нужно ли показывать позицию курсора
        /// </summary>
        private bool showCursorPosition = true;


        /// <summary>
        /// Нужно ли показывать позицию курсора
        /// </summary>
        public bool ShowCursorPosition
            {
            get
                {
                return showCursorPosition;
                }
            set
                {
                showCursorPosition = value;
                }
            }


        /// <summary>
        /// Шрифт текста в окне редактирования
        /// </summary>
        private Font textFont = new Font( "Courier New", 10F, FontStyle.Bold );


        /// <summary>
        /// Шрифт текста в окне редактирования
        /// </summary>
        public Font TextFont
            {
            get
                {
                return textFont;
                }
            set
                {
                textFont = value;
                TriadPad.Forms.FormMain.Instance.RtbText.Font = value;
                TriadPad.Forms.FormMain.Instance.NumberLabel.Font = value;

                TriadPad.Forms.Syntax.Instance.ClearHistory();
                TriadPad.Forms.Syntax.Instance.Select( TriadPad.Forms.FormMain.Instance.RtbText );
                }
            }


        /// <summary>
        /// Принудительный показ полос прокрутки
        /// </summary>
        private bool forcedScrollBars = false;


        /// <summary>
        /// Принудительный показ полос прокрутки
        /// </summary>
        public bool ForcedScrollBars
            {
            get
                {
                return forcedScrollBars;
                }
            set
                {
                forcedScrollBars = value;

                if ( forcedScrollBars )
                    TriadPad.Forms.FormMain.Instance.RtbText.ScrollBars =
                        System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
                else
                    TriadPad.Forms.FormMain.Instance.RtbText.ScrollBars =
                        System.Windows.Forms.RichTextBoxScrollBars.Both;
                TriadPad.Forms.FormMain.Instance.RtbText.Refresh();
                }
            }


        /// <summary>
        /// Показ номеров строк
        /// </summary>
        private bool showLineNumbers = true;


        /// <summary>
        /// Показ номеров строк
        /// </summary>
        public bool ShowLineNumbers
            {
            get
                {
                return showLineNumbers;
                }
            set
                {
                showLineNumbers = value;
                if ( value )
                    TriadPad.Forms.FormMain.Instance.SynchronizeLineNumbers();
                else
                    TriadPad.Forms.FormMain.Instance.NumberLabel.Text = "";
                }
            }

        }
    }
