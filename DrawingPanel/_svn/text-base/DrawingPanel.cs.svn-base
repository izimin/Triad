using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO; 						
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DrawingPanel
{
    public enum ToolType
    {
        ttSelect,
        ttImageBox,
        ttLine,
        ttHandMove
    }

    public enum DrawingStatus 
    {
        dsNone,
        dsResizeShape,
        dsSelectRect,
        dsDrawRect
    }

    public partial class DrawingPanel :  UserControl
    {
        private DrawingStatus CurrentStatus;
        public ToolType CurrentTool;
        private InteractionType InteractionType = InteractionType.itNone;


        private int startX;
        private int startY;
        private Shapes _shapes;
        private NameEdit _edit;
        private BaseObject hoverShape;

        private CConnectionPoint CurrentCP;
        private CConnectionPoint FromCP;

        private float _Zoom = 1;
        private bool _A4 = true;

        private int _dx = 0;
        private int _dy = 0;
        private int startDX = 0;
        private int startDY = 0;
        private int truestartX = 0;
        private int truestartY = 0;

        private Bitmap offScreenBmp;
        private Bitmap offScreenBackBmp;

        // Grid
        public int _gridSize = 20;
        public bool bStickToGrid = false;

        //Graphic
        private System.Drawing.Drawing2D.CompositingQuality _CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.Default;
        private System.Drawing.Text.TextRenderingHint _TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        private System.Drawing.Drawing2D.SmoothingMode _SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        private System.Drawing.Drawing2D.InterpolationMode _InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;

        // Drawing Rect
        private bool MouseSx;
        private int tempX;
        private int tempY;

        private PrintPreviewFrm PreviewFrm;

        public Color CreationPenColor;
        public float CreationPenWidth;
        public Color CreationFillColor;
        public bool CreationFilled;


        //EVENT
        public event ToolChanged toolChanged;
        public event ObjectSelected objectSelected;
        public event ObjectDeleted objectDeleted;
        public event BeforeAddLine beforeAddLine;
        public event OnLineCPChanged onLineCPChanged;

        public static Cursor getCursor(string a, Cursor defCur)
        {
            try
            {
                return new Cursor(a);
            }
            catch
            {
                return defCur;
            }
        }

        public DrawingPanel()
        {
            InitializeComponent();
            myInit();
        }

        //Graphic
        [CategoryAttribute("Graphics"), DescriptionAttribute("InterpolationMode")]
        public System.Drawing.Drawing2D.InterpolationMode InterpolationMode
        {
            get
            {
                return _InterpolationMode;
            }
            set
            {
                _InterpolationMode = value;
            }
        }


        [CategoryAttribute("Graphics"), DescriptionAttribute("SmoothingMode")]
        public System.Drawing.Drawing2D.SmoothingMode SmoothingMode
        {
            get
            {
                return _SmoothingMode;
            }
            set
            {
                _SmoothingMode = value;
            }
        }

        [CategoryAttribute("Graphics"), DescriptionAttribute("Txt.Rend.Hint")]
        public System.Drawing.Text.TextRenderingHint TextRenderingHint
        {
            get
            {
                return _TextRenderingHint;
            }
            set
            {
                _TextRenderingHint = value;
            }
        }

        [CategoryAttribute("Graphics"), DescriptionAttribute("Comp.Quality")]
        public System.Drawing.Drawing2D.CompositingQuality CompositingQuality
        {
            get
            {
                return _CompositingQuality;
            }
            set
            {
                _CompositingQuality = value;
            }
        }


        [CategoryAttribute("  "), DescriptionAttribute("Grid Size")]
        public int gridSize
        {
            get
            {
                return _gridSize;
            }
            set
            {
                if (value >= 0)
                {
                    _gridSize = value;
                }
                if (_gridSize > 0)
                {
                    dx = _gridSize * (int)(dx / _gridSize);
                    dy = _gridSize * (int)(dy / _gridSize);
                }
                redraw(true);
            }
        }

        [CategoryAttribute("  "), DescriptionAttribute("Stick to grid")]
        public bool StickToGrid
        {
            get
            {
                return bStickToGrid;
            }
            set
            {
                bStickToGrid = value;
            }
        }


        [CategoryAttribute("  "), DescriptionAttribute("Zoom")]
        public float Zoom
        {
            get
            {
                return _Zoom;
            }
            set
            {
                if (value > 0)
                    _Zoom = value;
                else
                    _Zoom = 1;
                AutoScrollMinSize = new System.Drawing.Size((int)(1024 * _Zoom), (int)(768 * _Zoom));
                redraw(true);
            }
        }


        [CategoryAttribute("  "), DescriptionAttribute("Show A4")]
        public bool A4
        {
            get
            {
                return _A4;
            }
            set
            {
                 _A4 = value;
            }
        }

        [CategoryAttribute("  "), DescriptionAttribute("OriginX")]
        public int dx
        {
            get
            {
                return _dx;
            }
            set
            {
                    _dx = value;
            }
        }

        [CategoryAttribute("  "), DescriptionAttribute("OriginY")]
        public int dy
        {
            get
            {
                return _dy;
            }
            set
            {
                _dy = value;
            }
        }

        [Browsable(false)]
        public ArrayList Shapes
        {
            get
            {
                return _shapes.ShapeList;
            }
        }

        [Browsable(false)]
        public Shapes ShapeCollection
        {
            get
            {
                return _shapes;
            }
        }
        
        private void myInit()
        {
            CurrentStatus = DrawingStatus.dsNone;
            CurrentTool = ToolType.ttSelect;
            _shapes = new Shapes(this);
            _edit = new NameEdit(this);
            _edit.Visible = false;
            this.Controls.Add(_edit);

            CreationPenColor=Color.Black;
            CreationPenWidth=1f;
            CreationFillColor=Color.Black;
            CreationFilled=false;

            this.toolChanged += new ToolChanged(OnToolChanged);
            this.objectSelected += new ObjectSelected(OnObjectSelected);
            this.objectDeleted += new ObjectDeleted(OnObjectDeleted);

            offScreenBackBmp = new Bitmap(this.Width, this.Height);
            offScreenBmp = new Bitmap(this.Width, this.Height);
        }

        private void OnToolChanged(object sender, ToolEventArgs e)
        { }

        private void OnObjectSelected(object sender, PropertyEventArgs e)
        { }

        private void OnObjectDeleted(object sender, ObjectEventArgs e)
        { }

        public void SelectedChanged()
        {
            PropertyEventArgs e1 = new PropertyEventArgs(this._shapes.getSelectedArray(), this._shapes.RedoEnabled(), this._shapes.UndoEnabled());
            objectSelected(this, e1);
            redraw(true);
        }

        private void changeTool(ToolType tool)
        {
            this.CurrentTool = tool;
            toolChanged(this, new ToolEventArgs(CurrentTool));
        }

        public void deleteObject(BaseObject e)
        {
            if (_shapes.ShapeList.IndexOf(e) != -1)
            {
                this._shapes.ShapeList.Remove(e);
                objectDeleted(this, new ObjectEventArgs(e));
            }
        }

        public void Clear()
        {
            _shapes = new Shapes(this);
            redraw(true);
        }
        
        public void PrintPreview(float zoom)
        {
            InitializePrintPreviewControl(zoom);
        }

        #region Print & Preview

        public void PrintPreview()
        {
            this._shapes.deSelect();

            PreviewFrm = new PrintPreviewFrm();
            PreviewFrm.PrintPreviewControl1.Name = "PrintPreviewControl1";
            PreviewFrm.PrintPreviewControl1.Document = PreviewFrm.docToPrint;

            PreviewFrm.PrintPreviewControl1.Zoom = 1;

            PreviewFrm.PrintPreviewControl1.Document.DocumentName = "PrintPreview";

            PreviewFrm.PrintPreviewControl1.UseAntiAlias = true;

            PreviewFrm.docToPrint.PrintPage +=
                new System.Drawing.Printing.PrintPageEventHandler(
                docToPrint_PrintPage);

            PreviewFrm.docToPrint.Print();

            PreviewFrm.Dispose();

        }

        private void InitializePrintPreviewControl(float zoom)
        {
            this._shapes.deSelect();

            PreviewFrm = new PrintPreviewFrm();
            PreviewFrm.PrintPreviewControl1.Name = "Preview";
            PreviewFrm.PrintPreviewControl1.Document = PreviewFrm.docToPrint;
            PreviewFrm.PrintPreviewControl1.Zoom = zoom;
            PreviewFrm.PrintPreviewControl1.Document.DocumentName = "Preview";
            PreviewFrm.PrintPreviewControl1.UseAntiAlias = true;
            PreviewFrm.docToPrint.PrintPage +=
                new System.Drawing.Printing.PrintPageEventHandler(
                docToPrint_PrintPage);
            PreviewFrm.ShowDialog();
        }

        private void docToPrint_PrintPage(
            object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Graphics g = e.Graphics;
            if (this.BackgroundImage != null)
                g.DrawImage(this.BackgroundImage, 0, 0);
            _shapes.Draw(g,0,0,1);
            g.Dispose();
        }


        #endregion


        public bool UndoEnabled()
        {
            return this._shapes.UndoEnabled();
        }

        public bool RedoEnabled()
        {
            return this._shapes.RedoEnabled();
        }

        public void Undo()
        {
            this._shapes.Undo();
            this._shapes.deSelect();
            this.redraw(true);
        }

        public void Redo()
        {
            this._shapes.Redo();
            this._shapes.deSelect();
            this.redraw(true);
        }


        public void setPenColor(Color c)
        {
            CreationPenColor = c;
            if (_shapes.selectedObj != null)
            {
                this._shapes.selectedObj.penColor = c;
            }            
        }

        public void setFillColor(Color c)
        {
            CreationFillColor = c;
            if (_shapes.selectedObj != null)
            {
                this._shapes.selectedObj.fillColor = c;
            }
        }

        public void setFilled(bool f)
        {
            CreationFilled = f;
            if (_shapes.selectedObj != null)
            {
                this._shapes.selectedObj.filled = f;
            }
        }

        public void setPenWidth(float f)
        {
            CreationPenWidth = f;
            if (_shapes.selectedObj != null)
            {
                this._shapes.selectedObj.penWidth = f;
            }
        }
        
        public void DeleteSelected()
        {
            this._shapes.DeleteSelected();
            redraw(true);
        }

        public void cpSelected()
        {
            this._shapes.CopyMultiSelected(25, 15);
            redraw(true);
        }

        public string Loader()
        {
            try
            {
                Stream StreamRead;
                OpenFileDialog DialogueCharger = new OpenFileDialog();
                DialogueCharger.DefaultExt = "ns";
                DialogueCharger.Title = "Загрузка сети";
                DialogueCharger.Filter = "Netwotk files (*.ns)|*.ns|All files (*.*)|*.*";
                if (DialogueCharger.ShowDialog() == DialogResult.OK)
                {
                    if ((StreamRead = DialogueCharger.OpenFile()) != null)
                    {
                        BinaryFormatter BinaryRead = new BinaryFormatter();
                        this._shapes = (Shapes) BinaryRead.Deserialize(StreamRead);
                        StreamRead.Close();

                        _shapes.drawingPanel = this;
                        this._shapes.afterLoad();

                        this.redraw(true);
                        return DialogueCharger.FileName;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception:" + e.ToString(), "Load error:");
            }
            return string.Empty;
        }

        public string Saver(string fileName)
        {
            try
            {
                Stream StreamWrite;
                SaveFileDialog DialogueSauver = new SaveFileDialog();
                DialogueSauver.DefaultExt = "ns";
                DialogueSauver.Title = "Сохранить сеть";
                DialogueSauver.Filter = "Network files (*.ns)|*.ns|All files (*.*)|*.*";
                bool bOK = false;
                if (fileName != string.Empty)
                {
                    DialogueSauver.FileName = fileName;
                    bOK = true;
                }
                else if (DialogueSauver.ShowDialog() == DialogResult.OK)
                        bOK = true;
                if (bOK && (StreamWrite = DialogueSauver.OpenFile()) != null)
                {
                        BinaryFormatter BinaryWrite = new BinaryFormatter();
                        BinaryWrite.Serialize(StreamWrite, this._shapes);
                        StreamWrite.Close();
                        return DialogueSauver.FileName;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception:" + e.ToString(), "Save error:");
            }
            return string.Empty;
        }

        public bool SaveSelected()
        {
            ArrayList a = this._shapes.getSelectedList();
            if ((a!=null)&&(a.Count >0 ))
            {
                try
                {
                    Stream StreamWrite;
                    SaveFileDialog DialogueSauver = new SaveFileDialog();
                    DialogueSauver.DefaultExt = "sobj";
                    DialogueSauver.Title = "Save as sobj";
                    DialogueSauver.Filter = "sobj files (*.sobj)|*.sobj|All files (*.*)|*.*";
                    if (DialogueSauver.ShowDialog() == DialogResult.OK)
                    {
                        if ((StreamWrite = DialogueSauver.OpenFile()) != null)
                        {
                            BinaryFormatter BinaryWrite = new BinaryFormatter();
                            BinaryWrite.Serialize(StreamWrite, a);
                            StreamWrite.Close();
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception:" + e.ToString(), "Save error:");
                }             
            }
            return false;
        }

        public bool LoadObj()
        {
            try
            {
                Stream StreamRead;
                OpenFileDialog DialogueCharger = new OpenFileDialog();
                DialogueCharger.DefaultExt = "sobj";
                DialogueCharger.Title = "Load sobj";
                DialogueCharger.Filter = "frame files (*.sobj)|*.sobj|All files (*.*)|*.*";
                if (DialogueCharger.ShowDialog() == DialogResult.OK)
                {
                    if ((StreamRead = DialogueCharger.OpenFile()) != null)
                    {
                        BinaryFormatter BinaryRead = new BinaryFormatter();
                        ArrayList a = (ArrayList)BinaryRead.Deserialize(StreamRead);
                        this._shapes.setList(a);
                        StreamRead.Close();
                        this._shapes.afterLoad();
                        this.redraw(true);
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception:" + e.ToString(), "Load error:");
            }
            return false;
        }

        public string imgLoader()
        {
            try
            {
                OpenFileDialog DialogueCharger = new OpenFileDialog();
                DialogueCharger.Title = "Load background image";
                DialogueCharger.Filter = "jpg files (*.jpg)|*.jpg|bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";
                if (DialogueCharger.ShowDialog() == DialogResult.OK)
                {
                    return (DialogueCharger.FileName);
                }
            }
            catch { }
            return null;
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            this.redraw(false); 
        }

        private void DrawingPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DeleteSelected();
            if (e.KeyCode == Keys.F2)
                _edit.Edit(_shapes.selectedObj);
        }

        #region DRAWING

        private void GraphicSetUp(Graphics g)
        {
            g.CompositingQuality = this.CompositingQuality;
            g.TextRenderingHint = this.TextRenderingHint;
            g.SmoothingMode = this.SmoothingMode;
            g.InterpolationMode = this.InterpolationMode;
        }

        public void redraw(bool All)
        {

            if (bStickToGrid & this.gridSize > 0)
            {
                this.startX = this.gridSize * (int)(startX / this.gridSize);
                this.startY = this.gridSize * (int)(startY / this.gridSize);
            }


            Graphics g = this.CreateGraphics();

            this.GraphicSetUp(g);
            
            if (All)
            {
                Graphics backG;
                backG = Graphics.FromImage(offScreenBackBmp);
                this.GraphicSetUp(backG);
                backG.Clear(this.BackColor);

                if (this.BackgroundImage != null)
                    backG.DrawImage(this.BackgroundImage, 0, 0);

                // Render the grid
                if (this.gridSize > 0)
                {
                    System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.LightGray);
                    int nX = (int)(this.Width / (this.gridSize * Zoom));
                    for (int i = 0; i <= nX; i++)
                    {
                        backG.DrawLine(myPen, i * this.gridSize * Zoom, 0, i * this.gridSize * Zoom, this.Height);
                    }
                    int nY = (int)(this.Height / (this.gridSize * Zoom));
                    for (int i = 0; i <= nY; i++)
                    {
                        backG.DrawLine(myPen, 0, i * this.gridSize * Zoom, this.Width, i * this.gridSize * Zoom);
                    }
                    myPen.Dispose();
                }

                _shapes.DrawUnselected(backG,this.dx,this.dy,this.Zoom);
                backG.Dispose();
            }

            //Do Double Buffering
            Graphics offScreenDC;
            offScreenDC = Graphics.FromImage(offScreenBmp);
            offScreenDC.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            offScreenDC.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            offScreenDC.Clear(this.BackColor);


            offScreenDC.DrawImageUnscaled(this.offScreenBackBmp,0,0);

            _shapes.DrawSelected(offScreenDC, this.dx, this.dy, this.Zoom);


            if (this.MouseSx & this.CurrentStatus == DrawingStatus.dsDrawRect)
            {
                System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red, 1.5f);
                myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                myPen.StartCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;

                if (CurrentTool == ToolType.ttLine)
                {
                    offScreenDC.DrawLine(myPen, (startX + this.dx) * this.Zoom, (startY + this.dy) * this.Zoom, (tempX + this.dx) * this.Zoom, (tempY + this.dy) * this.Zoom);
                }
                else
                {
                    offScreenDC.DrawRectangle(myPen, (this.startX + this.dx) * this.Zoom, (this.startY + this.dy) * this.Zoom, (tempX - this.startX) * this.Zoom, (tempY - this.startY) * this.Zoom);
                }
                myPen.Dispose();
            }

            if (this.MouseSx & this.CurrentStatus == DrawingStatus.dsSelectRect)
            {
                int startX = this.startX;
                int endX = this.tempX;
                if (startX > endX)
                {
                    startX = this.tempX;
                    endX = this.startX;
                }
                int startY = this.startY;
                int endY = this.tempY;
                if (startY > endY)
                {
                    startY = this.tempY;
                    endY = this.startY;
                }
                if (startX == endX)
                    endX++;
                if (startY == endY)
                    endY++;
                System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Blue, 1.5f);
                myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                offScreenDC.DrawRectangle(myPen, (startX + this.dx) * this.Zoom, (startY + this.dy) * this.Zoom, (endX - startX) * this.Zoom, (endY - startY) * this.Zoom);
                myPen.Dispose();
            }

            if (this.A4)
            {
                System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Blue, 0.5f);
                myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                offScreenDC.DrawRectangle(myPen, (1 + this.dx) * this.Zoom, (1 + this.dy) * this.Zoom, 810 * this.Zoom, 1140 * this.Zoom);
                myPen.Dispose();
            }

            g.DrawImageUnscaled(offScreenBmp, 0, 0);

            offScreenDC.Dispose();
            g.Dispose();

        }

        #endregion

        #region MOUSE

        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (_edit.Visible && !_edit.SaveValue())
                return;
            
            this.startX = (int)((e.X) / Zoom - this.dx);
            this.startY = (int)((e.Y) / Zoom - this.dy);

            this.truestartX = (int)e.X;
            this.truestartY = (int)e.Y;

            switch(e.Button)
            {
            case MouseButtons.Left:
                {
                #region START LEFT MOUSE BUTTON PRESSED
                this.MouseSx = true; // I start pressing SX
                switch (CurrentTool)
                {
                    case ToolType.ttSelect:
                        if (this.InteractionType != InteractionType.itNone)
                        {
                            CurrentCP = _shapes.GetConnectionPoint((int)(e.X / Zoom) - this.dx, (int)(e.Y / Zoom - this.dy));
                            if (CurrentCP != null && _shapes.selectedObj is Line)
                            {
                                Line connector = _shapes.selectedObj as Line;
                                if (connector.FromCP == CurrentCP)
                                    connector.MoveFrom = true;
                                else
                                    connector.MoveFrom = false;
                                connector.Moving = true;
                            }
                            CurrentStatus = DrawingStatus.dsResizeShape;
                        }
                        else
                        {
                            CurrentStatus = DrawingStatus.dsSelectRect;
                        }
                        break;
                    case ToolType.ttLine:
                        if (CurrentCP != null)
                        {
                            FromCP = CurrentCP;
                            CurrentStatus = DrawingStatus.dsDrawRect;
                        }
                        else if (hoverShape != null)
                        {
                            FromCP = hoverShape.ConnectionPoint;
                            CurrentStatus = DrawingStatus.dsDrawRect;
                        }
                        break;
                    default:
                        CurrentStatus = DrawingStatus.dsDrawRect;
                        break;
                }
                #endregion
                }
                break;
            case MouseButtons.Right:
                {
                    if (CurrentTool == ToolType.ttHandMove)
                    {
                        this.startDX = this.dx;
                        this.startDY = this.dy;
                        this.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        _shapes.click(startX, startY);
                        SelectedChanged();
                    }
                }
                break;
            }
        }

        private void DrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            hoverShape = _shapes.GetHoverShape((int)(e.X / Zoom) - this.dx, (int)(e.Y / Zoom - this.dy));
            if (e.Button == MouseButtons.Left)
            {
                if (this.MouseSx)
                {    
                    tempX = (int)(e.X / Zoom );
                    tempY = (int)(e.Y / Zoom );
                    if (bStickToGrid & this.gridSize > 0)
                    {
                        tempX = this.gridSize * (int)((e.X / Zoom ) / this.gridSize);
                        tempY = this.gridSize * (int)((e.Y / Zoom ) / this.gridSize);
                    }
                    tempX = tempX - this.dx;
                    tempY = tempY - this.dy;

                }

                if (this.CurrentStatus ==  DrawingStatus.dsResizeShape)
                {
                    int tmpX = (int)(e.X / Zoom - this.dx);
                    int tmpY = (int)(e.Y / Zoom - this.dy);
                    int tmpstartX = startX;
                    int tmpstartY = startY;
                    if (bStickToGrid & this.gridSize > 0)
                    {
                        tmpX = this.gridSize * (int)((e.X / Zoom - this.dx) / this.gridSize);
                        tmpY = this.gridSize * (int)((e.Y / Zoom - this.dy) / this.gridSize);
                        tmpstartX = this.gridSize * (int)(startX / this.gridSize);
                        tmpstartY = this.gridSize * (int)(startY / this.gridSize);
                        _shapes.Fit2grid(this.gridSize);
                        _shapes.sRec.Fit2grid(this.gridSize);
                    }

                    switch (this.InteractionType)
                    {
                        case InteractionType.itSelect:
                            if (_shapes.selectedObj != null & _shapes.sRec != null)
                            {
                                 _shapes.move(tmpstartX - tmpX, tmpstartY - tmpY);

                                 _shapes.sRec.move(tmpstartX - tmpX, tmpstartY - tmpY);
                            }
                            break;
                        case InteractionType.itRotate:
                            if (_shapes.selectedObj != null & _shapes.sRec != null)
                            {
                                _shapes.selectedObj.Rotate(tmpX, tmpY);
                                _shapes.sRec.Rotate(tmpX, tmpY);
                            }
                            break;
                        default:
                            if (_shapes.selectedObj != null & _shapes.sRec != null)
                            {
                                _shapes.selectedObj.redim(tmpX - tmpstartX, tmpY - tmpstartY, this.InteractionType);
                                _shapes.sRec.redim(tmpX - tmpstartX, tmpY - tmpstartY, this.InteractionType);
                            }
                            break;
                    }

                }
                redraw(false);
            }
            else
                if (e.Button == MouseButtons.Right)
                {
                    if (CurrentTool == ToolType.ttHandMove)
                    {
                        int newDx = (this.startDX + this.truestartX - e.X);
                        int newDy = (this.startDY + this.truestartY - e.Y);
                        if (bStickToGrid & this.gridSize > 0)
                        {
                            newDx = this.gridSize * (int)((newDx) / this.gridSize);
                            newDy = this.gridSize * (int)((newDy) / this.gridSize);
                        }
                        if (newDx > 0)
                            newDx = 0;
                        if (newDy > 0)
                            newDy = 0;
                        dx = newDx;
                        dy = newDy;
                        if (VerticalScroll.Visible)
                            VerticalScroll.Value = -newDy;
                        if (HorizontalScroll.Visible)
                            HorizontalScroll.Value = -newDx;
                        this.redraw(true);
                    }
                }
                else
                {
                    if (CurrentTool == ToolType.ttSelect)
                    {
                        if (this._shapes.sRec != null)
                        {
                            InteractionType PointType = this._shapes.isOver((int)(e.X / Zoom) - this.dx, (int)(e.Y / Zoom - this.dy));
                            this.InteractionType = PointType;

                            switch (PointType)
                            {
                                case InteractionType.itRotate:
                                    this.Cursor = Cursors.SizeAll;
                                    break;
                                case InteractionType.itSelect:
                                    this.Cursor = Cursors.Hand;
                                    break;
                                case InteractionType.itResizeTopLeft:
                                    this.Cursor = Cursors.SizeNWSE;
                                    break;
                                case InteractionType.itResizeTop:
                                    this.Cursor = Cursors.SizeNS;
                                    break;
                                case InteractionType.itResizeTopRight:
                                    this.Cursor = Cursors.SizeNESW;
                                    break;
                                case InteractionType.itResizeRight:
                                    this.Cursor = Cursors.SizeWE;
                                    break;
                                case InteractionType.itResizeBottomRight:
                                    this.Cursor = Cursors.SizeNWSE;
                                    break;
                                case InteractionType.itResizeBottom:
                                    this.Cursor = Cursors.SizeNS;
                                    break;
                                case InteractionType.itResizeBottomLeft:
                                    this.Cursor = Cursors.SizeNESW;
                                    break;
                                case InteractionType.itResizeLeft:
                                    this.Cursor = Cursors.SizeWE;
                                    break;
                                default:
                                    this.Cursor = Cursors.Default;
                                    InteractionType = InteractionType.itNone;
                                    break;
                            }
                        }
                        else 
                        {
                            this.Cursor = Cursors.Default;
                            InteractionType = InteractionType.itNone;
                        }
                    }
                    else if (CurrentTool == ToolType.ttLine)
                    {
                        CurrentCP = this._shapes.GetConnectionPoint((int)(e.X / Zoom) - this.dx, (int)(e.Y / Zoom - this.dy));                  
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        InteractionType = InteractionType.itNone;
                    }
            }
        }

        private void DrawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            #region left up
            {
                int tmpX = (int)((e.X) / Zoom - this.dx);
                int tmpY = (int)((e.Y) / Zoom - this.dy);
                if (bStickToGrid & this.gridSize > 0)
                {
                    tmpX = this.gridSize * (int)((e.X / Zoom - this.dx )/ this.gridSize);
                    tmpY = this.gridSize * (int)((e.Y / Zoom  - this.dy)/ this.gridSize);
                }

                switch (CurrentTool)
                {
                    case ToolType.ttSelect:
                        if (this.CurrentStatus != DrawingStatus.dsResizeShape)
                        {
                            this._shapes.click((int)((e.X) / Zoom - this.dx), (int)((e.Y) / Zoom - this.dy));
                        }
                        if (this.CurrentStatus == DrawingStatus.dsSelectRect)
                        {
                            int startX = this.startX;
                            int endX = (int)((e.X) / Zoom) - this.dx;
                            if (startX > endX)
                            {
                                startX = this.tempX;
                                endX = this.startX;
                            }
                            int startY = this.startY;
                            int endY = (int)((e.Y) / Zoom) - this.dy;
                            if (startY > endY)
                            {
                                startY = this.tempY;
                                endY = this.startY;
                            }
                            if (((endX - startX) + (endY  - startY)) > 12)
                            {
                                this._shapes.multiSelect(startX, startY, endX, endY);
                            }
                        }

                        CurrentStatus = DrawingStatus.dsNone;
                        break;
                    case ToolType.ttImageBox: 
                        if (this.CurrentStatus == DrawingStatus.dsDrawRect)
                        {
                            string f_name = this.imgLoader();
                            this._shapes.addImgBox(startX, startY, tmpX, tmpY, f_name, this.CreationPenColor, CreationPenWidth);
                            changeTool(ToolType.ttSelect);
                        }
                        break;
                    case ToolType.ttLine:
                        if (this.CurrentStatus == DrawingStatus.dsDrawRect)
                        {
                            CConnectionPoint ToCP = _shapes.GetConnectionPoint((int)(e.X / Zoom) - this.dx, (int)(e.Y / Zoom - this.dy));
                            if (ToCP == null && hoverShape != null)
                                ToCP = hoverShape.ConnectionPoint;

                            if (ToCP != null && ToCP != FromCP)
                            {
                                BeforeAddLineEventArgs args = new BeforeAddLineEventArgs(FromCP, ToCP);
                                beforeAddLine(this, args);
                                if (!args.cancel)
                                    this._shapes.addConnector(FromCP, ToCP, CreationPenColor, CreationPenWidth);
                            }
                            CurrentStatus = DrawingStatus.dsNone;
                        }
                        break;
                    default:
                        CurrentStatus = DrawingStatus.dsNone;
                        break;
                }

                if (_shapes.selectedObj != null)
                {
                    if (InteractionType != InteractionType.itNone)
                    {
                        _shapes.endMove();
                    }

                    if (_shapes.selectedObj is Line)
                    {
                        Line connector = _shapes.selectedObj as Line;
                        CConnectionPoint CP = _shapes.GetConnectionPoint((int)(e.X / Zoom) - this.dx, (int)(e.Y / Zoom - this.dy));
                        if (CP == null && hoverShape != null)
                            CP = hoverShape.ConnectionPoint;
                        if (connector.Moving)
                        {
                            if (CP == null)
                                Undo();
                            else
                            {
                                bool bChanged = false;
                                bool bChangedFromCP = false;
                                if (connector.MoveFrom && _shapes.GetLine(connector.ToCP.Owner, CP.Owner) == null)
                                {
                                    bChanged = true;
                                    bChangedFromCP = true;
                                    connector.FromCP = CP;
                                }
                                else if (!connector.MoveFrom && connector.ToCP != CP && _shapes.GetLine(connector.FromCP.Owner, CP.Owner) == null)
                                {
                                    bChanged = true;
                                    connector.ToCP = CP;
                                }
                                else
                                    Undo();
                                if (bChanged)
                                {
                                    OnLineCPChangedEventArgs args = new OnLineCPChangedEventArgs(connector, bChangedFromCP);
                                    onLineCPChanged(this, args);
                                }
                            }
                            _shapes.deSelect();
                        }
                        connector.Moving = false;
                    }
                    if (_shapes.sRec != null)
                    {
                        _shapes.sRec.endMoveRedim();
                    }
                }
                SelectedChanged();

                this.MouseSx = false;
            }
            #endregion
            else
            {
                //SelectedChanged();
            }
        }

        #endregion

        public void propertyChanged()
        {
            this._shapes.Propertychanged();
        }


        private void DrawingPanel_Resize(object sender, EventArgs e)
        {
            if (this.Width>0 & this.Height>0)
            {
                offScreenBackBmp = new Bitmap(this.Width, this.Height);
                offScreenBmp = new Bitmap(this.Width, this.Height);
                if (!VerticalScroll.Enabled)
                    dy = 0;
                else
                    dy = -VerticalScroll.Value;
                if (!HorizontalScroll.Enabled)
                    dx = 0;
                else
                    dx = -HorizontalScroll.Value;
                this.redraw(true);
            }
        }

        private void DrawingPanel_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                if (_dx != -e.NewValue)
                {
                    _dx = -e.NewValue;
                        redraw(true);
                }
            }
            else
            {
                if (_dy != -e.NewValue)
                {
                    _dy = -e.NewValue;
                    redraw(true);
                }
            }
        }

        private void DrawingPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_shapes.selectedObj != null)
            {
                if (_shapes.selectedObj is ImgBox)
                {
                    ImgBox obj = _shapes.selectedObj as ImgBox;
                    _edit.Edit(obj);
                }
            }
        }
    }
}
