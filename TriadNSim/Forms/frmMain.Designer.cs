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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tsBottom = new System.Windows.Forms.ToolStrip();
            this.tsBtnShowElems = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripcmbZoom = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trbZoom = new MetroFramework.Controls.MetroTrackBar();
            this.scDraw = new System.Windows.Forms.SplitContainer();
            this.dpMain = new DrawingPanel.DrawingPanel();
            this.lvElems = new System.Windows.Forms.ListView();
            this.imgListNetworkItems = new System.Windows.Forms.ImageList(this.components);
            this.panelSna = new System.Windows.Forms.Panel();
            this.tablePanelSna = new System.Windows.Forms.TableLayoutPanel();
            this.bunifuFlatButton2 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton3 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton6 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton7 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panelSimulation = new System.Windows.Forms.Panel();
            this.tablePanelSimulation = new System.Windows.Forms.TableLayoutPanel();
            this.btnEditMC = new Bunifu.Framework.UI.BunifuFlatButton();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFinish = new MetroFramework.Controls.MetroDateTime();
            this.label9 = new System.Windows.Forms.Label();
            this.btnMakeNetwork = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnClearNetwork = new Bunifu.Framework.UI.BunifuFlatButton();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpStart = new MetroFramework.Controls.MetroDateTime();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chbxIsBuildNetwork = new MetroFramework.Controls.MetroCheckBox();
            this.chbIsShowAllRoutines = new MetroFramework.Controls.MetroCheckBox();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnRunSimulation = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnEditIp = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnOpenSimulationSettings = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panelCommunity = new System.Windows.Forms.Panel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDeleteCommunity = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAddCommunity = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnCommunityInfo = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dgvCommunity = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnLincCommunity = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpenCommunityPanel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panelPeople = new System.Windows.Forms.Panel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDeleteUser = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnUserInfo = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAddUser = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dgvPeople = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.ClmnNameUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnUrlUser = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenPeoplePanel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panelLoadData = new System.Windows.Forms.Panel();
            this.btnLoadOntologyUsers = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnLoadLogUsers = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnOpenLoadDataPanel = new Bunifu.Framework.UI.BunifuFlatButton();
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbMain = new Bunifu.Framework.UI.BunifuProgressBar();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDrag = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnMinimize = new Bunifu.Framework.UI.BunifuTileButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.ofdLoadOwl = new System.Windows.Forms.OpenFileDialog();
            this.ofdLoadXes = new System.Windows.Forms.OpenFileDialog();
            this.btnMaximize = new Bunifu.Framework.UI.BunifuTileButton();
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
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scDraw)).BeginInit();
            this.scDraw.Panel1.SuspendLayout();
            this.scDraw.Panel2.SuspendLayout();
            this.scDraw.SuspendLayout();
            this.panelSna.SuspendLayout();
            this.tablePanelSna.SuspendLayout();
            this.panelSimulation.SuspendLayout();
            this.tablePanelSimulation.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panelCommunity.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunity)).BeginInit();
            this.panelPeople.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.panelLoadData.SuspendLayout();
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
            this.tsTop.BackColor = System.Drawing.Color.Transparent;
            this.tsTop.Dock = System.Windows.Forms.DockStyle.None;
            this.tsTop.GripMargin = new System.Windows.Forms.Padding(0);
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
            this.toolStripBtnGraphs});
            this.tsTop.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsTop.Location = new System.Drawing.Point(3, 32);
            this.tsTop.Name = "tsTop";
            this.tsTop.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsTop.Size = new System.Drawing.Size(386, 32);
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
            this.toolStripContainer1.BottomToolStripPanel.BackColor = System.Drawing.Color.Transparent;
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.tsBottom);
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStrip3);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer3);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1623, 854);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.BackColor = System.Drawing.Color.Transparent;
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.toolStrip2);
            this.toolStripContainer1.Location = new System.Drawing.Point(3, 38);
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            this.toolStripContainer1.RightToolStripPanel.BackColor = System.Drawing.Color.Transparent;
            this.toolStripContainer1.RightToolStripPanel.Controls.Add(this.tsRiht);
            this.toolStripContainer1.Size = new System.Drawing.Size(1671, 950);
            this.toolStripContainer1.TabIndex = 4;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.Color.Transparent;
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsTop);
            this.toolStripContainer1.TopToolStripPanel.ForeColor = System.Drawing.Color.Black;
            this.toolStripContainer1.TopToolStripPanel.Click += new System.EventHandler(this.toolStripContainer1_TopToolStripPanel_Click_1);
            // 
            // tsBottom
            // 
            this.tsBottom.BackColor = System.Drawing.Color.Transparent;
            this.tsBottom.Dock = System.Windows.Forms.DockStyle.None;
            this.tsBottom.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnShowElems,
            this.toolStripSeparator7,
            this.toolStripButton4});
            this.tsBottom.Location = new System.Drawing.Point(23, 0);
            this.tsBottom.Name = "tsBottom";
            this.tsBottom.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsBottom.Size = new System.Drawing.Size(173, 32);
            this.tsBottom.TabIndex = 0;
            // 
            // tsBtnShowElems
            // 
            this.tsBtnShowElems.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tsBtnShowElems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnShowElems.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnShowElems.Image")));
            this.tsBtnShowElems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnShowElems.Name = "tsBtnShowElems";
            this.tsBtnShowElems.Padding = new System.Windows.Forms.Padding(5);
            this.tsBtnShowElems.Size = new System.Drawing.Size(116, 29);
            this.tsBtnShowElems.Text = "Панель объектов";
            this.tsBtnShowElems.Click += new System.EventHandler(this.tsBtnShowElems_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripButton4.Size = new System.Drawing.Size(48, 29);
            this.toolStripButton4.Text = "Логи";
            // 
            // toolStrip3
            // 
            this.toolStrip3.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.GripMargin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripcmbZoom,
            this.toolStripLabel1,
            this.toolStripButton5,
            this.toolStripButton6});
            this.toolStrip3.Location = new System.Drawing.Point(965, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(254, 32);
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
            this.toolStripcmbZoom.Size = new System.Drawing.Size(121, 32);
            this.toolStripcmbZoom.ToolTipText = "Масштаб";
            this.toolStripcmbZoom.SelectedIndexChanged += new System.EventHandler(this.toolStripcmbZoom_SelectedIndexChanged);
            this.toolStripcmbZoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripcmbZoom_KeyDown);
            this.toolStripcmbZoom.TextChanged += new System.EventHandler(this.toolStripcmbZoom_TextChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(65, 29);
            this.toolStripLabel1.Text = "Масштаб: ";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton6.Text = "toolStripButton6";
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
            this.splitContainer3.Size = new System.Drawing.Size(1623, 854);
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
            this.scMain.Panel1.Controls.Add(this.metroPanel1);
            this.scMain.Panel1.Controls.Add(this.scDraw);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.AutoScroll = true;
            this.scMain.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.scMain.Panel2.Controls.Add(this.panelSna);
            this.scMain.Panel2.Controls.Add(this.bunifuFlatButton7);
            this.scMain.Panel2.Controls.Add(this.panelSimulation);
            this.scMain.Panel2.Controls.Add(this.btnOpenSimulationSettings);
            this.scMain.Panel2.Controls.Add(this.panelCommunity);
            this.scMain.Panel2.Controls.Add(this.btnOpenCommunityPanel);
            this.scMain.Panel2.Controls.Add(this.panelPeople);
            this.scMain.Panel2.Controls.Add(this.btnOpenPeoplePanel);
            this.scMain.Panel2.Controls.Add(this.panelLoadData);
            this.scMain.Panel2.Controls.Add(this.btnOpenLoadDataPanel);
            this.scMain.Panel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.scMain.Panel2MinSize = 0;
            this.scMain.Size = new System.Drawing.Size(1623, 854);
            this.scMain.SplitterDistance = 1216;
            this.scMain.TabIndex = 5;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.label8);
            this.metroPanel1.Controls.Add(this.label7);
            this.metroPanel1.Controls.Add(this.label6);
            this.metroPanel1.Controls.Add(this.trbZoom);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(13, 727);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(220, 55);
            this.metroPanel1.TabIndex = 5;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(187, 29);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label8.Size = new System.Drawing.Size(25, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "200";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(7, 30);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label7.Size = new System.Drawing.Size(13, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(6, 10);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Масштаб";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // trbZoom
            // 
            this.trbZoom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.trbZoom.BackColor = System.Drawing.Color.Transparent;
            this.trbZoom.Location = new System.Drawing.Point(26, 31);
            this.trbZoom.Maximum = 200;
            this.trbZoom.Minimum = 10;
            this.trbZoom.Name = "trbZoom";
            this.trbZoom.Size = new System.Drawing.Size(160, 10);
            this.trbZoom.Style = MetroFramework.MetroColorStyle.Green;
            this.trbZoom.TabIndex = 7;
            this.trbZoom.Text = "metroTrackBar1";
            this.trbZoom.Value = 100;
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
            this.scDraw.Size = new System.Drawing.Size(1214, 852);
            this.scDraw.SplitterDistance = 758;
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
            this.dpMain.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            this.dpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpMain.dx = 0;
            this.dpMain.dy = 0;
            this.dpMain.gridSize = 20;
            this.dpMain.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            this.dpMain.Location = new System.Drawing.Point(0, 0);
            this.dpMain.Margin = new System.Windows.Forms.Padding(0);
            this.dpMain.Name = "dpMain";
            this.dpMain.Size = new System.Drawing.Size(1214, 758);
            this.dpMain.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.dpMain.StickToGrid = true;
            this.dpMain.TabIndex = 3;
            this.dpMain.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.dpMain.Zoom = 1F;
            this.dpMain.objectSelected += new DrawingPanel.ObjectSelected(this.drawingPanel1_objectSelected);
            this.dpMain.beforeAddLine += new DrawingPanel.BeforeAddLine(this.drawingPanel1_beforeAddLine);
            this.dpMain.onLineCPChanged += new DrawingPanel.OnLineCPChanged(this.drawingPanel1_onLineCPChanged);
            this.dpMain.Load += new System.EventHandler(this.dpMain_Load);
            this.dpMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.drawingPanel1_DragDrop);
            this.dpMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.drawingPanel1_DragEnter);
            this.dpMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.drawingPanel1_MouseDoubleClick);
            this.dpMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingPanel1_MouseUp);
            this.dpMain.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.drawingPanel1_MouseWheel);
            // 
            // lvElems
            // 
            this.lvElems.BackColor = System.Drawing.Color.WhiteSmoke;
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
            this.lvElems.Size = new System.Drawing.Size(1214, 90);
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
            // panelSna
            // 
            this.panelSna.Controls.Add(this.tablePanelSna);
            this.panelSna.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSna.Location = new System.Drawing.Point(0, 1564);
            this.panelSna.Name = "panelSna";
            this.panelSna.Size = new System.Drawing.Size(384, 136);
            this.panelSna.TabIndex = 13;
            this.panelSna.Visible = false;
            // 
            // tablePanelSna
            // 
            this.tablePanelSna.ColumnCount = 1;
            this.tablePanelSna.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanelSna.Controls.Add(this.bunifuFlatButton2, 0, 0);
            this.tablePanelSna.Controls.Add(this.bunifuFlatButton3, 0, 1);
            this.tablePanelSna.Controls.Add(this.bunifuFlatButton6, 0, 2);
            this.tablePanelSna.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanelSna.Location = new System.Drawing.Point(0, 0);
            this.tablePanelSna.Margin = new System.Windows.Forms.Padding(0);
            this.tablePanelSna.Name = "tablePanelSna";
            this.tablePanelSna.Padding = new System.Windows.Forms.Padding(10);
            this.tablePanelSna.RowCount = 3;
            this.tablePanelSna.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tablePanelSna.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tablePanelSna.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tablePanelSna.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablePanelSna.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablePanelSna.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablePanelSna.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablePanelSna.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablePanelSna.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablePanelSna.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablePanelSna.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablePanelSna.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablePanelSna.Size = new System.Drawing.Size(384, 136);
            this.tablePanelSna.TabIndex = 11;
            // 
            // bunifuFlatButton2
            // 
            this.bunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.bunifuFlatButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.bunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton2.BorderRadius = 0;
            this.bunifuFlatButton2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuFlatButton2.ButtonText = "Вычислить диаметр графа";
            this.bunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton2.DisabledColor = System.Drawing.Color.Gainsboro;
            this.bunifuFlatButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuFlatButton2.Enabled = false;
            this.bunifuFlatButton2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton2.Iconimage")));
            this.bunifuFlatButton2.Iconimage_right = null;
            this.bunifuFlatButton2.Iconimage_right_Selected = null;
            this.bunifuFlatButton2.Iconimage_Selected = null;
            this.bunifuFlatButton2.IconMarginLeft = 11;
            this.bunifuFlatButton2.IconMarginRight = 0;
            this.bunifuFlatButton2.IconRightVisible = true;
            this.bunifuFlatButton2.IconRightZoom = 0D;
            this.bunifuFlatButton2.IconVisible = true;
            this.bunifuFlatButton2.IconZoom = 40D;
            this.bunifuFlatButton2.IsTab = false;
            this.bunifuFlatButton2.Location = new System.Drawing.Point(10, 10);
            this.bunifuFlatButton2.Margin = new System.Windows.Forms.Padding(0);
            this.bunifuFlatButton2.Name = "bunifuFlatButton2";
            this.bunifuFlatButton2.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.bunifuFlatButton2.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(103)))), ((int)(((byte)(88)))));
            this.bunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton2.Padding = new System.Windows.Forms.Padding(5);
            this.bunifuFlatButton2.selected = false;
            this.bunifuFlatButton2.Size = new System.Drawing.Size(364, 35);
            this.bunifuFlatButton2.TabIndex = 5;
            this.bunifuFlatButton2.Text = "Вычислить диаметр графа";
            this.bunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton2.Textcolor = System.Drawing.Color.Black;
            this.bunifuFlatButton2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // bunifuFlatButton3
            // 
            this.bunifuFlatButton3.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.bunifuFlatButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.bunifuFlatButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton3.BorderRadius = 0;
            this.bunifuFlatButton3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuFlatButton3.ButtonText = "Вычислить коэф. кластеризации";
            this.bunifuFlatButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton3.DisabledColor = System.Drawing.Color.Gainsboro;
            this.bunifuFlatButton3.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuFlatButton3.Enabled = false;
            this.bunifuFlatButton3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuFlatButton3.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton3.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton3.Iconimage")));
            this.bunifuFlatButton3.Iconimage_right = null;
            this.bunifuFlatButton3.Iconimage_right_Selected = null;
            this.bunifuFlatButton3.Iconimage_Selected = null;
            this.bunifuFlatButton3.IconMarginLeft = 11;
            this.bunifuFlatButton3.IconMarginRight = 0;
            this.bunifuFlatButton3.IconRightVisible = true;
            this.bunifuFlatButton3.IconRightZoom = 0D;
            this.bunifuFlatButton3.IconVisible = true;
            this.bunifuFlatButton3.IconZoom = 40D;
            this.bunifuFlatButton3.IsTab = false;
            this.bunifuFlatButton3.Location = new System.Drawing.Point(10, 52);
            this.bunifuFlatButton3.Margin = new System.Windows.Forms.Padding(0);
            this.bunifuFlatButton3.Name = "bunifuFlatButton3";
            this.bunifuFlatButton3.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.bunifuFlatButton3.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(103)))), ((int)(((byte)(88)))));
            this.bunifuFlatButton3.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton3.Padding = new System.Windows.Forms.Padding(5);
            this.bunifuFlatButton3.selected = false;
            this.bunifuFlatButton3.Size = new System.Drawing.Size(364, 35);
            this.bunifuFlatButton3.TabIndex = 8;
            this.bunifuFlatButton3.Text = "Вычислить коэф. кластеризации";
            this.bunifuFlatButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton3.Textcolor = System.Drawing.Color.Black;
            this.bunifuFlatButton3.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // bunifuFlatButton6
            // 
            this.bunifuFlatButton6.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.bunifuFlatButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.bunifuFlatButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton6.BorderRadius = 0;
            this.bunifuFlatButton6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuFlatButton6.ButtonText = "Вычислить коэф. ассортативности";
            this.bunifuFlatButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton6.DisabledColor = System.Drawing.Color.Gainsboro;
            this.bunifuFlatButton6.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuFlatButton6.Enabled = false;
            this.bunifuFlatButton6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuFlatButton6.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton6.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton6.Iconimage")));
            this.bunifuFlatButton6.Iconimage_right = null;
            this.bunifuFlatButton6.Iconimage_right_Selected = null;
            this.bunifuFlatButton6.Iconimage_Selected = null;
            this.bunifuFlatButton6.IconMarginLeft = 11;
            this.bunifuFlatButton6.IconMarginRight = 0;
            this.bunifuFlatButton6.IconRightVisible = true;
            this.bunifuFlatButton6.IconRightZoom = 0D;
            this.bunifuFlatButton6.IconVisible = true;
            this.bunifuFlatButton6.IconZoom = 40D;
            this.bunifuFlatButton6.IsTab = false;
            this.bunifuFlatButton6.Location = new System.Drawing.Point(10, 94);
            this.bunifuFlatButton6.Margin = new System.Windows.Forms.Padding(0);
            this.bunifuFlatButton6.Name = "bunifuFlatButton6";
            this.bunifuFlatButton6.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.bunifuFlatButton6.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(103)))), ((int)(((byte)(88)))));
            this.bunifuFlatButton6.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton6.Padding = new System.Windows.Forms.Padding(5);
            this.bunifuFlatButton6.selected = false;
            this.bunifuFlatButton6.Size = new System.Drawing.Size(364, 36);
            this.bunifuFlatButton6.TabIndex = 16;
            this.bunifuFlatButton6.Text = "Вычислить коэф. ассортативности";
            this.bunifuFlatButton6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton6.Textcolor = System.Drawing.Color.Black;
            this.bunifuFlatButton6.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // bunifuFlatButton7
            // 
            this.bunifuFlatButton7.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton7.BorderRadius = 0;
            this.bunifuFlatButton7.ButtonText = "Модели распространения информации";
            this.bunifuFlatButton7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton7.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton7.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuFlatButton7.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton7.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton7.Iconimage")));
            this.bunifuFlatButton7.Iconimage_right = null;
            this.bunifuFlatButton7.Iconimage_right_Selected = null;
            this.bunifuFlatButton7.Iconimage_Selected = null;
            this.bunifuFlatButton7.IconMarginLeft = 0;
            this.bunifuFlatButton7.IconMarginRight = 0;
            this.bunifuFlatButton7.IconRightVisible = true;
            this.bunifuFlatButton7.IconRightZoom = 0D;
            this.bunifuFlatButton7.IconVisible = true;
            this.bunifuFlatButton7.IconZoom = 50D;
            this.bunifuFlatButton7.IsTab = true;
            this.bunifuFlatButton7.Location = new System.Drawing.Point(0, 1531);
            this.bunifuFlatButton7.Name = "bunifuFlatButton7";
            this.bunifuFlatButton7.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton7.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.bunifuFlatButton7.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton7.selected = false;
            this.bunifuFlatButton7.Size = new System.Drawing.Size(384, 33);
            this.bunifuFlatButton7.TabIndex = 12;
            this.bunifuFlatButton7.Text = "Модели распространения информации";
            this.bunifuFlatButton7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton7.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton7.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton7.Click += new System.EventHandler(this.bunifuFlatButton7_Click);
            // 
            // panelSimulation
            // 
            this.panelSimulation.Controls.Add(this.tablePanelSimulation);
            this.panelSimulation.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSimulation.Location = new System.Drawing.Point(0, 981);
            this.panelSimulation.Margin = new System.Windows.Forms.Padding(0);
            this.panelSimulation.MinimumSize = new System.Drawing.Size(0, 550);
            this.panelSimulation.Name = "panelSimulation";
            this.panelSimulation.Size = new System.Drawing.Size(384, 550);
            this.panelSimulation.TabIndex = 7;
            this.panelSimulation.Visible = false;
            // 
            // tablePanelSimulation
            // 
            this.tablePanelSimulation.ColumnCount = 1;
            this.tablePanelSimulation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanelSimulation.Controls.Add(this.btnEditMC, 0, 9);
            this.tablePanelSimulation.Controls.Add(this.tableLayoutPanel5, 0, 4);
            this.tablePanelSimulation.Controls.Add(this.btnMakeNetwork, 0, 0);
            this.tablePanelSimulation.Controls.Add(this.btnClearNetwork, 0, 1);
            this.tablePanelSimulation.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tablePanelSimulation.Controls.Add(this.label4, 0, 2);
            this.tablePanelSimulation.Controls.Add(this.chbxIsBuildNetwork, 0, 5);
            this.tablePanelSimulation.Controls.Add(this.chbIsShowAllRoutines, 0, 6);
            this.tablePanelSimulation.Controls.Add(this.bunifuFlatButton1, 0, 11);
            this.tablePanelSimulation.Controls.Add(this.btnRunSimulation, 0, 10);
            this.tablePanelSimulation.Controls.Add(this.btnEditIp, 0, 8);
            this.tablePanelSimulation.Dock = System.Windows.Forms.DockStyle.Top;
            this.tablePanelSimulation.Location = new System.Drawing.Point(0, 0);
            this.tablePanelSimulation.Margin = new System.Windows.Forms.Padding(0);
            this.tablePanelSimulation.Name = "tablePanelSimulation";
            this.tablePanelSimulation.Padding = new System.Windows.Forms.Padding(10);
            this.tablePanelSimulation.RowCount = 13;
            this.tablePanelSimulation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tablePanelSimulation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tablePanelSimulation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tablePanelSimulation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tablePanelSimulation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tablePanelSimulation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tablePanelSimulation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tablePanelSimulation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tablePanelSimulation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tablePanelSimulation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tablePanelSimulation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tablePanelSimulation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tablePanelSimulation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tablePanelSimulation.Size = new System.Drawing.Size(384, 547);
            this.tablePanelSimulation.TabIndex = 10;
            this.tablePanelSimulation.Paint += new System.Windows.Forms.PaintEventHandler(this.tablePanelSimulation_Paint);
            // 
            // btnEditMC
            // 
            this.btnEditMC.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnEditMC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnEditMC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditMC.BorderRadius = 0;
            this.btnEditMC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnEditMC.ButtonText = "Условия моделирования";
            this.btnEditMC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditMC.DisabledColor = System.Drawing.Color.Gainsboro;
            this.btnEditMC.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditMC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEditMC.Iconcolor = System.Drawing.Color.Transparent;
            this.btnEditMC.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnEditMC.Iconimage")));
            this.btnEditMC.Iconimage_right = null;
            this.btnEditMC.Iconimage_right_Selected = null;
            this.btnEditMC.Iconimage_Selected = null;
            this.btnEditMC.IconMarginLeft = 11;
            this.btnEditMC.IconMarginRight = 0;
            this.btnEditMC.IconRightVisible = true;
            this.btnEditMC.IconRightZoom = 0D;
            this.btnEditMC.IconVisible = true;
            this.btnEditMC.IconZoom = 40D;
            this.btnEditMC.IsTab = false;
            this.btnEditMC.Location = new System.Drawing.Point(10, 370);
            this.btnEditMC.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditMC.Name = "btnEditMC";
            this.btnEditMC.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnEditMC.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(103)))), ((int)(((byte)(88)))));
            this.btnEditMC.OnHoverTextColor = System.Drawing.Color.White;
            this.btnEditMC.Padding = new System.Windows.Forms.Padding(5);
            this.btnEditMC.selected = false;
            this.btnEditMC.Size = new System.Drawing.Size(364, 39);
            this.btnEditMC.TabIndex = 15;
            this.btnEditMC.Text = "Условия моделирования";
            this.btnEditMC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEditMC.Textcolor = System.Drawing.Color.Black;
            this.btnEditMC.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditMC.Click += new System.EventHandler(this.btnEditMC_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.dtpFinish, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label9, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(13, 164);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(358, 60);
            this.tableLayoutPanel5.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "по";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFinish
            // 
            this.dtpFinish.CalendarMonthBackground = System.Drawing.Color.Transparent;
            this.dtpFinish.CustomFormat = "dd.MM.yyyy  |  hh:mm:ss tt";
            this.dtpFinish.DisplayFocus = true;
            this.dtpFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFinish.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFinish.Location = new System.Drawing.Point(32, 3);
            this.dtpFinish.MinimumSize = new System.Drawing.Size(4, 29);
            this.dtpFinish.Name = "dtpFinish";
            this.dtpFinish.ShowCheckBox = true;
            this.dtpFinish.Size = new System.Drawing.Size(323, 29);
            this.dtpFinish.Style = MetroFramework.MetroColorStyle.Silver;
            this.dtpFinish.TabIndex = 1;
            this.dtpFinish.UseCustomBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(32, 38);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label9.Size = new System.Drawing.Size(165, 21);
            this.label9.TabIndex = 16;
            this.label9.Text = "Всего событий за это время: 0";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // btnMakeNetwork
            // 
            this.btnMakeNetwork.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnMakeNetwork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnMakeNetwork.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMakeNetwork.BorderRadius = 0;
            this.btnMakeNetwork.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnMakeNetwork.ButtonText = "Построить сеть";
            this.btnMakeNetwork.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMakeNetwork.DisabledColor = System.Drawing.Color.Gainsboro;
            this.btnMakeNetwork.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMakeNetwork.Enabled = false;
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
            this.btnMakeNetwork.Location = new System.Drawing.Point(10, 10);
            this.btnMakeNetwork.Margin = new System.Windows.Forms.Padding(0);
            this.btnMakeNetwork.Name = "btnMakeNetwork";
            this.btnMakeNetwork.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnMakeNetwork.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(103)))), ((int)(((byte)(88)))));
            this.btnMakeNetwork.OnHoverTextColor = System.Drawing.Color.White;
            this.btnMakeNetwork.Padding = new System.Windows.Forms.Padding(5);
            this.btnMakeNetwork.selected = false;
            this.btnMakeNetwork.Size = new System.Drawing.Size(364, 35);
            this.btnMakeNetwork.TabIndex = 5;
            this.btnMakeNetwork.Text = "Построить сеть";
            this.btnMakeNetwork.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMakeNetwork.Textcolor = System.Drawing.Color.Black;
            this.btnMakeNetwork.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeNetwork.Click += new System.EventHandler(this.btnMakeNetwork_Click);
            // 
            // btnClearNetwork
            // 
            this.btnClearNetwork.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnClearNetwork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnClearNetwork.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClearNetwork.BorderRadius = 0;
            this.btnClearNetwork.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnClearNetwork.ButtonText = "Очистить сеть";
            this.btnClearNetwork.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearNetwork.DisabledColor = System.Drawing.Color.Gainsboro;
            this.btnClearNetwork.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClearNetwork.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClearNetwork.Iconcolor = System.Drawing.Color.Transparent;
            this.btnClearNetwork.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnClearNetwork.Iconimage")));
            this.btnClearNetwork.Iconimage_right = null;
            this.btnClearNetwork.Iconimage_right_Selected = null;
            this.btnClearNetwork.Iconimage_Selected = null;
            this.btnClearNetwork.IconMarginLeft = 11;
            this.btnClearNetwork.IconMarginRight = 0;
            this.btnClearNetwork.IconRightVisible = true;
            this.btnClearNetwork.IconRightZoom = 0D;
            this.btnClearNetwork.IconVisible = true;
            this.btnClearNetwork.IconZoom = 40D;
            this.btnClearNetwork.IsTab = false;
            this.btnClearNetwork.Location = new System.Drawing.Point(10, 52);
            this.btnClearNetwork.Margin = new System.Windows.Forms.Padding(0);
            this.btnClearNetwork.Name = "btnClearNetwork";
            this.btnClearNetwork.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnClearNetwork.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(103)))), ((int)(((byte)(88)))));
            this.btnClearNetwork.OnHoverTextColor = System.Drawing.Color.White;
            this.btnClearNetwork.Padding = new System.Windows.Forms.Padding(5);
            this.btnClearNetwork.selected = false;
            this.btnClearNetwork.Size = new System.Drawing.Size(364, 35);
            this.btnClearNetwork.TabIndex = 8;
            this.btnClearNetwork.Text = "Очистить сеть";
            this.btnClearNetwork.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClearNetwork.Textcolor = System.Drawing.Color.Black;
            this.btnClearNetwork.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearNetwork.Click += new System.EventHandler(this.btnClearNetwork_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.dtpStart, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(13, 123);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(358, 35);
            this.tableLayoutPanel4.TabIndex = 10;
            // 
            // dtpStart
            // 
            this.dtpStart.CalendarMonthBackground = System.Drawing.Color.Transparent;
            this.dtpStart.CustomFormat = "dd.MM.yyyy  |  hh:mm:ss tt";
            this.dtpStart.DisplayFocus = true;
            this.dtpStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(31, 3);
            this.dtpStart.MinimumSize = new System.Drawing.Size(4, 29);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.ShowCheckBox = true;
            this.dtpStart.Size = new System.Drawing.Size(324, 29);
            this.dtpStart.Style = MetroFramework.MetroColorStyle.Silver;
            this.dtpStart.TabIndex = 3;
            this.dtpStart.UseCustomBackColor = true;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "с";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 101);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label4.Size = new System.Drawing.Size(149, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Параметры моделирования";
            // 
            // chbxIsBuildNetwork
            // 
            this.chbxIsBuildNetwork.AutoSize = true;
            this.chbxIsBuildNetwork.BackColor = System.Drawing.Color.Transparent;
            this.chbxIsBuildNetwork.Checked = true;
            this.chbxIsBuildNetwork.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxIsBuildNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chbxIsBuildNetwork.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chbxIsBuildNetwork.Location = new System.Drawing.Point(13, 230);
            this.chbxIsBuildNetwork.Name = "chbxIsBuildNetwork";
            this.chbxIsBuildNetwork.Size = new System.Drawing.Size(358, 35);
            this.chbxIsBuildNetwork.Style = MetroFramework.MetroColorStyle.Silver;
            this.chbxIsBuildNetwork.TabIndex = 13;
            this.chbxIsBuildNetwork.Text = "с построением сети";
            this.chbxIsBuildNetwork.UseCustomBackColor = true;
            this.chbxIsBuildNetwork.UseSelectable = true;
            // 
            // chbIsShowAllRoutines
            // 
            this.chbIsShowAllRoutines.AutoSize = true;
            this.chbIsShowAllRoutines.BackColor = System.Drawing.Color.Transparent;
            this.chbIsShowAllRoutines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chbIsShowAllRoutines.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chbIsShowAllRoutines.Location = new System.Drawing.Point(13, 271);
            this.chbIsShowAllRoutines.Name = "chbIsShowAllRoutines";
            this.chbIsShowAllRoutines.Size = new System.Drawing.Size(358, 40);
            this.chbIsShowAllRoutines.Style = MetroFramework.MetroColorStyle.Silver;
            this.chbIsShowAllRoutines.TabIndex = 15;
            this.chbIsShowAllRoutines.Text = "просматривать каждую сгенерированную рутину";
            this.chbIsShowAllRoutines.UseCustomBackColor = true;
            this.chbIsShowAllRoutines.UseSelectable = true;
            this.chbIsShowAllRoutines.CheckedChanged += new System.EventHandler(this.metroCheckBox1_CheckedChanged);
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 0;
            this.bunifuFlatButton1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuFlatButton1.ButtonText = "Сформировать отчет";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gainsboro;
            this.bunifuFlatButton1.Dock = System.Windows.Forms.DockStyle.Top;
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
            this.bunifuFlatButton1.Location = new System.Drawing.Point(10, 502);
            this.bunifuFlatButton1.Margin = new System.Windows.Forms.Padding(0);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(103)))), ((int)(((byte)(88)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.Padding = new System.Windows.Forms.Padding(5);
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(364, 35);
            this.bunifuFlatButton1.TabIndex = 16;
            this.bunifuFlatButton1.Text = "Сформировать отчет";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.Black;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // btnRunSimulation
            // 
            this.btnRunSimulation.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnRunSimulation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.btnRunSimulation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRunSimulation.BorderRadius = 0;
            this.btnRunSimulation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnRunSimulation.ButtonText = "Начать моделирование";
            this.btnRunSimulation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRunSimulation.DisabledColor = System.Drawing.Color.Gainsboro;
            this.btnRunSimulation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRunSimulation.Enabled = false;
            this.btnRunSimulation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRunSimulation.Iconcolor = System.Drawing.Color.Transparent;
            this.btnRunSimulation.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnRunSimulation.Iconimage")));
            this.btnRunSimulation.Iconimage_right = null;
            this.btnRunSimulation.Iconimage_right_Selected = null;
            this.btnRunSimulation.Iconimage_Selected = null;
            this.btnRunSimulation.IconMarginLeft = 11;
            this.btnRunSimulation.IconMarginRight = 0;
            this.btnRunSimulation.IconRightVisible = true;
            this.btnRunSimulation.IconRightZoom = 0D;
            this.btnRunSimulation.IconVisible = true;
            this.btnRunSimulation.IconZoom = 40D;
            this.btnRunSimulation.IsTab = false;
            this.btnRunSimulation.Location = new System.Drawing.Point(10, 439);
            this.btnRunSimulation.Margin = new System.Windows.Forms.Padding(0);
            this.btnRunSimulation.Name = "btnRunSimulation";
            this.btnRunSimulation.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.btnRunSimulation.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(103)))), ((int)(((byte)(88)))));
            this.btnRunSimulation.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRunSimulation.Padding = new System.Windows.Forms.Padding(5);
            this.btnRunSimulation.selected = false;
            this.btnRunSimulation.Size = new System.Drawing.Size(364, 35);
            this.btnRunSimulation.TabIndex = 14;
            this.btnRunSimulation.Text = "Начать моделирование";
            this.btnRunSimulation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRunSimulation.Textcolor = System.Drawing.Color.Black;
            this.btnRunSimulation.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunSimulation.Click += new System.EventHandler(this.btnRunSimulation_Click);
            // 
            // btnEditIp
            // 
            this.btnEditIp.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnEditIp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnEditIp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditIp.BorderRadius = 0;
            this.btnEditIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnEditIp.ButtonText = "Информаицонные процедуры";
            this.btnEditIp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditIp.DisabledColor = System.Drawing.Color.Gainsboro;
            this.btnEditIp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditIp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEditIp.Iconcolor = System.Drawing.Color.Transparent;
            this.btnEditIp.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnEditIp.Iconimage")));
            this.btnEditIp.Iconimage_right = null;
            this.btnEditIp.Iconimage_right_Selected = null;
            this.btnEditIp.Iconimage_Selected = null;
            this.btnEditIp.IconMarginLeft = 11;
            this.btnEditIp.IconMarginRight = 0;
            this.btnEditIp.IconRightVisible = true;
            this.btnEditIp.IconRightZoom = 0D;
            this.btnEditIp.IconVisible = true;
            this.btnEditIp.IconZoom = 40D;
            this.btnEditIp.IsTab = false;
            this.btnEditIp.Location = new System.Drawing.Point(10, 326);
            this.btnEditIp.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditIp.Name = "btnEditIp";
            this.btnEditIp.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnEditIp.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(103)))), ((int)(((byte)(88)))));
            this.btnEditIp.OnHoverTextColor = System.Drawing.Color.White;
            this.btnEditIp.Padding = new System.Windows.Forms.Padding(5);
            this.btnEditIp.selected = false;
            this.btnEditIp.Size = new System.Drawing.Size(364, 39);
            this.btnEditIp.TabIndex = 14;
            this.btnEditIp.Text = "Информаицонные процедуры";
            this.btnEditIp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEditIp.Textcolor = System.Drawing.Color.Black;
            this.btnEditIp.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditIp.Click += new System.EventHandler(this.btnEditIp_Click);
            // 
            // btnOpenSimulationSettings
            // 
            this.btnOpenSimulationSettings.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnOpenSimulationSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnOpenSimulationSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenSimulationSettings.BorderRadius = 0;
            this.btnOpenSimulationSettings.ButtonText = "Моделирование";
            this.btnOpenSimulationSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenSimulationSettings.DisabledColor = System.Drawing.Color.Gray;
            this.btnOpenSimulationSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpenSimulationSettings.Iconcolor = System.Drawing.Color.Transparent;
            this.btnOpenSimulationSettings.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnOpenSimulationSettings.Iconimage")));
            this.btnOpenSimulationSettings.Iconimage_right = null;
            this.btnOpenSimulationSettings.Iconimage_right_Selected = null;
            this.btnOpenSimulationSettings.Iconimage_Selected = null;
            this.btnOpenSimulationSettings.IconMarginLeft = 0;
            this.btnOpenSimulationSettings.IconMarginRight = 0;
            this.btnOpenSimulationSettings.IconRightVisible = true;
            this.btnOpenSimulationSettings.IconRightZoom = 0D;
            this.btnOpenSimulationSettings.IconVisible = true;
            this.btnOpenSimulationSettings.IconZoom = 50D;
            this.btnOpenSimulationSettings.IsTab = true;
            this.btnOpenSimulationSettings.Location = new System.Drawing.Point(0, 948);
            this.btnOpenSimulationSettings.Name = "btnOpenSimulationSettings";
            this.btnOpenSimulationSettings.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnOpenSimulationSettings.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnOpenSimulationSettings.OnHoverTextColor = System.Drawing.Color.White;
            this.btnOpenSimulationSettings.selected = false;
            this.btnOpenSimulationSettings.Size = new System.Drawing.Size(384, 33);
            this.btnOpenSimulationSettings.TabIndex = 10;
            this.btnOpenSimulationSettings.Text = "Моделирование";
            this.btnOpenSimulationSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenSimulationSettings.Textcolor = System.Drawing.Color.White;
            this.btnOpenSimulationSettings.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenSimulationSettings.Click += new System.EventHandler(this.btnOpenSimulationSettings_Click);
            // 
            // panelCommunity
            // 
            this.panelCommunity.Controls.Add(this.tableLayoutPanel7);
            this.panelCommunity.Controls.Add(this.dgvCommunity);
            this.panelCommunity.Controls.Add(this.label2);
            this.panelCommunity.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCommunity.Location = new System.Drawing.Point(0, 598);
            this.panelCommunity.Margin = new System.Windows.Forms.Padding(0);
            this.panelCommunity.MinimumSize = new System.Drawing.Size(0, 300);
            this.panelCommunity.Name = "panelCommunity";
            this.panelCommunity.Padding = new System.Windows.Forms.Padding(10);
            this.panelCommunity.Size = new System.Drawing.Size(384, 350);
            this.panelCommunity.TabIndex = 9;
            this.panelCommunity.Visible = false;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.btnDeleteCommunity, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.btnAddCommunity, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.btnCommunityInfo, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(10, 210);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.MaximumSize = new System.Drawing.Size(0, 130);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(364, 130);
            this.tableLayoutPanel7.TabIndex = 12;
            // 
            // btnDeleteCommunity
            // 
            this.btnDeleteCommunity.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(144)))), ((int)(((byte)(122)))));
            this.btnDeleteCommunity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnDeleteCommunity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteCommunity.BorderRadius = 0;
            this.btnDeleteCommunity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnDeleteCommunity.ButtonText = "Удалить сообщество";
            this.btnDeleteCommunity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteCommunity.DisabledColor = System.Drawing.Color.Gainsboro;
            this.btnDeleteCommunity.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDeleteCommunity.Enabled = false;
            this.btnDeleteCommunity.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDeleteCommunity.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDeleteCommunity.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnDeleteCommunity.Iconimage")));
            this.btnDeleteCommunity.Iconimage_right = null;
            this.btnDeleteCommunity.Iconimage_right_Selected = null;
            this.btnDeleteCommunity.Iconimage_Selected = null;
            this.btnDeleteCommunity.IconMarginLeft = 0;
            this.btnDeleteCommunity.IconMarginRight = 0;
            this.btnDeleteCommunity.IconRightVisible = true;
            this.btnDeleteCommunity.IconRightZoom = 0D;
            this.btnDeleteCommunity.IconVisible = true;
            this.btnDeleteCommunity.IconZoom = 40D;
            this.btnDeleteCommunity.IsTab = false;
            this.btnDeleteCommunity.Location = new System.Drawing.Point(0, 95);
            this.btnDeleteCommunity.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteCommunity.Name = "btnDeleteCommunity";
            this.btnDeleteCommunity.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnDeleteCommunity.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(103)))), ((int)(((byte)(88)))));
            this.btnDeleteCommunity.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDeleteCommunity.Padding = new System.Windows.Forms.Padding(5);
            this.btnDeleteCommunity.selected = false;
            this.btnDeleteCommunity.Size = new System.Drawing.Size(364, 35);
            this.btnDeleteCommunity.TabIndex = 9;
            this.btnDeleteCommunity.Text = "Удалить сообщество";
            this.btnDeleteCommunity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeleteCommunity.Textcolor = System.Drawing.Color.Black;
            this.btnDeleteCommunity.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnAddCommunity
            // 
            this.btnAddCommunity.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnAddCommunity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnAddCommunity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddCommunity.BorderRadius = 0;
            this.btnAddCommunity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnAddCommunity.ButtonText = "Добавить новое сообщество";
            this.btnAddCommunity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCommunity.DisabledColor = System.Drawing.Color.Gainsboro;
            this.btnAddCommunity.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddCommunity.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddCommunity.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAddCommunity.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnAddCommunity.Iconimage")));
            this.btnAddCommunity.Iconimage_right = null;
            this.btnAddCommunity.Iconimage_right_Selected = null;
            this.btnAddCommunity.Iconimage_Selected = null;
            this.btnAddCommunity.IconMarginLeft = 0;
            this.btnAddCommunity.IconMarginRight = 0;
            this.btnAddCommunity.IconRightVisible = true;
            this.btnAddCommunity.IconRightZoom = 0D;
            this.btnAddCommunity.IconVisible = true;
            this.btnAddCommunity.IconZoom = 40D;
            this.btnAddCommunity.IsTab = false;
            this.btnAddCommunity.Location = new System.Drawing.Point(0, 52);
            this.btnAddCommunity.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddCommunity.Name = "btnAddCommunity";
            this.btnAddCommunity.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnAddCommunity.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(103)))), ((int)(((byte)(88)))));
            this.btnAddCommunity.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAddCommunity.Padding = new System.Windows.Forms.Padding(5);
            this.btnAddCommunity.selected = false;
            this.btnAddCommunity.Size = new System.Drawing.Size(364, 35);
            this.btnAddCommunity.TabIndex = 11;
            this.btnAddCommunity.Text = "Добавить новое сообщество";
            this.btnAddCommunity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddCommunity.Textcolor = System.Drawing.Color.Black;
            this.btnAddCommunity.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCommunity.Click += new System.EventHandler(this.btnAddCommunity_Click);
            // 
            // btnCommunityInfo
            // 
            this.btnCommunityInfo.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnCommunityInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnCommunityInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCommunityInfo.BorderRadius = 0;
            this.btnCommunityInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnCommunityInfo.ButtonText = "Подробнее о сообществе";
            this.btnCommunityInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCommunityInfo.DisabledColor = System.Drawing.Color.Gainsboro;
            this.btnCommunityInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCommunityInfo.Enabled = false;
            this.btnCommunityInfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCommunityInfo.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCommunityInfo.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnCommunityInfo.Iconimage")));
            this.btnCommunityInfo.Iconimage_right = null;
            this.btnCommunityInfo.Iconimage_right_Selected = null;
            this.btnCommunityInfo.Iconimage_Selected = null;
            this.btnCommunityInfo.IconMarginLeft = 0;
            this.btnCommunityInfo.IconMarginRight = 0;
            this.btnCommunityInfo.IconRightVisible = true;
            this.btnCommunityInfo.IconRightZoom = 0D;
            this.btnCommunityInfo.IconVisible = true;
            this.btnCommunityInfo.IconZoom = 40D;
            this.btnCommunityInfo.IsTab = false;
            this.btnCommunityInfo.Location = new System.Drawing.Point(0, 10);
            this.btnCommunityInfo.Margin = new System.Windows.Forms.Padding(0);
            this.btnCommunityInfo.Name = "btnCommunityInfo";
            this.btnCommunityInfo.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnCommunityInfo.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(103)))), ((int)(((byte)(88)))));
            this.btnCommunityInfo.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCommunityInfo.Padding = new System.Windows.Forms.Padding(5);
            this.btnCommunityInfo.selected = false;
            this.btnCommunityInfo.Size = new System.Drawing.Size(364, 35);
            this.btnCommunityInfo.TabIndex = 10;
            this.btnCommunityInfo.Text = "Подробнее о сообществе";
            this.btnCommunityInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCommunityInfo.Textcolor = System.Drawing.Color.Black;
            this.btnCommunityInfo.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommunityInfo.Click += new System.EventHandler(this.btnCommunityInfo_Click);
            // 
            // dgvCommunity
            // 
            this.dgvCommunity.AllowUserToAddRows = false;
            this.dgvCommunity.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCommunity.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCommunity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCommunity.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvCommunity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCommunity.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommunity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCommunity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommunity.ColumnHeadersVisible = false;
            this.dgvCommunity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.clmnLincCommunity});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCommunity.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCommunity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCommunity.DoubleBuffered = true;
            this.dgvCommunity.EnableHeadersVisualStyles = false;
            this.dgvCommunity.HeaderBgColor = System.Drawing.Color.LightGray;
            this.dgvCommunity.HeaderForeColor = System.Drawing.Color.Black;
            this.dgvCommunity.Location = new System.Drawing.Point(10, 27);
            this.dgvCommunity.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.dgvCommunity.MaximumSize = new System.Drawing.Size(0, 300);
            this.dgvCommunity.MinimumSize = new System.Drawing.Size(0, 200);
            this.dgvCommunity.Name = "dgvCommunity";
            this.dgvCommunity.ReadOnly = true;
            this.dgvCommunity.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCommunity.RowHeadersVisible = false;
            this.dgvCommunity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommunity.Size = new System.Drawing.Size(364, 300);
            this.dgvCommunity.TabIndex = 9;
            this.dgvCommunity.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCommunity_CellContentClick);
            this.dgvCommunity.SelectionChanged += new System.EventHandler(this.dgvCommunity_CellContentClick);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Список сообществ";
            // 
            // btnOpenCommunityPanel
            // 
            this.btnOpenCommunityPanel.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnOpenCommunityPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnOpenCommunityPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenCommunityPanel.BorderRadius = 0;
            this.btnOpenCommunityPanel.ButtonText = "Сообщества";
            this.btnOpenCommunityPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenCommunityPanel.DisabledColor = System.Drawing.Color.Gray;
            this.btnOpenCommunityPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpenCommunityPanel.Iconcolor = System.Drawing.Color.Transparent;
            this.btnOpenCommunityPanel.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnOpenCommunityPanel.Iconimage")));
            this.btnOpenCommunityPanel.Iconimage_right = null;
            this.btnOpenCommunityPanel.Iconimage_right_Selected = null;
            this.btnOpenCommunityPanel.Iconimage_Selected = null;
            this.btnOpenCommunityPanel.IconMarginLeft = 0;
            this.btnOpenCommunityPanel.IconMarginRight = 0;
            this.btnOpenCommunityPanel.IconRightVisible = true;
            this.btnOpenCommunityPanel.IconRightZoom = 0D;
            this.btnOpenCommunityPanel.IconVisible = true;
            this.btnOpenCommunityPanel.IconZoom = 50D;
            this.btnOpenCommunityPanel.IsTab = true;
            this.btnOpenCommunityPanel.Location = new System.Drawing.Point(0, 565);
            this.btnOpenCommunityPanel.Name = "btnOpenCommunityPanel";
            this.btnOpenCommunityPanel.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnOpenCommunityPanel.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnOpenCommunityPanel.OnHoverTextColor = System.Drawing.Color.White;
            this.btnOpenCommunityPanel.selected = false;
            this.btnOpenCommunityPanel.Size = new System.Drawing.Size(384, 33);
            this.btnOpenCommunityPanel.TabIndex = 8;
            this.btnOpenCommunityPanel.Text = "Сообщества";
            this.btnOpenCommunityPanel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenCommunityPanel.Textcolor = System.Drawing.Color.White;
            this.btnOpenCommunityPanel.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenCommunityPanel.Click += new System.EventHandler(this.btnOpenCommunityPanel_Click);
            // 
            // panelPeople
            // 
            this.panelPeople.Controls.Add(this.tableLayoutPanel6);
            this.panelPeople.Controls.Add(this.dgvPeople);
            this.panelPeople.Controls.Add(this.label1);
            this.panelPeople.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPeople.Location = new System.Drawing.Point(0, 165);
            this.panelPeople.Margin = new System.Windows.Forms.Padding(0);
            this.panelPeople.MinimumSize = new System.Drawing.Size(0, 300);
            this.panelPeople.Name = "panelPeople";
            this.panelPeople.Padding = new System.Windows.Forms.Padding(10);
            this.panelPeople.Size = new System.Drawing.Size(384, 400);
            this.panelPeople.TabIndex = 7;
            this.panelPeople.Visible = false;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.btnDeleteUser, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.btnUserInfo, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnAddUser, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(10, 260);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.MaximumSize = new System.Drawing.Size(0, 130);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(364, 130);
            this.tableLayoutPanel6.TabIndex = 9;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnDeleteUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnDeleteUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteUser.BorderRadius = 0;
            this.btnDeleteUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnDeleteUser.ButtonText = "Удалить пользователя";
            this.btnDeleteUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteUser.DisabledColor = System.Drawing.Color.Gainsboro;
            this.btnDeleteUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDeleteUser.Enabled = false;
            this.btnDeleteUser.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDeleteUser.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDeleteUser.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnDeleteUser.Iconimage")));
            this.btnDeleteUser.Iconimage_right = null;
            this.btnDeleteUser.Iconimage_right_Selected = null;
            this.btnDeleteUser.Iconimage_Selected = null;
            this.btnDeleteUser.IconMarginLeft = 0;
            this.btnDeleteUser.IconMarginRight = 0;
            this.btnDeleteUser.IconRightVisible = true;
            this.btnDeleteUser.IconRightZoom = 0D;
            this.btnDeleteUser.IconVisible = true;
            this.btnDeleteUser.IconZoom = 40D;
            this.btnDeleteUser.IsTab = false;
            this.btnDeleteUser.Location = new System.Drawing.Point(0, 95);
            this.btnDeleteUser.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnDeleteUser.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(103)))), ((int)(((byte)(88)))));
            this.btnDeleteUser.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDeleteUser.Padding = new System.Windows.Forms.Padding(5);
            this.btnDeleteUser.selected = false;
            this.btnDeleteUser.Size = new System.Drawing.Size(364, 35);
            this.btnDeleteUser.TabIndex = 9;
            this.btnDeleteUser.Text = "Удалить пользователя";
            this.btnDeleteUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeleteUser.Textcolor = System.Drawing.Color.Black;
            this.btnDeleteUser.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnUserInfo
            // 
            this.btnUserInfo.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnUserInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnUserInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUserInfo.BorderRadius = 0;
            this.btnUserInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnUserInfo.ButtonText = "Подробнее о пользователе";
            this.btnUserInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserInfo.DisabledColor = System.Drawing.Color.Gainsboro;
            this.btnUserInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUserInfo.Enabled = false;
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
            this.btnUserInfo.Location = new System.Drawing.Point(0, 10);
            this.btnUserInfo.Margin = new System.Windows.Forms.Padding(0);
            this.btnUserInfo.Name = "btnUserInfo";
            this.btnUserInfo.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnUserInfo.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(103)))), ((int)(((byte)(88)))));
            this.btnUserInfo.OnHoverTextColor = System.Drawing.Color.White;
            this.btnUserInfo.Padding = new System.Windows.Forms.Padding(5);
            this.btnUserInfo.selected = false;
            this.btnUserInfo.Size = new System.Drawing.Size(364, 35);
            this.btnUserInfo.TabIndex = 4;
            this.btnUserInfo.Text = "Подробнее о пользователе";
            this.btnUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUserInfo.Textcolor = System.Drawing.Color.Black;
            this.btnUserInfo.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserInfo.Click += new System.EventHandler(this.btnUserInfo_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnAddUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddUser.BorderRadius = 0;
            this.btnAddUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnAddUser.ButtonText = "Добавить нового пользователя";
            this.btnAddUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddUser.DisabledColor = System.Drawing.Color.Gainsboro;
            this.btnAddUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddUser.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddUser.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAddUser.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnAddUser.Iconimage")));
            this.btnAddUser.Iconimage_right = null;
            this.btnAddUser.Iconimage_right_Selected = null;
            this.btnAddUser.Iconimage_Selected = null;
            this.btnAddUser.IconMarginLeft = 0;
            this.btnAddUser.IconMarginRight = 0;
            this.btnAddUser.IconRightVisible = true;
            this.btnAddUser.IconRightZoom = 0D;
            this.btnAddUser.IconVisible = true;
            this.btnAddUser.IconZoom = 40D;
            this.btnAddUser.IsTab = false;
            this.btnAddUser.Location = new System.Drawing.Point(0, 52);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnAddUser.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(103)))), ((int)(((byte)(88)))));
            this.btnAddUser.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAddUser.Padding = new System.Windows.Forms.Padding(5);
            this.btnAddUser.selected = false;
            this.btnAddUser.Size = new System.Drawing.Size(364, 35);
            this.btnAddUser.TabIndex = 8;
            this.btnAddUser.Text = "Добавить нового пользователя";
            this.btnAddUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddUser.Textcolor = System.Drawing.Color.Black;
            this.btnAddUser.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // dgvPeople
            // 
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPeople.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPeople.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPeople.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvPeople.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPeople.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPeople.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.ColumnHeadersVisible = false;
            this.dgvPeople.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmnNameUser,
            this.ClmnUrlUser});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPeople.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPeople.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPeople.DoubleBuffered = true;
            this.dgvPeople.EnableHeadersVisualStyles = false;
            this.dgvPeople.HeaderBgColor = System.Drawing.Color.LightGray;
            this.dgvPeople.HeaderForeColor = System.Drawing.Color.Black;
            this.dgvPeople.Location = new System.Drawing.Point(10, 27);
            this.dgvPeople.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.dgvPeople.MaximumSize = new System.Drawing.Size(0, 300);
            this.dgvPeople.MinimumSize = new System.Drawing.Size(0, 200);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.ReadOnly = true;
            this.dgvPeople.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPeople.RowHeadersVisible = false;
            this.dgvPeople.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeople.Size = new System.Drawing.Size(364, 300);
            this.dgvPeople.TabIndex = 6;
            this.dgvPeople.SelectionChanged += new System.EventHandler(this.dgvPeople_SelectionChanged);
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
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Список пользователей";
            // 
            // btnOpenPeoplePanel
            // 
            this.btnOpenPeoplePanel.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnOpenPeoplePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnOpenPeoplePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenPeoplePanel.BorderRadius = 0;
            this.btnOpenPeoplePanel.ButtonText = "Пользователи";
            this.btnOpenPeoplePanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenPeoplePanel.DisabledColor = System.Drawing.Color.Gray;
            this.btnOpenPeoplePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpenPeoplePanel.Iconcolor = System.Drawing.Color.Transparent;
            this.btnOpenPeoplePanel.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnOpenPeoplePanel.Iconimage")));
            this.btnOpenPeoplePanel.Iconimage_right = null;
            this.btnOpenPeoplePanel.Iconimage_right_Selected = null;
            this.btnOpenPeoplePanel.Iconimage_Selected = null;
            this.btnOpenPeoplePanel.IconMarginLeft = 0;
            this.btnOpenPeoplePanel.IconMarginRight = 0;
            this.btnOpenPeoplePanel.IconRightVisible = true;
            this.btnOpenPeoplePanel.IconRightZoom = 0D;
            this.btnOpenPeoplePanel.IconVisible = true;
            this.btnOpenPeoplePanel.IconZoom = 50D;
            this.btnOpenPeoplePanel.IsTab = true;
            this.btnOpenPeoplePanel.Location = new System.Drawing.Point(0, 132);
            this.btnOpenPeoplePanel.Name = "btnOpenPeoplePanel";
            this.btnOpenPeoplePanel.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnOpenPeoplePanel.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnOpenPeoplePanel.OnHoverTextColor = System.Drawing.Color.White;
            this.btnOpenPeoplePanel.selected = false;
            this.btnOpenPeoplePanel.Size = new System.Drawing.Size(384, 33);
            this.btnOpenPeoplePanel.TabIndex = 6;
            this.btnOpenPeoplePanel.Text = "Пользователи";
            this.btnOpenPeoplePanel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenPeoplePanel.Textcolor = System.Drawing.Color.White;
            this.btnOpenPeoplePanel.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenPeoplePanel.Click += new System.EventHandler(this.btnOpenPeoplePanel_Click);
            // 
            // panelLoadData
            // 
            this.panelLoadData.Controls.Add(this.btnLoadOntologyUsers);
            this.panelLoadData.Controls.Add(this.btnLoadLogUsers);
            this.panelLoadData.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLoadData.Location = new System.Drawing.Point(0, 33);
            this.panelLoadData.Margin = new System.Windows.Forms.Padding(0);
            this.panelLoadData.Name = "panelLoadData";
            this.panelLoadData.Padding = new System.Windows.Forms.Padding(10);
            this.panelLoadData.Size = new System.Drawing.Size(384, 99);
            this.panelLoadData.TabIndex = 5;
            // 
            // btnLoadOntologyUsers
            // 
            this.btnLoadOntologyUsers.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnLoadOntologyUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnLoadOntologyUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadOntologyUsers.BorderRadius = 0;
            this.btnLoadOntologyUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnLoadOntologyUsers.ButtonText = "Загрузить онтологию с  данными";
            this.btnLoadOntologyUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadOntologyUsers.DisabledColor = System.Drawing.Color.Gainsboro;
            this.btnLoadOntologyUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoadOntologyUsers.ForeColor = System.Drawing.Color.White;
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
            this.btnLoadOntologyUsers.Margin = new System.Windows.Forms.Padding(0);
            this.btnLoadOntologyUsers.Name = "btnLoadOntologyUsers";
            this.btnLoadOntologyUsers.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnLoadOntologyUsers.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(103)))), ((int)(((byte)(88)))));
            this.btnLoadOntologyUsers.OnHoverTextColor = System.Drawing.Color.White;
            this.btnLoadOntologyUsers.selected = false;
            this.btnLoadOntologyUsers.Size = new System.Drawing.Size(364, 35);
            this.btnLoadOntologyUsers.TabIndex = 2;
            this.btnLoadOntologyUsers.Text = "Загрузить онтологию с  данными";
            this.btnLoadOntologyUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLoadOntologyUsers.Textcolor = System.Drawing.Color.Black;
            this.btnLoadOntologyUsers.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadOntologyUsers.Click += new System.EventHandler(this.btnLoadOntologyUsers_Click);
            // 
            // btnLoadLogUsers
            // 
            this.btnLoadLogUsers.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnLoadLogUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnLoadLogUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadLogUsers.BorderRadius = 0;
            this.btnLoadLogUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnLoadLogUsers.ButtonText = "Загрузить логи с  поведением";
            this.btnLoadLogUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadLogUsers.DisabledColor = System.Drawing.Color.Gainsboro;
            this.btnLoadLogUsers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLoadLogUsers.Enabled = false;
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
            this.btnLoadLogUsers.Location = new System.Drawing.Point(10, 54);
            this.btnLoadLogUsers.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.btnLoadLogUsers.Name = "btnLoadLogUsers";
            this.btnLoadLogUsers.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnLoadLogUsers.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(103)))), ((int)(((byte)(88)))));
            this.btnLoadLogUsers.OnHoverTextColor = System.Drawing.Color.White;
            this.btnLoadLogUsers.selected = false;
            this.btnLoadLogUsers.Size = new System.Drawing.Size(364, 35);
            this.btnLoadLogUsers.TabIndex = 3;
            this.btnLoadLogUsers.Text = "Загрузить логи с  поведением";
            this.btnLoadLogUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLoadLogUsers.Textcolor = System.Drawing.Color.Black;
            this.btnLoadLogUsers.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadLogUsers.Click += new System.EventHandler(this.btnLoadLogUsers_Click);
            // 
            // btnOpenLoadDataPanel
            // 
            this.btnOpenLoadDataPanel.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnOpenLoadDataPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnOpenLoadDataPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenLoadDataPanel.BorderRadius = 0;
            this.btnOpenLoadDataPanel.ButtonText = "Загрузка данных";
            this.btnOpenLoadDataPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenLoadDataPanel.DisabledColor = System.Drawing.Color.Gray;
            this.btnOpenLoadDataPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpenLoadDataPanel.Iconcolor = System.Drawing.Color.Transparent;
            this.btnOpenLoadDataPanel.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnOpenLoadDataPanel.Iconimage")));
            this.btnOpenLoadDataPanel.Iconimage_right = null;
            this.btnOpenLoadDataPanel.Iconimage_right_Selected = null;
            this.btnOpenLoadDataPanel.Iconimage_Selected = null;
            this.btnOpenLoadDataPanel.IconMarginLeft = 0;
            this.btnOpenLoadDataPanel.IconMarginRight = 0;
            this.btnOpenLoadDataPanel.IconRightVisible = true;
            this.btnOpenLoadDataPanel.IconRightZoom = 0D;
            this.btnOpenLoadDataPanel.IconVisible = true;
            this.btnOpenLoadDataPanel.IconZoom = 50D;
            this.btnOpenLoadDataPanel.IsTab = true;
            this.btnOpenLoadDataPanel.Location = new System.Drawing.Point(0, 0);
            this.btnOpenLoadDataPanel.Name = "btnOpenLoadDataPanel";
            this.btnOpenLoadDataPanel.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnOpenLoadDataPanel.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnOpenLoadDataPanel.OnHoverTextColor = System.Drawing.Color.White;
            this.btnOpenLoadDataPanel.selected = false;
            this.btnOpenLoadDataPanel.Size = new System.Drawing.Size(384, 33);
            this.btnOpenLoadDataPanel.TabIndex = 4;
            this.btnOpenLoadDataPanel.Text = "Загрузка данных";
            this.btnOpenLoadDataPanel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenLoadDataPanel.Textcolor = System.Drawing.Color.White;
            this.btnOpenLoadDataPanel.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenLoadDataPanel.Click += new System.EventHandler(this.btnOpenLoadDataPanel_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripbtnSelect,
            this.toolStripbtnLink});
            this.toolStrip2.Location = new System.Drawing.Point(0, 4);
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
            this.tsRiht.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsRiht.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSimSetting});
            this.tsRiht.Location = new System.Drawing.Point(0, 3);
            this.tsRiht.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tsRiht.Name = "tsRiht";
            this.tsRiht.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsRiht.Size = new System.Drawing.Size(24, 211);
            this.tsRiht.TabIndex = 0;
            // 
            // tsBtnSimSetting
            // 
            this.tsBtnSimSetting.BackColor = System.Drawing.Color.Transparent;
            this.tsBtnSimSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnSimSetting.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSimSetting.Image")));
            this.tsBtnSimSetting.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsBtnSimSetting.Margin = new System.Windows.Forms.Padding(0);
            this.tsBtnSimSetting.Name = "tsBtnSimSetting";
            this.tsBtnSimSetting.Padding = new System.Windows.Forms.Padding(2);
            this.tsBtnSimSetting.Size = new System.Drawing.Size(22, 209);
            this.tsBtnSimSetting.Text = "Моделирование социальных сетей";
            this.tsBtnSimSetting.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            this.tsBtnSimSetting.ToolTipText = "Настройки моделирования";
            this.tsBtnSimSetting.Click += new System.EventHandler(this.tsBtnSimSetting_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstModelTime,
            this.toolStripbtnRun});
            this.toolStrip1.Location = new System.Drawing.Point(47, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(103, 32);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
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
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
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
            this.MainMenu.Location = new System.Drawing.Point(65, 4);
            this.MainMenu.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
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
            this.miFile.ForeColor = System.Drawing.Color.White;
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(48, 20);
            this.miFile.Text = "&Файл";
            this.miFile.DropDownClosed += new System.EventHandler(this.miDropDownClose);
            this.miFile.DropDownOpening += new System.EventHandler(this.miDropDownOpen);
            this.miFile.MouseEnter += new System.EventHandler(this.miMouseEnter);
            this.miFile.MouseLeave += new System.EventHandler(this.miMouseLeave);
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
            this.miEdit.ForeColor = System.Drawing.Color.White;
            this.miEdit.Name = "miEdit";
            this.miEdit.Size = new System.Drawing.Size(59, 20);
            this.miEdit.Text = "&Правка";
            this.miEdit.DropDownClosed += new System.EventHandler(this.miDropDownClose);
            this.miEdit.DropDownOpening += new System.EventHandler(this.miDropDownOpen);
            this.miEdit.MouseEnter += new System.EventHandler(this.miMouseEnter);
            this.miEdit.MouseLeave += new System.EventHandler(this.miMouseLeave);
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
            this.miModel.ForeColor = System.Drawing.Color.White;
            this.miModel.Name = "miModel";
            this.miModel.Size = new System.Drawing.Size(62, 20);
            this.miModel.Text = "&Модель";
            this.miModel.DropDownClosed += new System.EventHandler(this.miDropDownClose);
            this.miModel.DropDownOpening += new System.EventHandler(this.miDropDownOpen);
            this.miModel.MouseEnter += new System.EventHandler(this.miMouseEnter);
            this.miModel.MouseLeave += new System.EventHandler(this.miMouseLeave);
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
            this.miHelp.Checked = true;
            this.miHelp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAbout});
            this.miHelp.ForeColor = System.Drawing.Color.White;
            this.miHelp.Name = "miHelp";
            this.miHelp.Size = new System.Drawing.Size(65, 20);
            this.miHelp.Text = "&Справка";
            this.miHelp.DropDownClosed += new System.EventHandler(this.miDropDownClose);
            this.miHelp.DropDownOpening += new System.EventHandler(this.miDropDownOpen);
            this.miHelp.MouseEnter += new System.EventHandler(this.miMouseEnter);
            this.miHelp.MouseLeave += new System.EventHandler(this.miMouseLeave);
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(158, 22);
            this.miAbout.Text = "&О программе...";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pbMain, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStripContainer1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1677, 1000);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // pbMain
            // 
            this.pbMain.BackColor = System.Drawing.Color.LightGray;
            this.pbMain.BorderRadius = 0;
            this.pbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMain.Location = new System.Drawing.Point(0, 991);
            this.pbMain.Margin = new System.Windows.Forms.Padding(0);
            this.pbMain.MaximumValue = 100;
            this.pbMain.Name = "pbMain";
            this.pbMain.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(101)))), ((int)(((byte)(31)))));
            this.pbMain.Size = new System.Drawing.Size(1677, 9);
            this.pbMain.TabIndex = 6;
            this.pbMain.Value = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(51)))), ((int)(((byte)(0)))));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1677, 35);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // panelDrag
            // 
            this.panelDrag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDrag.Location = new System.Drawing.Point(313, 0);
            this.panelDrag.Margin = new System.Windows.Forms.Padding(0);
            this.panelDrag.Name = "panelDrag";
            this.panelDrag.Size = new System.Drawing.Size(1218, 35);
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
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1531, 0);
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
            this.btnClose.ForeColor = System.Drawing.Color.White;
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
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.color = System.Drawing.Color.Transparent;
            this.btnMinimize.colorActive = System.Drawing.Color.Silver;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
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
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 29);
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
            // btnMaximize
            // 
            this.btnMaximize.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMaximize.BackgroundImage")));
            this.btnMaximize.color = System.Drawing.Color.Transparent;
            this.btnMaximize.colorActive = System.Drawing.Color.Silver;
            this.btnMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximize.Font = new System.Drawing.Font("Century Gothic", 13.75F);
            this.btnMaximize.ForeColor = System.Drawing.Color.White;
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(1677, 1000);
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
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.scDraw.Panel1.ResumeLayout(false);
            this.scDraw.Panel1.PerformLayout();
            this.scDraw.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scDraw)).EndInit();
            this.scDraw.ResumeLayout(false);
            this.panelSna.ResumeLayout(false);
            this.tablePanelSna.ResumeLayout(false);
            this.panelSimulation.ResumeLayout(false);
            this.tablePanelSimulation.ResumeLayout(false);
            this.tablePanelSimulation.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panelCommunity.ResumeLayout(false);
            this.panelCommunity.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunity)).EndInit();
            this.panelPeople.ResumeLayout(false);
            this.panelPeople.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.panelLoadData.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripButton toolStripbtnGraphConst;
        private System.Windows.Forms.ToolStripButton toolStripBtnGraphs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panelDrag;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
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
        private Bunifu.Framework.UI.BunifuFlatButton btnLoadLogUsers;
        private Bunifu.Framework.UI.BunifuFlatButton btnUserInfo;
        private Bunifu.Framework.UI.BunifuFlatButton btnMakeNetwork;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvPeople;
        private System.Windows.Forms.OpenFileDialog ofdLoadOwl;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvCommunity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuFlatButton btnClearNetwork;
        private System.Windows.Forms.OpenFileDialog ofdLoadXes;
        private Bunifu.Framework.UI.BunifuProgressBar pbMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmnNameUser;
        private System.Windows.Forms.DataGridViewLinkColumn ClmnUrlUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewLinkColumn clmnLincCommunity;
        private System.Windows.Forms.Panel panelLoadData;
        private Bunifu.Framework.UI.BunifuFlatButton btnOpenLoadDataPanel;
        private System.Windows.Forms.Panel panelSimulation;
        private Bunifu.Framework.UI.BunifuFlatButton btnOpenSimulationSettings;
        private System.Windows.Forms.Panel panelCommunity;
        private Bunifu.Framework.UI.BunifuFlatButton btnCommunityInfo;
        private Bunifu.Framework.UI.BunifuFlatButton btnOpenCommunityPanel;
        private System.Windows.Forms.Panel panelPeople;
        private Bunifu.Framework.UI.BunifuFlatButton btnOpenPeoplePanel;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.TableLayoutPanel tablePanelSimulation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroDateTime dtpStart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroDateTime dtpFinish;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroCheckBox chbxIsBuildNetwork;
        private Bunifu.Framework.UI.BunifuFlatButton btnRunSimulation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private Bunifu.Framework.UI.BunifuFlatButton btnDeleteCommunity;
        private Bunifu.Framework.UI.BunifuFlatButton btnAddCommunity;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private Bunifu.Framework.UI.BunifuFlatButton btnDeleteUser;
        private MetroFramework.Controls.MetroTrackBar trbZoom;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.Label label9;
        private MetroFramework.Controls.MetroCheckBox chbIsShowAllRoutines;
        private System.Windows.Forms.TableLayoutPanel tablePanelSna;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton2;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton3;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton6;
        private Bunifu.Framework.UI.BunifuFlatButton btnEditIp;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton7;
        private System.Windows.Forms.Panel panelSna;
        private Bunifu.Framework.UI.BunifuFlatButton btnAddUser;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private Bunifu.Framework.UI.BunifuFlatButton btnEditMC;
        private Bunifu.Framework.UI.BunifuTileButton btnMaximize;
    }
}

