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
    /// Генерация текста в память
    /// </summary>
    internal class MemoryGenerator : CommonGenerator
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public MemoryGenerator()
            {
            }


        /// <summary>
        /// Добавить ссылку на другую сборку
        /// </summary>
        /// <param name="fileName">Имя сборки</param>
        public override void AddReference( string fileName )
            {
            if ( !this.referenceAssembliesList.Contains( fileName.ToLower() ) )
                {
                if ( File.Exists( fileName ) )
                    this.referenceAssembliesList.Add( fileName.ToLower() );
                //Если путь к файлу указан неправильно
                else
                    {
                    Fabric.Instance.ErrReg.Register( Err.Generator.InvalidFileName );
                    }
                }
            }


        /// <summary>
        /// Подготовить генератор кода к новой компиляции
        /// </summary>
        public override void Reload()
            {
            base.Reload();
            this.referenceAssembliesList.Clear();
            }


        /// <summary>
        /// Создать сборку в памяти
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        public override void GenerateCode( string fileName )
            {
            CSharpCodeProvider csCodeProvider = new CSharpCodeProvider();
            CompilerParameters compilerParameters = new CompilerParameters();
            compilerParameters.CompilerOptions = "/t:library";
            compilerParameters.GenerateInMemory = true;

            //Добавляем ссылки на другие сборки
            compilerParameters.ReferencedAssemblies.Add( "system.dll" );
            foreach ( string refFileName in this.referenceAssembliesList )
                compilerParameters.ReferencedAssemblies.Add( refFileName );
            this.referenceAssembliesList.Clear();

            compilerParameters.ReferencedAssemblies.Add( CoreFilePath );

            CompilerResults compilerResults = csCodeProvider.CompileAssemblyFromDom( compilerParameters, unitCode );
            foreach ( CompilerError error in compilerResults.Errors )
                {
                Fabric.Instance.ErrReg.Register( Err.Generator.Compilation, "<" +
                   +error.Line + ":" + error.Column + "> " + error.ErrorText );
                }
            }


        /// <summary>
        /// Компилятор
        /// </summary>
        private CSharpCodeProvider csCodeProvider = new CSharpCodeProvider();
        /// <summary>
        /// Сборки, на которые нужно установить ссылки
        /// </summary>
        private List<string> referenceAssembliesList = new List<string>();
        }
    }
