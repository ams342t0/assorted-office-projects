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
        private Bitmap src;
        private int width, height;
        private int blk_w, blk_h;
        private Bitmap img;
        
        
        public Form1()
        {

            
            InitializeComponent();
            //src = new Bitmap(@"d:\source.png");
            init();
        }

        private void init()
        {
            Graphics g;
            System.Drawing.Image src;
            Pen p;

            AForge.Imaging.Filters.GaussianBlur gb;
            AForge.Imaging.Filters.ContrastCorrection cc;
            AForge.Imaging.Filters.BrightnessCorrection bc;
            AForge.Imaging.Filters.Threshold th;

            gb = new AForge.Imaging.Filters.GaussianBlur();
            cc = new AForge.Imaging.Filters.ContrastCorrection();
            bc = new AForge.Imaging.Filters.BrightnessCorrection();
            th = new AForge.Imaging.Filters.Threshold();


            // load image source
            src = System.Drawing.Image.FromFile(@"d:\source.png");


            gb.Size = 2;
            cc.Factor = 40;
            bc.AdjustValue = -30;

            src = (System.Drawing.Image)(cc.Apply(bc.Apply(gb.Apply((Bitmap)src))));
            
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height,System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            g = Graphics.FromImage(pictureBox1.Image);

            img = (Bitmap)pictureBox1.Image;

            width = img.Width;
            height = img.Height;
            blk_w = width / 9;
            blk_h = height / 9;

            g.FillRectangle(Brushes.White, pictureBox1.DisplayRectangle);
            g.DrawImage(src, new Rectangle(0,0,pictureBox1.Width, pictureBox1.Height), new Rectangle(0,0,src.Width, src.Height), GraphicsUnit.Pixel);
            
            p = new Pen(Color.White, 20);
            
            
            for (int iy = 0; iy <9; iy++)
                g.DrawLine(p, 0, iy * blk_h, width, iy * blk_h);

            g.DrawLine(p, 0, height-1, width, height-1);

            for(int ix=0;ix<9;ix++)
                g.DrawLine(p, ix*blk_w, 0, ix*blk_w,height);
            g.DrawLine(p, width-1, 0, width-1, height - 1);
            
            
            // init destination image
            // set destination width and height
            
            textBox1.Text = "290000";

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            show_status();
        }

        private void show_status()
        {
        }

        private void test_table()
        {
            float k;


            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    k = test_block(x * blk_w, y * blk_h);


                    if (checkBox1.Checked)
                        label1.Text += k.ToString() + ",";
                    else
                    {
                        
                        if (k < float.Parse(textBox1.Text))
                            label1.Text += "1";
                        else
                            label1.Text += "0";
                    }
                     
                    
                }
                label1.Text += "\n";
            }

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

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Text = "";
            test_table();
        }
    }

}
