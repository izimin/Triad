using System;
using System.Drawing;
using System.Windows.Forms;
using DrawingPanel;

namespace TriadNSim
{
    [Serializable]
    public class Client : NetworkObject
    {
        public Client(DrawingPanel.DrawingPanel panel, int x, int y, int x1, int y1)
            : base(panel, x, y, x1, y1)
        {
            try
            {
                Bitmap bmp = new Bitmap("img\\comp.png");
                this.img = bmp;
            }
            catch
            {
                MessageBox.Show("Client: create bitmap", "Error");
            }
            this.Routine = new Routine();
            this.Routine.Poluses.Add(new Polus("pol"));
            this.Routine.Variables.Add(new TriadCompiler.VarType(TriadCompiler.TypeCode.Boolean, "sent"));
            this.Routine.Parameters.Add(new TriadCompiler.VarType(TriadCompiler.TypeCode.Integer, "DeltaT"));
            this.Routine.ParameterValues.Add(15);
            this.Routine.ParamDescription.Add("");
            this.Routine.Events.Add("Request");
            this.Routine.Name = "RClient";
            showBorder = false;
        }

        public int DeltaT
        {
            get { return m_iDeltaT; }
            set { m_iDeltaT = value; }
        }

        //Частота запросов
        int m_iDeltaT = 15;
    }
}
