using System;
using System.Drawing;
using System.Windows.Forms;
using TriadCompiler;
using DrawingPanel;

namespace TriadNSim
{
    [Serializable]
    public class UserObject : NetworkObject
    {
        public UserObject(DrawingPanel.DrawingPanel panel)
            : base(panel)
        {
            showBorder = true;
            this.Routine = new Routine();
            this.Routine.Name = "R" + this.Name;
            this.Routine.Text = "routine " + this.Routine.Name + "(InOut pol)\nendrout";
            this.Routine.Poluses.Add(new Polus("pol"));
        }
    }
}
