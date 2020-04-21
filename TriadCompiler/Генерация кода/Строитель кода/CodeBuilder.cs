using System;
using System.Collections.Generic;
using System.CodeDom;

using TriadCompiler.Code.Generator;

namespace TriadCompiler
    {
    /// <summary>
    /// Обобщенный построитель кода
    /// !!! Все переменные-члены этого класса должны пересоздаваться в методе Reload
    /// </summary>
    internal class CodeBuilder
        {
        /// <summary>
        /// Задать имя класса
        /// </summary>
        /// <param name="className">Имя генерируемого класса</param>
        public void SetClassName( string className )
            {
            resultClass.Name = className;
            }


        /// <summary>
        /// Добавить параметр в конструктор класса
        /// </summary>
        /// <param name="varType">Тип параметра</param>
        /// <param name="varName">Имя параметра</param>
        public void AddParameterInConstructor( IExprType varType, string varName )
            {
            //Если у класса еще не было конструктора, то добавляем его
            if ( this.codeConstructor == null )
                {
                this.codeConstructor = new CodeConstructor();
                this.codeConstructor.Attributes = MemberAttributes.Public;
                this.resultClass.Members.Add( this.codeConstructor );
                }

            CodeParameterDeclarationExpression constructorParam =
                new CodeParameterDeclarationExpression( GetTypeString( GetBaseTypeString( varType ), varType ), varName );

            this.codeConstructor.Parameters.Add( constructorParam );
           
            //Добавляем код записи переданного параметра
            //в одноименную внутреннюю переменную
            CodeAssignStatement assignStat = new CodeAssignStatement();
            assignStat.Left = new CodeFieldReferenceExpression( new CodeThisReferenceExpression(), varName );
            assignStat.Right = new CodeArgumentReferenceExpression( varName );

            this.codeConstructor.Statements.Add( assignStat );
            }


        /// <summary>
        /// Добавить объявление переменной
        /// </summary>
        /// <param name="varType">Тип переменной</param>
        public virtual void AddVarDefinition( IExprType varType )
            {
            //Виртуальная ф-я нужна, т.к. в случае рутин инициализацию массивов
            //нужно производить внутри ф-и Initialize
            //Иначе при наложении одной рутины на несколько вершин
            //у них будут общие массивы
            }

        /// <summary>
        /// Добавить объявление переменной c инициализацией
        /// </summary>
        /// <param name="varType">Тип переменной</param>
        /// /// <param name="initExpression">код инициализации</param>
        public virtual void AddVarDefinition(IExprType varType, CodeExpression initExpression)
        {
            if (initExpression == null)
                AddVarDefinition(varType);
            else
            {
                CodeMemberField field = new CodeMemberField();
                string baseSimpleType = GetBaseTypeString(varType);
                field = new CodeMemberField(GetTypeString(GetBaseTypeString(varType), varType), varType.Name);
                field.InitExpression = initExpression;
                field.Attributes = MemberAttributes.Private;
                resultClass.Members.Add(field);
            }
        }

        /// <summary>
        /// Добавить design переменную
        /// </summary>
        /// <param name="designVarType">Тип design переменной</param>
        public static CodeStatementCollection GetDesignVarDefinitionStatements(IDesignVarType designVarType)
        {
            CodeStatementCollection resultStatList = new CodeStatementCollection();
            //Имя класса, представляющего переменную
            string varClass = "";

            switch (designVarType.TypeCode)
            {
                //Графовая переменная
                case DesignTypeCode.Structure:
                    varClass = Builder.Structure.GraphClass;
                    break;
                //Переменная-рутина
                case DesignTypeCode.Routine:
                    varClass = Builder.Routine.BaseClass;
                    break;
                //Переменная-модель
                case DesignTypeCode.Model:
                    varClass = Builder.Model.ModelClass;
                    break;
            }

            //Объявляем графовую переменную
            CodeVariableDeclarationStatement varDeclaration = new CodeVariableDeclarationStatement(
                GetTypeString(varClass, designVarType), designVarType.Name);

            resultStatList.Add(varDeclaration);

            //Инициализируем design переменную
            CodeAssignStatement assignStat = new CodeAssignStatement();
            //Инициализация массива ( если нужно )
            CodeMethodInvokeExpression initializeArrayMethod = null;

            //Если это простая переменная
            if (designVarType is DesignVarType)
            {
                assignStat = new CodeAssignStatement(new CodeVariableReferenceExpression(designVarType.Name),
                    new CodeObjectCreateExpression(varClass));
            }
            //Если это массив
            if (designVarType is DesignVarArrayType)
            {
                assignStat = new CodeAssignStatement(new CodeVariableReferenceExpression(designVarType.Name),
                    new CodeSnippetExpression(GetIndexFieldInitialization(varClass,
                    designVarType as DesignVarArrayType)));

                initializeArrayMethod = new CodeMethodInvokeExpression();
                initializeArrayMethod.Method = new CodeMethodReferenceExpression(
                    new CodeVariableReferenceExpression(Builder.Common.ArrayInitializing.InitializingClass),
                    Builder.Common.ArrayInitializing.InitializingMethod);

                initializeArrayMethod.Parameters.Add(new CodeArgumentReferenceExpression(designVarType.Name));

                //Создаем объект, которым будет инициализироваться массив
                CodeObjectCreateExpression createStat = new CodeObjectCreateExpression();
                createStat.CreateType = new CodeTypeReference(varClass);
                initializeArrayMethod.Parameters.Add(createStat);
            }
            
            resultStatList.Add(assignStat);
            
            if (initializeArrayMethod != null)
                resultStatList.Add(initializeArrayMethod);

            return resultStatList;
        }

        /// <summary>
        /// Добавить объявления переменных
        /// </summary>
        /// <param name="varTypeList">Список типов переменных</param>
        public void AddVarDefinition( List<IExprType> varTypeList )
            {
            foreach ( IExprType varType in varTypeList )
                AddVarDefinition( varType );
            }

        /// <summary>
        /// Добавить объявления переменных c инициализацией
        /// </summary>
        /// <param name="dict">словарь тип->код инициализации</param>
        public void AddVarDefinition(Dictionary<IExprType, CodeExpression> dict)
        {
            foreach (KeyValuePair<IExprType, CodeExpression> pair in dict)
            {
                AddVarDefinition(pair.Key, pair.Value);
            }
        }


        /// <summary>
        /// Сгенерировать инициализацию для массива
        /// </summary>
        /// <param name="baseTypeString">Базовый тип массива</param>
        /// <param name="indexType">Информация о массива</param>
        /// <returns></returns>
        protected static string GetIndexFieldInitialization( string baseTypeString, IndexedType indexType )
            {          
            //Инициализация массива
            string initStringCode = "new " + baseTypeString + " [";

            int index = 0;
            foreach ( int maxIndexValue in indexType )
                {
                if ( index != 0 )
                    initStringCode += ",";
                initStringCode += maxIndexValue.ToString();
                index++;
                }

            initStringCode += "]";

            return initStringCode;
            }


        /// <summary>
        /// Сгенерировать инициализацию переменной-множества
        /// </summary>
        /// <returns></returns>
        protected string GetSetFieldInitialization()
            {
            return "new " + Builder.Common.SetClassName + "()";
            }
        

        /// <summary>
        /// Получить строковую запись базового типа переменной (без индексов в массивах)
        /// </summary>
        /// <param name="varType">Тип переменной</param>
        /// <returns></returns>
        public static string GetBaseTypeString( IExprType varType )
            {
            string typeStringCode;

            //Если это множество
            if ( varType is SetType )
                typeStringCode = Builder.Common.SetClassName;
            //Если это обычная переменная
            else
                {
                switch ( varType.Code )
                    {
                    case TypeCode.Bit:
                        typeStringCode = "Int64";
                        break;
                    case TypeCode.Boolean:
                        typeStringCode = "Boolean";
                        break;
                    case TypeCode.Char:
                        typeStringCode = "Char";
                        break;
                    case TypeCode.Integer:
                        typeStringCode = "Int32";
                        break;
                    case TypeCode.Real:
                        typeStringCode = "Double";
                        break;
                    case TypeCode.String:
                        typeStringCode = "String";
                        break;
                    case TypeCode.UndefinedType:
                        typeStringCode = "Object";
                        break;
                    //by jum
                    case TypeCode.Node:
                        typeStringCode = Builder.Common.NodeClassName;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException( "Неизвестный тип переменной" );
                    }
                }

            return typeStringCode;
            }


        /// <summary>
        /// Получить строковое представление типа переменной (возможно с индексами)
        /// </summary>
        /// <param name="baseTypeString">Базовый тип переменной (без индексов)</param>
        /// <param name="varType">Тип переменной</param>
        /// <returns></returns>
        public static string GetTypeString( string baseTypeString, ICommonType varType )
            {
            string resultStringCode = baseTypeString;

            if ( varType is IndexedType )
                {
                resultStringCode += "[";
                for ( int i = 1; i < ( varType as IndexedType ).IndexCount; i++ )
                    {
                    resultStringCode += ",";
                    }
                resultStringCode += "]";
                }

            return resultStringCode;
            }


        /// <summary>
        /// Добавить обычную функцию
        /// </summary>
        /// <param name="methodName">Имя имя метода</param>
        /// <param name="statementList">Список операторов</param>
        public void AddPrivateMethod( string methodName, CodeStatementCollection statementList )
            {
            CodeMemberMethod method = new CodeMemberMethod();
            method.Name = methodName;
            method.Attributes = MemberAttributes.Private | MemberAttributes.Final;
            method.Statements.AddRange( statementList ); 

            this.AddMethod( method );
            }


        /// <summary>
        /// Задать родительский класс
        /// </summary>
        /// <param name="baseClassName">Имя родительского класса</param>
        public void SetBaseClass( string baseClassName )
            {
            //Наследуем от родительского класса
            resultClass.BaseTypes.Add( new CodeTypeReference( baseClassName ) );
            }


        /// <summary>
        /// Добавить метод
        /// </summary>
        /// <param name="method">Описание метода</param>
        public void AddMethod( CodeMemberMethod method )
            {
            resultClass.Members.Add( method );
            }

        
        /// <summary>
        /// Сгенерировать код
        /// </summary>
        public virtual void Build()
            {
            //Если были зарегестрированы ошибки, то генерировать код не надо
            if ( Fabric.Instance.ErrReg.ErrorCount > 0 )
                return;

            CodeFabric.Instance.AddTypeInUnit( resultClass );            
            }


        /// <summary>
        /// Подготовить построитель кода для новой компиляции
        /// </summary>
        public virtual void Reload()
            {
            this.resultClass = new CodeTypeDeclaration();
            this.codeConstructor = null;
            }


        /// <summary>
        /// Итоговый класс
        /// </summary>
        protected CodeTypeDeclaration resultClass = new CodeTypeDeclaration();
        /// <summary>
        /// Конструктор итогового класса (=null, если он не нужен)
        /// </summary>
        protected CodeConstructor codeConstructor = null;
        }
    }

    
