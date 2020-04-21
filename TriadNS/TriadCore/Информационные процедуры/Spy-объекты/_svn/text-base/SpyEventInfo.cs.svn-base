using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Информация, необходимая для слежения за событиями
    /// </summary>
    public class SpyEvent : SpyObject
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="realName">Настоящее имя события</param>
        /// <param name="objectContainer">Объект-контейнер</param>
        public SpyEvent( CoreName realName, ReflectionObject objectContainer )
            : base( realName, objectContainer )
            {
            }


        /// <summary>
        /// Операция сравнения
        /// </summary>
        /// <param name="other"></param>
        /// <returns>True, если объекты совпадают</returns>
        public override bool Equals( SpyObject other )
            {
            SpyEvent spyVarInfo = other as SpyEvent;

            //Если объект имеет неподходящий тип
            if ( spyVarInfo == null )
                return false;

            return spyVarInfo.RealName.Equals( this.RealName );
            }
        }
    }
