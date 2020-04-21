using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler.Parser.Common.Header
    {
    /// <summary>
    /// Имя объекта в заголовке
    /// </summary>
    internal class HeaderName : CommonParser
        {
        /// <summary>
        /// Функция, регистрирующая тип
        /// </summary>
        /// <param name="headerName">Имя в заголовке</param>
        public delegate void RegisterTypeFunction( string headerName );


        /// <summary>
        /// Разобрать имя объекта в заголовке
        /// </summary>
        /// <syntax>Identificator</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <param name="registerType">Функция, регистрирующая тип</param>
        /// <returns>Разобранное имя</returns>
        public static void Parse( EndKeyList endKeys, RegisterTypeFunction registerType )
            {
            if ( currKey != Key.Identificator )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongStartSymbol.HeaderName, Key.Identificator );
                SkipTo( endKeys.UniteWith( Key.Identificator ) );
                }
            if ( currKey == Key.Identificator )
                {
                registerType( ( currSymbol as IdentSymbol ).Name );

                Accept( Key.Identificator );

                if ( !endKeys.Contains( currKey ) )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.HeaderName, endKeys.GetLastKeys() );
                    SkipTo( endKeys );
                    }
                }
            }

        }
    }
