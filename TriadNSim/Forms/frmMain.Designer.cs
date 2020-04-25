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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsTop = new System.Windows.Forms.ToolStrip();
            this.toolStripbtnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCalcStaticProp = new System.Windows.Forms.ToolStripButton();
            this.btnDefine = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripbtnGraphConst = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnGraphs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tsBottom = new System.Windows.Forms.ToolStrip();
            this.tsBtnShowElems = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripcmbZoom = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.scDraw = new System.Windows.Forms.SplitContainer();
            this.dpMain = new DrawingPanel.DrawingPanel();
            this.lvElems = new System.Windows.Forms.ListView();
            this.imgListNetworkItems = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPeople = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.ClmnNameUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnUrlUser = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUserInfo = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dgvCommunity = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnLincCommunity = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnLoadLogUsers = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnLoadOntologyUsers = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnMakeNetwork = new Bunifu.Framework.UI.BunifuFlatButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripbtnSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtnLink = new System.Windows.Forms.ToolStripButton();
            this.tsRiht = new System.Windows.Forms.ToolStrip();
            this.tsBtnSimSetting = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tstModelTime = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripbtnRun = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbMain1 = new Bunifu.Framework.UI.BunifuProgressBar();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDrag = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnMaximize = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnMinimize = new Bunifu.Framework.UI.BunifuTileButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.ofdLoadOwl = new System.Windows.Forms.OpenFileDialog();
            this.ofdLoadXes = new System.Windows.Forms.OpenFileDialog();
            this.tsTop.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer1.RightToolStripPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tsBottom.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scDraw)).BeginInit();
            this.scDraw.Panel1.SuspendLayout();
            this.scDraw.Panel2.SuspendLayout();
            this.scDraw.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunity)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.tsRiht.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tsTop
            // 
            this.tsTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tsTop.Dock = System.Windows.Forms.DockStyle.None;
            this.tsTop.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.tsTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripbtnNew,
            this.toolStripbtnOpen,
            this.toolStripbtnSave,
            this.toolStripSeparator1,
            this.tsbCalcStaticProp,
            this.btnDefine,
            this.toolStripButton2,
            this.toolStripSeparator12,
            this.toolStripButton1,
            this.toolStripButton3,
            this.toolStripSeparator11,
            this.toolStripbtnGraphConst,
            this.toolStripBtnGraphs,
            this.toolStripSeparator10});
            this.tsTop.Location = new System.Drawing.Point(3, 32);
            this.tsTop.Name = "tsTop";
            this.tsTop.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsTop.Size = new System.Drawing.Size(396, 32);
            this.tsTop.TabIndex = 2;
            this.tsTop.Text = "toolStrip1";
            // 
            // toolStripbtnNew
            // 
            this.toolStripbtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnNew.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtnNew.Image")));
            this.toolStripbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnNew.Name = "toolStripbtnNew";
            this.toolStripbtnNew.Size = new System.Drawing.Size(29, 29);
            this.toolStripbtnNew.Text = "Создать";
            this.toolStripbtnNew.Click += new System.EventHandler(this.toolStripbtnNew_Click);
            // 
            // toolStripbtnOpen
            // 
            this.toolStripbtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtnOpen.Image")));
            this.toolStripbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnOpen.Name = "toolStripbtnOpen";
            this.toolStripbtnOpen.Size = new System.Drawing.Size(29, 29);
            this.toolStripbtnOpen.Text = "Открыть";
            this.toolStripbtnOpen.Click += new System.EventHandler(this.toolStripbtnOpen_Click);
            // 
            // toolStripbtnSave
            // 
            this.toolStripbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtnSave.Image")));
            this.toolStripbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnSave.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.toolStripbtnSave.Name = "toolStripbtnSave";
            this.toolStripbtnSave.Size = new System.Drawing.Size(29, 29);
            this.toolStripbtnSave.Text = "Сохранить";
            this.toolStripbtnSave.Click += new System.EventHandler(this.toolStripbtnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // tsbCalcStaticProp
            // 
            this.tsbCalcStaticProp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCalcStaticProp.Image = ((System.Drawing.Image)(resources.GetObject("tsbCalcStaticProp.Image")));
            this.tsbCalcStaticProp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCalcStaticProp.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.tsbCalcStaticProp.Name = "tsbCalcStaticProp";
            this.tsbCalcStaticProp.Size = new System.Drawing.Size(29, 29);
            this.tsbCalcStaticProp.Text = "Вычислить статические характеристики";
            this.tsbCalcStaticProp.Click += new System.EventHandler(this.tsbCalcStaticProp_Click);
            // 
            // btnDefine
            // 
            this.btnDefine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDefine.Image = global::TriadNSim.Properties.Resources.define;
            this.btnDefine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDefine.Name = "btnDefine";
            this.btnDefine.Size = new System.Drawing.Size(29, 29);
            this.btnDefine.Text = "Доопределить";
            this.btnDefine.Click += new System.EventHandler(this.btnDefine_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::TriadNSim.Properties.Resources.reset;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton2.Text = "Сбросить поведение";
            this.toolStripButton2.ToolTipText = "Сбросить поведение всех элементов";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::TriadNSim.Properties.Resources.Spy;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton1.Text = "Информационные процедуры";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::TriadNSim.Properties.Resources.simc;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton3.Text = "Условия моделироавния";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripbtnGraphConst
            // 
            this.toolStripbtnGraphConst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnGraphConst.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtnGraphConst.Image")));
            this.toolStripbtnGraphConst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnGraphConst.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripbtnGraphConst.Name = "toolStripbtnGraphConst";
            this.toolStripbtnGraphConst.Size = new System.Drawing.Size(29, 29);
            this.toolStripbtnGraphConst.Text = "Добавить графовую константу";
            this.toolStripbtnGraphConst.Click += new System.EventHandler(this.toolStripbtnGraphConst_Click);
            // 
            // toolStripBtnGraphs
            // 
            this.toolStripBtnGraphs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnGraphs.Image = global::TriadNSim.Properties.Resources.graphs1;
            this.toolStripBtnGraphs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnGraphs.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.toolStripBtnGraphs.Name = "toolStripBtnGraphs";
            this.toolStripBtnGraphs.Size = new System.Drawing.Size(29, 29);
            this.toolStripBtnGraphs.Text = "Построить граф";
            this.toolStripBtnGraphs.Click += new System.EventHandler(this.toolStripBtnGraphs_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 32);
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
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.tsBottom);
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStrip3);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer3);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1194, 567);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.toolStrip2);
            this.toolStripContainer1.Location = new System.Drawing.Point(3, 33);
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            this.toolStripContainer1.RightToolStripPanel.Controls.Add(this.tsRiht);
            this.toolStripContainer1.Size = new System.Drawing.Size(1242, 656);
            this.toolStripContainer1.TabIndex = 4;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.Color.Transparent;
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsTop);
            // 
            // tsBottom
            // 
            this.tsBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tsBottom.Dock = System.Windows.Forms.DockStyle.None;
            this.tsBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnShowElems,
            this.toolStripSeparator7});
            this.tsBottom.Location = new System.Drawing.Point(24, 0);
            this.tsBottom.Name = "tsBottom";
            this.tsBottom.Size = new System.Drawing.Size(130, 25);
            this.tsBottom.TabIndex = 0;
            // 
            // tsBtnShowElems
            // 
            this.tsBtnShowElems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tsBtnShowElems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnShowElems.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnShowElems.Image")));
            this.tsBtnShowElems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnShowElems.Name = "tsBtnShowElems";
            this.tsBtnShowElems.Size = new System.Drawing.Size(112, 22);
            this.tsBtnShowElems.Text = "Элементы модели";
            this.tsBtnShowElems.Click += new System.EventHandler(this.tsBtnShowElems_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip3
            // 
            this.toolStrip3.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripcmbZoom,
            this.toolStripLabel1});
            this.toolStrip3.Location = new System.Drawing.Point(942, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip3.Size = new System.Drawing.Size(198, 25);
            this.toolStrip3.TabIndex = 1;
            // 
            // toolStripcmbZoom
            // 
            this.toolStripcmbZoom.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripcmbZoom.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripcmbZoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolStripcmbZoom.Items.AddRange(new object[] {
            "25%",
            "50%",
            "75%",
            "100%",
            "150%",
            "200%",
            "500%"});
            this.toolStripcmbZoom.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripcmbZoom.Name = "toolStripcmbZoom";
            this.toolStripcmbZoom.Size = new System.Drawing.Size(121, 25);
            this.toolStripcmbZoom.ToolTipText = "Масштаб";
            this.toolStripcmbZoom.SelectedIndexChanged += new System.EventHandler(this.toolStripcmbZoom_SelectedIndexChanged);
            this.toolStripcmbZoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripcmbZoom_KeyDown);
            this.toolStripcmbZoom.TextChanged += new System.EventHandler(this.toolStripcmbZoom_TextChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(65, 22);
            this.toolStripLabel1.Text = "Масштаб: ";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Panel1Collapsed = true;
            this.splitContainer3.Panel1MinSize = 0;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.scMain);
            this.splitContainer3.Size = new System.Drawing.Size(1194, 567);
            this.splitContainer3.SplitterDistance = 398;
            this.splitContainer3.TabIndex = 6;
            // 
            // scMain
            // 
            this.scMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.scDraw);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.scMain.Panel2.Controls.Add(this.tableLayoutPanel4);
            this.scMain.Panel2MinSize = 0;
            this.scMain.Size = new System.Drawing.Size(1194, 567);
            this.scMain.SplitterDistance = 919;
            this.scMain.TabIndex = 5;
            // 
            // scDraw
            // 
            this.scDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scDraw.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scDraw.Location = new System.Drawing.Point(0, 0);
            this.scDraw.Margin = new System.Windows.Forms.Padding(0);
            this.scDraw.Name = "scDraw";
            this.scDraw.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scDraw.Panel1
            // 
            this.scDraw.Panel1.Controls.Add(this.dpMain);
            // 
            // scDraw.Panel2
            // 
            this.scDraw.Panel2.AutoScroll = true;
            this.scDraw.Panel2.Controls.Add(this.lvElems);
            this.scDraw.Panel2MinSize = 90;
            this.scDraw.Size = new System.Drawing.Size(917, 565);
            this.scDraw.SplitterDistance = 471;
            this.scDraw.TabIndex = 4;
            // 
            // dpMain
            // 
            this.dpMain.A4 = false;
            this.dpMain.AllowDrop = true;
            this.dpMain.AutoScroll = true;
            this.dpMain.AutoScrollMinSize = new System.Drawing.Size(1024, 768);
            this.dpMain.AutoSize = true;
            this.dpMain.BackColor = System.Drawing.Color.White;
            this.dpMain.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.Default;
            this.dpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpMain.dx = 0;
            this.dpMain.dy = 0;
            this.dpMain.gridSize = 20;
            this.dpMain.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.dpMain.Location = new System.Drawing.Point(0, 0);
            this.dpMain.Margin = new System.Windows.Forms.Padding(0);
            this.dpMain.Name = "dpMain";
            this.dpMain.Size = new System.Drawing.Size(917, 471);
            this.dpMain.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.dpMain.StickToGrid = false;
            this.dpMain.TabIndex = 3;
            this.dpMain.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.dpMain.Zoom = 1F;
            this.dpMain.objectSelected += new DrawingPanel.ObjectSelected(this.drawingPanel1_objectSelected);
            this.dpMain.beforeAddLine += new DrawingPanel.BeforeAddLine(this.drawingPanel1_beforeAddLine);
            this.dpMain.onLineCPChanged += new DrawingPanel.OnLineCPChanged(this.drawingPanel1_onLineCPChanged);
            this.dpMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.drawingPanel1_DragDrop);
            this.dpMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.drawingPanel1_DragEnter);
            this.dpMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.drawingPanel1_MouseDoubleClick);
            this.dpMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingPanel1_MouseUp);
            this.dpMain.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.drawingPanel1_MouseWheel);
            // 
            // lvElems
            // 
            this.lvElems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lvElems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvElems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvElems.HideSelection = false;
            listViewItem1.Tag = "Client";
            listViewItem2.Tag = "Server";
            listViewItem4.Tag = "UserObj";
            this.lvElems.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.lvElems.LargeImageList = this.imgListNetworkItems;
            this.lvElems.Location = new System.Drawing.Point(0, 0);
            this.lvElems.Margin = new System.Windows.Forms.Padding(0);
            this.lvElems.MultiSelect = false;
            this.lvElems.Name = "lvElems";
            this.lvElems.Size = new System.Drawing.Size(917, 90);
            this.lvElems.TabIndex = 5;
            this.lvElems.UseCompatibleStateImageBehavior = false;
            this.lvElems.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            this.lvElems.DragOver += new System.Windows.Forms.DragEventHandler(this.listView1_DragOver);
            this.lvElems.MouseLeave += new System.EventHandler(this.listView1_MouseLeave);
            this.lvElems.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseMove);
            this.lvElems.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
            // 
            // imgListNetworkItems
            // 
            this.imgListNetworkItems.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListNetworkItems.ImageStream")));
            this.imgListNetworkItems.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListNetworkItems.Images.SetKeyName(0, "comp.png");
            this.imgListNetworkItems.Images.SetKeyName(1, "question.png");
            this.imgListNetworkItems.Images.SetKeyName(2, "server.png");
            this.imgListNetworkItems.Images.SetKeyName(3, "router.png");
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.bunifuFlatButton1, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.btnLoadLogUsers, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnLoadOntologyUsers, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnMakeNetwork, 0, 3);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(269, 565);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.Silver;
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 5;
            this.bunifuFlatButton1.ButtonText = "Очистить сеть";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gainsboro;
            this.bunifuFlatButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuFlatButton1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton1.Iconimage")));
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 11;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 40D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(10, 524);
            this.bunifuFlatButton1.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.Silver;
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.Padding = new System.Windows.Forms.Padding(5);
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(249, 36);
            this.bunifuFlatButton1.TabIndex = 8;
            this.bunifuFlatButton1.Text = "Очистить сеть";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.Black;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.dgvPeople, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.btnUserInfo, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.dgvCommunity, 0, 4);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 104);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 5;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.84518F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.15483F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(263, 367);
            this.tableLayoutPanel5.TabIndex = 7;
            // 
            // dgvPeople
            // 
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPeople.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPeople.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPeople.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvPeople.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPeople.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPeople.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.ColumnHeadersVisible = false;
            this.dgvPeople.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmnNameUser,
            this.ClmnUrlUser});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPeople.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPeople.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPeople.DoubleBuffered = true;
            this.dgvPeople.EnableHeadersVisualStyles = false;
            this.dgvPeople.HeaderBgColor = System.Drawing.Color.LightGray;
            this.dgvPeople.HeaderForeColor = System.Drawing.Color.Black;
            this.dgvPeople.Location = new System.Drawing.Point(0, 18);
            this.dgvPeople.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.ReadOnly = true;
            this.dgvPeople.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPeople.RowHeadersVisible = false;
            this.dgvPeople.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeople.Size = new System.Drawing.Size(263, 179);
            this.dgvPeople.TabIndex = 6;
            // 
            // ClmnNameUser
            // 
            this.ClmnNameUser.HeaderText = "Имя";
            this.ClmnNameUser.Name = "ClmnNameUser";
            this.ClmnNameUser.ReadOnly = true;
            // 
            // ClmnUrlUser
            // 
            this.ClmnUrlUser.HeaderText = "Ссылка";
            this.ClmnUrlUser.Name = "ClmnUrlUser";
            this.ClmnUrlUser.ReadOnly = true;
            this.ClmnUrlUser.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClmnUrlUser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Список пользователей";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Список сообществ";
            // 
            // btnUserInfo
            // 
            this.btnUserInfo.Activecolor = System.Drawing.Color.Gray;
            this.btnUserInfo.BackColor = System.Drawing.Color.Silver;
            this.btnUserInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUserInfo.BorderRadius = 5;
            this.btnUserInfo.ButtonText = "Подробнее о пользователе";
            this.btnUserInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserInfo.DisabledColor = System.Drawing.Color.Gainsboro;
            this.btnUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUserInfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUserInfo.Iconcolor = System.Drawing.Color.Transparent;
            this.btnUserInfo.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnUserInfo.Iconimage")));
            this.btnUserInfo.Iconimage_right = null;
            this.btnUserInfo.Iconimage_right_Selected = null;
            this.btnUserInfo.Iconimage_Selected = null;
            this.btnUserInfo.IconMarginLeft = 0;
            this.btnUserInfo.IconMarginRight = 0;
            this.btnUserInfo.IconRightVisible = true;
            this.btnUserInfo.IconRightZoom = 0D;
            this.btnUserInfo.IconVisible = true;
            this.btnUserInfo.IconZoom = 40D;
            this.btnUserInfo.IsTab = false;
            this.btnUserInfo.Location = new System.Drawing.Point(10, 207);
            this.btnUserInfo.Margin = new System.Windows.Forms.Padding(10);
            this.btnUserInfo.Name = "btnUserInfo";
            this.btnUserInfo.Normalcolor = System.Drawing.Color.Silver;
            this.btnUserInfo.OnHovercolor = System.Drawing.Color.Gray;
            this.btnUserInfo.OnHoverTextColor = System.Drawing.Color.White;
            this.btnUserInfo.Padding = new System.Windows.Forms.Padding(5);
            this.btnUserInfo.selected = false;
            this.btnUserInfo.Size = new System.Drawing.Size(243, 35);
            this.btnUserInfo.TabIndex = 4;
            this.btnUserInfo.Text = "Подробнее о пользователе";
            this.btnUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUserInfo.Textcolor = System.Drawing.Color.Black;
            this.btnUserInfo.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserInfo.Click += new System.EventHandler(this.btnUserInfo_Click);
            // 
            // dgvCommunity
            // 
            this.dgvCommunity.AllowUserToAddRows = false;
            this.dgvCommunity.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCommunity.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCommunity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCommunity.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvCommunity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCommunity.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommunity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCommunity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommunity.ColumnHeadersVisible = false;
            this.dgvCommunity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.clmnLincCommunity});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCommunity.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCommunity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCommunity.DoubleBuffered = true;
            this.dgvCommunity.EnableHeadersVisualStyles = false;
            this.dgvCommunity.HeaderBgColor = System.Drawing.Color.LightGray;
            this.dgvCommunity.HeaderForeColor = System.Drawing.Color.Black;
            this.dgvCommunity.Location = new System.Drawing.Point(0, 272);
            this.dgvCommunity.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.dgvCommunity.Name = "dgvCommunity";
            this.dgvCommunity.ReadOnly = true;
            this.dgvCommunity.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCommunity.RowHeadersVisible = false;
            this.dgvCommunity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommunity.Size = new System.Drawing.Size(263, 95);
            this.dgvCommunity.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Название";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // clmnLincCommunity
            // 
            this.clmnLincCommunity.HeaderText = "Ссылка";
            this.clmnLincCommunity.Name = "clmnLincCommunity";
            this.clmnLincCommunity.ReadOnly = true;
            this.clmnLincCommunity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnLincCommunity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnLoadLogUsers
            // 
            this.btnLoadLogUsers.Activecolor = System.Drawing.Color.Gray;
            this.btnLoadLogUsers.BackColor = System.Drawing.Color.Silver;
            this.btnLoadLogUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadLogUsers.BorderRadius = 5;
            this.btnLoadLogUsers.ButtonText = "Загрузить логи с  поведением пользователей";
            this.btnLoadLogUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadLogUsers.DisabledColor = System.Drawing.Color.Gainsboro;
            this.btnLoadLogUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadLogUsers.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLoadLogUsers.Iconcolor = System.Drawing.Color.Transparent;
            this.btnLoadLogUsers.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnLoadLogUsers.Iconimage")));
            this.btnLoadLogUsers.Iconimage_right = null;
            this.btnLoadLogUsers.Iconimage_right_Selected = null;
            this.btnLoadLogUsers.Iconimage_Selected = null;
            this.btnLoadLogUsers.IconMarginLeft = 0;
            this.btnLoadLogUsers.IconMarginRight = 0;
            this.btnLoadLogUsers.IconRightVisible = true;
            this.btnLoadLogUsers.IconRightZoom = 0D;
            this.btnLoadLogUsers.IconVisible = true;
            this.btnLoadLogUsers.IconZoom = 40D;
            this.btnLoadLogUsers.IsTab = false;
            this.btnLoadLogUsers.Location = new System.Drawing.Point(10, 56);
            this.btnLoadLogUsers.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.btnLoadLogUsers.Name = "btnLoadLogUsers";
            this.btnLoadLogUsers.Normalcolor = System.Drawing.Color.Silver;
            this.btnLoadLogUsers.OnHovercolor = System.Drawing.Color.Gray;
            this.btnLoadLogUsers.OnHoverTextColor = System.Drawing.Color.White;
            this.btnLoadLogUsers.selected = false;
            this.btnLoadLogUsers.Size = new System.Drawing.Size(249, 35);
            this.btnLoadLogUsers.TabIndex = 3;
            this.btnLoadLogUsers.Text = "Загрузить логи с  поведением пользователей";
            this.btnLoadLogUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLoadLogUsers.Textcolor = System.Drawing.Color.Black;
            this.btnLoadLogUsers.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadLogUsers.Click += new System.EventHandler(this.btnLoadLogUsers_Click);
            // 
            // btnLoadOntologyUsers
            // 
            this.btnLoadOntologyUsers.Activecolor = System.Drawing.Color.Gray;
            this.btnLoadOntologyUsers.BackColor = System.Drawing.Color.Silver;
            this.btnLoadOntologyUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadOntologyUsers.BorderRadius = 5;
            this.btnLoadOntologyUsers.ButtonText = "Загрузить онтологию с  пользователями";
            this.btnLoadOntologyUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadOntologyUsers.DisabledColor = System.Drawing.Color.Gainsboro;
            this.btnLoadOntologyUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadOntologyUsers.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLoadOntologyUsers.Iconcolor = System.Drawing.Color.Transparent;
            this.btnLoadOntologyUsers.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnLoadOntologyUsers.Iconimage")));
            this.btnLoadOntologyUsers.Iconimage_right = null;
            this.btnLoadOntologyUsers.Iconimage_right_Selected = null;
            this.btnLoadOntologyUsers.Iconimage_Selected = null;
            this.btnLoadOntologyUsers.IconMarginLeft = 0;
            this.btnLoadOntologyUsers.IconMarginRight = 0;
            this.btnLoadOntologyUsers.IconRightVisible = true;
            this.btnLoadOntologyUsers.IconRightZoom = 0D;
            this.btnLoadOntologyUsers.IconVisible = true;
            this.btnLoadOntologyUsers.IconZoom = 40D;
            this.btnLoadOntologyUsers.IsTab = false;
            this.btnLoadOntologyUsers.Location = new System.Drawing.Point(10, 10);
            this.btnLoadOntologyUsers.Margin = new System.Windows.Forms.Padding(10);
            this.btnLoadOntologyUsers.Name = "btnLoadOntologyUsers";
            this.btnLoadOntologyUsers.Normalcolor = System.Drawing.Color.Silver;
            this.btnLoadOntologyUsers.OnHovercolor = System.Drawing.Color.Gray;
            this.btnLoadOntologyUsers.OnHoverTextColor = System.Drawing.Color.White;
            this.btnLoadOntologyUsers.selected = false;
            this.btnLoadOntologyUsers.Size = new System.Drawing.Size(249, 36);
            this.btnLoadOntologyUsers.TabIndex = 2;
            this.btnLoadOntologyUsers.Text = "Загрузить онтологию с  пользователями";
            this.btnLoadOntologyUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLoadOntologyUsers.Textcolor = System.Drawing.Color.Black;
            this.btnLoadOntologyUsers.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadOntologyUsers.Click += new System.EventHandler(this.btnLoadOntologyUsers_Click);
            // 
            // btnMakeNetwork
            // 
            this.btnMakeNetwork.Activecolor = System.Drawing.Color.Gray;
            this.btnMakeNetwork.BackColor = System.Drawing.Color.Silver;
            this.btnMakeNetwork.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMakeNetwork.BorderRadius = 5;
            this.btnMakeNetwork.ButtonText = "Построить сеть";
            this.btnMakeNetwork.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMakeNetwork.DisabledColor = System.Drawing.Color.Gainsboro;
            this.btnMakeNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMakeNetwork.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMakeNetwork.Iconcolor = System.Drawing.Color.Transparent;
            this.btnMakeNetwork.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnMakeNetwork.Iconimage")));
            this.btnMakeNetwork.Iconimage_right = null;
            this.btnMakeNetwork.Iconimage_right_Selected = null;
            this.btnMakeNetwork.Iconimage_Selected = null;
            this.btnMakeNetwork.IconMarginLeft = 11;
            this.btnMakeNetwork.IconMarginRight = 0;
            this.btnMakeNetwork.IconRightVisible = true;
            this.btnMakeNetwork.IconRightZoom = 0D;
            this.btnMakeNetwork.IconVisible = true;
            this.btnMakeNetwork.IconZoom = 40D;
            this.btnMakeNetwork.IsTab = false;
            this.btnMakeNetwork.Location = new System.Drawing.Point(10, 479);
            this.btnMakeNetwork.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btnMakeNetwork.Name = "btnMakeNetwork";
            this.btnMakeNetwork.Normalcolor = System.Drawing.Color.Silver;
            this.btnMakeNetwork.OnHovercolor = System.Drawing.Color.Gray;
            this.btnMakeNetwork.OnHoverTextColor = System.Drawing.Color.White;
            this.btnMakeNetwork.Padding = new System.Windows.Forms.Padding(5);
            this.btnMakeNetwork.selected = false;
            this.btnMakeNetwork.Size = new System.Drawing.Size(249, 35);
            this.btnMakeNetwork.TabIndex = 5;
            this.btnMakeNetwork.Text = "Построить сеть";
            this.btnMakeNetwork.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMakeNetwork.Textcolor = System.Drawing.Color.Black;
            this.btnMakeNetwork.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeNetwork.Click += new System.EventHandler(this.btnMakeNetwork_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripbtnSelect,
            this.toolStripbtnLink});
            this.toolStrip2.Location = new System.Drawing.Point(0, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip2.Size = new System.Drawing.Size(24, 62);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270;
            // 
            // toolStripbtnSelect
            // 
            this.toolStripbtnSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnSelect.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtnSelect.Image")));
            this.toolStripbtnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnSelect.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.toolStripbtnSelect.Name = "toolStripbtnSelect";
            this.toolStripbtnSelect.Size = new System.Drawing.Size(22, 20);
            this.toolStripbtnSelect.Text = "Выделение";
            this.toolStripbtnSelect.Click += new System.EventHandler(this.toolStripbtnSelect_Click);
            // 
            // toolStripbtnLink
            // 
            this.toolStripbtnLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnLink.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtnLink.Image")));
            this.toolStripbtnLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnLink.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.toolStripbtnLink.Name = "toolStripbtnLink";
            this.toolStripbtnLink.Size = new System.Drawing.Size(22, 20);
            this.toolStripbtnLink.Text = "Соединить";
            this.toolStripbtnLink.Click += new System.EventHandler(this.toolStripbtnLink_Click);
            // 
            // tsRiht
            // 
            this.tsRiht.Dock = System.Windows.Forms.DockStyle.None;
            this.tsRiht.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSimSetting});
            this.tsRiht.Location = new System.Drawing.Point(0, 3);
            this.tsRiht.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tsRiht.Name = "tsRiht";
            this.tsRiht.Size = new System.Drawing.Size(24, 173);
            this.tsRiht.TabIndex = 0;
            // 
            // tsBtnSimSetting
            // 
            this.tsBtnSimSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnSimSetting.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSimSetting.Image")));
            this.tsBtnSimSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSimSetting.Margin = new System.Windows.Forms.Padding(0);
            this.tsBtnSimSetting.Name = "tsBtnSimSetting";
            this.tsBtnSimSetting.Size = new System.Drawing.Size(22, 162);
            this.tsBtnSimSetting.Text = "Настройки моделирования";
            this.tsBtnSimSetting.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            this.tsBtnSimSetting.ToolTipText = "Настройки моделирования";
            this.tsBtnSimSetting.Click += new System.EventHandler(this.tsBtnSimSetting_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstModelTime,
            this.toolStripbtnRun});
            this.toolStrip1.Location = new System.Drawing.Point(45, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(105, 32);
            this.toolStrip1.TabIndex = 3;
            // 
            // tstModelTime
            // 
            this.tstModelTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstModelTime.Name = "tstModelTime";
            this.tstModelTime.Size = new System.Drawing.Size(50, 32);
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
            this.toolStripbtnRun.Size = new System.Drawing.Size(41, 29);
            this.toolStripbtnRun.Text = "Моделировать";
            this.toolStripbtnRun.ButtonClick += new System.EventHandler(this.toolStripbtnRun_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(260, 22);
            this.toolStripMenuItem1.Text = "Выбрать условия моделирования";
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.Transparent;
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miEdit,
            this.miModel,
            this.miHelp});
            this.MainMenu.Location = new System.Drawing.Point(55, 4);
            this.MainMenu.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(242, 24);
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
            this.miFile.Size = new System.Drawing.Size(48, 20);
            this.miFile.Text = "&Файл";
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
            this.miEdit.Size = new System.Drawing.Size(59, 20);
            this.miEdit.Text = "&Правка";
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
            this.miModel.Size = new System.Drawing.Size(62, 20);
            this.miModel.Text = "&Модель";
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
            this.miHelp.Size = new System.Drawing.Size(65, 20);
            this.miHelp.Text = "&Справка";
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pbMain1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStripContainer1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1248, 701);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // pbMain1
            // 
            this.pbMain1.BackColor = System.Drawing.Color.LightGray;
            this.pbMain1.BorderRadius = 0;
            this.pbMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMain1.Location = new System.Drawing.Point(0, 692);
            this.pbMain1.Margin = new System.Windows.Forms.Padding(0);
            this.pbMain1.MaximumValue = 100;
            this.pbMain1.Name = "pbMain1";
            this.pbMain1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(101)))), ((int)(((byte)(31)))));
            this.pbMain1.Size = new System.Drawing.Size(1248, 9);
            this.pbMain1.TabIndex = 6;
            this.pbMain1.Value = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.DarkGray;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 248F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel2.Controls.Add(this.panelDrag, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.MainMenu, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1248, 30);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // panelDrag
            // 
            this.panelDrag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDrag.Location = new System.Drawing.Point(303, 0);
            this.panelDrag.Margin = new System.Windows.Forms.Padding(0);
            this.panelDrag.Name = "panelDrag";
            this.panelDrag.Size = new System.Drawing.Size(799, 30);
            this.panelDrag.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel3.Controls.Add(this.btnClose, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnMaximize, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnMinimize, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1102, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(146, 30);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.color = System.Drawing.Color.Transparent;
            this.btnClose.colorActive = System.Drawing.Color.Silver;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnClose.ForeColor = System.Drawing.Color.DimGray;
            this.btnClose.Image = null;
            this.btnClose.ImagePosition = 0;
            this.btnClose.ImageZoom = 0;
            this.btnClose.LabelPosition = 27;
            this.btnClose.LabelText = "×";
            this.btnClose.Location = new System.Drawing.Point(98, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 30);
            this.btnClose.TabIndex = 9;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximize.color = System.Drawing.Color.Transparent;
            this.btnMaximize.colorActive = System.Drawing.Color.Silver;
            this.btnMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximize.Font = new System.Drawing.Font("Century Gothic", 13.75F);
            this.btnMaximize.ForeColor = System.Drawing.Color.DimGray;
            this.btnMaximize.Image = null;
            this.btnMaximize.ImagePosition = 0;
            this.btnMaximize.ImageZoom = 0;
            this.btnMaximize.LabelPosition = 27;
            this.btnMaximize.LabelText = "■";
            this.btnMaximize.Location = new System.Drawing.Point(49, 0);
            this.btnMaximize.Margin = new System.Windows.Forms.Padding(0);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(48, 30);
            this.btnMaximize.TabIndex = 10;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.color = System.Drawing.Color.Transparent;
            this.btnMinimize.colorActive = System.Drawing.Color.Silver;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnMinimize.ForeColor = System.Drawing.Color.DimGray;
            this.btnMinimize.Image = null;
            this.btnMinimize.ImagePosition = 0;
            this.btnMinimize.ImageZoom = 0;
            this.btnMinimize.LabelPosition = 36;
            this.btnMinimize.LabelText = "_";
            this.btnMinimize.Location = new System.Drawing.Point(0, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(48, 30);
            this.btnMinimize.TabIndex = 11;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panelDrag;
            this.bunifuDragControl1.Vertical = true;
            // 
            // ofdLoadOwl
            // 
            this.ofdLoadOwl.Filter = "OWL files|*.owl";
            // 
            // ofdLoadXes
            // 
            this.ofdLoadXes.Filter = "XES files|*.xes";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1248, 701);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TriadNS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tsTop.ResumeLayout(false);
            this.tsTop.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
            this.toolStripContainer1.RightToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.RightToolStripPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tsBottom.ResumeLayout(false);
            this.tsBottom.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.scDraw.Panel1.ResumeLayout(false);
            this.scDraw.Panel1.PerformLayout();
            this.scDraw.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scDraw)).EndInit();
            this.scDraw.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunity)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tsRiht.ResumeLayout(false);
            this.tsRiht.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsTop;
        private DrawingPanel.DrawingPanel dpMain;
        private System.Windows.Forms.ToolStripButton toolStripbtnNew;
        private System.Windows.Forms.ToolStripButton toolStripbtnOpen;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton toolStripbtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
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
        private System.Windows.Forms.ListView lvElems;
        private System.Windows.Forms.ImageList imgListNetworkItems;
        private System.Windows.Forms.SplitContainer scDraw;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton btnDefine;
        private System.Messaging.MessageQueue messageQueue1;
        private System.Windows.Forms.ToolStripButton toolStripbtnGraphConst;
        private System.Windows.Forms.ToolStripButton toolStripBtnGraphs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panelDrag;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuTileButton btnMaximize;
        private Bunifu.Framework.UI.BunifuTileButton btnMinimize;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.ToolStrip tsBottom;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStrip tsRiht;
        private System.Windows.Forms.ToolStripButton tsBtnShowElems;
        private System.Windows.Forms.ToolStripButton tsBtnSimSetting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox tstModelTime;
        private System.Windows.Forms.ToolStripSplitButton toolStripbtnRun;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripComboBox toolStripcmbZoom;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuTileButton btnClose;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripbtnSelect;
        private System.Windows.Forms.ToolStripButton toolStripbtnLink;
        private Bunifu.Framework.UI.BunifuFlatButton btnLoadOntologyUsers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Bunifu.Framework.UI.BunifuFlatButton btnLoadLogUsers;
        private Bunifu.Framework.UI.BunifuFlatButton btnUserInfo;
        private Bunifu.Framework.UI.BunifuFlatButton btnMakeNetwork;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvPeople;
        private System.Windows.Forms.OpenFileDialog ofdLoadOwl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvCommunity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private System.Windows.Forms.OpenFileDialog ofdLoadXes;
        private Bunifu.Framework.UI.BunifuProgressBar pbMain1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnNameUser;
        private System.Windows.Forms.DataGridViewLinkColumn ClmnUrlUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewLinkColumn clmnLincCommunity;
    }
}

