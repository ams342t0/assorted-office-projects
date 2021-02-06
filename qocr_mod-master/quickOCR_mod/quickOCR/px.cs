using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Imaging;


namespace quickOCR{

    public partial class px : Form
    {
        String outstring;
        Graphics g;
        System.Drawing.Image src;
        private int width, height;
        private int blk_w, blk_h;
        AForge.Imaging.Filters.GaussianBlur gb;
        AForge.Imaging.Filters.ContrastCorrection cc;
        AForge.Imaging.Filters.BrightnessCorrection bc;
        Bitmap img;
        
        public px()
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

            try
            {
                src = Program.pbitmap;
                draw_image();
            }
            catch (Exception xk)
            {
                MessageBox.Show("Error displaying source");
                this.Close();
            }

        }


        private void draw_grid()
        {
            Pen p;
            p = new Pen(Color.White, (int)weight.Value);


            for (int iy = 0; iy < Program.srows; iy++)
                g.DrawLine(p, 0, iy * blk_h, width, iy * blk_h);

            g.DrawLine(p, 0, height - 1, width, height - 1);

            for (int ix = 0; ix < Program.scolumns; ix++)
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
            blk_w = width / Program.scolumns;
            blk_h = height / Program.srows;

            g = Graphics.FromImage(pictureBox1.Image);

            gb.Size = 2;
            cc.Factor = 40;
            bc.AdjustValue = -20;

            g.FillRectangle(Brushes.White, pictureBox1.DisplayRectangle);
            g.DrawImage((System.Drawing.Image)(cc.Apply(bc.Apply(gb.Apply((Bitmap)src)))), new Rectangle(0, 0, width, height), new Rectangle(0, 0, src.Width, src.Height), GraphicsUnit.Pixel);

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


        private void pATTERNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float k;

            outstring = "";
            draw_image();
            for (int y = 0; y < Program.srows; y++)
            {
                for (int x = 0; x < Program.scolumns; x++)
                {
                    k = test_block(x * blk_w, y * blk_h);

                    if (k < (float)th.Value)
                    {
                        outstring += "1";
                        draw_rect(x * blk_w, y * blk_h);
                    }
                    else
                        outstring += "0";
  
                }
                outstring += "\n";
            }

            try
            {
                Clipboard.SetText(outstring);
                MessageBox.Show("Pattern copied to clipboard");
            }
            catch (Exception kx)
            {
                MessageBox.Show("Error copying");
            }
        }

        private void cOPYPATTERNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(outstring);
            }
            catch (Exception kx)
            {
                MessageBox.Show("Error copying");
            }
        }

    }

}
