using System;
using System.Collections.Generic;
using System.Text;

using TriadCompiler.Parser.Common.ObjectRef;
using TriadCompiler.Parser.Common.Expr;

namespace TriadCompiler.Parser.Model.DesignVar
    {
    /// <summary>
    /// Разбор дизайн-переменной
    /// </summary>
    internal class DesignVariable : CommonParser
        {
        /// <summary>
        /// Обращение к design переменной
        /// </summary>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <param name="expectedTypeCode">Ожидаемый тип design переменной</param>
        /// <syntax>Identificator #[ Expression {, Expression } ]#</syntax>
        /// <returns>Описание переменной</returns>
        public static ObjectRefInfo Parse( EndKeyList endKeys, DesignTypeCode expectedTypeCode )
            {
            IDesignVarType designVarType = null;

            ObjectRefInfo objRef = ObjectReference.Parse( endKeys, true,
                delegate( string varName, ExprInfo indexExpr, int indexNumber )
                    {
                    //Если имя не было разобрано
                    if ( varName == string.Empty )
                        return;

                    if ( designVarType == null )
                        {
                        //Получаем тип переменной
                        designVarType = CommonArea.Instance.GetType<IDesignVarType>( varName );
                        
                        //Если тип имеет неожидаемый код
                        if ( designVarType != null )
                            if ( designVarType.TypeCode != expectedTypeCode )
                                {
                                Fabric.Instance.ErrReg.Register( Err.Parser.Usage.DesignVar.NotExpectedTypeCode );
                                }
                        }

                    //Если переменная имеет индексированный тип
                    if ( designVarType is DesignVarArrayType )
                        {
                        DesignVarArrayType varArrayType = designVarType as DesignVarArrayType;
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

            //Получаем тип полюса
            if ( designVarType == null )
                if ( objRef.Name != string.Empty )
                    designVarType = CommonArea.Instance.GetType<IDesignVarType>( objRef.Name );
                else
                    designVarType = null;

            //Проверить число индексов у переменной
            ObjectReference.CheckIndexCount( designVarType, objRef, false );

            return objRef;
            }
        }
    }
