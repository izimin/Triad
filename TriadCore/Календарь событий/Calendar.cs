using System;
using System.Collections.Generic;

namespace TriadCore
    {

    /// <summary>
    /// Календарь событий, обеспечивает планирование событий.
    /// </summary>
    public class Calendar
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public Calendar()
        { }

        
        /// <summary>
        /// Текущее системное время
        /// </summary>
        /// <remarks>По умолчанию до старта моделирования время равно 0.
        /// Если изменить системное время, то будут удалены все ранее запланированные события
        /// с временем срабатывания, меньшим, чем новое системное время
        /// Системное время не должно быть отрицательным</remarks>
        public double SystemTime
            {
            get
                {
                return systemTime;
                }
            set
                {
                if ( value >= 0 )
                    systemTime = value;
                else
                    throw new ArgumentOutOfRangeException( "value" );

                while ( eventList.Count != 0 )
                    {
                    if ( eventList[ 0 ].ExecutionTime >= systemTime )
                        break;
                    else
                        eventList.RemoveAt( 0 );
                    }
                }
            }


        /// <summary>
        /// Запланировать событие
        /// </summary>
        /// <remarks>Принимаются только те события, время
        /// которых не меньше текущего системного. Иначе
        /// будет исключение</remarks>
        /// <param name="ev">Планируемое событие</param>
        public void PlaneEvent( CommonEvent ev )
            {
            if ( ev.ExecutionTime >= systemTime )
                {
                eventList.Add( ev.Clone() );
                eventList.Sort();
                }
            else
                throw new ArgumentException( "Время планируемого события меньше текущего системного времени календаря" );
            }


        /// <summary>
        /// Отменить все события с указанным обработчиком
        /// </summary>
        /// <param name="eventHandler">Обработчик события</param>
        public void CancelEvent( EventHandler eventHandler )
            {
            }



        /// <summary>
        /// Наличие запланированных событий
        /// </summary>
        /// <returns>true, если есть</returns>
        public bool HasEventToExecute
            {
            get
                {
                return ( this.eventList.Count != 0 );
                }
            }


        /// <summary>
        /// Выполнить ближайшее событие
        /// </summary>
        public void DoNextEvent()
            {
            //Если есть событие, которые могут сработать
            if ( eventList.Count != 0 )
                {
                CommonEvent ev = eventList[ 0 ];
                eventList.RemoveAt( 0 );
                SystemTime = ev.ExecutionTime;
                ev.ExecuteAllEventHandlers();
                }
            //Если событий, которые могут сработать нет
            else
                {
                //Ничего не делаем
                }
            }


        /// <summary>
        /// Получить время ближайшего запланированного события
        /// </summary>
        /// <returns>Время (если соыбтий нет - double.MaxValue)</returns>
        public double NextEventTime
            {
            get
                {
                if ( this.eventList.Count != 0 )
                    return this.eventList[ 0 ].ExecutionTime;
                else
                    return double.MaxValue;
                }
            }


        /// <summary>
        /// Сбросить календарь событий в начальное состояние
        /// </summary>
        public void Reload()
            {
            this.eventList.Clear();
            this.systemTime = 0;
            }


        /// <summary>
        /// Копирование
        /// </summary>
        /// <returns></returns>
        public Calendar Clone()
            {
            Calendar newCalendar = new Calendar();
            newCalendar.systemTime = this.systemTime;
            foreach ( CommonEvent ev in this.eventList )
                newCalendar.eventList.Add( ev );
            return newCalendar;
            }


        /// <summary>
        /// Текущее системное время
        /// </summary>
        private double systemTime = 0;


        /// <summary>
        /// Список запланированных событий
        /// </summary>
        private List<CommonEvent> eventList = new List<CommonEvent>();
        }
    }
