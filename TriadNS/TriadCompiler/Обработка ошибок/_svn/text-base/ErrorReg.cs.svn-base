using System;
using System.IO;
using System.Collections.Generic;

namespace TriadCompiler
    {
    /// <summary>
    /// Класс отвечает за регистрацию ошибок и их печать.
    /// </summary>
    public class ErrorReg
        {
        /// <summary>
        /// Имя файла с кодами ошибок
        /// </summary>
        private const string ErrorFileName = "ErrMessages.txt";
        /// <summary>
        /// Максимально возможный код ошибки
        /// </summary>
        private const int MaxErrorCodeNumber = 1000;
        /// <summary>
        /// Ошибка отсутствия сообщения об ошибке
        /// </summary>
        private const string NoTextForErrorCodeMessage = "Не могу найти сообщения об ошибке с таким кодом.";
        /// <summary>
        /// Неверный формат записи в файле 
        /// </summary>
        private const string WrongErrorTextFormatMessage = "Неверный формат записи в файле с сообщениями об ошибках.";


        /// <summary>
        /// Общее число зарегистрированных ошибок
        /// </summary>
        public int ErrorCount
            {
            get
                {                
                return errorCount;
                }
            }


        /// <summary>
        /// Конструктор
        /// </summary>
        public ErrorReg()
            {
            //Заполнить список с сообщениями об ошибках
            FillErrMessagesList();
            }


        /// <summary>
        /// Обновить
        /// </summary>
        public virtual void Reload()
            {
            errorCount = 0;
            }


        /// <summary>
        /// Зарегистрировать ошибку
        /// </summary>
        /// <param name="errCode">Код сообщения об ошибке</param>
        public virtual void Register( uint errCode )
            {
            errorCount++;

            //Если сообщение с таким кодом есть
            if ( errList[ errCode ] != null )
                {
                Fabric.IO.ShowError( errCode.ToString() + ": " + errList[ errCode ] );
                }
            else
                {
                Fabric.IO.ShowError( errCode.ToString() + ": " + NoTextForErrorCodeMessage );
                }
            }


        /// <summary>
        /// Зарегистрировать ошибку и добавить к сообщению произвольный текст
        /// </summary>
        /// <param name="errCode">Код сообщения об ошибке</param>
        /// <param name="additionalText">Дополнительный текст ошибки</param>
        public virtual void Register( uint errCode, string additionalText )
            {
            if ( additionalText == null )
                throw new ArgumentNullException( "additionalText" );

            errorCount++;

            //Если сообщение с таким кодом есть
            if ( errList[ errCode ] != null )
                {
                Fabric.IO.ShowError( errCode.ToString() + ": " + errList[ errCode ] + " ("
                    + additionalText + ")" );
                }
            else
                {
                Fabric.IO.ShowError( errCode.ToString() + ": " + NoTextForErrorCodeMessage );
                }
            }


        /// <summary>
        /// Зарегистрировать ошибку и указать множество допустимых символов
        /// </summary>
        /// <param name="errCode">Код ошибки</param>
        /// <param name="allowedEndKeys">Множество допустимых символов</param>
        public virtual void Register( uint errCode, List<Key> allowedEndKeys )
            {
            errorCount++;

            //Если сообщение с таким кодом есть
            if ( errList[ errCode ] != null )
                {
                string errorMessage = errCode.ToString() + ": " + errList[ errCode ];
                if ( this.printAllowedKeys )
                    {
                    errorMessage += ". Допустимые символы: ";
                    foreach ( Key key in allowedEndKeys )
                        errorMessage += key.ToString() + " ";
                    }
                Fabric.IO.ShowError( errorMessage );
                }
            else
                {
                Fabric.IO.ShowError( errCode.ToString() + ": " + NoTextForErrorCodeMessage );
                }
            }


        /// <summary>
        /// Зарегистрировать ошибку и указать множество допустимых символов
        /// </summary>
        /// <param name="errCode">Код ошибки</param>
        /// <param name="keys">Множество допустимых символов</param>
        public void Register( uint errCode, params Key[] keys )
            {
            List<Key> allowedKeys = new List<Key>();
            foreach ( Key key in keys )
                allowedKeys.Add( key );
            
            Register( errCode, allowedKeys );
            }

        
        /// <summary>
        /// Заполнить список с сообщениями об ошибках
        /// </summary>
        private void FillErrMessagesList()
            {
            try
                {
                string[] messageList = Properties.Resources.ErrMessages.Split( '\n' );

                //Код ошибки
                int errorCode = 0;
                //Код ошибки + Сообщение об ошибке
                string[] spliterString = new string[ 2 ];
                //Разделитель
                char[] delimiter = { ' ' };

                foreach ( string message in messageList )
                    {
                    spliterString = message.Split( delimiter, 2 );

                    errorCode = int.Parse( spliterString[ 0 ] );
                    //Убираем символ перевода каретки в конце
                    errList[ errorCode ] = spliterString[ 1 ].Replace( '\r', ' ' );
                    }
                }
            catch ( FormatException e )
                {
                throw new FormatException( WrongErrorTextFormatMessage, e );
                }
            }


        /// <summary>
        /// Определение печатать или нет множества допустимых символов при выводе ошибок
        /// </summary>
        public bool PrintAllowedKeys
            {
            get
                {
                return printAllowedKeys;
                }
            set
                {
                printAllowedKeys = value;
                }
            }


        //Список сообщений об ошибках (Код ошибки - это ее номер в списке)
        private string[] errList = new string[ MaxErrorCodeNumber ];
        /// <summary>
        /// Общее число зарегистрированных ошибок
        /// </summary>
        protected int errorCount = 0;
        /// <summary>
        /// Определение печатать или нет множества допустимых символов при выводе ошибок
        /// </summary>
        private bool printAllowedKeys = CompilerFacade.ShowExtendedErrorInfo;
        }

    }
