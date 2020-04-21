using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

using TriadCompiler.Parser.Common.Expr;
using TriadCompiler.Parser.Common.ObjectRef;

namespace TriadCompiler.Parser.Common.Polus
    {
    /// <summary>
    /// Разбор полюса / диапазона полюсов
    /// </summary>
    internal class PolusVar : CommonParser
        {
        /// <summary>
        /// Имя полюса
        /// </summary>
        /// <syntax>Identificator [ Expression : Expression ]</syntax>
        /// <param name="endKeys">Множество конечных символов</param>
        /// <returns>Информацию о полюсе</returns>
        public static PolusInfo Parse( EndKeyList endKeys )
            {
            PolusInfo polusInfo = new PolusInfo();

            bool typeWasFetched = false;

            ObjectRefInfo objRef = ObjectReference.Parse( endKeys, true,
                delegate( string polusName, ExprInfo indexExpr, int indexNumber )
                {
                //Если имя полюса не было разобрано
                if ( polusName == string.Empty )
                    return;

                if ( !typeWasFetched )
                    {
                    //Получаем тип полюса
                    polusInfo.Type = CommonArea.Instance.GetType<IPolusType>( polusName );
                    typeWasFetched = true;
                    }

                //Если полюс имеет индексированный тип
                if ( polusInfo.Type is IndexedType )
                    {
                    IndexedType polusArrayType = polusInfo.Type as IndexedType;
                    //Если индекс задан константным выражением и индекс является допустимым
                    if ( indexExpr.Value.IsConstant && indexNumber < polusArrayType.IndexCount )
                        {
                        //Проверка попадания в границы
                        if ( !polusArrayType.IsValidIndex( ( indexExpr.Value as IntegerValue ).Value, indexNumber ) )
                            {
                            Fabric.Instance.ErrReg.Register( Err.Parser.Usage.Array.OutOfArrayBound );
                            }
                        }
                    }
                } );

            //Получаем тип полюса
            if ( !typeWasFetched )
                if ( objRef.Name != string.Empty )
                    polusInfo.Type = CommonArea.Instance.GetType<IPolusType>( objRef.Name );
                else
                    polusInfo.Type = null;

            polusInfo.CoreNameCode = objRef.CoreNameCode;

            //Проверить число индексов у переменной
            ObjectReference.CheckIndexCount( polusInfo.Type, objRef, false );

            if ( polusInfo.Type != null )
            //Если это элемент массива, то возвращаем тип одиночного элемента
                if ( polusInfo.Type is IndexedType && objRef.HasIndexes && !objRef.IsRange )
                    {
                    polusInfo.Type = new PolusType( polusInfo.Type.IsInput, polusInfo.Type.IsOutput, polusInfo.Type.IsSpyObject );
                    }

            return polusInfo;
            }


        
        }
    }
