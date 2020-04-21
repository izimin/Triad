using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Информация для слежения за переменной
    /// </summary>
    public class SpyVar : SpyObject
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="realName">Имя переменной в объекте</param>
        /// <param name="varContainer">Объект, содержащий переменную</param>
        public SpyVar( CoreName realName, ReflectionObject varContainer )
            : base( realName, varContainer )
            {
            this.varContainer = varContainer;
            }


        /// <summary>
        /// Операция сравнения
        /// </summary>
        /// <param name="other"></param>
        /// <returns>True, если объекты совпадают</returns>
        public override bool Equals( SpyObject other )
            {
            SpyVar spyVarInfo = other as SpyVar;

            //Если объект имеет неподходящий тип
            if ( spyVarInfo == null )
                return false;

            return base.Equals( other );
            }



        /// <summary>
        /// Значение переменной
        /// </summary>
        public object Value
            {
            set
                {
                if ( this.varContainer != null )
                    {
                    this.varContainer.SetValueForVar( this.RealName, value );
                    }
                }
            get
                {
                if ( this.varContainer != null )
                    {
                    return this.varContainer.GetValueForVar( this.RealName );
                    }
                return null;
                }
            }


        /// <summary>
        /// Создать копию
        /// </summary>
        /// <returns></returns>
        public override SpyObject Clone()
            {
            return new SpyVar( this.RealName, this.Container );
            }


        /// <summary>
        /// Объект, содержащий переменную
        /// </summary>
        private ReflectionObject varContainer;
        }
    }
