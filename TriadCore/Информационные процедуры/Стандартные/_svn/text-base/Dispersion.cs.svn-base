using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
{
    /// <summary>
    /// Информационная функция нахождения дисперсии аргумента
    /// </summary>
    public class IPDispersion : IPMean
    {
        /// <summary>
        /// степень
        /// </summary>
        private const int POW = 2;

        public static string Description = "Нахождение дисперсии аргумента";

        /// <summary>
        /// сумма квадратов аргументов
        /// </summary>
        private Double summa_square;

        /// <summary>
        /// 
        /// </summary>
        public override void DoInitialize()
        {
            base.DoInitialize();
            this.summa_square = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectInfo"></param>
        /// <param name="systemTime"></param>
        protected override void DoHandling(SpyObject objectInfo, double systemTime)
        {
            base.DoHandling(objectInfo, systemTime);
            this.summa_square += Math.Pow(Arg, POW);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Double DoProcessing()
        {
            return (this.summa_square/base.count - base.DoProcessing());
        }
    }

}
