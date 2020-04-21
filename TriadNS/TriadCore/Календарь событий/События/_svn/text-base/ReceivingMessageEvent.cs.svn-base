using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Событие получения сообщения
    /// </summary>
    class ReceivingMessageEvent : CommonEvent
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="executionTime">Время срабатывания события</param>
        /// <param name="routine">Рутина, на которой происходит событие</param>
        /// <param name="routinePolusName">Имя полюса рутины, принявшего сообщение</param>
        /// <param name="nodePolusName">Имя полюса вершины, принявшего сообщение</param>
        /// <param name="message">Посланное сообщение</param>
        public ReceivingMessageEvent( double executionTime, Routine routine, CoreName routinePolusName, CoreName nodePolusName, string message )
            : base( executionTime, routine )
            {
            this.routinePolusName = routinePolusName;
            this.nodePolusName = nodePolusName;
            this.message = message;
            }


        /// <summary>
        /// Вызвать обработчик события
        /// </summary>
        public override void ExecuteAllEventHandlers()
            {
            if ( this.OnEventFunction != null )
                {
                this.OnEventFunction( this.routinePolusName, this.nodePolusName, this.message, this.EventSpyHandler );
                }
            }


        /// <summary>
        /// Зарегистрированные обработчики события
        /// </summary>
        public ReceivingMessageEventHandler OnEventFunction = null;
        /// <summary>
        /// Имя полюса рутины, принявшего сообщение
        /// </summary>
        private CoreName routinePolusName;
        /// <summary>
        /// Имя полюса вершины, принявшего сообщение
        /// </summary>
        private CoreName nodePolusName;
        /// <summary>
        /// Посланное сообщение
        /// </summary>
        private string message;
        }
    }
