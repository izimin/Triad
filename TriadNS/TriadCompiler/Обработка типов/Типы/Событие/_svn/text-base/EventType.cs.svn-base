using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Тип, описывающий событие
    /// </summary>
    public class EventType : ISpyType
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="eventName">Имя события</param>
        public EventType( string eventName )
            {
            this.eventName = eventName;
            }


        /// <summary>
        /// Имя события
        /// </summary>
        public string Name
            {
            get
                {
                return this.eventName;
                }
            set
                {
                this.eventName = value;
                }
            }


        /// <summary>
        /// Признак spy-объекта
        /// </summary>
        public bool IsSpyObject
            {
            get { return isSpyObject; }
            set { isSpyObject = value; }
            }


        /// <summary>
        /// Имя события
        /// </summary>
        private string eventName = string.Empty;
        /// <summary>
        /// Признак spy-объекта
        /// </summary>
        private bool isSpyObject = false;
        }
    }
