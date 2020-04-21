using System;
using DrawingPanel;

namespace TriadNSim
{
    [Serializable]
    public class Link : Line
    {
        public Link(DrawingPanel.DrawingPanel panel, CConnectionPoint From, CConnectionPoint To)
            : base(panel, From, To)
        {
            penColor = panel.CreationPenColor;
            penWidth = panel.CreationPenWidth;
        }

        public string PolusFrom { set; get; }
        public string PolusTo { set; get; }
    }
}
