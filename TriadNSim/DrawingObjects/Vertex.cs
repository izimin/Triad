using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriadNSim.DrawingObjects
{
    [Serializable]
    public class Vertex : NetworkObject
    {
        public Vertex(DrawingPanel.DrawingPanel panel):base(panel)
        {
            showBorder = false;
            this.Routine = new Routine();
            this.Routine.Poluses.Add(new Polus("pol"));
            this.Routine.Variables.Add(new TriadCompiler.VarType(TriadCompiler.TypeCode.Boolean, "GetMes"));
            this.Routine.Parameters.Add(new TriadCompiler.VarType(TriadCompiler.TypeCode.Integer, "MaxL"));
            this.Routine.ParameterValues.Add(15);
            this.Routine.ParamDescription.Add("");
            this.Routine.Events.Add("Request");
            this.Routine.Name = "RVertex";
        }
        public int MaxL
        {
            get { return m_iMaxL; }
            set { m_iMaxL = value; }
        }


        //максимальная очередь
        private int m_iMaxL = 10;
    }
}
