using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Функции для работы со случайными величинами
    /// </summary>
    public static class Rand
        {
        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        private static Random random = new Random( DateTime.Now.GetHashCode() );


        /// <summary>
        /// Получение случайного неотрицательного целого числа
        /// </summary>
        /// <returns>Случайное целое число</returns>
        public static int Random()
            {
            return random.Next();
            }


        /// <summary>
        /// Получение случайного целого числа из промежутка
        /// </summary>
        /// <param name="lowValue">Минимальное значение</param>
        /// <param name="topValue">Максимальное значение</param>
        /// <returns>Случайное целое число</returns>
        public static int RandomIn( int lowValue, int topValue )
            {
            return random.Next( lowValue, topValue + 1 );
            }


        /// <summary>
        /// Получение случайного вещественного числа числа из промежутка [0,1]
        /// </summary>
        /// <returns>Случайное вещественное число</returns>
        public static double RandomReal()
            {
            return random.NextDouble();
            }


        /// <summary>
        /// Получение случайного вещественного числа числа из промежутка
        /// </summary>
        /// <param name="lowValue">Минимальное значение</param>
        /// <param name="topValue">Максимальное значение</param>
        /// <returns>Случайное вещественное число</returns>
        public static double RandomRealIn( double lowValue, double topValue )
            {
            return random.NextDouble() * ( topValue - lowValue ) + lowValue;
            }

        }
    }
