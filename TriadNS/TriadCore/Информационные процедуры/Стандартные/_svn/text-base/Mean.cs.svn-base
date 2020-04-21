using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
{
    /// <summary>
    /// Информационная функция нахождения среднего арифметического всех значений аргумента
    /// </summary>
    public class IPMean : IProcedure
    {
        /// <summary>
        /// сумма аргументов
        /// </summary>
        protected Double summa;

        public static string Description = "Нахождение среднего арифметического";

        /// <summary>
        /// количество аргументов
        /// </summary>
        protected Double count;

        /// <summary>
        /// аргумент функции
        /// </summary>
        protected Double Arg
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
            this.summa = 0;
            this.count = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectInfo"></param>
        /// <param name="systemTime"></param>
        protected override void DoHandling(SpyObject objectInfo, double systemTime)
        {
            this.summa += Arg;
            this.count ++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual Double DoProcessing()
        {
            return (this.summa/this.count);
        }
    }

}
