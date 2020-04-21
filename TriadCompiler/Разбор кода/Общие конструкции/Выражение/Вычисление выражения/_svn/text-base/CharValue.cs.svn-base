using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Дочерний класс, предназначенный для хранения символьных значений.
    /// </summary>
    internal class CharValue : ConstValue
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="value"> Значение </param>
        public CharValue( char value )
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
                    if ( operand is CharValue )
                        return new BooleanValue( value == ( operand as CharValue ).Value );
                    break;

                //Проверка на неравенство !=
                case Key.NotEqual:
                    //Проверка совместимости типов
                    if ( operand is CharValue )
                        return new BooleanValue( value != ( operand as CharValue ).Value );
                    break;

                //Проверка на меньше <
                case Key.Later:
                    //Проверка совместимости типов
                    if ( operand is CharValue )
                        return new BooleanValue( value < ( operand as CharValue ).Value );
                    break;

                //Проверка на меньше или равно <=
                case Key.LaterEqual:
                    //Проверка совместимости типов
                    if ( operand is CharValue )
                        return new BooleanValue( value <= ( operand as CharValue ).Value );
                    break;

                //Проверка на больше >
                case Key.Greater:
                    //Проверка совместимости типов
                    if ( operand is CharValue )
                        return new BooleanValue( value > ( operand as CharValue ).Value );
                    break;

                //Проверка на больше или равно >=
                case Key.GreaterEqual:
                    //Проверка совместимости типов
                    if ( operand is CharValue )
                        return new BooleanValue( value >= ( operand as CharValue ).Value );
                    break;

                //Проверка на попадание в множество
                case Key.In:
                    //Проверка совместимости типов
                    if ( operand is SetValue )
                        return new BooleanValue( ( operand as SetValue ).Value.In( value ) );
                    break;

                }
            throw new InvalidOperationException( "CharValue.CalculateWith: Wrong _input data" );
            }


        //Текущее значение
        private char value = ' ';
        }
    }
