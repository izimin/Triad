namespace TriadNSim.Forms
{
    partial class frmReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.chbxIsBuildNetwork = new MetroFramework.Controls.MetroCheckBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddCommunity = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton2 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton3 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkDegreeCentrality = new System.Windows.Forms.CheckBox();
            this.checkEigenvectorCentrality = new System.Windows.Forms.CheckBox();
            this.checkClosenessCentrality = new System.Windows.Forms.CheckBox();
            this.checkBetweennessCentrality = new System.Windows.Forms.CheckBox();
            this.groupOther = new System.Windows.Forms.GroupBox();
            this.checkDegree = new System.Windows.Forms.CheckBox();
            this.checkClusteringCoefficient = new System.Windows.Forms.CheckBox();
            this.checkSCC = new System.Windows.Forms.CheckBox();
            this.checkOverallProperties = new System.Windows.Forms.CheckBox();
            this.groupShortestPath = new System.Windows.Forms.GroupBox();
            this.checkAllShortestPath = new System.Windows.Forms.CheckBox();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox2 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox3 = new MetroFramework.Controls.MetroCheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupOther.SuspendLayout();
            this.groupShortestPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.metroCheckBox3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.metroCheckBox2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.metroCheckBox1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 1, 10, 10);
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(736, 328);
            this.tableLayoutPanel1.TabIndex = 15;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "В отчет включать:";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.9404F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.0596F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tableLayoutPanel3.Controls.Add(this.bunifuFlatButton3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.bunifuFlatButton2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.chbxIsBuildNetwork, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(13, 25);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(710, 32);
            this.tableLayoutPanel3.TabIndex = 15;
            // 
            // chbxIsBuildNetwork
            // 
            this.chbxIsBuildNetwork.AutoSize = true;
            this.chbxIsBuildNetwork.BackColor = System.Drawing.Color.Transparent;
            this.chbxIsBuildNetwork.Checked = true;
            this.chbxIsBuildNetwork.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxIsBuildNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chbxIsBuildNetwork.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chbxIsBuildNetwork.Location = new System.Drawing.Point(3, 3);
            this.chbxIsBuildNetwork.Name = "chbxIsBuildNetwork";
            this.chbxIsBuildNetwork.Size = new System.Drawing.Size(291, 26);
            this.chbxIsBuildNetwork.Style = MetroFramework.MetroColorStyle.Silver;
            this.chbxIsBuildNetwork.TabIndex = 14;
            this.chbxIsBuildNetwork.Text = "структурные характеристики";
            this.chbxIsBuildNetwork.UseCustomBackColor = true;
            this.chbxIsBuildNetwork.UseSelectable = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.btnAddCommunity, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(10, 280);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(716, 351);
            this.tableLayoutPanel4.TabIndex = 17;
            // 
            // btnAddCommunity
            // 
            this.btnAddCommunity.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnAddCommunity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnAddCommunity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddCommunity.BorderRadius = 0;
            this.btnAddCommunity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnAddCommunity.ButtonText = "Сформировать отчет";
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
            this.btnAddCommunity.Location = new System.Drawing.Point(0, 0);
            this.btnAddCommunity.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddCommunity.Name = "btnAddCommunity";
            this.btnAddCommunity.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.btnAddCommunity.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(103)))), ((int)(((byte)(88)))));
            this.btnAddCommunity.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAddCommunity.Padding = new System.Windows.Forms.Padding(5);
            this.btnAddCommunity.selected = false;
            this.btnAddCommunity.Size = new System.Drawing.Size(716, 35);
            this.btnAddCommunity.TabIndex = 15;
            this.btnAddCommunity.Text = "Сформировать отчет";
            this.btnAddCommunity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddCommunity.Textcolor = System.Drawing.Color.Black;
            this.btnAddCommunity.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // bunifuFlatButton2
            // 
            this.bunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.bunifuFlatButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.bunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton2.BorderRadius = 0;
            this.bunifuFlatButton2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuFlatButton2.ButtonText = "Выделить все";
            this.bunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton2.DisabledColor = System.Drawing.Color.Gainsboro;
            this.bunifuFlatButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuFlatButton2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton2.Iconimage")));
            this.bunifuFlatButton2.Iconimage_right = null;
            this.bunifuFlatButton2.Iconimage_right_Selected = null;
            this.bunifuFlatButton2.Iconimage_Selected = null;
            this.bunifuFlatButton2.IconMarginLeft = 0;
            this.bunifuFlatButton2.IconMarginRight = 0;
            this.bunifuFlatButton2.IconRightVisible = true;
            this.bunifuFlatButton2.IconRightZoom = 0D;
            this.bunifuFlatButton2.IconVisible = true;
            this.bunifuFlatButton2.IconZoom = 40D;
            this.bunifuFlatButton2.IsTab = false;
            this.bunifuFlatButton2.Location = new System.Drawing.Point(297, 0);
            this.bunifuFlatButton2.Margin = new System.Windows.Forms.Padding(0);
            this.bunifuFlatButton2.Name = "bunifuFlatButton2";
            this.bunifuFlatButton2.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.bunifuFlatButton2.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(103)))), ((int)(((byte)(88)))));
            this.bunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton2.Padding = new System.Windows.Forms.Padding(5);
            this.bunifuFlatButton2.selected = false;
            this.bunifuFlatButton2.Size = new System.Drawing.Size(207, 32);
            this.bunifuFlatButton2.TabIndex = 16;
            this.bunifuFlatButton2.Text = "Выделить все";
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
            this.bunifuFlatButton3.ButtonText = "Снять выделение";
            this.bunifuFlatButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton3.DisabledColor = System.Drawing.Color.Gainsboro;
            this.bunifuFlatButton3.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuFlatButton3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuFlatButton3.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton3.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton3.Iconimage")));
            this.bunifuFlatButton3.Iconimage_right = null;
            this.bunifuFlatButton3.Iconimage_right_Selected = null;
            this.bunifuFlatButton3.Iconimage_Selected = null;
            this.bunifuFlatButton3.IconMarginLeft = 0;
            this.bunifuFlatButton3.IconMarginRight = 0;
            this.bunifuFlatButton3.IconRightVisible = true;
            this.bunifuFlatButton3.IconRightZoom = 0D;
            this.bunifuFlatButton3.IconVisible = true;
            this.bunifuFlatButton3.IconZoom = 40D;
            this.bunifuFlatButton3.IsTab = false;
            this.bunifuFlatButton3.Location = new System.Drawing.Point(504, 0);
            this.bunifuFlatButton3.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.bunifuFlatButton3.Name = "bunifuFlatButton3";
            this.bunifuFlatButton3.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(218)))), ((int)(((byte)(210)))));
            this.bunifuFlatButton3.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(103)))), ((int)(((byte)(88)))));
            this.bunifuFlatButton3.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton3.Padding = new System.Windows.Forms.Padding(5);
            this.bunifuFlatButton3.selected = false;
            this.bunifuFlatButton3.Size = new System.Drawing.Size(203, 32);
            this.bunifuFlatButton3.TabIndex = 17;
            this.bunifuFlatButton3.Text = "Снять выделение";
            this.bunifuFlatButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton3.Textcolor = System.Drawing.Color.Black;
            this.bunifuFlatButton3.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupShortestPath);
            this.panel1.Controls.Add(this.groupOther);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(13, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 114);
            this.panel1.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkDegreeCentrality);
            this.groupBox1.Controls.Add(this.checkEigenvectorCentrality);
            this.groupBox1.Controls.Add(this.checkClosenessCentrality);
            this.groupBox1.Controls.Add(this.checkBetweennessCentrality);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 110);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Центральность";
            // 
            // checkDegreeCentrality
            // 
            this.checkDegreeCentrality.AutoSize = true;
            this.checkDegreeCentrality.Checked = true;
            this.checkDegreeCentrality.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDegreeCentrality.Location = new System.Drawing.Point(11, 19);
            this.checkDegreeCentrality.Name = "checkDegreeCentrality";
            this.checkDegreeCentrality.Size = new System.Drawing.Size(153, 17);
            this.checkDegreeCentrality.TabIndex = 10;
            this.checkDegreeCentrality.Text = "Степень центральносьти";
            this.checkDegreeCentrality.UseVisualStyleBackColor = true;
            // 
            // checkEigenvectorCentrality
            // 
            this.checkEigenvectorCentrality.AutoSize = true;
            this.checkEigenvectorCentrality.Checked = true;
            this.checkEigenvectorCentrality.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkEigenvectorCentrality.Location = new System.Drawing.Point(11, 88);
            this.checkEigenvectorCentrality.Name = "checkEigenvectorCentrality";
            this.checkEigenvectorCentrality.Size = new System.Drawing.Size(211, 17);
            this.checkEigenvectorCentrality.TabIndex = 9;
            this.checkEigenvectorCentrality.Text = "Собственный вектор центральности";
            this.checkEigenvectorCentrality.UseVisualStyleBackColor = true;
            // 
            // checkClosenessCentrality
            // 
            this.checkClosenessCentrality.AutoSize = true;
            this.checkClosenessCentrality.Checked = true;
            this.checkClosenessCentrality.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkClosenessCentrality.Location = new System.Drawing.Point(11, 65);
            this.checkClosenessCentrality.Name = "checkClosenessCentrality";
            this.checkClosenessCentrality.Size = new System.Drawing.Size(159, 17);
            this.checkClosenessCentrality.TabIndex = 8;
            this.checkClosenessCentrality.Tag = "Степень связи со всеми остальными";
            this.checkClosenessCentrality.Text = "Плотность центральности";
            this.checkClosenessCentrality.UseVisualStyleBackColor = true;
            // 
            // checkBetweennessCentrality
            // 
            this.checkBetweennessCentrality.AutoSize = true;
            this.checkBetweennessCentrality.Checked = true;
            this.checkBetweennessCentrality.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBetweennessCentrality.Location = new System.Drawing.Point(11, 42);
            this.checkBetweennessCentrality.Name = "checkBetweennessCentrality";
            this.checkBetweennessCentrality.Size = new System.Drawing.Size(210, 17);
            this.checkBetweennessCentrality.TabIndex = 7;
            this.checkBetweennessCentrality.Tag = "Роль в обеспеч связей между различыми сегм сети";
            this.checkBetweennessCentrality.Text = "Центральность как посредничество";
            this.checkBetweennessCentrality.UseVisualStyleBackColor = true;
            // 
            // groupOther
            // 
            this.groupOther.Controls.Add(this.checkDegree);
            this.groupOther.Controls.Add(this.checkClusteringCoefficient);
            this.groupOther.Controls.Add(this.checkSCC);
            this.groupOther.Controls.Add(this.checkOverallProperties);
            this.groupOther.Location = new System.Drawing.Point(245, 3);
            this.groupOther.Name = "groupOther";
            this.groupOther.Size = new System.Drawing.Size(227, 110);
            this.groupOther.TabIndex = 13;
            this.groupOther.TabStop = false;
            this.groupOther.Text = "Разное";
            // 
            // checkDegree
            // 
            this.checkDegree.AutoSize = true;
            this.checkDegree.Checked = true;
            this.checkDegree.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDegree.Location = new System.Drawing.Point(11, 19);
            this.checkDegree.Name = "checkDegree";
            this.checkDegree.Size = new System.Drawing.Size(109, 17);
            this.checkDegree.TabIndex = 7;
            this.checkDegree.Text = "Степень вершин";
            this.checkDegree.UseVisualStyleBackColor = true;
            // 
            // checkClusteringCoefficient
            // 
            this.checkClusteringCoefficient.AutoSize = true;
            this.checkClusteringCoefficient.Checked = true;
            this.checkClusteringCoefficient.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkClusteringCoefficient.Location = new System.Drawing.Point(11, 63);
            this.checkClusteringCoefficient.Name = "checkClusteringCoefficient";
            this.checkClusteringCoefficient.Size = new System.Drawing.Size(176, 17);
            this.checkClusteringCoefficient.TabIndex = 2;
            this.checkClusteringCoefficient.Text = "Коэффициент кластеризации";
            this.checkClusteringCoefficient.UseVisualStyleBackColor = true;
            // 
            // checkSCC
            // 
            this.checkSCC.AutoSize = true;
            this.checkSCC.Checked = true;
            this.checkSCC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSCC.Location = new System.Drawing.Point(11, 41);
            this.checkSCC.Name = "checkSCC";
            this.checkSCC.Size = new System.Drawing.Size(176, 17);
            this.checkSCC.TabIndex = 1;
            this.checkSCC.Text = "Сильно связные компоненты";
            this.checkSCC.UseVisualStyleBackColor = true;
            // 
            // checkOverallProperties
            // 
            this.checkOverallProperties.AutoSize = true;
            this.checkOverallProperties.Checked = true;
            this.checkOverallProperties.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkOverallProperties.Location = new System.Drawing.Point(11, 86);
            this.checkOverallProperties.Name = "checkOverallProperties";
            this.checkOverallProperties.Size = new System.Drawing.Size(145, 17);
            this.checkOverallProperties.TabIndex = 0;
            this.checkOverallProperties.Text = "Общие характеристики";
            this.checkOverallProperties.UseVisualStyleBackColor = true;
            // 
            // groupShortestPath
            // 
            this.groupShortestPath.Controls.Add(this.checkAllShortestPath);
            this.groupShortestPath.Location = new System.Drawing.Point(478, 3);
            this.groupShortestPath.Name = "groupShortestPath";
            this.groupShortestPath.Size = new System.Drawing.Size(229, 110);
            this.groupShortestPath.TabIndex = 14;
            this.groupShortestPath.TabStop = false;
            this.groupShortestPath.Text = "Кратчайшее растояние";
            // 
            // checkAllShortestPath
            // 
            this.checkAllShortestPath.Checked = true;
            this.checkAllShortestPath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAllShortestPath.Location = new System.Drawing.Point(11, 19);
            this.checkAllShortestPath.Name = "checkAllShortestPath";
            this.checkAllShortestPath.Size = new System.Drawing.Size(211, 63);
            this.checkAllShortestPath.TabIndex = 13;
            this.checkAllShortestPath.Text = "Кратчайшее растояние между всеми элементами";
            this.checkAllShortestPath.UseVisualStyleBackColor = true;
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.metroCheckBox1.Checked = true;
            this.metroCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroCheckBox1.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBox1.Location = new System.Drawing.Point(13, 183);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(201, 29);
            this.metroCheckBox1.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroCheckBox1.TabIndex = 19;
            this.metroCheckBox1.Text = "результаты моделирования";
            this.metroCheckBox1.UseCustomBackColor = true;
            this.metroCheckBox1.UseSelectable = true;
            // 
            // metroCheckBox2
            // 
            this.metroCheckBox2.AutoSize = true;
            this.metroCheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.metroCheckBox2.Checked = true;
            this.metroCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroCheckBox2.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBox2.Location = new System.Drawing.Point(13, 218);
            this.metroCheckBox2.Name = "metroCheckBox2";
            this.metroCheckBox2.Size = new System.Drawing.Size(622, 19);
            this.metroCheckBox2.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroCheckBox2.TabIndex = 20;
            this.metroCheckBox2.Text = "результаты информационных процедур";
            this.metroCheckBox2.UseCustomBackColor = true;
            this.metroCheckBox2.UseSelectable = true;
            // 
            // metroCheckBox3
            // 
            this.metroCheckBox3.AutoSize = true;
            this.metroCheckBox3.BackColor = System.Drawing.Color.Transparent;
            this.metroCheckBox3.Checked = true;
            this.metroCheckBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroCheckBox3.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBox3.Location = new System.Drawing.Point(13, 245);
            this.metroCheckBox3.Name = "metroCheckBox3";
            this.metroCheckBox3.Size = new System.Drawing.Size(585, 24);
            this.metroCheckBox3.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroCheckBox3.TabIndex = 20;
            this.metroCheckBox3.Text = "результаты применения алгоритмов распространения информации";
            this.metroCheckBox3.UseCustomBackColor = true;
            this.metroCheckBox3.UseSelectable = true;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 328);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Формирование отчета";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupOther.ResumeLayout(false);
            this.groupOther.PerformLayout();
            this.groupShortestPath.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private MetroFramework.Controls.MetroCheckBox chbxIsBuildNetwork;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Bunifu.Framework.UI.BunifuFlatButton btnAddCommunity;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton3;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkDegreeCentrality;
        private System.Windows.Forms.CheckBox checkEigenvectorCentrality;
        private System.Windows.Forms.CheckBox checkClosenessCentrality;
        private System.Windows.Forms.CheckBox checkBetweennessCentrality;
        private System.Windows.Forms.GroupBox groupOther;
        private System.Windows.Forms.CheckBox checkDegree;
        private System.Windows.Forms.CheckBox checkClusteringCoefficient;
        private System.Windows.Forms.CheckBox checkSCC;
        private System.Windows.Forms.CheckBox checkOverallProperties;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox2;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private System.Windows.Forms.GroupBox groupShortestPath;
        private System.Windows.Forms.CheckBox checkAllShortestPath;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox3;
    }
}