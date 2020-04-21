using System;
using System.Collections.Generic;
using System.Text;

namespace TriadPad
    {
    /// <summary>
    /// Опции, связанные с компиляцией
    /// </summary>
    partial class Options
        {
        /// <summary>
        /// Применить опции компиляции к системе
        /// </summary>
        private void SetCompileOptions()
            {
            this.ShowRichCompileErrorMessage = this.showRichCompileErrorMessage;
            this.CompiledDllPath = this.compiledDllPath;
            this.CompilationMode = this.compilationMode;
            }


        /// <summary>
        /// Подробность сообщений об ошибках компилятора
        /// </summary>
        private bool showRichCompileErrorMessage = true;


        /// <summary>
        /// Подробность сообщений об ошибках компилятора
        /// </summary>
        public bool ShowRichCompileErrorMessage
            {
            get
                {
                return showRichCompileErrorMessage;
                }
            set
                {
                showRichCompileErrorMessage = value;
                TriadCompiler.CompilerFacade.ShowExtendedErrorInfo = value;
                }
            }


        /// <summary>
        /// Имя папки для сохранения всех скомпилированных сборок
        /// </summary>
        private string compiledDllPath = ".";


        /// <summary>
        /// Имя папки для сохранения всех скомпилированных сборок
        /// </summary>
        public string CompiledDllPath
            {
            get 
                {
                return compiledDllPath;
                }
            set 
                {
                compiledDllPath = value;
                }
            }


        /// <summary>
        /// Текущий режим компиляции
        /// </summary>
        private CompilationMode compilationMode = CompilationMode.Model;


        /// <summary>
        /// Текущий режим компиляции
        /// </summary>
        public CompilationMode CompilationMode
            {
            get 
                {
                return compilationMode;
                }
            set 
                {
                compilationMode = value;
                }
            }
        }
    }
