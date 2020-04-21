using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Обработчик области видимости событий
    /// </summary>
    internal class EventArea
        {
        /// <summary>
        /// Экземпляр
        /// </summary>
        private static EventArea instance = null;


        /// <summary>
        /// Закрытый конструктор
        /// </summary>
        private EventArea()
            {
            }


        /// <summary>
        /// Экземпляр класса
        /// </summary>
        public static EventArea Instance
            {
            get
                {
                if ( instance == null )
                    instance = new EventArea();
                return instance;
                }
            }


        /// <summary>
        /// Очистить множество зарегистрированных обращений к событиям
        /// </summary>
        public void ClearEventCallList()
            {
            this.eventCallList.Clear();
            }


        /// <summary>
        /// Зарегистрировать событие
        /// </summary>
        /// <param name="eventName">Имя события</param>
        public void RegisterEvent( string eventName )
            {
            CommonArea.Instance.Register( new EventType( eventName ) );
            }


        /// <summary>
        /// Зафиксировать обращение к событию
        /// </summary>
        /// <param name="eventName">Имя события</param>
        public void RegisterEventReference( string eventName )
            {
            if ( !eventCallList.Contains( eventName ) )
                {
                eventCallList.Add( eventName );
                }
            }


        /// <summary>
        /// Проверить, все ли события зафиксированные в RegisterGraphReference были
        /// зарегистрированны через RegisterGraph
        /// </summary>
        public void CheckEventDefinitions()
            {
            for ( int i = 0; i < eventCallList.Count; i++ )
                if ( !CommonArea.Instance.IsEventRegistered( eventCallList[ i ] ) )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.Usage.NotDeclared, eventCallList[ i ].ToString() );
                    }
            }
        
        /// <summary>
        /// Список зафиксированных имен событий
        /// </summary>
        private List<string> eventCallList = new List<string>();
        }
    }
