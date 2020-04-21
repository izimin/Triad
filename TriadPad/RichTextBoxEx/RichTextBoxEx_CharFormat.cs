using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace TriadPad
    {
    /// <summary>
    /// Specifies the style of underline that should be applied to the text.
    /// </summary>
    public enum UnderlineType
        {
        /// <summary>
        /// No underlining.
        /// </summary>
        None = 0,
        /// <summary>
        /// Standard underlining across all words (display as single)
        /// </summary>
        Normal = 1,
        /// <summary>
        /// Standard underlining broken between words.
        /// </summary>
        Word = 2,
        /// <summary>
        /// Dotted underlining.
        /// </summary>
        Dotted = 4,
        /// <summary>
        /// Dashed underlining.
        /// </summary>
        Dash = 5,
        /// <summary>
        /// Dash-dot ("-.-.") underlining.
        /// </summary>
        DashDot = 6,
        /// <summary>
        /// Dash-dot-dot ("-..-..") underlining.
        /// </summary>
        DashDotDot = 7,
        /// <summary>
        /// Wave underlining (like spelling mistakes in MS Word).
        /// </summary>
        Wave = 8,
        /// <summary>
        /// Extra long dash underlining.
        /// </summary>
        LongDash = 13
        }


    /// <summary>
    /// Область действия форматирования символов
    /// </summary>
    public enum CharFormatArea
        {
        /// <summary>
        /// Ко всему тексту
        /// </summary>
        AllText = 0x0004,
        /// <summary>
        /// К выделенному фрагменту
        /// </summary>
        Selection = 0x0001,
        /// <summary>
        /// К шрифту по умолчанию
        /// </summary>
        DefaultFont = 0x0000
        }



    /// <summary>
    /// Все, что связано с форматированием символов в RichTextBoxEx
    /// </summary>
    public partial class RichTextBoxEx
        {
        /// <summary>
        /// Символьные эффекты
        /// </summary>
        [Flags]
        public enum CharEffect
            {
            /// <summary>
            /// Все заглавные
            /// </summary>
            AllCaps = CFE_ALLCAPS,
            /// <summary>
            /// Системный фон тескта
            /// </summary>
            AutoBackColor = CFE_AUTOBACKCOLOR,
            /// <summary>
            /// Системный цвет текста
            /// </summary>
            AutoColor = CFE_AUTOCOLOR,
            /// <summary>
            /// Жирный текст
            /// </summary>
            Bold = CFE_BOLD,
            /// <summary>
            /// Нивидимые символы
            /// </summary>
            Hidden = CFE_HIDDEN,
            /// <summary>
            /// Курсив
            /// </summary>
            Italic = CFE_ITALIC,
            /// <summary>
            /// Гиперссылка
            /// </summary>
            Link = CFE_LINK,
            /// <summary>
            /// Неизменяемость
            /// </summary>
            Protected = CFE_PROTECTED,
            /// <summary>
            /// Символы становятся "проверенными"=подчеркнутыми
            /// </summary>
            Revised = CFE_REVISED,
            /// <summary>
            /// Зачеркнутые буквы
            /// </summary>
            StrikeOut = CFE_STRIKEOUT,
            /// <summary>
            /// Нижний индекс
            /// </summary>
            Subscript = CFE_SUBSCRIPT,
            /// <summary>
            /// Верхний индекс
            /// </summary>
            Superscript = CFE_SUPERSCRIPT,
            /// <summary>
            /// Подчеркивание
            /// </summary>
            Underline = CFE_UNDERLINE,
            }


        /// <summary>
        /// Шаг шрифта
        /// </summary>
        public enum FontPitch
            {
            /// <summary>
            /// Обычный шаг
            /// </summary>
            DefaultPitch = 0,
            /// <summary>
            /// Фиксированный шаг
            /// </summary>
            FixedPitch = 1,
            /// <summary>
            /// Переменный шаг
            /// </summary>
            VariablePitch = 2
            }


        /// <summary>
        /// Семейство шрифтов
        /// </summary>
        public enum FontFamily
            {
            /// <summary>
            /// Декоративные
            /// </summary>
            Decorative = 5 << 4,
            /// <summary>
            /// По умолчанию
            /// </summary>
            Default = 0,
            /// <summary>
            /// Современные (моноширные)
            /// </summary>
            Modern = 3 << 4,
            /// <summary>
            /// Романские
            /// </summary>
            Roman = 1 << 4,
            /// <summary>
            /// Рукописные
            /// </summary>
            Script = 4 << 4,
            /// <summary>
            /// Шрифты с serif
            /// </summary>
            Swiss = 2 << 4
            }


        //Флаги для CHARFORMAT2.dwMask
        private const uint CFM_ANIMATION = 0x00040000;
        private const uint CFM_BACKCOLOR = 0x04000000;
        private const uint CFM_CHARSET = 0x08000000;
        private const uint CFM_FACE = 0x20000000;
        private const uint CFM_KERNING = 0x00100000;
        private const uint CFM_LCID = 0x02000000;
        private const uint CFM_OFFSET = 0x10000000;
        private const uint CFM_REVAUTHOR = 0x00008000;
        private const uint CFM_SIZE = 0x80000000;
        private const uint CFM_SPACING = 0x00200000;
        private const uint CFM_STYLE = 0x00080000;
        private const uint CFM_WEIGHT = 0x00400000;
        private const uint CFM_UNDERLINETYPE = 8388608;
        private const uint CFM_ALLCAPS = 0x0080;
        private const uint CFM_BOLD = 0x00000001;
        private const uint CFM_COLOR = 0x40000000;
        private const uint CFM_DISABLED = 0x2000;
        private const uint CFM_EMBOSS = 0x0800;
        private const uint CFM_HIDDEN = 0x0100;
        private const uint CFM_IMPRINT = 0x1000;
        private const uint CFM_ITALIC = 0x00000002;
        private const uint CFM_LINK = 0x00000020;
        private const uint CFM_OUTLINE = 0x0200;
        private const uint CFM_PROTECTED = 0x00000010;
        private const uint CFM_REVISED = 0x4000;
        private const uint CFM_SHADOW = 0x0400;
        private const uint CFM_SMALLCAPS = 0x0040;
        private const uint CFM_STRIKEOUT = 0x00000008;
        private const uint CFM_SUBSCRIPT = CFE_SUBSCRIPT | CFE_SUPERSCRIPT;
        private const uint CFM_SUPERSCRIPT = CFM_SUBSCRIPT;
        private const uint CFM_UNDERLINE = 0x00000004;
        //Эффекты
        private const int CFE_ALLCAPS = 0x0080;
        private const int CFE_AUTOBACKCOLOR = (int)CFM_BACKCOLOR;
        private const int CFE_AUTOCOLOR = 0x40000000;
        private const int CFE_BOLD = 0x0001;
        private const int CFE_DISABLED = (int)CFM_DISABLED;
        private const int CFE_EMBOSS = (int)CFM_EMBOSS;
        private const int CFE_HIDDEN = (int)CFM_HIDDEN;
        private const int CFE_IMPRINT = (int)CFM_IMPRINT;
        private const int CFE_ITALIC = 0x0002;
        private const int CFE_LINK = 0x0020;
        private const int CFE_OUTLINE = (int)CFM_OUTLINE;
        private const int CFE_PROTECTED = 0x0010;
        private const int CFE_REVISED = (int)CFM_REVISED;
        private const int CFE_SHADOW = (int)CFM_SHADOW;
        private const int CFE_SMALLCAPS = (int)CFM_SMALLCAPS;
        private const int CFE_STRIKEOUT = 0x0008;
        private const int CFE_SUBSCRIPT = 0x00010000;
        private const int CFE_SUPERSCRIPT = 0x00020000;
        private const int CFE_UNDERLINE = 0x0004;

        /// <summary>
        /// Сообщение - Задать формат символов
        /// </summary>
        private const int EM_SETCHARFORMAT = 1092;
        private const int SCF_SELECTION = 1;

        /// <summary>
        /// The CHARFORMAT2 structure contains information about character formatting in a rich edit control.
        /// </summary>
        [StructLayout( LayoutKind.Sequential )]
        private struct CHARFORMAT2
            {
            /// <summary>
            /// Specifies the size, in bytes, of the structure. 
            /// </summary>
            public int cbSize;
            /// <summary>
            /// Specifies the parts of the CHARFORMAT2 structure that contain valid information. 
            /// </summary>
            public uint dwMask;
            /// <summary>
            /// A set of bit flags that specify character effects. 
            /// </summary>
            public uint dwEffects;
            /// <summary>
            /// Specifies the character height, in twips
            /// </summary>
            public int yHeight;
            /// <summary>
            /// Character offset from the baseline, in twips
            /// </summary>
            public int yOffset;
            /// <summary>
            /// Text color
            /// </summary>
            public int crTextColor;
            /// <summary>
            /// Character set value
            /// </summary>
            public byte bCharSet;
            /// <summary>
            /// Specifies the font family and pitch
            /// </summary>
            public byte bPitchAndFamily;
            /// <summary>
            /// A null-terminated character array specifying the font name
            /// </summary>
            [MarshalAs( UnmanagedType.ByValArray, SizeConst = 32 )]
            public char[] szFaceName;
            /// <summary>
            /// Font weight
            /// </summary>
            public short wWeight;
            /// <summary>
            /// Horizontal space between letters, in twips
            /// </summary>
            public short sSpacing;
            /// <summary>
            /// Background color
            /// </summary>
            public int crBackColor;
            /// <summary>
            /// A 32-bit locale identifier that contains a language identifier in the lower word 
            /// and a sorting identifier and reserved value in the upper word
            /// </summary>
            public int LCID;
            /// <summary>
            /// Reserved; the value must be zero.
            /// </summary>
            public uint dwReserved;
            /// <summary>
            /// Character style handle
            /// </summary>
            public short sStyle;
            /// <summary>
            /// Value of the font size, above which to kern the character 
            /// </summary>
            public short wKerning;
            /// <summary>
            /// Specifies the underline type
            /// </summary>
            public byte bUnderlineType;
            /// <summary>
            /// Text animation type
            /// </summary>
            public byte bAnimation;
            /// <summary>
            /// An index that identifies the author making a revision
            /// </summary>
            public byte bRevAuthor;
            }


        /// <summary>
        /// Стиль подчеркивания
        /// </summary>
        public UnderlineType SelectionUnderlineType
            {
            set
                {
                CHARFORMAT2 fmt = new CHARFORMAT2();
                fmt.cbSize = Marshal.SizeOf( fmt );
                fmt.dwMask = CFM_UNDERLINETYPE;
                fmt.bUnderlineType = (byte)value;

                IntPtr lFmt = Marshal.AllocCoTaskMem( Marshal.SizeOf( fmt ) ); ;
                Marshal.StructureToPtr( fmt, lFmt, false );

                // Set the underline type.
                SendMessage( new HandleRef( this, Handle ), EM_SETCHARFORMAT, new IntPtr( SCF_SELECTION ), lFmt );

                Marshal.FreeCoTaskMem( lFmt );
                }
            }


        /// <summary>
        /// Задать символьный эффект
        /// </summary>
        /// <param name="effect">Совокупный эффект</param>
        /// <param name="area">Область применения</param>
        /// <param name="on">Значение эффекта</param>
        public void SetCharEffect( CharEffect effect, CharFormatArea area, bool on )
            {
            CHARFORMAT2 fmt = new CHARFORMAT2();
            fmt.cbSize = Marshal.SizeOf( fmt );
            if ( on )
                fmt.dwEffects = (uint)effect;

            uint dwMask = 0;
            //Задаем маску
            if ( ( effect & CharEffect.AllCaps ) == CharEffect.AllCaps )
                dwMask |= CFM_ALLCAPS;
            if ( ( effect & CharEffect.AutoBackColor ) == CharEffect.AutoBackColor )
                dwMask |= CFM_BACKCOLOR;
            if ( ( effect & CharEffect.AutoColor ) == CharEffect.AutoColor )
                dwMask |= CFM_COLOR;
            if ( ( effect & CharEffect.Bold ) == CharEffect.Bold )
                dwMask |= CFM_BOLD;
            if ( ( effect & CharEffect.Hidden ) == CharEffect.Hidden )
                dwMask |= CFM_HIDDEN;
            if ( ( effect & CharEffect.Italic ) == CharEffect.Italic )
                dwMask |= CFM_ITALIC;
            if ( ( effect & CharEffect.Link ) == CharEffect.Link )
                dwMask |= CFM_LINK;
            if ( ( effect & CharEffect.Protected ) == CharEffect.Protected )
                dwMask |= CFM_PROTECTED;
            if ( ( effect & CharEffect.Revised ) == CharEffect.Revised )
                dwMask |= CFM_REVISED;
            if ( ( effect & CharEffect.StrikeOut ) == CharEffect.StrikeOut )
                dwMask |= CFM_STRIKEOUT;
            if ( ( effect & CharEffect.Subscript ) == CharEffect.Subscript )
                dwMask |= CFM_SUBSCRIPT;
            if ( ( effect & CharEffect.Superscript ) == CharEffect.Superscript )
                dwMask |= CFM_SUPERSCRIPT;
            if ( ( effect & CharEffect.Underline ) == CharEffect.Underline )
                dwMask |= CFM_UNDERLINE;

            fmt.dwMask = dwMask;

            IntPtr lFmt = Marshal.AllocCoTaskMem( Marshal.SizeOf( fmt ) ); ;
            Marshal.StructureToPtr( fmt, lFmt, false );

            SendMessage( new HandleRef( this, Handle ), EM_SETCHARFORMAT, new IntPtr( (int)area ), lFmt );

            Marshal.FreeCoTaskMem( lFmt );
            }


        /// <summary>
        /// Задать высоту символов
        /// </summary>
        /// <param name="area">Область применения</param>
        /// <param name="heightInTwips">Высота в twips</param>
        public void SetCharHeight( CharFormatArea area, int heightInTwips )
            {
            CHARFORMAT2 fmt = new CHARFORMAT2();
            fmt.cbSize = Marshal.SizeOf( fmt );
            fmt.dwMask = CFM_SIZE;
            fmt.yHeight = heightInTwips;

            IntPtr lFmt = Marshal.AllocCoTaskMem( Marshal.SizeOf( fmt ) ); ;
            Marshal.StructureToPtr( fmt, lFmt, false );

            SendMessage( new HandleRef( this, Handle ), EM_SETCHARFORMAT, new IntPtr( (int)area ), lFmt );

            Marshal.FreeCoTaskMem( lFmt );
            }


        /// <summary>
        /// Задать смещение символа по вертикали, относительно базовой линиии
        /// </summary>
        /// <param name="area">Область применения</param>
        /// <param name="yOffsetInTwips">Смещение</param>
        public void SetCharYOffset( CharFormatArea area, int yOffsetInTwips )
            {
            CHARFORMAT2 fmt = new CHARFORMAT2();
            fmt.cbSize = Marshal.SizeOf( fmt );
            fmt.dwMask = CFM_OFFSET;
            fmt.yOffset = yOffsetInTwips;

            IntPtr lFmt = Marshal.AllocCoTaskMem( Marshal.SizeOf( fmt ) ); ;
            Marshal.StructureToPtr( fmt, lFmt, false );

            SendMessage( new HandleRef( this, Handle ), EM_SETCHARFORMAT, new IntPtr( (int)area ), lFmt );

            Marshal.FreeCoTaskMem( lFmt );
            }


        /// <summary>
        /// Задать цвет символов
        /// </summary>
        /// <param name="area">Область применения</param>
        /// <param name="color">Цвет</param>
        public void SetCharColor( CharFormatArea area, Color color )
            {
            CHARFORMAT2 fmt = new CHARFORMAT2();
            fmt.cbSize = Marshal.SizeOf( fmt );
            fmt.dwMask = CFM_COLOR;
            fmt.crTextColor = ColorTranslator.ToWin32( color );

            IntPtr lFmt = Marshal.AllocCoTaskMem( Marshal.SizeOf( fmt ) ); ;
            Marshal.StructureToPtr( fmt, lFmt, false );

            SendMessage( new HandleRef( this, Handle ), EM_SETCHARFORMAT, new IntPtr( (int)area ), lFmt );

            Marshal.FreeCoTaskMem( lFmt );
            }


        /// <summary>
        /// Задать заливку
        /// </summary>
        /// <param name="area">Область применения</param>
        /// <param name="color">Цвет заливки</param>
        public void SetCharBackColor( CharFormatArea area, Color color )
            {
            CHARFORMAT2 fmt = new CHARFORMAT2();
            fmt.cbSize = Marshal.SizeOf( fmt );
            fmt.dwMask = CFM_BACKCOLOR;
            fmt.crBackColor = ColorTranslator.ToWin32( color );

            IntPtr lFmt = Marshal.AllocCoTaskMem( Marshal.SizeOf( fmt ) ); ;
            Marshal.StructureToPtr( fmt, lFmt, false );

            SendMessage( new HandleRef( this, Handle ), EM_SETCHARFORMAT, new IntPtr( (int)area ), lFmt );

            Marshal.FreeCoTaskMem( lFmt );
            }
        }
    }
