using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {/*
    /// <summary>
    /// Класс для тестирования вершины
    /// </summary>
    public class TestNode : TestCommon
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public TestNode()
            {
            this.OnTest += testConstructor;
            this.OnTest += testIndexer;
            this.OnTest += testDeclareOperations;
            this.OnTest += testHasPoluses;
            this.OnTest += testRemoveAllPoluses;
            this.OnTest += testAddArc;
            this.OnTest += testUniteWith;
            this.OnTest += testSubtractWith;
            this.OnTest += testIntersectWith;
            this.OnTest += testClone;
            }


        private void testConstructor( object sender, EventArgs e )
            {
            CoreName coreName = new CoreName( "a" );
            Node node = new Node( coreName );
            if ( node.Name != coreName )
                {
                throw new TestFailedException();
                }
            node = new Node( "a" );
            if ( !node.Name.Equals( coreName ) )
                {
                throw new TestFailedException();
                }
            node = new Node( "a", 0 );
            if ( !node.Name.Equals( new CoreName( "a", 0 ) ) )
                {
                throw new TestFailedException();
                }
            node = new Node( "a", -1 );
            if ( !node.Name.Equals( new CoreName( "a", -1 ) ) )
                {
                throw new TestFailedException();
                }
            }

        private void testIndexer( object sender, EventArgs e )
            {
            Node node = new Node( "a" );
            node.DeclarePolus( "p" );

            node.DeclarePolusArray( "p", 10 );
            try
                {
                Polus p = node[ new CoreName( "d" ) ];
                throw new TestFailedException();
                }
            catch ( ArgumentException )
            { }

            //Обращение по индексу
            node.RemoveAllPoluses();
            try
                {
                Polus p = node[ 0 ];
                throw new TestFailedException();
                }
            catch ( ArgumentOutOfRangeException )
            { }

            node.DeclarePolus( "p" );
            node.DeclarePolus( "a" );
            node.DeclarePolusArray( "a", 10 );

            if ( !node[ 0 ].Name.Equals( new CoreName( "p" ) ) )
                {
                throw new TestFailedException();
                }
            if ( !node[ 1 ].Name.Equals( new CoreName( "a" ) ) )
                {
                throw new TestFailedException();
                }
            if ( !node[ 2 ].Name.Equals( new CoreName( "a", 0 ) ) )
                {
                throw new TestFailedException();
                }
            if ( !node[ 11 ].Name.Equals( new CoreName( "a", 9 ) ) )
                {
                throw new TestFailedException();
                }

            try
                {
                Polus p = node[ -1 ];
                throw new TestFailedException();
                }
            catch ( ArgumentOutOfRangeException )
            { }

            try
                {
                Polus p = node[ 12 ];
                throw new TestFailedException();
                }
            catch ( ArgumentOutOfRangeException )
            { }

            node.RemoveAllPoluses();
            node.DeclarePolus( "a" );
            node.DeclarePolusArray( "a", 10 );
            if ( !node[ 0 ].Name.Equals( new CoreName( "a" ) ) )
                throw new TestFailedException();

            }

        private void testDeclareOperations( object sender, EventArgs e )
            {
            Node node = new Node( "a" );
            node.DeclarePolus( "p" );
            if ( node.PolusNameList.Count != 1 )
                {
                throw new TestFailedException();
                }

            node.DeclarePolus( "p" );
            if ( node.PolusNameList.Count != 1 )
                {
                throw new TestFailedException();
                }

            node.DeclarePolusArray( "p", 0 );
            node.DeclarePolusArray( "p", -1 );

            Polus p;
            
            try
                {
                p = node[ "p", 0 ];
                throw new TestFailedException();
                }
            catch ( ArgumentException )
            { }
            
            node.DeclarePolusArray( "p", 10 );
            
            if ( node.PolusNameList.Count != 11 )
                {
                throw new TestFailedException();
                }

            try
                {
                p = node[ "p", 10 ];
                throw new TestFailedException();
                }
            catch ( ArgumentException )
            { }

            }

        private void testHasPoluses( object sender, EventArgs e )
            {
            Node node = new Node( "a" );
            if ( node.HasPoluses() )
                {
                throw new TestFailedException();
                }
            node.DeclarePolus( "p" );
            if ( !node.HasPoluses() )
                {
                throw new TestFailedException();
                }
            }

        private void testRemoveAllPoluses( object sender, EventArgs e )
            {
            Node node = new Node( "a" );
            node.RemoveAllPoluses();
            node.DeclarePolus( "p" );
            node.RemoveAllPoluses();
            if ( node.PolusNameList.Count != 0 )
                {
                throw new TestFailedException();
                }
            node.DeclarePolusArray( "a", 10 );
            node.RemoveAllPoluses();
            if ( node.PolusNameList.Count != 0 )
                {
                throw new TestFailedException();
                }
            }

        private void testAddArc( object sender, EventArgs e )
            {
            Node node1 = new Node( "a" );
            node1.DeclarePolus( "p1" );
            Node node2 = new Node( "b" );
            node2.DeclarePolus( "p2" );

            node1.AddArc( node1[ "p1" ], node2[ "p2" ] );
            if ( node1[ "p1" ].TargetOutputPoluses.Count != 1 )
                {
                throw new TestFailedException();
                }
            if ( !node1[ "p1" ].TargetOutputPoluses[ 0 ].Equals( new CoreName( "p2" ) )  )
                {
                throw new TestFailedException();
                }
            if ( node2[ "p2" ].TargetInputPoluses.Count != 1 )
                {
                throw new TestFailedException();
                }
            if ( !node2[ "p2" ].TargetInputPoluses[ 0 ].Equals( new CoreName( "p1" ) ) )
                {
                throw new TestFailedException();
                }

            Node node3 = new Node( "c" );
            node3.DeclarePolus( "p2" );
            node1.AddArc( node1[ "p1" ], node3[ "p2" ] );
            if ( node1[ "p1" ].TargetOutputPoluses.Count != 2 )
                throw new TestFailedException();
            }

        private void testUniteWith( object sender, EventArgs e )
            {
            Node node1 = new Node( "a" );
            Node node2 = new Node( "b" );

            node1.DeclarePolus( "p1" );
            node2.DeclarePolus( "p1" );
            node2.DeclarePolus( "p2" );

            node1.Add( node2 );

            if ( node1.PolusNameList.Count != 2 )
                {
                throw new TestFailedException();
                }
            if ( !node1.PolusNameList.Contains( new CoreName( "p1" ) ) ||
                !node1.PolusNameList.Contains( new CoreName( "p2" ) ) )
                {
                throw new TestFailedException();
                }

            node2[ "p2" ].AddInputArc( node1[ "p1" ] );
            if ( node1[ "p2" ].TargetInputPoluses.Count != 0 )
                {
                throw new TestFailedException();
                }

            node1.Add( node1 );
            if ( node1.PolusNameList.Count != 2 )
                {
                throw new TestFailedException();
                }

            node2.RemoveAllPoluses();
            node2.DeclarePolus( "p1" );

            node2.RemoveAllPoluses();
            node2.Add( node1 );
            if ( node2.PolusNameList.Count != 2 )
                {
                throw new TestFailedException();
                }
            }


        private void testSubtractWith( object sender, EventArgs e )
            {
            Node n1 = new Node( "a" );
            Node n2 = new Node( "b" );
            n1.DeclarePolusArray( "p", 10 );
            n2.DeclarePolusArray( "p", 9 );

            n1.Subtract( n2 );
            if ( n1.PolusNameList.Count != 1 )
                {
                throw new TestFailedException();
                }
            if ( !n1.PolusNameList[ 0 ].Equals( new CoreName( "p", 9 ) ) )
                {
                throw new TestFailedException();
                }

            n1.RemoveAllPoluses();
            n2.Subtract( n1 );
            if ( n2.PolusNameList.Count != 9 )
                {
                throw new TestFailedException();
                }

            n1 = n2.Clone();
            n1.Subtract( n2 );
            if ( n1.PolusNameList.Count != 0 )
                {
                throw new TestFailedException();
                }


            n1.RemoveAllPoluses();
            n2.RemoveAllPoluses();
            n1.DeclarePolus( "p" );
            n1.DeclarePolus( "g" );
            n1.AddArc( n1[ "p" ], n1[ "g" ] );
            Node n3 = new Node( "c" );
            n3.DeclarePolus( "p" );
            n3.AddArc( n3[ "p" ], n1[ "p" ] );
            n2.DeclarePolus( "p" );
            n1.Subtract( n2 );
            if ( n3[ "p" ].HasArcs() )
                throw new TestFailedException();
            if ( n1.PolusNameList.Count != 1 )
                throw new TestFailedException();
            if ( n1[ "g" ].HasArcs() )
                throw new TestFailedException();
            }


        private void testIntersectWith( object sender, EventArgs e )
            {
            Node n1 = new Node( "a" );
            Node n2 = new Node( "a" );

            n1.DeclarePolusArray( "p", 1 );
            n2.DeclarePolusArray( "p", 5 );
            n1.Multiply( n2 );
            if ( n1.PolusNameList.Count != 1 )
                {
                throw new TestFailedException();
                }
            if ( !n1.PolusNameList[ 0 ].Equals( new CoreName( "p", 0 ) ) )
                {
                throw new TestFailedException();
                }

            n2.RemoveAllPoluses();
            n1.Multiply( n2 );
            if ( n1.PolusNameList.Count != 0 )
                {
                throw new TestFailedException();
                }
            n2.RemoveAllPoluses();
            n1.Multiply( n2 );
            }


        private void testClone( object sender, EventArgs e )
            {
            Node n1 = new Node( "a" );
            n1.DeclarePolus( "p" );
            Node n2 = n1.Clone();
            n2.DeclarePolus( "p1" );
            if ( n1.PolusNameList.Count != 1 )
                {
                throw new TestFailedException();
                }
            n2[ "p" ].AddInputArc( n2[ "p1" ] );
            if ( n1[ "p" ].TargetInputPoluses.Count != 0 )
                {
                throw new TestFailedException();
                }

            }

        }*/
    }
