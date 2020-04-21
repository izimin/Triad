using System;
using System.Collections.Generic;
using System.Text;
//by jum
using System.CodeDom;

using TriadCompiler.Parser.Common.Declaration.Var;
using TriadCompiler.Parser.Common.Expr;
using TriadCompiler.Parser.Common.Statement;

namespace TriadCompiler.Parser.Common.Declaration.Var
    {
    /// <summary>
    /// Разбор объявления переменных
    /// </summary>
    internal class VarDeclaration : CommonParser
        {
        /// <summary>
        /// Объявление переменной
        /// </summary>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <param name="context">Констекст</param>
        /// <returns>Типы объявленных переменных</returns>
        public static List<IExprType> Parse( EndKeyList endKeys, VarDeclarationContext context )
            {
            List<IExprType> varTypeList = new List<IExprType>();

            //Если нужно регистрировать переменные
            if ( context != VarDeclarationContext.IncludeSection )
                varTypeList.AddRange( DeclarationWithRegistration( endKeys, context ) );
            else
                varTypeList.AddRange( DeclarationWithOutRegistration( endKeys, context ) );
            
            return varTypeList;
            }


        /// <summary>
        /// Объявление переменной с инициализацией
        /// </summary>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <returns>словарь тип->код инициализации</returns>
        public static Dictionary<IExprType, CodeExpression> Parse(EndKeyList endKeys)
        {
            Dictionary<IExprType, CodeExpression> result = new Dictionary<IExprType, CodeExpression>();
            IExprType varType = TypeDeclaration.Parse(endKeys.UniteWith(Key.Identificator));
            do
            {
                if (result.Count > 0)
                    Accept(Key.Comma);
                IExprType var = VarName(endKeys.UniteWith(Key.Comma, Key.Assign), varType, true, VarDeclarationContext.Common);
                CodeExpression initExpression = null;
                if (currKey == Key.Assign)
                {
                    Accept(Key.Assign);

                    ExprInfo exprInfo = Expression.Parse(endKeys.UniteWith(Key.Comma));
                    
                    if (!Assignement.CheckVarTypes(varType, exprInfo.Type))
                        SkipTo(endKeys.UniteWith(Key.Comma));
                    else
                        initExpression = exprInfo.Code;
                }
                result[var] = initExpression;
            }
            while (currKey == Key.Comma);

            return result;
        }

        /// <summary>
        /// Разбор имени переменной в ее объявлении
        /// </summary>
        /// <syntax>IDentificator</syntax>
        /// <param name="endKeys">Допустимые конечные символы</param>
        /// <param name="varType">Тип всех переменных в объявлении</param>
        /// <param name="registerType">Необходимость регистрации типа</param>
        /// <param name="context">Контекст объявления</param>
        /// <returns>Тип переменной</returns>
        private static IExprType VarName( EndKeyList endKeys, IExprType varType, bool registerType, VarDeclarationContext context )
            {
            //Тип переменной
            IExprType resultType = null;
            if ( varType != null )
                resultType = varType.Clone();

            if ( currKey != Key.Identificator )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongStartSymbol.VarDeclarationName, Key.Identificator );
                SkipTo( endKeys.UniteWith( Key.Identificator ) );
                }
            if ( currKey == Key.Identificator )
                {
                resultType.Name = ( currSymbol as IdentSymbol ).Name;                

                //Если тип переменной нужно регистрировать
                if ( registerType )
                    CommonArea.Instance.Register( resultType );

                //Если это spy-объект
                if ( context == VarDeclarationContext.SpyObjectList )
                    resultType.IsSpyObject = true;

                GetNextKey();

                //by jum
                //объявление полюсов в вершине
                if (resultType.Code == TypeCode.Node && currKey == Key.Later)
                {
                    (Fabric.Instance.Builder as GraphCodeBuilder).AddBuildStatementList(PolusDeclarationParse(endKeys, resultType.Name));
                }

                if ( !endKeys.Contains( currKey ) )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.VarDeclarationName, endKeys.GetLastKeys() );
                    SkipTo( endKeys );
                    }
                }

            return resultType;
            }

        //by jum
        /// <summary>
        ///  Разбор объявления полюсов в объявлении вершины
        /// </summary>
        /// <param name="endKeys">Допустимые конечные символы</param>
        /// <param name="nodeVarName">Имя вершины, куда добавить полюса</param>
        /// <returns>Представление для генерации кода</returns>
        private static CodeStatementCollection PolusDeclarationParse(EndKeyList endKeys, string nodeVarName)
        {
            CodeStatementCollection statements = new CodeStatementCollection();

            Accept(Key.Later);

            if (currKey != Key.Identificator)
            {
                Fabric.Instance.ErrReg.Register(Err.Parser.WrongStartSymbol.ObjectReference, Key.Identificator);
                SkipTo(endKeys.UniteWith(Key.Identificator, Key.Greater));
            }

            if (currKey == Key.Identificator)
            {
                string polusName = (currSymbol as IdentSymbol).Name;

                Accept(Key.Identificator);

                //генерация кода
                CodeMethodInvokeExpression declarePolusStat = new CodeMethodInvokeExpression(new CodeVariableReferenceExpression(nodeVarName), Builder.Structure.BuildExpr.DeclareOperation.DecalarePolusInNode, new CodeObjectCreateExpression(Builder.CoreName.Name, new CodePrimitiveExpression(polusName)));

                statements.Add(declarePolusStat);
            }

            while (currKey == Key.Comma)
            {
                Accept(Key.Comma);

                if (currKey != Key.Identificator)
                {
                    Fabric.Instance.ErrReg.Register(Err.Parser.WrongStartSymbol.ObjectReference, Key.Identificator);
                    SkipTo(endKeys.UniteWith(Key.Identificator, Key.Greater));
                }

                if (currKey == Key.Identificator)
                {
                    string polusName = (currSymbol as IdentSymbol).Name;

                    Accept(Key.Identificator);

                    //генерация кода
                    CodeMethodInvokeExpression declarePolusStat = new CodeMethodInvokeExpression(new CodeVariableReferenceExpression(nodeVarName), Builder.Structure.BuildExpr.DeclareOperation.DecalarePolusInNode, new CodeObjectCreateExpression(Builder.CoreName.Name, new CodePrimitiveExpression(polusName)));

                    statements.Add(declarePolusStat);
                }
            }

            Accept(Key.Greater);

            return statements;
        }

        /// <summary>
        /// Обычное объявление переменных
        /// </summary>
        /// <syntax>Type Identificator {,Identificator}</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <param name="context">Контекст</param>
        /// <returns>Список типов объявленных переменных</returns>
        private static List<IExprType> DeclarationWithRegistration( EndKeyList endKeys, VarDeclarationContext context )
            {
            List<IExprType> varTypeList = new List<IExprType>();

            IExprType varType = TypeDeclaration.Parse( endKeys.UniteWith( Key.Identificator ) );

            //Имя переменной
            varTypeList.Add( VarName( endKeys.UniteWith( Key.Comma ), varType, true, context ) );
 
            while ( currKey == Key.Comma )
                {
                GetNextKey();

                //Имя переменной
                varTypeList.Add( VarName( endKeys.UniteWith( Key.Comma ), varType, true, context ) );
                }

            return varTypeList;
            }


        /// <summary>
        /// Объявление переменных без регистрации их имен
        /// </summary>
        /// <syntax>Type #Identificator {,Identificator}#</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <param name="context">Констекст объявления</param>
        /// <returns>Список типов объявленных переменных</returns>
        private static List<IExprType> DeclarationWithOutRegistration( EndKeyList endKeys, VarDeclarationContext context )
            {
            List<IExprType> varTypeList = new List<IExprType>();

            IExprType varType = TypeDeclaration.Parse( endKeys.UniteWith( Key.Identificator ) );

            //Необязательная часть
            if ( currKey == Key.Identificator )
                {
                //Имя переменной
                varTypeList.Add( VarName( endKeys.UniteWith( Key.Comma ), varType, false, context ) );

                while ( currKey == Key.Comma )
                    {
                    GetNextKey();

                    //Имя переменной
                    varTypeList.Add( VarName( endKeys.UniteWith( Key.Comma ), varType, false, context ) );
                    }
                }
            //Если имени переменной не указано
            else
                {
                varTypeList.Add( varType );
                }

            return varTypeList;
            }
        
        }
    }
