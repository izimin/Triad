namespace TriadNSim.Forms
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Workstation",
            ""}, 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Server", 2);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Router", 3);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Custom", 1);
            this.MainToolBar = new System.Windows.Forms.ToolStrip();
            this.toolStripbtnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripbtnSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtnLink = new System.Windows.Forms.ToolStripButton();
            this.toolStripcmbZoom = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCalcStaticProp = new System.Windows.Forms.ToolStripButton();
            this.btnDefine = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tstModelTime = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripbtnRun = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtnGraphConst = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.drawingPanel1 = new DrawingPanel.DrawingPanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miNew = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.miSave = new System.Windows.Forms.ToolStripMenuItem();
            this.miSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.miPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miModel = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.messageQueue1 = new System.Messaging.MessageQueue();
            this.MainToolBar.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainToolBar
            // 
            this.MainToolBar.Dock = System.Windows.Forms.DockStyle.None;
            this.MainToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripbtnNew,
            this.toolStripbtnOpen,
            this.toolStripbtnSave,
            this.toolStripSeparator1,
            this.toolStripbtnSelect,
            this.toolStripbtnLink,
            this.toolStripcmbZoom,
            this.toolStripSeparator2,
            this.tsbCalcStaticProp,
            this.btnDefine,
            this.toolStripButton2,
            this.tstModelTime,
            this.toolStripbtnRun,
            this.toolStripSeparator8,
            this.toolStripButton1,
            this.toolStripButton3,
            this.toolStripbtnGraphConst});
            this.MainToolBar.Location = new System.Drawing.Point(3, 24);
            this.MainToolBar.Name = "MainToolBar";
            this.MainToolBar.Size = new System.Drawing.Size(490, 25);
            this.MainToolBar.TabIndex = 2;
            this.MainToolBar.Text = "toolStrip1";
            // 
            // toolStripbtnNew
            // 
            this.toolStripbtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnNew.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtnNew.Image")));
            this.toolStripbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnNew.Name = "toolStripbtnNew";
            this.toolStripbtnNew.Size = new System.Drawing.Size(23, 22);
            this.toolStripbtnNew.Text = "Создать";
            this.toolStripbtnNew.Click += new System.EventHandler(this.toolStripbtnNew_Click);
            // 
            // toolStripbtnOpen
            // 
            this.toolStripbtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtnOpen.Image")));
            this.toolStripbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnOpen.Name = "toolStripbtnOpen";
            this.toolStripbtnOpen.Size = new System.Drawing.Size(23, 22);
            this.toolStripbtnOpen.Text = "Открыть";
            this.toolStripbtnOpen.Click += new System.EventHandler(this.toolStripbtnOpen_Click);
            // 
            // toolStripbtnSave
            // 
            this.toolStripbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtnSave.Image")));
            this.toolStripbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnSave.Name = "toolStripbtnSave";
            this.toolStripbtnSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripbtnSave.Text = "Сохранить";
            this.toolStripbtnSave.Click += new System.EventHandler(this.toolStripbtnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripbtnSelect
            // 
            this.toolStripbtnSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnSelect.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtnSelect.Image")));
            this.toolStripbtnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnSelect.Name = "toolStripbtnSelect";
            this.toolStripbtnSelect.Size = new System.Drawing.Size(23, 22);
            this.toolStripbtnSelect.Text = "Выделение";
            this.toolStripbtnSelect.Click += new System.EventHandler(this.toolStripbtnSelect_Click);
            // 
            // toolStripbtnLink
            // 
            this.toolStripbtnLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnLink.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtnLink.Image")));
            this.toolStripbtnLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnLink.Name = "toolStripbtnLink";
            this.toolStripbtnLink.Size = new System.Drawing.Size(23, 22);
            this.toolStripbtnLink.Text = "Соединить";
            this.toolStripbtnLink.Click += new System.EventHandler(this.toolStripbtnLink_Click);
            // 
            // toolStripcmbZoom
            // 
            this.toolStripcmbZoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolStripcmbZoom.Items.AddRange(new object[] {
            "25%",
            "50%",
            "75%",
            "100%",
            "150%",
            "200%",
            "500%"});
            this.toolStripcmbZoom.Name = "toolStripcmbZoom";
            this.toolStripcmbZoom.Size = new System.Drawing.Size(121, 25);
            this.toolStripcmbZoom.ToolTipText = "Масштаб";
            this.toolStripcmbZoom.SelectedIndexChanged += new System.EventHandler(this.toolStripcmbZoom_SelectedIndexChanged);
            this.toolStripcmbZoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripcmbZoom_KeyDown);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbCalcStaticProp
            // 
            this.tsbCalcStaticProp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCalcStaticProp.Image = ((System.Drawing.Image)(resources.GetObject("tsbCalcStaticProp.Image")));
            this.tsbCalcStaticProp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCalcStaticProp.Name = "tsbCalcStaticProp";
            this.tsbCalcStaticProp.Size = new System.Drawing.Size(23, 22);
            this.tsbCalcStaticProp.Text = "Вычислить статические характеристики";
            this.tsbCalcStaticProp.Click += new System.EventHandler(this.tsbCalcStaticProp_Click);
            // 
            // btnDefine
            // 
            this.btnDefine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDefine.Image = global::TriadNSim.Properties.Resources.define;
            this.btnDefine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDefine.Name = "btnDefine";
            this.btnDefine.Size = new System.Drawing.Size(23, 22);
            this.btnDefine.Text = "Доопределить";
            this.btnDefine.Click += new System.EventHandler(this.btnDefine_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::TriadNSim.Properties.Resources.reset;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Сбросить поведение";
            this.toolStripButton2.ToolTipText = "Сбросить поведение всех элементов";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // tstModelTime
            // 
            this.tstModelTime.Name = "tstModelTime";
            this.tstModelTime.Size = new System.Drawing.Size(50, 25);
            this.tstModelTime.Text = "100";
            this.tstModelTime.ToolTipText = "Конечное время моделирования";
            // 
            // toolStripbtnRun
            // 
            this.toolStripbtnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnRun.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.toolStripbtnRun.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtnRun.Image")));
            this.toolStripbtnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnRun.Name = "toolStripbtnRun";
            this.toolStripbtnRun.Size = new System.Drawing.Size(32, 22);
            this.toolStripbtnRun.Text = "Моделировать";
            this.toolStripbtnRun.ButtonClick += new System.EventHandler(this.toolStripbtnRun_Click);
            this.toolStripbtnRun.DropDownOpening += new System.EventHandler(this.toolStripbtnRun_DropDownOpening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(260, 22);
            this.toolStripMenuItem1.Text = "Выбрать условия моделирования";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::TriadNSim.Properties.Resources.Spy;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Информационные процедуры";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::TriadNSim.Properties.Resources.simc;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Условия моделироавния";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripbtnGraphConst
            // 
            this.toolStripbtnGraphConst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnGraphConst.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtnGraphConst.Image")));
            this.toolStripbtnGraphConst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnGraphConst.Name = "toolStripbtnGraphConst";
            this.toolStripbtnGraphConst.Size = new System.Drawing.Size(23, 22);
            this.toolStripbtnGraphConst.Text = "Добавить графовую константу";
            this.toolStripbtnGraphConst.Click += new System.EventHandler(this.toolStripbtnGraphConst_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "FileNew");
            this.imageList1.Images.SetKeyName(1, "FileOpen");
            this.imageList1.Images.SetKeyName(2, "FileSave");
            this.imageList1.Images.SetKeyName(3, "Run");
            this.imageList1.Images.SetKeyName(4, "Spy.bmp");
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(566, 253);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(566, 302);
            this.toolStripContainer1.TabIndex = 4;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.MainMenu);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.MainToolBar);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.drawingPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Size = new System.Drawing.Size(566, 253);
            this.splitContainer1.SplitterDistance = 215;
            this.splitContainer1.TabIndex = 4;
            // 
            // drawingPanel1
            // 
            this.drawingPanel1.A4 = false;
            this.drawingPanel1.AllowDrop = true;
            this.drawingPanel1.AutoScroll = true;
            this.drawingPanel1.AutoScrollMinSize = new System.Drawing.Size(1024, 768);
            this.drawingPanel1.AutoSize = true;
            this.drawingPanel1.BackColor = System.Drawing.Color.White;
            this.drawingPanel1.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.Default;
            this.drawingPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPanel1.dx = 0;
            this.drawingPanel1.dy = 0;
            this.drawingPanel1.gridSize = 20;
            this.drawingPanel1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.drawingPanel1.Location = new System.Drawing.Point(0, 0);
            this.drawingPanel1.Name = "drawingPanel1";
            this.drawingPanel1.Size = new System.Drawing.Size(566, 215);
            this.drawingPanel1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.drawingPanel1.StickToGrid = false;
            this.drawingPanel1.TabIndex = 3;
            this.drawingPanel1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.drawingPanel1.Zoom = 1F;
            this.drawingPanel1.objectSelected += new DrawingPanel.ObjectSelected(this.drawingPanel1_objectSelected);
            this.drawingPanel1.objectDeleted += new DrawingPanel.ObjectDeleted(this.drawingPanel1_objectDeleted);
            this.drawingPanel1.beforeAddLine += new DrawingPanel.BeforeAddLine(this.drawingPanel1_beforeAddLine);
            this.drawingPanel1.onLineCPChanged += new DrawingPanel.OnLineCPChanged(this.drawingPanel1_onLineCPChanged);
            this.drawingPanel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.drawingPanel1_DragDrop);
            this.drawingPanel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.drawingPanel1_DragEnter);
            this.drawingPanel1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.drawingPanel1_MouseDoubleClick);
            this.drawingPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingPanel1_MouseUp);
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewItem1.Tag = "Client";
            listViewItem2.Tag = "Server";
            listViewItem4.Tag = "UserObj";
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.listView1.LargeImageList = this.imageList2;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(566, 34);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DragOver += new System.Windows.Forms.DragEventHandler(this.listView1_DragOver);
            this.listView1.MouseLeave += new System.EventHandler(this.listView1_MouseLeave);
            this.listView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseMove);
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "comp.png");
            this.imageList2.Images.SetKeyName(1, "question.png");
            this.imageList2.Images.SetKeyName(2, "server.png");
            this.imageList2.Images.SetKeyName(3, "router.png");
            // 
            // MainMenu
            // 
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miEdit,
            this.miModel,
            this.miHelp});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(566, 24);
            this.MainMenu.TabIndex = 5;
            this.MainMenu.Text = "MainMenu";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNew,
            this.miOpen,
            this.toolStripSeparator,
            this.miSave,
            this.miSaveAs,
            this.toolStripSeparator3,
            this.miPrint,
            this.miPrintPreview,
            this.toolStripSeparator4,
            this.miExit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(40, 20);
            this.miFile.Text = "&FILE";
            // 
            // miNew
            // 
            this.miNew.Image = ((System.Drawing.Image)(resources.GetObject("miNew.Image")));
            this.miNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miNew.Name = "miNew";
            this.miNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.miNew.Size = new System.Drawing.Size(233, 22);
            this.miNew.Text = "&Новый";
            // 
            // miOpen
            // 
            this.miOpen.Image = ((System.Drawing.Image)(resources.GetObject("miOpen.Image")));
            this.miOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miOpen.Name = "miOpen";
            this.miOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.miOpen.Size = new System.Drawing.Size(233, 22);
            this.miOpen.Text = "&Открыть";
            this.miOpen.Click += new System.EventHandler(this.miOpen_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(230, 6);
            // 
            // miSave
            // 
            this.miSave.Image = ((System.Drawing.Image)(resources.GetObject("miSave.Image")));
            this.miSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miSave.Name = "miSave";
            this.miSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.miSave.Size = new System.Drawing.Size(233, 22);
            this.miSave.Text = "&Сохранить";
            this.miSave.Click += new System.EventHandler(this.miSave_Click);
            // 
            // miSaveAs
            // 
            this.miSaveAs.Name = "miSaveAs";
            this.miSaveAs.Size = new System.Drawing.Size(233, 22);
            this.miSaveAs.Text = "Сохранить &как...";
            this.miSaveAs.Click += new System.EventHandler(this.miSaveAs_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(230, 6);
            // 
            // miPrint
            // 
            this.miPrint.Image = ((System.Drawing.Image)(resources.GetObject("miPrint.Image")));
            this.miPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miPrint.Name = "miPrint";
            this.miPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.miPrint.Size = new System.Drawing.Size(233, 22);
            this.miPrint.Text = "&Печать";
            // 
            // miPrintPreview
            // 
            this.miPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("miPrintPreview.Image")));
            this.miPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miPrintPreview.Name = "miPrintPreview";
            this.miPrintPreview.Size = new System.Drawing.Size(233, 22);
            this.miPrintPreview.Text = "П&редварительный просмотр";
            this.miPrintPreview.Click += new System.EventHandler(this.miPrintPreview_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(230, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(233, 22);
            this.miExit.Text = "&Выход";
            // 
            // miEdit
            // 
            this.miEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator5,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator6,
            this.selectAllToolStripMenuItem});
            this.miEdit.Name = "miEdit";
            this.miEdit.Size = new System.Drawing.Size(43, 20);
            this.miEdit.Text = "&EDIT";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.undoToolStripMenuItem.Text = "&Отменить";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.redoToolStripMenuItem.Text = "&Повторить";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(178, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.cutToolStripMenuItem.Text = "&Вырезать";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.copyToolStripMenuItem.Text = "&Копировать";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.pasteToolStripMenuItem.Text = "В&ставить";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(178, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.selectAllToolStripMenuItem.Text = "Вы&делить все";
            // 
            // miModel
            // 
            this.miModel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.miModel.Name = "miModel";
            this.miModel.Size = new System.Drawing.Size(59, 20);
            this.miModel.Text = "&MODEL";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // miHelp
            // 
            this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAbout});
            this.miHelp.Name = "miHelp";
            this.miHelp.Size = new System.Drawing.Size(47, 20);
            this.miHelp.Text = "&HELP";
            this.miHelp.Click += new System.EventHandler(this.miHelp_Click);
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(158, 22);
            this.miAbout.Text = "&О программе...";
            // 
            // messageQueue1
            // 
            this.messageQueue1.MessageReadPropertyFilter.LookupId = true;
            this.messageQueue1.SynchronizingObject = this;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(566, 302);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "frmMain";
            this.Text = "TriadNS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MainToolBar.ResumeLayout(false);
            this.MainToolBar.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip MainToolBar;
        private System.Windows.Forms.ToolStripComboBox toolStripcmbZoom;
        private DrawingPanel.DrawingPanel drawingPanel1;
        private System.Windows.Forms.ToolStripButton toolStripbtnLink;
        private System.Windows.Forms.ToolStripButton toolStripbtnSelect;
        private System.Windows.Forms.ToolStripButton toolStripbtnNew;
        private System.Windows.Forms.ToolStripButton toolStripbtnOpen;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton toolStripbtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbCalcStaticProp;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miNew;
        private System.Windows.Forms.ToolStripMenuItem miOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem miSave;
        private System.Windows.Forms.ToolStripMenuItem miSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem miPrint;
        private System.Windows.Forms.ToolStripMenuItem miPrintPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miModel;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripTextBox tstModelTime;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSplitButton toolStripbtnRun;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton btnDefine;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Messaging.MessageQueue messageQueue1;
        private System.Windows.Forms.ToolStripButton toolStripbtnGraphConst;
    }
}

