using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Diagnostics;
using System.IO;


namespace quickOCR
{
    public partial class Form1 : Form
    {
        FilterInfoCollection fic;
        VideoCaptureDevice vcd;
        Bitmap cam_bmp,sel_bmp,show_bmp;
        int x1, y1, x2, y2,sx,sy;
        float fx, fy;
        BufferedGraphics bg;
        BufferedGraphicsContext bgc;
        ContrastCorrection cc;
        BrightnessCorrection bc;
        Grayscale gs;
        bool snap_ready=false;
        int frame_count = 0;
        Graphics g;
        Pen grid,marker;
        Delegate del_convert;
        public delegate void pimg();
        pimg p;
        IAsyncResult ir;
        bool processing = false;
        

        public Form1()
        {
            InitializeComponent();
            fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            bgc = BufferedGraphicsManager.Current;
            cc = new ContrastCorrection((int)nContrast.Value);
            bc = new BrightnessCorrection((int)nBrightness.Value);
            grid = new Pen(Brushes.LimeGreen, 2);
            marker = new Pen(Brushes.Red, 2);
            //p = new pimg(process_image);

            cbCamera.Items.Clear();

            try
            {

                foreach (FilterInfo f in fic)
                {
                    cbCamera.Items.Add(f.Name);
                }
                cbCamera.SelectedIndex = 0;
            }
            catch (Exception k)
            {
            }
        }

        void vcd_NewFrame(Object s, NewFrameEventArgs a)
        {
            using (cam_bmp = (Bitmap)a.Frame.Clone())
            {
                cam_bmp = bc.Apply(cam_bmp);
                cam_bmp = cc.Apply(cam_bmp);
                camview.Image = cam_bmp;
                using (g = camview.CreateGraphics())
                {
                    fx = (float)cam_bmp.Width / (float)camview.Width;
                    fy = (float)cam_bmp.Height / (float)camview.Height;
                    g.DrawLine(grid, camview.Width / 2, 0, camview.Width / 2, camview.Height - 1);
                    g.DrawLine(grid, 0, camview.Height / 2, camview.Width - 1, camview.Height / 2);
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                vcd.Stop();
            }
            catch (Exception ex)
            {
            }
        }

        private void camview_MouseDown(object sender, MouseEventArgs e)
        {
            if (!snap_ready)
            {
                x1 = e.X;
                y1 = e.Y;
                bg = bgc.Allocate(camview.CreateGraphics(), camview.DisplayRectangle);
            }
        }

        private void camview_MouseUp(object sender, MouseEventArgs e)
        {
            int w, h;
            int passes;
            int rh;

            if ((e.X == x1) || (e.Y == y1))
                return;

            if (!snap_ready)
            {
                if (x2 < x1)
                    x2 = e.X - 1;
                else
                    x2 = e.X + 1;

                if (y2 < y1)
                    y2 = e.Y - 1;
                else
                    y2 = e.Y+1;

                if (x2 < 0)
                    x2 = 0;
                if (x2 >= camview.Width - 1)
                    x2 = camview.Width-1;
                if (y2 < 0)
                    y2 = 0;
                if (y2 >= camview.Height - 1)
                    y2 = camview.Height-1;


                if (x1 < x2)
                    sx = x1;
                else
                    sx = x2;

                if (y1 < y2)
                    sy = y1;
                else
                    sy = y2;
            

                w = (int)Math.Round((fx * (1+Math.Abs(x2 - x1))),0);
                h = (int)Math.Round((fy * (1+Math.Abs(y2 - y1))),0);
                sx = (int)Math.Round(sx * fx,0);
                sy = (int)Math.Round(sy * fy,0);

                if ((sx + w) > cam_bmp.Width)
                    w = cam_bmp.Width - sx + 1;

                if ((sy + h) > cam_bmp.Height)
                    h = cam_bmp.Height- sy + 1;

                if (dogrid.Checked)
                {
                    //w = 722;
                    //h = 788;
                    passes = 9;
                    rh = (int)Math.Round((double)(h / 9), 0);
                    txtCompiledText.Text = "";
                    for (int k = 0; k < passes; k++)
                    {
                        sel_bmp = cam_bmp.Clone(new Rectangle(sx, sy, w, rh), cam_bmp.PixelFormat);
                        selection.Image = sel_bmp;
                        richText.Text = "Ungarbling this gibberish...";
                        sy += rh;
                        process_image();
                    }

                }
                else
                {
                    sel_bmp = cam_bmp.Clone(new Rectangle(sx, sy, w, h), cam_bmp.PixelFormat);
                    selection.Image = sel_bmp;
                    richText.Text = "Ungarbling this gibberish...";
                    process_image();
                }
            }
        }


        private void camview_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && !snap_ready)
            {
                x2 = e.X;
                y2 = e.Y;

                if (x2 > x1)
                    sx = x1;
                else
                    sx = x2;
                if (y2 > y1)
                    sy = y1;
                else
                    sy = y2;

                try
                {
                    bg.Graphics.DrawImage(show_bmp,camview.DisplayRectangle);
                    bg.Graphics.DrawRectangle(marker, sx, sy, Math.Abs(x2 - x1), Math.Abs(y2 - y1));
                    bg.Render();
                }
                catch (Exception ex)
                {
                }
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                float centerx, centery;
                centerx = camview.Width / 2;
                centery = camview.Height / 2;
            }
        }



