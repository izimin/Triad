using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Прототип обработчика внутреннего события рутины
    /// </summary>
    public delegate void InternalEventHandler();


    /// <summary>
    /// Прототип обработчика события принятия сообщения
    /// </summary>
    /// <param name="routinePolusName">Имя полюса рутины, принявшего сообщение</param>
    /// <param name="nodePolusName">Имя полюса вершины, принявшего сообщение</param>
    /// <param name="message">Принятое сообщение</param>
    /// <param name="spyHandler">Зарегистрированные обработчики принятия сообщения</param>
    public delegate void ReceivingMessageEventHandler( CoreName routinePolusName, CoreName nodePolusName,
            string message, SpyHandler spyHandler );
    }
