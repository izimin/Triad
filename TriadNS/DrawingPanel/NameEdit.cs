using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingPanel
{
    public class NameEdit : TextBox
    {
        private BaseObject obj;
        private DrawingPanel drawingPanel;
        private Size minSize;

        public NameEdit(DrawingPanel panel)
        {
            Graphics g = CreateGraphics();
            SizeF sz = g.MeasureString("A", Font);
            minSize.Width = (int)sz.Width + Margin.Horizontal;
            minSize.Height = (int)sz.Height + Margin.Vertical;
            g.Dispose();
            this.drawingPanel = panel;
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        public void Edit(BaseObject obj)
        {
            if (obj == null)
                return;
            this.obj = obj;
            if (obj is ImgBox)
            {
                Font = new Font("Arial", 8 * drawingPanel.Zoom);
                ImgBox imgBox = obj as ImgBox;
                this.Location = new Point((int)(obj.getX() * drawingPanel.Zoom), (int)(obj.getY1() * drawingPanel.Zoom));
                this.Text = obj.Name;
                Visible = true;
                UpdateSize();
                Focus();
            }
        }

        private void UpdateSize()
        {
            Graphics g = CreateGraphics();
            SizeF sz = g.MeasureString(Text, Font);
            Size NewSz = new Size((int)(sz.Width + 0.5f) + Margin.Horizontal, (int)(sz.Height + 0.5f) + Margin.Vertical);
            if (NewSz.Width < minSize.Width)
                NewSz.Width = minSize.Width;
            if (NewSz.Height < minSize.Height)
                NewSz.Height = minSize.Height;
            this.Size = NewSz;
            g.Dispose();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            UpdateSize();
            base.OnTextChanged(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Visible = false;
                drawingPanel.Focus();
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                SaveValue();
                return;
            }
            base.OnKeyDown(e);
        }

        public bool SaveValue()
        {
            if (!Visible)
                return false;

            if (Text.Trim() == string.Empty)
            {
                MessageBox.Show("Введите имя");
                return false;
            }

            foreach (BaseObject shape in drawingPanel.Shapes)
            {
                if (shape == obj)
                    continue;
                if (shape.Name == this.Text.Trim())
                {
                    MessageBox.Show("Такое имя уже существует");
                    this.SelectAll();
                    return false;
                }
            }

            obj.Name = this.Text.Trim();
            this.Visible = false;
            drawingPanel.Focus();
            return true;
        }
    }
}
