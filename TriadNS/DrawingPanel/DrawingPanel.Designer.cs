namespace DrawingPanel
{
    partial class DrawingPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DrawingPanel
            // 
            this.AllowDrop = true;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(1024, 768);
            this.BackColor = System.Drawing.Color.White;
            this.Name = "DrawingPanel";
            this.Size = new System.Drawing.Size(1000, 1000);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DrawingPanel_Scroll);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingPanel_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DrawingPanel_KeyDown);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DrawingPanel_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawingPanel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingPanel_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawingPanel_MouseUp);
            this.Resize += new System.EventHandler(this.DrawingPanel_Resize);
            this.ResumeLayout(false);

        }

        #endregion


    }
}
