using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Обычное событие без обработчиков срабатывания
    /// </summary>
    public class CommonEvent : IComparable
        {
        /// <summary>
        /// Предельное время срабатывания события
        /// </summary>
        public const double MaxEventTime = double.MaxValue;


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="executionTime">Время срабатывания события</param>
        /// <param name="routine">Рутина, на которой должно произойти событие</param>
        public CommonEvent( double executionTime, Routine routine )
            {
            this.executionTime = executionTime;
            this.routine = routine;
            }


        /// <summary>
        /// Условие сортировки событий по времени
        /// </summary>
        public int CompareTo( Object obj )
            {
            CommonEvent calendarEvent = obj as CommonEvent;
            if ( calendarEvent != null )
                {
                return this.ExecutionTime.CompareTo( calendarEvent.ExecutionTime );
                }
            else
                throw new ArgumentException( "Это условие сравнения предназначено только для событий" );
            }



        /// <summary>
        /// Время срабатывания события
        /// </summary>
        /// <remarks>Время должно быть неотрицательным, 
        /// иначе генерируется исключение ArgumentOutOfRangeException</remarks>
        /// <value>executionTime</value>
        public double ExecutionTime
            {
            set
                {
                if ( value >= 0 )
                    {
                    executionTime = value;
                    }
                else
                    throw new ArgumentOutOfRangeException( "value" );
                }
            get
                {
                return executionTime;
                }
            }


        /// <summary>
        /// Вызвать обработчик события
        /// </summary>
        public virtual void ExecuteAllEventHandlers()
            {
            //Пусто
            }


        /// <summary>
        /// Клонирование объекта
        /// </summary>
        /// <returns>Новый объект</returns>
        public CommonEvent Clone()
            {
            return this.MemberwiseClone() as CommonEvent;
            }


        /// <summary>
        /// Операция сравнения
        /// </summary>
        /// <param name="obj">Другой объект</param>
        /// <returns>Результат сравнения</returns>
        public override bool Equals( object obj )
            {
            CommonEvent otherEvent = obj as CommonEvent;
            if ( otherEvent == null )
                return false;
            else
                return this.executionTime == otherEvent.executionTime;
            }


        /// <summary>
        /// Хеш
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
            {
            return this.executionTime.GetHashCode();
            }


        /// <summary>
        /// Оператор больше
        /// </summary>
        /// <param name="first">Первый операнд</param>
        /// <param name="second">Второй операнд</param>
        /// <returns>Результат сравнения</returns>
        public static bool operator >( CommonEvent first, CommonEvent second )
            {
            if ( first == null )
                throw new ArgumentNullException( "first" );
            if ( second == null )
                throw new ArgumentNullException( "second" );

            return first.CompareTo( second ) > 0;
            }


        /// <summary>
        /// Оператор меньше
        /// </summary>
        /// <param name="first">Первый операнд</param>
        /// <param name="second">Второй операнд</param>
        /// <returns>Результат сравнения</returns>
        public static bool operator <( CommonEvent first, CommonEvent second )
            {
            if ( first == null )
                throw new ArgumentNullException( "first" );
            if ( second == null )
                throw new ArgumentNullException( "second" );

            return first.CompareTo( second ) < 0;
            }


        /// <summary>
        /// Рутина, на которой происходит событие
        /// </summary>
        protected Routine routine = null;
        /// <summary>
        /// Время срабатывания события
        /// </summary>
        private double executionTime = 0;
        /// <summary>
        /// Зарегистрированные обработчики события (регистрация таких обработчиков происходит из ИП)
        /// </summary>
        public SpyHandler EventSpyHandler = null;
        }
    }
