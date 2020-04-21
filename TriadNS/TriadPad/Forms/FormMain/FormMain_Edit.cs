using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

using TriadPad.Properties;

namespace TriadPad.Forms
    {
    /// <summary>
    /// Все, что относится к редактированию текста в главной форме
    /// </summary>
    partial class FormMain
        {
        /// <summary>
        /// Инициализируем окно редактирования
        /// </summary>
        private void InitializeRtbEdit()
            {
            //Необходимость автоматического выравнивания
            this.rtbText.SaveIndentation = true;

            this.rtbText.LeftMargin = 5;

            //Устанавливаем обработчики событий
            this.rtbText.TextChanged += this.rtbText_TextChanged;
            this.rtbText.SelectionChanged += this.rtbText_SelectionChanged;
            this.rtbText.VScroll += this.rtbText_VScroll;
            this.rtbText.Resize += this.rtbText_Resize;
            }


        /// <summary>
        /// Окно редактирования
        /// </summary>
        internal RichTextBoxEx RtbText
            {
            get { return rtbText; }
            }


        /// <summary>
        /// Номера строк
        /// </summary>
        internal Label NumberLabel
            {
            get { return numberLabel; }
            }


        /// <summary>
        /// Создать новый файл в окне редактирования
        /// </summary>
        private void CreateNewFile()
            {
            this.rtbText.Clear();
            this.rtbListing.Clear();

            //Очистить историю выделения
            Syntax.Instance.ClearHistory();

            //Выбираем начальное заполнение, исходя из типа проекта
            switch ( Options.Instance.CompilationMode )
                {
                case CompilationMode.Model:
                    this.rtbText.AppendText( Resources.ModelInitialCode );
                    break;
                case CompilationMode.Routine:
                    this.rtbText.AppendText( Resources.RoutineInitialCode );
                    break;
                case CompilationMode.Structure:
                    this.rtbText.AppendText( Resources.StructureInitialCode );
                    break;
                case CompilationMode.Design:
                    this.rtbText.AppendText( Resources.DesignInitialCode );
                    break;
                case CompilationMode.IProcedure:
                    this.rtbText.AppendText( Resources.IProcedureInitialCode );
                    break;
                case CompilationMode.ICondition:
                    this.rtbText.AppendText( Resources.IConditionInitialCode );
                    break;
                }

            this.currFileName = NewFileName;
            this.Text = MainFormText + " - " + this.currFileName;

            //Прокручиваем наверх
            this.rtbText.Scroll( ScrollDirection.Vertical, ScrollBarCommand.Top );
            }


        /// <summary>
        /// Открыть файл в окне редактирования
        /// </summary>
        /// <param name="fileName">Имя открываемого файла</param>
        public void OpenFile( string fileName )
            {
            this.currFileName = fileName;

            //Очистить историю выделения
            Syntax.Instance.ClearHistory();

            this.rtbText.LoadFile( fileName, RichTextBoxStreamType.PlainText );
            this.rtbCode.Clear();
            this.rtbListing.Clear();
            this.Text = MainFormText + " - " + Path.GetFileName( fileName );

            //Добавляем файл в список недавно использованных
            Options.Instance.AddRecentFile( fileName );
            }


        /// <summary>
        /// Сохранить файл как
        /// </summary>
        /// <param name="fileName">Новое имя файла</param>
        private void SaveFileAs( string fileName )
            {
            this.currFileName = fileName;
            this.rtbText.SaveFile( fileName, RichTextBoxStreamType.PlainText );
            this.Text = MainFormText + " - " + Path.GetFileName( fileName );

            //Добавляем файл в список недавно использованных
            Options.Instance.AddRecentFile( fileName );
            }


        /// <summary>
        /// Получить отступ строки
        /// </summary>
        /// <param name="lineStr">Разбираемая строка</param>
        /// <returns>Отступ у строки</returns>
        private static StringBuilder GetStringIndent( string lineStr )
            {
            StringBuilder indentStr = new StringBuilder();

            int lineStrLength = lineStr.Length;
            for ( int chIndex = 0 ; chIndex < lineStrLength ; chIndex++ )
                {
                char ch = lineStr[ chIndex ];
                if ( ch != ' ' && ch != '\t' )
                    break;
                indentStr.Append( ch );
                }
            return indentStr;
            }


        /// <summary>
        /// Закомментировать выделенные строки в окне редактирования
        /// </summary>
        private void Comment()
            {
            this.rtbText.BeginUpdate();
            Syntax.Instance.Enabled = false;

            //Сохраняем текущее выделение
            int oldSelectionStart = this.rtbText.SelectionStart;
            //Необходимость восстанавливать длину выделения
            bool needSaveSelectionLength = this.rtbText.SelectionLength > 0;

            //Первая выделенная строка
            int startLineNumber = this.rtbText.SelectedFirstLineNumber;
            //Последняя выделенная строка
            int endLineNumber = this.rtbText.SelectedLastLineNumber;

            string[] textLines = this.rtbText.Lines;

            for ( int lineIndex = startLineNumber ; lineIndex <= endLineNumber ; lineIndex++ )
                {
                string lineStr = textLines[ lineIndex ];
                string currTrimString = lineStr.TrimStart( ' ', '\t' );

                //Новая строка
                StringBuilder newStr = new StringBuilder();

                //Добавляем старый отступ
                newStr = GetStringIndent( lineStr );
                //Добавляем комментарий
                newStr.Append( "//" );
                newStr.Append( currTrimString );

                this.rtbText.ReplaceText( this.rtbText.GetFirstCharIndexFromLine( lineIndex ),
                    textLines[ lineIndex ].Length, newStr.ToString() );
                }

            //Если длина старого выделения была нулевой
            if ( !needSaveSelectionLength )
                {
                //Восстанавливаем старое выделение
                this.rtbText.SelectionStart = oldSelectionStart + 2;
                }
            else
                {
                //Выделяем все закомментаренные строки
                this.rtbText.SelectionStart = this.rtbText.GetFirstCharIndexFromLine( startLineNumber );
                int selectionEndChNumber = this.rtbText.GetFirstCharIndexFromLine( endLineNumber ) +
                    this.rtbText.Lines[ endLineNumber ].Length;
                this.rtbText.SelectionLength = selectionEndChNumber - this.rtbText.SelectionStart;
                }

            this.rtbText.EndUpdate();
            Syntax.Instance.Enabled = true;
            Syntax.Instance.Select( this.rtbText );
            this.rtbText.Invalidate();
            }


        /// <summary>
        /// Убрать комментарий у выделенных строк в окне редактирования
        /// </summary>
        private void Uncomment()
            {
            this.rtbText.BeginUpdate();
            Syntax.Instance.Enabled = false;

            //Сохраняем текущее выделение
            int oldSelectionStart = this.rtbText.SelectionStart;
            //Необходимость восстанавливать длину выделения
            bool needSaveSelectionLength = this.rtbText.SelectionLength > 0;

            //Первая выделенная строка
            int startLineNumber = this.rtbText.SelectedFirstLineNumber;
            //Последняя выделенная строка
            int endLineNumber = this.rtbText.SelectedLastLineNumber;

            //Признак того, что в первую выделенную строку был добавлен комментарий
            bool firstStringWasCommented = false;
            string[] textLines = this.rtbText.Lines;

            for ( int lineIndex = startLineNumber ; lineIndex <= endLineNumber ; lineIndex++ )
                {
                string lineStr = textLines[ lineIndex ];
                string currTrimString = lineStr.TrimStart( ' ', '\t' );

                //Если у строки есть комментарий
                if ( currTrimString.StartsWith( "//" ) )
                    {
                    //Новая строка
                    StringBuilder newStr = new StringBuilder();

                    //Добавляем старый отступ
                    newStr = GetStringIndent( lineStr );
                    newStr.Append( currTrimString.Substring( 2 ) );

                    this.rtbText.ReplaceText( this.rtbText.GetFirstCharIndexFromLine( lineIndex ),
                        textLines[ lineIndex ].Length, newStr.ToString() );

                    //Если комментарий был добавлен в первую строку
                    if ( lineIndex == startLineNumber )
                        firstStringWasCommented = true;
                    }
                }

            //Если длина старого выделения была нулевой
            if ( !needSaveSelectionLength )
                {
                //Восстанавливаем старое выделение
                this.rtbText.SelectionStart = oldSelectionStart;
                if ( firstStringWasCommented )
                    if ( this.rtbText.SelectionStart > 1 )
                        this.rtbText.SelectionStart -= 2;
                }
            else
                {
                //Выделяем все закомментаренные строки
                this.rtbText.SelectionStart = this.rtbText.GetFirstCharIndexFromLine( startLineNumber );
                int selectionEndChNumber = this.rtbText.GetFirstCharIndexFromLine( endLineNumber ) +
                    this.rtbText.Lines[ endLineNumber ].Length;
                this.rtbText.SelectionLength = selectionEndChNumber - this.rtbText.SelectionStart;
                }

            this.rtbText.EndUpdate();
            Syntax.Instance.Enabled = true;
            Syntax.Instance.Select( this.rtbText );
            this.rtbText.Invalidate();
            }


        /// <summary>
        /// Увеличить отступ выделенных строк в окне редактирования
        /// </summary>
        private void IncreaseIndent()
            {
            this.rtbText.BeginUpdate();
            Syntax.Instance.Enabled = false;

            //Сохраняем текущее выделение
            int oldSelectionStart = this.rtbText.SelectionStart;
            //Необходимость восстанавливать длину выделения
            bool needSaveSelectionLength = this.rtbText.SelectionLength > 0;

            //Первая выделенная строка
            int startLineNumber = this.rtbText.SelectedFirstLineNumber;
            //Последняя выделенная строка
            int endLineNumber = this.rtbText.SelectedLastLineNumber;

            string[] textLines = this.rtbText.Lines;

            for ( int lineIndex = startLineNumber ; lineIndex <= endLineNumber ; lineIndex++ )
                {
                this.rtbText.ReplaceText( this.rtbText.GetFirstCharIndexFromLine( lineIndex ),
                    textLines[ lineIndex ].Length, "\t" + textLines[ lineIndex ] );
                }

            //Если длина старого выделения была нулевой
            if ( !needSaveSelectionLength )
                {
                //Восстанавливаем старое выделение
                this.rtbText.SelectionStart = oldSelectionStart + "\t".Length;
                }
            else
                {
                //Выделяем все строки
                this.rtbText.SelectionStart = this.rtbText.GetFirstCharIndexFromLine( startLineNumber );
                int selectionEndChNumber = this.rtbText.GetFirstCharIndexFromLine( endLineNumber ) +
                    this.rtbText.Lines[ endLineNumber ].Length;
                this.rtbText.SelectionLength = selectionEndChNumber - this.rtbText.SelectionStart;
                }

            this.rtbText.EndUpdate();
            Syntax.Instance.Enabled = true;
            Syntax.Instance.Select( this.rtbText );
            //this.rtbText.Invalidate();
            }


        /// <summary>
        /// Уменьшить отступ у выделенных строк в окне редактирования
        /// </summary>
        private void DecreaseIndent()
            {
            this.rtbText.BeginUpdate();
            Syntax.Instance.Enabled = false;

            //Сохраняем текущее выделение
            int oldSelectionStart = this.rtbText.SelectionStart;
            //Необходимость восстанавливать длину выделения
            bool needSaveSelectionLength = this.rtbText.SelectionLength > 0;

            //Первая выделенная строка
            int startLineNumber = this.rtbText.SelectedFirstLineNumber;
            //Последняя выделенная строка
            int endLineNumber = this.rtbText.SelectedLastLineNumber;

            //Признак того, что в первую выделенную строку был добавлен \t
            bool firstStringWasIndented = false;
            string[] textLines = this.rtbText.Lines;

            for ( int lineIndex = startLineNumber ; lineIndex <= endLineNumber ; lineIndex++ )
                {
                string currLine = textLines[ lineIndex ];
                //Если у строки есть комментарий
                if ( currLine.StartsWith( "\t" ) )
                    {
                    this.rtbText.ReplaceText( this.rtbText.GetFirstCharIndexFromLine( lineIndex ),
                        textLines[ lineIndex ].Length, currLine.Substring( 1 ) );

                    //Если комментарий был добавлен в первую строку
                    if ( lineIndex == startLineNumber )
                        firstStringWasIndented = true;
                    }
                }

            //Если длина старого выделения была нулевой
            if ( !needSaveSelectionLength )
                {
                //Восстанавливаем старое выделение
                this.rtbText.SelectionStart = oldSelectionStart;
                if ( firstStringWasIndented )
                    this.rtbText.SelectionStart -= "\t".Length;
                }
            else
                {
                //Выделяем все строки
                this.rtbText.SelectionStart = this.rtbText.GetFirstCharIndexFromLine( startLineNumber );
                int selectionEndChNumber = this.rtbText.GetFirstCharIndexFromLine( endLineNumber ) +
                    this.rtbText.Lines[ endLineNumber ].Length;
                this.rtbText.SelectionLength = selectionEndChNumber - this.rtbText.SelectionStart;
                }

            this.rtbText.EndUpdate();
            Syntax.Instance.Enabled = true;
            Syntax.Instance.Select( this.rtbText );
            this.rtbText.Invalidate();
            }


        /// <summary>
        /// Перевести выделенный текст в верхний регистр
        /// </summary>
        private void SetSelectedTextToUpper()
            {
            this.rtbText.BeginUpdate();
            Syntax.Instance.Enabled = false;

            //Сохраняем текущее выделение
            this.rtbText.SaveCurrentSelection();

            this.rtbText.ReplaceText( this.rtbText.SelectionStart, this.rtbText.SelectionLength,
                        this.rtbText.SelectedText.ToUpper() );

            //Восстанавливаем старое выделение
            this.rtbText.RestoreSelection();
            this.rtbText.EndUpdate();
            Syntax.Instance.Enabled = true;
            Syntax.Instance.Select( this.rtbText );
            this.rtbText.Invalidate();
            }


        /// <summary>
        /// Перевести выделенный текст в нижний регистр
        /// </summary>
        private void SetSelectedTextToLower()
            {
            this.rtbText.BeginUpdate();
            Syntax.Instance.Enabled = false;

            //Сохраняем текущее выделение
            this.rtbText.SaveCurrentSelection();

            this.rtbText.ReplaceText( this.rtbText.SelectionStart, this.rtbText.SelectionLength,
                        this.rtbText.SelectedText.ToLower() );

            //Восстанавливаем старое выделение
            this.rtbText.RestoreSelection();

            this.rtbText.EndUpdate();
            Syntax.Instance.Enabled = true;
            Syntax.Instance.Select( this.rtbText );
            this.rtbText.Invalidate();
            }


        //Прокрутка окна с текстом программы
        private void rtbText_VScroll( object sender, EventArgs e )
            {
            //Чуть-чуть подравниваем label
            int deltaH = this.rtbText.GetPositionFromCharIndex( 0 ).Y % ( this.rtbText.Font.Height + 1 );
            this.numberLabel.Top = deltaH;

            SynchronizeLineNumbers();
            }


        //Изменение размера окна редактирования
        private void rtbText_Resize( object sender, EventArgs e )
            {
            rtbText_VScroll( this, EventArgs.Empty );
            }


        //Обработка изменения текста
        private void rtbText_TextChanged( object sender, EventArgs e )
            {
            if ( Options.Instance.ShowLineNumbers )
                SynchronizeLineNumbers();

            //Подсветка синтаксиса
            Syntax.Instance.Select( this.rtbText );
            }


        /// <summary>
        /// Синхронизовать номера строк
        /// </summary>
        public void SynchronizeLineNumbers()
            {
            int firstVisibleLineNumber = this.rtbText.FirstVisibleLineNumber;
            int lastVisibleLineNumber = this.rtbText.LastVisibleLineNumber;

            StringBuilder lineText = new StringBuilder();
            for ( int lineIndex = firstVisibleLineNumber ; lineIndex <= lastVisibleLineNumber ; lineIndex++ )
                {
                lineText.Append( lineIndex.ToString() );
                lineText.Append( Environment.NewLine );
                }
            this.numberLabel.Text = lineText.ToString();
            }


        //Обработка изменения позиции курсора
        private void rtbText_SelectionChanged( object sender, EventArgs e )
            {
            //Если позицию курсора показывать не надо
            if ( !Options.Instance.ShowCursorPosition )
                return;

            this.tssCursorLine.Text = String.Format( "Ln {0} - Ch {1} - Chn {2}",
                this.rtbText.SelectedFirstLineNumber, this.rtbText.SelectedChInCurrLine,
                this.rtbText.SelectionStart );
            }


        //Изменение выделенного элемента в списке ошибок
        private void lvErrors_SelectedIndexChanged( object sender, EventArgs e )
            {
            foreach ( int selIndex in this.lvErrors.SelectedIndices )
                {
                ErrorDescription error = this.lvErrors.Items[ selIndex ].Tag as ErrorDescription;
                if ( error != null )
                    {
                    this.rtbText.BeginUpdate();
                    //Убираем подчеркивание ошибок
                    //this.rtbText.SetCharYOffset( CharFormatArea.AllText, 0 );
                    //this.rtbText.SetCharEffect( RichTextBoxEx.CharEffect.Underline, CharFormatArea.AllText, false );
                    this.rtbText.SetCharBackColor( CharFormatArea.AllText, this.rtbText.BackColor );

                    //Общее число строк
                    int totalLineNumber = this.rtbText.Lines.Length;

                    //Если текста нет
                    if ( totalLineNumber == 0 )
                        return;

                    //Номер строки с ошибкой
                    int errorLineNumber = 0;

                    //Если номер строки превышает максимально допустимый
                    if ( error.lineNumber >= totalLineNumber )
                        {
                        errorLineNumber = totalLineNumber - 1;
                        }
                    else
                        {
                        errorLineNumber = error.lineNumber;
                        }

                    //Строка с ошибкой
                    string errorLine = this.rtbText.Lines[ errorLineNumber ];

                    //Если текущая строка пуста
                    if ( errorLine.Trim() == string.Empty )
                        {
                        this.rtbText.SelectionLength = 0;
                        return;
                        }

                    //Если индекс символа с ошибкой выходит за пределы строки
                    if ( error.chNumber > errorLine.Length )
                        {
                        this.rtbText.SelectionLength = 0;
                        return;
                        }

                    //Номер символа с ошибкой
                    int errorChPos = this.rtbText.GetFirstCharIndexFromLine( errorLineNumber ) + error.chNumber;

                    //Номер первого символа текущей строки
                    int currStrFirstChNumber = this.rtbText.GetFirstCharIndexFromLine( errorLineNumber );

                    //Номер первой буквы слова в текущей строке
                    int wordFirstChIndex = errorLine.Length - 1;
                    //Если такой символ есть в строке
                    if ( errorChPos - currStrFirstChNumber < errorLine.Length )
                        {
                        wordFirstChIndex = errorChPos - currStrFirstChNumber;
                        }

                    int selectionStart = this.rtbText.FindWordBreak( FindWordBreakMode.MoveWordLeft, errorChPos );
                    this.rtbText.Select( selectionStart, errorChPos - selectionStart );
                    
                    //this.rtbText.SetCharYOffset( CharFormatArea.Selection, 50 );    
                    this.rtbText.SetCharBackColor( CharFormatArea.Selection, Color.Red );
                    //this.rtbText.SelectionUnderlineType = UnderlineType.Dotted;
                    this.rtbText.SelectionLength = 0;
                    }
                else
                    throw new ArgumentException( "Неверный тип элемента списка" );
                this.rtbText.EndUpdate();
                this.rtbText.Invalidate();
                }
            }


        }
    }
