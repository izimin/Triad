using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Дескриптор графа вида цепочка
    /// </summary>
    public abstract class PathGraph : Graph
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        protected PathGraph()
            : base( new CoreName( "Неизвестный цепочечный граф" ) )
            {
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="coreName">Имя графа</param>
        protected PathGraph( CoreName coreName )
            : base( coreName )
            {
            }


        /// <summary>Дополнить граф предопределенными ребрами и дугами
        /// Ребром соединяется второй полюс текущей вершины с
        /// первым полюсом следующей вершины
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
    /// Дескриптор графа вида ненаправленная цепочка
    /// </summary>
    public class UndirectedPathGraph : PathGraph
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public UndirectedPathGraph()
            : base( new CoreName( "Неизвестный ненаправленный цепочечный граф" ) )
            {
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="coreName">Имя графа</param>
        public UndirectedPathGraph( CoreName coreName )
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
    /// Дескриптор графа вида направленная цепочка
    /// </summary>
    public class DirectedPathGraph : PathGraph
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public DirectedPathGraph()
            : base( new CoreName( "Неизвестный направленный цепочечный граф" ) )
            {
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="coreName">Имя графа</param>
        public DirectedPathGraph( CoreName coreName )
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
