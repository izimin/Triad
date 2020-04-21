using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Expr;
using TriadCompiler.Parser.Model.DesignVar;
using TriadCompiler.Parser.Common.Function;

namespace TriadCompiler.Parser.Common.Statement
    {
    /// <summary>
    /// Разбор оператора создания экземпляров объектов let
    /// </summary>
    internal class Let : CommonParser
        {
        /// <summary>
        /// Конструктор модельного типа
        /// </summary>
        /// <syntax>Let Identificator ( expression {, expression} Be Identificator</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <returns>Представление для генерации кода</returns>
        public static CodeStatementCollection Parse( EndKeyList endKeys )
            {
            CodeStatementCollection resultStat = new CodeStatementCollection();

            Accept( Key.Let );

            //Создание экземпляра объекта
            CodeObjectCreateExpression createStat = new CodeObjectCreateExpression();

            //Design тип
            DesignTypeType designType = new DesignTypeType( string.Empty, DesignTypeCode.NoType );

            if ( currKey == Key.Identificator )
                {
                designType.Name = ( currSymbol as IdentSymbol ).Name;
                DesignTypeType type = CommonArea.Instance.GetType<DesignTypeType>( designType.Name );

                if ( type != null )
                    designType = type;
                }

            //Имя создаваемого объекта
            createStat.CreateType = new CodeTypeReference( designType.Name );

            Accept( Key.Identificator );

            //Список параметров
            List<ExprInfo> paramExprList = FunctionInvoke.ParameterList( endKeys.UniteWith( Key.Be ), 
                designType, Key.LeftPar, Key.RightPar );
            foreach ( ExprInfo info in paramExprList )
                createStat.Parameters.Add( info.Code );
            
            Accept( Key.Be );

            //Имя переменной
            string varName = DesignVariable.Parse( endKeys, designType.Code ).StrCode;

            //Вызов метода построения
            CodeExpression buildStat = new CodeExpression();

            switch ( designType.Code )
                {
                //Если создается структура
                case DesignTypeCode.Structure:
                //Если создается модель
                case DesignTypeCode.Model:
                    buildStat = new CodeMethodInvokeExpression( createStat,
                        Builder.Common.BuildMethod );
                    break;
                //Если создается рутина
                case DesignTypeCode.Routine:
                    buildStat = createStat;
                    break;
                }

            //Присваивание
            CodeAssignStatement assignStat = new CodeAssignStatement( new CodeArgumentReferenceExpression( varName ),
                buildStat );
            resultStat.Add( assignStat );

            return resultStat;
            }
        
        }
    }
