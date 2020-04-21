using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
{
    /// <summary>
    /// Информационная функция нахождения промежутка времени между срабатываниями событий
    /// </summary>
    public class IPIntervalEvent : Interval
    {
        public static string Description = "Нахождение промежутка времени между срабатываниями событий";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="E1"></param>
        /// <param name="E2"></param>
        public void RegisterSpyObjects(SpyObject E1, SpyObject E2)
        {
            RegisterSpyObject (E1, new CoreName("E1"));
            RegisterSpyHandler(E1, DoHandling);
            RegisterSpyObject (E2, new CoreName("E2"));
            RegisterSpyHandler(E2, DoHandling);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectInfo"></param>
        /// <param name="systemTime"></param>
        protected override void DoHandling(SpyObject objectInfo, double systemTime)
        {
            if (objectInfo.Equals(GetSpyObject(new CoreName("E1"))))
            {
                base.time_1 = systemTime;
            }
            else
                base.time_2 = systemTime;
        }
    }

    /// <summary>
    /// Информационная функция нахождения промежутка времени между изменениями значений переменной
    /// </summary>
    public class IPIntervalChange : Interval
    {
        public static string Description = "Нахождение промежутка времени между изменениями значений переменной";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="var1"></param>
        /// <param name="var2"></param>
        public void RegisterSpyObjects(SpyObject var1, SpyObject var2)
        {
            RegisterSpyObject (var1, new CoreName("Var1"));
            RegisterSpyHandler(var1, DoHandling);
            RegisterSpyObject (var2, new CoreName("Var2"));
            RegisterSpyHandler(var2, DoHandling);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectInfo"></param>
        /// <param name="systemTime"></param>
        protected override void DoHandling(SpyObject objectInfo, double systemTime)
        {
            if (objectInfo.Equals(GetSpyObject(new CoreName("Var1"))))
            {
                base.time_1 = systemTime;
            }
            else
                base.time_2 = systemTime;
        }
    }

    /// <summary>
    /// Информационная функция нахождения промежутка времени между поступлениями сигналов на полюса
    /// </summary>
    public class IPIntervalPolus : Interval
    {
        public static string Description = "Нахождение промежутка времени между поступлениями сигналов на полюса";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        public void RegisterSpyObjects(SpyObject P1, SpyObject P2)
        {
            RegisterSpyObject (P1, new CoreName("P1"));
            RegisterSpyHandler(P1, DoHandling);
            RegisterSpyObject (P2, new CoreName("P2"));
            RegisterSpyHandler(P2, DoHandling);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectInfo"></param>
        /// <param name="systemTime"></param>
        protected override void DoHandling(SpyObject objectInfo, double systemTime)
        {
            if (objectInfo.Equals(GetSpyObject(new CoreName("P1"))))
            {
                base.time_1 = systemTime;
            }
            else
                base.time_2 = systemTime;
        }
    }

    /// <summary>
    /// Информационная функция - предок
    /// </summary>
    public class Interval : IProcedure
    {
        /// <summary>
        /// время срабатывания ИП на первый объект слежения 
        /// </summary>
        protected Double time_1;

        /// <summary>
        /// время срабатывания ИП на второй объект слежения 
        /// </summary>
        protected Double time_2;

        /// <summary>
        /// 
        /// </summary>
        public override void DoInitialize()
        {
            this.time_1 = 0;
            this.time_2 = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Double DoProcessing()
        {
            return Math.Abs(this.time_1 - this.time_2);
        }
    }

}
