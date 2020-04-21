using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
{
    /// <summary>
    /// Информационная функция нахождения числа срабатываний SPY-объектов
    /// </summary>
    public class IPCount : IProcedure
    {
        /// <summary>
        /// счетчик 
        /// </summary>
        private int counter;

        public static string Description = "Нахождение числа срабатываний SPY-объектов";
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Arg"></param>
        public void RegisterSpyObjects(SpyObject Arg)
        {
            RegisterSpyObject (Arg, new CoreName("Arg"));
            RegisterSpyHandler(Arg, DoHandling);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectInfo"></param>
        /// <param name="systemTime"></param>
        protected override void DoHandling(SpyObject objectInfo, double systemTime)
        {
            counter++;
        }
 
        /// <summary>
        /// 
        /// </summary>
        public override void DoInitialize()
        {
            this.counter = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Double DoProcessing()
        {
            return this.counter;
        }
    }

}
