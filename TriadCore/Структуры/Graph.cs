using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Дескриптор графа
    /// </summary>
    public class Graph : ICreatable
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public Graph()
            : this ( new CoreName( "Неизвестный граф" ) )
            {
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="coreName">Имя графа</param>
        public Graph( CoreName coreName )
            {
            if ( coreName == null )
                throw new ArgumentNullException( "Пустое имя графа" );

            this.coreName = coreName;
            this.systemTime = -1;
            }


        /// <summary>
        /// Создать новый граф  (вызывается при инициализации массивов)
        /// </summary>
        /// <returns>Новый граф</returns>
        public object CreateNew()
            {
            return new Graph();
            }


        /// <summary>
        /// Имя графа
        /// </summary>
        public CoreName Name
            {
            get
                {
                return this.coreName;
                }
            }


        /// <summary>
        /// Индексатор вершин
        /// </summary>
        /// <value>Имя вершины</value>
        public Node this[ CoreName nodeName ]
            {
            get
                {
                if ( nodeName == null )
                    throw new ArgumentNullException( "Пустое имя вершины" );

                if ( !this.nodeList.ContainsKey( nodeName ) )
                    throw new ArgumentException( String.Format( 
                        "Граф \"{0}\" не содержит вершины с именем \"{1}\"", this, nodeName ) );

                return this.nodeList[ nodeName ];
                }
            }


        /// <summary>
        /// Индексатор вершин
        /// </summary>
        /// <value>Индекс вершины в графе</value>
        public Node this[ int nodeIndex ]
            {
            get
                {
                int currIndex = 0;
                foreach ( Node node in nodeList.Values )
                    {
                    if ( currIndex == nodeIndex )
                        return node;
                    currIndex++;
                    }

                throw new ArgumentOutOfRangeException( "Индекс вершины выходит за допустимые границы" );
                }
            }


        /// <summary>
        /// Символьное имя графа
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            {
            return coreName.ToString();
            }

        
        /// <summary>
        /// Список вершин графа
        /// </summary>
        public IEnumerable<Node> Nodes
            {
            get
                {
                foreach ( Node node in nodeList.Values )
                    yield return node;
                }
            }


        /// <summary>
        /// Число вершин в графе
        /// </summary>
        public int NodeCount
            {
            get
                {
                return this.nodeList.Count;
                }
            }


        /// <summary>
        /// Получить копию
        /// </summary>
        /// <returns></returns>
        public Graph Clone()
            {
            //Создаем копию графа
            Graph newGraph = new Graph( this.Name );
            
            //Заполняем список его вершин
            foreach ( KeyValuePair<CoreName, Node> pair in this.nodeList )
                newGraph.nodeList.Add( pair.Key, pair.Value.Clone() );
            
            return newGraph;
            }

        #region Декларативные операции

        /// <summary>
        /// Объявить вершину
        /// </summary>
        /// <param name="nodeName">Имя вершины</param>
        public void DeclareNode( CoreName nodeName )
            {
            if ( nodeName == null )
                throw new ArgumentNullException( "Пустое имя вершины" );

            //Если у графа не было ранее объявлена такая вершина
            if ( !this.nodeList.ContainsKey( nodeName ) )
                {
                this.nodeList.Add( nodeName, new Node( nodeName ) );
                }
            else
                {
                //Ничего не делаемы
                }
            }


        /// <summary>
        /// Объявить вершину вместе с ее полюсами
        /// </summary>
        /// <param name="nodeName">Имя вершины</param>
        /// <param name="polusNameList">Список имен полюсов вершины</param>
        public void DeclareNode( CoreName nodeName, params CoreName[] polusNameList )
            {
            if ( nodeName == null )
                throw new ArgumentNullException( "Пустое имя вершины" );

            //Объявляем саму вершину
            DeclareNode( nodeName );
            
            //Объявляем полюса в добавленной вершине
            foreach ( CoreName polusName in polusNameList )
                {
                this[ nodeName ].DeclarePolus( polusName );
                }
            }


        /// <summary>
        /// Объявить множество вершин
        /// </summary>
        /// <param name="nodeNameRange">Имена вершин</param>
        public void DeclareNode( CoreNameRange nodeNameRange )
            {
            if ( nodeNameRange == null )
                throw new ArgumentNullException( "Пустой диапазон имен вершины" );

            //Объявляем диапазон вершин
            foreach ( CoreName nodeName in nodeNameRange )
                {
                DeclareNode( nodeName );
                }
            }


        /// <summary>
        /// Объявить полюс во всех вершинах
        /// </summary>
        /// <param name="polusName">Имя полюса</param>
        public void DeclarePolusInAllNodes( CoreName polusName )
            {
            if ( polusName == null )
                throw new ArgumentNullException( "Пустое имя полюса" );

            //Объявляем полюс во всех вершинах
            foreach ( Node node in this.nodeList.Values )
                {
                node.DeclarePolus( polusName );
                }
            }


        /// <summary>
        /// Объявить множество полюсов во всех вершинах
        /// </summary>
        /// <param name="polusNameRange">Имена полюсов</param>
        public void DeclarePolusInAllNodes( CoreNameRange polusNameRange )
            {
            if ( polusNameRange == null )
                throw new ArgumentNullException( "Пустой диапазон имен полюсов" );

            //Объявляем во всех вершинах все полюса из диапазона
            foreach ( CoreName polusName in polusNameRange )
                {
                DeclarePolusInAllNodes( polusName );
                }
            }


        #endregion


        #region Динамические операции


        /// <summary> 
        /// Добавить дугу
        /// </summary>
        /// <param name="nodeFromName">Начальная вершина</param>
        /// <param name="polusFromName">Имя начального полюса</param>
        /// <param name="nodeToName">Конечная вершина </param>
        /// <param name="polusToName">Имя конечного полюса</param>
        public void AddArc( CoreName nodeFromName, CoreName polusFromName, CoreName nodeToName, CoreName polusToName )
            {
            if ( nodeFromName == null )
                throw new ArgumentNullException( "Пустое имя первой вершины" );
            if ( polusFromName == null )
                throw new ArgumentNullException( "Пустое имя полюса первой вершины" );
            if ( nodeToName == null )
                throw new ArgumentNullException( "Пустое имя второй вершины" );
            if ( polusToName == null )
                throw new ArgumentNullException( "Пустое имя полюса второй вершины" );

            if ( !this.nodeList.ContainsKey( nodeFromName ) )
                throw new ArgumentException( String.Format(
                    "Граф \"{0}\" не содержит вершины с именем \"{1}\"", this, nodeFromName ) );
            if ( !this.nodeList.ContainsKey( nodeToName ) )
                throw new ArgumentException( String.Format(
                    "Граф \"{0}\" не содержит вершины с именем \"{1}\"", this, nodeToName ) );
            
            Node nodeFrom = this[ nodeFromName ];
            Node nodeTo = this[ nodeToName ];
            nodeFrom.AddArc( this[ nodeFromName ][ polusFromName ], nodeTo[ polusToName ] );
            }


        /// <summary>
        /// Добавить ребро
        /// </summary>
        /// <param name="nodeFromName">Начальная вершина</param>
        /// <param name="polusFromName">Имя начального полюса</param>
        /// <param name="nodeToName">Конечная вершина </param>
        /// <param name="polusToName">Имя конечного полюса</param>
        public void AddEdge( CoreName nodeFromName, CoreName polusFromName, CoreName nodeToName, CoreName polusToName )
            {
            AddArc( nodeFromName, polusFromName, nodeToName, polusToName );
            AddArc( nodeToName, polusToName, nodeFromName, polusFromName );
            }


        /// <summary>
        /// Соединить с вершиной
        /// </summary>
        /// <param name="node">Вершина</param>
        public void Add( Node node )
            {
            if ( node == null )
                throw new ArgumentNullException( "Передана пустая вершина" );

            //Если такая вершина есть в графе
            if ( this.nodeList.ContainsKey( node.Name ) )
                {
                //Сливаем переданную вершину с вершиной графа
                this.nodeList[ node.Name ].Add( node );
                }
            //Если такой вершины нет в графе
            else
                {
                //Просто добавляем вершину в граф
                this.nodeList.Add( node.Name, node );
                }
            }


        /// <summary>
        /// Соединить с графом
        /// </summary>
        /// <param name="graph">Добавляемый граф</param>
        public void Add( Graph graph )
            {
            if ( graph == null )
                throw new ArgumentNullException( "Передан пустой граф" );

            //Сливаем текущий граф со всеми вершинами переданного графа
            foreach ( Node node in graph.nodeList.Values )
                {
                this.Add( node );
                }
            }


        /// <summary>
        /// Вычесть вершину из графа 
        /// </summary>
        /// <param name="node">Вершина</param>
        /// <remarks>Если после вычитания у вершины с тем же именем не осталось полюсов, то она удаляется из графа
        /// Если у вычитаемой вершины нет полюсов, то исходная вершина тоже удаляется</remarks>
        public void Subtract( Node node )
            {
            if ( node == null )
                throw new ArgumentNullException( "Передана пустая вершина" );

            //Если текущий граф содержит вычитаемую вершину
            if ( this.nodeList.ContainsKey( node.Name ) )
                {
                //Если вычитаемая вершина содержит полюсы
                if ( node.HasPoluses() )
                    {
                    //Вычитаем указанную вершину из вершины графа
                    this.nodeList[ node.Name ].Subtract( node );

                    //Если после вычитания у вершины графа не осталось полюсов
                    if ( !this.nodeList[ node.Name ].HasPoluses() )
                        {
                        //То удаляем вершину графа
                        this.nodeList.Remove( node.Name );
                        }
                    }
                //Если вычитаемая вершина не содержит полюсов
                else
                    {
                    //То удаляем соответствующую вершину графа в любом случае
                    RemoveNode( node.Name );
                    }
                }
            //Если текущий граф не содержит вычитаемой вершины
            else
                {
                //Ничего не делаем
                }
            }

        
        /// <summary>
        /// Удалить вершину из графа
        /// </summary>
        /// <param name="nodeName">Имя удаляемой вершины</param>
        private void RemoveNode( CoreName nodeName )
            {
            if ( nodeName == null )
                throw new ArgumentNullException( "Передано пустое имя вершины" );

            //Удаляем все полюса вершины
            this.nodeList[ nodeName ].RemoveAllPoluses();
            //Удаляем саму вершину
            this.nodeList.Remove( nodeName );
            }


        /// <summary>
        /// Вычесть граф
        /// </summary>
        /// <param name="graph">Граф</param>
        public void Subtract( Graph graph )
            {
            if ( graph == null )
                throw new ArgumentNullException( "Передан пустой граф" );

            //Вычитаем из текущего графа все вершины переданного графа
            foreach ( Node node in graph.nodeList.Values )
                {
                this.Subtract( node );
                }
            }


        /// <summary>
        /// Пересечь текущий граф с другим
        /// </summary>
        /// <param name="graph">Второй граф</param>
        public void Multiply( Graph graph )
            {
            if ( graph == null )
                throw new ArgumentNullException( "Передан пустой граф" );

            //Вершины текущего графа, которые нужно пересечь с вершинами из переданного графа
            List<Node> nodesToIntersect = new List<Node>();
            //Вершины текущего графа, которые нужно удалить
            List<Node> nodesToRemove = new List<Node>();

            //Перебираем вершины текущего графа
            foreach ( Node node in this.nodeList.Values )
                {
                //Если указанный граф содержит текущую вершину текущего графа
                if ( graph.nodeList.ContainsKey( node.Name ) )
                    {
                    //То эту вершину текущего графа нужно пересечь с вершиной указанного графа
                    nodesToIntersect.Add( node );
                    }
                //Если указанный граф не содержит текущую вершину текущего графа
                else
                    {
                    //То эту вершину нужно удалить из текущего графа
                    nodesToRemove.Add( node );
                    }
                }

            //Удаляем выбранные вершины
            foreach ( Node node in nodesToRemove )
                {
                RemoveNode( node.Name );
                }

            //Пересекаем выбранные вершины
            foreach ( Node node in nodesToIntersect )
                {
                node.Multiply( graph[ node.Name ] );
                }
            }

        
        /// <summary>
        /// Удалить все вершины графа
        /// </summary>
        public void RemoveAllNodes()
            {
            //Пока в текущем графе еще есть вершины
            while ( this.nodeList.Count != 0 )
                {
                RemoveNode( this.nodeList.Keys.GetEnumerator().Current );
                }
            }


        /// <summary>
        /// Дополнить граф предопределенными ребрами и дугами
        /// </summary>
        public virtual void CompleteGraph()
            {
            //Ничего не делаем (поведение переопределяется в графах константах)
            }


        #endregion


        #region Операции с рутинами


        /// <summary>
        /// Задать рутину для вершины в графе
        /// </summary>
        /// <param name="nodeName">Имя вершины</param>
        /// <param name="routine">Рутина</param>
        public void RegisterRoutine( CoreName nodeName, Routine routine )
        {
            if ( nodeName == null )
                throw new ArgumentNullException( "Пустое имя вершины" );
            if ( routine == null )
                throw new ArgumentNullException( "Передана пустая рутина" );

            Node node = this[nodeName];
            node.RegisterRoutine( routine );

            if (systemTime >= 0)
            {
                node.InitializeRoutine();
                node.NodeRoutine.EventCalendar.SystemTime = systemTime;
                node.DoRoutineInitialSection();
            }
        }


        /// <summary>
        /// Задать рутину для диапазона вершин в графе
        /// </summary>
        /// <param name="nodeNameRange">Диапазон имен вершин</param>
        /// <param name="routine">Рутина</param>
        public void RegisterRoutine( CoreNameRange nodeNameRange, Routine routine )
            {
            if ( nodeNameRange == null )
                throw new ArgumentNullException( "Пустой диапазон имен вершин" );
            if ( routine == null )
                throw new ArgumentNullException( "Передана пустая рутина" );

            foreach ( CoreName nodeName in nodeNameRange )
                {
                RegisterRoutine( nodeName, routine );
                }
            }


        /// <summary>
        /// Задать рутину для всех вершин графа
        /// </summary>
        /// <param name="routine">Накладываемая рутина</param>
        public void RegisterRoutineInAllNodes(Routine routine)
        {
            if (routine == null)
                throw new ArgumentNullException("Передана пустая рутина");

            foreach (CoreName name in this.nodeList.Keys)
            {
                RegisterRoutine(name, routine);
            }
        }


        /// <summary>
        /// Инициализировать рутины всех вершин
        /// </summary>
        private void InitializeRoutineInAllNodes()
            {

                Logger.Instance.Clear(); // ?????????????

            //Инициализируем рутины всех вершин
            foreach ( Node node in this.nodeList.Values )
                {
                node.InitializeRoutine();
                }
            //Выполняем секцию Initial у всех рутин
            foreach ( Node node in this.nodeList.Values )
                {
                node.DoRoutineInitialSection();
                }
            }


        /// <summary>
        /// Проверка условия окончания моделирования
        /// </summary>
        /// <param name="currSystemTime">Текущее системное время</param>
        /// <returns>True, если моделирование можно продолжать</returns>
        private delegate bool CheckEndOfModelling( double currSystemTime );


        /// <summary>
        /// Начать процесс имитации
        /// </summary>
        /// <param name="checkEndOfModelling">Проверка условия окончания моделирования</param>
        private void DoSimulate( CheckEndOfModelling checkEndOfModelling )
        {
            systemTime = 0;

            //Выполнение секций initial у всех рутин
            InitializeRoutineInAllNodes();

            //Рутина, которая получит управление
            Routine routineToExecute;

            do
            {
                routineToExecute = null;
                //Время ближайшего запланированного события
                double minTime = CommonEvent.MaxEventTime;

                //Перебираем вершины графа
                foreach ( Node node in this.nodeList.Values )
                    {
                    if ( node.NodeRoutine != null )
                        //Если это ближайшее время
                        if ( node.NodeRoutine.EventCalendar.NextEventTime < minTime &&
                            //и есть события для срабатывания
                            node.NodeRoutine.EventCalendar.HasEventToExecute )
                            {
                            minTime = node.NodeRoutine.EventCalendar.NextEventTime;
                            routineToExecute = node.NodeRoutine;
                            }
                    }

                //Если рутину для исполнения так и не нашли
                if ( routineToExecute == null )
                    break;

                //Выполняем в рутине ближайщее событие
                routineToExecute.EventCalendar.DoNextEvent();
                systemTime = routineToExecute.EventCalendar.SystemTime;
            }
            while ( checkEndOfModelling( systemTime ) );

            systemTime = -1;
        }

        
        /// <summary>
        /// Начать процесс имитации
        /// </summary>
        /// <param name="iConditions">Условия моделирования</param>
        public void DoSimulate(params ICondition[] iConditions ) //???????????????????
            {
            //Выполнение секций initial у всех рутин
            InitializeRoutineInAllNodes();

            foreach (ICondition iCondition in iConditions)
                iCondition.Initialize(this);

            this.DoSimulate( delegate( double currSystemTime )
                {
                    bool bResult = true;
                    foreach (ICondition iCondition in iConditions)
                    {
                        if (!iCondition.DoCheck(currSystemTime))
                            bResult = false;
                    }
                    return bResult;
                } );
            
            foreach (ICondition iCondition in iConditions)
                iCondition.OnTerminate();
            }



        /// <summary>
        /// Начать процесс имитации
        /// </summary>
        /// <param name="endTime">Конечное время моделирования</param>
        public void DoSimulate( double endTime )
            {
            this.DoSimulate( delegate( double currSystemTime )
                {
                    return currSystemTime < endTime;
                } );
            }

        #endregion


        #region Операции для расшифровки графа

        /// <summary>
        /// Объявить выходной полюс графа
        /// </summary>
        /// <param name="outPolusName">Имя выходного полюса</param>
        /// <param name="internalPolusName">Имя внутреннего полюса</param>
        public void DefineOutPolus( CoreName outPolusName, UniquePolusName internalPolusName )
            {
            if ( outPolusName == null )
                throw new ArgumentNullException( "Пустое имя полюса" );
            if ( internalPolusName == null )
                throw new ArgumentNullException( "Пустой имя полюса" );

            //Если выходной полюс с таким именем ранее не регистрировался
            if ( !outPolusList.ContainsKey( outPolusName ) )
                {
                outPolusList.Add( outPolusName, internalPolusName );
                }
            //Если выходной полюс с таким именем уже был зарегистрирован
            else
                {
                //Связываем выходной полюс с другим внутренним полюсом
                outPolusList[ outPolusName ] = internalPolusName;
                }
            }

        
        /// <summary>
        /// Расшифровать вершину текущего графа другим графом
        /// </summary>
        /// <param name="nodeName">Имя расшифровываемой вершины текущего графа</param>
        /// <param name="graph">Граф, который подставляется вместо расшифровываемой вершины</param>
        /// <param name="polusPairList">Список соответствий имен полюсов расшифровывамеой
        /// вершины и внешних полюсов указанного графа</param>
        public void OpenNode( CoreName nodeName, Graph graph, params CoreName[] polusPairList )
            {
            if ( nodeName == null )
                throw new ArgumentNullException( "Пустое имя вершины" );
            
            if ( graph == null )
                throw new ArgumentNullException( "Пустой граф" );

            if ( polusPairList == null )
                throw new ArgumentNullException( "Пустой список соответствия" );

            //Если в графе нет вершины с таким именем
            if ( !nodeList.ContainsKey( nodeName ) )
                throw new ArgumentException( "В графе нет вершины с именем " + nodeName.ToString() );

            //Расшифровываемая вершина
            Node decodedNode = this[ nodeName ];

            //Полюса расшифровываемой вершины
            List<Polus> decodedNodePolusList = new List<Polus>();

            //Заполняем список полюсов расшифровываемой вершины
            foreach ( Polus polus in decodedNode.Poluses )
                {
                decodedNodePolusList.Add( polus.Clone() );
                }

            //Удаляем расшифровываемую вершину
            RemoveNode( decodedNode.Name );

            //Вставляем 
            }


        #endregion

        /// <summary>
        /// Системное время
        /// </summary>
        private double systemTime;
        /// <summary>
        /// Имя графа
        /// </summary>
        private CoreName coreName;
        /// <summary>
        /// Список включенных в граф вершин
        /// </summary>
        private Dictionary<CoreName, Node> nodeList = new Dictionary<CoreName, Node>();
        /// <summary>
        /// Список выходных полюсов графа
        /// Key - Имя выходного полюса
        /// Value - Имя соответствующего внутреннего полюса
        /// </summary>
        private Dictionary<CoreName, UniquePolusName> outPolusList = new Dictionary<CoreName, UniquePolusName>();
        }

    }
