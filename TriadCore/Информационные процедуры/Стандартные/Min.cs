using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
{
    /// <summary>
    /// Информационная функция нахождения минимального значения аргумента
    /// </summary>
    public class IPMin : IProcedure
    {
        /// <summary>
        /// минимальное значение аргумента
        /// </summary>
        private Double min;

        public static string Description = "Нахождение минимального значения аргумента";

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

        /// <summary>
        /// 
        /// </summary>
        public override void DoInitialize()
        {
            this.min = Double.MaxValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectInfo"></param>
        /// <param name="systemTime"></param>
        protected override void DoHandling(SpyObject objectInfo, double systemTime)
        {
            if (Arg < min)
                min = Arg;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Double DoProcessing()
        {
            return min;
        }
    }
}
