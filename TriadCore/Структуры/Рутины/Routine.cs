using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace TriadCore
    {
    /// <summary>
    /// Обработчик изменения
    /// </summary>
    /// <param name="Info">Объект слежения</param>
    /// <param name="systemTime">Время изменения</param>
    public delegate void SpyHandler( SpyObject Info, double systemTime );

    /// <summary>
    /// Рутина
    /// </summary>
    public class Routine : ReflectionObject, ICreatable
        {
        /// <summary>
        /// Индекс в случае отсутствия массива
        /// </summary>
        protected const int DefaultIndex = -1;
        /// <summary>
        /// Индекс полюса, принявшего сообщение
        /// </summary>
        private int indexOfPolusReceivedMessage = -1;


        /// <summary>
        /// Создать новую рутину (вызывается при инициализации массивов)
        /// </summary>
        /// <returns>Новая рутина</returns>
        public object CreateNew()
            {
            return new Routine();
            }


        /// <summary>
        /// Планирование события
        /// </summary>
        /// <param name="deltaTime">Время ожидания срабатывания события</param>
        /// <param name="eventHandlerList">Обработчики событий, происходящих в это время</param>
        protected void Sсhedule( double deltaTime, params InternalEventHandler[] eventHandlerList )
            {
            if ( this.baseNode != null )
                {
                foreach ( InternalEventHandler eventHandler in eventHandlerList )
                    {
                    //Планируем через deltaTime единиц времени
                    InternalEvent ev = new InternalEvent( deltaTime + this.SystemTime, this );
                    ev.EventHandler += eventHandler;

                    CoreName eventCoreName = new CoreName( eventHandler.Method.Name );
                    
                    //Проверяем также обработчики ИП
                    if ( this.spyHandlerList.ContainsKey( eventCoreName ) )
                        foreach ( SpyHandler handler in this.spyHandlerList[ eventCoreName ] )
                            {
                            ev.EventSpyHandler += handler;
                            }

                    this.eventCalendar.PlaneEvent( ev ); 
                    }
                }
            }


        /// <summary>
        /// Отменить ближайшие события с такими обработчиками
        /// </summary>
        /// <param name="eventHandlerList">Обработчики событий</param>
        protected void Cancel( params InternalEventHandler[] eventHandlerList )
            {
            //***********************************************
            // Заглушка
            //***********************************************
            }

        
        /// <summary>
        /// Послать сообщение через полюс
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="routinePolusName">Имя полюса рутины, через который посылается сообщение</param>
        protected void SendMessageVia( string message, CoreName routinePolusName )
            {
            if ( message == null )
                throw new ArgumentNullException( "message" );

            if ( this.baseNode != null )
                {
                //Если полюс рутины связан с полюсом вершины
                if ( this.routineNodePolusPairs.ContainsKey( routinePolusName ) )
                    //Если полюс рутины не находится в списке заблокированных
                    if ( !this.routineBlockedPolusList.Contains( routinePolusName ) )
                        //Посылаем сообщение на связанные полюса вершины
                        foreach ( CoreName nodeCoreName in this.routineNodePolusPairs[ routinePolusName ] )
                            {
                            this.baseNode.SendMessageVia( message, nodeCoreName, this.SystemTime );
                            }
                }
            }


        /// <summary>
        /// Послать сообщение через все полюсы
        /// </summary>
        protected void SendMessageViaAllPoluses( string message )
            {
            foreach ( CoreName routinePolusName in this.routineNodePolusPairs.Keys )
                {
                SendMessageVia( message, routinePolusName );
                }
            }


        /// <summary>
        /// Послать сообщение через диапазон полюсов
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="routineCoreNameRange">Диапазон полюсов рутины, через которые посылаются сообщения</param>
        protected void SendMessageVia( string message, CoreNameRange routineCoreNameRange )
            {
            foreach ( CoreName routineCoreName in routineCoreNameRange )
                {
                SendMessageVia( message, routineCoreName );
                }
            }


        /// <summary>
        /// Получить индекс полюса
        /// </summary>
        /// <param name="polusName">Имя полюса</param>
        /// <returns>Индекс полюса или -1, если у полюса нет индексов</returns>
        protected int GetPolusIndex( CoreName polusName )
            {
            if ( polusName.IsIndexed )
                return polusName.Indices[ 0 ];
            else
                return -1;
            }



        /// <summary>
        /// Получить сообщение через полюс
        /// </summary>
        /// <param name="nodePolusName">Имя полюса вершины</param>
        /// <param name="message">Сообщение</param>
        /// <param name="sendMessageTime">Время посылки сообщения</param>
        public void ReceiveMessage( CoreName nodePolusName, string message, double sendMessageTime )
            {
            //Если полюс вершины связан с полюсом рутины
            if ( this.nodeRoutinePolusPairs.ContainsKey( nodePolusName ) )
                foreach ( CoreName routineCoreName in this.nodeRoutinePolusPairs[ nodePolusName ] )
                    {
                    //Планируем событие приема сообщения (независимо от того, заблокирован или нет полюс)
                    ReceivingMessageEvent ev = new ReceivingMessageEvent( sendMessageTime, 
                        this, routineCoreName, nodePolusName, message );
                    ev.OnEventFunction += this.ReceiveMessageHandler;

                    //Добавляем обработчики приема сообщений
                    if ( this.spyHandlerList.ContainsKey( nodePolusName ) )
                        foreach ( SpyHandler handler in this.spyHandlerList[ nodePolusName ] )
                            {
                            ev.EventSpyHandler += handler;
                            }
                    
                    this.eventCalendar.PlaneEvent( ev );
                    }
            }


        /// <summary>
        /// Обработчик приема сообщения
        /// Такой обработчик нужен, чтобы проверять заблокированность полюса
        /// в нужный момент модельного времени (а не в функции ReceiveMessage)
        /// </summary>
        /// <param name="routinePolusName">Имя полюса, принявшего сообщение</param>
        /// <param name="nodePolusName">Имя полюса вершины, принявшего сообщение</param>
        /// <param name="message">Сообщение</param>
        /// <param name="spyHandler">Обработчики принятия сообщения</param>
        private void ReceiveMessageHandler( CoreName routinePolusName, CoreName nodePolusName,
            string message, SpyHandler spyHandler )
            {
            //Если полюс рутины не находится в списке заблокированных
            if ( !this.routineBlockedPolusList.Contains( routinePolusName ) )
                {
                ReceiveMessageVia( routinePolusName, message );

                //Вызываем информационные процедуры, следящие за принятием сообщений
                if ( spyHandler != null )
                    {
                    SpyObject spyPolus = new SpyPolus( nodePolusName, this );
                    spyPolus.Data = message;
                    spyHandler( spyPolus, this.SystemTime );
                    }
                }
            }


        /// <summary>
        /// Переопределяемый обработчик сообщений
        /// </summary>
        /// <param name="polusName">Имя полюса или массива полюсов</param>
        /// <param name="message">Сообщение</param>
        protected virtual void ReceiveMessageVia( CoreName polusName, string message )
            {
            //Ничего не делаем
            }


        /// <summary>
        /// Действия по инициализации рутины
        /// </summary>
        public virtual void DoInitialize()
            {
            //Ничего не делаем
            }

        
        /// <summary>
        /// Действия по инициализации рутины
        /// </summary>
        /// <param name="baseNode">Родительская вершина</param>
        public void Initialize( Node baseNode )
            {
            this.baseNode = baseNode;
            }


        /// <summary>
        /// Получить копию
        /// </summary>
        /// <returns></returns>
        public new Routine Clone()
            {
            Routine newRoutine = base.Clone() as Routine;

            //У копии должен быть свой календарь событий
            newRoutine.eventCalendar = new Calendar();

            //Копируем список заблокированных полюсов
            newRoutine.routineBlockedPolusList = new List<CoreName>();
            foreach ( CoreName coreName in this.routineBlockedPolusList )
                newRoutine.routineBlockedPolusList.Add( coreName );

            //**********************************************************
            //Список соответствий у клонированных рутин тоже надо клонировать,
            //т.к. рутина может накладываться несколько раз с разными соответствиями
            //**********************************************************
            newRoutine.routineNodePolusPairs = new SortedList<CoreName, List<CoreName>>();
            foreach ( KeyValuePair<CoreName, List<CoreName>> pair in this.routineNodePolusPairs )
                newRoutine.routineNodePolusPairs.Add( pair.Key, pair.Value );
            
            newRoutine.nodeRoutinePolusPairs = new SortedList<CoreName, List<CoreName>>();
            foreach ( KeyValuePair<CoreName, List<CoreName>> pair in this.nodeRoutinePolusPairs )
                newRoutine.nodeRoutinePolusPairs.Add( pair.Key, pair.Value );

            return newRoutine;
            }


        /// <summary>
        /// Добавить соответствие между именем полюса в вершине и в рутине
        /// </summary>
        /// <param name="routinePolusName">Имя полюса в рутине</param>
        /// <param name="nodePolusName">Имя полюса в вершине</param>
        public void AddPolusPair( CoreName routinePolusName, CoreName nodePolusName )
            {
            if ( !this.nodeRoutinePolusPairs.ContainsKey( nodePolusName ) )
                this.nodeRoutinePolusPairs.Add( nodePolusName, new List<CoreName>() );
            this.nodeRoutinePolusPairs[ nodePolusName ].Add( routinePolusName );

            if ( !this.routineNodePolusPairs.ContainsKey( routinePolusName ) )
                this.routineNodePolusPairs.Add( routinePolusName, new List<CoreName>() );
            this.routineNodePolusPairs[ routinePolusName ].Add( nodePolusName );
            }


        /// <summary>
        /// Добавить соответствие между полюсом рутины и каждым полюсом вершины из списка
        /// </summary>
        /// <param name="routinePolusName">Полюс рутины</param>
        /// <param name="nodePolusNameRange">Список полюсов вершины</param>
        public void AddPolusPair( CoreName routinePolusName, CoreNameRange nodePolusNameRange )
            {
            foreach ( CoreName nodePolusName in nodePolusNameRange )
                AddPolusPair( routinePolusName, nodePolusName );
            }


        /// <summary>
        /// Добавить соответствие между каждым полюсом рутины из списка и полюсом вершины
        /// </summary>
        /// <param name="routinePolusNameRange">Список полюсов рутины</param>
        /// <param name="nodePolusName">Полюс вершины</param>
        public void AddPolusPair( CoreNameRange routinePolusNameRange, CoreName nodePolusName )
            {
            foreach ( CoreName routinePolusName in routinePolusNameRange )
                AddPolusPair( routinePolusName, nodePolusName );
            }


        /// <summary>
        /// Добавить соответствие между списками полюсов рутины и вершины
        /// </summary>
        /// <param name="routinePolusNameRange"></param>
        /// <param name="nodePolusNameRange"></param>
        public void AddPolusPair( CoreNameRange routinePolusNameRange, CoreNameRange nodePolusNameRange )
            {
            for ( int index = 0 ; index < routinePolusNameRange.ItemCount ; index++ )
                {
                if ( index >= nodePolusNameRange.ItemCount )
                    break;

                AddPolusPair( routinePolusNameRange[ index ], nodePolusNameRange[ index ] );
                }
            }



        /// <summary>
        /// Очистить список соответствий между именами полюсов в структуре и в рутине
        /// </summary>
        public void ClearPolusPairList()
            {
            this.routineNodePolusPairs.Clear();
            this.nodeRoutinePolusPairs.Clear();
            }

        
        /// <summary>
        /// Системное время
        /// </summary>
        protected override double SystemTime
            {
            get
                {
                return this.eventCalendar.SystemTime;
                }
            }   
        

        
        /// <summary>
        /// Заблокировать полюс для посылки/принятия сообщений
        /// </summary>
        /// <param name="routinePolusName">Имя полюса в рутине</param>
        public void BlockPolus( CoreName routinePolusName )
            {
            if ( !this.routineBlockedPolusList.Contains( routinePolusName ) )
                this.routineBlockedPolusList.Add( routinePolusName );
            }


        /// <summary>
        /// Заблокировать полюс для посылки/принятия сообщений
        /// </summary>
        /// <param name="routineNameRange">Диапазон имен полюсов в рутине</param>
        public void BlockPolus( CoreNameRange routineNameRange )
            {
            foreach( CoreName coreName in routineNameRange )
                {
                BlockPolus( coreName );
                }
            }


        /// <summary>
        /// Заблокировать полюс для посылки/принятия сообщений
        /// </summary>
        /// <param name="nodePolusName">Имя полюса в вершине</param>
        public void BlockNodePolus( CoreName nodePolusName )
            {
            if ( this.nodeRoutinePolusPairs.ContainsKey( nodePolusName ) )
                //Блокируем все связанные с полюсом вершины полюса рутины
                foreach ( CoreName routinePolusName in this.nodeRoutinePolusPairs[ nodePolusName ] )
                    BlockPolus( routinePolusName );
            }


        /// <summary>
        /// Разблокировать полюс для посылки/принятия сообщений
        /// </summary>
        /// <param name="routinePolusName">Имя полюса рутины</param>
        public void UnblockPolus( CoreName routinePolusName )
            {
            if ( this.routineBlockedPolusList.Contains( routinePolusName ) )
                this.routineBlockedPolusList.Remove( routinePolusName );            
            }


        /// <summary>
        /// Разблокировать полюс для посылки/принятия сообщений
        /// </summary>
        /// <param name="routineNameRange">Диапазон имен полюсов рутины</param>
        public void UnblockPolus( CoreNameRange routineNameRange )
            {
            foreach ( CoreName coreName in routineNameRange )
                {
                UnblockPolus( coreName );
                }
            }


        /// <summary>
        /// Разблокировать полюс для посылки/принятия сообщений
        /// </summary>
        /// <param name="nodePolusName">Имя полюса вершины</param>
        public void UnblockNodePolus( CoreName nodePolusName )
            {
            if ( this.nodeRoutinePolusPairs.ContainsKey( nodePolusName ) )
                //Разлокируем все связанные с полюсом вершины полюса рутины
                foreach ( CoreName routinePolusName in this.nodeRoutinePolusPairs[ nodePolusName ] )
                    UnblockPolus( routinePolusName );
            }


        /// <summary>
        /// Отладочная печать
        /// </summary>
        /// <param name="message">Сообщение</param>
        protected void PrintMessage( object message )
            {
            if ( message != null )
                {
                if ( this.baseNode != null )
                    Console.WriteLine( "{0,-12} {1,-6} {2} ", this.baseNode, this.SystemTime, message );
                }
            }


        
        /// <summary>
        /// Календарь событий рутины
        /// </summary>
        public Calendar EventCalendar
            {
            get
                {
                return eventCalendar;
                }
            }


        /// <summary>
        /// Вершина, содержащая рутину
        /// </summary>
        private Node baseNode = null;
        /// <summary> 
        /// Календарь событий
        /// </summary>
        private Calendar eventCalendar = new Calendar();

        /// <summary>
        /// Список соответствий вида: Key - имя полюса в рутине; Value - имена связанных с ним полюсов в вершине
        /// </summary>
        private SortedList<CoreName, List<CoreName>> routineNodePolusPairs = new SortedList<CoreName, List<CoreName>>();
        /// <summary>
        /// Список соответствий вида: Key - имя полюса в вершине; Value - имена связанных с ним полюсов в рутине
        /// </summary>
        private SortedList<CoreName, List<CoreName>> nodeRoutinePolusPairs = new SortedList<CoreName, List<CoreName>>();
        /// <summary>
        /// Список заблокированных для посылки/принятия сообщений полюсов рутины
        /// </summary>
        private List<CoreName> routineBlockedPolusList = new List<CoreName>();
        }
    }
