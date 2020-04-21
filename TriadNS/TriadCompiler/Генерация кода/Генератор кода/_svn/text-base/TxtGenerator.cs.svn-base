using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.IO;

namespace TriadCompiler.Code.Generator
    {
    /// <summary>
    /// Генерация текста на C#
    /// </summary>
    internal class TxtGenerator : CommonGenerator
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public TxtGenerator()
            {
            }

        /// <summary>
        /// Создать текст на C#
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        public override void GenerateCode( string fileName )
            {
            CSharpCodeProvider csCodeProvider = new CSharpCodeProvider();
            CodeGeneratorOptions generatorParameters = new CodeGeneratorOptions();
            using ( TextWriter streamWriter = new StreamWriter( fileName, false, System.Text.Encoding.Unicode ) )
                {
                csCodeProvider.GenerateCodeFromCompileUnit( unitCode, streamWriter, generatorParameters );
                streamWriter.Flush();
                }
            }
        }
    }
