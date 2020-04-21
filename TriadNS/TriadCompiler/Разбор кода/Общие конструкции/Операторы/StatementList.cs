using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

namespace TriadCompiler.Parser.Common.Statement
    {
    /// <summary>
    /// Контекст вызова оператора
    /// </summary>
    public enum StatementContext
        {
        /// <summary>
        /// Секция инициализации
        /// </summary>
        Initial,
        /// <summary>
        /// Событие обработки входных сообщений
        /// </summary>
        MessageEvent,
        /// <summary>
        /// Обычный контекст
        /// </summary>
        Common,
        /// <summary>
        /// Секция обработки в информационной процедуре
        /// </summary>
        Handling,
        }


    /// <summary>
    /// Разбор последовательности операторов
    /// </summary>
    internal class StatementList : CommonParser
        {
        /// <summary>
        /// Последовательность операторов
        /// </summary>
        /// <syntax>Statement {;Statement}</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <param name="context">Контекст оператора</param>
        /// <returns>Класс для генерации кода</returns>
        public static CodeStatementCollection Parse( EndKeyList endKeys, StatementContext context )
            {
            CodeStatementCollection statementList = new CodeStatementCollection();
            statementList.AddRange( Fabric.Instance.Parser.Statement( endKeys.UniteWith( Key.Semicolon ), context ) );
            while ( currKey == Key.Semicolon )
                {
                GetNextKey();
                statementList.AddRange( Fabric.Instance.Parser.Statement( endKeys.UniteWith( Key.Semicolon ), context ) );
                }
            return statementList;
            }

        }
    }
