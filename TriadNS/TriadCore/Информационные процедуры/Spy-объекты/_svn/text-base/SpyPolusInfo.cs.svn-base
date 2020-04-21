using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCore
    {
    /// <summary>
    /// Информация для слежения за полюсом
    /// </summary>
    public class SpyPolus : SpyObject
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="realName">Настоящее имя полюса</param>
        /// <param name="objectContainer">Объект-контейнер (обязательно рутина)</param>
        public SpyPolus( CoreName realName, ReflectionObject objectContainer )
            : base( realName, objectContainer )
            {
            if ( !( objectContainer is Routine ) )
                throw new ArgumentException( "Следить можно только за полюсом рутины" );
            }


        /// <summary>
        /// Операция сравнения
        /// </summary>
        /// <param name="other"></param>
        /// <returns>True, если объекты совпадают</returns>
        public override bool Equals( SpyObject other )
            {
            SpyPolus spyVarInfo = other as SpyPolus;

            //Если объект имеет неподходящий тип
            if ( spyVarInfo == null )
                return false;

            return base.Equals( other );
            }



        /// <summary>
        /// Базовая рутина
        /// </summary>
        private Routine BaseRoutine
            {
            get
                {
                return ( this.Container as Routine );
                }
            }


        /// <summary>
        /// Блокировать полюс
        /// </summary>
        public void BlockPolus()
            {
            this.BaseRoutine.BlockNodePolus( this.RealName );
            }


        /// <summary>
        /// Разблокировать полюс
        /// </summary>
        public void UnblockPolus()
            {
            this.BaseRoutine.UnblockNodePolus( this.RealName );
            }

        }
    }
