using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ads
{
    public partial class Form1 : Form
    {
        int nf;
        int pid;
        Boolean playing = false;
        output of;
        BufferedGraphics bg;
        BufferedGraphicsContext bgc;
        Graphics g;
        Image imgsrc;
        float ar;
        int px, py;

        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Minimum = 1000;
            numericUpDown1.Maximum = 100000;
            numericUpDown1.Value = 1000;
            owidth.Minimum = 320;
            owidth.Maximum = 1920;
            oheight.Minimum = 240;
            oheight.Maximum = 1280;
            owidth.Value = 800;
            oheight.Value = 600;
            offsetX.Minimum = -10000;
            offsetX.Maximum = 10000;
            offsetY.Minimum = -10000;
            offsetY.Maximum = 10000;
            offsetX.Value = 0;
            offsetY.Value = 0;
            of = new output();
            bgc= BufferedGraphicsManager.Current;
            
        }

        private void mnuaddfiles_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPEG|*.jpg|JPEG|*jpeg|BITMAP|*.BMP";
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                nf = openFileDialog1.FileNames.Length;
                if (nf > 0)
                {
                    for (int i = 0; i < nf; i++)
                    {
                        listpictures.Items.Add(openFileDialog1.FileNames[i]);
                    }
                }
            }

            
        }

        private void mnuStartStop_Click(object sender, EventArgs e)
        {

            if (listpictures.Items.Count == 0) return;

            timer1.Interval = 1;

            if (!playing)
            {
                timer1.Start();
                mnuStartStop.Text = "Stop";
                pid = 0;
                of.Show();
            }
            else
            {
                timer1.Stop();
                mnuStartStop.Text = "Start";
                of.Hide();
            }

            playing = !playing;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (playing)
            {
                timer1.Interval = (int)numericUpDown1.Value;
                imgsrc = Image.FromFile((string)listpictures.Items[pid]);
                pictureBox1.Image = imgsrc;
                resizeoutput();
                pid++;
                if (pid == listpictures.Items.Count) pid = 0;
            }
        }

        void resizeoutput()
        {
            if (bg != null) bg.Dispose();
            ar = (float)imgsrc.Width / (float)imgsrc.Height;

            if (ar > 1.0f)
            {
                if (imgsrc.Width > owidth.Value) of.Width = (int)owidth.Value;
                else  of.Width = imgsrc.Width;
                of.Height = (int)(of.Width / ar);
            }
            else
            {
                if (imgsrc.Height > oheight.Value)
                {
                    if (imgsrc.Height > oheight.Value) of.Height = (int)oheight.Value;
                    else of.Height = imgsrc.Height;
                    of.Width = (int)(of.Height * ar);
                }
            }
            px = (int)((owidth.Value - of.Width) / 2);
            py = (int)((oheight.Value - of.Height) / 2);
            of.Left = px + (int)offsetX.Value;
            of.Top = py + (int)offsetY.Value;
            bg = bgc.Allocate(of.CreateGraphics(), of.DisplayRectangle);
            g = bg.Graphics;
            g.DrawImage(imgsrc, of.DisplayRectangle);
            bg.Render();
            
        }
    }
}
