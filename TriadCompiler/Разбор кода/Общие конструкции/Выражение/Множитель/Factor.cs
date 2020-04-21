using System;
using System.Collections.Generic;
using System.Text;

using TriadCompiler.Parser.Common.Expr;
using TriadCompiler.Parser.Common.Expr.SimpleFact;

namespace TriadCompiler.Parser.Common.Expr.Fact
    {
    /// <summary>
    /// Разбор множителя в арифметическом выражении
    /// </summary>
    internal partial class Factor : CommonParser
        {
        /// <summary>
        /// Множитель
        /// </summary>
        /// <syntax>Not Factor | SimpleFactor {Power SimpleFactor}</syntax>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <returns>Информация о множителе</returns>
        public static ExprInfo Parse( EndKeyList endKeys )
            {
            ExprInfo info = new ExprInfo();

            //Если перед множителем стоит отрицание
            if ( currKey == Key.Not )
                {
                GetNextKey();
                info = Factor.Parse( endKeys );

                //Проверка типа
                info.Type = CheckTypeInNotFactor( info.Type );

                //Генерация кода
                BuildStringCodeForNotFactor( info );

                if ( info.HasNoError )
                    info.Value = info.Value.CalculateWith( Key.Not );
                }

            //Если перед множителем не стоит отрицание
            else
                {
                info = SimpleFactor.Parse( endKeys.UniteWith( Key.Power ) );

                while ( currKey == Key.Power )
                    {
                    GetNextKey();

                    ExprInfo nextSimpleFactorInfo = SimpleFactor.Parse( endKeys.UniteWith( Key.Power ) );

                    //Генерация кода
                    BuildStringCodeForFactor( info, nextSimpleFactorInfo );

                    //Проверка типов
                    info.Type = CheckTypeInSimpleFactor( info.Type, nextSimpleFactorInfo.Type );

                    if ( info.HasNoError )
                        info.Value = info.Value.CalculateWith( Key.Power, nextSimpleFactorInfo.Value );
                    }
                }

            return info;
            }     

        
        }
    }
