using System;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace DrawingPanel
{
    #region Events & Delegates (Used by the controls vectShape & toolBox )
    
    public delegate void ToolChanged(object sender, ToolEventArgs e);

    public delegate void ObjectDeleted(object sender, ObjectEventArgs e);

    public delegate void ObjectSelected(object sender, PropertyEventArgs e);

    public delegate void BeforeAddLine(object sender, BeforeAddLineEventArgs e);
    
    public delegate void OnLineCPChanged(object sender, OnLineCPChangedEventArgs e);

    public class PropertyEventArgs : EventArgs
    {
        public BaseObject[] ele;
        public bool Undoable;
        public bool Redoable;

        public PropertyEventArgs(BaseObject[] a,bool r, bool u)
        {
            this.ele = a;
            this.Undoable = u;
            this.Redoable = r;
        }
    }

    public class ObjectEventArgs : EventArgs
    {
        public BaseObject deletedObject;

        public ObjectEventArgs(BaseObject deletedObject)
        {
            this.deletedObject = deletedObject;
        }
    }

    public class ToolEventArgs : EventArgs 
    {  
      public ToolType tool;
      
      public ToolEventArgs(ToolType tool) 
      {
         this.tool = tool;
      }
    }

    public class BeforeAddLineEventArgs : EventArgs
    {
        public CConnectionPoint fromCP;
        public CConnectionPoint toCP;
        public bool cancel;

        public BeforeAddLineEventArgs(CConnectionPoint from, CConnectionPoint to)
        {
            this.fromCP = from;
            this.toCP = to;
            this.cancel = false;
        }
    }

    public class OnLineCPChangedEventArgs : EventArgs
    {
        public Line line;
        public bool fromChanged;

        public OnLineCPChangedEventArgs(Line line, bool bFromChanged)
        {
            this.line = line;
            this.fromChanged = bFromChanged;
        }
    }
    
    #endregion

    #region AbSel
    /// <summary>
    /// Handle tool for redim/move/rotate shapes
    /// </summary>
    [Serializable]
    public class AbSel : BaseObject
    {
        public AbSel(DrawingPanel panel, BaseObject EL) : base(panel)
        {
            this.X = EL.getX();
            this.Y = EL.getY();
            this.X1 = EL.getX1();
            this.Y1 = EL.getY1();
            this.bSelected = false;
            this.endMoveRedim();
            this.bCanRotate = EL.canRotate();
            this._rotation = EL.getRotation();
        }

        public string isOver(int x, int y)
        {
            if (this.contains(x, y))
                return "C";
            return "NO";
        }

        public override void Select()
        {
            this.undoEle = this.Copy();
        }

        public override void Draw(Graphics g, int dx, int dy, float zoom)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            myBrush.Color = this.Trasparency(Color.Black, 80);

            System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Blue, 1.5f);
            myPen.DashStyle = DashStyle.Dash;

            System.Drawing.Pen whitePen = new System.Drawing.Pen(System.Drawing.Color.White);
                
            g.DrawRectangle(myPen, (this.X + dx) * zoom, (this.Y + dy) * zoom, (this.X1 - this.X) * zoom, (this.Y1 - this.Y) * zoom);
            
            myPen.Dispose();
            myBrush.Dispose();
        }
    }
    #endregion

    #region SelRectBK
    /// <summary>
    /// Handle tool for redim/move/rotate shapes
    /// </summary>
    [Serializable]
    public class SelRectBK : BaseObject
    {
        public SelRectBK(DrawingPanel panel, BaseObject EL) : base(panel)
        {
            this.X = EL.getX();
            this.Y = EL.getY();
            this.X1 = EL.getX1();
            this.Y1 = EL.getY1();
            this.bSelected = false;
            this.endMoveRedim();
            this.bCanRotate = EL.canRotate();
            this._rotation = EL.getRotation();
        }

        public string isOver(int x, int y)
        {
            Rectangle r;
            r = new Rectangle(this.X - 2, this.Y - 2, 5, 5);
            //NW
            if (r.Contains(x, y))
               return "NW";
            //SE
            r.X = this.X1 - 2;
            r.Y = this.Y1 - 2;
            if (r.Contains(x, y))
               return "SE";
             if (!bIsLine)
             {
               //N
                r.X = this.X - 2 + (this.X1 - this.X) / 2;
                r.Y = this.Y - 2;
                if (r.Contains(x, y))
                    return "N";
                if (bCanRotate)
                {
                    //ROT
                    float midX, midY = 0;
                    midX = (this.X1 - this.X) / 2;
                    midY = (this.Y1 - this.Y) / 2;
                    PointF Hp = new PointF(0, -25);
                    PointF RotHP = this.rotatePoint(Hp, this._rotation);
                    midX += RotHP.X;
                    midY += RotHP.Y;

                    r.X = this.X + (int)midX - 2;
                    r.Y = this.Y + (int)midY - 2;
                    if (r.Contains(x, y))
                        return "ROT";
                }
                //NE
                r.X = this.X1 - 2;
                r.Y = this.Y - 2;
                if (r.Contains(x, y))
                  return "NE";
                //E
                r.X = this.X1 - 2;
                r.Y = this.Y - 2 + (this.Y1 - this.Y) / 2;
                if (r.Contains(x, y))
                  return "E";
                //S
                r.X = this.X - 2 + (this.X1 - this.X) / 2;
                r.Y = this.Y1 - 2;
                if (r.Contains(x, y))
                  return "S";
                //SW
                r.X = this.X - 2;
                r.Y = this.Y1 - 2;
                if (r.Contains(x, y))
                  return "SW";
                //W
                r.X = this.X - 2;
                r.Y = this.Y - 2 + (this.Y1 - this.Y) / 2;
                if (r.Contains(x, y))
                  return "W";
            }
            if (this.contains(x, y))
                return "C";

            return "NO";

        }

        public override void Select()
        {
            this.undoEle = this.Copy();
        }

        public override void Draw(Graphics g, int dx, int dy, float zoom)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            myBrush.Color = this.Trasparency(Color.Black, 90);

            System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Blue, 1.5f);
            myPen.DashStyle = DashStyle.Dash;

            System.Drawing.Pen whitePen = new System.Drawing.Pen(System.Drawing.Color.White);
                //NW
                g.FillRectangle(myBrush, new RectangleF((int)((this.X + dx - 2)) * zoom, (int)((this.Y + dy - 2)) * zoom, (int)5 * zoom, (int)5 * zoom));
                g.DrawRectangle(whitePen, (this.X + dx - 2) * zoom, (this.Y + dy - 2) * zoom, 5 * zoom, 5 * zoom);
                //SE
                g.FillRectangle(myBrush, new RectangleF((this.X1 + dx - 2) * zoom, (this.Y1 + dy - 2) * zoom, (5) * zoom, (5) * zoom));
                g.DrawRectangle(whitePen, (this.X1 + dx - 2) * zoom, (this.Y1 + dy - 2) * zoom, (5) * zoom, (5) * zoom);
            if (!bIsLine)
            {
                    g.DrawRectangle(myPen, (this.X + dx) * zoom, (this.Y + dy) * zoom, (this.X1 - this.X) * zoom, (this.Y1 - this.Y) * zoom);
                    //N
                    g.FillRectangle(myBrush, (this.X + dx - 2 + (this.X1 - this.X) / 2) * zoom, (this.Y + dy - 2) * zoom, 5 * zoom, 5 * zoom);
                    g.DrawRectangle(whitePen, (this.X + dx - 2 + (this.X1 - this.X) / 2) * zoom, (this.Y + dy - 2) * zoom, 5 * zoom, 5 * zoom);
                {
                    //NE
                    g.FillRectangle(myBrush, (this.X1 + dx - 2) * zoom, (this.Y + dy - 2) * zoom, 5 * zoom, 5 * zoom);
                    g.DrawRectangle(whitePen, (this.X1 + dx - 2) * zoom, (this.Y + dy - 2) * zoom, 5 * zoom, 5 * zoom);
                }
                    //E
                    g.FillRectangle(myBrush, (this.X1 + dx - 2) * zoom, (this.Y + dy - 2 + (this.Y1 - this.Y) / 2) * zoom, 5 * zoom, 5 * zoom);
                    g.DrawRectangle(whitePen, (this.X1 + dx - 2) * zoom, (this.Y + dy - 2 + (this.Y1 - this.Y) / 2) * zoom, 5 * zoom, 5 * zoom);
                    //S
                    g.FillRectangle(myBrush, (this.X + dx - 2 + (this.X1 - this.X) / 2) * zoom, (this.Y1 + dy - 2) * zoom, 5 * zoom, 5 * zoom);
                    g.DrawRectangle(whitePen, (this.X + dx - 2 + (this.X1 - this.X) / 2) * zoom, (this.Y1 + dy - 2) * zoom, 5 * zoom, 5 * zoom);
                {
                    //SW
                    g.FillRectangle(myBrush, (this.X + dx - 2) * zoom, (this.Y1 + dy - 2) * zoom, 5 * zoom, 5 * zoom);
                    g.DrawRectangle(whitePen, (this.X + dx - 2) * zoom, (this.Y1 + dy - 2) * zoom, 5 * zoom, 5 * zoom);
                }
                    //W
                    g.FillRectangle(myBrush, (this.X + dx - 2) * zoom, (this.Y + dy - 2 + (this.Y1 - this.Y) / 2) * zoom, 5 * zoom, 5 * zoom);
                    g.DrawRectangle(whitePen, (this.X + dx - 2) * zoom, (this.Y + dy - 2 + (this.Y1 - this.Y) / 2) * zoom, 5 * zoom, 5 * zoom);

                    if (bCanRotate)
                    {
                        //C
                        float midX, midY = 0;
                        midX = (this.X1 - this.X) / 2;
                        midY = (this.Y1 - this.Y) / 2;
                        g.FillEllipse(myBrush, (this.X + midX + dx - 3) * zoom, (this.Y + dy - 3 + midY) * zoom, 6 * zoom, 6 * zoom);
                        g.DrawEllipse(whitePen, (this.X + midX + dx - 3) * zoom, (this.Y + dy - 3 + midY) * zoom, 6 * zoom, 6 * zoom);
                        // ROT
                        PointF Hp = new PointF(0, -25);
                        PointF RotHP = this.rotatePoint(Hp, this._rotation);
                        RotHP.X += midX;
                        RotHP.Y += midY;
                        g.FillRectangle(myBrush, (this.X + RotHP.X + dx - 3) * zoom, (this.Y + dy - 3 + RotHP.Y) * zoom, 6 * zoom, 6 * zoom);
                        g.DrawRectangle(whitePen, (this.X + RotHP.X + dx - 3) * zoom, (this.Y + dy - 3 + RotHP.Y) * zoom, 6 * zoom, 6 * zoom);
                        g.DrawLine(myPen, (this.X + midX + dx) * zoom, (this.Y + midY + dy) * zoom, (this.X + RotHP.X + dx) * zoom, (this.Y + RotHP.Y + dy) * zoom);
                    }
                }
                else
                {
                    g.DrawLine(myPen, (this.X + dx) * zoom, (this.Y + dy) * zoom, (this.X1 + dx) * zoom, (this.Y1 + dy) * zoom);
                }

            myPen.Dispose();
            myBrush.Dispose();
        }
    }
    #endregion
    
    [Serializable]
    public class Shapes
    {
        public ArrayList ShapeList;
        // The Handles Obj
        public ObjSelectionBase sRec;
        public BaseObject selectedObj;
        [NonSerialized]
        public DrawingPanel drawingPanel;

        public int minDim = 10;

        [NonSerialized]
        private UndoRedoBuffer undoB;

        public Shapes(DrawingPanel panel)
        {
            drawingPanel = panel;
            ShapeList = new ArrayList();
            initUndoBuff();
        }

        private void initUndoBuff()
        {
            undoB = new UndoRedoBuffer(20);
        }

        public bool IsEmpty()
        {
            return ( ShapeList.Count>0 );
        }

        public void afterLoad()
        {
            initUndoBuff();
            foreach (BaseObject e in this.ShapeList)
            {
                e.drawingPanel = drawingPanel;
                e.AfterLoad();
            }
        }

        public void CopyMultiSelected(int dx, int dy)
        {
            ArrayList tmpList = new ArrayList();
            foreach (BaseObject elem in this.ShapeList)
            {
                if (elem.bSelected)
                {
                    BaseObject eL = elem.Copy();
                    elem.bSelected = false;
                    eL.move(dx, dy);
                    tmpList.Add(eL);
                    
                    sRec = new ObjSelection(drawingPanel, eL);
                    selectedObj = eL;
                    selectedObj.endMoveRedim();
                }
            }
            foreach (BaseObject tmpElem in tmpList)
            {
                this.ShapeList.Add(tmpElem);
                storeDo(UndoRedoAction.uraInsert, tmpElem);
            }
                        
        }

        public BaseObject CpSelected()
        {
            if (this.selectedObj != null)
            {
                BaseObject L = selectedObj.Copy();
                return L;
            }
            return null;
        }

        public void CopySelected(int dx,int dy)
        {
            if (this.selectedObj != null)
            {

                BaseObject L = this.CpSelected();
                L.move(dx, dy);
                this.deSelect();
                this.ShapeList.Add(L);
                
                storeDo(UndoRedoAction.uraInsert, L);

                sRec = new ObjSelection(drawingPanel, L);
                selectedObj = L;
                selectedObj.endMoveRedim();
            }
        }

        public void DeleteSelected()
        {
            ArrayList tmpList = new ArrayList();
            foreach (BaseObject elem in this.ShapeList)
            {
                if (elem.bSelected)
                {
                    tmpList.Add(elem);    
                }
            }

            if (this.selectedObj != null)
            {
                selectedObj = null;
                this.sRec = null;
            }

            foreach (BaseObject tmpElem in tmpList)
            {
                tmpElem.Delete();
                storeDo(UndoRedoAction.uraDelete, tmpElem);
                
            }

        }

        public Line GetLine(BaseObject obj1, BaseObject obj2)
        {
            Line FindedLine = null;
            foreach (BaseObject obj in ShapeList)
            {
                if (obj is Line)
                {
                    Line line = obj as Line;
                    if (line.FromCP.Owner == obj1 && line.ToCP.Owner == obj2
                        || line.FromCP.Owner == obj2 && line.ToCP.Owner == obj1)
                    {
                        FindedLine = line;
                        break;
                    }
                }
            }
            return FindedLine;
        }

        public CConnectionPoint GetConnectionPoint(int x, int y)
        {
            CConnectionPoint res = null;
            foreach (BaseObject obj in this.ShapeList)
            {
                res = obj.GetConnectionPoint(x, y);
                if (res != null)
                    break;
            }
            return res;
        }

        public InteractionType isOver(int x, int y)
        {
            InteractionType Res = InteractionType.itNone;
            if (sRec != null)
                Res = sRec.isOver(x, y);
            return Res;
        }

        public BaseObject GetHoverShape(int x, int y)
        {
            BaseObject res = null;
            foreach (BaseObject obj in ShapeList)
            {
                if (obj is Line)
                    continue;
                if (obj.contains(x, y))
                {
                    res = obj;
                    break;
                }
            }
            return res;
        }

        public void move(int dx, int dy)
        {
            foreach (BaseObject e in this.ShapeList)
            {
                if (e.bSelected && !(e is Line))
                {
                    e.move(dx, dy);
                }
            }
        }

        public void Fit2grid(int gridsize)
        {
            foreach (BaseObject e in this.ShapeList)
            {
                if (e.bSelected)
                {
                    e.Fit2grid(gridsize);
                    
                }
            }
        }


        public void endMove()
        {
            foreach (BaseObject e in this.ShapeList)
            {
                if (e.bSelected)
                {
                    e.endMoveRedim();
                    storeDo(UndoRedoAction.uraUpdate, e); 
                }
            }
        }

        public void Propertychanged()
        {
            foreach (BaseObject e in this.ShapeList)
            {
                if (e.bSelected)
                {
                    storeDo(UndoRedoAction.uraUpdate, e);
                }
            }

        }

        #region undo/redo 

        public bool UndoEnabled()
        {
            return this.undoB.unDoable();
        }

        public bool RedoEnabled()
        {
            return this.undoB.unRedoable();
        }

        public void storeDo(UndoRedoAction Action, BaseObject e)
        {
            BaseObject olde = null;
            if (e.undoEle != null)
                olde = e.undoEle.Copy();
            BaseObject newe = e.Copy();
            BufferElement buff = new BufferElement(e, newe, olde, Action);
            this.undoB.add2Buff(buff);
            e.undoEle = e.Copy();
        }

        public void Undo() 
        {
            BufferElement buff = (BufferElement)this.undoB.Undo();
            if (buff != null)
            {
                switch (buff.Action)
                {
                    case UndoRedoAction.uraUpdate:
                        buff.RefElem.CopyFrom(buff.OldElem);
                        break;
                    case UndoRedoAction.uraInsert:
                        this.ShapeList.Remove(buff.RefElem);
                        break;
                    case UndoRedoAction.uraDelete:
                        this.ShapeList.Add(buff.RefElem);
                        break;
                    default:
                        break;
                }
            }
        }

        public void Redo()
        {
            BufferElement buff = (BufferElement)this.undoB.Redo();
            if (buff != null)
            {
                switch (buff.Action)
                {
                    case UndoRedoAction.uraUpdate:
                        buff.RefElem.CopyFrom(buff.NewElem);
                        break;
                    case UndoRedoAction.uraInsert:
                        this.ShapeList.Add(buff.RefElem);
                        break;
                    case UndoRedoAction.uraDelete:
                        this.ShapeList.Remove(buff.RefElem);
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        private int countSelected()
        {
            int i = 0;
            foreach (BaseObject e in this.ShapeList)
            {
                if (e.bSelected)
                {
                    i++;
                }
            }
            return i;
        }

        public BaseObject[] getSelectedArray()
        {
            BaseObject[] myArray = new BaseObject[this.countSelected()];   
            int i = 0;
            foreach (BaseObject e in this.ShapeList)
            {
                if (e.bSelected)
                {
                    myArray[i]=e;
                    i++;
                }
                    
            }
            return myArray;
        }

        public ArrayList getSelectedList()
        {
            ArrayList tmpL = new ArrayList();
            foreach (BaseObject e in this.ShapeList)
            {
                if (e.bSelected)
                {
                    tmpL.Add(e);
                }
            }
            return tmpL;
        }

        public void setList(ArrayList a)
        {
            foreach (BaseObject e in a)
            {
                 this.ShapeList.Add(e);

            }
        }
        public void deSelect()
        {
            foreach (BaseObject obj in this.ShapeList)
            {
                obj.bSelected = false;
            }
            selectedObj = null;
            sRec = null;
        }

        #region DRAW

        public void Draw(Graphics g,int dx, int dy, float zoom)
        {
            bool almostOneSelected = false;
            foreach (BaseObject obj in this.ShapeList)
            {
                obj.Draw(g,dx,dy, zoom);
                if (obj.bSelected)
                    almostOneSelected = true;                    
            }
            if (almostOneSelected)
                if (sRec !=null)
                    sRec.Draw(g,dx,dy,zoom);
        }


        public void DrawUnselected(Graphics g, int dx , int dy,float zoom)
        {
            g.PageScale = 10;
            foreach (BaseObject obj in this.ShapeList)
            {
                if (!obj.bSelected)
                {
                    obj.Draw(g, dx, dy, zoom);
                }
            }
        }


        public void DrawUnselected(Graphics g)
        {
            g.PageScale = 10;
            foreach (BaseObject obj in this.ShapeList)
            {

                if (!obj.bSelected)
                    obj.Draw(g,0,0,1);
            }
        }

        public void DrawSelected(Graphics g,int dx, int dy, float zoom)
        {
            bool almostOneSelected = false;
            
            foreach (BaseObject obj in this.ShapeList)
            {
                if (obj.bSelected)
                {
                    obj.Draw(g,dx,dy,zoom);
                    almostOneSelected = true;
                }
            }
            if (almostOneSelected)
                if (sRec != null)
                {
                    sRec.Draw(g, dx, dy, zoom);
                }
        }

        public void DrawSelected(Graphics g)
        {
            bool almostOneSelected = false;
            foreach (BaseObject obj in this.ShapeList)
            {
                if (obj.bSelected)
                {
                    obj.Draw(g,0,0,1);
                    almostOneSelected = true;
                }
            }
            if (almostOneSelected)
                if (sRec != null)
                    sRec.Draw(g,0,0,1);
        }

        #endregion

        #region ADD ELEMNTS METODS

        public void addConnector(CConnectionPoint From, CConnectionPoint To, Color penC, float penW)
        {
            this.deSelect();
            Line r = new Line(drawingPanel, From, To);

            r.penColor = penC;
            r.penWidth = penW;

            this.ShapeList.Add(r);
            storeDo(UndoRedoAction.uraInsert, r);

            sRec = new ObjSelection(drawingPanel, r);
            
            selectedObj = r;
            selectedObj.Select();
        }

        public ImgBox addImgBox(int x, int y, int x1, int y1, string st, Color penC, float penW)
        {
            if (x1 - minDim <= x)
                x1 = x + minDim;
            if (y1 - minDim <= y)
                y1 = y + minDim;             

            this.deSelect();
            ImgBox r = new ImgBox(drawingPanel, x, y, x1, y1);
            r.penColor = penC;
            r.penWidth = penW;

            this.ShapeList.Add(r);
            storeDo(UndoRedoAction.uraInsert, r);

            if (!(st == null))
            {
                try
                {
                    Bitmap loadTexture = new Bitmap(st);
                    r.img = loadTexture;
                }
                catch { }
            }


            sRec = new ObjSelection(drawingPanel, r);
            selectedObj = r;
            selectedObj.Select();
            return r;
        }

        public void AddShape(BaseObject obj)
        {
            this.deSelect();
            this.ShapeList.Add(obj);

            storeDo(UndoRedoAction.uraInsert, obj);

            sRec = new ObjSelection(drawingPanel, obj);
            selectedObj = obj;
            selectedObj.Select();
            drawingPanel.SelectedChanged();
        }

        #endregion

        /// <summary>
        /// Selects last shape containing x,y
        /// </summary>
        public void click(int x, int y)
        {
            sRec = null;
            selectedObj = null;
            foreach (BaseObject obj in this.ShapeList)
            {
                obj.bSelected = false;
                obj.DeSelect();
                if (obj.contains(x, y))
                {
                    selectedObj = obj;
                }
            }
            if (selectedObj != null)
            {
                selectedObj.bSelected = true;
                selectedObj.Select();
                sRec = new ObjSelection(drawingPanel, selectedObj);
            }
        }

        /// <summary>
        /// Выделить все что находится в заданном прямоугольнике 
        /// </summary>
        public void multiSelect(int startX, int startY, int endX, int endY)
        {
            sRec = null;
            selectedObj = null;
            foreach (BaseObject obj in this.ShapeList)
            {

                obj.bSelected = false;
                obj.DeSelect();
                int x = obj.getX();
                int x1 = obj.getX1();
                int y = obj.getY();
                int y1 = obj.getY1();
                int c = 0;
                if (x > x1)
                {
                    c = x;
                    x = x1;
                    x1 = c;
                }
                if (y > y1)
                {
                    c = y;
                    y = y1;
                    y1 = c;
                }
                if (x <= endX & x1 >= startX & y <= endY & y1 >= startY)
                {
                    selectedObj = obj;
                    obj.bSelected = true;
                    obj.Select();
                    obj.Select(startX, startY, endX, endY);
                }
            }
            if (selectedObj != null)
            {
                sRec = new ObjSelection(drawingPanel, selectedObj);
            }

        }

    }
}