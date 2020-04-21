using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Expr;

namespace TriadCompiler.Parser.Common.ObjectRef
    {
    /// <summary>
    /// Ссылка на любой объект или на диапазон объектов
    /// </summary>
    /// <remarks>В этом классе нельзя объявлять static переменные,
    /// т.к. вызовы разбора объекта могут быть вложенными!!!</remarks>
    class ObjectReference : CommonParser
        {
        /// <summary>
        /// Дополнительная проверка индекса
        /// </summary>
        /// <param name="objectName">Имя объекта</param>
        /// <param name="exprInfo">Значение индекса</param>
        /// <param name="indexNumber">Номер индекса</param>
        public delegate void AdditionalIndexCheck( string objectName, ExprInfo exprInfo, int indexNumber );


        /// <summary>
        /// Разбор ссылки
        /// </summary>
        /// <param name="endKeys">Допустимые конечные символы</param>
        /// <param name="allowRange">Разрешены ли диапазоны</param>
        /// <returns>Описание ссылки</returns>
        /// <remarks>В целях унификации возвращаемое ObjectRefInfo даже
        /// одиночные объекты описывает как диапазоны из одного символа, хотя
        /// код генерит правильно</remarks>
        /// <syntax>Identificator # [ IndexBounds {,IndexBounds} ] #</syntax>
        public static ObjectRefInfo Parse( EndKeyList endKeys, bool allowRange )
            {
            return Parse( endKeys, allowRange, delegate( string objectName, ExprInfo exprInfo, int indexNumber ) { } );
            }


        /// <summary>
        /// Разбор ссылки
        /// </summary>
        /// <param name="endKeys">Допустимые конечные символы</param>
        /// <param name="allowRange">Разрешены ли диапазоны</param>
        /// <param name="additionalIndexCheck">Дополнительная проверка индекса</param>
        /// <returns>Описание ссылки</returns>
        /// <remarks>В целях унификации возвращаемое ObjectRefInfo даже
        /// одиночные объекты описывает как диапазоны из одного символа, хотя
        /// код генерит правильно</remarks>
        /// <syntax>Ident # [ IndexBounds {,IndexBounds} ] #</syntax>
        public static ObjectRefInfo Parse( EndKeyList endKeys, bool allowRange, AdditionalIndexCheck additionalIndexCheck )
            {
            ObjectRefInfo refInfo = new ObjectRefInfo();

            if ( currKey != Key.Identificator )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongStartSymbol.ObjectReference, Key.Identificator );
                SkipTo( endKeys.UniteWith( Key.Identificator ) );
                }
            if ( currKey == Key.Identificator )
                {
                refInfo.Name = ( currSymbol as IdentSymbol ).Name;
                refInfo.AppendStrCode( refInfo.Name );

                Accept( Key.Identificator );

                //Если это индексированный объект
                if ( currKey == Key.LeftBracket )
                    {
                    refInfo.AppendStrCode( "[" );

                    //Был ли указан диапазон индексов
                    bool indexRangeFound = false;

                    // Номер текущего разбираемого индекса
                    int currIndexNumber = 0;
                    do
                        {
                        GetNextKey();
                        refInfo.AddIndexBounds( IndexBounds( endKeys.UniteWith( Key.Comma, Key.RightBracket ), allowRange,
                            ref indexRangeFound, refInfo, currIndexNumber, additionalIndexCheck ) );
                        currIndexNumber++;

                        if ( currKey == Key.Comma )
                            refInfo.AppendStrCode( "," );
                        }
                    while ( currKey == Key.Comma );

                    Accept( Key.RightBracket );
                    refInfo.AppendStrCode( "]" );

                    refInfo.IsRange = indexRangeFound;

                    //Генерация кода
                    CodeObjectCreateExpression createStat = new CodeObjectCreateExpression();
                    createStat.Parameters.Add( new CodePrimitiveExpression( refInfo.Name ) );

                    //Если это ссылка на одиночный индексированный объект
                    if ( !indexRangeFound )
                        {
                        createStat.CreateType = new CodeTypeReference( Builder.CoreName.Name );
                        
                        foreach ( ObjectRefInfo.IndexBounds indexBounds in refInfo.IndexBoundArray )
                            {
                            //Используем только нижние границы (равные верхним)
                            createStat.Parameters.Add( indexBounds.lowIndexExpr.Code );
                            }
                        }
                    //Если указан диапазон объектов
                    else
                        {
                        createStat.CreateType = new CodeTypeReference( Builder.CoreName.Range );

                        foreach ( ObjectRefInfo.IndexBounds indexBounds in refInfo.IndexBoundArray )
                            {
                            createStat.Parameters.Add( indexBounds.lowIndexExpr.Code );
                            createStat.Parameters.Add( indexBounds.topIndexExpr.Code );
                            }
                        }
                    refInfo.CoreNameCode = createStat;
                    }
                //Если это неиндексированный объект
                else
                    {
                    //Генерация кода
                    CodeObjectCreateExpression createStat = new CodeObjectCreateExpression();
                    createStat.CreateType = new CodeTypeReference( Builder.CoreName.Name );
                    createStat.Parameters.Add( new CodePrimitiveExpression( refInfo.Name ) );

                    refInfo.CoreNameCode = createStat;
                    }

                if ( !endKeys.Contains( currKey ) )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.ObjectReference, endKeys.GetLastKeys() );
                    SkipTo( endKeys );
                    }
                }

            return refInfo;
            }



        /// <summary>
        /// Разбор индекса или диапазона индексов
        /// </summary>
        /// <param name="endKeys">Допустимые конечные символы</param>
        /// <param name="allowRange">Разрешены ли диапазоны</param>
        /// <param name="rangeFound">True, если указан диапазон</param>
        /// <param name="refInfo">Информация о разбираемом объекте</param>
        /// <param name="currIndexNumber">Номер текущего индекса</param>
        /// <param name="additionalIndexCheck">Дополнительная проверка индекса</param>
        /// <returns>Описание диапазона. Если это одиночный индекс,
        /// то верхняя граница диапазона совпадает с нижней</returns>
        /// <syntax>Expression # : Expression #</syntax>
        public static ObjectRefInfo.IndexBounds IndexBounds( EndKeyList endKeys, bool allowRange, ref bool rangeFound,
            ObjectRefInfo refInfo, int currIndexNumber, AdditionalIndexCheck additionalIndexCheck )
            {
            ExprInfo lowExpr;
            if ( allowRange )
                lowExpr = Expression.Parse( endKeys.UniteWith( Key.Colon ) );
            else
                lowExpr = Expression.Parse( endKeys );
            refInfo.AppendStrCode( lowExpr.StrCode );

            ExprInfo topExpr = lowExpr;

            //Проверка индекса
            bool errorFound = !lowExpr.IsNotIndexed();
            errorFound |= !lowExpr.IsNotSet();
            errorFound |= !lowExpr.IsInteger();
            errorFound |= !lowExpr.NotNegativeIntegerOrReal();

            //Дополнительная проверка
            if ( !errorFound )
                additionalIndexCheck( refInfo.Name, lowExpr, currIndexNumber );

            //Если указан диапазон полюсов
            if ( currKey == Key.Colon && allowRange )
                {
                Accept( Key.Colon );

                rangeFound = true;

                topExpr = Expression.Parse( endKeys );

                //Проверка индекса
                errorFound |= !topExpr.IsNotIndexed();
                errorFound |= !topExpr.IsNotSet();
                errorFound |= !topExpr.IsInteger();
                errorFound |= !topExpr.NotNegativeIntegerOrReal();

                //Дополнительная проверка
                if ( !errorFound )
                    additionalIndexCheck( refInfo.Name, topExpr, currIndexNumber );

                if ( !errorFound && topExpr.HasNoError && lowExpr.HasNoError )
                    //Если индексы заданы константами
                    if ( topExpr.Value.IsConstant && lowExpr.Value.IsConstant )
                        //Проводим дальнейшую проверку индексов
                        if ( ( lowExpr.Value as IntegerValue ).Value > ( topExpr.Value as IntegerValue ).Value )
                            {
                            Fabric.Instance.ErrReg.Register( Err.Parser.Usage.Polus.LowIndexIsGreaterThanTopInRange );
                            errorFound = true;
                            }

                }
 
            return new ObjectRefInfo.IndexBounds( lowExpr, topExpr );
            }


        /// <summary>
        /// Проверить число индексов у объекта
        /// </summary>
        /// <param name="varType">Заявленный тип объекта</param>
        /// <param name="objRef">Описание фактического вызова</param>
        /// <param name="arrayAllowed">Допустимы ли массивы без индексов</param>
        public static void CheckIndexCount( ICommonType varType, ObjectRefInfo objRef, bool arrayAllowed )
            {
            //Если переменная имеет индексированный тип
            if ( varType is IndexedType )
                {
                IndexedType indexedType = varType as IndexedType;
                //Если индексированная переменная используется без индексов
                if ( !objRef.HasIndexes && !arrayAllowed )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.Usage.Array.ArrayIsNotVar );
                    }
                //Если указаны индексы
                else if ( objRef.HasIndexes )
                    {
                    //Проверка числа индексов
                    if ( indexedType.IndexCount > objRef.IndexCount )
                        {
                        Fabric.Instance.ErrReg.Register( Err.Parser.Usage.Array.LostIndex );
                        }
                    else if ( indexedType.IndexCount < objRef.IndexCount )
                        {
                        Fabric.Instance.ErrReg.Register( Err.Parser.Usage.Array.TooManyIndexes );
                        }
                    }
                }
            //Если индекс используется у неиндексированной переменной            
            else if ( !( varType is IndexedType ) && objRef.HasIndexes )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.Usage.Array.VarIsNotArray );
                }
            }
        }
    }
