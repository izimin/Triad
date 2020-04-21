using System;
using System.Collections.Generic;
using System.Text;

using TriadCompiler.Parser.Common.Expr;

namespace TriadCompiler.Parser.Common.Declaration.Var
    {
    /// <summary>
    /// Разоб объявления типа переменной
    /// </summary>
    internal class TypeDeclaration : CommonParser
        {
        /// <summary>
        /// Множество стартовых символов типа
        /// </summary>
        private static List<Key> typeSet = null;
        /// <summary>
        /// Множество стартовых символов простого типа
        /// </summary>
        private static List<Key> simpleTypeSet = null;


        /// <summary>
        /// Стартовые символы простого типа
        /// </summary>
        public static List<Key> SimpleTypeStartKeys
            {
            get
                {
                if ( simpleTypeSet == null )
                    {

                    Key[] keySet = { Key.Bit, Key.String, Key.Boolean, Key.Real, Key.Char, Key.Integer, Key.Notype };

                    simpleTypeSet = new List<Key>( keySet );
                    }
                return simpleTypeSet;
                }
            }


        /// <summary>
        /// Стартовые символы типа
        /// </summary>
        public static List<Key> TypeStartKeys
            {
            get
                {
                if ( typeSet == null )
                    {
                    typeSet = new List<Key>();

                    typeSet.Add( Key.Array );
                    typeSet.Add( Key.Set );
                    //by jum
                    typeSet.Add( Key.Node );
                    typeSet.Add( Key.Graph );
                    typeSet.AddRange( SimpleTypeStartKeys );
                    }
                return typeSet;
                }
            }


        /// <summary>
        /// Тип
        /// </summary>
        /// <syntax>SimpleType | Array [ ArrayIndexRange { ,ArrayIndexRange } ] Of SimpleType |
        /// SET OF SimpleType </syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <returns>Сформированный тип</returns>
        public static IExprType Parse( EndKeyList endKeys )
            {
            IExprType resultType = null;

            if ( !TypeDeclaration.TypeStartKeys.Contains( currKey ) )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongStartSymbol.Type, TypeDeclaration.TypeStartKeys );
                SkipTo( endKeys.UniteWith( TypeDeclaration.TypeStartKeys ) );
                }
            if ( TypeDeclaration.TypeStartKeys.Contains( currKey ) )
                {
                //Массив
                if ( currKey == Key.Array )
                    {
                    Accept( Key.Array );                    

                    VarArrayType arrayType = new VarArrayType( TypeCode.UndefinedType );

                    RangeDeclaration( endKeys, arrayType );
                    
                    Accept( Key.Of );

                    VarType simpleType = SimpleType( endKeys );
                    if ( simpleType != null )
                        arrayType.Code = simpleType.Code;

                    resultType = arrayType;
                    }
                //Если это множество
                else if ( currKey == Key.Set )
                    {
                    Accept( Key.Set );
                    Accept( Key.Of );

                    SetType setType = new SetType( TypeCode.UndefinedType );

                    //by jum
                    if (currKey == Key.Node)
                    {
                        setType.Code = TypeCode.Node;
                        GetNextKey();
                    }
                    else
                        setType.Code = SimpleType( endKeys ).Code;
                    
                    resultType = setType;
                    }
                //by jum
                else if (currKey == Key.Node)
                    {
                        Accept( Key.Node );
                        resultType = new VarType(TypeCode.Node);
                    }
                //Простой тип
                else
                {
                    resultType = SimpleType(endKeys);
                }
                }

            return resultType;
            }


        /// <summary>
        /// Объявление диапазона у массива
        /// </summary>
        /// <param name="endKeys">Допустимые конечные символы</param>
        /// <param name="arrayType">Формируемый тип массива</param>
        public static void RangeDeclaration( EndKeyList endKeys, IndexedType arrayType )
            {
            Accept( Key.LeftBracket );

            ArrayIndex( endKeys.UniteWith( Key.Comma, Key.RightBracket ), arrayType );
            while ( currKey == Key.Comma )
                {
                GetNextKey();
                ArrayIndex( endKeys.UniteWith( Key.Comma, Key.RightBracket ), arrayType );
                }

            Accept( Key.RightBracket );
            }


        /// <summary>
        /// Диапазон значений индекса в массиве
        /// </summary>
        /// <syntax>Expression</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <param name="arrayType">Результирующий тип</param>
        /// <syntax> Expression </syntax>
        /// <returns>Наличие ошибки</returns>
        private static void ArrayIndex( EndKeyList endKeys, IndexedType arrayType )
            {
            ExprInfo exprInfo = Expression.Parse( endKeys );

            //Ошибки нет
            if ( !CheckIndexInArrayDeclaration( exprInfo ) )
                {
                arrayType.SetNewIndex( ( exprInfo.Value as IntegerValue ).Value );
                }

            }


        /// <summary>
        /// Проверить индекс в объявлении массива
        /// </summary>
        /// <param name="exprInfo">Информация об индексе</param>
        /// <returns>True, если найдена ошибка</returns>
        private static bool CheckIndexInArrayDeclaration( ExprInfo exprInfo )
            {
            bool errorFound = !exprInfo.HasNoError;
            errorFound |= !exprInfo.IsNotIndexed();
            errorFound |= !exprInfo.IsNotSet();
            //Тип индекса должен быть целым
            errorFound |= !exprInfo.IsInteger();
            //Тип индекса должен быть константой
            errorFound |= !exprInfo.IsConstant();
            //Константа, задающая верхний предел индекса должна быть положительной
            errorFound |= !exprInfo.PositiveIntegerOrReal();

            return errorFound;
            }


        /// <summary>
        /// Простой тип
        /// </summary>
        /// <syntax>Bit | String | Char | Integer | Real | Boolean | Notype</syntax>
        /// <param name="endKeys">Множество допустимых конечных символов</param>
        /// <returns>Сформированный тип</returns>
        public static VarType SimpleType( EndKeyList endKeys )
            {
            VarType resultType = null;

            if ( !TypeDeclaration.SimpleTypeStartKeys.Contains( currKey ) )
                {
                Fabric.Instance.ErrReg.Register( Err.Parser.WrongStartSymbol.Type, SimpleTypeStartKeys );
                SkipTo( endKeys.UniteWith( SimpleTypeStartKeys ) );
                }
            if ( SimpleTypeStartKeys.Contains( currKey ) )
                {
                switch ( currKey )
                    {
                    case Key.String:
                        resultType = new VarType( TypeCode.String );
                        GetNextKey();
                        break;
                    case Key.Integer:
                        resultType = new VarType( TypeCode.Integer );
                        GetNextKey();
                        break;
                    case Key.Char:
                        resultType = new VarType( TypeCode.Char );
                        GetNextKey();
                        break;
                    case Key.Real:
                        resultType = new VarType( TypeCode.Real );
                        GetNextKey();
                        break;
                    case Key.Boolean:
                        resultType = new VarType( TypeCode.Boolean );
                        GetNextKey();
                        break;
                    case Key.Bit:
                        resultType = new VarType( TypeCode.Bit );
                        GetNextKey();
                        break;
                    case Key.Notype:
                        resultType = new VarType( TypeCode.UndefinedType );
                        GetNextKey();
                        break;
                    //Ошибка
                    default:
                        //Неизвестный тип
                        Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.Unknown );
                        break;
                    }
                if ( !endKeys.Contains( currKey ) )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.WrongEndSymbol.Type, endKeys.GetLastKeys() );
                    SkipTo( endKeys );
                    }
                }
            return resultType;
            }
        }
    }
