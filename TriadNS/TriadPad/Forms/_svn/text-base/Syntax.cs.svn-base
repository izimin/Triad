using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

using tom;

namespace TriadPad.Forms
    {
    /// <summary>
    /// Тип ключевого слова
    /// </summary>
    enum KeyWordType
        {
        /// <summary>
        /// Тип
        /// </summary>
        Type,
        /// <summary>
        /// Оператор
        /// </summary>
        Operator,
        /// <summary>
        /// Граница
        /// </summary>
        Bound
        }

    /// <summary>
    /// Выделение ключевых слов в тексте цветом
    /// </summary>
    public class Syntax
        {
        /// <summary>
        /// Список зарегистрированных ключевых слов
        /// </summary>
        private Dictionary<string, KeyWordType> keyWordList = new Dictionary<string, KeyWordType>();
        /// <summary>
        /// Список хеш-кодов строк в уже отформатированном тексте
        /// </summary>
        private List<int> oldLineHashCodeList = new List<int>();
        /// <summary>
        /// Работоспособность
        /// </summary>
        private bool enabled = true;


        /// <summary>
        /// Экземпляр класса
        /// </summary>
        private static Syntax instance = null;


        /// <summary>
        /// Экземпляр класса
        /// </summary>
        public static Syntax Instance
            {
            get
                {
                if ( instance == null )
                    instance = new Syntax();
                return instance;
                }
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        public Syntax()
            {
            FillKeyWordList();
            }


        /// <summary>
        /// Работоспособность
        /// </summary>
        public bool Enabled
            {
            get { return enabled; }
            set { enabled = value; }
            }


        /// <summary>
        /// Заполнить список ключевых слов
        /// </summary>
        private void FillKeyWordList()
            {
            this.keyWordList.Add( "arc", KeyWordType.Operator );
            this.keyWordList.Add( "array", KeyWordType.Type );
            this.keyWordList.Add( "available", KeyWordType.Operator );
            this.keyWordList.Add( "be", KeyWordType.Operator );
            this.keyWordList.Add( "bit", KeyWordType.Type );
            this.keyWordList.Add( "boolean", KeyWordType.Type );
            this.keyWordList.Add( "break", KeyWordType.Operator );
            this.keyWordList.Add( "by", KeyWordType.Operator );
            this.keyWordList.Add( "cancel", KeyWordType.Operator );
            this.keyWordList.Add( "case", KeyWordType.Operator );
            this.keyWordList.Add( "cycle", KeyWordType.Operator );
            this.keyWordList.Add( "char", KeyWordType.Type );
            this.keyWordList.Add( "dcycle", KeyWordType.Operator );
            this.keyWordList.Add( "def", KeyWordType.Bound );
            this.keyWordList.Add( "design", KeyWordType.Bound );
            this.keyWordList.Add( "do", KeyWordType.Operator );
            this.keyWordList.Add( "downto", KeyWordType.Operator );
            this.keyWordList.Add( "dpath", KeyWordType.Operator );
            this.keyWordList.Add( "dstar", KeyWordType.Operator );
            this.keyWordList.Add( "edge", KeyWordType.Operator );
            this.keyWordList.Add( "else", KeyWordType.Operator );
            this.keyWordList.Add( "endi", KeyWordType.Bound );
            this.keyWordList.Add( "endcond", KeyWordType.Bound );
            this.keyWordList.Add( "endmod", KeyWordType.Bound );
            this.keyWordList.Add( "endrout", KeyWordType.Bound );
            this.keyWordList.Add( "ende", KeyWordType.Bound );
            this.keyWordList.Add( "endc", KeyWordType.Operator );
            this.keyWordList.Add( "enddes", KeyWordType.Bound );
            this.keyWordList.Add( "endf", KeyWordType.Operator );
            this.keyWordList.Add( "endh", KeyWordType.Bound );
            this.keyWordList.Add( "endif", KeyWordType.Operator );
            this.keyWordList.Add( "endinf", KeyWordType.Bound );
            this.keyWordList.Add( "endp", KeyWordType.Bound );
            this.keyWordList.Add( "endstr", KeyWordType.Bound );
            this.keyWordList.Add( "endw", KeyWordType.Operator );
            this.keyWordList.Add( "eor", KeyWordType.Operator );
            this.keyWordList.Add( "event", KeyWordType.Bound );
            this.keyWordList.Add( "for", KeyWordType.Operator );
            this.keyWordList.Add( "foreach", KeyWordType.Operator );
            this.keyWordList.Add( "from", KeyWordType.Bound );
            this.keyWordList.Add( "handling", KeyWordType.Bound );
            this.keyWordList.Add( "simcondition", KeyWordType.Bound );
            this.keyWordList.Add( "if", KeyWordType.Operator );
            this.keyWordList.Add( "in", KeyWordType.Operator );
            this.keyWordList.Add( "include", KeyWordType.Bound );
            this.keyWordList.Add( "initial", KeyWordType.Bound );
            this.keyWordList.Add( "input", KeyWordType.Type );
            this.keyWordList.Add( "integer", KeyWordType.Type );
            this.keyWordList.Add( "interlock", KeyWordType.Operator );
            this.keyWordList.Add( "infprocedure", KeyWordType.Bound );
            this.keyWordList.Add( "inout", KeyWordType.Type );
            this.keyWordList.Add( "let", KeyWordType.Operator );
            this.keyWordList.Add( "model", KeyWordType.Bound );
            this.keyWordList.Add( "node", KeyWordType.Operator );
            this.keyWordList.Add( "notype", KeyWordType.Type );
            this.keyWordList.Add( "of", KeyWordType.Type );
            this.keyWordList.Add( "on", KeyWordType.Operator );
            this.keyWordList.Add( "out", KeyWordType.Operator );
            this.keyWordList.Add( "output", KeyWordType.Type );
            this.keyWordList.Add( "passive", KeyWordType.Type );
            this.keyWordList.Add( "path", KeyWordType.Operator );
            this.keyWordList.Add( "polus", KeyWordType.Bound );
            this.keyWordList.Add( "print", KeyWordType.Operator );
            this.keyWordList.Add( "processing", KeyWordType.Bound );
            this.keyWordList.Add( "put", KeyWordType.Operator );
            this.keyWordList.Add( "real", KeyWordType.Type );
            this.keyWordList.Add( "routine", KeyWordType.Bound );
            this.keyWordList.Add( "schedule", KeyWordType.Operator );
            this.keyWordList.Add( "set", KeyWordType.Type );
            this.keyWordList.Add( "simulate", KeyWordType.Operator );
            this.keyWordList.Add( "star", KeyWordType.Operator );
            this.keyWordList.Add( "string", KeyWordType.Type );
            this.keyWordList.Add( "structure", KeyWordType.Bound );
            this.keyWordList.Add( "then", KeyWordType.Operator );
            this.keyWordList.Add( "through", KeyWordType.Operator );
            this.keyWordList.Add( "to", KeyWordType.Operator );
            this.keyWordList.Add( "while", KeyWordType.Operator );
            this.keyWordList.Add("graph", KeyWordType.Type);
            }


        /// <summary>
        /// Получить слово из текста
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="currPosition">Начальная позиция поиска</param>
        /// <returns>Составленное слово</returns>
        private string GetNextWord( string text, ref int currPosition )
            {
            int textLength = text.Length;
            if ( currPosition < 0 || currPosition >= textLength )
                return string.Empty;

            StringBuilder resultWord = new StringBuilder();
            
            //Ищем первую букву слова
            while ( currPosition < textLength && !Char.IsLetter( text[ currPosition ] ) )
                currPosition++;

            //Составляем слово
            while ( currPosition < textLength && Char.IsLetterOrDigit( text[ currPosition ] ) )
                {
                resultWord.Append( text[ currPosition ] );
                currPosition++;
                }

            return resultWord.ToString();
            }


        /// <summary>
        /// Форматировать строку в окне редактирования
        /// </summary>
        /// <param name="textCurrPosition">Номер текущего символа</param>
        /// <param name="lineNumber">Номер строки</param>
        /// <param name="textLines">Строки в окне редактирования</param>
        /// <param name="textRange">Диапазон редактирования</param>
        private void FormatLine( int textCurrPosition, int lineNumber, string[] textLines, ITextRange textRange )
            {
            int lineLength = textLines[ lineNumber ].Length;
            if ( lineLength == 0 )
                return;

            //Делаем всю строку черной
            textRange.SetRange( textCurrPosition, textCurrPosition + lineLength );
            textRange.Font.ForeColor = ColorTranslator.ToOle( Color.Black );

            string currWord = string.Empty;

            int lineCurrPosition = 0;
            string text = textLines[ lineNumber ];
            do
                {
                currWord = GetNextWord( text, ref lineCurrPosition );
                
                //Т.к. регистр не важен
                currWord = currWord.ToLower();

                //Если это ключевое слово
                if ( this.keyWordList.ContainsKey( currWord ) )
                    {
                    //Выделяем слово
                    textRange.SetRange( textCurrPosition + lineCurrPosition - currWord.Length,
                        textCurrPosition + lineCurrPosition );

                    //Выбираем цвет выделения
                    switch ( this.keyWordList[ currWord ] )
                        {
                        case KeyWordType.Bound:
                            textRange.Font.ForeColor = ColorTranslator.ToOle( Options.Instance.SyntaxBoundColor );
                            break;
                        case KeyWordType.Operator:
                            textRange.Font.ForeColor = ColorTranslator.ToOle( Options.Instance.SyntaxOperatorColor );
                            break;
                        case KeyWordType.Type:
                            textRange.Font.ForeColor = ColorTranslator.ToOle( Options.Instance.SyntaxTypeColor );
                            break;
                        }
                    }
                }
            while ( currWord != string.Empty );
            }


        /// <summary>
        /// Форматировать комментарии
        /// </summary>
        /// <param name="currLine">Текущая строка</param>
        /// <param name="textRange">Объект - диапазон</param>
        /// <param name="firstLineChNumber">Индекс первого символа строки</param>
        private void FormatComment( string currLine, ITextRange textRange, int firstLineChNumber )
            {
            if ( currLine.Contains( "//" ) )
                {
                int commentStartChNumber = currLine.IndexOf( "//" );
                //Закрашиваем комментарий
                textRange.SetRange( firstLineChNumber + commentStartChNumber, firstLineChNumber + currLine.Length );
                textRange.Font.ForeColor = ColorTranslator.ToOle( Options.Instance.SyntaxCommentColor );
                }
            }



        /// <summary>
        /// Подсветить синтаксис в окне редактирования
        /// </summary>
        /// <param name="rtb">Окно редактирования</param>
        public void Select( RichTextBoxEx rtb )
            {
            if ( !this.enabled )
                return;

            //rtb.GenerateTextChangeEvent = false;            

            //rtb.BeginUpdate();

            //Сохраняем старое выделение
            rtb.SaveCurrentSelection();

            string[] textLines = rtb.Lines;
            int lineNumber = textLines.Length;

            ITextDocument textDocument = rtb.CreateTomInterface();
            ITextRange textRange = textDocument.Range( 0, 0 );

            //Индекс первого символа текущей строки
            int firstLineChNumber = 0;

            //Идем по всем новым строкам
            for ( int lineIndex = 0 ; lineIndex < lineNumber ; lineIndex++ )
                {
                string currLineText = textLines[ lineIndex ];

                if ( lineIndex == this.oldLineHashCodeList.Count )
                    this.oldLineHashCodeList.Add( ( string.Empty ).GetHashCode() );

                int lineTextHashCode = currLineText.GetHashCode();

                //Если хеши старой и новой строки не совпадают
                if ( this.oldLineHashCodeList[ lineIndex ] != lineTextHashCode )
                    {
                    //Потерянная строка найдена
                    bool foundStr = false;

                    //Если это не последняя новая строка
                    if ( lineIndex < lineNumber - 1 )
                        {
                        //Если хеш старой строки совпадает с хешем следующей новой строки (то, наверное, в этом месте вставили новую строку)
                        if ( this.oldLineHashCodeList[ lineIndex ] == textLines[ lineIndex + 1 ].GetHashCode() )
                            {
                            //Скорее всего вставленная строка будет пустой
                            this.oldLineHashCodeList.Insert( lineIndex, ( string.Empty ).GetHashCode() );
                            foundStr = true;
                            }
                        }
                    //Если строка не нашлась и это не последняя старая строка
                    if ( !foundStr && lineIndex < this.oldLineHashCodeList.Count - 1 )
                        {
                        //Если хеш следующей старой строки совпадает с хешем текущей строки (то, наверное, в этом месте удалили строку )
                        if ( this.oldLineHashCodeList[ lineIndex + 1 ] == textLines[ lineIndex ].GetHashCode() )
                            {
                            //Удаляем хеш старой строки
                            this.oldLineHashCodeList.RemoveAt( lineIndex );
                            }
                        }
                    }

                //Если хеш новой и старой строки все-таки не совпадают
                if ( this.oldLineHashCodeList[ lineIndex ] != lineTextHashCode )
                    {
                    this.oldLineHashCodeList[ lineIndex ] = lineTextHashCode;
                    //Раскрашиваем строку
                    FormatLine( firstLineChNumber, lineIndex, textLines, textRange );
                    //Закрашиваем комментарии
                    FormatComment( textLines[ lineIndex ], textRange, firstLineChNumber );
                    }

                firstLineChNumber += currLineText.Length + 1;
                }

            //Убираем лишние хеши
            while ( this.oldLineHashCodeList.Count != lineNumber )
                this.oldLineHashCodeList.RemoveAt( this.oldLineHashCodeList.Count - 1 );

            Marshal.ReleaseComObject( textDocument );
            Marshal.ReleaseComObject( textRange );

            //Восстанавливаем старое выделение
            rtb.RestoreSelection();

            //rtb.EndUpdate();
            
            //rtb.Invalidate();
            //rtb.GenerateTextChangeEvent = true;
            }        


        /// <summary>
        /// Очистить историю выделения
        /// </summary>
        public void ClearHistory()
            {
            if ( this.enabled )
                this.oldLineHashCodeList.Clear();
            }


        }
    }
