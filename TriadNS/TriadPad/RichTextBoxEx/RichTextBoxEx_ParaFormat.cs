using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace TriadPad
    {
    /// <summary>
    /// Нумерация параграфа
    /// </summary>
    public enum ParaNumbering
        {
        /// <summary>
        /// Отсутствует
        /// </summary>
        None = 0,
        /// <summary>
        /// Маркер
        /// </summary>
        Bullet = 1,
        /// <summary>
        /// Арабские числа (1-254 почему-то)
        /// </summary>
        ArabicNumbers = 2,
        /// <summary>
        /// Прописные буквы (a,b,c,...)
        /// </summary>
        LowerCaseLetters = 3,
        /// <summary>
        /// Заглавные буквы (A,B,C,...)
        /// </summary>
        UpperCaseLetters = 4,
        /// <summary>
        /// Римские числа (i,ii,iii,...)
        /// </summary>
        LowerRomanNumerals = 5,
        /// <summary>
        /// Римские числа (I,II,III,...)
        /// </summary>
        UpperRomanNumerals = 6,
        }


    /// <summary>
    /// Выравнивание параграфа
    /// </summary>
    public enum ParaAllignment
        {
        /// <summary>
        /// По левому краю
        /// </summary>
        Left = 1,
        /// <summary>
        /// По правому краю
        /// </summary>
        Right = 2,
        /// <summary>
        /// По центру
        /// </summary>
        Center = 3,
        /// <summary>
        /// По ширине
        /// </summary>
        Justify = 4,
        }


    /// <summary>
    /// Правила для межстрочных интервалов в параграфе
    /// </summary>
    public enum ParaLineSpacingRule
        {
        /// <summary>
        /// Обычный интервал (LineSpacing игнорируется)
        /// </summary>
        SingleSpacing = 0,
        /// <summary>
        /// Полуторный интервал (LineSpacing игнорируется)
        /// </summary>
        OneAndAHalfSpacing = 1,
        /// <summary>
        /// Двойной интервал (LineSpacing игнорируется)
        /// </summary>
        DoubleSpacing = 2,
        }


    /// <summary>
    /// Стиль нумерации параграфов
    /// </summary>
    public enum ParaNumberingStyle
        {
        /// <summary>
        /// Правая закрывающаяся скобка
        /// </summary>
        RightParenthesis = 0,
        /// <summary>
        /// Две замкнутые скобки
        /// </summary>
        EncloseInParenthesis = 0x100,
        /// <summary>
        /// Номер, а после него точка
        /// </summary>
        FollowWithPeriod = 0x200,
        /// <summary>
        /// Только номер
        /// </summary>
        OnlyNumber = 0x300,
        /// <summary>
        /// Продолжить список без показа номера
        /// </summary>
        Empty = 0x400,
        }


    /// <summary>
    /// Форматирование параграфа
    /// </summary>
    [StructLayout( LayoutKind.Sequential, Pack = 4 )]
    public struct PARAFORMAT2
        {
        /// <summary>
        /// Structure size, in bytes. (UINT)
        /// </summary>
        public int cbSize;
        /// <summary>
        /// The members of the PARAFORMAT2 structure that contain valid information (DWORD)
        /// </summary>
        public uint dwMask;
        /// <summary>
        /// Options used for bulleted or numbered paragraphs. 
        /// </summary>            
        public short wNumbering;
        /// <summary>
        /// Зарезервировано
        /// </summary>
        public short wEffects;
        /// <summary>
        /// Indentation of the paragraph's first line, in twips.
        /// </summary>
        public int dxStartIndent;
        /// <summary>
        /// Indentation of the right side of the paragraph, relative to the right margin, in twips. 
        /// </summary>
        public int dxRightIndent;
        /// <summary>
        /// Indentation of the second and subsequent lines, relative to the indentation of the first line, in twips. 
        /// </summary>
        public int dxOffset;
        /// <summary>
        /// Paragraph alignment. 
        /// </summary>
        public short wAlignment;
        /// <summary>
        /// Number of tab stops defined in the rgxTabs array.
        /// </summary>
        public short cTabCount;
        /// <summary>
        /// Array of absolute tab stop positions.
        /// </summary>
        [MarshalAs( UnmanagedType.ByValArray, SizeConst = 32 )]
        public int[] rgxTabs;
        /// <summary>
        /// Size of the spacing above the paragraph, in twips.
        /// </summary>
        public int dySpaceBefore;
        /// <summary>
        /// Specifies the size of the spacing below the paragraph, in twips.
        /// </summary>
        public int dySpaceAfter;
        /// <summary>
        /// dyLineSpacing
        /// </summary>
        public int dyLineSpacing;
        /// <summary>
        /// Text style. 
        /// </summary>
        public short sStyle;
        /// <summary>
        /// Type of line spacing. 
        /// </summary>
        public byte bLineSpacingRule;
        /// <summary>
        /// Reserved;
        /// </summary>
        public byte bOutlineLevel;
        /// <summary>
        /// Percentage foreground color used in shading.
        /// </summary>
        public short wShadingWeight;
        /// <summary>
        /// Style and colors used for background shading. 
        /// </summary>
        public short wShadingStyle;
        /// <summary>
        /// Starting number or Unicode value used for numbered paragraphs
        /// </summary>
        public short wNumberingStart;
        /// <summary>
        /// Numbering style used with numbered paragraphs
        /// </summary>
        public short wNumberingStyle;
        /// <summary>
        /// Minimum space between a paragraph number and the paragraph text, in twips
        /// </summary>
        public short wNumberingTab;
        /// <summary>
        /// The space between the border and the paragraph text, in twips
        /// </summary>
        public short wBorderSpace;
        /// <summary>
        /// Border width, in twips
        /// </summary>
        public short wBorderWidth;
        /// <summary>
        /// Border location, style, and color
        /// </summary>
        public short wBorders;
        }


    /// <summary>
    /// Все, что связано с заданием форматирования параграфа
    /// </summary>
    public partial class RichTextBoxEx
        {
        //Маска
        private const uint PFM_ALIGNMENT = 0x00000008;
        private const uint PFM_BORDER = 0x00000800;
        private const uint PFM_LINESPACING = 0x00000100;
        private const uint PFM_NUMBERING = 0x00000020;
        private const uint PFM_NUMBERINGSTART = 0x00008000;
        private const uint PFM_NUMBERINGSTYLE = 0x00002000;
        private const uint PFM_NUMBERINGTAB = 0x00004000;
        private const uint PFM_OFFSET = 0x00000004;
        private const uint PFM_OFFSETINDENT = 0x80000000;
        private const uint PFM_RIGHTINDENT = 0x00000002;
        private const uint PFM_SHADING = 0x00001000;
        private const uint PFM_SPACEAFTER = 0x00000080;
        private const uint PFM_SPACEBEFORE = 0x00000040;
        private const uint PFM_STARTINDENT = 0x00000001;
        private const uint PFM_STYLE = 0x00000400;
        private const uint PFM_TABSTOPS = 0x00000010;
        private const uint PFM_DONOTHYPHEN = 0x00400000;
        private const uint PFM_KEEP = 0x00020000;
        private const uint PFM_KEEPNEXT = 0x00040000;
        private const uint PFM_NOLINENUMBER = 0x00100000;
        private const uint PFM_NOWIDOWCONTROL = 0x00200000;
        private const uint PFM_PAGEBREAKBEFORE = 0x00080000;
        private const uint PFM_RTLPARA = 0x00010000;
        private const uint PFM_SIDEBYSIDE = 0x00800000;
        private const uint PFM_TABLE = 0x40000000;

        /// <summary>
        /// Задать форматирование параграфа
        /// </summary>
        private const uint EM_SETPARAFORMAT = WM_USER + 71;
        private const int EM_SETTYPOGRAPHYOPTIONS = 1226;
        private const int TO_ADVANCEDTYPOGRAPHY = 1;


        /// <summary>
        /// This member overrides
        /// </summary>
        protected override void OnHandleCreated( EventArgs e )
            {
            base.OnHandleCreated( e );

            // Enable support for justification.
            SendMessage( new HandleRef( this, Handle ), EM_SETTYPOGRAPHYOPTIONS, new IntPtr( TO_ADVANCEDTYPOGRAPHY ),
                new IntPtr( TO_ADVANCEDTYPOGRAPHY ) );
            }


        /// <summary>
        /// Нумерация выделенных параграфов
        /// </summary>
        public ParaNumbering SelectionParaNumbering
            {
            set
                {
                PARAFORMAT2 fmt = new PARAFORMAT2();
                fmt.cbSize = Marshal.SizeOf( fmt );
                fmt.dwMask = PFM_NUMBERING;
                fmt.wNumbering = (short)value;

                IntPtr lFmt = Marshal.AllocCoTaskMem( Marshal.SizeOf( fmt ) ); ;
                Marshal.StructureToPtr( fmt, lFmt, false );

                SendMessage( new HandleRef( this, Handle ), EM_SETPARAFORMAT, IntPtr.Zero, lFmt );

                Marshal.FreeCoTaskMem( lFmt );
                }
            }



        /// <summary>
        /// Отступ красной строки в twips
        /// </summary>
        public int SelectionParaStartIndent
            {
            set
                {
                PARAFORMAT2 fmt = new PARAFORMAT2();
                fmt.cbSize = Marshal.SizeOf( fmt );
                fmt.dwMask = PFM_STARTINDENT;
                fmt.dxStartIndent = value;

                IntPtr lFmt = Marshal.AllocCoTaskMem( Marshal.SizeOf( fmt ) ); ;
                Marshal.StructureToPtr( fmt, lFmt, false );

                SendMessage( new HandleRef( this, Handle ), EM_SETPARAFORMAT, IntPtr.Zero, lFmt );

                Marshal.FreeCoTaskMem( lFmt );
                }
            }


        /// <summary>
        /// Отступ от правого края
        /// </summary>
        public int SelectionParaRightIndent
            {
            set
                {
                PARAFORMAT2 fmt = new PARAFORMAT2();
                fmt.cbSize = Marshal.SizeOf( fmt );
                fmt.dwMask = PFM_RIGHTINDENT;
                fmt.dxRightIndent = value;

                IntPtr lFmt = Marshal.AllocCoTaskMem( Marshal.SizeOf( fmt ) ); ;
                Marshal.StructureToPtr( fmt, lFmt, false );

                SendMessage( new HandleRef( this, Handle ), EM_SETPARAFORMAT, IntPtr.Zero, lFmt );

                Marshal.FreeCoTaskMem( lFmt );
                }
            }


        /// <summary>
        /// Отступ от левого края
        /// </summary>
        public ParaAllignment SelectionParaAllignment
            {
            set
                {
                PARAFORMAT2 fmt = new PARAFORMAT2();
                fmt.cbSize = Marshal.SizeOf( fmt );
                fmt.dwMask = PFM_ALIGNMENT;
                fmt.wAlignment = (short)value;

                IntPtr lFmt = Marshal.AllocCoTaskMem( Marshal.SizeOf( fmt ) ); ;
                Marshal.StructureToPtr( fmt, lFmt, false );

                SendMessage( new HandleRef( this, Handle ), EM_SETPARAFORMAT, IntPtr.Zero, lFmt );

                Marshal.FreeCoTaskMem( lFmt );
                }
            }


        /// <summary>
        /// Отступ перед абзацем
        /// </summary>
        public int SelectionParaSpaceBefore
            {
            set
                {
                PARAFORMAT2 fmt = new PARAFORMAT2();
                fmt.cbSize = Marshal.SizeOf( fmt );
                fmt.dwMask = PFM_SPACEBEFORE;
                fmt.dySpaceBefore = value;

                IntPtr lFmt = Marshal.AllocCoTaskMem( Marshal.SizeOf( fmt ) ); ;
                Marshal.StructureToPtr( fmt, lFmt, false );

                SendMessage( new HandleRef( this, Handle ), EM_SETPARAFORMAT, IntPtr.Zero, lFmt );

                Marshal.FreeCoTaskMem( lFmt );
                }
            }


        /// <summary>
        /// Отступ после абзаца
        /// </summary>
        public int SelectionParaSpaceAfter
            {
            set
                {
                PARAFORMAT2 fmt = new PARAFORMAT2();
                fmt.cbSize = Marshal.SizeOf( fmt );
                fmt.dwMask = PFM_SPACEAFTER;
                fmt.dySpaceAfter = value;

                IntPtr lFmt = Marshal.AllocCoTaskMem( Marshal.SizeOf( fmt ) ); ;
                Marshal.StructureToPtr( fmt, lFmt, false );

                SendMessage( new HandleRef( this, Handle ), EM_SETPARAFORMAT, IntPtr.Zero, lFmt );

                Marshal.FreeCoTaskMem( lFmt );
                }
            }



        /// <summary>
        /// Пользовательский междустрочный интервал, задаваемый в twips.
        /// Если размер меньше высоты одной линии, то он игнорируется
        /// </summary>
        public int SelectionParaLineSpacing
            {
            set
                {
                PARAFORMAT2 fmt = new PARAFORMAT2();
                fmt.cbSize = Marshal.SizeOf( fmt );
                fmt.dwMask = PFM_LINESPACING;
                fmt.dyLineSpacing = value;
                fmt.bLineSpacingRule = 4;

                IntPtr lFmt = Marshal.AllocCoTaskMem( Marshal.SizeOf( fmt ) ); ;
                Marshal.StructureToPtr( fmt, lFmt, false );

                SendMessage( new HandleRef( this, Handle ), EM_SETPARAFORMAT, IntPtr.Zero, lFmt );

                Marshal.FreeCoTaskMem( lFmt );
                }
            }


        /// <summary>
        /// Пользовательский междустрочный интервал, задаваемый в twips.
        /// Если размер меньше высоты одной линии, то он  НЕ игнорируется
        /// </summary>
        public int SelectionParaLineSpacingExact
            {
            set
                {
                PARAFORMAT2 fmt = new PARAFORMAT2();
                fmt.cbSize = Marshal.SizeOf( fmt );
                fmt.dwMask = PFM_LINESPACING;
                fmt.dyLineSpacing = value;
                fmt.bLineSpacingRule = 4;

                IntPtr lFmt = Marshal.AllocCoTaskMem( Marshal.SizeOf( fmt ) ); ;
                Marshal.StructureToPtr( fmt, lFmt, false );

                SendMessage( new HandleRef( this, Handle ), EM_SETPARAFORMAT, IntPtr.Zero, lFmt );

                Marshal.FreeCoTaskMem( lFmt );
                }
            }


        /// <summary>
        /// Пользовательский интервал, задаваемый через LineSpacing в долях от высоты строки (20 = высота одной строки, 40 - двух)
        /// </summary>
        public int SelectionParaLineSpacingByLine
            {
            set
                {
                PARAFORMAT2 fmt = new PARAFORMAT2();
                fmt.cbSize = Marshal.SizeOf( fmt );
                fmt.dwMask = PFM_LINESPACING;
                fmt.dyLineSpacing = value;
                fmt.bLineSpacingRule = 5;

                IntPtr lFmt = Marshal.AllocCoTaskMem( Marshal.SizeOf( fmt ) ); ;
                Marshal.StructureToPtr( fmt, lFmt, false );

                SendMessage( new HandleRef( this, Handle ), EM_SETPARAFORMAT, IntPtr.Zero, lFmt );

                Marshal.FreeCoTaskMem( lFmt );
                }
            }


        /// <summary>
        /// Правило задания межстрочного интервала
        /// </summary>
        public ParaLineSpacingRule SelectionParaSpacingRule
            {
            set
                {
                PARAFORMAT2 fmt = new PARAFORMAT2();
                fmt.cbSize = Marshal.SizeOf( fmt );
                fmt.dwMask = PFM_LINESPACING;
                fmt.bLineSpacingRule = (byte)value;

                IntPtr lFmt = Marshal.AllocCoTaskMem( Marshal.SizeOf( fmt ) ); ;
                Marshal.StructureToPtr( fmt, lFmt, false );

                SendMessage( new HandleRef( this, Handle ), EM_SETPARAFORMAT, IntPtr.Zero, lFmt );

                Marshal.FreeCoTaskMem( lFmt );
                }
            }



        /// <summary>
        /// Стиль нумерации
        /// </summary>
        public ParaNumberingStyle SelectionParaNumberingStyle
            {
            set
                {
                PARAFORMAT2 fmt = new PARAFORMAT2();
                fmt.cbSize = Marshal.SizeOf( fmt );
                fmt.dwMask = PFM_NUMBERINGSTYLE;
                fmt.wNumberingStyle = (short)value;

                IntPtr lFmt = Marshal.AllocCoTaskMem( Marshal.SizeOf( fmt ) ); ;
                Marshal.StructureToPtr( fmt, lFmt, false );

                SendMessage( new HandleRef( this, Handle ), EM_SETPARAFORMAT, IntPtr.Zero, lFmt );

                Marshal.FreeCoTaskMem( lFmt );
                }
            }

        }
    }
