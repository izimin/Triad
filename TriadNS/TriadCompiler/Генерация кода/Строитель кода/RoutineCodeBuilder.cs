using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

namespace TriadCompiler
    {
    /// <summary>
    /// Создание кода для рутины
    /// !!! Все переменные-члены этого класса должны пересоздаваться в методе Reload
    /// </summary>
    internal class RoutineCodeBuilder : CodeBuilder
        {
        /// <summary>
        /// Функция инициализации рутины
        /// </summary>
        protected CodeMemberMethod initialMethod = new CodeMemberMethod();


        /// <summary>
        /// Конструктор
        /// </summary>
        public RoutineCodeBuilder()
            {
            CreateInitialMethod();
            }


        
        /// <summary>
        /// Создать метод DoInitialize
        /// </summary>
        private void CreateInitialMethod()
            {
            this.initialMethod = new CodeMemberMethod();
            initialMethod.Name = Builder.Routine.Initial;
            initialMethod.Attributes = MemberAttributes.Public | MemberAttributes.Override;
            resultClass.Members.Add( initialMethod );
            }


        /// <summary>
        /// Определить событие обработки входных сообщений
        /// </summary>
        /// <param name="statementList">Список операторов</param>
        public void SetMessageHandlingEvent( CodeStatementCollection statementList )
            {
            CodeMemberMethod enterEventMethod = new CodeMemberMethod();
            enterEventMethod.Name = Builder.Routine.Receive.ReceiveMessage;
            enterEventMethod.Attributes = MemberAttributes.Family | MemberAttributes.Override;
            enterEventMethod.Statements.AddRange( statementList );

            //Параметры
            enterEventMethod.Parameters.Add( new CodeParameterDeclarationExpression(
                Builder.CoreName.Name,
                Builder.Routine.Receive.ReceivedPolus ) );
            enterEventMethod.Parameters.Add( new CodeParameterDeclarationExpression(
                "String",
                Builder.Routine.Receive.ReceivedMessage ) );

            resultClass.Members.Add( enterEventMethod );
            }


        /// <summary>
        /// Задать секцию initialSet
        /// </summary>
        /// <param name="statementList">Список операторов</param>
        public void SetInitialSection( CodeStatementCollection statementList )
            {            
            initialMethod.Statements.AddRange( statementList );
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
                    initialMethod.Statements.Insert(0, initArrayStat);
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
        /// Подготовить объект к новому циклу компиляции
        /// </summary>
        public override void Reload()
            {
            base.Reload();            
            CreateInitialMethod();
            }
        }
    }
