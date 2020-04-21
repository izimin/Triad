using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

namespace TriadCompiler
    {
    class IProcedureCodeBuilder : RoutineCodeBuilder
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public IProcedureCodeBuilder()
            {
            CreateRegisterSpyObjectMethod();
            CreateGetOutVarMethod();
            CreateDoHandlingMethod();
            CreateDoProcessingMethod();            
            }


        /// <summary>
        /// Создать метод, регистрирующий все spy-объекты
        /// </summary>
        private void CreateRegisterSpyObjectMethod()
            {
            this.registerSpyObjectsMethod = new CodeMemberMethod();
            this.registerSpyObjectsMethod.Name = Builder.IProcedure.RegisterAllSpyObjects;
            this.registerSpyObjectsMethod.Attributes = MemberAttributes.Public | MemberAttributes.Final;

            this.resultClass.Members.Add( this.registerSpyObjectsMethod );
            }


        /// <summary>
        /// Создать метод, возвращающий все out-переменные
        /// </summary>
        private void CreateGetOutVarMethod()
            {
            this.getOutVarMethod = new CodeMemberMethod();
            this.getOutVarMethod.Name = Builder.IProcedure.GetOutVariables;
            this.getOutVarMethod.Attributes = MemberAttributes.Public | MemberAttributes.Final;

            this.resultClass.Members.Add( this.getOutVarMethod );
            }


        /// <summary>
        /// Создать метод, возвращающий значение ИП
        /// </summary>
        private void CreateDoProcessingMethod()
            {
            this.doProcessingMethod = new CodeMemberMethod();
            this.doProcessingMethod.Name = Builder.IProcedure.DoProcessing;
            this.doProcessingMethod.Attributes = MemberAttributes.Public | MemberAttributes.Final;

            this.resultClass.Members.Add( this.doProcessingMethod );
            }


        /// <summary>
        /// Создать метод, обрабатывающий изменения spy-объектов
        /// </summary>
        private void CreateDoHandlingMethod()
            {
            this.doHandlingMethod = new CodeMemberMethod();
            this.doHandlingMethod.Name = Builder.IProcedure.Handling.DoHandling;
            this.doHandlingMethod.Attributes = MemberAttributes.Family | MemberAttributes.Override;

            //Первый параметр - изменившийся объект
            CodeParameterDeclarationExpression paramSpyObject = new CodeParameterDeclarationExpression();
            paramSpyObject.Name = Builder.IProcedure.Handling.SpyObjectNameInDoHandling;
            paramSpyObject.Type = new CodeTypeReference( Builder.IProcedure.SpyObject );

            this.doHandlingMethod.Parameters.Add( paramSpyObject );

            //Второй параметр - текущее системное время
            CodeParameterDeclarationExpression paramSystemTime = new CodeParameterDeclarationExpression();
            paramSystemTime.Name = Builder.Routine.SystemTime;
            paramSystemTime.Type = new CodeTypeReference( "Double" );

            this.doHandlingMethod.Parameters.Add( paramSystemTime );

            //Внутри создаем строковую переменную, содержащую сообщение в случае, если оно пришло на полюс
            CodeVariableDeclarationStatement messageDeclaration = new CodeVariableDeclarationStatement(
                "String", Builder.Routine.Receive.ReceivedMessage );
            //Инициализирующее значение
            CodeFieldReferenceExpression initExpr = new CodeFieldReferenceExpression();
            initExpr.TargetObject = new CodeArgumentReferenceExpression( Builder.IProcedure.Handling.SpyObjectNameInDoHandling );
            initExpr.FieldName = Builder.IProcedure.Handling.MessageField;

            messageDeclaration.InitExpression = initExpr;

            this.doHandlingMethod.Statements.Insert( 0, messageDeclaration );

            this.resultClass.Members.Add( this.doHandlingMethod );
            }


        /// <summary>
        /// Добавить spy-объект
        /// </summary>
        /// <param name="spyObjectType">Тип spy-объекта</param>
        public void AddSpyObject( ISpyType spyObjectType )
            {
            //Добавляем его как параметр в функцию регистрации spy-объектов
            CodeParameterDeclarationExpression param = new CodeParameterDeclarationExpression();
            param.Name = spyObjectType.Name;
            
            //Если это одиночный spy-объект
            if ( !( spyObjectType is IndexedType ) )
                param.Type = new CodeTypeReference( Builder.IProcedure.SpyObject );
            //Если это массив spy-объектов (пусть даже многомерный!!! - он передается как одномерный)
            else
                param.Type = new CodeTypeReference( Builder.IProcedure.SpyObject + "[]" );

            this.registerSpyObjectsMethod.Parameters.Add( param );

            //Создаем метод, регистрирующий spy-объект
            AddRegisterSpyObjectMethod( spyObjectType );

            //Если объект следит за переменной
            if ( spyObjectType is IExprType )
                {
                //То добавляем одноименное свойство
                AddProperty( spyObjectType as IExprType );
                }
            }



        /// <summary>
        /// Добавить свойство для объекта, следящего за переменной
        /// </summary>
        /// <param name="spyVarType">Объект</param>
        private void AddProperty( IExprType spyVarType )
            {
            string baseTypeString = GetBaseTypeString( spyVarType );
            string typeStr = GetTypeString( baseTypeString, spyVarType );

            CodeMemberProperty property = new CodeMemberProperty();
            property.Name = spyVarType.Name;
            property.Type = new CodeTypeReference( typeStr );
            property.Attributes = MemberAttributes.Private;
            
            //Аксептор Get
            CodeMethodReturnStatement getValueStat = new CodeMethodReturnStatement( 
                new CodeSnippetExpression(
                "((" + typeStr + ")" + Builder.IProcedure.GetValueForVar + 
                "(new " + Builder.CoreName.Name + "(\"" + spyVarType.Name + "\")))" ) );
            
            property.GetStatements.Add( getValueStat );

            //Аксептор set
            CodeMethodInvokeExpression setValueStat = new CodeMethodInvokeExpression();
            setValueStat.Method = new CodeMethodReferenceExpression();
            setValueStat.Method.MethodName = Builder.IProcedure.SetValueForVar;
            setValueStat.Parameters.Add( new CodeSnippetExpression(
                "new " + Builder.CoreName.Name + "(\"" + spyVarType.Name + "\")" ) );
            setValueStat.Parameters.Add( new CodeArgumentReferenceExpression( "value" ) );

            property.SetStatements.Add( setValueStat );

            resultClass.Members.Add( property );
            }


        /// <summary>
        /// Добавить метод, регистрирующий один spy-объект
        /// </summary>
        /// <param name="spyObjectType">Тип spy-объекта</param>
        private void AddRegisterSpyObjectMethod( ISpyType spyObjectType )
            {
            CodeObjectCreateExpression coreNameCode = new CodeObjectCreateExpression();

            //Есди это одиночный объект
            if ( !( spyObjectType is IndexedType ) )
                coreNameCode.CreateType = new CodeTypeReference( Builder.CoreName.Name );
            //Если это массив объектов
            else
                coreNameCode.CreateType = new CodeTypeReference( Builder.CoreName.Range );

            coreNameCode.Parameters.Add( new CodePrimitiveExpression( spyObjectType.Name ) );

            //Если это массив объектов
            if ( spyObjectType is IndexedType )
                {
                //Индексированными могут быть только переменные и полюса
                IndexedType indexedType = spyObjectType as IndexedType;

                if ( indexedType != null )
                    {
                    foreach ( int maxIndex in indexedType )
                        {
                        //Нижняя граница диапазона всегда 0
                        coreNameCode.Parameters.Add( new CodePrimitiveExpression( 0 ) );
                        //Верхнюю границу диапазона берем из типа массива
                        coreNameCode.Parameters.Add( new CodePrimitiveExpression( maxIndex - 1 ) );
                        }
                    }
                }

            //Вызов функции регистрации
            CodeMethodInvokeExpression registerStat = new CodeMethodInvokeExpression();
            registerStat.Method = new CodeMethodReferenceExpression();
            registerStat.Method.MethodName = Builder.IProcedure.RegisterSpyObject;
            registerStat.Parameters.Add( new CodeArgumentReferenceExpression( spyObjectType.Name ) );
            registerStat.Parameters.Add( coreNameCode );

            this.registerSpyObjectsMethod.Statements.Add( registerStat ); 
            }


        /// <summary>
        /// Добавить метод, регистрирующий обработчик изменений объекта слежения
        /// </summary>
        /// <param name="spyObjectType">Тип объекта слежения</param>
        public void AddSpyHandler( ISpyType spyObjectType )
            {
            //Вызов функции регистрации
            CodeMethodInvokeExpression registerStat = new CodeMethodInvokeExpression();
            registerStat.Method = new CodeMethodReferenceExpression();
            registerStat.Method.MethodName = Builder.IProcedure.RegisterSpyHandler;
            registerStat.Parameters.Add( new CodeArgumentReferenceExpression( spyObjectType.Name ) );
            registerStat.Parameters.Add( new CodeArgumentReferenceExpression( Builder.IProcedure.Handling.DoHandling ) );

            this.registerSpyObjectsMethod.Statements.Add( registerStat ); 
            }


        /// <summary>
        /// Добавить out-переменную
        /// </summary>
        /// <param name="varType">Тип переменной</param>
        public void AddOutVariable( IExprType varType )
            {
            //Объявляем эту переменную внутри
            this.AddVarDefinition( varType );

            //Добавляем переменную как параметр в функцию, возвращающую out-переменные
            CodeParameterDeclarationExpression param = new CodeParameterDeclarationExpression();
            param.Name = varType.Name;
            param.Type = new CodeTypeReference( GetTypeString( GetBaseTypeString( varType ), varType ) );
            param.Direction = FieldDirection.Out;

            this.getOutVarMethod.Parameters.Add( param );

            //Возвращаем значение out-переменной
            CodeAssignStatement assignStat = new CodeAssignStatement();
            assignStat.Left = new CodeArgumentReferenceExpression( varType.Name );
            assignStat.Right = new CodeFieldReferenceExpression(
                new CodeThisReferenceExpression(), varType.Name );

            this.getOutVarMethod.Statements.Add( assignStat ); 
            }


        /// <summary>
        /// Задать тип значения, возращаемого ИП
        /// </summary>
        /// <param name="varType">Тип значения</param>
        public void SetIPResultType( IExprType varType )
            {
            //Задаем тип возращаемого значения
            this.doProcessingMethod.ReturnType = new CodeTypeReference( GetBaseTypeString( varType ) );

            string baseType = GetBaseTypeString( varType );
            //Создаем переменную, аккамулирующую результат (ее имя совпадает с именем ИП)
            CodeVariableDeclarationStatement varDeclaration = new CodeVariableDeclarationStatement(
                baseType, this.resultClass.Name );
            //Инициализирующее значение
            CodeObjectCreateExpression initExpr = new CodeObjectCreateExpression();
            initExpr.CreateType = new CodeTypeReference( baseType );
            varDeclaration.InitExpression = initExpr;

            this.doProcessingMethod.Statements.Insert( 0, varDeclaration );

            //В конце возвращаем эту переменную
            CodeMethodReturnStatement returnStat = new CodeMethodReturnStatement();
            returnStat.Expression = new CodeArgumentReferenceExpression( this.resultClass.Name );

            this.doProcessingMethod.Statements.Add( returnStat );
            }


        /// <summary>
        /// Задать операторы в секции processing
        /// </summary>
        /// <param name="statList">Список операторов</param>
        public void SetDoProcessing( CodeStatementCollection statList )
            {
            //Предполагается, что doProcessingMethod уже содержит два оператора
            if ( this.doProcessingMethod.Statements.Count < 2 )
                return;

            //Вставка идет в этот индекс т.к. doProcessingMethod уже содержит служебный код (см SetIPResultType)
            foreach ( CodeStatement stat in statList )
                this.doProcessingMethod.Statements.Insert( doProcessingMethod.Statements.Count - 1, stat );
            }


        /// <summary>
        /// Задать операторы в секции handling
        /// </summary>
        /// <param name="statList">Список операторов</param>
        public void SetDoHandling( CodeStatementCollection statList )
            {
            this.doHandlingMethod.Statements.AddRange( statList );
            }


        /// <summary>
        /// Перезагрузить генератор кода
        /// </summary>
        public override void Reload()
            {
            base.Reload();
            CreateRegisterSpyObjectMethod();
            CreateGetOutVarMethod();
            CreateDoHandlingMethod();
            CreateDoProcessingMethod();            
            }


        /// <summary>
        /// Метод регистрирующий spy-объекты
        /// </summary>
        private CodeMemberMethod registerSpyObjectsMethod = new CodeMemberMethod();
        /// <summary>
        /// Метод, возвращающий все out-переменные
        /// </summary>
        private CodeMemberMethod getOutVarMethod = new CodeMemberMethod();
        /// <summary>
        /// Метод, возвращающий значение ИП
        /// </summary>
        private CodeMemberMethod doProcessingMethod = new CodeMemberMethod();
        /// <summary>
        /// Метод, обрабатывающий изменение spy-объектов
        /// </summary>
        private CodeMemberMethod doHandlingMethod = new CodeMemberMethod();
        }
    }
