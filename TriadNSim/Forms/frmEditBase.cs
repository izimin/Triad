using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TriadPad;
using TriadCompiler;
using System.IO;


namespace TriadNSim.Forms
{
    
    public partial class frmEditBase : Form
    {
        public string DesignTypeName;
        private TriadPad.Forms.Syntax syntax;
        public bool Successed;

        public frmEditBase()
        {
            InitializeComponent();
            InitializeRtbEdit();
            syntax = TriadPad.Forms.Syntax.Instance;
            numberLabel.Font = rtbText.Font;
            SynchronizeLineNumbers();
            this.splitContainer1.Panel2Collapsed = true;
        }
        
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
            this.rtbText.VScroll += this.rtbText_VScroll;
            this.rtbText.Resize += this.rtbText_Resize;
        }

        //Прокрутка окна с текстом
        private void rtbText_VScroll(object sender, EventArgs e)
        {
            //Чуть-чуть подравниваем label
            int deltaH = this.rtbText.GetPositionFromCharIndex(0).Y % (this.rtbText.Font.Height + 1);
            this.numberLabel.Top = deltaH;

            SynchronizeLineNumbers();
        }

        //Изменение размера окна редактирования
        private void rtbText_Resize(object sender, EventArgs e)
        {
            rtbText_VScroll(this, EventArgs.Empty);
        }

        //Обработка изменения текста
        private void rtbText_TextChanged(object sender, EventArgs e)
        {
            SynchronizeLineNumbers();

            //Подсветка синтаксиса
            syntax.Select(this.rtbText);
        }

        /// <summary>
        /// Синхронизовать номера строк
        /// </summary>
        public void SynchronizeLineNumbers()
        {
            int firstVisibleLineNumber = this.rtbText.FirstVisibleLineNumber;
            int lastVisibleLineNumber = this.rtbText.LastVisibleLineNumber;

            StringBuilder lineText = new StringBuilder();
            for (int lineIndex = firstVisibleLineNumber; lineIndex <= lastVisibleLineNumber; lineIndex++)
            {
                lineText.Append(lineIndex.ToString());
                lineText.Append(Environment.NewLine);
            }
            this.numberLabel.Text = lineText.ToString();
        }

        //Изменение выделенного элемента в списке ошибок
        private void lvErrors_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (int selIndex in this.lvErrors.SelectedIndices)
            {
                ErrorDescription error = this.lvErrors.Items[selIndex].Tag as ErrorDescription;
                if (error != null)
                {
                    this.rtbText.BeginUpdate();
                    this.rtbText.SetCharBackColor(CharFormatArea.AllText, this.rtbText.BackColor);

                    //Общее число строк
                    int totalLineNumber = this.rtbText.Lines.Length;

                    //Если текста нет
                    if (totalLineNumber == 0)
                        return;

                    //Номер строки с ошибкой
                    int errorLineNumber = 0;

                    //Если номер строки превышает максимально допустимый
                    if (error.lineNumber >= totalLineNumber)
                    {
                        errorLineNumber = totalLineNumber - 1;
                    }
                    else
                    {
                        errorLineNumber = error.lineNumber;
                    }

                    //Строка с ошибкой
                    string errorLine = this.rtbText.Lines[errorLineNumber];

                    //Если текущая строка пуста
                    if (errorLine.Trim() == string.Empty)
                    {
                        this.rtbText.SelectionLength = 0;
                        return;
                    }

                    //Если индекс символа с ошибкой выходит за пределы строки
                    if (error.chNumber > errorLine.Length)
                    {
                        this.rtbText.SelectionLength = 0;
                        return;
                    }

                    //Номер символа с ошибкой
                    int errorChPos = this.rtbText.GetFirstCharIndexFromLine(errorLineNumber) + error.chNumber;

                    //Номер первого символа текущей строки
                    int currStrFirstChNumber = this.rtbText.GetFirstCharIndexFromLine(errorLineNumber);

                    //Номер первой буквы слова в текущей строке
                    int wordFirstChIndex = errorLine.Length - 1;
                    //Если такой символ есть в строке
                    if (errorChPos - currStrFirstChNumber < errorLine.Length)
                    {
                        wordFirstChIndex = errorChPos - currStrFirstChNumber;
                    }

                    int selectionStart = this.rtbText.FindWordBreak(FindWordBreakMode.MoveWordLeft, errorChPos);
                    this.rtbText.Select(selectionStart, errorChPos - selectionStart);

                    this.rtbText.SetCharBackColor(CharFormatArea.Selection, Color.Red);
                    this.rtbText.SelectionLength = 0;
                }
                else
                    throw new ArgumentException("Неверный тип элемента списка");
                this.rtbText.EndUpdate();
                this.rtbText.Invalidate();
            }
        }

        public string Code
        {
            get
            {
                return this.rtbText.Text;
            }
            set
            {
                rtbText.Text = value;
                this.rtbText.Scroll(0);
                syntax.ClearHistory();
                SynchronizeLineNumbers();
                syntax.Select(this.rtbText);
            }
        }

        public string Description
        {
            get
            {
                return txtDescription.Text;
            }
            set
            {
                txtDescription.Text = value;
            }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            this.Successed = false;
            this.splitContainer.Panel2Collapsed = true;
            this.Visible = false;
        }

        protected virtual bool OnOk()
        {
            return true;
        }

        private void tsbОК_Click(object sender, EventArgs e)
        {
            if (Compile())
            {
                DesignTypeName = CompilerFacade.DesignTypeName;
                if (OnOk())
                {
                    this.splitContainer.Panel2Collapsed = true;
                    this.Successed = true;
                    this.Visible = false;
                }
            }
            else
            {
                this.splitContainer.Panel2Collapsed = false;
            }
        }

        private void ChangeRoutine_Activated(object sender, EventArgs e)
        {
            rtbText.Focus();
        }

        protected virtual void CompileCode(IOErrorListener io)
        {
            //
        }

        private bool Compile()
        {
            this.rtbText.SetCharBackColor(TriadPad.CharFormatArea.AllText, this.rtbText.BackColor);

            bool success = true;

            InputRichEdit input = new InputRichEdit(this.rtbText);
            RichTextBox listing = new RichTextBox();
            OutputRichEdit output = new OutputRichEdit(listing);
            IOErrorListener io = new IOErrorListener(input, output);

            this.lvErrors.Items.Clear();

            CompileCode(io);
            
            ErrorDescription[] registeresErrors = io.getRegisteredErrors();
            foreach (ErrorDescription errorFound in registeresErrors)
            {
                ListViewItem newItem = new ListViewItem((this.lvErrors.Items.Count + 1).ToString());
                newItem.Tag = errorFound;
                newItem.SubItems.Add(errorFound.ToString());
                newItem.SubItems.Add(errorFound.lineNumber.ToString());
                newItem.SubItems.Add(errorFound.chNumber.ToString());
                this.lvErrors.Items.Add(newItem);
                success = false;
            }
            return success;
        }
    }
}
