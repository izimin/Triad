using System;

namespace TriadCompiler
    {
    /// <summary>
    /// Родительский класс, предназначенный для хранения и вычисления константных выражений.
    /// </summary>
    internal class ConstValue
        {
        /// <summary>
        /// 	<para> Конструктор класса <see cref="ConstValue"/> .</para>
        /// </summary>
        public ConstValue()
        { }


        /// <summary>
        /// Проверка того, является ли значение константой
        /// </summary>
        /// <returns>true - если это константа</returns>
        public bool IsConstant
            {
            get
                {
                return isConstant;
                }
            }


        /// <summary>
        /// Произвести вычисления по унарной операции relationOperation с текущим значениеми
        /// </summary>
        /// <param name="operation">Код операции</param>
        /// <returns>Контейнер результа вычислений</returns>
        public virtual ConstValue CalculateWith( Key operation )
            {
            return this;
            }


        /// <summary>
        /// Произвести вычисления по операции relationOperation с текущим и переданным значениями
        /// Результат будет сохранен в текущем значении
        /// </summary>
        /// <param name="operation">Код операции</param>
        /// <param name="operand">Второй операнд (первый - this)</param>
        /// <returns>Контейнер результа вычислений</returns>
        public virtual ConstValue CalculateWith( Key operation, ConstValue operand )
            {
            return this;
            }


        /// <summary>
        /// Индикатор того, что значение - константа
        /// </summary>
        protected bool isConstant = false;
        }
    }


