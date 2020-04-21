using System;
using System.Collections.Generic;
using System.Text;

namespace TriadCompiler
    {
    /// <summary>
    /// Класс для сравнения зарегистрированных ошибок с ожидаемыми
    /// </summary>
    internal class TestErrorReg : ErrorReg
        {
        /// <summary>
        /// Регистрация ошибки
        /// </summary>
        /// <param name="errCode">Код ошибки</param>
        public override void Register( uint errCode )
            {
            errorCount++;
            io.TestError( errCode );
            }


        /// <summary>
        /// Регистрация ошибки
        /// </summary>
        /// <param name="errCode">Код ошибки</param>
        /// <param name="additionalText">Дополнительный текст</param>
        public override void Register( uint errCode, string additionalText )
            {
            errorCount++;
            
            io.TestError( errCode );
            io.Output.PrintLine( additionalText );
            }


        /// <summary>
        /// Регистрация ошибки, связанной с неожиданным символом
        /// </summary>
        /// <param name="errCode">Код ошибки</param>
        /// <param name="allowedEndKeys">Допустимые конечные символы</param>
        public override void Register( uint errCode, List<Key> allowedEndKeys )
            {
            errorCount++;

            io.TestError( errCode );

            //Список допустимых символов печатать не надо
            }


        // Тестовый ввод-вывод
        private IOTest io
            {
            get
                {
                return Fabric.IO as IOTest;
                }
            }
        }
    }
