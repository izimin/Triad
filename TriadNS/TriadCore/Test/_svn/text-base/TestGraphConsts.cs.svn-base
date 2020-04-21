using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {/*
    /// <summary>
    /// Тестирование графовых констант
    /// </summary>
    class TestGraphConsts : TestCommon
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public TestGraphConsts()
            {
            this.OnTest += testCicleGraph;
            this.OnTest += testPathGraph;
            this.OnTest += testStarGraph;
            }


        /// <summary>
        /// Тестирование циклического графа
        /// </summary>
        private void testCicleGraph( object sender, EventArgs e )
            {
            //Замыкание пустого графа
            CicleGraph a = new UndirectedCicleGraph();
            a.CompleteGraph();

            //Если у вершин не объявлены полюса
            a.DeclareNode( "a" );
            try
                {
                a.CompleteGraph();
                throw new TestFailedException();
                }
            catch ( ArgumentOutOfRangeException )
            { }

            //Проверка стандартной ситуации, когда полюса неиндексированные и граф ненаправленный
            a.DeclarePolusInAllNodes( "p" );
            a.DeclarePolusInAllNodes( "c" );
            a.CompleteGraph();
            if ( !a[ "a" ][ "p" ].HasArcs() )
                throw new TestFailedException();
            if ( !a[ "a" ][ "c" ].HasArcs() )
                throw new TestFailedException();
            if ( !a[ "a" ][ "p" ].TargetInputPoluses[ 0 ].EqualsWith( "c" ) )
                throw new TestFailedException();
            if ( !a[ "a" ][ "c" ].TargetInputPoluses[ 0 ].EqualsWith( "p" ) )
                throw new TestFailedException();
            if ( !a[ "a" ][ "p" ].TargetOutputPoluses[ 0 ].EqualsWith( "c" ) )
                throw new TestFailedException();
            if ( !a[ "a" ][ "c" ].TargetOutputPoluses[ 0 ].EqualsWith( "p" ) )
                throw new TestFailedException();

            //Проверка стандартной ситуации, когда полюса индексированные и граф направленный
            a = new DirectedCicleGraph();
            a.DeclareNodeArray( "a", 2 );
            a.DeclarePolusArrayInAllNodes( "p", 2 );
            a.CompleteGraph();
            if ( !a[ "a", 0 ][ "p", 0 ].HasArcs() )
                throw new TestFailedException();
            if ( !a[ "a", 1 ][ "p", 0 ].HasArcs())
                throw new TestFailedException();
            if ( !a[ "a", 0 ][ "p", 1 ].TargetOutputPoluses[ 0 ].Equals(  new CoreName( "p", 0 ) ) )
                throw new TestFailedException();
            if ( a[ "a", 0 ][ "p", 1 ].TargetInputPoluses.Count != 0 )
                throw new TestFailedException();
            if ( a[ "a", 0 ][ "p", 0 ].TargetOutputPoluses.Count != 0 )
                throw new TestFailedException();
            if ( !a[ "a", 0 ][ "p", 0 ].TargetInputPoluses[ 0 ].Equals( new CoreName( "p", 1 ) ) )
                throw new TestFailedException();
            }


        /// <summary>
        /// Тестирование графа-цепочки
        /// </summary>
        private void testPathGraph( object sender, EventArgs e )
            {
            //Замыкание пустого графа
            Graph g = new DirectedPathGraph();
            g.CompleteGraph();

            //Если у вершин не объявлены полюса
            g.DeclareNode( "a" );
            g.DeclareNode( "b" );
            try
                {
                g.CompleteGraph();
                throw new TestFailedException();
                }
            catch ( ArgumentException )
            { }

            //Проверка стандартной ситуации, когда полюса неиндексированные и граф направленный
            g.DeclarePolusInAllNodes( "p" );
            g.DeclarePolusInAllNodes( "c" );
            g.CompleteGraph();
            if ( g[ "a" ][ "p" ].TargetInputPoluses.Count != 0 )
                throw new TestFailedException();
            if ( g[ "a" ][ "p" ].TargetOutputPoluses.Count != 0 )
                throw new TestFailedException();
            if ( g[ "a" ][ "c" ].TargetInputPoluses.Count != 0 )
                throw new TestFailedException();            
            if ( !g[ "a" ][ "c" ].TargetOutputPoluses[ 0 ].EqualsWith( "p" ) )
                throw new TestFailedException();
            
            if ( g[ "b" ][ "p" ].TargetOutputPoluses.Count != 0 )
                throw new TestFailedException();
            if ( !g[ "b" ][ "p" ].TargetInputPoluses[ 0 ].EqualsWith( "c" ) )
                throw new TestFailedException();
            if ( g[ "b" ][ "c" ].TargetInputPoluses.Count != 0 )
                throw new TestFailedException();
            if ( g[ "b" ][ "c" ].TargetOutputPoluses.Count != 0 )
                throw new TestFailedException();

            //Проверка стандартной ситуации, когда полюса индексированные и граф ненаправленный
            g = new UndirectedPathGraph();
            g.DeclareNode( "a" );
            g.DeclareNode( "b" );
            g.DeclarePolusInAllNodes( "p" );
            g.DeclarePolusInAllNodes( "c" );
            g.CompleteGraph();

            if ( g[ "a" ][ "p" ].TargetInputPoluses.Count != 0 )
                throw new TestFailedException();
            if ( g[ "a" ][ "p" ].TargetOutputPoluses.Count != 0 )
                throw new TestFailedException();
            if ( !g[ "a" ][ "c" ].TargetInputPoluses[ 0 ].EqualsWith( "p" ) )
                throw new TestFailedException();
            if ( !g[ "a" ][ "c" ].TargetOutputPoluses[ 0 ].EqualsWith( "p" ) )
                throw new TestFailedException();

            if ( !g[ "b" ][ "p" ].TargetOutputPoluses[ 0 ].EqualsWith( "c" ) )
                throw new TestFailedException();
            if ( !g[ "b" ][ "p" ].TargetInputPoluses[ 0 ].EqualsWith( "c" ) )
                throw new TestFailedException();
            if ( g[ "b" ][ "c" ].TargetInputPoluses.Count != 0 )
                throw new TestFailedException();
            if ( g[ "b" ][ "c" ].TargetOutputPoluses.Count != 0 )
                throw new TestFailedException();   
            }


        /// <summary>
        /// Тестирование графа-звезды
        /// </summary>
        private void testStarGraph( object sender, EventArgs e )
            {
            //Замыкание пустого графа
            Graph g = new DirectedStarGraph();
            g.CompleteGraph();

            //Если у вершин не объявлены полюса
            g.DeclareNode( "a" );
            g.DeclareNode( "b" );
            g.DeclareNode( "c" );
            try
                {
                g.CompleteGraph();
                throw new TestFailedException();
                }
            catch ( ArgumentException )
            { }

            //Проверка стандартной ситуации, когда полюса неиндексированные и граф направленный            
            g[ "a" ].DeclarePolus( "s" );
            g.DeclarePolusInAllNodes( "p" );
            g.CompleteGraph();
            
            if ( !g[ "a" ][ "s" ].HasArcs() )
                throw new TestFailedException();
            if ( g[ "a" ][ "p" ].HasArcs() )
                throw new TestFailedException();
            if ( !g[ "b" ][ "p" ].HasArcs() )
                throw new TestFailedException();
            if ( !g[ "c" ][ "p" ].HasArcs() )
                throw new TestFailedException();

            if ( g[ "a" ][ "s" ].TargetOutputPoluses.Count != 2 )
                throw new TestFailedException();
            if ( !g[ "a" ][ "s" ].TargetOutputPoluses[ 0 ].EqualsWith( "p" ) )
                throw new TestFailedException();
            if ( g[ "a" ][ "s" ].TargetInputPoluses.Count != 0 )
                throw new TestFailedException();

            if ( !g[ "b" ][ "p" ].TargetInputPoluses[ 0 ].EqualsWith( "s" ) )
                throw new TestFailedException();
            if ( g[ "b" ][ "p" ].TargetOutputPoluses.Count != 0 )
                throw new TestFailedException();
            if ( !g[ "c" ][ "p" ].TargetInputPoluses[ 0 ].EqualsWith( "s" ) )
                throw new TestFailedException();
            if ( g[ "c" ][ "p" ].TargetOutputPoluses.Count != 0 )
                throw new TestFailedException();

            //Проверка стандартной ситуации, когда полюса индексированные и граф ненаправленный            
            g = new UndirectedStarGraph();
            g.DeclareNodeArray( "a", 3 );
            g[ "a", 0 ].DeclarePolus( "s" );
            g.DeclarePolusInAllNodes( "p" );
            g.CompleteGraph();
            
            if ( !g[ "a", 0 ][ "s" ].HasArcs() )
                throw new TestFailedException();
            if ( g[ "a", 0 ][ "p" ].HasArcs() )
                throw new TestFailedException();
            if ( !g[ "a", 1 ][ "p" ].HasArcs() )
                throw new TestFailedException();
            if ( !g[ "a", 2 ][ "p" ].HasArcs() )
                throw new TestFailedException();

            if ( g[ "a", 0 ][ "s" ].TargetOutputPoluses.Count != 2 )
                throw new TestFailedException();
            if ( !g[ "a", 0 ][ "s" ].TargetOutputPoluses[ 0 ].EqualsWith( "p" ) )
                throw new TestFailedException();
            if ( g[ "a", 0 ][ "s" ].TargetInputPoluses.Count != 2 )
                throw new TestFailedException();
            if ( !g[ "a", 0 ][ "s" ].TargetInputPoluses[ 0 ].EqualsWith( "p" ) )
                throw new TestFailedException();

            if ( !g[ "a", 1 ][ "p" ].TargetInputPoluses[ 0 ].EqualsWith( "s" ) )
                throw new TestFailedException();
            if ( !g[ "a", 1 ][ "p" ].TargetOutputPoluses[ 0 ].EqualsWith( "s" ) )
                throw new TestFailedException();
            if ( !g[ "a", 2 ][ "p" ].TargetInputPoluses[ 0 ].EqualsWith( "s" ) )
                throw new TestFailedException();
            if ( !g[ "a", 2 ][ "p" ].TargetOutputPoluses[ 0 ].EqualsWith( "s" ) )
                throw new TestFailedException();
            }
        }*/
    }
