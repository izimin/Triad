using System;
using System.CodeDom;
using System.Collections.Generic;

using TriadCompiler.Parser.Common.Header;
using TriadCompiler.Parser.Common.Statement;

namespace TriadCompiler
    {
    /// <summary>
    /// Класс, отвечающий за разбор рутин
    /// </summary>
    internal partial class RoutineParser : CommonParser
        {
        /// <summary>
        /// Строитель кода
        /// </summary>
        private RoutineCodeBuilder codeBuilder
            {
            get
                {
                return Fabric.Instance.Builder as RoutineCodeBuilder;
                }
            }

        
        /// <summary>
        /// Начать разбор и генерацию кода
        /// </summary>
        /// <param name="endKey">Множество допустимых конечных символов</param>
        public override void Compile( EndKeyList endKey )
            {
            if ( !( Fabric.Instance.Builder is RoutineCodeBuilder ) )
                throw new InvalidOperationException( "Недопустимый генератор кода" );

            this.codeBuilder.SetBaseClass( Builder.Routine.BaseClass );

            GetNextKey();

            designTypeInfo = new RoutineInfo();

            Routine( endKey );
            }


        /// <summary>
        /// Рутина
        /// </summary>
        /// <syntax>Routine Identificator { [ ParameterList ]( Interface ) } { InitialPart } 
        /// EventPart { EventPart } EndRoutine</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        private void Routine( EndKeyList endKeys )
            {
            if ( currKey != Key.Routine )
                {
                err.Register( Err.Parser.WrongStartSymbol.Routine, Key.Routine );
                SkipTo( endKeys.UniteWith( Key.Routine ) );
                }
            if ( currKey == Key.Routine )
                {
                Accept( Key.Routine );

                //Тип рутины
                DesignTypeType designTypeType = null;

                //Имя рутины
                HeaderName.Parse( endKeys.UniteWith( Key.LeftPar, Key.LeftBracket, Key.Initial,
                    Key.Event, Key.EndRoutine ), delegate( string headerName )
                        {
                            designTypeType = new DesignTypeType( headerName, DesignTypeCode.Routine );
                            CommonArea.Instance.Register( designTypeType );
                        } );

                if (designTypeType == null)
                    return;

                this.designTypeName = designTypeType.Name;
                
                //Создаем класс, представляющий объект
                Fabric.Instance.Builder.SetClassName( designTypeName );

                //Новая область видимости
                varArea.AddArea();
                //Регистрируем стандартные функции
                RegisterStandardFuntions();

                //Добавляем переменную SystemTime
                VarType varType = new VarType( TypeCode.Real );
                varType.Name = Builder.Routine.SystemTime;
                varArea.Register( varType );


                //Заголовок
                List<IExprType> parameters = Header.Parse(endKeys.UniteWith(Key.Initial, Key.Event, Key.EndRoutine));
                designTypeType.AddParameterList(parameters);

                (designTypeInfo as RoutineInfo).Parameters.AddRange(parameters);

                //Секция инициализации
                if ( currKey == Key.Initial )
                    {
                    InitialPart( endKeys.UniteWith( Key.Initial, Key.Event, Key.EndRoutine ) );
                    }

                //Очищаем список обращений к событиям
                EventArea.Instance.ClearEventCallList();

                //События			
                while ( currKey == Key.Event )
                    {
                    EventPart( endKeys.UniteWith( Key.Event, Key.EndRoutine ) );
                    }

                //Проверка, все ли события были описаны
                EventArea.Instance.CheckEventDefinitions();
                
                //Убираем область видимости
                varArea.RemoveArea();
                
                Accept( Key.EndRoutine );

                if ( !endKeys.Contains( currKey ) )
                    {
                    err.Register( Err.Parser.WrongEndSymbol.Routine, endKeys.GetLastKeys() );
                    SkipTo( endKeys );
                    }
                }
            }


        /// <summary>
        /// Начальные условия
        /// </summary>
        /// <syntax>Initial StatementList EndInitial</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        private void InitialPart( EndKeyList endKeys )
            {
            Accept( Key.Initial );
            codeBuilder.SetInitialSection( StatementList.Parse( endKeys.UniteWith( Key.EndInitial ), StatementContext.Initial ) );
            Accept( Key.EndInitial );

            if ( !endKeys.Contains( currKey ) )
                {
                err.Register( Err.Parser.WrongEndSymbol.InitialPart, endKeys.GetLastKeys() );
                SkipTo( endKeys );
                }
            }


        /// <summary>
        /// Описание события
        /// </summary>
        /// <syntax>Event [Identificator]; StatementList EndEvent</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        private void EventPart( EndKeyList endKeys )
            {
            CodeStatementCollection statList = new CodeStatementCollection();
            StatementContext context;
            string eventNameStr;

            Accept( Key.Event );

            eventNameStr = EventName( endKeys.UniteWith( Key.Semicolon ), out context );

            //Если это событие приема сообщений
            if ( context == StatementContext.MessageEvent )
                {
                //Добавление области для переменной message
                varArea.AddArea();

                //Регистрируем переменную message
                VarType messageVarType = new VarType( TypeCode.String );
                messageVarType.Name = Builder.Routine.Receive.ReceivedMessage;
                varArea.Register( messageVarType );

                //Регистрируем переменную polusIndex
                VarType polusIndexVarType = new VarType( TypeCode.Integer );
                polusIndexVarType.Name = Builder.Routine.Receive.PolusIndex;
                varArea.Register( polusIndexVarType );

                //Добавляем код объявления и инициализации переменной polusIndex
                CodeVariableDeclarationStatement fieldCode = new CodeVariableDeclarationStatement();
                fieldCode.Name = Builder.Routine.Receive.PolusIndex;
                fieldCode.Type = new CodeTypeReference( "Int32" );

                CodeMethodInvokeExpression getIndexMethod = new CodeMethodInvokeExpression();
                getIndexMethod.Method.MethodName = Builder.Routine.Receive.GetPolusIndexMethod;
                getIndexMethod.Parameters.Add( new CodeArgumentReferenceExpression( Builder.Routine.Receive.ReceivedPolus ) );

                fieldCode.InitExpression = getIndexMethod;
                statList.Add( fieldCode );
                }

            Accept( Key.Semicolon );
            statList.AddRange( StatementList.Parse( endKeys.UniteWith( Key.EndEvent ), context ) );

            //Если это событие приема сообщений
            if ( context == StatementContext.MessageEvent )
                {
                //Удаление области видимости
                varArea.RemoveArea();

                //Генерация события обработки входных сообщений
                codeBuilder.SetMessageHandlingEvent( statList );
                }
            else
                {
                //Генерация обычного события
                codeBuilder.AddPrivateMethod( eventNameStr, statList );
                (designTypeInfo as RoutineInfo).Events.Add(eventNameStr); //by jum 11.04.10
                }

            Accept( Key.EndEvent );

            if ( !endKeys.Contains( currKey ) )
                {
                err.Register( Err.Parser.WrongEndSymbol.Event, endKeys.GetLastKeys() );
                SkipTo( endKeys );
                }
            }


        /// <summary>
        /// Имя события
        /// </summary>
        /// <syntax>Identificator | ПУСТО</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <param name="context">Текущий контекст</param>
        /// <returns>Имя события 
        /// "" - если событие неименованное
        /// null - если была ошибка</returns>
        private string EventName( EndKeyList endKeys, out StatementContext context )
            {
            string eventName = "";
            context = StatementContext.Common;

            if ( currKey != Key.Identificator && currKey != Key.Semicolon )
                {
                err.Register( Err.Parser.WrongStartSymbol.EventDeclarationName, Key.Identificator, Key.Semicolon );
                SkipTo( endKeys.UniteWith( Key.Identificator, Key.Semicolon ) );
                }
            if ( currKey == Key.Identificator || currKey == Key.Semicolon )
                {
                //Именованное событие
                if ( currKey == Key.Identificator )
                    {
                    EventArea.Instance.RegisterEvent( ( currSymbol as IdentSymbol ).Name );
                    eventName = ( currSymbol as IdentSymbol ).Name;
                    GetNextKey();
                    }
                //Неименованное событие
                else if ( currKey == Key.Semicolon )
                    {
                    EventArea.Instance.RegisterEvent( "" );
                    context = StatementContext.MessageEvent;
                    }

                if ( !endKeys.Contains( currKey ) )
                    {
                    err.Register( Err.Parser.WrongEndSymbol.EventDeclarationName, endKeys.GetLastKeys() );
                    SkipTo( endKeys );
                    }
                }

            return eventName;
            }

        }

    public class RoutineInfo : DesignTypeInfo
    {
        public List<IPolusType> Poluses = new List<IPolusType>();
        public List<IExprType> Variables = new List<IExprType>();
        public List<String> Events = new List<string>();
        public List<IExprType> Parameters = new List<IExprType>();
    }
}
