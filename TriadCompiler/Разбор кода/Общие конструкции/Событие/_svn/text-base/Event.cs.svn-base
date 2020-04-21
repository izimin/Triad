using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

namespace TriadCompiler.Parser.Common.Ev
    {
    /// <summary>
    /// Разбор имени события
    /// </summary>
    internal class EventVar : CommonParser
        {
        /// <summary>
        /// Разбор
        /// </summary>
        /// <param name="endKeys">Допустимые конечные символы</param>
        /// <param name="checkRegistration">Необходимость проверки регистрации</param>
        /// <returns>Описание события</returns>
        public static EventInfo Parse( EndKeyList endKeys, bool checkRegistration )
            {
            EventInfo eventInfo = new EventInfo();

            if ( currKey != Key.Identificator )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongStartSymbol.ObjectReference, Key.Identificator );
                SkipTo( endKeys.UniteWith( Key.Identificator ) );
                }
            if ( currKey == Key.Identificator )
                {
                string eventName = ( currSymbol as IdentSymbol ).Name;
                eventInfo.StrCode = eventName;

                GetNextKey();

                //Проверка регистрации
                if ( checkRegistration )
                    {
                    CommonArea.Instance.GetType<EventType>( eventName );
                    }

                //Регистрируем обращение к событию
                EventArea.Instance.RegisterEventReference( eventName );

                //Генерируем код имени события
                eventInfo.CoreNameCode.CreateType = new System.CodeDom.CodeTypeReference( Builder.CoreName.Name );
                eventInfo.CoreNameCode.Parameters.Add( new CodePrimitiveExpression( eventName ) );

                //Генерируем ссылку на метод, которым предсатвлено событие
                eventInfo.MethodRefCode.MethodName = eventName;
                eventInfo.MethodRefCode.TargetObject = new CodeThisReferenceExpression();

                if ( !endKeys.Contains( currKey ) )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.ObjectReference, endKeys.GetLastKeys() );
                    SkipTo( endKeys );
                    }                
                }

            return eventInfo;
            }
        }
    }
