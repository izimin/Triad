using System;
using System.Drawing;
using System.Windows.Forms;
using DrawingPanel;

namespace TriadNSim
{
    [Serializable]
    public class Server : NetworkObject
    {
        public Server(DrawingPanel.DrawingPanel panel, int x, int y, int x1, int y1)
            : base(panel, x, y, x1, y1)
        {
            try
            {
                Bitmap bmp = new Bitmap("img\\server.png");
                this.img = bmp;
            }
            catch
            {
                MessageBox.Show("Server: create bitmap", "Error:");
            }
            this.Routine = new Routine();
            this.Routine.Poluses.Add(new Polus("pol"));
            this.Routine.Variables.Add(new TriadCompiler.VarType(TriadCompiler.TypeCode.Boolean, "busy"));
            this.Routine.Variables.Add(new TriadCompiler.VarType(TriadCompiler.TypeCode.Real, "length"));
            this.Routine.Parameters.Add(new TriadCompiler.VarType(TriadCompiler.TypeCode.Integer, "MaxQueueLength"));
            this.Routine.Parameters.Add(new TriadCompiler.VarType(TriadCompiler.TypeCode.Integer, "DeltaT"));
            this.Routine.ParameterValues.Add(10);
            this.Routine.ParameterValues.Add(5);
            this.Routine.ParamDescription.Add("");
            this.Routine.ParamDescription.Add("");
            this.Routine.Events.Add("EndService");
            this.Routine.Name = "RServer";
            showBorder = false;
        }

        public int MaxQueueLength
        {
            get { return m_iMaxQueueLength; }
            set { m_iMaxQueueLength = value; }
        }

        public int DeltaT
        {
            get { return m_iDeltaT; }
            set { m_iDeltaT = value; }
        }

        //максимальная очередь
        private int m_iMaxQueueLength = 10;
        //Время обслуживания на сервере
        private int m_iDeltaT = 5;
    }
}
