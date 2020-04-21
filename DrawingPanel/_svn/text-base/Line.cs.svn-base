using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrawingPanel
{
    /// <summary>
    /// LineConnector
    /// </summary>
    [Serializable]
    public class Line : BaseObject
    {
        private LineCap _starCap;
        private LineCap _endCap;
        private CConnectionPoint _FromCP;
        private CConnectionPoint _ToCP;
        private bool _Moving;
        private bool _MoveFrom;

        public Line(DrawingPanel panel, CConnectionPoint From, CConnectionPoint To)
            : base(panel)
        {
            this._FromCP = From;
            From.Connectors.Add(this);
            this._ToCP = To;
            To.Connectors.Add(this);
            this.X = From.getX() + From.Width / 2;
            this.Y = From.getY() + From.Width / 2;
            this.X1 = To.getX() + From.Width / 2;
            this.Y1 = To.getY() + From.Width / 2;
            this.bIsLine = true;
            this.bSelected = true;
            this.starCap = LineCap.Custom;
            this.endCap = LineCap.Custom;
            this.endMoveRedim();
            this.bCanRotate = false;
            this._Moving = false;
            this._MoveFrom = false;
        }

        [CategoryAttribute("Line Appearance"), DescriptionAttribute("Line Start Cap")]
        public LineCap starCap
        {
            get
            {
                return _starCap;
            }
            set
            {
                _starCap = value;
            }
        }

        [CategoryAttribute("Line Appearance"), DescriptionAttribute("Line End Cap")]
        public LineCap endCap
        {
            get
            {
                return _endCap;
            }
            set
            {
                _endCap = value;
            }
        }

        [CategoryAttribute("1"), DescriptionAttribute("Line")]
        public string ObjectType
        {
            get
            {
                return "Line";
            }
        }

        public CConnectionPoint FromCP
        {
            get { return _FromCP; }
            set
            {
                if (_FromCP != null)
                    _FromCP.Connectors.Remove(this);
                _FromCP = value;
                _FromCP.Connectors.Add(this);
                RefreshPosition();
            }
        }

        public CConnectionPoint ToCP
        {
            get { return _ToCP; }
            set
            {
                if (_ToCP != null)
                    _ToCP.Connectors.Remove(this);
                _ToCP = value;
                _ToCP.Connectors.Add(this);
                RefreshPosition();
            }
        }

        public bool Moving
        {
            get { return _Moving; }
            set { _Moving = value; }
        }

        public bool MoveFrom
        {
            get { return _MoveFrom; }
            set { _MoveFrom = value; }
        }

        public override BaseObject Copy()
        {
            Line newE = new Line(drawingPanel, _FromCP, _ToCP);
            newE.penColor = this.penColor;
            newE.penWidth = this.penWidth;
            newE.fillColor = this.fillColor;
            newE.filled = this.filled;
            newE.dashstyle = this.dashstyle;
            newE.bIsLine = this.bIsLine;
            newE.alpha = this.alpha;
            //
            newE.starCap = this.starCap;
            newE.endCap = this.endCap;

            return newE;
        }

        public override void Delete()
        {
            _FromCP.Connectors.Remove(this);
            _ToCP.Connectors.Remove(this);
            base.Delete();
        }

        public void RefreshPosition()
        {
            X = _FromCP.getX() + _FromCP.Width / 2;
            Y = _FromCP.getY() + _FromCP.Width / 2;
            X1 = _ToCP.getX() + _FromCP.Width / 2;
            Y1 = _ToCP.getY() + _FromCP.Width / 2;
            endMoveRedim();
        }

        public override void CopyFrom(BaseObject ele)
        {
            this.copyStdProp(ele, this);
            this.FromCP = ((Line)ele).FromCP;
            this.ToCP = ((Line)ele).ToCP;
            this.endCap = ((Line)ele).endCap;
            this.starCap = ((Line)ele).starCap;
        }

        public override void Select()
        {
            this.undoEle = this.Copy();
        }


        public override void AddGp(GraphicsPath gp, int dx, int dy, float zoom)
        {
            gp.AddLine((this.getX() + dx) * zoom, (this.getY() + dy) * zoom, (this.getX1() + dx) * zoom, (this.getY1() + dy) * zoom);
        }

        public override void Draw(Graphics g, int dx, int dy, float zoom)
        {
            System.Drawing.Pen myPen = new System.Drawing.Pen(this.penColor, scaledPenWidth(zoom));
            myPen.DashStyle = this.dashStyle;
            myPen.StartCap = this.starCap;
            myPen.EndCap = this.endCap;


            myPen.Color = this.Trasparency(this.penColor, this.alpha);

            if (this.bSelected)
            {
                myPen.Color = Color.Red;
                myPen.Color = this.Trasparency(myPen.Color, 120);
                myPen.Width = myPen.Width + 1;
                g.DrawEllipse(myPen, (this.X + dx) * zoom, (this.Y + dy) * zoom, 3, 3);
            }

            g.DrawLine(myPen, (this.X + dx) * zoom, (this.Y + dy) * zoom, (this.X1 + dx) * zoom, (this.Y1 + dy) * zoom);

            myPen.Dispose();
        }
    }
}
