using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using tom;

namespace TriadPad.Forms
    {
    /// <summary>
    /// Описание обработчиков событий на элементах главной формы
    /// </summary>
    partial class FormMain
        {

        //Кнопка - Транслировать
        private void tsbTranslate_Click( object sender, EventArgs e )
            {
            Translate();
            }


        //Кнопка - Компилировать
        private void tsbCompile_Click( object sender, EventArgs e )
            {
            Compile();
            }


        //Кнопка - Компилировать и выполнить
        private void tsbCompileAndRun_Click( object sender, EventArgs e )
            {
            CompileAndRun();
            }


        //Кнопка - Выполнить
        private void tsbRun_Click( object sender, EventArgs e )
            {
            RunProgram();
            }


        //Двойной щелчок в списке ошибок
        private void lbErrors_DoubleClick( object sender, EventArgs e )
            {
            this.rtbText.Select();
            }
        }
    }
