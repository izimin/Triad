using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security;

namespace TriadCompiler
    {
    /// <summary>
    /// Лексический анализатор
    /// </summary>
    internal class Scanner
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public Scanner()
            {
            Reload();
            }


        /// <summary>
        /// Очистить служебные данные
        /// </summary>
        public void Reload()
            {
            chStack.Clear();
            }


        /// <summary>
        /// Получить символ, не сдвигая позицию текущего символа
        /// </summary>
        /// <returns>Прочитанный символ</returns>
        public Symbol GetSymbolWithSavingPosition()
            {
            if ( this.storedSymbolStack.Count == 0 )
                this.storedSymbolStack.Push( GetSymbol() );
            return this.storedSymbolStack.Peek();
            }


        /// <summary>
        /// Сохранить символ
        /// </summary>
        /// <param name="symbol">Сохраняемый символ</param>
        public void SaveSymbol( Symbol symbol )
            {
            this.storedSymbolStack.Push( symbol );
            }


        /// <summary>
        /// Получить символ
        /// </summary>
        /// <returns>Прочитанный символ</returns>
        public Symbol GetSymbol()
            {
            //Символ конца файла (по-умолчанию)
            Symbol symbol = new Symbol();

            //Если есть сохраненные символы
            if ( this.storedSymbolStack.Count != 0 )
                {
                return this.storedSymbolStack.Pop();
                }

            //Запись в случае необходимости
            if ( needChRecording )
                {
                storedString.Append( currSymbolStr );
                }

            //Символьное представление текущего символа
            currSymbolStr = "";

            char ch = GetCh();

            //Пропускаем все символы табуляции и пробелы
            while ( ( ch == ' ' || ch == '\t' ) && ch != InputConst.EndOfFile )
                {
                ch = GetCh();
                }

            //Если это конец файла
            if ( ch == InputConst.EndOfFile )
                return symbol;

            //Если это не идентификатор
            if ( !( Char.IsLetter( ch ) || ch == '_' ) )
                {
                switch ( ch )
                    {
                    case '*':
                        symbol.Code = Key.Star;
                        break;

                    case '/':                        
                        ch = GetCh();
                        if ( ch == '/' )
                            {
                            Fabric.IO.SetNextString();
                            return this.GetSymbol();
                            }
                        else
                            {
                            SaveCh( ch );
                            symbol.Code = Key.Slash;
                            }
                        break;

                    case '=':
                        symbol.Code = Key.Equal;
                        break;

                    case ',':
                        symbol.Code = Key.Comma;
                        break;

                    case '.':
                        symbol.Code = Key.Point;
                        break;

                    case ';':
                        symbol.Code = Key.Semicolon;
                        break;

                    case '%':
                        symbol.Code = Key.ResidueOfDivision;
                        break;

                    // := | :
                    case ':':
                        ch = GetCh();
                        if ( ch == '=' )
                            {
                            symbol.Code = Key.Assign;
                            }
                        else
                            {
                            SaveCh( ch );
                            symbol.Code = Key.Colon;
                            }
                        break;

                    case '^':
                        symbol.Code = Key.Power;
                        break;

                    case ')':
                        symbol.Code = Key.RightPar;
                        break;

                    case '[':
                        symbol.Code = Key.LeftBracket;
                        break;

                    case ']':
                        symbol.Code = Key.RightBracket;
                        break;

                    case '+':
                        symbol.Code = Key.Plus;
                        break;

                    case '{':
                        symbol.Code = Key.LeftFigurePar;
                        break;

                    case '}':
                        symbol.Code = Key.RightFigurePar;
                        break;

                    case '-':
                        ch = GetCh();
                        //Обозначение соединения --
                        if ( ch == '-' )
                            {
                            symbol.Code = Key.Connection;
                            }
                        else
                            {
                            SaveCh( ch );
                            symbol.Code = Key.Minus;
                            }
                        break;

                    case '|':
                        symbol.Code = Key.Or;
                        break;

                    case '&':
                        symbol.Code = Key.And;
                        break;

                    //Символ
                    case '\'':
                        symbol = RecognizeChar();  
                        break;

                    //Строка
                    case '\"':
                        symbol = RecognizeString();
                        break;


                    // ! | != 
                    case '!':
                        ch = GetCh();
                        if ( ch == '=' )
                            {
                            symbol.Code = Key.NotEqual;
                            }
                        else
                            {
                            SaveCh( ch );
                            symbol.Code = Key.Not;
                            }
                        break;

                    // <  | <= 
                    case '<':
                        ch = GetCh();
                        //Меньше или равно <=
                        if ( ch == '=' )
                            {
                            symbol.Code = Key.LaterEqual;
                            }
                        else
                            {
                            SaveCh( ch );
                            symbol.Code = Key.Later;
                            }
                        break;

                    // > | >= 
                    case '>':
                        ch = GetCh();
                        if ( ch == '=' )
                            {
                            symbol.Code = Key.GreaterEqual;
                            }
                        else
                            {
                            SaveCh( ch );
                            symbol.Code = Key.Greater;
                            }
                        break;

                    // ( | Комментарий (*...*)
                    case '(':
                        symbol = RecognizeLeftParOrCommentary();
                        break;

                    // #010001...# Последовательность бит
                    case '#':

                        symbol = RecognizeBitString();
                        break;

                    default:

                        //Число
                        if ( Char.IsDigit( ch ) )
                            {
                            symbol = RecognizeValue( ch );
                            }
                        //Неизвестный символ
                        else
                            {
                            Fabric.Instance.ErrReg.Register( Err.Lexer.UnknownChar );
                            //Возвращаем следующий символ
                            symbol = GetSymbol();
                            }
                        break;
                    }
                }

            //Если это идентификатор
            else
                {
                symbol = RecognizeIdentificator( ch );
                }

            return symbol;
            }



        /// <summary>
        /// Распознать одиночный символ
        /// </summary>
        /// <returns>Распознанный символ</returns>
        private Symbol RecognizeChar()
            {
            char ch;
            Symbol symbol = new CharSymbol();

            ( symbol as CharSymbol ).Value = GetCh();
            ch = GetCh();

            //Проверка на завершающий символ '
            if ( ch != '\'' )
                {
                SaveCh( ch );
                Fabric.Instance.ErrReg.Register( Err.Lexer.WrongCharFormat );
                //Возвращаем следующий символ
                return GetSymbol();
                }
            return symbol;
            }



        /// <summary>
        /// Распознать строку символов
        /// </summary>
        /// <returns>Распознанный символ</returns>
        private Symbol RecognizeString()
            {
            char ch;
            Symbol symbol = new StringSymbol();

            ch = GetCh();
            while ( ch != '\"' && ch != InputConst.EndOfFile )
                {
                ( symbol as StringSymbol ).Value += ch;
                ch = GetCh();
                }

            //Если строка была не закрыта
            if ( ch == InputConst.EndOfFile )
                {
                Fabric.Instance.ErrReg.Register( Err.Lexer.NotClosedString );
                //Символ конца файла (по-умолчанию)
                symbol = new Symbol();
                }
            return symbol;
            }

        
        /// <summary>
        /// Распознать идентификатор
        /// </summary>
        /// <param name="ch">Текущий символ</param>
        /// <returns>Распознанный символ</returns>
        private Symbol RecognizeIdentificator( char ch )
            {
            Symbol symbol = new Symbol();

            string identificatorStringCode = "";
            identificatorStringCode += ch;
            ch = GetCh();

            //Копируем идентификатор в буфер
            while ( Char.IsLetterOrDigit( ch ) || ch == '_' )
                {
                identificatorStringCode += ch;
                ch = GetCh();
                }
            SaveCh( ch );

            //Ключевое слово
            if ( KeyIdentificatorContainer.Contains( identificatorStringCode ) )
                {
                symbol.Code = KeyIdentificatorContainer.GetKeyIdentificator( identificatorStringCode );
                }
            //Обычный идентификатор
            else
                {
                //Если это логическая константа true
                if ( identificatorStringCode.ToLower() == "true" )
                    {
                    symbol = new BooleanSymbol( true );
                    }
                //Если это логическая константа false
                else if ( identificatorStringCode.ToLower() == "false" )
                    {
                    symbol = new BooleanSymbol( false );
                    }
                else if ( identificatorStringCode.ToLower() == "nil" )
                    {
                    symbol = new NilSymbol();
                    }
                else
                    {
                    symbol = new IdentSymbol( identificatorStringCode );
                    }
                }

            return symbol;
            }


        /// <summary>
        /// Распознать комментарий или левую скобку
        /// </summary>
        /// <returns>Разобранный символ</returns>
        private Symbol RecognizeLeftParOrCommentary()
            {
            Symbol symbol = new Symbol();
            char ch = GetCh();

            //Комментарий
            if ( ch == '*' )
                {
                //Предыдущий символ
                char previousCh = ch;
                //Завершающий символ
                bool terminalChFound = false;
                //Конец файла
                bool endOfFileFound = false;

                ch = GetCh();
                
                do
                    {
                    previousCh = ch;
                    ch = GetCh();

                    terminalChFound = previousCh == '*' && ch == ')';
                    endOfFileFound = ch == InputConst.EndOfFile;
                    }
                while ( !terminalChFound && !endOfFileFound );

                if ( !endOfFileFound )
                    {
                    //Возвращаем следующий символ
                    symbol = GetSymbol();
                    }
                //Незакрытый комментарий
                else
                    {
                    Fabric.Instance.ErrReg.Register( Err.Lexer.NotClosedCommentary );
                    //Возвращается символ по-умолчанию (EndOfFile)								
                    }
                }
            // (
            else
                {
                SaveCh( ch );
                symbol.Code = Key.LeftPar;
                }

            return symbol;
            }


        /// <summary>
        /// Распознать строку бит
        /// </summary>
        /// <returns>Распознанный символ</returns>
        private Symbol RecognizeBitString()
            {
            Symbol symbol = new BitStringSymbol();

            //Конец файла
            bool endOfFileFound = false;
            //Недопустимый символ
            bool wrongChFound = false;
            //Численное значение
            Int64 bitStringValue = 0;
            //Число разрядов
            int bitCount = 0;

            char ch = GetCh();

            while ( ch != '#' && !endOfFileFound )
                {
                //Проверка на допустимый символ
                if ( ch != '0' && ch != '1' )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Lexer.WrongSymbolInBitSTring );
                    wrongChFound = true;
                    }

                bitStringValue <<= 1;                
                if ( ch == '1' )
                    bitStringValue |= 1;

                ch = GetCh();
                endOfFileFound = ch == InputConst.EndOfFile;

                bitCount += 1;
                }

            //Конец файла
            if ( endOfFileFound )
                {
                Fabric.Instance.ErrReg.Register( Err.Lexer.NotClosedBitString );
                //Возвращается символ по-умолчанию (EndOfFile)
                symbol = new Symbol();
                }
            //Недопустимый символ
            else if ( wrongChFound )
                {
                symbol = GetSymbol();
                }
            //Слишком длинная битовая строка
            else if ( bitCount > Err.Lexer.BitStringIsTooLong )
                {
                Fabric.Instance.ErrReg.Register( Err.Lexer.TooLongBitString );
                //Возращается следующий символ
                symbol = GetSymbol();
                }
            else
                ( symbol as BitStringSymbol ).Value = bitStringValue;

            return symbol;
            }


        /// <summary>
        /// Распознать число
        /// </summary>
        /// <returns>Распознанный символ</returns>
        private Symbol RecognizeValue( char ch )
            {
            Symbol symbol = new Symbol();

            //Символьное представление числа
            string valueStringCode = "";

            do
                {
                valueStringCode += ch;
                ch = GetCh();
                }
            while ( Char.IsDigit( ch ) );

            //Если число вещественное
            if ( ch == 'e' || ch == 'E' || ch == '.' )
                {
                symbol = new RealSymbol();
                if ( ch == '.' )
                    {
                    //Заменяем . на ,
                    valueStringCode += ',';
                    ch = GetCh();

                    if ( Char.IsDigit( ch ) )
                        do
                            {
                            valueStringCode += ch;
                            ch = GetCh();
                            }
                        while ( Char.IsDigit( ch ) );
                    //Неверный формат числа
                    else
                        {
                        SaveCh( ch );
                        Fabric.Instance.ErrReg.Register( Err.Lexer.WrongRealFormat );
                        //Возвращаем следующий символ
                        return GetSymbol();
                        }
                    }

                if ( ch == 'e' || ch == 'E' )
                    {
                    valueStringCode += ch;
                    ch = GetCh();

                    if ( ch == '+' || ch == '-' )
                        {
                        valueStringCode += ch;
                        ch = GetCh();
                        }
                    if ( Char.IsDigit( ch ) )
                        do
                            {
                            valueStringCode += ch;
                            ch = GetCh();
                            }
                        while ( Char.IsDigit( ch ) );
                    //Неверный формат числа
                    else
                        {
                        SaveCh( ch );
                        Fabric.Instance.ErrReg.Register( Err.Lexer.WrongRealFormat );
                        //Возвращаем следующий символ
                        return GetSymbol();
                        }
                    }
                SaveCh( ch );
                try
                    {
                    ( symbol as RealSymbol ).Value = double.Parse( valueStringCode );
                    }
                //Ошибка разбора строки (неверный формат числа)
                catch
                    {
                    Fabric.Instance.ErrReg.Register( Err.Lexer.WrongRealFormat );
                    //Возвращаем следующий символ
                    symbol = GetSymbol();
                    }
                }

            //Число целое
            else
                {
                SaveCh( ch );
                symbol = RecognizeIntegerValue( valueStringCode );
                }

            return symbol;
            }

        
        /// <summary>
        /// Распознать целое число
        /// </summary>
        /// <param name="valueStringCode">Строковое представление числа</param>
        /// <returns>Символ целого числа</returns>
        private Symbol RecognizeIntegerValue( string valueStringCode )
            {
            Symbol symbol = new IntegerSymbol();            
            try
                {
                //Если такое число уже было распознано
                if ( recognizedIntegerValues.ContainsKey( valueStringCode ) )
                    {
                    ( symbol as IntegerSymbol ).Value = recognizedIntegerValues[ valueStringCode ];
                    }
                else
                    {
                    ( symbol as IntegerSymbol ).Value = int.Parse( valueStringCode );
                    recognizedIntegerValues.Add( valueStringCode, ( symbol as IntegerSymbol ).Value );
                    }
                }
            //Ошибка разбора строки (неверный формат числа)
            catch
                {
                Fabric.Instance.ErrReg.Register( Err.Lexer.WrongIntegerFormat );
                //Возвращаем следующий символ
                symbol = GetSymbol();
                }

            return symbol;
            }


        /// <summary>
        /// Начать запись входных букв
        /// </summary>
        public void StartRecordingCh()
            {
            needChRecording = true;
            storedString = new StringBuilder();
            }


        /// <summary>
        /// Получить записанную последовательность входных букв
        /// </summary>
        /// <returns></returns>
        public string GetStoredString()
            {
            return storedString.ToString().Trim();
            }

        
        /// <summary>
        /// Получить букву
        /// </summary>
        /// <returns></returns>
        private char GetCh()
            {
            char ch;
            //Если неиспользованные буквы есть
            if ( chStack.Count != 0 )
                {
                ch = (char)chStack.Pop();
                }
            //Иначе
            else
                {
                ch = Fabric.IO.GetCh();
                }
            //Символьная запись текущего символа
            currSymbolStr = currSymbolStr + ch.ToString();
            return ch;
            }


        /// <summary>
        /// Сохранить букву неиспользованной
        /// </summary>
        /// <param name="ch">Буква</param>
        private void SaveCh( char ch ) 
            {
            chStack.Push( ch );
            //Символьная запись текущего символа
            currSymbolStr = currSymbolStr.Remove( currSymbolStr.Length - 1, 1 );
            }


        /// <summary>
        /// Стек неиспользованных букв (они будут переиспользованы при повторном вызове GetSymbol)
        /// </summary>
        private Stack<char> chStack = new Stack<char>();
        /// <summary>
        /// Сохраненные символы
        /// </summary>
        private Stack<Symbol> storedSymbolStack = new Stack<Symbol>();
        
        /// <summary>
        /// Необходимость в записи входных букв в строку
        /// </summary>
        private bool needChRecording = false;
        /// <summary>
        /// Текущая записанная последовательность входных букв
        /// </summary>
        private StringBuilder storedString = new StringBuilder();
        /// <summary>
        /// Символьное представление текущего символа
        /// </summary>
        private string currSymbolStr = "";
        /// <summary>
        /// Таблица уже распознанных целых чисел (нужна для оптимизации)
        /// </summary>
        private static Dictionary<string, int> recognizedIntegerValues = new Dictionary<string, int>();        
        }
    }
