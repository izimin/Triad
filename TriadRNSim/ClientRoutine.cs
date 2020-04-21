using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TriadCore;

namespace TriadCore
{
    public class RClient : TriadCore.Routine 
    {
        private Double deltaT;
        
        //private Boolean sent;

        public RClient(Double deltaT) 
        {
            this.deltaT = deltaT;
        }
        
        public override void DoInitialize() 
        {
            //sent = false;
            DoVarChanging(new CoreName("sent"));
            Sсhedule(0, this.Request);
            PrintMessage("Инциализация клиента");
        }
        
        private void Request() 
        {
            SendMessageViaAllPoluses("Запрос на обслуживание");
            PrintMessage("Клиент послал запрос серверу");
            Sсhedule(deltaT, this.Request);
        }
    }
}