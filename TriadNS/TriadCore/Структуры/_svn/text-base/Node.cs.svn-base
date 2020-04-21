using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Дескриптор объекта
    /// </summary>
    public class Node
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param polusName="polusName">Имя вершины</param>
        public Node( CoreName coreName )
            {
            if ( coreName == null )
                throw new ArgumentNullException( "Пустое имя вершины" );
            
            this.coreName = coreName;
            }



        /// <summary>
        /// Имя вершины
        /// </summary>
        public CoreName Name
            {
            get
                {
                return this.coreName;
                }
            }


        /// <summary>
        /// Символьное имя объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            {
            return coreName.ToString();
            }

        
        /// <summary>
        /// Список полюсов вершины
        /// </summary>
        public IEnumerable<Polus> Poluses
            {
            get
                {
                foreach ( Polus polus in this.polusList.Values )
                    yield return polus;
                }
            }


        /// <summary>
        /// Получить копию
        /// </summary>
        /// <returns></returns>
        public Node Clone()
            {
            //Создаем копию вершины
            Node newNode = new Node( this.Name );
            //Делаем копии полюсов вершины
            foreach ( KeyValuePair<CoreName, Polus> pair in this.polusList )
                newNode.polusList.Add( pair.Key, pair.Value.Clone() );
           
            //Делаем копию рутины
            if ( this.nodeRoutine != null )
                newNode.nodeRoutine = this.nodeRoutine.Clone();

            return newNode;
            }


        /// <summary>
        /// Индексатор полюсов
        /// </summary>
        /// <param name="polusName">Имя искомого полюса</param>
        /// <returns></returns>
        public Polus this[ CoreName polusName ]
            {
            get
                {
                if ( polusName == null )
                    throw new ArgumentNullException( "Пустое имя полюса" );

                if ( !this.polusList.ContainsKey( polusName ) )
                    throw new ArgumentException( "У вершины " +
                        this.ToString() + " нет запрашиваемого полюса " +
                        polusName );

                return this.polusList[ polusName ];
                }
            }


        /// <summary>
        /// Индексатор полюсов
        /// </summary>
        /// <param name="polusIndex">Индекс полюса в вершине</param>
        /// <returns></returns>
        public Polus this[ int polusIndex ]
            {
            get
                {
                int currIndex = 0;
                foreach ( Polus polus in polusList.Values )
                    {
                    if ( currIndex == polusIndex )
                        return polus;
                    currIndex++;
                    }

                throw new ArgumentOutOfRangeException( "Индекс полюса выходит за допустимые границы" );
                }
            }


        #region DeclareOperations


        /// <summary>
        /// Объявить полюс
        /// </summary>
        /// <param name="polusName">Имя полюса</param>
        public void DeclarePolus( CoreName polusName )
            {
            if ( polusName == null )
                throw new ArgumentNullException( "Передано пустое имя полюса" );

            //Если полюса с таким именем ранее добавлено не было
            if ( !polusList.ContainsKey( polusName ) )
                {
                polusList.Add( polusName, new Polus( polusName, this ) );
                }
            else
                {
                //Ничего не добавляем
                }
            }


        /// <summary>
        /// Объявить множество полюсов
        /// </summary>
        /// <param name="polusNameRange">Имя полюса</param>
        public void DeclarePolus( CoreNameRange polusNameRange )
            {
            if ( polusNameRange == null )
                throw new ArgumentNullException( "Передан пустой диапазон имен полюсов" );

            foreach ( CoreName polusName in polusNameRange )
                DeclarePolus( polusName );
            }

        #endregion


        #region DinamicOperations


        /// <summary>
        /// Соединить с полюсом
        /// </summary>
        /// <param name="polus">Полюс</param>
        private void Add( Polus polus )
            {
            if ( polus == null )
                throw new ArgumentNullException( "Передан пустой полюс" );

            //Устанавливаем родительскую вершину у нового полюса
            polus.BaseNode = this;

            //Если такой полюс уже есть в вершине
            if ( this.polusList.ContainsKey( polus.Name ) )
                {
                //Сливаем новый полюс со старым
                this.polusList[ polus.Name ].Add( polus );
                }
            //Если такого полюса нет в вершине
            else
                {
                //Просто добавляем новый полюс
                this.polusList.Add( polus.Name, polus );
                }
            }


        /// <summary>
        /// Слить полюса двух вершин
        /// </summary>
        /// <param name="node">Вторая вершина</param>
        /// <returns> Результат слияния</returns>
        public void Add( Node node )
            {
            if ( node == null )
                throw new ArgumentNullException( "Передана пустая вершина" );

            //Добавляем в текущую вершину все полюса переданной вершины
            foreach ( Polus polus in node.polusList.Values )
                {
                this.Add( polus );
                }
            }


        /// <summary>
        /// Вычесть полюса переданной вершины из текущей
        /// </summary>
        /// <param name="node">Вершина</param>
        public void Subtract( Node node )
            {
            if ( node == null )
                throw new ArgumentNullException( "Передана пустая вершина" );

            //Список полюсов, которые нужно удалить из текущей вершины
            List<CoreName> polusesToRemove = new List<CoreName>();
            //Перебираем полюса переданной вершины
            foreach ( Polus polus in node.polusList.Values )
                {
                //Если в текущей вершины есть полюс из переданной вершины
                if ( this.polusList.ContainsKey( polus.Name ) )
                    {
                    //Делаем этот полюс текущей вершины кандидатом на удаление
                    polusesToRemove.Add( polus.Name );
                    }
                }

            //Удаляем выбранные полюса текущей вершины
            foreach ( CoreName polusName in polusesToRemove )
                {
                RemovePolus( polusName );
                }
            }


        /// <summary>
        /// Удалить полюс
        /// </summary>
        /// <param name="polusName">Имя полюса</param>
        private void RemovePolus( CoreName polusName )
            {
            if ( polusName == null )
                throw new ArgumentNullException( "Передано пустое имя полюса" );

            //Если такой полюс есть в вершине
            if ( this.polusList.ContainsKey( polusName ) )
                {
                //Удаляем все дуги полюса
                this.polusList[ polusName ].RemoveAllArcs();
                //Удаляем сам полюс
                this.polusList.Remove( polusName );
                }
            else
                {
                //Ничего не делаем
                }
            }

        
        /// <summary>
        /// Пересечь текущую вершину с другой по полюсам
        /// </summary>
        /// <param name="node">Вторая вершина</param>
        public void Multiply( Node node )
            {
            if ( node == null )
                throw new ArgumentNullException( "Передана пустая вершина" );

            //Полюса текущей, которые нужно пересечь по общим дугам
            List<Polus> polusesToIntersect = new List<Polus>();
            //Полюса текущей вершины, которые нужно просто удалить
            List<Polus> polusesToRemove = new List<Polus>();

            //Перебираем полюса текущей вершины
            foreach ( Polus polus in this.polusList.Values )
                {
                //Если переданная вершина содержит текущий полюс
                if ( node.polusList.ContainsKey( polus.Name ) )
                    {
                    //То эти этот полюс нужно слить с соответствующим полюсом переданной вершины
                    polusesToIntersect.Add( polus );
                    }
                else
                    {
                    //Иначе этот полюс нужно просто удалить из текущей вершины
                    polusesToRemove.Add( polus );
                    }
                }

            //Удаляем выбранные полюса
            foreach ( Polus polus in polusesToRemove )
                {
                RemovePolus( polus.Name );
                }

            //Сливаем выбранные полюса
            foreach ( Polus polus in polusesToIntersect )
                {
                polus.Multiply( node[ polus.Name ] );
                }
            }


        /// <summary>
        /// Добавить дугу
        /// </summary>
        /// <param name="polusFrom">Начальный полюс (содержащийся в текущей вершине)</param>
        /// <param name="polusTo">Конечный полюс</param>
        public void AddArc( Polus polusFrom, Polus polusTo )
            {
            if ( polusFrom == null )
                throw new ArgumentNullException( "Пустой начальный полюс дуги" );
            if ( polusTo == null )
                throw new ArgumentNullException( "Пустой конечный полюс дуги" );

            //Если начальный полюс не содержится в текущей вершине
            if ( !this.polusList.ContainsKey( polusFrom.Name ) )
                throw new ArgumentException( "Вершина " +
                    this.ToString() + "  не содержит полюса " +
                    polusFrom.ToString() );

            polusFrom.AddOutputArc( polusTo );
            polusTo.AddInputArc( polusFrom );
            }


        /// <summary>
        /// Наличие полюсов у вершины
        /// </summary>
        /// <returns>Есть ли полюса</returns>
        public bool HasPoluses()
            {
            return this.polusList.Count != 0;
            }



        /// <summary>
        /// Удалить все полюсы вершины
        /// </summary>
        public void RemoveAllPoluses()
            {
            //Перебираем полюса вершины
            foreach ( Polus polus in this.polusList.Values )
                {
                //Удаляем все дуги идущие к текущему полюсу
                polus.RemoveAllArcs();
                }

            this.polusList.Clear();
            }

        //======by jum=====
        /// <summary>
        /// Операция слияния полюсов двух вершин
        /// </summary>
        /// <param name="node1">1 вершина</param>
        /// <param name="node2">2 вершина</param>
        /// <returns></returns>
        public static Node operator +(Node node1, Node node2)
        {
            if (node1 == null)
                return node2;
            if (node2 == null)
                return node1;

            node1.Add(node2);

            return node1;
        }

        /// <summary>
        /// Операция вычитания полюсов второй вершины из первой 
        /// </summary>
        /// <param name="node1">1 вершина</param>
        /// <param name="node2">2 вершина</param>
        /// <returns></returns>
        public static Node operator -(Node node1, Node node2)
        {
            if (node1 == null)
                return null;
            if (node2 == null)
                return node1;

            node1.Subtract(node2);

            return node1;
        }

        /// <summary>
        /// Операция пересечения вершин по полюсам
        /// </summary>
        /// <param name="node1">1 вершина</param>
        /// <param name="node2">2 вершина</param>
        /// <returns></returns>
        public static Node operator *(Node node1, Node node2)
        {
            if (node1 == null)
                return null;
            if (node2 == null)
                return node1;

            node1.Multiply(node2);

            return node1;
        }
        //===============================


        #endregion


        #region RoutioneOperations

        /// <summary>
        /// Послать сообщение через полюс
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="polusName">Имя полюса</param>
        /// <param name="sendMessageTime">Время посылки сообщения</param>
        public void SendMessageVia( string message, CoreName polusName, double sendMessageTime  )
            {
            if ( message == null )
                throw new ArgumentNullException( "Передано пустое сообщение" );
            
            if ( polusName == null )
                throw new ArgumentNullException( "Передано пустое имя полюса" );

            if ( !this.polusList.ContainsKey( polusName ) )
                throw new ArgumentException( "Послать сообщение невозможно. Вершина " 
                    + this.ToString() + " не содержит полюса " + polusName.ToString() );
            
            //Посылаем сообщение через указанный полюс вершины
            this.polusList[ polusName ].SendMessage( message, sendMessageTime );
            }


        /// <summary>
        /// Получить сообщение через полюс
        /// </summary>
        /// <param name="polusName">Имя полюса</param>
        /// <param name="message">Сообщение</param>
        /// <param name="sendMessageTime">Время посылки сообщения</param>
        public void ReceiveMessageVia( CoreName polusName, string message, double sendMessageTime )
            {
            if ( message == null )
                throw new ArgumentNullException( "Передано пустое сообщение" );

            if ( polusName == null )
                throw new ArgumentNullException( "Передано пустое имя полюса" );

            if ( !this.polusList.ContainsKey( polusName ) )
                throw new ArgumentException( "Принять сообщение невозможно. Вершина "
                    + this.ToString() + " не содержит полюса " + polusName.ToString() );

            //Если на вершину наложена рутина
            if ( this.nodeRoutine != null )
                {
                this.nodeRoutine.ReceiveMessage( polusName, message, sendMessageTime );
                }
            }


        /// <summary>
        /// Задать рутину
        /// </summary>
        /// <param name="routine">Рутина</param>
        public void RegisterRoutine( Routine routine )
            {
            if ( routine == null )
                throw new ArgumentNullException( "Передана пустая рутина" );

            //Накладываем на вершину копию рутины
            this.nodeRoutine = routine.Clone();
            }


        /// <summary>
        /// Инициализировать рутину вершины, если она есть
        /// </summary>
        public void InitializeRoutine()
            {
            //Если у вершины задана рутина
            if ( this.nodeRoutine != null )
                {
                nodeRoutine.Initialize( this );
                //Сбрасываем календарь событий у рутины
                nodeRoutine.EventCalendar.Reload();
                }
            }


        /// <summary>
        /// Выполнить секцию инициализации у рутины
        /// </summary>
        public void DoRoutineInitialSection()
            {
            //Если у вершины задана рутина
            if ( this.nodeRoutine != null )
                {
                nodeRoutine.DoInitialize();
                }
            }

       

        #endregion

        #region IProcedureOperations


        /// <summary>
        /// Создать объект слежения за объектом в рутине вершины
        /// </summary>
        /// <param name="objectName">Имя объекта</param>
        /// <param name="objectType">Тип объекта</param>
        /// <returns>Объект</returns>
        public SpyObject CreateSpyObject( CoreName objectName, SpyObjectType objectType )
            {
            if ( objectName == null )
                throw new ArgumentNullException( "Передано пустое имя объекта" );

            //Если у вершины не задана рутина
            if ( this.nodeRoutine == null )
                throw new InvalidOperationException( String.Format( "У вершины {0} не задана рутина", this ) );

            switch ( objectType )
                {
                //Если нужно следить за переменной в рутине
                case SpyObjectType.Var:
                    return new SpyVar( objectName, this.nodeRoutine );
                //Если нужно следить за приходом сообщений на полюс
                case SpyObjectType.Polus:
                    return new SpyPolus( objectName, this.nodeRoutine );
                //Если нужно следить за срабатыванием событий
                case SpyObjectType.Event:
                    return new SpyEvent( objectName, this.nodeRoutine );
                }

            throw new ArgumentOutOfRangeException( "Указан неизвестный тип объекта слежений" );
            }


        /// <summary>
        /// Создать диапазон объектов слежения
        /// </summary>
        /// <param name="objectNameRange">Имя диапазона</param>
        /// <param name="objectType">Тип объектов</param>
        /// <returns>Диапазон</returns>
        public SpyObject[] CreateSpyObject( CoreNameRange objectNameRange, SpyObjectType objectType )
            {
            if ( objectNameRange == null )
                throw new ArgumentNullException( "Передан пустой диапазон объектов слежения" );

            //Список созданный объектов
            List<SpyObject> objectList = new List<SpyObject>();

            foreach ( CoreName objectName in objectNameRange )
                objectList.Add( CreateSpyObject( objectName, objectType ) );

            return objectList.ToArray();
            }


        #endregion


        /// <summary>
        /// Рутина, наложенная на вершину
        /// </summary>
        public Routine NodeRoutine
            {
            get
                {
                return nodeRoutine;
                }
            set
                {
                    nodeRoutine = value;
                }
            }


        /// <summary>
        /// Прикрепленная к вершине рутина
        /// </summary>
        private Routine nodeRoutine = null;
        /// <summary>
        /// Имя вершины
        /// </summary>
        private CoreName coreName;
        /// <summary>
        /// Список полюсов вершины
        /// </summary>
        private Dictionary<CoreName, Polus> polusList = new Dictionary<CoreName, Polus>();
        }


   }
