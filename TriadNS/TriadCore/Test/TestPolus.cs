using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {/*
    /// <summary>
    /// Тестирование полюса
    /// </summary>
    public class TestPolus : TestCommon
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public TestPolus()
            {
            this.OnTest += testConstructor;
            this.OnTest += testAddRemoveInputArc;
            this.OnTest += testAddRemoveOutputArc;
            this.OnTest += testRemoveAllArcs;
            this.OnTest += testHasAnyArcs;
            this.OnTest += testUniteWith;
            this.OnTest += testIntersectWith;
            this.OnTest += testClone;
            }


        /// <summary>
        /// Тестирование конструктора полюса
        /// </summary>
        private void testConstructor( object sender, EventArgs e )
            {
            //Проверка стандартной ситуации
            CoreName coreName = new CoreName( "a" );
            Node nodeBase = new Node( coreName );

            Polus p = new Polus( coreName, nodeBase );
            
            //Проверка, сохранилась ли базовая вершина
            if ( p.BaseNode != nodeBase )
                {
                throw new TestFailedException();
                }
            //Проверка, сохранилось ли имя полюса
            if ( p.Name != coreName )
                {
                throw new TestFailedException();
                }
            }


        /// <summary>
        /// Тестирование добавления и удаления входных дуг у полюса
        /// </summary>
        private void testAddRemoveInputArc( object sender, EventArgs e )
            {
            CoreName nameA = new CoreName( "a" );
            CoreName nameB = new CoreName( "b" );
            Node baseNodeA = new Node( nameA );
            Node baseNodeB = new Node( nameB );

            //Объявляем два полюса из одной вершины
            Polus p1 = new Polus( nameA, baseNodeA );
            Polus p2 = new Polus( nameB, baseNodeA );
            
            //Проверяем стандартное добавление входной дуги
            p1.AddInputArc( p2 );
            if ( p1.TargetInputPoluses.Count != 1 )
                {
                throw new TestFailedException();
                }
            if ( p1.TargetInputPoluses[ 0 ] != nameB )
                {
                throw new TestFailedException();
                }
            
            //Добавляем такую же дугу
            p1.AddInputArc( p2 );
            //Дуга не должна продублироваться
            if ( p1.TargetInputPoluses.Count != 1 )
                {
                throw new TestFailedException();
                }

            //Пусть теперь дуга, отличается только именем родительской вершины
            p2 = new Polus( nameB, baseNodeB );
            p1.AddInputArc( p2 );
            //Теперь дуга должна добавиться
            if ( p1.TargetInputPoluses.Count != 2 )
                {
                throw new TestFailedException();
                }

            //Добавим дугу, соединяющую полюс с самим собой
            p1.AddInputArc( p1 );
            //Такие петли разрешены
            if ( p1.TargetInputPoluses.Count != 3 )
                {
                throw new TestFailedException();
                }

            //Стандартное удаление дуги
            p1.RemoveInputArc( nameB, baseNodeA.Name );
            //Удалиться должна только одна дуга
            if ( p1.TargetInputPoluses.Count != 2 )
                {
                throw new TestFailedException();
                }
            //Удаляем дугу из одноименного полюса, но из другой вершины
            p1.RemoveInputArc( nameB, baseNodeB.Name );
            //Удалиться должна только одна дуга
            if ( p1.TargetInputPoluses.Count != 1 )
                {
                throw new TestFailedException();
                }

            //Остаться должна только дуга, соединяющая полюс сам с собой
            if ( p1.TargetInputPoluses[ 0 ] != nameA )
                {
                throw new TestFailedException();
                }

            //Удаляем последнюю дугу
            p1.RemoveInputArc( nameA, baseNodeA.Name );
            if ( p1.TargetInputPoluses.Count != 0 )
                {
                throw new TestFailedException();
                }

            //Удаляем несуществующие дуги
            p1.RemoveInputArc( nameA, baseNodeA.Name );
            p1.RemoveInputArc( nameB, baseNodeA.Name );
            }


        /// <summary>
        /// Тестирование добавления и удаления входных дуг
        /// </summary>
        private void testAddRemoveOutputArc( object sender, EventArgs e )
            {
            CoreName nameA = new CoreName( "a" );
            CoreName nameB = new CoreName( "b" );
            Node baseNodeA = new Node( nameA );
            Node baseNodeB = new Node( nameB );

            //Объявляем два полюса из одной вершины
            Polus p1 = new Polus( nameA, baseNodeA );
            Polus p2 = new Polus( nameB, baseNodeA );

            //Проверяем стандартное добавление входной дуги
            p1.AddOutputArc( p2 );
            if ( p1.TargetOutputPoluses.Count != 1 )
                {
                throw new TestFailedException();
                }
            if ( p1.TargetOutputPoluses[ 0 ] != nameB )
                {
                throw new TestFailedException();
                }

            //Добавляем такую же дугу
            p1.AddOutputArc( p2 );
            //Дуга не должна продублироваться
            if ( p1.TargetOutputPoluses.Count != 1 )
                {
                throw new TestFailedException();
                }

            //Пусть теперь дуга, отличается только именем родительской вершины
            p2 = new Polus( nameB, baseNodeB );
            p1.AddOutputArc( p2 );
            //Теперь дуга должна добавиться
            if ( p1.TargetOutputPoluses.Count != 2 )
                {
                throw new TestFailedException();
                }

            //Добавим дугу, соединяющую полюс с самим собой
            p1.AddOutputArc( p1 );
            //Такие петли разрешены
            if ( p1.TargetOutputPoluses.Count != 3 )
                {
                throw new TestFailedException();
                }

            //Стандартное удаление дуги
            p1.RemoveOutputArc( nameB, baseNodeA.Name );
            //Удалиться должна только одна дуга
            if ( p1.TargetOutputPoluses.Count != 2 )
                {
                throw new TestFailedException();
                }
            //Удаляем дугу из одноименного полюса, но из другой вершины
            p1.RemoveOutputArc( nameB, baseNodeB.Name );
            //Удалиться должна только одна дуга
            if ( p1.TargetOutputPoluses.Count != 1 )
                {
                throw new TestFailedException();
                }

            //Остаться должна только дуга, соединяющая полюс сам с собой
            if ( p1.TargetOutputPoluses[ 0 ] != nameA )
                {
                throw new TestFailedException();
                }

            //Удаляем последнюю дугу
            p1.RemoveOutputArc( nameA, baseNodeA.Name );
            if ( p1.TargetOutputPoluses.Count != 0 )
                {
                throw new TestFailedException();
                }

            //Удаляем несуществующие дуги
            p1.RemoveOutputArc( nameA, baseNodeA.Name );
            p1.RemoveOutputArc( nameB, baseNodeA.Name );
            }

        
        /// <summary>
        /// Тестирование удаления всех дуг
        /// </summary>
        private void testRemoveAllArcs( object sender, EventArgs e )
            {
            CoreName a1 = new CoreName( "a" );
            CoreName a2 = new CoreName( "b" );
            Node baseNode = new Node( a1 );
            Polus p = new Polus( a1, baseNode );
            Polus p1 = new Polus( a1, baseNode );
            Polus p2 = new Polus( a2, baseNode );
            p.AddInputArc( p1 );
            p.AddInputArc( p2 );
            
            if ( p.TargetInputPoluses.Count != 2 )
                {
                throw new TestFailedException();
                }
            p.AddOutputArc( p1 );
            p.AddOutputArc( p2 );

            if ( p.TargetOutputPoluses.Count != 2 )
                {
                throw new TestFailedException();
                }
            p1.AddInputArc( p );
            p2.AddOutputArc( p );

            p.RemoveAllArcs();

            if ( p.TargetInputPoluses.Count != 0 )
                {
                throw new TestFailedException();
                }
            if ( p.TargetOutputPoluses.Count != 0 )
                {
                throw new TestFailedException();
                }
            if ( p1.HasArcs() )
                throw new TestFailedException();
            if ( p2.HasArcs() )
                throw new TestFailedException();

            p.RemoveAllArcs();
            }


        private void testHasAnyArcs( object sender, EventArgs e )
            {
            CoreName a1 = new CoreName( "a" );
            CoreName a2 = new CoreName( "b" );
            Node baseNode = new Node( a1 );
            Polus p = new Polus( a1, baseNode );
            Polus p1 = new Polus( a1, baseNode );
            Polus p2 = new Polus( a2, baseNode );
            if ( p.HasArcs() )
                {
                throw new TestFailedException();
                }
            p.AddInputArc( p1 );
            if ( !p.HasArcs() )
                {
                throw new TestFailedException();
                }
            p.RemoveInputArc( a1, baseNode.Name );
            if ( p.HasArcs() )
                {
                throw new TestFailedException();
                }
            p.AddOutputArc( p2 );
            if ( !p.HasArcs() )
                {
                throw new TestFailedException();
                }
            p.AddInputArc( p1 );
            if ( !p.HasArcs() )
                {
                throw new TestFailedException();
                }
            }
        
        private void testUniteWith( object sender, EventArgs e )
            {
            CoreName a1 = new CoreName( "a" );
            CoreName a2 = new CoreName( "b" );
            CoreName a3 = new CoreName( "c" );
            Node baseNode = new Node( a1 );
            Polus polus1 = new Polus( a1, baseNode );
            Polus polus2 = new Polus( a1, baseNode );
            Polus p1 = new Polus( a1, baseNode );
            Polus p2 = new Polus( a2, baseNode );
            Polus p3 = new Polus( a3, baseNode );
            polus1.AddInputArc( p1 );
            polus2.AddInputArc( p1 );
            polus2.AddInputArc( p2 );
            polus1.AddOutputArc( p1 );
            polus2.AddOutputArc( p1 );
            polus2.AddOutputArc( p3 );
            polus1.Add( polus2 );
            if ( polus1.TargetInputPoluses.Count != 2 )
                {
                throw new TestFailedException();
                }
            if ( polus1.TargetOutputPoluses.Count != 2 )
                {
                throw new TestFailedException();
                }
            polus1.AddInputArc( p3 );
            if ( polus2.TargetOutputPoluses.Count != 2 )
                {
                throw new TestFailedException();
                }
            }


        private void testIntersectWith( object sender, EventArgs e )
            {
            CoreName a1 = new CoreName( "a" );
            CoreName a2 = new CoreName( "b" );
            CoreName a3 = new CoreName( "c" );
            CoreName a4 = new CoreName( "d" );
            Node baseNode = new Node( a1 );
            Polus p1 = new Polus( a1, baseNode );
            Polus p2 = new Polus( a2, baseNode );

            Polus t1 = new Polus( a1, baseNode );
            Polus t2 = new Polus( a2, baseNode );
            Polus t3 = new Polus( a3, baseNode );
            Polus t4 = new Polus( a4, baseNode );

            p1.AddInputArc( t1 );
            p1.AddInputArc( t2 );
            p1.AddInputArc( t3 );
            p1.AddOutputArc( t3 );
            p1.AddOutputArc( t4 );

            p2.AddInputArc( t3 );
            p2.AddInputArc( t4 );
            p2.AddOutputArc( t1 );
            p2.AddOutputArc( t2 );
            p2.AddOutputArc( t3 );

            p1.Multiply( p2 );
            if ( p1.TargetInputPoluses.Count != 1 )
                {
                throw new TestFailedException();
                }
            if ( !p1.TargetInputPoluses[ 0 ].Equals( a3 ) )
                {
                throw new TestFailedException();
                }

            if ( p1.TargetOutputPoluses.Count != 1 )
                {
                throw new TestFailedException();
                }
            if ( !p1.TargetOutputPoluses[ 0 ].Equals( a3 ) )
                {
                throw new TestFailedException();
                }

            p1.RemoveAllArcs();
            p2.Multiply( p1 );
            if ( p2.HasArcs() )
                {
                throw new TestFailedException();
                }

            p1.AddInputArc( t1 );
            p1.AddInputArc( t2 );
            p1.AddInputArc( t3 );
            p1.AddOutputArc( t3 );
            p1.AddOutputArc( t4 );

            p1.Multiply( p2 );
            if ( p1.HasArcs() )
                {
                throw new TestFailedException();
                }
            }


        private void testClone( object sender, EventArgs e )
            {
            Polus p1 = new Polus( new CoreName( "a" ), new Node( "a" ) );
            Polus t1 = new Polus( new CoreName( "a" ), new Node( "a" ) );
            Polus t2 = new Polus( new CoreName( "a" ), new Node( "a" ) );
            Polus p2 = p1.Clone();
            p1.AddInputArc( t1 );
            p1.AddOutputArc( t2 );
            if ( p2.HasArcs() )
                {
                throw new TestFailedException();
                }
            }
        
        }*/
    }
