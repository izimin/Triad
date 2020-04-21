using System;
using System.Collections.Generic;
using System.Text;

using TriadCompiler.Parser.Common.Header;
using TriadCompiler.Parser.Common.Statement;

namespace TriadCompiler
    {
    /// <summary>
    /// Парсер модели
    /// </summary>
    internal partial class ModelParser : CommonParser
        {
        /// <summary>
        ///  Строитель кода
        /// </summary>
        protected GraphCodeBuilder codeBuilder
            {
            get
                {
                return Fabric.Instance.Builder as GraphCodeBuilder;
                }
            }


        /// <summary>
        /// Начать разбор
        /// </summary>
        /// <param name="endKey">Множество допустимых конечных символов</param>
        public override void Compile( EndKeyList endKey )
            {
            this.codeBuilder.SetBaseClass( Builder.Model.BaseClass );

            GetNextKey();
            Model( endKey );
            }


        /// <summary>
        /// Описание модели
        /// </summary>
        /// <syntax>Model EndModel</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        private void Model( EndKeyList endKeys )
            {
            if ( currKey != Key.Model )
                {
                err.Register( Err.Parser.WrongStartSymbol.Model, Key.Model );
                SkipTo( endKeys.UniteWith( Key.Model ) );
                }
            if ( currKey == Key.Model )
                {
                Accept( Key.Model );
               
                //Регистрируем стандартные функции (до разбора имени)
                RegisterStandardFuntions();

                //Имя модели
                HeaderName.Parse( endKeys.UniteWith( Key.LeftBracket, Key.Structure, Key.Routine,
                    Key.Include, Key.Define, Key.EndModel ), delegate( string headerName )
                        {
                            this.designTypeName = headerName;
                            CommonArea.Instance.Register( new DesignTypeType( headerName, DesignTypeCode.Model ) ); 
                        } );

                //Создаем класс, представляющий объект
                Fabric.Instance.Builder.SetClassName( designTypeName );

                //Параметры модели
                List<IExprType> varTypeList = ParameterSection.Parse( endKeys.UniteWith( Key.Structure, Key.Routine, Key.Include,
                    Key.Define, Key.EndModel ), VarDeclarationContext.Common );

                foreach ( IExprType varType in varTypeList )
                    {
                    //Добавляем эту переменную в параметры конструктору
                    Fabric.Instance.Builder.AddParameterInConstructor( varType, varType.Name );
                    //Объявляем переменную внутри класса
                    Fabric.Instance.Builder.AddVarDefinition( varType );
                    }

                //Список допустимых подключаемых типов
                List<Key> allowedTypeList = new List<Key>();
                allowedTypeList.Add( Key.Structure );
                allowedTypeList.Add( Key.Routine );

                //Объявления структур и рутин
                while ( currKey == Key.Structure || currKey == Key.Routine || currKey == Key.Include )
                    {
                    //Сохраняем текущий парсер и кодостроитель
                    CommonParser currParser = Fabric.Instance.Parser;
                    CodeBuilder currBuilder = Fabric.Instance.Builder;

                    //Объявление структуры
                    if ( currKey == Key.Structure )
                        {  
                        Fabric.Instance.Parser = new StructureParser();
                        Fabric.Instance.Builder = new GraphCodeBuilder();
                        }
                    //Объявление рутины
                    else if ( currKey == Key.Routine )
                        {
                        Fabric.Instance.Parser = new RoutineParser();
                        Fabric.Instance.Builder = new RoutineCodeBuilder();
                        }
                    //Секция подключений
                    else if ( currKey == Key.Include )
                        {
                        IncludeSection.Parse( endKeys.UniteWith( Key.Include, Key.Structure, Key.Routine, Key.Define, Key.EndModel ), allowedTypeList );
                        continue;
                        }

                    //Сохраняем контекст
                    Fabric.Instance.Scanner.SaveSymbol( currSymbol );
                    Fabric.Instance.Parser.Compile( endKeys.UniteWith( Key.Include, Key.Structure, Key.Routine, Key.Define, Key.EndModel ) );
                    Fabric.Instance.Builder.Build();

                    //Восстанавливаем контекст
                    Fabric.Instance.Scanner.SaveSymbol( Fabric.Instance.Parser.CurrentSymbol );
                    Fabric.Instance.Parser = currParser;
                    Fabric.Instance.Builder = currBuilder;
                    GetNextKey();
                    }

                Accept( Key.Define );

                //Добавляем область видимости
                varArea.AddArea();

                //Добавляем одноименную с моделью дизайн-переменную
                DesignVarType designVarType = new DesignVarType( this.designTypeName, DesignTypeCode.Structure );
                CommonArea.Instance.Register( designVarType );
                codeBuilder.AddBuildStatementList(TriadCompiler.CodeBuilder.GetDesignVarDefinitionStatements(designVarType));

                codeBuilder.AddBuildStatementList( StatementList.Parse( endKeys.UniteWith( Key.EndModel ), StatementContext.Common ) );

                Accept( Key.EndModel );

                //Убираем область видимости
                varArea.RemoveArea();

                if ( !endKeys.Contains( currKey ) )
                    {
                    err.Register( Err.Parser.WrongEndSymbol.Model, endKeys.GetLastKeys() );
                    SkipTo( endKeys );
                    }
                }
            }


        }
    }
