using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
{
    /// <summary>
    /// Информационная функция нахождения времени срабатывания события
    /// </summary>
    public class IPTimeEvent : Time
    {
        public static string Description = "Нахождение времени срабатывания события";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="E"></param>
        public void RegisterSpyObjects(SpyObject E)
        {
            RegisterSpyObject(E, new CoreName("E"));
            RegisterSpyHandler(E, DoHandling);
        }

    }

    /// <summary>
    /// Информационная функция нахождения времени изменения значения переменной
    /// </summary>
    public class IPTimeChange : Time
    {
        public static string Description = "Нахождение времени изменения значения переменной";

        /// <summary>
        /// аргумент функции
        /// </summary>
        private Double Arg
        {
            get
            {
                return ((Double)GetSpyVarValue(new CoreName("Arg")));
            }
            set
            {
                SetSpyVarValue(new CoreName("Arg"), value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void RegisterSpyObjects(SpyObject arg)
        {
            RegisterSpyObject(arg, new CoreName("Arg"));
            RegisterSpyHandler(arg, DoHandling);
        }
    }

    /// <summary>
    /// Информационная функция нахождения времени поступления сигнала на полюс
    /// </summary>
    public class IPTimePolus : Time
    {
        public static string Description = "Нахождение времени поступления сигнала на полюс";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="P"></param>
        public void RegisterSpyObjects(SpyObject P)
        {
            RegisterSpyObject (P, new CoreName("P"));
            RegisterSpyHandler(P, DoHandling);
        }
    }

    /// <summary>
    /// Информационная функция - предок
    /// </summary>
    public class Time : IProcedure
    {
        /// <summary>
        /// время
        /// </summary>
        private Double time;

        /// <summary>
        /// 
        /// </summary>
        public override void DoInitialize()
        {
            this.time = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectInfo"></param>
        /// <param name="systemTime"></param>
        protected override void DoHandling(SpyObject objectInfo, double systemTime)
        {
            this.time = systemTime;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Double DoProcessing()
        {
            return this.time;
        }
    }

}
