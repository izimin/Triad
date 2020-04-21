using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Дескриптор графа вида звезда
    /// </summary>
    public abstract class StarGraph : Graph
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        protected StarGraph()
            : base( new CoreName( "Неизвестный граф вида звезда" ) )
            {
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="coreName">Имя графа</param>
        protected StarGraph( CoreName coreName )
            : base( coreName )
            {
            }


        /// <summary>
        /// Протянуть ребра "по умолчанию".
        /// Ребро протягивается от первого полюса первой
        /// вершины к первому полюсу каждой следующей вершины
        /// </summary>
        public override void CompleteGraph()
            {
            for ( int i = 1; i < this.NodeCount; i++ )
                {
                AddConnection( this[ 0 ].Name, this[ 0 ][ 0 ].Name,
                               this[ i ].Name, this[ i ][ 0 ].Name );
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
    /// Дескриптор графа вида ненаправленная звезда
    /// </summary>
    public class UndirectedStarGraph : StarGraph
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public UndirectedStarGraph()
            : base( new CoreName( "Неизвестный ненаправленный граф вида звезда" ) )
            {
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="coreName">Имя графа</param>
        public UndirectedStarGraph( CoreName coreName )
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
    /// Дескриптор графа вида направленная звезда
    /// </summary>
    public class DirectedStarGraph : StarGraph
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public DirectedStarGraph()
            : base( new CoreName( "Неизвестный направленный граф вида звезда" ) )
            {
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="coreName">Имя графа</param>
        public DirectedStarGraph( CoreName coreName )
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
