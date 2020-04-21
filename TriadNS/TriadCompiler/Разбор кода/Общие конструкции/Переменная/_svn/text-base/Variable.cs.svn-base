using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom; //By Jum

using TriadCompiler.Parser.Common.Expr;
using TriadCompiler.Parser.Common.ObjectRef;

namespace TriadCompiler.Parser.Common.Var
    {
    /// <summary>
    /// Разбор переменной
    /// </summary>
    internal class Variable : CommonParser
        {
        /// <summary>
        /// Обращение к переменной
        /// </summary>
        /// <syntax>Identificator [ Expression{,Expression}]</syntax>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <param name="allowRange">Допустимость диапазона</param>
        /// <param name="allowNotIndexedArray">Допустимость массива без индексов</param>
        /// <returns>Информацию о переменной</returns>
        public static VarInfo Parse( EndKeyList endKeys, bool allowRange, bool allowNotIndexedArray )
            {
            VarInfo varInfo = new VarInfo();

            bool typeWasFetched = false;

            ObjectRefInfo objRef = ObjectReference.Parse( endKeys, allowRange,
                delegate( string varName, ExprInfo indexExpr, int indexNumber )
                    {
                    //Если имя переменной не было разобрано
                    if ( varName == string.Empty )
                        return;

                    if ( !typeWasFetched )
                        {
                        //Получаем тип переменной
                        varInfo.Type = CommonArea.Instance.GetType<IExprType>( varName );
                        typeWasFetched = true;
                        }

                    //Если переменная имеет индексированный тип
                    if ( varInfo.Type is VarArrayType )
                        {
                        VarArrayType varArrayType = varInfo.Type as VarArrayType;
                        //Если индекс задан константным выражением и индекс является допустимым
                        if ( indexExpr.Value.IsConstant && indexNumber < varArrayType.IndexCount )
                            {
                            //Проверка попадания в границы
                            if ( !varArrayType.IsValidIndex( ( indexExpr.Value as IntegerValue ).Value, indexNumber ) )
                                {
                                Fabric.Instance.ErrReg.Register( Err.Parser.Usage.Array.OutOfArrayBound );
                                }
                            }
                        }
                    } );

            //Получаем тип переменной
            if ( !typeWasFetched )
                if ( objRef.Name != string.Empty )
                    varInfo.Type = CommonArea.Instance.GetType<IExprType>( objRef.Name );
                else
                    varInfo.Type = null;

            varInfo.StrCode = objRef.StrCode;
            varInfo.CoreNameCode = objRef.CoreNameCode;
            varInfo.AddIndexBounds( objRef.IndexBoundArray );

            //Проверить число индексов у переменной
            ObjectReference.CheckIndexCount( varInfo.Type, objRef, allowNotIndexedArray );

            //Если это элемент массива, то возвращаем тип одиночного элемента
            if ( varInfo.Type is VarArrayType && objRef.HasIndexes && !objRef.IsRange )
                {
                varInfo.Type = new VarType( varInfo.Type.Code, varInfo.Type.Name, varInfo.Type.IsSpyObject );
                }

            return varInfo;
            }


        //==================By jum===============
        /// <summary>
        /// Обращение к графу или вершине графа
        /// </summary>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <returns>Информацию о переменной</returns>
        public static VarInfo ParseGraphOrNode(EndKeyList endKeys)
        {
            VarInfo varInfo = new VarInfo();
            ObjectRefInfo refInfo = new ObjectRefInfo();
            CodeObjectCreateExpression createStat = new CodeObjectCreateExpression();

            if (currKey != Key.Identificator)
            {
                Fabric.Instance.ErrReg.Register(Err.Parser.WrongStartSymbol.ObjectReference, Key.Identificator);
                SkipTo(endKeys.UniteWith(Key.Identificator));
            }
            if (currKey == Key.Identificator)
            {       
                refInfo.Name = (currSymbol as IdentSymbol).Name;
                refInfo.AppendStrCode(refInfo.Name);
                
                Accept(Key.Identificator);

                if (CommonArea.Instance.IsGraphRegistered(refInfo.Name))
                {
                    IDesignVarType designVarType = CommonArea.Instance.GetType<IDesignVarType>(refInfo.Name);
                    //Если это индексированный объект
                    if (currKey == Key.LeftBracket)
                    {
                        refInfo.AppendStrCode("[");

                        //Был ли указан диапазон индексов
                        bool indexRangeFound = false;

                        // Номер текущего разбираемого индекса
                        int currIndexNumber = 0;
                        do
                        {
                            GetNextKey();
                            refInfo.AddIndexBounds(ObjectReference.IndexBounds(endKeys.UniteWith(Key.Comma, Key.RightBracket), true, ref indexRangeFound, refInfo, currIndexNumber,
                            delegate(string varName, ExprInfo indexExpr, int indexNumber)
                            {
                                DesignVarArrayType varArrayType = designVarType as DesignVarArrayType;
                                //Если индекс задан константным выражением и индекс является допустимым
                                if (indexExpr.Value.IsConstant && indexNumber < varArrayType.IndexCount)
                                {
                                    //Проверка попадания в границы
                                    if (!varArrayType.IsValidIndex((indexExpr.Value as IntegerValue).Value, indexNumber))
                                    {
                                        Fabric.Instance.ErrReg.Register(Err.Parser.Usage.Array.OutOfArrayBound);
                                    }
                                }
                            }));
                            currIndexNumber++;

                            if (currKey == Key.Comma)
                                refInfo.AppendStrCode(",");
                        }
                        while (currKey == Key.Comma);

                        Accept(Key.RightBracket);
                        refInfo.AppendStrCode("]");

                        refInfo.IsRange = indexRangeFound;

                        //Генерация кода
                        createStat.Parameters.Add(new CodePrimitiveExpression(refInfo.Name));

                        //Если это ссылка на одиночный индексированный объект
                        if (!indexRangeFound)
                        {
                            createStat.CreateType = new CodeTypeReference(Builder.CoreName.Name);

                            foreach (ObjectRefInfo.IndexBounds indexBounds in refInfo.IndexBoundArray)
                            {
                                //Используем только нижние границы (равные верхним)
                                createStat.Parameters.Add(indexBounds.lowIndexExpr.Code);
                            }
                        }
                        //Если указан диапазон объектов
                        else
                        {
                            createStat.CreateType = new CodeTypeReference(Builder.CoreName.Range);

                            foreach (ObjectRefInfo.IndexBounds indexBounds in refInfo.IndexBoundArray)
                            {
                                createStat.Parameters.Add(indexBounds.lowIndexExpr.Code);
                                createStat.Parameters.Add(indexBounds.topIndexExpr.Code);
                            }
                        }
                        refInfo.CoreNameCode = createStat;
                    }
                    //Если это неиндексированный объект
                    else
                    {
                        //Генерация кода
                        createStat.CreateType = new CodeTypeReference(Builder.CoreName.Name);
                        createStat.Parameters.Add(new CodePrimitiveExpression(refInfo.Name));
                    }

                    refInfo.CoreNameCode = createStat;
                    ObjectReference.CheckIndexCount(designVarType, refInfo, false);

                    if (currKey == Key.Point)
                    {
                        GetNextKey();
                        if (currKey == Key.Identificator)
                        {
                            refInfo.Name = (currSymbol as IdentSymbol).Name;
                            refInfo.AppendStrCode("[ new " + Builder.CoreName.Name + "(\"" + refInfo.Name + "\") ]");
                            refInfo.Name = refInfo.StrCode;
                            Accept(Key.Identificator);
                            varInfo.Type = new VarType(TypeCode.Node);
                        }
                    }
                    else
                    {
                        varInfo.Type = new DesignVarType(DesignTypeCode.Structure);
                    }
                }
                else
                    varInfo.Type = null;

                varInfo.StrCode = refInfo.StrCode;
                varInfo.CoreNameCode = refInfo.CoreNameCode;
                varInfo.AddIndexBounds(refInfo.IndexBoundArray);

                if ( !endKeys.Contains( currKey ) )
                {
                    Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.ObjectReference, endKeys.GetLastKeys() );
                    SkipTo( endKeys );
                }
            }
            return varInfo;
        }



        }
    }
