using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Expr;

namespace TriadCompiler.Parser.Common.ObjectRef
    {  
    /// <summary>
    /// Описание ссылки на диапазон объектов
    /// </summary>
    class ObjectRefInfo
        {
        /// <summary>
        /// Описание диапазона изменения одного индекса
        /// </summary>
        public class IndexBounds
            {
            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="lowIndexExpr">Выражение, описывающее нижнюю границу диапазона</param>
            /// <param name="topIndexExpr">Выражение, описывающее верхнюю границу диапазона</param>
            public IndexBounds( ExprInfo lowIndexExpr, ExprInfo topIndexExpr )
                {
                this.lowIndexExpr = lowIndexExpr;
                this.topIndexExpr = topIndexExpr;
                }

            /// <summary>
            /// Выражение, описывающее нижнюю границу диапазона
            /// </summary>
            public ExprInfo lowIndexExpr = new ExprInfo();
            /// <summary>
            /// Выражение, описывающее верхнюю границу диапазона
            /// </summary>
            public ExprInfo topIndexExpr = new ExprInfo();
            }


        /// <summary>
        /// Имя объекта
        /// </summary>
        public string Name
            {
            get { return objectName; }
            set { this.objectName = value; }
            }


        /// <summary>
        /// Добавить описание диапазона индекса
        /// </summary>
        /// <param name="indexBounds">Диапазон</param>
        public void AddIndexBounds( IndexBounds indexBounds )
            {
            this.indexBounds.Add( indexBounds );
            }


        /// <summary>
        /// Добавить описание диапазона индекса
        /// </summary>
        /// <param name="indexBoundArray">Массив диапазонов</param>
        public void AddIndexBounds( IndexBounds[] indexBoundArray )
            {
            foreach ( IndexBounds indexBounds in indexBoundArray )
                this.indexBounds.Add( indexBounds );
            }


        /// <summary>
        /// Диапазоны изменения индексов
        /// </summary>
        public IndexBounds[] IndexBoundArray
            {
            get
                {
                return this.indexBounds.ToArray();
                }
            }


        /// <summary>
        /// Наличие индексов
        /// </summary>
        public bool HasIndexes
            {
            get
                {
                return this.indexBounds.Count > 0;
                }
            }


        /// <summary>
        /// Признак диапазона
        /// </summary>
        public bool IsRange
            {
            get
                {
                return this.isIndexRange;
                }
            set
                {
                this.isIndexRange = value;
                }
            }


        /// <summary>
        /// Число индексов
        /// </summary>
        public int IndexCount
            {
            get
                {
                return this.indexBounds.Count;
                }
            }


        /// <summary>
        /// Код, соответствующий ссылке на диапазон объектов
        /// </summary>
        public CodeObjectCreateExpression CoreNameCode
            {
            get { return coreNameCode; }
            set { this.coreNameCode = value; }
            }


        /// <summary>
        /// Строковое представление переменной
        /// Если указан диапазон, то в строковое представление пишутся только нижние индексы
        /// </summary>
        public string StrCode
            {
            get { return codeStr.ToString(); }
            set { this.codeStr = new StringBuilder( value ); }
            }


        /// <summary>
        /// Добавить часть строкового представления
        /// </summary>
        /// <param name="code">Добавляемая часть</param>
        public void AppendStrCode( string code )
            {
            this.codeStr.Append( code );
            }


        /// <summary>
        /// Имя объекта
        /// </summary>
        private string objectName = string.Empty;
        /// <summary>
        /// Признак диапазона
        /// </summary>
        private bool isIndexRange = false;
        /// <summary>
        /// Диапазоны изменения индексов
        /// </summary>
        private List<IndexBounds> indexBounds = new List<IndexBounds>();
        /// <summary>
        /// Код, соответствующий ссылке на диапазон объектов
        /// </summary>
        private CodeObjectCreateExpression coreNameCode = new CodeObjectCreateExpression();
        /// <summary>
        /// Строковое представление переменной
        /// </summary>
        private StringBuilder codeStr = new StringBuilder();
        }
    }
