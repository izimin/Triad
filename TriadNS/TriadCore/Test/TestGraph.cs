using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {/*
    /// <summary>
    /// Класс для тестирования графа
    /// </summary>
    [TestFixture, Description( "Тестирование графа" ) ]
    public class TestGraph
        {
        /// <summary>
        /// Тестирование конструктора графа
        /// </summary>
        [Test, Description( "Тестирование конструктора графа" )]
        public void TestConstructor()
            {
            Graph graph = new Graph();
            
            graph = new Graph( new CoreName( "a" ) );

            //Созданный граф имеет нужное имя
            Assert.AreEqual( graph.Name, new CoreName( "a" ) );
            }


        /// <summary>
        /// Тестирование индексирования в графе
        /// </summary>
        [Test, Description( "Тестирование индексирования в графе" )]
        public void TestIndex()
            {
            Graph graph = new Graph();

            graph.DeclareNode( "a" );

            //Добавленная вершина имеет правильное имя
            Assert.AreEqual( graph[ "a" ], graph[ new CoreName( "a" ) ] );

            graph.RemoveAllNodes();
            graph.DeclareNodeArray( "a", 10 );

            //Первая вершина добавленного массива имеет правильное имя
            Assert.AreEqual( graph[ "a", 0 ], graph[ new CoreName( "a", 0 ) ] );
            //Последняя вершина добавленного массива имеет правильное имя
            Assert.AreEqual( graph[ "a", 9 ], graph[ new CoreName( "a", 9 ) ] ); 

             try
                {
                CoreName coreName = new CoreName( "b" );
                Node node = graph[ coreName ];
                Assert.Fail( "Использование CoreName имени необъявленной вершины не вызывает исключения" );
                }
            catch ( ArgumentException )
            { }

            try
                {
                Node node = graph[ "a", -1 ];
                Assert.Fail( "Была объявлена лишняя вершина снизу массива вершин" );
                }
            catch ( ArgumentException )
            { }

            try
                {
                Node node = graph[ "a", 10 ];
                Assert.Fail( "Была объявлена лишняя вершина сверху массива вершин" );
                }
            catch ( ArgumentException )
            { }
            }


        /// <summary>
        /// Тестирование индексирования в графе
        /// </summary>
        [Test, Description( "Тестирование индексирования в графе" )]
        public void TestClone()
            {
            Graph a = new Graph();
            a.DeclareNode( "a" );
            Graph b = a.Clone();
            
            //Число вершин исходного графа и его копии должно совпадать
            Assert.AreEqual( b.NodeNameList.Count, 1 );

            //Вершины исходного графа и его копии должны называться одинаково
            Assert.AreEqual( b.NodeNameList[ 0 ], new CoreName( "a" ) ); 

            a.DeclareNode( "b" );
            //Добавление вершин в оригинал не должно влиять на копию
            Assert.AreEqual( b.NodeNameList.Count, 1 );
            
            a[ "a" ].DeclarePolus( "p" );
            //Добавление полюсов в вершину оригинала не должно влиять на полюса в одноименной вершине копии
            Assert.AreEqual( b[ "a" ].PolusNameList.Count, 0 );
            }


        /// <summary>
        /// Тестирование объявления вершины в графе
        /// </summary>
        [Test, Description( "Тестирование объявления вершины в графе" )]
        public void TestDeclareNode()
            {
            Graph a = new Graph();
            a.DeclareNode( "a" );
            //Должна добавиться одна вершина
            Assert.AreEqual( a.NodeNameList.Count, 1 );

            //Добавленная вершина должна иметь правильное имя
            Assert.AreEqual( a.NodeNameList[ 0 ], new CoreName( "a" ) );

            //Повторное объявление вершины
            a.DeclareNode( "a" );
            }


        /// <summary>
        /// Тестирование объявления массива вершин в графе
        /// </summary>
        [Test, Description( "Тестирование объявления массива вершин в графе" )]
        public void TestDeclareNodeArray()
            {
            Graph a = new Graph();
            a.DeclareNodeArray( "a", 10 );
            
            //Должно добавиться правильное число вершин
            Assert.AreEqual( a.NodeNameList.Count, 10 );

            //Первая вершина массива должна называться правильно
            Assert.AreEqual( a.NodeNameList[ 0 ], new CoreName( "a", 0 ) );
            //Последняя вершина массива должна называться правильно
            Assert.AreEqual( a.NodeNameList[ 9 ], new CoreName( "a", 9 ) );

            //Добавление одноименного массива
            a.DeclareNodeArray( "a", 1 );
            
            //Добавление пустого массива
            a.DeclareNodeArray( "b", 0 );
            a.DeclareNodeArray( "b", 1 );
            a.DeclareNodeArray( "b", 0 );

            //Добавление пустого массива
            a.DeclareNodeArray( "b", -1 );
            }


        /// <summary>
        /// Тестирование объявления полюса в каждой вершине графа
        /// </summary>
        [Test, Description( "Тестирование объявления полюса в каждой вершине графа" )]
        public void TestDeclarePolusInAllNodes()
            {
            Graph a = new Graph();
            a.DeclarePolusInAllNodes( "p" );
            a.DeclareNode( "a" );
            a.DeclareNodeArray( "a", 10 );
            a.DeclarePolusInAllNodes( "p" );

            //Должно добавиться нужное число полюсов
            Assert.AreEqual( a[ "a" ].PolusNameList.Count, 1 );
            Assert.AreEqual( a[ "a", 9 ].PolusNameList.Count, 1 );

            //Добавленный полюс имеет правильное имя
            Assert.AreEqual( a[ "a" ].PolusNameList[ 0 ], new CoreName( "p" ) );
            Assert.AreEqual( a[ "a", 9 ].PolusNameList[ 0 ], new CoreName( "p" ) );
            }


        /// <summary>
        /// Тестирование объявления массива полюсов в каждой вершине графа
        /// </summary>
        [Test, Description( "Тестирование объявления массива полюсов в каждой вершине графа" )]
        public void TestDeclarePolusArrayInAllNodes()
            {
            Graph a = new Graph();
            a.DeclarePolusArrayInAllNodes( "p", 10 );
            a.DeclareNodeArray( "a", 2 );
            a.DeclarePolusArrayInAllNodes( "p", 10 );

            //Добавилось нужное число полюсов
            Assert.AreEqual( a[ "a", 0 ].PolusNameList.Count, 10 );
            //Добавленные полюса имеют правильные имена
            Assert.AreEqual( a[ "a", 0 ].PolusNameList[ 0 ], new CoreName( "p", 0 ) );
            Assert.AreEqual( a[ "a", 0 ].PolusNameList[ 9 ], new CoreName( "p", 9 ) );

            //Добавление пустого массива полюсов
            a.DeclarePolusArrayInAllNodes( "p", 0 );
            a.DeclarePolusArrayInAllNodes( "p", -1 );

            //Повторное добавление массива полюсов
            a.DeclarePolusArrayInAllNodes( "p", 10 );
            }


        /// <summary>
        /// Тестирование добавления дуги в граф
        /// </summary>
        [Test, Description( "Тестирование добавления дуги в граф" )]
        public void TestAddArc()
            {
            //Это неполный тест
            Graph a = new Graph();
            a.DeclareNode( "a" );
            a[ "a" ].DeclarePolus( "p1");
            a.DeclareNode( "b" );
            a[ "b" ].DeclarePolus( "p2" );
            a.DeclareNode( "c" );
            a[ "c" ].DeclarePolus( "p2" );

            a.AddArc( "a", "p1", "b", "p2" );
            //Повторное добавление дуги
            a.AddArc( "a", "p1", "b", "p2" );
            a.AddArc( "a", "p1", "b", "p2" );

            //Дуги не должны продублироваться
            Assert.AreEqual( a[ "a" ][ "p1" ].TargetOutputPoluses.Count, 1 );
            Assert.AreEqual( a[ "b" ][ "p2" ].TargetInputPoluses.Count, 1 ); 

            //Дуга должна идти к нужному полюсу
            Assert.AreEqual( a[ "a" ][ "p1" ].TargetOutputPoluses[ 0 ], new CoreName( "p2" ) );
            Assert.AreEqual( a[ "b" ][ "p2" ].TargetInputPoluses[ 0 ], new CoreName( "p1" ) );

            a.AddArc( "a", "p1", "c", "p2" );
            //А вот эта дуга добавиться должна
            Assert.AreEqual( a[ "a" ][ "p1" ].TargetOutputPoluses.Count, 2 );
            }


        /// <summary>
        /// Тестирование добавления ребра в граф
        /// </summary>
        [Test, Description( "Тестирование добавления ребра в граф" )]
        public void TestAddEdge()
            {
            Graph a = new Graph();
            a.DeclareNodeArray( "a", 2 );
            a.DeclarePolusInAllNodes( "p" );

            a.AddEdge( "a", 0, "p", "a", 1, "p" );
            //Повторное добавление ребра
            a.AddEdge( "a", 0, "p", "a", 1, "p" );
            a.AddEdge( "a", 0, "p", "a", 1, "p" );
            
            //Должно добавиться правильное число входных и выходных дуг
            Assert.AreEqual( a[ "a", 0 ][ "p" ].TargetInputPoluses.Count, 1 );
            Assert.AreEqual( a[ "a", 0 ][ "p" ].TargetOutputPoluses.Count, 1 );
            Assert.AreEqual( a[ "a", 1 ][ "p" ].TargetInputPoluses.Count, 1 );
            Assert.AreEqual( a[ "a", 1 ][ "p" ].TargetOutputPoluses.Count, 1 );

            //Добавленные ребра должны быть правильно направлены
            Assert.AreEqual( a[ "a", 0 ][ "p" ].TargetInputPoluses[ 0 ], new CoreName( "p" ) );
            Assert.AreEqual( a[ "a", 0 ][ "p" ].TargetOutputPoluses[ 0 ], new CoreName( "p" ) );
            Assert.AreEqual( a[ "a", 1 ][ "p" ].TargetInputPoluses[ 0 ], new CoreName( "p" ) );
            Assert.AreEqual( a[ "a", 1 ][ "p" ].TargetOutputPoluses[ 0 ], new CoreName( "p" ) );
            }


        /// <summary>
        /// Тестирование удаления всех вершин графа
        /// </summary>
        [Test, Description( "Тестирование удаления всех вершин графа" )]
        public void TestRemoveAllNodes()
            {
            Graph a = new Graph();
            //Удаление вершин из пустого графа
            a.RemoveAllNodes();

            a.DeclareNodeArray( "a", 10 );
            a.DeclareNode( "a" );
            
            //Проверяем число добавленных вершин
            Assert.AreEqual( a.NodeNameList.Count, 11 );
            
            a.RemoveAllNodes();
            //Проверяем, что вершин не осталось
            Assert.AreEqual( a.NodeNameList.Count, 0 );
            }


        /// <summary>
        /// Тестирование операции достройки графа
        /// </summary>
        [Test, Description( "Тестирование операции достройки графа" )]
        public void TestCompleteGraph()
            {
            Graph a = new Graph();
            a.CompleteGraph();
            
            //Проверяем, что вызов достройки работает в случае общего графа
            a.DeclareNode( "a" );
            a.CompleteGraph();
            
            a.DeclareNodeArray( "a", 10 );
            a.CompleteGraph();
            }


        /// <summary>
        /// Тестирование операции сложения графов
        /// </summary>
        [Test, Description( "Тестирование операции сложения графов" )]
        public void TestAdd()
            {
            Graph a = new Graph();
            Node node = new Node( "a" );
            node.DeclarePolus( "p" );
            
            //Слияние пустого графа с вершиной
            a.Add( node );

            //Вершина должна добавиться
            Assert.AreEqual( a.NodeNameList.Count, 1 );
            //Имя вершины должно быть правильным
            Assert.AreEqual( a.NodeNameList[ 0 ], new CoreName( "a" ) );
            
            //У вершины должно быть правильное число полюсов
            Assert.AreEqual( a[ "a" ].PolusNameList.Count, 1 );
            //Полюса вершины должны иметь правильные имена
            Assert.AreEqual( a[ "a" ].PolusNameList[ 0 ], new CoreName( "p" ) );

            //Удаляем полюса исходной вершины
            node.RemoveAllPoluses();

            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // При этом удалятся и полюса в вершине графа
            // При слиянии вершин с графом они не клонируются, чтобы
            // не было косяков при наложении рутин:
            // Ситуация - дуга указывала на какую-то вершину.
            // Потом граф вместе с вершиной слили с другим графом.
            // При этом вершина была клонирована, а дуга по 
            // прежнему указывает на исходную вершину.
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Assert.AreEqual( a[ "a" ].PolusNameList.Count, 0 );

            node = node.Clone();
            node.DeclarePolus( "g" );

            //В вершину в графе ничего в этом случае не добавится
            Assert.AreEqual( a[ "a" ].PolusNameList.Count, 0 ); 

            //Еще раз добавляем вершину с тем именем, но с новым полюсом
            a.Add( node );
            
            //Вершины должны слиться
            Assert.AreEqual( a.NodeNameList.Count, 1 );
            //Добавится новый полюс
            Assert.AreEqual( a[ "a" ].PolusNameList.Count, 1 );
            //Новый полюс будет иметь правильное имя
            Assert.AreEqual( a[ "a" ].PolusNameList[ 0 ], new CoreName( "g" ) );

            Graph b = new Graph();
            a.RemoveAllNodes();
            a.Add( b );
            a.DeclareNodeArray( "a", 3 );
            //Добавляем в пустой граф другой граф
            b.Add( a );

            //Число вершин графов должно совпасть
            Assert.AreEqual( b.NodeNameList.Count, 3 );
            //Вершины графов должны иметь одинаковые имена
            Assert.AreEqual( b.NodeNameList[ 0 ], new CoreName( "a", 0 ) );

            //Добавляем полюс в исходный граф
            a[ "a", 0 ].DeclarePolus( "p" );

            //Из-за описанной выше особенности результирующий граф тоже изменится
            Assert.AreEqual( b[ "a", 0 ].PolusNameList.Count, 1 );
            
            a.RemoveAllNodes();
            //Вершины из результирующего графа удалится не должны
            Assert.AreEqual( b.NodeNameList.Count, 3 );

            a.DeclareNodeArray( "a", 5 );
            //Добавляем одноименный массив вершин большего размера
            b.Add( a );

            //Одноимееные вершины должны слиться
            Assert.AreEqual( b.NodeNameList.Count, 5 );
            }


        /// <summary>
        /// Тестирование операции вычитания графов
        /// </summary>
        [Test, Description( "Тестирование операции вычитания графов" )]
        public void TestSubtract()
            {
            Graph a = new Graph();
            Node node = new Node( "a" );
            //Вычитание из пустого графа
            a.Subtract( node );

            a.DeclareNode( "a" );
            //Вычитание одноименной вершины
            a.Subtract( node );

            //Вершина должна удалится из графа
            Assert.AreEqual( a.NodeNameList.Count, 0 );

            a.DeclareNode( "a" );
            a.DeclareNode( "b" );
            a.DeclarePolusInAllNodes( "p" );
            a.AddEdge( "a", "p", "b", "p" );
            
            //Т.к. вычитаемая вершина не имеет полюсов, то одноименная вершина из исходного графа удаляется
            a.Subtract( node );
            
            //Осталась одна вершина
            Assert.AreEqual( a.NodeNameList.Count, 1 ); 
            //Это нужная вершина
            Assert.AreEqual( a.NodeNameList[ 0 ], new CoreName( "b" ) );
            //Дуга при удлении вершины тоже удалилась
            Assert.AreEqual( a[ "b" ][ "p" ].TargetInputPoluses.Count, 0 );
            Assert.AreEqual( a[ "b" ][ "p" ].TargetOutputPoluses.Count, 0 );

            //Повторное удаление той же самой вершины
            a.Subtract( node );

            //Ничего не изменилось
            Assert.AreEqual( a.NodeNameList.Count, 1 );

            //node a<p,g> + node b<p,g> + edge ( a.p -- b.p )
            a.RemoveAllNodes();
            a.DeclareNode( "a" );
            a[ "a" ].DeclarePolus( "p" );
            a[ "a" ].DeclarePolus( "g" );
            a.DeclareNode( "b" );
            a[ "b" ].DeclarePolus( "p" );
            a.AddEdge( "a", "p", "b", "p" );
            
            //node a<p,g>
            node = new Node( "a" );
            node.DeclarePolus( "p" );
            node.DeclarePolus( "g" );
            
            //Вычитаем вершины, имеющую тот же набор полюсов
            a.Subtract( node );

            //Вершина при этом удалится
            Assert.IsFalse( a.NodeNameList.Contains( new CoreName( "a" ) ) ); 
            //Дуги удаляются тоже
            Assert.IsFalse( a[ "b" ][ "p" ].HasArcs() );

            a.RemoveAllNodes();
            a.DeclareNode( "a" );
            a[ "a" ].DeclarePolus( "p" );
            a[ "a" ].DeclarePolus( "g" );
            a.DeclareNode( "b" );
            a[ "b" ].DeclarePolus( "p" );
            a.AddEdge( "a", "p", "b", "p" );
            node = new Node( "a" );
            node.DeclarePolus( "p" );
            a.Subtract( node );

            if ( a[ "b" ][ "p" ].HasArcs() )
                throw new TestFailedException();
            if ( a[ "a" ].PolusNameList.Count != 1 )
                throw new TestFailedException();
            if ( !a[ "a" ].PolusNameList[ 0 ].EqualsWith( "g" ) )
                throw new TestFailedException();

            a.RemoveAllNodes();
            Graph b = new Graph();
            a.DeclareNode( "a" );
            a[ "a" ].DeclarePolus( "p" );
            a[ "a" ].DeclarePolus( "g" );
            a.DeclareNode( "b" );
            a[ "b" ].DeclarePolus( "p" );
            a.AddEdge( "a", "g", "b", "p" );
            a.DeclareNode( "c" );
            a[ "c" ].DeclarePolus( "p" );
            a.DeclareNode( "main" );
            a[ "main" ].DeclarePolus( "p" );
            a.AddEdge( "main", "p", "a", "p" );
            a.AddEdge( "main", "p", "b", "p" );
            a.AddEdge( "main", "p", "c", "p" );

            b.DeclareNode( "a" );
            b[ "a" ].DeclarePolus( "p" );
            b.DeclareNode( "b" );
            b[ "b" ].DeclarePolus( "p" );
            b.DeclareNode( "c" );

            a.Subtract( b );
            if ( a.NodeNameList.Count != 2 )
                throw new TestFailedException();
            if ( !a.NodeNameList[ 0 ].EqualsWith( "a" ) )
                throw new TestFailedException();
            if ( !a.NodeNameList[ 1 ].EqualsWith( "main" ) )
                throw new TestFailedException();
            if ( a[ "a" ].PolusNameList.Count != 1 )
                throw new TestFailedException();
            if ( !a[ "a" ].PolusNameList[ 0 ].EqualsWith( "g" ) )
                throw new TestFailedException();
            if ( a[ "a" ][ "g" ].HasArcs() )
                throw new TestFailedException();
            if ( a[ "main" ][ "p" ].HasArcs() )
                throw new TestFailedException();
            b.RemoveAllNodes();
            a.RemoveAllNodes();
            a.Subtract( b );

            }

        private void TestMultiply( object sender, EventArgs e )
            {
            Graph a = new Graph();
            Graph b = new Graph();
            a.DeclareNode( "a" );
            a[ "a" ].DeclarePolus( "p" );
            a[ "a" ].DeclarePolus( "g" );
            a.DeclareNode( "b" );
            a[ "b" ].DeclarePolus( "p" );
            a.DeclareNode( "c" );
            a[ "c" ].DeclarePolus( "p" );
            a.DeclareNode( "main" );
            a[ "main" ].DeclarePolus( "p" );
            a[ "main" ].DeclarePolus( "g" );
            a.AddEdge( "main", "p", "a", "p" );
            a.AddEdge( "main", "p", "a", "g" );
            a.AddEdge( "main", "p", "b", "p" );
            a.AddEdge( "main", "p", "c", "p" );

            b.DeclareNode( "a" );
            b[ "a" ].DeclarePolus( "g" );
            b.DeclareNode( "b" );
            b.DeclareNode( "main" );
            b[ "main" ].DeclarePolus( "p" );
            b.AddEdge( "main", "p", "a", "g" );

            a.Multiply( b );

            if ( a.NodeNameList.Count != 3 )
                throw new TestFailedException();
            if ( !a[ "a" ].PolusNameList[ 0 ].EqualsWith( "g" ) )
                throw new TestFailedException();
            if ( !a[ "a" ][ "g" ].HasArcs() )
                throw new TestFailedException();
            if ( a[ "b" ].PolusNameList.Count != 0 )
                throw new TestFailedException();
            if ( a[ "main" ].PolusNameList.Count != 1 )
                throw new TestFailedException();
            if ( a[ "main" ][ "p" ].TargetOutputPoluses[ 0 ].EqualsWith( "a" ) )
                throw new TestFailedException();

            }
        }*/
    }