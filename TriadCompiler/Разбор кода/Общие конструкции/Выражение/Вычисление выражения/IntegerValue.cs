using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Дочерний класс, предназначенный для хранения целых значений.
    /// </summary>
    internal class IntegerValue : ConstValue
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="value"> Значение </param>
        public IntegerValue( int value )
            {
            this.value = value;
            isConstant = true;
            }


        /// <summary> 
        /// Получить текущее значение
        /// </summary>
        /// <returns> Текущее значение </returns>
        public int Value
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

            //Смена знака -
            if ( operation == Key.Minus )
                return new IntegerValue( ( -1 ) * value );

            throw new InvalidOperationException( "IntegerValue.Calculate: Wrong _input operation" );
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
                    if ( operand is IntegerValue )
                        return new BooleanValue( value == ( operand as IntegerValue ).Value );
                    else if ( operand is RealValue )
                        return new BooleanValue( value == ( operand as RealValue ).Value );
                    break;

                //Проверка на неравенство !=
                case Key.NotEqual:
                    //Проверка совместимости типов
                    if ( operand is IntegerValue )
                        return new BooleanValue( value != ( operand as IntegerValue ).Value );
                    else if ( operand is RealValue )
                        return new BooleanValue( value != ( operand as RealValue ).Value );
                    break;

                //Проверка на меньше <
                case Key.Later:
                    //Проверка совместимости типов
                    if ( operand is IntegerValue )
                        return new BooleanValue( value < ( operand as IntegerValue ).Value );
                    else if ( operand is RealValue )
                        return new BooleanValue( value < ( operand as RealValue ).Value );
                    break;

                //Проверка на меньше или равно <=
                case Key.LaterEqual:
                    //Проверка совместимости типов
                    if ( operand is IntegerValue )
                        return new BooleanValue( value <= ( operand as IntegerValue ).Value );
                    else if ( operand is RealValue )
                        return new BooleanValue( value <= ( operand as RealValue ).Value );
                    break;

                //Проверка на больше >
                case Key.Greater:
                    //Проверка совместимости типов
                    if ( operand is IntegerValue )
                        return new BooleanValue( value > ( operand as IntegerValue ).Value );
                    else if ( operand is RealValue )
                        return new BooleanValue( value > ( operand as RealValue ).Value );
                    break;

                //Проверка на больше или равно >=
                case Key.GreaterEqual:
                    //Проверка совместимости типов
                    if ( operand is IntegerValue )
                        return new BooleanValue( value >= ( operand as IntegerValue ).Value );
                    else if ( operand is RealValue )
                        return new BooleanValue( value >= ( operand as RealValue ).Value );
                    break;

                //Сложение +
                case Key.Plus:
                    //Проверка совместимости типов
                    if ( operand is IntegerValue )
                        return new IntegerValue( value + ( operand as IntegerValue ).Value );
                    else if ( operand is RealValue )
                        return new RealValue( value + ( operand as RealValue ).Value );
                    break;

                //Вычитание - 
                case Key.Minus:
                    //Проверка совместимости типов
                    if ( operand is IntegerValue )
                        return new IntegerValue( value - ( operand as IntegerValue ).Value );
                    else if ( operand is RealValue )
                        return new RealValue( value - ( operand as RealValue ).Value );
                    break;

                //Умножение *
                case Key.Star:
                    //Проверка совместимости типов
                    if ( operand is IntegerValue )
                        return new IntegerValue( value * ( operand as IntegerValue ).Value );
                    else if ( operand is RealValue )
                        return new RealValue( value * ( operand as RealValue ).Value );
                    break;

                //Деление /
                case Key.Slash:
                    //Проверка совместимости типов
                    if ( operand is IntegerValue )
                        return new RealValue( (double)value / (double)( operand as IntegerValue ).Value );
                    else if ( operand is RealValue )
                        return new RealValue( (double)value / ( operand as RealValue ).Value );
                    break;

                //Остаток от деления
                case Key.ResidueOfDivision:
                    //Проверка совместимости типов
                    if ( operand is IntegerValue )
                        return new IntegerValue( value % ( operand as IntegerValue ).Value );
                    break;

                //Возведение в степень 
                case Key.Power:
                    //Проверка совместимости типов
                    if ( operand is IntegerValue )
                        return new IntegerValue( (int)Math.Pow( value, ( operand as IntegerValue ).Value ) );
                    else if ( operand is RealValue )
                        return new RealValue( Math.Pow( value, ( operand as RealValue ).Value ) );
                    break;

                //Проверка на попадание в множество
                case Key.In:
                    //Проверка совместимости типов
                    if ( operand is SetValue )
                        return new BooleanValue( ( operand as SetValue ).Value.In( value ) );
                    break;
                }

            throw new InvalidOperationException( "Недопустимая операция" );
            }


        //Текущее значение
        private int value = 0;
        }
    }
