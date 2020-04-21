#pragma warning disable 1591
using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
{
    /// <summary>
    /// Интерфейс стека для генерации структурных выражений
    /// </summary>
    public interface IStructExprStack
    {
        void PushGraph(Graph graph);
        void PushEmptyGraph();
        void PushEmptyUndirectPathGraph();
        void PushEmptyDirectPathGraph();
        void PushEmptyUndirectCicleGraph();
        void PushEmptyDirectCicleGraph();
        void PushEmptyUndirectStarGraph();
        void PushEmptyDirectStarGraph();
        Graph PopGraph();
        Graph FirstInStackGraph { get; }
        Graph SecondInStackGraph { get; }
    }

    /// <summary>
    /// Стек для генерации структурных выражений
    /// </summary>
    public class StructExprStack : IStructExprStack
    {
        private List<Graph> stack = new List<Graph>();

        /// <summary>
        /// Добавить в стек новый граф
        /// </summary>
        /// <param name="graph">Добавляемый граф</param>
        public void PushGraph(Graph graph)
        {
            this.stack.Add(graph);
        }


        /// <summary>
        /// Добавить в стек пустой граф
        /// </summary>
        public void PushEmptyGraph()
        {
            this.stack.Add(new Graph());
        }


        /// <summary>
        /// Добавить в стек пустой граф - ненаправленную цепочку
        /// </summary>
        public void PushEmptyUndirectPathGraph()
        {
            this.stack.Add(new UndirectedPathGraph());
        }

        /// <summary>
        /// Добавить в стек пустой граф - направленную цепочку
        /// </summary>
        public void PushEmptyDirectPathGraph()
        {
            this.stack.Add(new DirectedPathGraph());
        }


        /// <summary>
        /// Добавить в стек пустой граф - ненаправленное кольцо
        /// </summary>
        public void PushEmptyUndirectCicleGraph()
        {
            this.stack.Add(new UndirectedCicleGraph());
        }


        /// <summary>
        /// Добавить в стек пустой граф - направленное кольцо
        /// </summary>
        public void PushEmptyDirectCicleGraph()
        {
            this.stack.Add(new DirectedCicleGraph());
        }


        /// <summary>
        /// Добавить в стек пустой граф - ненаправленную звезду
        /// </summary>
        public void PushEmptyUndirectStarGraph()
        {
            this.stack.Add(new UndirectedStarGraph());
        }


        /// <summary>
        /// Добавить в стек пустой граф - направленную звезду
        /// </summary>
        public void PushEmptyDirectStarGraph()
        {
            this.stack.Add(new DirectedStarGraph());
        }


        /// <summary>
        /// Удалить граф с вершины стека
        /// </summary>
        public Graph PopGraph()
        {
            int topGraphIndex = this.stack.Count - 1;
            Graph topGraph = this.stack[topGraphIndex];
            this.stack.RemoveAt(topGraphIndex);
            return topGraph;
        }


        /// <summary>
        /// Граф на вершине
        /// </summary>
        public Graph FirstInStackGraph
        {
            get
            {
                return this.stack[this.stack.Count - 1];
            }
        }

        /// <summary>
        /// Граф, второй по счету от вершины
        /// </summary>
        public Graph SecondInStackGraph
        {
            get
            {
                return this.stack[this.stack.Count - 2];
            }
        }
    }

    /// <summary>
    /// Обобщенный класс для создания структуры
    /// </summary>
    public abstract class GraphBuilder : StructExprStack
        {
       
        /// <summary>
        /// Отладочная печать
        /// </summary>
        /// <param name="message">Сообщение</param>
        protected void PrintMessage(object message)
        {
            if (message != null)
            {
                Console.WriteLine("Отладочная печать: {0} \t {1} ", this, message);
                Logger.Instance.AddRecord(new LoggerRecord(-1, this.ToString(), message.ToString()));
            }
        }

        /// <summary>
        /// Построить структуру
        /// </summary>
        /// <returns>Граф, представляющий всю структуру</returns>
        public abstract Graph Build();
        }
}
