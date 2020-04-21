using System;
using System.Collections.Generic;
using System.Text;

using TriadCompiler.Parser.Common.Expr;
using TriadCompiler.Code.Generator;

namespace TriadCompiler.Parser.Common.Header
    {
    /// <summary>
    /// Разбор секции подключения внешних модулей
    /// </summary>
    internal class IncludeSection : CommonParser
        {
        /// <summary>
        /// Секция подключения
        /// </summary>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <param name="allowedTypeList">Множество конструкций, которые можно подключать</param>
        /// <syntax>{ IncludeStatement }</syntax>
        public static void Parse( EndKeyList endKeys, List<Key> allowedTypeList )
            {
            while ( currKey == Key.Include )
                {
                Accept( Key.Include );
                IncludeStatement( endKeys.UniteWith( Key.Include ), allowedTypeList );
                }
            }


        /// <summary>
        /// Оператор подкючения
        /// </summary>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <param name="allowedTypeList">Множество конструкций, которые можно подключать</param>
        /// <syntax>Structure | Routine | InfProcedure | Model | ModelCondition
        /// Identificator #ParameterList# from String </syntax>
        private static void IncludeStatement( EndKeyList endKeys, List<Key> allowedTypeList )
            {
            if ( !allowedTypeList.Contains( currKey ) )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongStartSymbol.IncludeSection, allowedTypeList );
                SkipTo( endKeys.UniteWith( allowedTypeList ) );
                }
            if ( allowedTypeList.Contains( currKey ) )
                {
                //Подключаемый тип
                DesignTypeType designType = new DesignTypeType( string.Empty, DesignTypeCode.Structure );

                switch ( currKey )
                    {
                    //Подключается структура
                    case Key.Structure:
                        designType.Code = DesignTypeCode.Structure;
                        break;
                    //Подключается рутина
                    case Key.Routine:
                        designType.Code = DesignTypeCode.Routine;
                        break;
                    //Подключается модель
                    case Key.Model:
                        designType.Code = DesignTypeCode.Structure;
                        break;
                    }


                GetNextKey();

                //Тип подключаемого объекта
                DesignTypeType designTypeType = new DesignTypeType( string.Empty, DesignTypeCode.Structure );

                //Имя подкючаемой модельной переменной
                HeaderName.Parse( endKeys.UniteWith( Key.LeftBracket, Key.From, Key.StringValue ),
                    delegate( string headerName )
                        {
                        designTypeType = new DesignTypeType( headerName, designType.Code );
                        CommonArea.Instance.Register( designTypeType ); 
                        } );

                //Регистрируем параметры
                designTypeType.AddParameterList( ParameterSection.Parse( endKeys.UniteWith( Key.From, Key.StringValue ), 
                    VarDeclarationContext.IncludeSection ) );

                Accept( Key.From );

                //Путь к файлу
                ExprInfo exprInfo = Expression.Parse( endKeys );

                //Если это строковое константное выражение
                if ( exprInfo.HasNoError && exprInfo.IsNotIndexed() && exprInfo.IsNotSet() 
                    && exprInfo.IsConstant() && exprInfo.IsString() )
                    {
                    CodeFabric.Instance.AddReference( ( exprInfo.Value as StringValue ).Value );
                    }
                
                if ( !endKeys.Contains( currKey ) )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.IncludeSection, endKeys.GetLastKeys() );
                    SkipTo( endKeys );
                    }
                }
            }        


        }
    }
