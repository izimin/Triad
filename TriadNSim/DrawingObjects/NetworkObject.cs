using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DrawingPanel;
using TriadCompiler;

namespace TriadNSim
{
    public enum ENetworkObjectType
    {
        Undefined,
        Client,
        Server,
        UserObject,
        SDNNode
    };

    [Serializable]
    public class Polus
    {
        public string Name { set; get; }
        //public bool IsInput { set; get; }
        //public bool IsOutput { set; get; }
        public List<int> UpperBounds = new List<int>(); // для индексированного типа

        public bool IsRequired { set; get; }
        public string CanConnectedWith { set; get; }

        public Polus(IPolusType polusType)
        {
            this.Name = polusType.Name;
            //this.IsInput = polusType.IsInput;
            //this.IsOutput = polusType.IsOutput;
            this.IsRequired = true;
            this.CanConnectedWith = string.Empty; //any
            if (polusType is IIndexedType)
            {
                IIndexedType type = polusType as IIndexedType;
                int nCount = type.IndexCount;
                for (int i = 0; i < nCount; i++)
                    UpperBounds.Add(type.GetUpperBound(i));
            }
        }

        public string FullName
        {
            get
            {
                string sRes = Name;
                if (UpperBounds.Count > 0)
                {
                    sRes += "[";
                    for (int i = 0; i < UpperBounds.Count; i++)
                    {
                        if (i > 0)
                            sRes += ",";
                        sRes += UpperBounds[i].ToString();
                    }
                    sRes += "]";
                }
                return sRes;
            }
        }
        
        public Polus(string Name)
        {
            int nIndex = Name.IndexOf("[");
            if (nIndex > 0)
            {
                string sBounds = Name.Substring(nIndex + 1, Name.Length - nIndex - 2);
                foreach (string bound in sBounds.Split(','))
                    UpperBounds.Add(Int32.Parse(bound.Trim()));
                Name = Name.Substring(0, nIndex);
            }
            this.Name = Name;
            this.IsRequired = true;
            this.CanConnectedWith = string.Empty; //any
            //this.IsInput = IsInput;
            //this.IsOutput = IsOutput;
        }
    }
    [Serializable]
    public class Routine
    {
        /// <summary>
        /// Имя рутины
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Полюса рутины
        /// </summary>
        public List<Polus> Poluses { set; get; }
        
        /// <summary>
        /// Переменные рутины
        /// </summary>
        public List<IExprType> Variables { set; get; }

        /// <summary>
        /// Переменные рутины
        /// </summary>
        public List<IExprType> Parameters { set; get; }

        /// <summary>
        /// Значения параметров
        /// </summary>
        public List<object> ParameterValues { set; get; }

        public List<string> ParamDescription { set; get; }

        /// <summary>
        /// Имена событий рутины
        /// </summary>
        public List<string> Events { set; get; }

        /// <summary>
        /// Код рутины
        /// </summary>
        public string Text { set; get; }

        public string AssemblyPath { get; set; }

        public string Type { get; set; }

        public Routine()
        {
            Text = string.Empty;
            Name = string.Empty;
            Type = string.Empty;
            Poluses = new List<Polus>();
            Variables = new List<IExprType>();
            Events = new List<string>();
            Parameters = new List<IExprType>();
            ParameterValues = new List<object>();
            ParamDescription = new List<string>();
            AssemblyPath = string.Empty;
        }

        public Polus GetPolus(string sName)
        {
            foreach(Polus polus in Poluses)
                if (polus.Name.Equals(sName, StringComparison.InvariantCultureIgnoreCase))
                    return polus;
            return null;
        }
    }

    [Serializable]
    public class ConnectedIP
    {
        public string Description { get; set; }

        public ConnectedIP(InfProcedure proc)
        {
            IP = proc;
            Params = new List<string>();
            Description = string.Empty;
        }

        public InfProcedure IP { private set; get; }

        public List<string> Params { set; get; }
    }

    /// <summary>
    /// Параметр IP
    /// </summary>
    [Serializable]
    public class IPParam
    {
        public IPParam(ISpyType type)
        {
            Name = type.Name;
            IsEvent = type is EventType;
            IsPolus = type is IPolusType;
            if (type is IExprType)
                Code = (type as IExprType).Code;
        }

        /// <summary>
        /// Имя параметра
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// Событие?
        /// </summary>
        public bool IsEvent { private set; get; }
        /// <summary>
        /// Полюс?
        /// </summary>
        public bool IsPolus { private set; get; }
        /// <summary>
        /// Тип параметра
        /// </summary>
        public TriadCompiler.TypeCode Code { set; get; }

        public string TypeName
        {
            get
            {
                if (IsEvent)
                    return "Event";
                if (IsPolus)
                    return "Polus";
                return Code.ToString();
            }
        }
    }

    /// <summary>
    /// УМ
    /// </summary>
    [Serializable]
    public class SimCondition
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public string Code { set; get; }
    }

    /// <summary>
    /// ИП
    /// </summary>
    [Serializable]
    public class InfProcedure
    {
        public InfProcedure(IProcedureType ipType, bool IsStandart)
        {
            Name = ipType.Name;
            ReturnCode = ipType.ReturnCode;
            Description = ipType.Description;
            this.IsStandart = IsStandart;
            Params = new List<IPParam>();
            foreach (var var in ipType.ToList())
                Params.Add(new IPParam(var));
        }

        /// <summary>
        /// Описание ИП
        /// </summary>
        public string Description { set; get; }

        /// <summary>
        /// Стандартная?
        /// </summary>
        public bool IsStandart { private set; get; }

        /// <summary>
        /// Имя ИП
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Код типа результата
        /// </summary>
        public TriadCompiler.TypeCode ReturnCode { set; get; }

        /// <summary>
        /// Cписок параметров
        /// </summary>
        public List<IPParam> Params { set; get; }

        /// <summary>
        /// Код ИП
        /// </summary>
        public string Code { set; get; }
    }

    

    [Serializable]
    public class NetworkObject : ImgBox
    {
        private Routine _routine;
        private List<ConnectedIP> _connectedIPs;
        public string SemanticType;
        public ENetworkObjectType Type { get; set; }
        public List<ConnectedIP> ConnectedIPs
        {
            set
            {
                _connectedIPs = value;
            }
            get
            {
                if (_connectedIPs == null)
                    _connectedIPs = new List<ConnectedIP>();
                return _connectedIPs;
            }
        }

        public Routine Routine
        {
            get { return _routine; }
            set { _routine = value; }
        }

        public NetworkObject(DrawingPanel.DrawingPanel panel, int x, int y, int x1, int y1)
            : base(panel, x, y, x1, y1)
        {
            Type = ENetworkObjectType.Undefined;
        }

        public NetworkObject(DrawingPanel.DrawingPanel panel)
            : base(panel)
        {
            Type = ENetworkObjectType.Undefined;
        }
    }
}