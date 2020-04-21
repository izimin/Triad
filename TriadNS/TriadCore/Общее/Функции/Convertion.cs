using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Функции преобразования типов
    /// </summary>
    public static class Convertion
        {
        /// <summary>
        /// Преобразование строки в целое число
        /// </summary>
        /// <param name="value">Строка</param>
        /// <returns>Целое число</returns>
        public static int StrToInt( string value )
            {
            return Int32.Parse( value );
            }


        /// <summary>
        /// Преобразование целого числа в строку
        /// </summary>
        /// <param name="value">Целое число</param>
        /// <returns>Строка</returns>
        public static string IntToStr( int value )
            {
            return value.ToString();
            }


        /// <summary>
        /// Преобразование строки в вещественное число
        /// </summary>
        /// <param name="value">Строка</param>
        /// <returns>Вещественное число</returns>
        public static double StrToReal( string value )
            {
            //Все точки трактуем как запятые
            value = value.Replace( '.', ',' );
            return Double.Parse( value );
            }


        /// <summary>
        /// Преобразование вещественного числа в строку
        /// </summary>
        /// <param name="value">Вещественное число</param>
        /// <returns>Строка</returns>
        public static string RealToStr( double value )
            {
            return value.ToString();
            }


        /// <summary>
        /// Преобразование строки в логическое значение
        /// </summary>
        /// <param name="value">Строка</param>
        /// <returns>Логическое значение</returns>
        public static bool StrToBoolean( string value )
            {
            return Boolean.Parse( value );
            }


        /// <summary>
        /// Преобразование логического значения в строку
        /// </summary>
        /// <param name="value">Логическое значение</param>
        /// <returns>Строка</returns>
        public static string BooleanToStr( bool value )
            {
            return value.ToString();
            }


        /// <summary>
        /// Преобразование строки в битовую строку
        /// </summary>
        /// <param name="value">Строка</param>
        /// <returns>Битовая строка</returns>
        public static Int64 StrToBit( string value )
            {
            Int64 bitStringValue = 0;

            //Проверка на длину строки
            if ( value.Length > 64 )
                throw new ArgumentException( "Слишком длинная битовая строка" );

            foreach ( char ch in value )
                {
                //Проверка на допустимый символ
                if ( ch != '0' && ch != '1' )
                    {
                    throw new ArgumentException( "Недопустимый символ в битовой строке" );
                    }
                
                bitStringValue <<= 1;
                if ( ch == '1' )
                    bitStringValue |= 1;
                
                }

            return bitStringValue;
            }


        /// <summary>
        /// Преобразование битовой строки в строку
        /// </summary>
        /// <param name="value">Битовая строка</param>
        /// <returns>Строка</returns>
        public static string BitToStr( Int64 value )
            {
            StringBuilder valueStr = new StringBuilder();

            Int64 comparer = 1;
            for ( int index = 0 ; index < 64 ; index++ )
                {
                if ( ( value & comparer ) == 1 )
                    valueStr.Insert( 0, "1" );
                else
                    valueStr.Insert( 0, "0" );
                value >>= 1;

                if ( value == 0 )
                    break;
                }

            return valueStr.ToString();
            }


        /// <summary>
        /// Преобразование строки в символ
        /// </summary>
        /// <param name="value">Строка</param>
        /// <returns>Символ</returns>
        public static char StrToChar( string value )
            {
            return Char.Parse( value );
            }


        /// <summary>
        /// Преобразование символа в строку
        /// </summary>
        /// <param name="value">Символ</param>
        /// <returns>Строка</returns>
        public static string CharToStr( char value )
            {
            return value.ToString();
            }


        /// <summary>
        /// Преобразование строки в массив символов
        /// </summary>
        /// <param name="value">Строка</param>
        /// <returns>Массив символов</returns>
        public static char[] StrToCharArray( string value )
            {
            return value.ToCharArray();
            }


        /// <summary>
        /// Преобразование массива символов в строку
        /// </summary>
        /// <param name="value">Массив символов</param>
        /// <returns>Строка</returns>
        public static string CharArrayToStr( char[] value )
            {
            return new String( value );
            }

        /// <summary>
        /// Преобразование в строку
        /// </summary>
        /// <param name="value">Массив символов</param>
        /// <returns>Строка</returns>
        public static string ToStr(object value)
        {
            return value.ToString();
        }

        /// <summary>
        /// Перобразование целочисленного массива в строку
        /// </summary>
        /// <param name="value">массив</param>
        /// <returns></returns>
        public static string IntArrayToStr(int[] value)
        {
            string sRes = string.Join(" ", Array.ConvertAll<int, string>(value, Convert.ToString));
            return "[" + sRes + "]";
            //return ToString(value, " ");
        }

        public static string RealArrayToStr(double[] value)
        {
            string sRes = string.Join(" ", Array.ConvertAll<double, string>(value, Convert.ToString));
            return "[" + sRes + "]";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int[] StrToIntArray(string value)
        {
            value = value.Trim();
            if (value.Length < 2 || value[0] != '[' || value[value.Length - 1] != ']')
                return null;
            value = value.Substring(1, value.Length - 2);
            int[] res = Array.ConvertAll<string, int>(value.Split(' '), Convert.ToInt32);
            return res;
        }

        public static double[] StrToRealArray(string value)
        {
            value = value.Trim();
            if (value.Length < 2 || value[0] != '[' || value[value.Length - 1] != ']')
                return null;
            value = value.Substring(1, value.Length - 2);
            double[] res = Array.ConvertAll<string, double>(value.Split(' '), Convert.ToDouble);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Real2DArrayToStr(double[,] value)
        {
            string res = "";
            for (int i = 0; i < value.GetLength(0); i++)
            {
                if (i > 0)
                    res += ",";
                res += "[";
                for (int j = 0; j < value.GetLength(1); j++)
                {
                    if (j > 0)
                        res += " ";
                    res += value[i, j].ToString();
                }
                res += "]";
            }
            return "[" + res + "]";
        }

        public static double[,] StrToReal2DArray(string value)
        {
            value = value.Trim();
            if (value.Length < 2 || value[0] != '[' || value[value.Length - 1] != ']')
                return null;
            value = value.Substring(1, value.Length - 2);
            string[] rows = value.Split(',');
            if (rows.Length > 0)
            {
                double[] row = StrToRealArray(rows[0]);
                double[,] res = new double[rows.Length, row.Length];
                for (int i = 0; i < rows.Length; i++)
                {
                    row = StrToRealArray(rows[i]);
                    for (int j = 0; j < row.Length; j++)
                        res[i, j] = row[j];
                }
                return res;
            }
            return null;
        }

        /// <summary>
        /// массив в строку
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string ToString<T>(T[] array, string delimiter)
        {
            if (array != null)
            {
                if (array.Length > 0)
                {
                    StringBuilder builder = new StringBuilder();

                    builder.Append(array[0]);
                    for (int i = 1; i < array.Length; i++)
                    {
                        builder.Append(delimiter);
                        builder.Append(array[i]);
                    }

                    return builder.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Деление строки на части
        /// </summary>
        /// <param name="value">Исходная строка</param>
        /// <param name="separator">Разделитель</param>
        /// <returns>Массив поличившихся частей</returns>
        public static string[] Split( string value, char separator )
            {
            return value.Split( separator );
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Boolean StrContains(string str, string value)
        {
            return str.Contains(value);
        }
        public static int[] IDtoIntArray(string value)
        {
            int[] res = new int[value.Length];
            for (int i = 0; i < value.Length; i++)
                res[i] = value[i];            
            return res;
        }

    }
    }
