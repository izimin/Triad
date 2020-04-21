using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Дочерний класс, предназначенный для хранения логических значений.
    /// </summary>
    internal class BooleanValue : ConstValue
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="value"> Значение </param>
        public BooleanValue( bool value )
            {
            this.value = value;
            isConstant = true;
            }


        /// <summary>
        /// Получить текущее значение
        /// </summary>
        /// <returns> Текущее значение </returns>
        public bool Value
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

            //Отрицание !
            if ( operation == Key.Not )
                return new BooleanValue( !value );
            throw new InvalidOperationException( "BooleanValue.Calculate: Wrong input data" );
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
                    if ( operand is BooleanValue )
                        return new BooleanValue( value == ( operand as BooleanValue ).Value );
                    break;

                //Проверка на неравенство !=
                case Key.NotEqual:
                    //Проверка совместимости типов
                    if ( operand is BooleanValue )
                        return new BooleanValue( value != ( operand as BooleanValue ).Value );
                    break;

                //Конъюнкция &
                case Key.And:
                    //Проверка совместимости типов
                    if ( operand is BooleanValue )
                        return new BooleanValue( value && ( operand as BooleanValue ).Value );
                    break;

                //Дизъюнкция |
                case Key.Or:
                    //Проверка совместимости типов
                    if ( operand is BooleanValue )
                        return new BooleanValue( value || ( operand as BooleanValue ).Value );
                    break;

                //Проверка на попадание в множество
                case Key.In:
                    //Проверка совместимости типов
                    if ( operand is SetValue )
                        return new BooleanValue( ( operand as SetValue ).Value.In( value ) );
                    break;
                }

            throw new InvalidOperationException( "BooleanValue.CalculateWith: Wrong _input data" );
            }


        //Текущее значение
        private bool value = false;
        }
    }
