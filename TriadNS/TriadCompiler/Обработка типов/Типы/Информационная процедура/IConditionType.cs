using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Тип условий моделирования
    /// </summary>
    class IConditionType : IProcedureType
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="conditionName">Имя условий моделирования</param>
        public IConditionType( string conditionName )
            : base( conditionName )
            {
            }


        /// <summary>
        /// Возвращаемое значение (пустое - т.к. у условий моделирования его нет)
        /// </summary>
        public override TypeCode ReturnCode
            {
            get
                {
                return TypeCode.UndefinedType;
                }
            set
                {
                }
            }
        }
    }
