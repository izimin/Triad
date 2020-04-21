using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Математические функции
    /// </summary>
    public static class TMath
        {
        /// <summary>
        /// Округление к ближайшему целому числу
        /// </summary>
        /// <param name="value">Вещественное число</param>
        /// <returns>Целое число</returns>
        public static int Round( double value )
            {
            return (int)Math.Round( value, MidpointRounding.ToEven );
            }


        /// <summary>
        /// Синус
        /// </summary>
        /// <param name="value">Вещественное число</param>
        /// <returns>Вещественное число</returns>
        public static double Sin( double value )
            {
            return Math.Sin( value );
            }


        /// <summary>
        /// Косинус
        /// </summary>
        /// <param name="value">Вещественное число</param>
        /// <returns>Вещественное число</returns>
        public static double Cos( double value )
            {
            return Math.Cos( value );
            }


        /// <summary>
        /// Тангенс
        /// </summary>
        /// <param name="value">Вещественное число</param>
        /// <returns>Вещественное число</returns>
        public static double Tan( double value )
            {
            return Math.Tan( value );
            }


        /// <summary>
        /// Знак числа
        /// </summary>
        /// <param name="value">Вещественное число</param>
        /// <returns>-1 | 0 | 1</returns>
        public static int Sign( double value )
            {
            return Math.Sign( value );
            }


        /// <summary>
        /// Модуль числа
        /// </summary>
        /// <param name="value">Целое число</param>
        /// <returns>Целое число</returns>
        public static int Abs( int value )
            {
            return Math.Abs( value );
            }


        /// <summary>
        /// Модуль числа
        /// </summary>
        /// <param name="value">Вещественное число</param>
        /// <returns>Вещественное число</returns>
        public static double AbsReal( double value )
            {
            return Math.Abs( value );
            }


        /// <summary>
        /// Натуральный логарифм
        /// </summary>
        /// <param name="value">Вещественное число</param>
        /// <returns>Вещественное число</returns>
        public static double Ln( double value )
            {
            return Math.Log( value );
            }


        /// <summary>
        /// Десятичный логарифм
        /// </summary>
        /// <param name="value">Вещественное число</param>
        /// <returns>Вещественное число</returns>
        public static double Log( double value )
            {
            return Math.Log10( value );
            }


        /// <summary>
        /// Арксинус
        /// </summary>
        /// <param name="value">Вещественное число</param>
        /// <returns>Вещественное число</returns>
        public static double Asin( double value )
            {
            return Math.Asin( value );
            }


        /// <summary>
        /// Арккосинус
        /// </summary>
        /// <param name="value">Вещественное число</param>
        /// <returns>Вещественное число</returns>
        public static double Acos( double value )
            {
            return Math.Acos( value );
            }


        /// <summary>
        /// Арктангенс
        /// </summary>
        /// <param name="value">Вещественное число</param>
        /// <returns>Вещественное число</returns>
        public static double Atan( double value )
            {
            return Math.Atan( value );
            }


        /// <summary>
        /// Экспонента
        /// </summary>
        /// <param name="value">Вещественное число</param>
        /// <returns>Вещественное число</returns>
        public static double Exp( double value )
            {
            return Math.Exp( value );
            }


        /// <summary>
        /// Возведение в степень
        /// </summary>
        /// <param name="x">Вещественное число</param>
        /// <param name="y">Вещественное число</param>
        /// <returns>Вещественное число</returns>
        public static double Pow( double x, double y )
            {
            return Math.Pow( x, y );
            }


        /// <summary>
        /// Квадратный корень
        /// </summary>
        /// <param name="value">Вещественное число</param>
        /// <returns>Вещественное число</returns>
        public static double Sqrt( double value )
            {
            return Math.Sqrt( value );
            }

        }
    }
