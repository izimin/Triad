using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace DrawingPanel
{
    [Serializable]
    public abstract class BaseObject : Object
    {
        protected bool bCanRotate;

        //Start point
        protected int X;
        protected int Y;
        //End point
        protected int X1;
        protected int Y1;

        protected int startX;
        protected int startY;
        protected int startX1;
        protected int startY1;

        protected string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        protected LineCap start;
        protected LineCap end;
        protected DashStyle dashstyle;

        protected int _rotation;

        private CConnectionPoint _connectionPoint;

        public CConnectionPoint ConnectionPoint
        {
            get { return _connectionPoint; }
            protected set { _connectionPoint = value; }
        }

        private Color _penColor;
        private float _penWidth;
        private Color _fillColor;
        private bool _filled;
        private bool _showBorder;
        private DashStyle _dashStyle;
        private int _alpha;

        public bool bIsLine;

        public bool bSelected;

        public bool Deleted;

        public BaseObject undoEle;

        [NonSerialized]
        public DrawingPanel drawingPanel;

        public BaseObject(DrawingPanel panel)
        {
            drawingPanel = panel;
            penColor = Color.Black;
            penWidth = 1f;
            fillColor = Color.Black;
            filled = false;
            showBorder = true;
            this.dashstyle = DashStyle.Solid;
            this.alpha = 255;
        }

        #region GET/SET

        public bool canRotate()
        {
            return bCanRotate;
        }
        public int getRotation()
        {
            if (canRotate())
                return _rotation;
            else
                return 0;
        }

        public void addRotation(int a)
        {
            this._rotation += a;
        }

        [CategoryAttribute("Position"), DescriptionAttribute("X ")]
        public int PosX
        {
            get
            {
                return this.X;
            }
        }

        [CategoryAttribute("Position"), DescriptionAttribute("Y ")]
        public int PosY
        {
            get
            {
                return this.Y;
            }
        }
        [CategoryAttribute("Dimention"), DescriptionAttribute("Width ")]
        public int Width
        {
            get
            {
                return System.Math.Abs(this.X1 - this.X);
            }
        }
        [CategoryAttribute("Dimention"), DescriptionAttribute("Height ")]
        public int Height
        {
            get
            {
                return System.Math.Abs(this.Y1 - this.Y);
            }
        }

        [CategoryAttribute("Appearance"), DescriptionAttribute("Set Border Dash Style ")]
        public virtual DashStyle dashStyle
        {
            get
            {
                return _dashStyle;
            }
            set
            {
                _dashStyle = value;
            }
        }
        [CategoryAttribute("Appearance"), DescriptionAttribute("Show border when filled or contains Text")]
        public virtual bool showBorder
        {
            get
            {
                return _showBorder;
            }
            set
            {
                _showBorder = value;
            }
        }
        [CategoryAttribute("Appearance"), DescriptionAttribute("Pen Color")]
        public virtual Color penColor
        {
            get
            {
                return _penColor;
            }
            set
            {
                _penColor = value;
            }
        }
        [CategoryAttribute("Appearance"), DescriptionAttribute("Fill Color")]
        public virtual Color fillColor
        {
            get
            {
                return _fillColor;
            }
            set
            {
                _fillColor = value;
            }
        }
        [CategoryAttribute("Appearance"), DescriptionAttribute("Pen Width")]
        public virtual float penWidth
        {
            get
            {
                return _penWidth;
            }
            set
            {
                _penWidth = value;
            }
        }
        [CategoryAttribute("Appearance"), DescriptionAttribute("Filled/Unfilled")]
        public virtual bool filled
        {
            get
            {
                return _filled;
            }
            set
            {
                _filled = value;
            }
        }
        [CategoryAttribute("Appearance"), DescriptionAttribute("Trasparency")]
        public virtual int alpha
        {
            get
            {
                return _alpha;
            }
            set
            {
                if (value < 0)
                    _alpha = 0;
                else
                    if (value > 255)
                        _alpha = 255;
                    else
                        _alpha = value;
            }
        }

        public int getX()
        {
            return X;
        }
        public int getY()
        {
            return Y;
        }
        public int getX1()
        {
            return X1;
        }
        public int getY1()
        {
            return Y1;
        }

        #endregion

        public virtual void Draw(Graphics g, int dx, int dy, float zoom)
        {
            if (_connectionPoint != null)
                _connectionPoint.Draw(g, dx, dy, zoom);
        }

        public void AddGraphPath(GraphicsPath gp, int dx, int dy, float zoom)
        {
            GraphicsPath tmpGp = new GraphicsPath();
            AddGp(tmpGp, dx, dy, zoom);
            Matrix translateMatrix = new Matrix();
            translateMatrix.RotateAt(this._rotation, new PointF((this.X + dx + (int)(this.X1 - this.X) / 2) * zoom, (this.Y + dy + (int)(this.Y1 - this.Y) / 2) * zoom));
            tmpGp.Transform(translateMatrix);
            gp.AddPath(tmpGp, true);
        }

        public virtual void AddGp(GraphicsPath gp, int dx, int dy, float zoom)
        { }

        public virtual void Delete()
        {
            if (_connectionPoint != null)
            {
                ArrayList connectors = new ArrayList(_connectionPoint.Connectors);
                foreach (Line connector in connectors)
                {
                    connector.Delete();
                }
                connectors.Clear();
            }
            if (drawingPanel != null)
                drawingPanel.deleteObject(this);
        }

        public virtual ArrayList deGroup()
        {
            return null;
        }

        public virtual void Select()
        { }

        public virtual void Select(int sX, int sY, int eX, int eY)
        { }

        public virtual void DeSelect()
        { }

        public virtual void AfterLoad()
        {
            if (_connectionPoint != null)
                _connectionPoint.drawingPanel = drawingPanel;
        }

        public virtual void CopyFrom(BaseObject ele)
        { }

        public virtual BaseObject Copy()
        {
            return null;
        }

        public CConnectionPoint GetConnectionPoint(int x, int y)
        {
            InteractionType InteractionType = InteractionType.itNone;
            if (_connectionPoint != null)
                InteractionType = _connectionPoint.isOver(x, y);
            if (InteractionType != InteractionType.itNone)
                return _connectionPoint;
            return null;
        }

        protected void FillWithLines(Graphics g, int dx, int dy, float zoom, GraphicsPath myPath, float gridSize, float gridRot)
        {
            GraphicsState gs = g.Save();
            g.SetClip(myPath, CombineMode.Intersect);
            Matrix mx = g.Transform;
            PointF p = new PointF(zoom * (this.X + dx + (this.X1 - this.X) / 2), zoom * (this.Y + dy + (this.Y1 - this.Y) / 2));
            if (this._rotation > 0)
                mx.RotateAt(this._rotation, p, MatrixOrder.Append); 
            mx.RotateAt(gridRot, p, MatrixOrder.Append); 
            g.Transform = mx;

            int max = System.Math.Max(this.Width, this.Height);
            System.Drawing.Pen linePen = new System.Drawing.Pen(System.Drawing.Color.Gray);
            int nY = (int)(max * 3 / (gridSize));
            for (int i = 0; i <= nY; i++)
            {
                g.DrawLine(linePen, (this.X - max + dx) * zoom, (this.Y - max + dy + i * gridSize) * zoom, (this.X + dx + max * 2) * zoom, (this.Y - max + dy + i * gridSize) * zoom);
            }
            linePen.Dispose();
            g.Restore(gs);
        }

        protected float scaledPenWidth(float zoom)
        {
            if (zoom < 0.1f)
                zoom = 0.1f;
            return this.penWidth * zoom;
        }

        public virtual void Fit2grid(int gridsize)
        {
            this.startX = gridsize * (int)(this.startX / gridsize);
            this.startY = gridsize * (int)(this.startY / gridsize);
            this.startX1 = gridsize * (int)(this.startX1 / gridsize);
            this.startY1 = gridsize * (int)(this.startY1 / gridsize);
        }

        public virtual void CommitRotate(float x, float y)
        {
        }

        public virtual void Rotate(float x, float y)
        {
            float tmp = _rotate(x, y);
            this._rotation = (int)tmp;
        }

        protected PointF rotatePoint(PointF p, int RotAng)
        {
            double RotAngF = RotAng * Math.PI / 180;
            double SinVal = Math.Sin(RotAngF);
            double CosVal = Math.Cos(RotAngF);
            float Nx = (float)(p.X * CosVal - p.Y * SinVal);
            float Ny = (float)(p.Y * CosVal + p.X * SinVal);
            return new PointF(Nx, Ny);
        }

        protected float _rotate(float x, float y)
        {
            //
            Point c = new Point((int)(this.X + (this.X1 - this.X) / 2), (int)(this.Y + (this.Y1 - this.Y) / 2));
            float dx = x - c.X;
            float dy = y - c.Y;
            float b = 0f;
            float alpha = 0f;
            float f = 0f;
            if ((dx > 0) & (dy > 0))
            {
                b = 90;
                alpha = (float)Math.Abs((Math.Atan((double)(dy / dx)) * (180 / Math.PI)));
            }
            else
                if ((dx <= 0) & (dy >= 0))
                {
                    b = 180;
                    if (dy > 0)
                    {
                        alpha = (float)Math.Abs((Math.Atan((double)(dx / dy)) * (180 / Math.PI)));
                    }
                    else if (dy == 0)
                    {
                        b = 270;
                    }
                }
                else
                    if ((dx < 0) & (dy < 0))
                    {
                        b = 270;
                        alpha = (float)Math.Abs((Math.Atan((double)(dy / dx)) * (180 / Math.PI)));
                    }
                    else
                    {
                        b = 0;
                        alpha = (float)Math.Abs((Math.Atan((double)(dx / dy)) * (180 / Math.PI)));
                    }
            f = (b + alpha);
            return f;
        }

        private float getDimX()
        {
            return (float)(System.Math.Sqrt(System.Math.Pow(this.Width, 2) + System.Math.Pow(this.Height, 2)) - this.Width) / 2;
        }
        private float getDimY()
        {
            return (float)(System.Math.Sqrt(System.Math.Pow(this.Width, 2) + System.Math.Pow(this.Height, 2)) - this.Height) / 2;
        }

        protected Brush getBrush(int dx, int dy, float zoom)
        {
            if (this.filled)
            {
                return new SolidBrush(this.Trasparency(this.fillColor, this.alpha));
            }
            else
            {
                return null;
            }
        }

        protected void copyStdProp(BaseObject from, BaseObject to)
        {
            to.X = from.X;
            to.X1 = from.X1;
            to.Y = from.Y;
            to.Y1 = from.Y1;
            to.start = from.start;
            to.startX = from.startX;
            to.startX1 = from.startX1;
            to.startY = from.startY;
            to.startY1 = from.startY1;
            to.bIsLine = from.bIsLine;
            to.alpha = from.alpha;
            to.dashstyle = from.dashstyle;
            to.fillColor = from.fillColor;
            to.filled = from.filled;
            to.penColor = from.penColor;
            to._penWidth = from.penWidth;
            to.showBorder = from.showBorder;
        }

        protected int Dist(int x, int y, int x1, int y1)
        {
            return (int)System.Math.Sqrt(System.Math.Pow((x - x1), 2) + System.Math.Pow((y - y1), 2));
        }

        protected Color dark(Color c, int v, int a)
        {

            int r = c.R;
            r = r - v;
            if (r < 0)
                r = 0;
            if (r > 255)
                r = 255;
            int green = c.G;
            green = green - v;
            if (green < 0)
                green = 0;
            if (green > 255)
                green = 255;
            int b = c.B;
            b = b - v;
            if (b < 0)
                b = 0;
            if (b > 255)
                b = 255;
            if (a > 255)
                a = 255;
            if (a < 0)
                a = 0;

            return Color.FromArgb(a, r, green, b);

        }

        protected Color Trasparency(Color c, int v)
        {
            if (v < 0)
                v = 0;
            if (v > 255)
                v = 255;

            return Color.FromArgb(v, c);
        }

        public virtual bool contains(int x, int y)
        {
            if (bIsLine)
            {
                int appo = Dist(x, y, this.X, this.Y) + Dist(x, y, this.X1, this.Y1);
                int appo1 = Dist(this.X1, this.Y1, this.X, this.Y) + 7;

                return appo < appo1;
            }
            else
            {
                return new Rectangle(this.X, this.Y, this.X1 - this.X, this.Y1 - this.Y).Contains(x, y);
            }
        }

        public virtual void move(int x, int y)
        {
            this.X = this.startX - x;
            this.Y = this.startY - y;
            this.X1 = this.startX1 - x;
            this.Y1 = this.startY1 - y;
            if (_connectionPoint != null)
                _connectionPoint.rePosition();
        }

        public virtual void redim(int x, int y, InteractionType Type)
        {
            int newX = this.X;
            int newY = this.Y;
            int newX1 = this.X1;
            int newY1 = this.Y1;
            switch (Type)
            {
                case InteractionType.itResizeTopLeft:
                    newX = this.startX + x;
                    newY = this.startY + y;
                    break;
                case InteractionType.itResizeTop:
                    newY = this.startY + y;
                    break;
                case InteractionType.itResizeTopRight:
                    newX1 = this.startX1 + x;
                    newY = this.startY + y;
                    break;
                case InteractionType.itResizeRight:
                    newX1 = this.startX1 + x;
                    break;
                case InteractionType.itResizeBottomRight:
                    newX1 = this.startX1 + x;
                    newY1 = this.startY1 + y;
                    break;
                case InteractionType.itResizeBottom:
                    newY1 = this.startY1 + y;
                    break;
                case InteractionType.itResizeBottomLeft:
                    newX = this.startX + x;
                    newY1 = this.startY1 + y;
                    break;
                case InteractionType.itResizeLeft:
                    newX = this.startX + x;
                    break;
                default:
                    break;
            }

            if (!this.bIsLine)
            {
                if (newX + 10 > this.X1 && newX != this.X)
                    newX = this.X1 - 10;
                if (this.X + 10 > newX1 && newX1 != this.X1)
                    newX1 = this.X + 10;
                if (newY + 10 > this.Y1 && newY != this.Y)
                    newY = this.Y1 - 10;
                if (this.Y + 10 > newY1 && newY1 != this.Y1)
                    newY1 = this.Y + 10;
            }

            this.X = newX;
            this.Y = newY;
            this.X1 = newX1;
            this.Y1 = newY1;

            if (_connectionPoint != null)
                _connectionPoint.rePosition();
        }

        public virtual void endMoveRedim()
        {
            this.startX = this.X;
            this.startY = this.Y;
            this.startX1 = this.X1;
            this.startY1 = this.Y1;
        }

    }
}
