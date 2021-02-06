using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace lazymail
{
	public partial class picview : Form
	{
		public string fpath;
		Point p1, p2, s1;

		public picview()
		{
			InitializeComponent();
		}

		private void picview_Deactivate(object sender, EventArgs e)
		{
		//	this.Visible = false;
		}


		public void redo()
		{
			Text = fpath;
			flipH.Checked = false;
			flipV.Checked = false;
			s1 = new Point(0, 30);
			p1 = new Point(0, 0);
			p2 = new Point(0, 0);
			Invalidate();
		}

		private void picview_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				Bitmap b = new Bitmap(fpath);
				e.Graphics.Clear(Color.White);
                if (rotleft.Checked)
                    b.RotateFlip(RotateFlipType.Rotate270FlipNone);
                if (rotright.Checked)
                    b.RotateFlip(RotateFlipType.Rotate90FlipNone);
				if (flipH.Checked)
					b.RotateFlip(RotateFlipType.Rotate180FlipY);
				if (flipV.Checked)
					b.RotateFlip(RotateFlipType.Rotate180FlipX);
				if (zoom.Checked)
					e.Graphics.DrawImage(b, s1.X + p2.X - p1.X, s1.Y + p2.Y - p1.Y,b.Width,b.Height);
				else
					e.Graphics.DrawImage(b, s1.X+p2.X-p1.X,s1.Y+p2.Y-p1.Y, this.Width, this.Height);
			}
			catch (Exception x)
			{
                //if (Path.GetExtension(fpath).ToUpper().Equals(".PDF"))
                System.Diagnostics.Process.Start(fpath);
                this.Close();
			}
		}

		private void flipH_Click(object sender, EventArgs e)
		{
			Invalidate();
		}

		private void flipV_Click(object sender, EventArgs e)
		{
			Invalidate();
		}

		private void zoom_Click(object sender, EventArgs e)
		{
			s1.X = 0;
			s1.Y = 30;
			p1.X = 0;
			p1.Y = 0;
			p2.X = 0;
			p2.Y = 0;
            zoom.Checked = false;
            flipH.Checked = false;
            flipV.Checked = false;
            rotleft.Checked = false;
            rotright.Checked = false;
			Invalidate();
		}

		private void picview_MouseDown(object sender, MouseEventArgs e)
		{
			p1 = e.Location;
		}

		private void picview_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				p2 = e.Location;
			}
		}

		private void picview_MouseUp(object sender, MouseEventArgs e)
		{
			s1.X += (p2.X - p1.X);
			s1.Y += (p2.Y - p1.Y);
			Invalidate();
		}

        private void rotleft_Click(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void rotright_Click(object sender, EventArgs e)
        {
            Invalidate();
        }
	}
}
