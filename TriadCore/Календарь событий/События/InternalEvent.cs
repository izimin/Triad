using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Внутреннее событие рутины
    /// </summary>
    class InternalEvent : CommonEvent
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="executionTime">Время срабатывания события</param>
        /// <param name="routine">Рутина, на которой происходит событие</param>
        public InternalEvent( double executionTime, Routine routine )
            : base( executionTime, routine )
            {
            }


        /// <summary>
        /// Вызвать обработчик события
        /// </summary>
        public override void ExecuteAllEventHandlers()
            {
            //Вызываем функции в рутине, описывающие события
            if ( this.EventHandler != null )
                {
                this.EventHandler();
                }
            //Вызываем информационные процедуры, следящие за событием
            if ( this.EventSpyHandler != null )
                {
                this.EventSpyHandler( new SpyEvent( new CoreName( this.EventHandler.Method.Name ), this.routine ),
                    this.ExecutionTime );
                }
            }

        /// <summary>
        /// Зарегистрированные обработчики события
        /// </summary>
        public InternalEventHandler EventHandler = null;
        }
    }
