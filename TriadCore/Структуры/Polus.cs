using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Дескриптор полюса
    /// </summary>
    public class Polus
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="coreName">Имя полюса</param>
        /// <param name="baseNode">Содержащая полюс вершина</param>
        public Polus( CoreName coreName, Node baseNode )
            {
            if ( coreName == null )
                throw new ArgumentNullException( "Пустое имя полюса" );
            if ( baseNode == null )
                throw new ArgumentNullException( "Пустая базовая вершина" );

            //Чтобы отличать полюса с одинаковыми именами у разных вершин
            this.coreName = coreName;
            this.baseNode = baseNode;
            this.uniqueName = new UniquePolusName( coreName, baseNode.Name );
            }


        /// <summary>
        /// Имя полюса
        /// </summary>
        public CoreName Name
            {
            get
                {
                return this.coreName;
                }
            }

        
        /// <summary>
        /// Уникальное имя полюса
        /// </summary>
        public UniquePolusName UniqueName
            {
            get
                {
                return this.uniqueName; 
                }
            }


        /// <summary>
        /// Родительская вершина
        /// </summary>
        public Node BaseNode
            {
            set
                {
                if ( value == null )
                    throw new ArgumentNullException( "Пустая базовая вершина" );

                this.baseNode = value;
                }
            get
                {
                return this.baseNode;
                }
            }


        /// <summary>
        /// Список полюсов, от которых идут входные дуги
        /// </summary>
        public IEnumerable<Polus> TargetInputPoluses
            {
            get
                {
                foreach ( Polus polus in inputArcList.Values )
                    yield return polus;
                }
            }


        /// <summary>
        /// Список полюсов, в которые идут выходные дуги
        /// </summary>
        public IEnumerable<Polus> TargetOutputPoluses
            {
            get
                {
                foreach ( Polus polus in outputArcList.Values )
                    yield return polus;
                }
            }


        /// <summary>
        /// Символьное имя полюса
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            {
            return coreName.ToString();
            }


        /// <summary>
        /// Получить копию
        /// </summary>
        /// <returns></returns>
        public Polus Clone()
            {
            //Создаем копию полюса
            Polus newPolus = new Polus( this.Name, this.baseNode );

            //Копируем список входных дуг
            foreach ( KeyValuePair<UniquePolusName, Polus> pair in this.inputArcList )
                newPolus.inputArcList.Add( pair.Key, pair.Value );
            
            //Копируем список выходных дуг
            foreach ( KeyValuePair<UniquePolusName, Polus> pair in this.outputArcList )
                newPolus.outputArcList.Add( pair.Key, pair.Value );
            
            return newPolus;
            }


        #region DinamicOperations

        /// <summary>
        /// Слить полюса по дугам
        /// </summary>
        /// <returns>Результат слияния</returns>
        /// <param name="polus">Второй полюс</param>
        public void Add( Polus polus )
            {
            if ( polus == null )
                throw new ArgumentNullException( "Передан пустой полюс" );

            //Добавляем в текущий полюс входные дуги переданного полюса
            foreach ( Polus targetPolus in polus.inputArcList.Values )
                {                
                this.AddInputArc( targetPolus );
                }

            //Добавляем в текущий полюс выходные дуги переданного полюса
            foreach ( Polus targetPolus in polus.outputArcList.Values )
                {
                this.AddOutputArc( targetPolus );
                } 
            }


        /// <summary>
        /// Пересечь текущий полюс с другим по дугам
        /// </summary>
        /// <param name="polus">Второй полюс</param>
        public void Multiply( Polus polus )
            {
            if ( polus == null )
                throw new ArgumentNullException( "Передан пустой полюс" );

            //Список input полюсов, которые нужно удалить у текущего полюса
            List<UniquePolusName> targetPolusesToRemove = new List<UniquePolusName>();
            //Перебираем полюса текущего полюса
            foreach ( Polus targetPolus in this.inputArcList.Values )
                {
                //Если у другого полюса
                if ( !polus.inputArcList.ContainsKey( targetPolus.UniqueName ) )
                    {
                    targetPolusesToRemove.Add( targetPolus.UniqueName );
                    }
                }

            foreach ( UniquePolusName targetPolusName in targetPolusesToRemove )
                {
                this.RemoveInputArc( targetPolusName );
                }

            targetPolusesToRemove.Clear();
            foreach ( Polus targetPolus in this.outputArcList.Values )
                {
                if ( !polus.outputArcList.ContainsKey( targetPolus.UniqueName ) )
                    {
                    targetPolusesToRemove.Add( targetPolus.UniqueName );
                    }
                }

            foreach ( UniquePolusName targetPolusName in targetPolusesToRemove )
                {
                this.RemoveOutputArc( targetPolusName );
                }
            }

        
        /// <summary>
        /// Добавить входную дугу
        /// </summary>
        /// <param name="targetPolus">Объект, от которого идет дуга</param>
        public void AddInputArc( Polus targetPolus )
            {
            //Если дуги от этого полюса ранее не добавлялось
            if ( !inputArcList.ContainsKey( targetPolus.UniqueName ) )
                {
                inputArcList.Add( targetPolus.UniqueName, targetPolus );
                }
            //Иначе - добавлять не надо
            }


        /// <summary>
        /// Добавить выходную дугу
        /// </summary>
        /// <param name="targetPolus"> Объект, к которому идет дуга</param>
        public void AddOutputArc( Polus targetPolus )
            {
            //Если дуги от этого полюса ранее не добавлялось
            if ( !outputArcList.ContainsKey( targetPolus.UniqueName ) )
                {
                outputArcList.Add( targetPolus.UniqueName, targetPolus );
                }
            //Иначе - добавлять не надо
            }        


        /// <summary>
        /// Удалить выходящую дугу
        /// </summary>
        /// <param name="targetPolusName">Конечный полюс</param>
        public void RemoveInputArc( UniquePolusName targetPolusName )
            {
            if ( this.inputArcList.ContainsKey( targetPolusName ) )
                {
                this.inputArcList.Remove( targetPolusName );
                }
            else
                {
                //Ничего не делаем
                }
            }


        /// <summary>
        /// Удалить выходящую дугу
        /// </summary>
        /// <param name="targetPolusName">Конечный полюс</param>
        /// <param name="targetNodeName">Конечный вершина</param>
        public void RemoveInputArc( CoreName targetPolusName, CoreName targetNodeName )
            {
            RemoveInputArc( new UniquePolusName( targetPolusName, targetNodeName ) );
            }


        /// <summary>
        /// Удалить входящую дугу
        /// </summary>
        /// <param name="targetPolusName">Конечный полюс</param>
        public void RemoveOutputArc( UniquePolusName targetPolusName )
            {
            if ( this.outputArcList.ContainsKey( targetPolusName ) )
                {
                this.outputArcList.Remove( targetPolusName );
                }
            else
                {
                //Ничего не делаем
                }
            }


        /// <summary>
        /// Удалить входящую дугу
        /// </summary>
        /// <param name="targetPolusName">Конечный полюс</param>
        /// <param name="targetNodeName">Конечный вершина</param>
        public void RemoveOutputArc( CoreName targetPolusName, CoreName targetNodeName )
            {
            RemoveOutputArc( new UniquePolusName( targetPolusName, targetNodeName ) );
            }


        /// <summary>
        /// Удалить все дуги
        /// </summary>
        public void RemoveAllArcs()
            {
            foreach ( Polus targetPolus in this.outputArcList.Values )
                {
                targetPolus.RemoveInputArc( this.UniqueName );
                }
            foreach ( Polus targetPolus in this.inputArcList.Values )
                {
                targetPolus.RemoveOutputArc( this.UniqueName );
                }
            this.outputArcList.Clear();
            this.inputArcList.Clear();
            }

        
        #endregion


        #region RoutineOperations


        /// <summary>
        /// Послать сообщение всем получателям
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="sendMessageTime">Время посылки сообщения</param>
        public void SendMessage( string message, double sendMessageTime  )
            {
            foreach ( Polus polus in this.outputArcList.Values )
                {
                polus.ReceiveMessage( message, sendMessageTime );
                }
            }


        /// <summary>
        /// Получить сообщение
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="sendMessageTime">Время посылки сообщения</param>
        public void ReceiveMessage( string message, double sendMessageTime )
            {
            this.baseNode.ReceiveMessageVia( this.Name, message, sendMessageTime );
            }

        #endregion

        /// <summary>
        /// Внутренне имя
        /// </summary>
        private CoreName coreName;
        /// <summary>
        /// Уникальное имя (включает имя вершины)
        /// </summary>
        private UniquePolusName uniqueName;
        /// <summary>
        /// Базовая вершина
        /// </summary>
        private Node baseNode;
        /// <summary>
        /// Список входных дуг
        /// </summary>
        private Dictionary<UniquePolusName, Polus> inputArcList = new Dictionary<UniquePolusName, Polus>();
        /// <summary>
        /// Список выходных дуг
        /// </summary>
        private Dictionary<UniquePolusName, Polus> outputArcList = new Dictionary<UniquePolusName, Polus>();
        }
    }
