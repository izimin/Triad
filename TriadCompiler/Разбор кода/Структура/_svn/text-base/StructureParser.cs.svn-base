using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Header;
using TriadCompiler.Parser.Common.Statement;

namespace TriadCompiler
    {
    /// <summary>
    /// Класс для разбора структур
    /// </summary>
    internal partial class StructureParser : CommonParser
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
            this.codeBuilder.SetBaseClass( Builder.Structure.BaseClass );

            GetNextKey();
            Structure( endKey );
            }


        /// <summary>
        /// Объявление структуры
        /// </summary>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <syntax>Structure Identificator Define StatementList EndStructure</syntax>
        private void Structure( EndKeyList endKeys )
            {
            if ( currKey != Key.Structure )
                {
                err.Register( Err.Parser.WrongStartSymbol.Structure, Key.Structure );
                SkipTo( endKeys.UniteWith( Key.Structure ) );
                }
            if ( currKey == Key.Structure )
                {
                Accept( Key.Structure );

                //Тип структуры
                DesignTypeType designTypeType = null;

                //Имя структуры
                HeaderName.Parse( endKeys.UniteWith( Key.LeftPar, Key.LeftBracket, Key.Include, Key.Define,
                    Key.EndStructure ), delegate( string headerName )
                        {
                            designTypeType = new DesignTypeType( headerName, DesignTypeCode.Structure );
                            CommonArea.Instance.Register( designTypeType );
                        } );
                
                this.designTypeName = designTypeType.Name;

                //Создаем класс, представляющий объект
                Fabric.Instance.Builder.SetClassName( designTypeName );

                //Добавляем область видимости
                varArea.AddArea();
                //Регистрируем стандартные функции
                RegisterStandardFuntions();

                //Добавляем одноименную с моделью дизайн-переменную
                DesignVarType designVarType = new DesignVarType( this.designTypeName, DesignTypeCode.Structure );
                CommonArea.Instance.Register( designVarType );
                codeBuilder.AddBuildStatementList(TriadCompiler.CodeBuilder.GetDesignVarDefinitionStatements(designVarType));

                //Заголовок
                designTypeType.AddParameterList( Header.Parse( endKeys.UniteWith( Key.Include, Key.Define, Key.EndStructure ) ) );
                
                //Список допустимых подкючаемых типов
                List<Key> allowedTypeList = new List<Key>();
                allowedTypeList.Add( Key.Structure );

                //Секция подключений
                IncludeSection.Parse( endKeys.UniteWith( Key.Define, Key.EndStructure ), allowedTypeList );

                Accept( Key.Define );

                codeBuilder.AddBuildStatementList( StatementList.Parse( endKeys.UniteWith( Key.EndStructure ), StatementContext.Common ) );

                //Убираем область видимости
                varArea.RemoveArea();

                Accept( Key.EndStructure );

                if ( !endKeys.Contains( currKey ) )
                    {
                    err.Register( Err.Parser.WrongEndSymbol.Structure, endKeys.GetLastKeys() );
                    SkipTo( endKeys );
                    }
                }
            }


        
        }
    }