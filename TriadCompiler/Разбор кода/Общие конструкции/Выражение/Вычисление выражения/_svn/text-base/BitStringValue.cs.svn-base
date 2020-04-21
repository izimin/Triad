using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Дочерний класс, предназначенный для хранения битовых строковых значений.
    /// </summary>
    internal class BitStringValue : ConstValue
        {
        /// <summary>
        /// Константа для инвертирования битовых строк
        /// </summary>
        public const Int64 BitStringInvertConst = -1;


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="value"> Значение </param>
        public BitStringValue( Int64 value )
            {
            this.value = value;
            isConstant = true;
            }


        /// <summary>
        /// Получить текущее значение
        /// </summary>
        /// <returns> Текущее значение </returns>
        public long Value
            {
            get
                {
                return value;
                }
            }


        /// <summary>
        /// Произвести вычисления
        /// </summary>
        /// <param name="operation"> Код унарной операции </param>
        /// <returns> Результат </returns>
        public override ConstValue CalculateWith( Key operation )
            {
            if ( !this.IsConstant )
                return this;

            //Поразрядное инвертирование -
            if ( operation == Key.Not )
                return new BitStringValue( BitStringInvertConst ^ value );
            throw new InvalidOperationException( "RealValue.Calculate: Wrong _input data" );
            }


        /// <summary>
        /// Произвести вычисления
        /// </summary>
        /// <param name="operation"> Код бинарной операции </param>
        /// <param name="operand"> Второй операнд </param>
        /// <returns> Результат </returns>
        public override ConstValue CalculateWith( Key operation, ConstValue operand )
            {
            //Хотя бы одно из значений - не константа, то вычисления не производятся
            if ( !operand.IsConstant || !this.IsConstant )
                return new ConstValue();

            switch ( operation )
                {
                //Проверка на равенство =
                case Key.Equal:
                    //Проверка совместимости типов
                    if ( operand is BitStringValue )
                        return new BooleanValue( value == ( operand as BitStringValue ).Value );
                    break;

                //Проверка на неравенство !=
                case Key.NotEqual:
                    //Проверка совместимости типов
                    if ( operand is BitStringValue )
                        return new BooleanValue( value != ( operand as BitStringValue ).Value );
                    break;

                //Проверка на меньше <
                case Key.Later:
                    //Проверка совместимости типов
                    if ( operand is BitStringValue )
                        return new BooleanValue( value < ( operand as BitStringValue ).Value );
                    break;

                //Проверка на меньше или равно <=
                case Key.LaterEqual:
                    //Проверка совместимости типов
                    if ( operand is BitStringValue )
                        return new BooleanValue( value <= ( operand as BitStringValue ).Value );
                    break;

                //Проверка на больше >
                case Key.Greater:
                    //Проверка совместимости типов
                    if ( operand is BitStringValue )
                        return new BooleanValue( value > ( operand as BitStringValue ).Value );
                    break;

                //Проверка на больше или равно >=
                case Key.GreaterEqual:
                    //Проверка совместимости типов
                    if ( operand is BitStringValue )
                        return new BooleanValue( value >= ( operand as BitStringValue ).Value );
                    break;

                //Поразрядное сложение |
                case Key.Or:
                    //Проверка совместимости типов
                    if ( operand is BitStringValue )
                        return new BitStringValue( value | ( operand as BitStringValue ).Value );
                    break;

                //Поразрядное умножение &
                case Key.And:
                    //Проверка совместимости типов
                    if ( operand is BitStringValue )
                        return new BitStringValue( value & ( operand as BitStringValue ).Value );
                    break;

                //Проверка на попадание в множество
                case Key.In:
                    //Проверка совместимости типов
                    if ( operand is SetValue )
                        return new BooleanValue( ( operand as SetValue ).Value.In( value ) );
                    break;
                }
            throw new InvalidOperationException( "BitStringValue.CalculateWith: Wrong _input data" );
            }


        //Текущее значение
        private Int64 value = 0;
        }
    }
