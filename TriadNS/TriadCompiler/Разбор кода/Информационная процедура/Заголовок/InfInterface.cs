using System;
using System.Collections.Generic;
using System.Text;

using TriadCompiler.Parser.Common.Declaration.Var;
using TriadCompiler.Parser.Common.Declaration.Polus;
using TriadCompiler.Parser.Common.Declaration.Event;

namespace TriadCompiler.Parser.InfProcedure.Header
    {
    /// <summary>
    /// Разбор интерфейса ИП
    /// </summary>
    internal class InfInterface : CommonParser
        {
        /// <summary>
        /// Стартовые символы объявления объекта слежения
        /// </summary>
        private static List<Key> spyDeclarationStartKeys = null;

        /// <summary>
        /// Стартовые символы объявления объекта слежения
        /// </summary>
        private static List<Key> SpyDeclarationStartKeys
            {
            get
                {
                if ( spyDeclarationStartKeys == null )
                    {
                    spyDeclarationStartKeys = new List<Key>();

                    spyDeclarationStartKeys.Add( Key.In );
                    spyDeclarationStartKeys.Add( Key.Passive );
                    spyDeclarationStartKeys.Add( Key.Polus );
                    spyDeclarationStartKeys.Add( Key.Event );
                    }

                return spyDeclarationStartKeys;
                }
            }


        /// <summary>
        /// Интерфейс
        /// </summary>
        /// <syntax>SingleInterface {SingleInterface}</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <returns>Список типов объектов слежения</returns>
        public static List<ISpyType> Parse( EndKeyList endKeys )
            {
            List<ISpyType> spyObjectTypeList = new List<ISpyType>();

            do
                spyObjectTypeList.AddRange( SingleInterface( endKeys.UniteWith( Key.LeftPar ) ) );
            while ( currKey == Key.LeftPar );

            return spyObjectTypeList;
            }


        /// <summary>
        /// Отдельный интерфейс
        /// </summary>
        /// <syntax> ( NextDeclaration {; NextDeclaration} )</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <returns>Список типов объектов слежения</returns>
        private static List<ISpyType> SingleInterface( EndKeyList endKeys )
            {
            List<ISpyType> spyObjectTypeList = new List<ISpyType>();

            if ( currKey == Key.LeftPar )
                {
                GetNextKey();

                spyObjectTypeList.AddRange( SingleDeclaration( endKeys.UniteWith( Key.Semicolon, Key.RightPar ) ) );
                while ( currKey == Key.Semicolon )
                    {
                    GetNextKey();
                    spyObjectTypeList.AddRange( SingleDeclaration( endKeys.UniteWith( Key.Semicolon, Key.RightPar ) ) );
                    }

                Accept( Key.RightPar );
                }

            if ( !endKeys.Contains( currKey ) )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.SingleHeader, endKeys.GetLastKeys() );
                SkipTo( endKeys );
                }

            return spyObjectTypeList;
            }


        /// <summary>
        /// Разбор параметра в интерфейсе 
        /// </summary>
        /// <param name="endKey">Множество допустимых конечных символов</param>
        /// <returns>Список типов spy-объектов</returns>
        private static List<ISpyType> SingleDeclaration( EndKeyList endKey )
            {
            List<ISpyType> spyObjectTypeList = new List<ISpyType>();

            if ( !SpyDeclarationStartKeys.Contains( currKey ) )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongStartSymbol.SpyObjectDeclaration, SpyDeclarationStartKeys );
                SkipTo( endKey.UniteWith( SpyDeclarationStartKeys ) );
                }
            if ( SpyDeclarationStartKeys.Contains( currKey ) )
                {
                //Активное слежение за переменной
                if ( currKey == Key.In )
                    {
                    GetNextKey();

                    List<IExprType> varTypeList = VarDeclaration.Parse( endKey, VarDeclarationContext.SpyObjectList );

                    foreach ( IExprType varType in varTypeList )
                        {
                        codeBuilder.AddSpyObject( varType );
                        codeBuilder.AddSpyHandler( varType );
                        
                        spyObjectTypeList.Add( varType );
                        }
                    }
                //Пассивное слежение за переменной
                else if ( currKey == Key.Passive )
                    {
                    GetNextKey();

                    List<IExprType> varTypeList = VarDeclaration.Parse( endKey, VarDeclarationContext.SpyObjectList );

                    foreach ( IExprType varType in varTypeList )
                        {
                        codeBuilder.AddSpyObject( varType );
                        //Для passive переменных обработчик регистрировать не надо

                        spyObjectTypeList.Add( varType );
                        }
                    }
                //Слежение за событием
                else if ( currKey == Key.Event )
                    {
                    GetNextKey();

                    List<EventType> eventTypeList = EventDeclaration.Parse( endKey, true );

                    foreach ( EventType eventType in eventTypeList )
                        {
                        codeBuilder.AddSpyObject( eventType );
                        codeBuilder.AddSpyHandler( eventType );

                        spyObjectTypeList.Add( eventType );
                        }
                    }
                //Слежение за полюсом
                else if ( currKey == Key.Polus )
                    {
                    GetNextKey();

                    List<IPolusType> polusTypeList = PolusDeclaration.Parse( endKey, true );

                    foreach ( IPolusType polusType in polusTypeList )
                        {
                        codeBuilder.AddSpyObject( polusType );
                        codeBuilder.AddSpyHandler( polusType );

                        spyObjectTypeList.Add( polusType );
                        }
                    }
                }

            return spyObjectTypeList;
            }


        /// <summary>
        /// Строитель кода
        /// </summary>
        protected static IProcedureCodeBuilder codeBuilder
            {
            get
                {
                return Fabric.Instance.Builder as IProcedureCodeBuilder;
                }
            }

        }
    }
