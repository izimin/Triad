using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler.Parser.Common.Declaration.Event
    {
    internal class EventDeclaration : CommonParser
        {
        /// <summary>
        /// Объявление событий
        /// </summary>
        /// <syntax>Identificator {,Identificator}</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <param name="isSpyObject">Признак spy-объектов</param>
        /// <returns>Список типов объявленных событий</returns>
        public static List<EventType> Parse( EndKeyList endKeys, bool isSpyObject )
            {
            List<EventType> eventList = new List<EventType>();

            //Имя события
            eventList.Add( EventName( endKeys.UniteWith( Key.Comma ), isSpyObject ) );

            while ( currKey == Key.Comma )
                {
                GetNextKey();

                //Имя события
                eventList.Add( EventName( endKeys.UniteWith( Key.Comma ), isSpyObject ) );
                }

            return eventList;
            }


        /// <summary>
        /// Разбор имени события в объявлении
        /// </summary>
        /// <param name="endKeys">Допустимые конечные символы</param>
        /// <param name="isSpyObject">Признак spy-объекта</param>
        /// <returns>Тип события</returns>
        private static EventType EventName( EndKeyList endKeys, bool isSpyObject )
            {
            //Тип события
            EventType resultType = null;

            if ( currKey != Key.Identificator )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongStartSymbol.EventDeclarationName, Key.Identificator );
                SkipTo( endKeys.UniteWith( Key.Identificator ) );
                }
            if ( currKey == Key.Identificator )
                {
                string eventName = ( currSymbol as IdentSymbol ).Name;

                //Тип события
                resultType = new EventType( eventName );
                resultType.IsSpyObject = isSpyObject;

                //Регистрируем событие
                CommonArea.Instance.Register( resultType );
                
                GetNextKey();

                if ( !endKeys.Contains( currKey ) )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.EventDeclarationName, endKeys.GetLastKeys() );
                    SkipTo( endKeys );
                    }
                }
            return resultType;
            }

        }
    }
