using System;
using System.Collections.Generic;
using System.Text;

using System.Xml.Serialization;
using System.IO;

namespace TriadCore
{
    /// <summary>
    /// 
    /// </summary>
    public class LoggerRecord
    {
        /// <summary>
        /// 
        /// </summary>
        public double SystemTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ObjectName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="systemTime"></param>
        /// <param name="objectName"></param>
        /// <param name="message"></param>
        public LoggerRecord(double systemTime, string objectName, string message)
        {
            SystemTime = systemTime;
            ObjectName = objectName;
            Message = message;
        }

        /// <summary>
        /// 
        /// </summary>
        public LoggerRecord()
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Logger
    {
        // единственный экземпляр синглтона
        private static Logger instance = null;

        //private static string fileName = "d:\\modeling.xml";

        private List<LoggerRecord> records;

        private Logger()
        {
            this.records = new List<LoggerRecord>();
        }

        /// <summary>
        /// 
        /// </summary>
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                    instance = new Logger();
                return instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<LoggerRecord> Records
        {
            get
            {
                return this.records;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="record"></param>
        public void AddRecord(LoggerRecord record)
        {
            this.records.Add(record);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            this.records.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        public string XML
        {
            get
            {
                XmlSerializer sr = new XmlSerializer(records.GetType());
                StringBuilder sb = new StringBuilder();
                StringWriter w = new StringWriter(sb, System.Globalization.CultureInfo.InvariantCulture);
                sr.Serialize(w, records);
                return sb.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SaveToXml()
        {
            /*string xml = Xml;
            StreamWriter fileWriter = new StreamWriter(fileName);
            fileWriter.Write(xml);
            fileWriter.Close();*/
        }

        /// <summary>
        /// 
        /// </summary>
        public void LoadFromXml()
        {
            /*StreamReader file = new StreamReader(fileName, true);
            String xml = file.ReadToEnd();
            file.Close();

            // создаем reader
            StringReader reader = new StringReader(xml);

            // создаем XmlSerializer
            XmlSerializer dsr = new XmlSerializer(typeof(List<LoggerRecord>));

            // десериализуем 
            records = (List<LoggerRecord>)dsr.Deserialize(reader);*/
        }
    }
}