        void process_image()
        {
            if (File.Exists("output.txt"))
                File.Delete("output.txt");
            sel_bmp.Save(@"q.jpg");
			Process p = new Process();
			p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = Path.Combine("tesseract.exe");

            if (checkBox1.Checked)
			    p.StartInfo.Arguments = "q.jpg output nobatch digits";
            else
                p.StartInfo.Arguments = "q.jpg output";
            p.Start();
            //p.WaitForExit();
            while (!p.HasExited)
            {
                Application.DoEvents();
            }

            if (dogrid.Checked)
            {
                string s;

                richText.Text = File.ReadAllText("output.txt");

                richText.Text = richText.Text.Replace('\n', ' ').TrimEnd(' ', '\n').Replace("ﬁ", "fi").Replace("ﬂ", "fl");

                s = "";

                for (int i = 0; i < richText.Text.Length; i++)
                    if (!richText.Text.Substring(i, 1).Equals(" "))
                        s += richText.Text.Substring(i, 1);
                txtCompiledText.Text += "\n" + s;
            }
            else
                richText.Text = File.ReadAllText("output.txt");
        }

        void printstatus()
        {
            richText.Text = x1.ToString() + "," + y1.ToString() + " - " + x2.ToString() + "," + y2.ToString() + "\n" +
                "fx: " + fx.ToString() + ", fy: " + fy.ToString() + "\n" +
                camview.Width.ToString() + "x" + camview.Height.ToString() + "\n" +
                cam_bmp.Width.ToString() + "x" + cam_bmp.Height.ToString();
        }

        private void cmdCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(richText.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            nBrightness.Value = 18;
            nContrast.Value = 30;
            setadjust();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            nBrightness.Value = -30;
            nContrast.Value = 60;
            setadjust();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            nBrightness.Value = -60;
            nContrast.Value = 100;
            setadjust();
        }

        void setadjust()
        {
            cc = new ContrastCorrection((int)nContrast.Value);
            bc = new BrightnessCorrection((int)nBrightness.Value);
        }

        private void nBrightness_ValueChanged(object sender, EventArgs e)
        {
            setadjust();
        }

        private void nContrast_ValueChanged(object sender, EventArgs e)
        {
            setadjust();
        }

        void swap_corners()
        {
            float tx, ty;

            if (x2 < x1)
            {
                tx = x1;
                x1 = x2;
                x2 = x1;
            }

            if (y2 < y1)
            {
                ty = y1;
                y1 = y2;
                y2 = y1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetImage(selection.Image);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAppend_Click(object sender, EventArgs e)
        {
            if (richText.Text.Length > 0)
            {
                txtCompiledText.Text += "\n" + richText.Text;
            }
        }

        private void xCAPTUREToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (snap_ready)
                return;

            snap_ready = true;
            vcd = new VideoCaptureDevice(fic[cbCamera.SelectedIndex].MonikerString);
            vcd.VideoResolution = vcd.VideoCapabilities[cbRes.SelectedIndex];
            vcd.NewFrame += new NewFrameEventHandler(vcd_NewFrame);
            vcd.Start();
            camview.SizeMode = PictureBoxSizeMode.StretchImage;
            Text = "";
        }

        private void sNAPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!snap_ready)
                return;

