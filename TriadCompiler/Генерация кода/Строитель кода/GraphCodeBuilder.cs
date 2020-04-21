using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

namespace TriadCompiler
    {
    /// <summary>
    /// Обобщенный построитель кода, основанный на методе Build()
    /// !!! Все переменные-члены этого класса должны пересоздаваться в методе Reload
    /// </summary>
    internal class GraphCodeBuilder : CodeBuilder
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public GraphCodeBuilder()
            {
            //Создаем метод построения структуры
            CreateBuildMethod();
            }

        /// <summary>
        /// Создать метод, строящий структуру
        /// </summary>
        protected virtual void CreateBuildMethod()
            {
            //Описываем метод
            this.buildGraphMethod = new CodeMemberMethod();
            this.buildGraphMethod.Attributes = MemberAttributes.Public | MemberAttributes.Override;
            this.buildGraphMethod.Name = Builder.Common.BuildMethod;

            this.resultClass.Members.Add(buildGraphMethod);
            }


        /// <summary>
        /// Добавить объявление переменной
        /// </summary>
        /// <param name="varType">Тип переменной</param>
        public override void AddVarDefinition( IExprType varType )
            {
                CodeMemberField field = new CodeMemberField();

                string baseSimpleType = GetBaseTypeString(varType);
                field = new CodeMemberField(GetTypeString(GetBaseTypeString(varType), varType), varType.Name);

                //Если это массив
                if (varType is VarArrayType)
                {
                    //Инициализировать массивы нужно в ф-и Initialize
                    //иначе при клонированные рутины будут иметь общие массивы
                    CodeAssignStatement initArrayStat = new CodeAssignStatement();
                    initArrayStat.Left = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(),
                        varType.Name);
                    initArrayStat.Right = new CodeSnippetExpression(
                        GetIndexFieldInitialization(baseSimpleType, varType as VarArrayType));
                    this.buildGraphMethod.Statements.Insert(0, initArrayStat);
                }
                //Если это множество
                else if (varType is SetType)
                {
                    field.InitExpression = new CodeSnippetExpression(GetSetFieldInitialization());
                }
                //=========By jum==========
                else if (varType.Code == TypeCode.Node)
                {
                     CodeObjectCreateExpression createExpr = new CodeObjectCreateExpression(Builder.Common.NodeClassName, new CodeObjectCreateExpression(Builder.CoreName.Name, new CodePrimitiveExpression(varType.Name)));
                     field.InitExpression = createExpr; 
                }

                field.Attributes = MemberAttributes.Private;
                resultClass.Members.Add(field);
            }

        
        /// <summary>
        /// Добавить код, строящий структуру
        /// </summary>
        /// <param name="statementList">Последовательность операторов</param>
        public void AddBuildStatementList( CodeStatementCollection statementList )
            {
            this.buildGraphMethod.Statements.AddRange( statementList );
            }


        /// <summary>
        /// Подготовить построитель кода для новой компиляции
        /// </summary>
        public override void Reload()
            {
            base.Reload();
            CreateBuildMethod();
            }


        /// <summary>
        /// Сгенерировать код
        /// </summary>
        public override void Build()
            {
            this.buildGraphMethod.ReturnType = new CodeTypeReference( Builder.Structure.GraphClass );

            //Добавляем оператор, возвращающий результат в метод, строящий структуру
            CodeMethodReturnStatement returnStatement = new CodeMethodReturnStatement(
                 new CodeVariableReferenceExpression( this.resultClass.Name ) );                    
            this.buildGraphMethod.Statements.Add(returnStatement);

            base.Build();
            }


        /// <summary>
        /// Метод, в котором создается структура
        /// </summary>
        protected CodeMemberMethod buildGraphMethod = null;
        }
    }
