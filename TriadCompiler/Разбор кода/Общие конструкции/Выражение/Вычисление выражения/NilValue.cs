using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Вычисление выражений с nil
    /// </summary>
    class NilValue : ConstValue
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public NilValue()
            {
            this.isConstant = true;
            }


        /// <summary>
        /// Обработать двуместную операцию
        /// </summary>
        /// <param name="operation">Операция</param>
        /// <param name="operand">Второй операнд</param>
        /// <returns>Результат</returns>
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
                    if ( operand is NilValue )
                        return new BooleanValue( true );
                    break;

                //Проверка на неравенство !=
                case Key.NotEqual:
                    //Проверка совместимости типов
                    if ( operand is NilValue )
                        return new BooleanValue( false );
                    break;
                }

            throw new InvalidOperationException( "Несовместимые типы аргументов" );
            }
        }
    }
