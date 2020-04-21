using System;
using System.Collections.Generic;
using System.Text;

using TriadCompiler.Parser.Common.Declaration.Var;

namespace TriadCompiler.Parser.Common.Declaration.Polus
    {
    /// <summary>
    /// Разбор объявления полюсов
    /// </summary>
    internal class PolusDeclaration : CommonParser
        {
        /// <summary>
        /// Множество стартовых символов объявления полюса
        /// </summary>
        private static List<Key> startKeys = null;


        /// <summary>
        /// Стартовые символы объявления полюса
        /// </summary>
        public static List<Key> StartKeys
            {
            get
                {
                if ( startKeys == null )
                    {
                    Key[] keySet = { Key.Identificator, Key.InOut, Key.Input, Key.Output };

                    startKeys = new List<Key>( keySet );
                    }
                return startKeys;
                }
            }

        /// <summary>
        /// Объявление полюсов
        /// </summary>
        /// <syntax>Input | Output | InOut PolusNameInDeclaration {,PolusNameInDeclaration}</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <param name="isSpyObject">Признак spy-объекта</param>
        /// <returns>Список типов объявленных полюсов</returns>
        public static List<IPolusType> Parse( EndKeyList endKeys, bool isSpyObject )
            {
            List<IPolusType> polusTypeList = new List<IPolusType>();

            if ( !StartKeys.Contains( currKey ) )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongStartSymbol.PolusDeclaration, StartKeys );
                SkipTo( endKeys.UniteWith( StartKeys ) );
                }
            if ( StartKeys.Contains( currKey ) )
                {
                bool isInput = true;
                bool isOutput = true;

                //Входной полюс
                if ( currKey == Key.Input )
                    {
                    GetNextKey();

                    isInput = true;
                    isOutput = false;
                    }
                //Выходной полюс
                else if ( currKey == Key.Output )
                    {
                    GetNextKey();
                    
                    isInput = false;
                    isOutput = true;
                    }
                //Универсальный полюс
                else if ( currKey == Key.InOut )
                    {
                    GetNextKey();

                    isInput = true;
                    isOutput = true;
                    }
                else
                    {
                    //Если ничего не указано, то используется как у Polus
                    }

                //Имя полюса
                IPolusType polusType = PolusName( endKeys.UniteWith( Key.Comma ), isInput, isOutput );
                polusType.IsSpyObject = isSpyObject;
                polusTypeList.Add( polusType );

                while ( currKey == Key.Comma )
                    {
                    GetNextKey();

                    //Имя полюса
                    polusType = PolusName( endKeys.UniteWith( Key.Comma ), isInput, isOutput );
                    polusType.IsSpyObject = isSpyObject;
                    polusTypeList.Add( polusType );
                    }
                }
            return polusTypeList;
            }


        /// <summary>
        /// Имя полюса
        /// </summary>
        /// <syntax>Identificator # RangeDeclaration #</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <param name="isInput">Это входной полюс</param>
        /// <param name="isOutput">Это выходной полюс</param>
        /// <returns>Тип полюса</returns>
        private static IPolusType PolusName( EndKeyList endKeys, bool isInput, bool isOutput )
            {
            IPolusType polusType = new PolusType( isInput, isOutput );

            if ( currKey != Key.Identificator )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongStartSymbol.PolusDeclarationName, Key.Identificator );
                SkipTo( endKeys.UniteWith( Key.Identificator ) );
                }
            if ( currKey == Key.Identificator )
                {
                //Имя полюса
                string polusName = ( currSymbol as IdentSymbol ).Name;
                polusType.Name = polusName;

                Accept( Key.Identificator );

                //Если это индексированный полюс
                if ( currKey == Key.LeftBracket )
                    {
                    PolusArrayType polusArrayType = new PolusArrayType( polusType.IsInput, polusType.IsOutput );
                    polusArrayType.Name = polusName;

                    TypeDeclaration.RangeDeclaration( endKeys.UniteWith( Key.RightBracket ), polusArrayType );
                    polusType = polusArrayType;
                    }

                if ( polusName != string.Empty )
                    {
                    CommonArea.Instance.Register( polusType );
                    }

                if ( !endKeys.Contains( currKey ) )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.PolusDeclarationName, endKeys.GetLastKeys() );
                    SkipTo( endKeys );
                    }
                }

            return polusType;
            }


        }
    }
