using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;

namespace TriadCompiler.Parser.Common.Expr
    {
    /// <summary>
    /// Информация о выражении
    /// </summary>
    internal class ExprInfo
        {
        /// <summary>
        /// Значение выражения
        /// </summary>
        public ConstValue Value = new ConstValue();
        /// <summary>
        /// Тип выражения
        /// </summary>
        public IExprType Type = null;
        /// <summary>
        /// Строковое представление
        /// </summary>
        private StringBuilder strCode = new StringBuilder();


        /// <summary>
        /// Признак того, что выражение было разобрано правильно
        /// </summary>
        public bool HasNoError
            {
            get
                {
                //Если это множество
                if ( Type is SetType )
                    return true;

                return this.Type != null;
                }
            }


        /// <summary>
        /// Строковое представление
        /// </summary>
        public string StrCode
            {
            get
                {
                return strCode.ToString();
                }
            }


        /// <summary>
        /// Добавить часть строкового представления
        /// </summary>
        /// <param name="newCode">Новая часть</param>
        public void Append( string newCode )
            {
            strCode.Append( newCode );
            }


        /// <summary>
        /// Вставить новую часть кода в начало
        /// </summary>
        /// <param name="newCode">Новая часть кода</param>
        public void InsertFirst( string newCode )
            {
            strCode.Insert( 0, newCode );
            }


        /// <summary>
        /// Заменить часть строкового кода другим фрагментом
        /// </summary>
        /// <param name="oldSubStr">Старый фрагмент</param>
        /// <param name="newSubStr">Новый фрагмент</param>
        public void Replace( string oldSubStr, string newSubStr )
            {
            strCode.Replace( oldSubStr, newSubStr );
            }


        /// <summary>
        /// Представление в виде кода
        /// </summary>
        public CodeExpression Code
            {
            get
                {
                return new CodeSnippetExpression( strCode.ToString() );
                }
            }


        /// <summary>
        /// Проверить, что выражение имеет неиндексированный тип
        /// </summary>
        /// <returns>True, если неиндексированный тип</returns>
        public bool IsNotIndexed()
            {
            if ( this.HasNoError )
                {
                if ( this.Type is IndexedType )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.Usage.NeedNotIndexed );
                    return false;
                    }
                }
            return true;
            }


        /// <summary>
        /// Проверить, что выражение имеет тип не множество
        /// </summary>
        /// <returns>True, если тип не множество</returns>
        public bool IsNotSet()
            {
            if ( this.HasNoError )
                {
                if ( this.Type is SetType )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.Usage.NeedNotSet );
                    return false;
                    }
                }
            return true;
            }


        /// <summary>
        /// Проверить, что выражение имеет тип массив или множество
        /// </summary>
        /// <returns>True, если тип выражения массив или мн-во</returns>
        public bool IsIndexedOrSet()
            {
            if ( this.HasNoError )
                {
                if ( !( Type is SetType ) && !( Type is IndexedType ) )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.Usage.NeedIndexedOrSet );
                    return false;
                    }
                }
            return true;
            }

        
        /// <summary>
        /// Проверить, что выражение имеет целый тип
        /// </summary>
        /// <returns>True, если целый</returns>
        public bool IsInteger()
            {
            if ( this.HasNoError )
                {
                //Тип должен быть целым
                if ( this.Type.Code != TypeCode.Integer )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.Need.Integer );
                    return false;
                    }
                }
            return true;
            }


        /// <summary>
        /// Проверить, что выражение имеет целый или вещественный тип
        /// </summary>
        /// <returns>True, если целый или вещественный</returns>
        public bool IsIntegerOrReal()
            {
            if ( this.HasNoError )
                {
                //Тип должен быть целым или вещественным
                if ( this.Type.Code != TypeCode.Integer && this.Type.Code != TypeCode.Real )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.Need.IntegerOrReal );
                    return false;
                    }
                }
            return true;
            }


        /// <summary>
        /// Проверить, что выражение имеет строковый тип
        /// </summary>
        /// <returns>True, если строковый</returns>
        public bool IsString()
            {
            if ( this.HasNoError )
                {
                //Тип должен быть строковым
                if ( this.Type.Code != TypeCode.String )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.Need.String );
                    return false;
                    }
                }
            return true;
            }


        /// <summary>
        /// Проверить, что выражение имеет логический тип
        /// </summary>
        /// <returns>True, если логический</returns>
        public bool IsBoolean()
            {
            if ( this.HasNoError )
                {
                //Тип должен быть логическим
                if ( this.Type.Code != TypeCode.Boolean )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.Type.Var.Need.Boolean );
                    return false;
                    }
                }
            return true;
            }


        /// <summary>
        /// Проверить, что выражение - это константа
        /// </summary>
        /// <returns>True, если константа</returns>
        public bool IsConstant()
            {
            if ( this.HasNoError )
                {
                //Тип выражения должен быть константой
                if ( !this.Value.IsConstant )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.Value.Need.Constant );
                    return false;
                    }
                }
            return true;
            }


        /// <summary>
        /// Проверить, что выражение - это не константа
        /// </summary>
        /// <returns>True, если не константа</returns>
        public bool IsNotConstant()
            {
            if ( this.HasNoError )
                {
                //Тип выражения должен быть константой
                if ( this.Value.IsConstant )
                    {
                    Fabric.Instance.ErrReg.Register( Err.Parser.Value.Need.NotConstant );
                    return false;
                    }
                }
            return true;
            }



        /// <summary>
        /// Проверить, что если выражение - константа, то она неотрицательное число
        /// </summary>
        /// <returns>True, если все верно</returns>
        public bool NotNegativeIntegerOrReal()
            {
            if ( this.HasNoError )
                {
                //Если выражение - это константа
                if ( this.Value.IsConstant )
                    //Если это не констнтное мн-во
                    if ( !( Value is SetValue ) )
                        //Если это вещественный тип
                        if ( this.Type.Code == TypeCode.Real )
                            {
                            //Число должно быть неотрицательным
                            if ( ( this.Value as RealValue ).Value < 0 )
                                {
                                Fabric.Instance.ErrReg.Register( Err.Parser.Value.Need.NotNegative );
                                return false;
                                }
                            }
                        //Если это целый тип
                        else if ( this.Type.Code == TypeCode.Integer )
                            {
                            //Число должно быть неотрицательным
                            if ( ( this.Value as IntegerValue ).Value < 0 )
                                {
                                Fabric.Instance.ErrReg.Register( Err.Parser.Value.Need.NotNegative );
                                return false;
                                }
                            }
                        else
                            {
                            //Ничего не делаем
                            }
                }
            return true;
            }



        /// <summary>
        /// Проверить, что если выражение - константа, то она положительное число
        /// </summary>
        /// <returns>True, если все верно</returns>
        public bool PositiveIntegerOrReal()
            {
            if ( this.HasNoError )
                {
                //Если выражение - это константа
                if ( this.Value.IsConstant )
                    //Если это не констнтное мн-во
                    if ( !( Value is SetValue ) )
                        //Если это вещественный тип
                        if ( this.Type.Code == TypeCode.Real )
                            {
                            //Число должно быть положительным
                            if ( ( this.Value as RealValue ).Value <= 0 )
                                {
                                Fabric.Instance.ErrReg.Register( Err.Parser.Value.Need.NotNegative );
                                return false;
                                }
                            }
                        //Если это целый тип
                        else if ( this.Type.Code == TypeCode.Integer )
                            {
                            //Число должно быть положительным
                            if ( ( this.Value as IntegerValue ).Value <= 0 )
                                {
                                Fabric.Instance.ErrReg.Register( Err.Parser.Value.Need.Positive );
                                return false;
                                }
                            }
                        //Иначе - недопустимый тип
                        else
                            {
                            //Ничего не делаем
                            }
                }
            return true;
            }


        }
    }
