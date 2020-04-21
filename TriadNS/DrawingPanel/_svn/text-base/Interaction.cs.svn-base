using System;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace DrawingPanel
{
    [Serializable]
    public enum InteractionType
    {
        itNone,
        itResizeTopLeft,
        itResizeTop,
        itResizeTopRight,
        itResizeLeft,
        itResizeRight,
        itResizeBottomLeft,
        itResizeBottom,
        itResizeBottomRight,
        itMove,
        itRotate,
        itCP,
        itSelect
    }

    [Serializable]
    public abstract class InteractionPoint : BaseObject
    {
        public InteractionType Type = InteractionType.itNone;
        public bool visible=true;

        private BaseObject _owner;

        public BaseObject Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public InteractionPoint(DrawingPanel panel ,BaseObject e) : base(panel)
        {
            _owner = e;
            rePosition();
        }

        public InteractionPoint(DrawingPanel panel, BaseObject e, InteractionType PointType) : base(panel)
        {
            Type = PointType;
            _owner = e;
            rePosition();        
        }

        public virtual bool isSelected()
        {
            return this.bSelected;
        }

        public InteractionType isOver(int x, int y)
        {
            Rectangle r;
            r = new Rectangle(this.X, this.Y, this.X1 - this.X, this.Y1 - this.Y);
            if (r.Contains(x, y))
            {
                this.bSelected = true;
                return this.Type;
            }
            else
            {
                this.bSelected = false;
                return InteractionType.itNone;
            }
        }

        public virtual void rePosition()
        { }
    }

    [Serializable]
    public class IPResize : InteractionPoint
    {
        
        public IPResize(DrawingPanel panel, BaseObject obj, InteractionType PointType) : base(panel, obj , PointType) 
        {
            this.fillColor = Color.Red;
        }

        public override void rePosition()
        {
            switch (this.Type)
            {
                case InteractionType.itResizeTopLeft:
                    this.X = Owner.getX() - 3;
                    this.Y = Owner.getY() - 3;   
                    break;
                case InteractionType.itResizeTop:
                    this.X = Owner.getX() - 3 + ((Owner.getX1() - Owner.getX()) / 2);
                    this.Y = Owner.getY() - 3;
                    break;
                case InteractionType.itResizeTopRight:
                    this.X = Owner.getX1() - 3;
                    this.Y = Owner.getY() - 3;
                    break;
                case InteractionType.itResizeRight:
                    this.X = Owner.getX1() - 3;
                    this.Y = Owner.getY() - 3 + (Owner.getY1() - Owner.getY()) / 2;                    
                    break;
                case InteractionType.itResizeBottomRight:
                    this.X = Owner.getX1() - 3;
                    this.Y = Owner.getY1() - 3;
                    break;
                case InteractionType.itResizeBottom:
                    this.X = Owner.getX() - 3 + (Owner.getX1() - Owner.getX()) / 2;
                    this.Y = Owner.getY1() - 3;                    
                    break;
                case InteractionType.itResizeBottomLeft:
                    this.X = Owner.getX() - 3;
                    this.Y = Owner.getY1() - 3;
                    break;
                case InteractionType.itResizeLeft:
                    this.X = Owner.getX() - 3;
                    this.Y = Owner.getY() - 3 + (Owner.getY1() - Owner.getY()) / 2;
                    break;
                default: 
                    break;
            }
            this.X1 = this.X + 6;
            this.Y1 = this.Y + 6;
        }

        public override void Draw(Graphics g, int dx, int dy, float zoom)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(this.fillColor);
            myBrush.Color = this.Trasparency(Color.Red, 200);
            System.Drawing.Pen blackPen = new System.Drawing.Pen(System.Drawing.Color.Black);            
            g.FillRectangle(myBrush, new RectangleF((this.X + dx) * zoom, (this.Y + dy) * zoom, (this.X1 - this.X) * zoom, (this.Y1 - this.Y) * zoom));
            g.DrawRectangle(blackPen, (this.X + dx) * zoom, (this.Y + dy) * zoom, (this.X1 - this.X) * zoom, (this.Y1 - this.Y) * zoom);
            myBrush.Dispose();
            blackPen.Dispose();
        }
    }

    [Serializable]
    public  class IPRotatation : InteractionPoint 
    {

        public IPRotatation(DrawingPanel panel, BaseObject obj, InteractionType PointType)
            : base(panel, obj, PointType)
        { }

        public override void rePosition()
        {
            float midX, midY = 0;
            midX = (Owner.getX1() - Owner.getX()) / 2;
            midY = (Owner.getY1() - Owner.getY()) / 2;
            PointF Hp = new PointF(0, -25);
            PointF RotHP = this.rotatePoint(Hp, Owner.getRotation());
            midX += RotHP.X;
            midY += RotHP.Y;

            this.X = Owner.getX() + (int)midX - 2;
            this.Y = Owner.getY() + (int)midY - 2;
            this._rotation = Owner.getRotation();

            this.X1 = this.X + 5;
            this.Y1 = this.Y + 5;


        }

        public override void Draw(Graphics g, int dx, int dy, float zoom)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            //myBrush.Color = this.Trasparency(Color.Black, 80);
            System.Drawing.Pen whitePen = new System.Drawing.Pen(System.Drawing.Color.White);
            System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Blue, 1.5f);
            myPen.DashStyle = DashStyle.Dash;

            g.FillRectangle(myBrush, new RectangleF((this.X + dx) * zoom, (this.Y + dy) * zoom, (this.X1 - this.X) * zoom, (this.Y1 - this.Y) * zoom));
            g.DrawRectangle(whitePen, (this.X + dx) * zoom, (this.Y + dy) * zoom, (this.X1 - this.X) * zoom, (this.Y1 - this.Y) * zoom);

            //CENTER POINT
            float midX, midY = 0;
            midX = (this.X1 - this.X) / 2;
            midY = (this.Y1 - this.Y) / 2;

            PointF Hp = new PointF(0, 25);

            PointF RotHP = this.rotatePoint(Hp, this._rotation);
            
            RotHP.X += this.X;
            RotHP.Y += this.Y;
            g.FillEllipse(myBrush, (RotHP.X + midX + dx - 3) * zoom, (RotHP.Y + dy - 3 + midY) * zoom, 6 * zoom, 6 * zoom);
            g.DrawEllipse(whitePen, (RotHP.X + midX + dx - 3) * zoom, (RotHP.Y + dy - 3 + midY) * zoom, 6 * zoom, 6 * zoom);
            g.DrawLine(myPen, (this.X +midX+ dx) * zoom, (this.Y + midY + dy) * zoom, ( RotHP.X+midX + dx) * zoom, ( RotHP.Y+midY + dy) * zoom);

            myPen.Dispose();
            myBrush.Dispose();
            whitePen.Dispose();
        }
    }

    [Serializable]
    public class CConnectionPoint : InteractionPoint
    {
        public int Width = 6;
        public ArrayList Connectors;
        public CConnectionPoint(DrawingPanel panel, BaseObject e) : base(panel, e)
        {
            this.Type = InteractionType.itCP;
            this.fillColor = Color.Red;
            this.Connectors = new ArrayList();
        }

        public override bool isSelected()
        {
            return (this.bSelected);
        }

        public override void rePosition()
        {
            int midX, midY = 0;
            midX = (int)((Owner.getX1() - Owner.getX()) / 2f) + Owner.getX();
            midY = (int)((Owner.getY1() - Owner.getY()) / 2f) + Owner.getY();
            this.X = midX - Width / 2;
            this.Y = midY - Width / 2;
            this.X1 = midX + Width / 2;
            this.Y1 = midY + Width / 2;
            if (Connectors == null)
                return;
            foreach (Line connector in Connectors)
            {
                connector.RefreshPosition();
            }
        }

        public override void Draw(Graphics g, int dx, int dy, float zoom)
        {
            System.Drawing.Pen bluePen = new System.Drawing.Pen(System.Drawing.Color.Blue);

            g.DrawLine(bluePen, (this.X + dx) * zoom, (this.Y + dy) * zoom, (this.X + dx + Width) * zoom, (this.Y + dy + Width) * zoom);
            g.DrawLine(bluePen, (this.X + dx + Width) * zoom, (this.Y + dy) * zoom, (this.X + dx) * zoom, (this.Y + dy + Width) * zoom);
            bluePen.Dispose();

            if (drawingPanel.CurrentTool == ToolType.ttLine && isSelected())
            {
                System.Drawing.Pen fillPen = new System.Drawing.Pen(this.fillColor, 2);
                g.DrawRectangle(fillPen, (this.X + dx) * zoom, (this.Y + dy) * zoom, Width, Width);
                fillPen.Dispose();
            }
        }
    }

    [Serializable]
    public abstract class ObjSelectionBase : BaseObject
    {
        protected ArrayList Interactions;
        protected BaseObject owner;
        public ObjSelectionBase(DrawingPanel panel, BaseObject el) : base(panel)
        {
            this.owner = el;
            this.X = el.getX();
            this.Y = el.getY();
            this.X1 = el.getX1(); ;
            this.Y1 = el.getY1();
            this.bSelected = false;
            this.bCanRotate = el.canRotate();
            this._rotation = el.getRotation();
            this.bIsLine = el.bIsLine;
            Interactions = new ArrayList();
            this.endMoveRedim();
        }

        public override void endMoveRedim()
        {
            base.endMoveRedim();
            foreach (InteractionPoint h in Interactions)
            {
                h.endMoveRedim();
            }
        }


        public void setZoom(float x, float y)
        {
            foreach (InteractionPoint h in Interactions)
            {
                h.rePosition();
            }
        }

        public override void Rotate(float x, float y)
        {
            base.Rotate(x, y);
            foreach (InteractionPoint h in Interactions)
            {
                h.rePosition();
            }            
        }

        public override void move(int x, int y)
        {
            //if (owner is Line)
            //    return;
            base.move(x, y);
            foreach (InteractionPoint h in Interactions)
            {
                h.rePosition();
            }
        }

        public InteractionType isOver(int x, int y)
        {
            InteractionType Res = InteractionType.itNone;
            foreach (InteractionPoint h in Interactions)
            {
                Res = h.isOver(x, y);
                if (Res != InteractionType.itNone)
                    return Res;
            }

            if (this.contains(x, y))
                return InteractionType.itSelect;

            return Res;
        }

        public override void Select()
        {
            this.undoEle = this.Copy();
        }

        public override void redim(int x, int y, InteractionType InteractionType)
        {
            base.redim(x, y, InteractionType); //
            foreach (InteractionPoint h in Interactions)
            {
                h.rePosition();
            }

        }

        public override void Draw(Graphics g, int dx, int dy, float zoom)
        {
            foreach (InteractionPoint h in Interactions)
            {
                if (h.visible)
                    h.Draw(g, dx, dy, zoom);
            }
        }

    }


    [Serializable]
    public class ObjSelection : ObjSelectionBase
    {
        public ObjSelection(DrawingPanel panel, BaseObject el)
            : base(panel, el)
        {
            Init();
        }

        public void Init()
        {
            this.Interactions.Add(new IPResize(drawingPanel, this, InteractionType.itResizeTopLeft));
            this.Interactions.Add(new IPResize(drawingPanel, this, InteractionType.itResizeBottomRight));
            if (!bIsLine)
            {
                this.Interactions.Add(new IPResize(drawingPanel, this, InteractionType.itResizeTop));
                if (bCanRotate)
                {
                    this.Interactions.Add(new IPRotatation(drawingPanel, this, InteractionType.itRotate));
                }
                this.Interactions.Add(new IPResize(drawingPanel, this, InteractionType.itResizeTopRight));
                this.Interactions.Add(new IPResize(drawingPanel, this, InteractionType.itResizeRight));
                this.Interactions.Add(new IPResize(drawingPanel, this, InteractionType.itResizeBottom));
                this.Interactions.Add(new IPResize(drawingPanel, this, InteractionType.itResizeBottomLeft));
                this.Interactions.Add(new IPResize(drawingPanel, this, InteractionType.itResizeLeft));
            }

        }

        public override void Draw(Graphics g, int dx, int dy, float zoom)
        {
            
            System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Blue, 1.5f);
            myPen.DashStyle = DashStyle.Dash;
            if (this.bIsLine)
                g.DrawLine(myPen, (this.X + dx) * zoom, (this.Y + dy) * zoom, (this.X1 + dx) * zoom, (this.Y1 + dy) * zoom);
            else
                g.DrawRectangle(myPen, (this.X + dx) * zoom, (this.Y + dy) * zoom, (this.X1 - this.X) * zoom, (this.Y1 - this.Y) * zoom);
            myPen.Dispose();
            base.Draw(g, dx, dy, zoom);   
        }
    }
}
