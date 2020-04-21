using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TriadPad.Forms
    {
    /// <summary>
    /// Обработчики меню главной формы
    /// </summary>
    partial class FormMain
        {
        /// <summary>
        /// Название главной формы
        /// </summary>
        private const string MainFormText = "Система Triad.NET";
        /// <summary>
        /// Название нового файла
        /// </summary>
        private const string NewFileName = "Новый.txt";


        //Меню - Новый файл
        private void tsmiNewFile_Click( object sender, EventArgs e )
            {
            CreateNewFile();
            }
        

        //Меню - Открыть файл
        private void tsmiOpenFile_Click( object sender, EventArgs e )
            {
            if ( this.openFileDialog.ShowDialog() == DialogResult.OK )
                {
                OpenFile( this.openFileDialog.FileName );
                }
            }        


        //Меню - Выход
        private void tsmiExit_Click( object sender, EventArgs e )
            {
            this.Close();
            }


        //Меню - Сохранить
        private void tsmiSave_Click( object sender, EventArgs e )
            {
            if ( currFileName != NewFileName )
                {
                this.rtbText.SaveFile( currFileName, RichTextBoxStreamType.PlainText );
                }
            //Иначе - Сохранить как...
            else
                {
                tsmiSaveAs_Click( this, new EventArgs() );
                }
            }


        //Меню - Сохранить как
        private void tsmiSaveAs_Click( object sender, EventArgs e )
            {
            if ( this.saveFileDialog.ShowDialog() == DialogResult.OK )
                {
                SaveFileAs( this.saveFileDialog.FileName );
                }
            }


        //Меню - Транслировать
        private void tsmiTranslate_Click( object sender, EventArgs e )
            {
            Translate();
            }


        //Меню - Компилировать
        private void tsmiCompile_Click( object sender, EventArgs e )
            {
            Compile();
            }


        //Меню - Компилировать и выполнить
        private void tsmiCompileAndRun_Click( object sender, EventArgs e )
            {
            CompileAndRun();
            }


        //Меню - Выполнить
        private void tsmiRun_Click( object sender, EventArgs e )
            {
            RunProgram();
            }


        //Меню - О программе
        private void tsmiAbout_Click( object sender, EventArgs e )
            {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
            }


        //Меню - Опции компиляции
        private void tsmiOptions_Click( object sender, EventArgs e )
            {
            FormOptions formOptions = new FormOptions();
            formOptions.ShowDialog();
            }


        //Меню - Перейти
        private void tsmiGoTo_Click( object sender, EventArgs e )
            {
            FormGoTo.Instance.Go( this.rtbText );
            }


        //Меню - Найти
        private void tsmiFind_Click( object sender, EventArgs e )
            {
            FormFind.Instance.Find( this.rtbText );
            }


        //Меню - Найти и заменить
        private void tsmiReplace_Click( object sender, EventArgs e )
            {
            FormReplace.Instance.Replace( this.rtbText );
            }


        //Меню - Вырезать
        private void tsmiCut_Click( object sender, EventArgs e )
            {
            this.rtbText.Cut();
            }


        //Меню - Копировать
        private void tsmiCopy_Click( object sender, EventArgs e )
            {
            if ( this.rtbText.Focused )
                this.rtbText.Copy();
            else if ( this.rtbCode.Focused )
                this.rtbCode.Copy();
            }


        //Меню - Вставить
        private void tsmiPaste_Click( object sender, EventArgs e )
            {
            this.rtbText.Paste();
            }


        //Меню - Выделить все
        private void tsmiSelectAll_Click( object sender, EventArgs e )
            {
            this.rtbText.SelectAll();
            }


        //Меню - Отменить
        private void tsmiUndo_Click( object sender, EventArgs e )
            {
            this.rtbText.Undo();
            }


        //Меню - Закомментировать
        private void tsmiComment_Click( object sender, EventArgs e )
            {
            this.Comment();
            }


        //Меню - Убрать комментарий
        private void tsmiUncomment_Click( object sender, EventArgs e )
            {
            this.Uncomment();
            }


        //Меню - Увеличить отступ
        private void tsmiIncreaseIndent_Click( object sender, EventArgs e )
            {
            this.IncreaseIndent();
            }


        //Меню - Уменьшить отступ
        private void tsmiDecreaseIndent_Click( object sender, EventArgs e )
            {
            this.DecreaseIndent();
            }


        //Меню - Вырезать текущую строку
        private void tsmiCutCurrentLine_Click( object sender, EventArgs e )
            {
            this.rtbText.CutCurrentLine();
            }


        //Меню - Перевести в верхний регистр
        private void tsmiToUpper_Click( object sender, EventArgs e )
            {
            this.SetSelectedTextToUpper();
            }


        //Меню - Перевести в нижний регистр
        private void tsmiToLower_Click( object sender, EventArgs e )
            {
            this.SetSelectedTextToLower();
            }


        //Меню - Задать опции
        private void параметрыToolStripMenuItem_Click( object sender, EventArgs e )
            {
            FormOptions formOptions = new FormOptions();
            formOptions.ShowDialog();
            }


        //Меню - Экспорт опций
        private void tsmiExportOptions_Click( object sender, EventArgs e )
            {
            if ( this.saveOptionDialog.ShowDialog() == DialogResult.OK )
                {
                Options.Instance.SaveToFile( this.saveOptionDialog.FileName );
                }
            }


        //Меню - Импорт опций
        private void tsmiImportOptions_Click( object sender, EventArgs e )
            {
            if ( this.openOptionDialog.ShowDialog() == DialogResult.OK )
                {
                Options.Instance.OpenFromFile( this.openOptionDialog.FileName );
                }
            }


        //Меню - Установить опции по умолчанию
        private void tsmiSetOptionDefaultValue_Click( object sender, EventArgs e )
            {
            Options.Instance.SetDefaultValues();
            }


        //Меню - Быстрая печать
        private void tsmiQuickPrint_Click( object sender, EventArgs e )
            {
            this.rtbText.PrintRichTextContents();
            }

        //Меню - Параметры печати
        private void tsmiPrintSetup_Click( object sender, EventArgs e )
            {
            SetPrintParameters();
            }

        //Меню - Печать
        private void tsmiPrint_Click( object sender, EventArgs e )
            {
            PrintCurrentDocument();
            }

        //Меню - Предварительный просмотр
        private void tsmiPrintPreview_Click( object sender, EventArgs e )
            {
            PrintPreviewDocument();
            }


        }
    }
