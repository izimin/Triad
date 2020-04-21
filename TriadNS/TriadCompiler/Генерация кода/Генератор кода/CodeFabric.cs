using System;
using System.Collections.Generic;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.IO;

using TriadCompiler.Code.Generator;

namespace TriadCompiler.Code.Generator
    {
    /// <summary>
    /// Формат результирующего кода
    /// </summary>
    internal enum CodeFormat
        {
        /// <summary>
        /// Без генерации кода
        /// </summary>
        None,
        /// <summary>
        /// Генерация Dll
        /// </summary>
        Dll,
        /// <summary>
        /// Генерация Txt
        /// </summary>
        Txt,
        /// <summary>
        /// Генерация в память
        /// </summary>
        Memory
        }


    /// <summary>
    /// Текущий генератор кода (одиночка)
    /// </summary>
    internal class CodeFabric
        {
        /// <summary>
        /// Защищенный конструктор
        /// </summary>
        protected CodeFabric()
            {
            }


        /// <summary>
        /// Изменить режим работы генератора кода
        /// </summary>
        /// <param name="codeFormat"></param>
        public static void ReloadFabric( CodeFormat codeFormat )
            {
            //Если фабрика уже создана
            if ( instance != null )
                {
                //Если режим работы не изменился, то перезагружаем все классы
                if ( generatingMode == codeFormat )
                    {
                    //Перезагружаем генератор кода
                    Instance.Reload();
                    }
                //Если режим работы изменился, то создаем новую фабрику
                else
                    {
                    generatingMode = codeFormat;
                    instance = null;
                    }
                }
            //Иначе просто создаем новую фабрику
            else
                {
                generatingMode = codeFormat;
                }
            }


        /// <summary>
        /// Генератор кода (одиночка)
        /// </summary>
        public static CommonGenerator Instance
            {
            get
                {
                if ( instance == null )
                    switch ( generatingMode )
                        {
                        case CodeFormat.None:
                            instance = new CommonGenerator();
                            break;
                        case CodeFormat.Dll:
                            instance = new DllGenerator();
                            break;
                        case CodeFormat.Txt:
                            instance = new TxtGenerator();
                            break;
                        case CodeFormat.Memory:
                            instance = new MemoryGenerator();
                            break;
                        default:
                            throw new InvalidOperationException( "Недопустимый режим работы" );
                        }
                return instance;
                }
            }


        /// <summary>
        /// Создать новый экземпляр этого класса
        /// </summary>
        /// <param name="codeFormat">Формат результирующего кода</param>
        public static void CreateNewInstance( CodeFormat codeFormat )
            {
            generatingMode = codeFormat;
            instance = null;
            }


        /// <summary>
        /// Экземпляр этого класса
        /// </summary>
        private static CommonGenerator instance = null;
        /// <summary>
        /// Текущий режим
        /// </summary>
        private static CodeFormat generatingMode = CodeFormat.None;
        }   
    
    }





    
    