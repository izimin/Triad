using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Function;
using TriadCompiler.Parser.Common.Var;
using TriadCompiler.Parser.Common.Polus;
using TriadCompiler.Parser.Common.Ev;
using TriadCompiler.Parser.Common.Statement;
using TriadCompiler.Parser.Common.Expr;
using TriadCompiler.Parser.Design.Statement;

namespace TriadCompiler.Parser.SimCondition.Statement
    {
    /// <summary>
    /// Разбор вызова ИП
    /// </summary>
    internal partial class IPCall : CommonParser
        {
        /// <summary>
        /// Порядковый номер вызова ИП
        /// </summary>
        private static int ipCallNumber = 0;


        /// <summary>
        ///  Строитель кода
        /// </summary>
        private static IConditionCodeBuilder codeBuilder
            {
            get
                {
                return Fabric.Instance.Builder as IConditionCodeBuilder;
                }
            }


        /// <summary>
        /// Вызов ИП
        /// </summary>
        /// <syntax>Identificator # [ ParameterList ] # SpyParameterList # { ParameterList } # # IPAssignment #</syntax>
        /// <param name="endKeys">Множество конечных символов</param> 
        /// <returns>Тип ИП</returns>
        public static IPCallInfo Parse( EndKeyList endKeys )
            {
            IPCallInfo ipCallInfo = new IPCallInfo();

            //Имя ИП
            string ipName = ( currSymbol as IdentSymbol ).Name;

            //Первый символ всегда Identificator
            ipCallInfo.Type = CommonArea.Instance.GetType<IProcedureType>( ipName );
            //Порядковый номер ИП
            ipCallInfo.ipCallNumber = ipCallNumber;

            Accept( Key.Identificator );

            //Список параметров 
            List<ExprInfo> paramList = new List<ExprInfo>();
            //Указание списка параметров
            if ( currKey == Key.LeftBracket )
                {
                paramList.AddRange( FunctionInvoke.ParameterList( endKeys.UniteWith( Key.LeftPar, Key.LeftFigurePar, Key.Colon ),
                    ipCallInfo.Type.ParamVarList, Key.LeftBracket, Key.RightBracket ) );
                }
            //Если параметры не указаны, а они должны быть
            else if ( ipCallInfo.Type.ParamVarList.ParameterCount > 0 )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.Usage.ParameterList.NotEnoughParameters );
                }

            //Создаем метод, добавляющий ИП
            codeBuilder.SetInitialSection( GenerateIProcedureCreation( ipName, ipCallNumber, paramList ) );

            //Список spy-объектов
            codeBuilder.SetInitialSection( SpyParameterList( endKeys.UniteWith( Key.LeftFigurePar, Key.Colon ), ipCallInfo, SingleSpyObject ) );

            //Список Out-переменных
            if ( currKey == Key.LeftFigurePar )
                {
                ipCallInfo.Code.Add( OutVarList( endKeys.UniteWith( Key.Colon ), ipCallInfo ) );
                }

            //Если указана переменная, куда нужно записать результат
            if ( currKey == Key.Colon )
                {
                //Если ИП не возращает никакого значения
                if ( ipCallInfo.Type.ReturnCode == TypeCode.UndefinedType )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.Usage.IProcedure.NoReturnedValue );
                    }

                ipCallInfo.Code.Add( IPAssignment( endKeys, ipName ) );
                }

            //Генерируем метод, инициализирующий ИП
            codeBuilder.SetInitialSection( GenerateIProcedureInitialization( ipCallNumber ) );

            ipCallNumber++;
            return ipCallInfo;
            } 


        
        /// <summary>
        /// Список spy-объектов
        /// </summary>
        /// <syntax>( SingleSpyObject {, SingleSpyObject } )</syntax>
        /// <param name="endKeys">Допустимые конечные символы</param>
        /// <param name="ipCallInfo">Информация о вызове информационной процедуры</param>
        /// <param name="singeSpyObject">Метод, разбирающий одиночный spy-объект</param>
        /// <returns>Сгенерированный код</returns>
        public static CodeStatementCollection SpyParameterList( EndKeyList endKeys, IPCallInfo ipCallInfo, SingleSpyObjectDelegate singeSpyObject )
            {
            //Генерируем метод, регистрирующий spy-объекты в рутине
            CodeMethodInvokeExpression registerSpyObjectsStat = new CodeMethodInvokeExpression();
            registerSpyObjectsStat.Method = new CodeMethodReferenceExpression();
            registerSpyObjectsStat.Method.MethodName = Builder.IProcedure.RegisterAllSpyObjects;
            registerSpyObjectsStat.Method.TargetObject = GetIProcedureCode( ipCallInfo.Type.Name, ipCallInfo.ipCallNumber );

            if ( currKey != Key.LeftPar )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongStartSymbol.FunctionParameterList, Key.LeftPar );
                SkipTo( endKeys.UniteWith( Key.LeftPar ) );
                }
            if ( currKey == Key.LeftPar )
                {
                GetNextKey();

                //Счетчик параметров
                IEnumerator<ISpyType> paramEnumerator = ipCallInfo.Type.GetEnumerator();
                paramEnumerator.MoveNext();

                //Если это не пустой список параметров
                if ( currKey != Key.RightPar )
                    {
                    registerSpyObjectsStat.Parameters.Add(
                        singeSpyObject( endKeys.UniteWith( Key.RightPar, Key.Comma ), paramEnumerator ) );

                    while ( currKey == Key.Comma )
                        {
                        GetNextKey();

                        registerSpyObjectsStat.Parameters.Add(
                            singeSpyObject( endKeys.UniteWith( Key.RightPar, Key.Comma ), paramEnumerator ) );
                        }
                    }

                Accept( Key.RightPar );

                //Если были указаны не все параметры
                if ( paramEnumerator.Current != null )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.Usage.ParameterList.NotEnoughParameters );
                    }

                if ( !endKeys.Contains( currKey ) )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.FunctionParameterList, endKeys.GetLastKeys() );
                    SkipTo( endKeys );
                    }
                }

            //Добавляем этот метод в секцию инициализации
            CodeStatementCollection statList = new CodeStatementCollection();
            statList.Add( registerSpyObjectsStat );
            return statList;
            }


        /// <summary>
        /// Метод, разбирающий одиночный spy-объект в списке spy-объектов
        /// </summary>
        /// <param name="endKeys">Допустимые конечные символы</param>
        /// <param name="enumerator">Тип формального параметра</param>
        /// <returns>>Код метода, возращающего этот spy-объект</returns>
        public delegate CodeMethodInvokeExpression SingleSpyObjectDelegate( EndKeyList endKeys, IEnumerator<ISpyType> enumerator );


        /// <summary>
        /// Один spy-объект
        /// </summary>
        /// <syntax>Variable | PolusVar | EventVar</syntax>
        /// <param name="endKeys">Допустимые конечные символы</param>
        /// <param name="enumerator">Тип формального параметра</param>
        /// <returns>Код метода, возращающего этот spy-объект</returns>
        private static CodeMethodInvokeExpression SingleSpyObject( EndKeyList endKeys, IEnumerator<ISpyType> enumerator )
            {
            CodeMethodInvokeExpression getSpyObjectStat = new CodeMethodInvokeExpression();
            getSpyObjectStat.Method = new CodeMethodReferenceExpression();


            if ( currKey != Key.Identificator )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongStartSymbol.SpyObject, Key.Identificator );
                SkipTo( endKeys.UniteWith( Key.Identificator ) );
                }
            if ( currKey == Key.Identificator )
                {
                ISpyType spyFormalType = enumerator.Current;

                if ( spyFormalType != null )
                    {
                    ISpyType spyOjectType = null;

                    getSpyObjectStat.Method.MethodName = Builder.IProcedure.GetSpyObject;

                    // ????????
                    string sIdentName = (currSymbol as IdentSymbol).Name;
                    if (CommonArea.Instance.IsGraphRegistered(sIdentName) /*&& sIdentName == Builder.ICondition.CurrentModel*/)
                    {
                        Accept(Key.Identificator);
                        Accept(Key.Point);
                        Simulate.modelName = sIdentName;
                        return Simulate.SingleSpyObject(endKeys, enumerator);
                    }
                    else if (CommonArea.Instance.IsNodeRegistered(sIdentName))
                    {
                        return Simulate.SingleSpyObject(endKeys, enumerator);
                    }

                    //Если это должна быть переменная
                    if ( spyFormalType is IExprType )
                        {
                        VarInfo varInfo = Variable.Parse( endKeys, /*Allow range*/ true,
                            /*Allow not indexed array*/ false );
                        Assignement.CheckVarTypes( spyFormalType as IExprType, varInfo.Type );
                        spyOjectType = varInfo.Type;

                        //Параметр
                        getSpyObjectStat.Parameters.Add( varInfo.CoreNameCode );
                        }
                    //Если это должен быть полюс
                    else if ( spyFormalType is IPolusType )
                        {
                        PolusInfo polusInfo = PolusVar.Parse( endKeys );
                        Assignement.CheckPolusTypes( spyFormalType as IPolusType, polusInfo.Type );
                        spyOjectType = polusInfo.Type;

                        //Параметр
                        getSpyObjectStat.Parameters.Add( polusInfo.CoreNameCode );
                        }
                    //Если это должно быть событие
                    else if ( spyFormalType is EventType )
                        {
                        EventInfo eventInfo = EventVar.Parse( endKeys, /*Check registration*/ true );
                        spyOjectType = eventInfo.Type;

                        //Генерим параметр
                        getSpyObjectStat.Parameters.Add( eventInfo.CoreNameCode );
                        }

                    //Проверяем, это spy-объект?
                    if ( spyOjectType != null )
                        if ( spyOjectType != null && !spyOjectType.IsSpyObject )
                            {
                            Fabric.Instance.ErrReg.Register( Err.Parser.Usage.NeedSpyObject );
                            }
                    enumerator.MoveNext();
                    }
                //Столько индексов объявлено не было
                else
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.Usage.ParameterList.TooManyParameters );
                    }
                }

            return getSpyObjectStat;
            }


        /// <summary>
        /// Список out-переменных
        /// </summary>
        /// <param name="endKeys">Допустимые конечные символы</param>
        /// <param name="ipCallInfo">Информация о ИП</param>
        /// <returns>Код метода, возращающего значения out-переменных</returns>
        public static CodeMethodInvokeExpression OutVarList( EndKeyList endKeys, IPCallInfo ipCallInfo )
            {
            //Генерируем вызов функции, возращающей значения out-переменных
            CodeMethodInvokeExpression getOutVarStat = new CodeMethodInvokeExpression();
            getOutVarStat.Method = new CodeMethodReferenceExpression();
            getOutVarStat.Method.TargetObject = GetIProcedureCode( ipCallInfo.Type.Name, ipCallInfo.ipCallNumber );
            getOutVarStat.Method.MethodName = Builder.IProcedure.GetOutVariables;

            Accept( Key.LeftFigurePar );

            //Счетчик параметров
            IEnumerator<IExprType> paramEnumerator = ipCallInfo.Type.OutVarList.GetEnumerator();
            paramEnumerator.MoveNext();

            //Если это не пустой список параметров
            if ( currKey != Key.RightFigurePar )
                {
                VarInfo varInfo = Variable.Parse( endKeys.UniteWith( Key.RightFigurePar, Key.Comma ), false, true );

                //Проверка параметра
                FunctionInvoke.CheckParameterType( paramEnumerator, varInfo.Type );

                //Генерим параметр
                getOutVarStat.Parameters.Add( new CodeSnippetExpression( "out " + varInfo.StrCode ) );

                while ( currKey == Key.Comma )
                    {
                    GetNextKey();

                    varInfo = Variable.Parse( endKeys.UniteWith( Key.RightFigurePar, Key.Comma ), false, true );

                    //Проверка параметра
                    FunctionInvoke.CheckParameterType( paramEnumerator, varInfo.Type );

                    //Генерим параметр
                    getOutVarStat.Parameters.Add( new CodeSnippetExpression( "out " + varInfo.StrCode ) );
                    }
                }

            //Если были указаны не все параметры
            if ( paramEnumerator.Current != null )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.Usage.ParameterList.NotEnoughParameters );
                }

            Accept( Key.RightFigurePar );

            if ( !endKeys.Contains( currKey ) )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.FunctionParameterList, endKeys.GetLastKeys() );
                SkipTo( endKeys );
                }
            return getOutVarStat;
            }


        /// <summary>
        /// Разбор результирующего присваивания
        /// </summary>
        /// <param name="endKeys">Допустимые конечные символы</param>
        /// <param name="ipName">Имя ИП</param>
        /// <returns>Код метода, выполняюшего присваивание</returns>
        private static CodeAssignStatement IPAssignment( EndKeyList endKeys, string ipName )
            {
            Accept( Key.Colon );

            VarInfo varInfo = Variable.Parse( endKeys, false, false );

            //Создаем метод, выполняющий присваивание
            CodeAssignStatement asignStat = new CodeAssignStatement();
            asignStat.Left = varInfo.Code;

            //Получаем результат из рутины
            CodeMethodInvokeExpression doProcessStat = new CodeMethodInvokeExpression();
            doProcessStat.Method = new CodeMethodReferenceExpression();
            doProcessStat.Method.MethodName = Builder.IProcedure.DoProcessing;
            doProcessStat.Method.TargetObject = GetIProcedureCode( ipName, ipCallNumber );

            asignStat.Right = doProcessStat;

            return asignStat;
            }

        }
    }
