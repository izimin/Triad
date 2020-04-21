using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Дочерний класс, предназначенный для хранения строковых значений.
    /// </summary>
    internal class StringValue : ConstValue
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="value"> Значение </param>
        public StringValue( string value )
            {
            this.value = value;
            isConstant = true;
            }


        /// <summary>
        /// Получить текущее значение
        /// </summary>
        /// <returns> Текущее значение </returns>
        public string Value
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
                    if ( operand is StringValue )
                        return new BooleanValue( value == ( operand as StringValue ).Value );
                    break;

                //Проверка на неравенство !=
                case Key.NotEqual:
                    //Проверка совместимости типов
                    if ( operand is StringValue )
                        return new BooleanValue( value != ( operand as StringValue ).Value );
                    break;

                //Проверка на меньше <
                case Key.Later:
                    //Проверка совместимости типов
                    if ( operand is StringValue )
                        return new BooleanValue( String.Compare( value, ( operand as StringValue ).Value ) < 0 );
                    break;

                //Проверка на меньше или равно <=
                case Key.LaterEqual:
                    //Проверка совместимости типов
                    if ( operand is StringValue )
                        return new BooleanValue( String.Compare( value, ( operand as StringValue ).Value ) <= 0 );
                    break;

                //Проверка на больше >
                case Key.Greater:
                    //Проверка совместимости типов
                    if ( operand is StringValue )
                        return new BooleanValue( String.Compare( value, ( operand as StringValue ).Value ) > 0 );
                    break;

                //Проверка на больше или равно >=
                case Key.GreaterEqual:
                    //Проверка совместимости типов
                    if ( operand is StringValue )
                        return new BooleanValue( String.Compare( value, ( operand as StringValue ).Value ) >= 0 );
                    break;

                //Конкатенация +
                case Key.Plus:
                    //Проверка совместимости типов
                    if ( operand is StringValue )
                        return new StringValue( value + ( operand as StringValue ).Value );
                    break;

                //Проверка на попадание в множество
                case Key.In:
                    //Проверка совместимости типов
                    if ( operand is SetValue )
                        return new BooleanValue( ( operand as SetValue ).Value.In( value ) );
                    break;

                }
            throw new InvalidOperationException( "StringValue.CalculateWith: Wrong _input data" );
            }


        //Текущее значение
        private string value = "";
        }
    }
