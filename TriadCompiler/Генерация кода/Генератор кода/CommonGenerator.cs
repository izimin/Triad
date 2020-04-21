using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;
using System.CodeDom.Compiler;

namespace TriadCompiler.Code.Generator
    {
    /// <summary>
    /// Генерация кода
    /// </summary>
    internal class CommonGenerator
        {
        /// <summary>
        /// Путь к файлу с кодом ядра
        /// </summary>
        protected const string CoreFilePath = "TriadCore.dll";


        /// <summary>
        /// Конструктор
        /// </summary>
        public CommonGenerator()
            {
            Reload();
            }


        /// <summary>
        /// Добавление кода класса к сборку
        /// </summary>
        /// <param name="typeCode"></param>
        public void AddTypeInUnit( CodeTypeDeclaration typeCode )
            {
            namespaceCode.Types.Add( typeCode );
            }


        /// <summary>
        /// Добавить ссылку на другую сборку
        /// </summary>
        /// <param name="fileName">Имя сборки</param>
        public virtual void AddReference( string fileName )
            {
            }


        /// <summary>
        /// Создать код
        /// </summary>
        /// <param name="fileName">Имя сборки</param>
        public virtual void GenerateCode( string fileName )
            {
            }


        /// <summary>
        /// Подготовить генератор кода к новой компиляции
        /// </summary>
        public virtual void Reload()
            {
            unitCode = new CodeCompileUnit();

            namespaceCode = new CodeNamespace( Builder.Common.Namespace );
            namespaceCode.Imports.Add( new CodeNamespaceImport( "System" ) );
            namespaceCode.Imports.Add( new CodeNamespaceImport( "System.Collections.Generic" ) );
            namespaceCode.Imports.Add( new CodeNamespaceImport( "System.Collections" ) );

            unitCode.Namespaces.Add( namespaceCode );
            }


        /// <summary>
        /// Создаваемая сборка
        /// </summary>
        protected CodeCompileUnit unitCode = new CodeCompileUnit();
        /// <summary>
        /// Пространство имен
        /// </summary>
        protected CodeNamespace namespaceCode = new CodeNamespace( Builder.Common.Namespace );
        }
    }