            snap_ready = false;
            vcd.Stop();
        }

        private void cOPYTEXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(richText.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cOPYIMAGEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetImage(selection.Image);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void aPPENDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richText.Text.Length > 0)
            {
                txtCompiledText.Text += " " + richText.Text;
            }

        }

        private void lOADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (snap_ready == true)
                return;

            openFileDialog1.FileName = "";
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "JPEG|*.JPG|JPEG|*.JPEG|PNG|*.PNG|GIF|*.GIF|BITMAP|*.BMP";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cam_bmp = new Bitmap(openFileDialog1.FileName);
                show_bmp = new Bitmap(cam_bmp,new Size(camview.Width ,camview.Height));
                camview.Image = show_bmp;
                camview.SizeMode = PictureBoxSizeMode.StretchImage;
                fx = (float)cam_bmp.Width / (float)camview.Width;
                fy = (float)cam_bmp.Height / (float)camview.Height;
                Text = openFileDialog1.FileName;
            }
        }

        private void camview_Resize(object sender, EventArgs e)
        {
            if (cam_bmp != null)
            {
                fx = (float)cam_bmp.Width / (float)camview.Width;
                fy = (float)cam_bmp.Height / (float)camview.Height;
            }
        }

        private void cLEANUPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richText.SelectedText.Length > 0)
            {
                richText.SelectedText = richText.SelectedText.Replace('\n', ' ').TrimEnd(' ','\n').Replace("ﬁ","fi").Replace("ﬂ","fl");
            }
        }

        private void cOPYAPPENDEDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtCompiledText.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cLEANCOPYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richText.Text.Length > 0)
            {
                richText.Text = richText.Text.Replace('\n', ' ').TrimEnd(' ', '\n').Replace("ﬁ", "fi").Replace("ﬂ", "fl");
            }
            try
            {
                Clipboard.SetText(richText.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbRes.Items.Clear();
            VideoCaptureDevice v;
            
            v = new VideoCaptureDevice(fic[cbCamera.SelectedIndex].MonikerString);
            foreach (VideoCapabilities vc in v.VideoCapabilities)
            {
                cbRes.Items.Add(vc.FrameSize.Width.ToString() + " x " + vc.FrameSize.Height.ToString());
            }
            cbRes.SelectedIndex = 0;
        }

        private void rESETCAMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vcd != null)
            {
                vcd.Stop();
                snap_ready = !snap_ready;
            }
        }

        private void fILEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cLIPBOARDPASTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                cam_bmp = (Bitmap)Clipboard.GetImage();
                show_bmp = new Bitmap(cam_bmp, new Size(camview.Width,camview.Height));
                camview.Image = cam_bmp;
                camview.SizeMode = PictureBoxSizeMode.StretchImage;
                fx = (float)cam_bmp.Width / (float)camview.Width;
                fy = (float)cam_bmp.Height / (float)camview.Height;
            }
        }

        private void nBrightness_ValueChanged_1(object sender, EventArgs e)
        {
            cam_bmp = bc.Apply(cam_bmp);
            cam_bmp = cc.Apply(cam_bmp);
            camview.Image = cam_bmp;
        }


        private void rELOADLASTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                cam_bmp = new Bitmap(Text);
                show_bmp = new Bitmap(cam_bmp, new Size(camview.Width, camview.Height));
                camview.Image = show_bmp;
                camview.SizeMode = PictureBoxSizeMode.StretchImage;
                fx = (float)cam_bmp.Width / (float)camview.Width;
                fy = (float)cam_bmp.Height / (float)camview.Height;
            }
            catch (Exception ke)
            {
            }
        }

        private void cLEANDIGITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s;

            if (richText.Text.Length > 0 && richText.Text.Length < 27)
            {
                richText.Text = richText.Text.Replace('\n', ' ').TrimEnd(' ', '\n').Replace("ﬁ", "fi").Replace("ﬂ", "fl");

                s = "";
                
                for (int i = 0; i < richText.Text.Length; i++)
                    if (!richText.Text.Substring(i,1).Equals(" "))
                        s += richText.Text.Substring(i,1);
                txtCompiledText.Text += "\n"+s;
            }
            
            try
            {
                Clipboard.SetText(txtCompiledText.Text);
            }
            catch (Exception ex)
            {
             //   MessageBox.Show(ex.Message);
            }
        }

        private void cLEARCOMPILEDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtCompiledText.Text = "";
        }

        private void cOPYCOMPILEDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtCompiledText.Text);
            }
            catch (Exception ki)
            {
                MessageBox.Show(ki.Message);
            }
        }

    }
}
