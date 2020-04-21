using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Дескриптор графа вида кольцо
    /// </summary>
    public abstract class CicleGraph : Graph
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        protected CicleGraph()
            : base( new CoreName( "Неизвестный циклический граф" ) )
            {
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="coreName">Имя графа</param>
        protected CicleGraph( CoreName coreName )
            : base( coreName )
            {
            }


        /// <summary>
        /// Протянуть ребра "по умолчанию".
        /// Ребро протягивается от второго полюса каждой вершины
        /// к первому полюсу следующей вершины
        /// </summary>
        public override void CompleteGraph()
            {
            Node nodePrev = null;
            Node nodeCurr = null;

            for ( int i = 1; i < this.NodeCount; i++ )
                {
                nodePrev = this[ i - 1 ];
                nodeCurr = this[ i ];

                AddConnection( nodePrev.Name, nodePrev[ 1 ].Name,
                              nodeCurr.Name, nodeCurr[ 0 ].Name );
                }

            //Соединяем последнюю вершину с первой
            if ( this.NodeCount != 0 )
                {
                nodePrev = this[ this.NodeCount - 1 ];
                nodeCurr = this[ 0 ];
                AddConnection( nodePrev.Name, nodePrev[ 1 ].Name,
                              nodeCurr.Name, nodeCurr[ 0 ].Name );
                }
            
            base.CompleteGraph();
            }

        
        /// <summary>
        /// Установить "нужное" соединение
        /// </summary>
        /// <param name="nodeName1">Имя первой вершины</param>
        /// <param name="polusName1">Имя первого полюса</param>
        /// <param name="nodeName2">Имя второй вершины</param>
        /// <param name="polusName2">Имя второго полюса</param>
        protected virtual void AddConnection( CoreName nodeName1, CoreName polusName1, CoreName nodeName2, CoreName polusName2 )
            {
            return;
            }
        }


    /// <summary>
    /// Дескриптор графа вида ненаправленное кольцо
    /// </summary>
    public class UndirectedCicleGraph : CicleGraph
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public UndirectedCicleGraph()
            : base( new CoreName( "Неизвестный ненаправленный циклический граф" ) )
            {
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="coreName">Имя графа</param>
        public UndirectedCicleGraph( CoreName coreName )
            : base( coreName )
            {
            }


        /// <summary>
        /// Установить "нужное" соединение
        /// </summary>
        /// <param name="nodeName1">Имя первой вершины</param>
        /// <param name="polusName1">Имя первого полюса</param>
        /// <param name="nodeName2">Имя второй вершины</param>
        /// <param name="polusName2">Имя второго полюса</param>
        protected override void AddConnection( CoreName nodeName1, CoreName polusName1, CoreName nodeName2, CoreName polusName2 )
            {
            this.AddEdge( nodeName1, polusName1, nodeName2, polusName2 );
            }
        }

    
    /// <summary>
    /// Дескриптор графа вида направленное кольцо
    /// </summary>
    public class DirectedCicleGraph : CicleGraph
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public DirectedCicleGraph()
            : base ( new CoreName( "Неизвестный направленный циклический граф" ) )
            {
            }

        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="coreName">Имя графа</param>
        public DirectedCicleGraph( CoreName coreName )
            : base( coreName )
            {
            }


        /// <summary>
        /// Установить "нужное" соединение
        /// </summary>
        /// <param name="nodeName1">Имя первой вершины</param>
        /// <param name="polusName1">Имя первого полюса</param>
        /// <param name="nodeName2">Имя второй вершины</param>
        /// <param name="polusName2">Имя второго полюса</param>
        protected override void AddConnection( CoreName nodeName1, CoreName polusName1, CoreName nodeName2, CoreName polusName2 )
            {
            this.AddArc( nodeName1, polusName1, nodeName2, polusName2 );
            }
        }    

    }
