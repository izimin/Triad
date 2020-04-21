using System;
using System.Collections.Generic;
using System.Text;

using TriadCore;

namespace TriadCompiler
    {
    /// <summary>
    /// Вычисление выражений над множествами
    /// </summary>
    class SetValue : ConstValue
        {
        /// <summary>
        /// Текущее значение
        /// </summary>
        private Set set;


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="valueList">Элементы множества</param>
        public SetValue( params object[] valueList )
            {
            isConstant = true;

            if ( valueList != null )
                set = new Set( valueList );
            else
                set = new Set();
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="set">Начальное множество</param>
        public SetValue( Set set )
            {
            isConstant = true;

            this.set = new Set( set );
            }


        /// <summary> 
        /// Получить текущее значение
        /// </summary>
        /// <returns> Текущее значение </returns>
        public Set Value
            {
            get
                {
                return set;
                }
            }


        /// <summary>
        /// Добавить элемент в мн-во
        /// </summary>
        /// <param name="value">Значение добавляемого элемента</param>
        public void AddValue( ConstValue value )
            {
            //Если добавляемое значение неконстантное
            if ( !value.IsConstant )
                {
                this.isConstant = false;
                return;
                }

            if ( value is BooleanValue )
                {
                Value.AddValue( ( value as BooleanValue ).Value );
                return;
                }
            else if ( value is IntegerValue )
                {
                Value.AddValue( ( value as IntegerValue ).Value );
                return;
                }
            else if ( value is RealValue )
                {
                Value.AddValue( ( value as RealValue ).Value );
                return;
                }
            else if ( value is CharValue )
                {
                Value.AddValue( ( value as CharValue ).Value );
                return;
                }
            else if ( value is StringValue )
                {
                Value.AddValue( ( value as StringValue ).Value );
                return;
                }
            else if ( value is BitStringValue )
                {
                Value.AddValue( ( value as BitStringValue ).Value );
                return;
                }
            //Если это пустой символ
            else if ( value is NilValue )
                {
                Value.AddValue( null );
                return;
                }

            throw new InvalidOperationException( "Недопустимая операция" );
            }



        /// <summary>
        /// Выполнить бинарную операцию
        /// </summary>
        /// <param name="operation">Код операции</param>
        /// <param name="operand">Второе множество</param>
        /// <returns>Итоговое множество</returns>
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
                    if ( operand is SetValue )
                        return new BooleanValue( set.Equal( ( operand as SetValue ).Value ) );
                    break;
                //Проверка на неравенство !=
                case Key.NotEqual:
                    //Проверка совместимости типов
                    if ( operand is SetValue )
                        return new BooleanValue( set.NotEqual( ( operand as SetValue ).Value ) );
                    break;
                //Проверка на то, что текущее мн-во - подмн-во переданного <=
                case Key.LaterEqual:
                    //Проверка совместимости типов
                    if ( operand is SetValue )
                        return new BooleanValue( set.IsSubsetOf( ( operand as SetValue ).Value ) );
                    break;
                //Проверка на то, что текущее мн-во - надмн-во переданного >=
                case Key.GreaterEqual:
                    //Проверка совместимости типов
                    if ( operand is SetValue )
                        return new BooleanValue( set.IsSupersetOf( ( operand as SetValue ).Value ) );
                    break;
                //Объединение множеств +
                case Key.Plus:
                    //Проверка совместимости типов
                    if ( operand is SetValue )
                        return new SetValue( set.Unite( ( operand as SetValue ).Value ) );
                    break;
                //Вычитание множеств -
                case Key.Minus:
                    //Проверка совместимости типов
                    if ( operand is SetValue )
                        return new SetValue( set.Subtract( ( operand as SetValue ).Value ) );
                    break;
                //Пересечение множеств *
                case Key.Star:
                    //Проверка совместимости типов
                    if ( operand is SetValue )
                        return new SetValue( set.Intersect( ( operand as SetValue ).Value ) );
                    break;
                }

            throw new InvalidOperationException( "Недопустимая операция" );
            }


        }
    }
