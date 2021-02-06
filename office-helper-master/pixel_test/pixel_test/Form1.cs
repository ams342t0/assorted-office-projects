using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Imaging;


namespace pixel_test
{
    public partial class Form1 : Form
    {
        Graphics g;
        System.Drawing.Image src;
        private int width, height;
        private int blk_w, blk_h;
        AForge.Imaging.Filters.GaussianBlur gb;
        AForge.Imaging.Filters.ContrastCorrection cc;
        AForge.Imaging.Filters.BrightnessCorrection bc;
        Bitmap img;
        
        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            gb = new AForge.Imaging.Filters.GaussianBlur();
            cc = new AForge.Imaging.Filters.ContrastCorrection();
            bc = new AForge.Imaging.Filters.BrightnessCorrection();

            th.Minimum = 0;
            th.Maximum = 277695;
            th.Value = 270000;
        }


        private void draw_grid()
        {
            Pen p;
            p = new Pen(Color.White, 20);


            for (int iy = 0; iy < 9; iy++)
                g.DrawLine(p, 0, iy * blk_h, width, iy * blk_h);

            g.DrawLine(p, 0, height - 1, width, height - 1);

            for (int ix = 0; ix < 9; ix++)
                g.DrawLine(p, ix * blk_w, 0, ix * blk_w, height);
            g.DrawLine(p, width - 1, 0, width - 1, height - 1);

        }

        private void draw_rect(int x, int y)
        {
            Pen p;
            p = new Pen(Color.Red, 2);
            g.DrawRectangle(p, new Rectangle(x+10,y+10,blk_w-20,blk_h-20));
        }


        private void draw_image()
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            img = (Bitmap)pictureBox1.Image;
            width = img.Width;
            height = img.Height;
            blk_w = width / 9;
            blk_h = height / 9;

            g = Graphics.FromImage(pictureBox1.Image);

            gb.Size = 2;
            cc.Factor = 40;
            bc.AdjustValue = -20;

            g.FillRectangle(Brushes.White, pictureBox1.DisplayRectangle);
            g.DrawImage((System.Drawing.Image)(cc.Apply(bc.Apply(gb.Apply((Bitmap)src)))), new Rectangle(0, 0, width, height), new Rectangle(0, 0, src.Width, src.Height), GraphicsUnit.Pixel);

            if (grid.Checked)
                draw_grid();
        }

        private float test_block(int x, int y)
        {
            Color c;
            float int_total=0.0f;

            if ((x + blk_w) > width)
                blk_w = width - x;

            if ((y + blk_h) > height)
                blk_h = height - y;

            for (int py = y; py < (y+blk_h);py++)
                for (int px = x; px < (x+blk_w); px++)
                {
                    c = img.GetPixel(px, py);
                    int_total += (float)(c.R * 0.3f + c.G * 0.6f + c.B * 0.1f);
                }

            return int_total;
        }


        private void fILEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPG|*.JPG|JPEG|*.JPEG|BITMAP|*.BMP|PNG|*.PNG";
            
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                src = System.Drawing.Image.FromFile(openFileDialog1.FileName);
                draw_image();
            }
        }

        private void pATTERNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float k;

            label1.Text = "";
            draw_image();
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    k = test_block(x * blk_w, y * blk_h);

                    if (k < (float)th.Value)
                    {
                        label1.Text += "1";
                        draw_rect(x * blk_w, y * blk_h);
                    }
                    else
                        label1.Text += "0";
  
                }
                label1.Text += "\n";
            }

            try
            {
                Clipboard.SetText(label1.Text);
            }
            catch (Exception kx)
            {
                MessageBox.Show("Error copying");
            }
        }

        private void dUMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float k;

            label1.Text = "";

            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    k = test_block(x * blk_w, y * blk_h);
                    if (k<(float)th.Value)
                        label1.Text += "["+Math.Round(k/1000,2).ToString() + "],";
                    else
                        label1.Text += Math.Round(k / 1000, 2).ToString() + "  ,  ";
                }
                label1.Text += "\n";
            }


        }

        private void cOPYPATTERNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(label1.Text);
            }
            catch (Exception kx)
            {
                MessageBox.Show("Error copying");
            }
        }

        private void cLIPBOARDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                src = Clipboard.GetImage();
                draw_image();
            }
            catch (Exception xk)
            {
                MessageBox.Show("clipboard empty!");
            }
        }

        private void grid_CheckedChanged(object sender, EventArgs e)
        {
//            draw_image();
        }
    }

}
