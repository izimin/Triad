using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TriadPad
    {
    /// <summary>
    /// Настройки программы
    /// </summary>
    [Serializable]
    internal partial class Options
        {
        /// <summary>
        /// Экземпляр класса
        /// </summary>
        private static Options instance = null;


        /// <summary>
        /// Закрытый конструктор
        /// </summary>
        private Options()
            {            
            }


        /// <summary>
        /// Экземпляр класса
        /// </summary>
        public static Options Instance
            {
            get
                {
                if ( instance == null )
                    instance = new Options();
                return instance;
                }
            }


        /// <summary>
        /// Установить значения по умолчанию
        /// </summary>
        public void SetDefaultValues()
            {
            instance = null;
            Options.Instance.SetOptions();
            }


        /// <summary>
        /// Применить все опции к системе
        /// </summary>
        public void SetOptions()
            {
            SetEditOptions();
            SetCompileOptions();
            SetRecentFileOptions();
            SetHotkeys();
            }


        /// <summary>
        /// Заполнить данные из файла
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        public void OpenFromFile( string fileName )
            {
            try
                {
                using ( Stream file = File.Open( fileName, FileMode.Open ) )
                    {
                    BinaryFormatter formatter = new BinaryFormatter();
                    try
                        {
                        instance = formatter.Deserialize( file ) as Options;
                        instance.SetOptions();
                        }
                    catch ( SerializationException e )
                        {
                        throw new ArgumentException( "Возможно указанный файл имеет неверный формат:\n" + e.Message, e );
                        }
                    }
                }
            catch ( IOException e )
                {
                throw new ArgumentException( "Указанный файл прочитать не удалось", e );
                }
            }


        /// <summary>
        /// Сохранить данные в файл
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        public void SaveToFile( string fileName )
            {
            try
                {
                using ( Stream file = File.Open( fileName, FileMode.OpenOrCreate ) )
                    {
                    //Перед сохранением считываем текущие горячие клавиши
                    FillHotkeyList();

                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize( file, Options.Instance );
                    }
                //Проверка
                using ( Stream file = File.Open( fileName, FileMode.Open ) )
                    {
                    BinaryFormatter formatter = new BinaryFormatter();

                    try
                        {
                        //Пытаемся прочитать записанное
                        Options tempBase = formatter.Deserialize( file ) as Options;
                        }
                    catch ( SerializationException e )
                        {
                        throw new ArgumentException( "Сохранение прошло с ошибками:\n" + e.Message, e );
                        }
                    }

                }
            catch ( SerializationException e )
                {
                throw new ArgumentException( e.Message, e );
                }
            catch ( IOException e )
                {
                throw new ArgumentException( "В указанный файл ничего записать не удалось", e );
                }
            }
        }
    }
