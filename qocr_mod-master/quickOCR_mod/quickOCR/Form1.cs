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
using AForge;

namespace quickOCR
{
    public partial class Form1 : Form
    {
        VideoCaptureDevice vcd;

        FilterInfoCollection fic;
        BrightnessCorrection bc;
        ContrastCorrection cc;

        BufferedGraphics bg;
        BufferedGraphicsContext bgc;
        Graphics g;
        Pen grid, corner_line;
        Bitmap source_bmp,sel_bmp,show_bmp, temp_bmp;
        QuadrilateralTransformation qt;
        System.Drawing.Point[] corners, corners_tmp;
        System.Drawing.Point center, d_off;
        Delegate del_convert;
        IAsyncResult ir;

        List<IntPoint> quad;

        int sx,sy;
        float fx, fy;
        bool snap_ready=false,do_grid=false;
        int frame_count = 0;
        bool processing = false,has_image=false;
        int corner_index = -1;

        private int width, height;
        private int blk_w, blk_h;

        public Form1()
        {
            InitializeComponent();

            fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            cc = new ContrastCorrection((int)nContrast.Value);
            bc = new BrightnessCorrection((int)nBrightness.Value);


            bgc = BufferedGraphicsManager.Current;
            grid = new Pen(Brushes.LimeGreen, 2);
            corner_line = new Pen(Brushes.Red, 2);
            corners = new System.Drawing.Point[4];
            corners_tmp = new System.Drawing.Point[4];
            corners[0].X = -100;
            corners[0].Y = -100;
            corners[1].X = -100;
            corners[1].Y = -100;
            corners[2].X = -100;
            corners[2].Y = -100;
            corners[3].X = -100;
            corners[3].Y = -100;

            camview.SizeMode = PictureBoxSizeMode.StretchImage;

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


        int ctos_x(int x)
        {
            return center.X+ x;
        }

        int ctos_y(int y)
        {
            return center.Y - y;
        }

        int stoc_x(int x)
        {
            return (x - center.X);
        }

        int stoc_y(int y)
        {
            return (center.Y - y);
        }

        string dump_values(int x, int y)
        {
            string retval = "";

            retval = "Clicked at : " + x.ToString() + ", " + y.ToString() + ", conrer_index = " + corner_index.ToString() +"\n";
            for (int i = 0; i < 4; i++)
                retval += "Corner " + i.ToString() + ", x = " + corners[i].X.ToString() + ", y = " + corners[i].Y.ToString() + "\n";
                   
            return retval;
        }

        void vcd_NewFrame(Object s, NewFrameEventArgs a)
        {
            using (source_bmp = (Bitmap)a.Frame.Clone())
            {
                source_bmp = bc.Apply(source_bmp);
                source_bmp = cc.Apply(source_bmp);
                camview.Image = source_bmp;
                using (g = camview.CreateGraphics())
                {
                    fx = (float)source_bmp.Width / (float)camview.Width;
                    fy = (float)source_bmp.Height / (float)camview.Height;
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
            key_control.Focus();

            if (!snap_ready && has_image)
            {
                if (e.X >= Math.Max(corners[0].X, corners[3].X) + 10 &&
                    e.X <= Math.Min(corners[1].X, corners[2].X) - 10 &&
                    e.Y >= Math.Max(corners[0].Y, corners[1].Y) + 10 &&
                    e.Y <= Math.Min(corners[2].Y, corners[3].Y) - 10)
                {
                    corner_index = -2;
                    sx = e.X;
                    sy = e.Y;
                    
                    for (int i = 0; i < 4; i++)
                    {
                        corners_tmp[i].X = corners[i].X;
                        corners_tmp[i].Y = corners[i].Y;
                    }
                }
                else
                {
                    corner_index = -1;
                    if (!points_equal(corners[0], corners[1]) &&
                        !points_equal(corners[1], corners[2]) &&
                        !points_equal(corners[2], corners[3]) &&
                        !points_equal(corners[0], corners[3]))
                    {
                        
                        for (int i = 0; i < 4; i++)
                        {
                            if (e.X >= corners[i].X - 10 && e.X <= corners[i].X + 10 &&
                                e.Y >= corners[i].Y - 10 && e.Y <= corners[i].Y + 10)
                            {
                                corner_index = i;
                                break;
                            }

                        }
                    }
                    if (corner_index == -1)
                    {
                        corners[0].X = e.X;
                        corners[0].Y = e.Y;
                        corners[1].X = e.X;
                        corners[1].Y = e.Y;
                        corners[2].X = e.X;
                        corners[2].Y = e.Y;
                        corners[3].X = e.X;
                        corners[3].Y = e.Y;
                    }
                }
            }
        }

        bool points_equal(System.Drawing.Point a, System.Drawing.Point b)
        {
            if (a.X == b.X && a.Y == b.Y)
                return true;
            else
                return false;
        }

        private void camview_MouseUp(object sender, MouseEventArgs e)
        {
            if ((e.X == corners[0].X || e.Y == corners[0].Y))
                return;

            get_center();

            if (!snap_ready && has_image)
                show_selected();
        }


        void get_center()
        {
            center.X = corners[0].X + (int)(Math.Round((corners[2].X - corners[0].X) / 2.0, 0));
            center.Y = corners[0].Y + (int)(Math.Round((corners[2].Y - corners[0].Y) / 2.0, 0));
        }

        void hide_lines()
        {
            float vg, hg,x,y;

            if (!has_image)
                return;

            temp_bmp = sel_bmp.Clone(new Rectangle(0, 0, sel_bmp.Width, sel_bmp.Height), System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            g = Graphics.FromImage(temp_bmp);
            Pen wl = new Pen(Brushes.White, (int)line_weight.Value);
            vg = temp_bmp.Height / ((float)nCells.Value);
            hg = temp_bmp.Width / ((float)nCells.Value);

            x = 0.0f;
            y = 0.0f;
            for (int i = 0; i <= nCells.Value; i++)
            {
                g.DrawLine(wl, (int)x, 0, (int)x, temp_bmp.Height - 1);
                g.DrawLine(wl, 0, (int)y, temp_bmp.Width - 1, (int)y);
                x += hg;
                y += vg;
            }


        }

        void do_rows()
        {
            int passes;
            float rh,x,y;
            int tmp;

            do_grid = true;
            temp_bmp = sel_bmp;
            hide_lines();

            rh = temp_bmp.Height / ((float)nCells.Value);
            txtCompiledText.Text = "";

            x = 0.0f;
            y = 0.0f;

            for (passes = 0; passes < nCells.Value; passes++)
            {
                tmp = (int)Math.Round(y + rh);
                if (tmp >= temp_bmp.Height)
                    rh = temp_bmp.Height - y;

                sel_bmp = temp_bmp.Clone(new Rectangle(0, (int)Math.Round(y, 0), temp_bmp.Width, (int)Math.Round(rh, 0)), temp_bmp.PixelFormat);
                selection.Image = sel_bmp;
                richText.Text = "Ungarbling this gibberish...";
                y += rh;
                process_image();
            }
            sel_bmp = temp_bmp;
            selection.Image = sel_bmp;
            do_grid = false;
        }


        private void camview_MouseMove(object sender, MouseEventArgs e)
        {
            int temp;

            if (e.Button == System.Windows.Forms.MouseButtons.Left && !snap_ready && has_image)
            {

                if (corner_index == -2)
                {
                    if ((int)Math.Min(corners[0].X,corners[3].X) >= 0 &&
                        (int)Math.Max(corners[1].X,corners[2].X) < camview.Width)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            corners[i].X = corners_tmp[i].X + (e.X - sx);

                            if (corners[i].X < 0)
                                corners[i].X = 0;

                            if (corners[i].X >= camview.Width)
                                corners[i].X = camview.Width - 1;
                        }
                    }

                    if ((int)Math.Min(corners[0].Y,corners[1].Y) >= 0 &&
                        (int)Math.Max(corners[2].Y,corners[3].Y) < camview.Height)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            corners[i].Y = corners_tmp[i].Y + (e.Y - sy);

                            if (corners[i].Y < 0)
                                corners[i].Y = 0;

                            if (corners[i].Y >= camview.Height)
                                corners[i].Y = camview.Height - 1;

                        }
                    }
                }
                else if (corner_index == -1)
                {
                        corners[2].X = e.X;
                        corners[2].Y = e.Y;

                        if (corners[2].X < 0)
                            corners[2].X = 0;

                        if (corners[2].X >= camview.Width)
                            corners[2].X = camview.Width - 2;

                        if (corners[2].Y < 0)
                            corners[2].Y = 0;

                        if (corners[2].Y >= camview.Height)
                            corners[2].Y = camview.Height - 2;

                        corners[1].X = corners[2].X;
                        corners[1].Y = corners[0].Y;
                        corners[3].X = corners[0].X;
                        corners[3].Y = corners[2].Y;
                 }
                 else
                 {
                            corners[corner_index].X = e.X;
                            corners[corner_index].Y = e.Y;

                            if (e.X < 0)
                                corners[corner_index].X = 0;

                            if (e.X > camview.Width - 1)
                                corners[corner_index].X = camview.Width - 1;

                            if (e.Y < 0)
                                corners[corner_index].Y = 0;

                            if (e.Y > camview.Height - 1)
                                corners[corner_index].Y = camview.Height - 1;
                 }
                
                draw_corner_select();
                bg.Render();
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

            //if (!File.Exists(p.StartInfo.FileName))
            //{
            //    richText.Text = "Error: Tesseract not found!";
            //    return;
            //}

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

            if (do_grid)
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
                Clipboard.SetImage(sel_bmp);
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
                has_image = true;
                source_bmp = new Bitmap(openFileDialog1.FileName);
                init_source_image();
            }
        }

        void init_source_image()
        {
            show_bmp = new Bitmap(source_bmp, new Size(camview.Width, camview.Height));
            camview.Image = show_bmp;
            bg = bgc.Allocate(camview.CreateGraphics(), camview.DisplayRectangle);
            draw_corner_select();

            fx = (float)source_bmp.Width / (float)camview.Width;
            fy = (float)source_bmp.Height / (float)camview.Height;

            Text = openFileDialog1.FileName;
        }

        private void camview_Resize(object sender, EventArgs e)
        {
            if (source_bmp != null)
            {
                fx = (float)source_bmp.Width / (float)camview.Width;
                fy = (float)source_bmp.Height / (float)camview.Height;
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

        private void cLIPBOARDPASTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                has_image = true;
                source_bmp = (Bitmap)Clipboard.GetImage();
                init_source_image();
                Text = "Source: Clipboard Image";
            }
        }

        private void nBrightness_ValueChanged_1(object sender, EventArgs e)
        {
            source_bmp = bc.Apply(source_bmp);
            source_bmp = cc.Apply(source_bmp);
            camview.Image = source_bmp;
        }


        private void rELOADLASTToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!File.Exists(openFileDialog1.FileName)) return;
            try
            {
                source_bmp = new Bitmap(openFileDialog1.FileName);
                has_image = true;
                init_source_image();
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

        void draw_corner_select()
        {
            if (!has_image)
                return;

            bg.Graphics.DrawImage(show_bmp, camview.DisplayRectangle);
            bg.Graphics.DrawLine(corner_line, corners[0].X, corners[0].Y, corners[1].X, corners[1].Y);
            bg.Graphics.DrawLine(corner_line, corners[1].X, corners[1].Y, corners[2].X, corners[2].Y);
            bg.Graphics.DrawLine(corner_line, corners[2].X, corners[2].Y, corners[3].X, corners[3].Y);
            bg.Graphics.DrawLine(corner_line, corners[3].X, corners[3].Y, corners[0].X, corners[0].Y);
            bg.Graphics.DrawLine(corner_line, corners[0].X, corners[0].Y, corners[2].X, corners[2].Y);
            bg.Graphics.DrawEllipse(corner_line, corners[0].X - 10, corners[0].Y - 10, 20, 20);
            bg.Graphics.DrawEllipse(corner_line, corners[1].X - 10, corners[1].Y - 10, 20,20);
            bg.Graphics.DrawEllipse(corner_line, corners[2].X - 10, corners[2].Y - 10, 20,20);
            bg.Graphics.DrawEllipse(corner_line, corners[3].X - 10, corners[3].Y - 10, 20,20);
            bg.Render();
        }

        private void sel_points_CheckedChanged(object sender, EventArgs e)
        {
            draw_corner_select();
        }

        private void dOROWSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            do_rows();
        }

        private void line_weight_ValueChanged(object sender, EventArgs e)
        {
            hide_lines();
            selection.Image = temp_bmp;
        }

        private void sel_rect_CheckedChanged(object sender, EventArgs e)
        {
            draw_corner_select();
        }

        private void mi_get_pattern_Click(object sender, EventArgs e)
        {
            px pt;

            if (sel_bmp == null) return;


            Program.pbitmap = (Bitmap) sel_bmp.Clone();
            Program.scolumns = (int)nCells.Value;
            Program.srows = (int)nCells.Value;
            pt = new px();
            pt.ShowDialog(this);
        }

        private void key_control_KeyDown(object sender, KeyEventArgs e)
        {
            if (!snap_ready && has_image)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        for (int i = 0; i < 4; i++)
                            corners[i].Y--;
                        break;
                    case Keys.Down:
                        for (int i = 0; i < 4; i++)
                            corners[i].Y++;
                        break;
                    case Keys.Left:
                        for (int i = 0; i < 4; i++)
                            corners[i].X--;
                        break;
                    case Keys.Right:
                        for (int i = 0; i < 4; i++)
                            corners[i].X++;
                        break;

                    case Keys.Escape:
                        corners[0].X = -100;
                        corners[0].Y = -100;
                        corners[1].X = -100;
                        corners[1].Y = -100;
                        corners[2].X = -100;
                        corners[2].Y = -100;
                        corners[3].X = -100;
                        corners[3].Y = -100;
                        break;

                }
                draw_corner_select();
                show_selected();
                bg.Render();
            }
        }


        void show_selected()
        {
            if (corners[0].X < 0 && corners[0].Y < 0 &&
                corners[1].X < 0 && corners[1].Y < 0 &&
                corners[2].X < 0 && corners[2].Y < 0 &&
                corners[3].X < 0 && corners[3].Y < 0) return;

            quad = new List<IntPoint>(4);
            qt = new QuadrilateralTransformation();
            quad.Add(new IntPoint((int)(fx * corners[0].X), (int)(fy * corners[0].Y)));
            quad.Add(new IntPoint((int)(fx * corners[1].X), (int)(fy * corners[1].Y)));
            quad.Add(new IntPoint((int)(fx * corners[2].X), (int)(fy * corners[2].Y)));
            quad.Add(new IntPoint((int)(fx * corners[3].X), (int)(fy * corners[3].Y)));
            qt.SourceQuadrilateral = quad;
            sel_bmp = qt.Apply(source_bmp);

            if (!checkBox1.Checked)
            {
                richText.Text = "Ungarbling this gibberish...";
                process_image();
                selection.Image = sel_bmp;
            }
            else
            {
                hide_lines();
                selection.Image = temp_bmp;
            }
        }

        void do_rotate(double angle)
        {
            int tx, ty;
            for (int k = 0; k < 4; k++)
            {
                tx = (int)Math.Round((stoc_x(corners[k].X) * Math.Cos(angle * Math.PI / 180.0) - stoc_y(corners[k].Y) * Math.Sin(angle * Math.PI / 180.0)),0);
                ty = (int)Math.Round((stoc_x(corners[k].X) * Math.Sin(angle * Math.PI / 180.0) + stoc_y(corners[k].Y) * Math.Cos(angle * Math.PI / 180.0)),0);
                corners[k].X = ctos_x(tx);
                corners[k].Y = ctos_y(ty);
            }
        }

        private void rOTATERIGHTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!has_image) return;

            do_rotate(-0.5);
            draw_corner_select();
            bg.Render();
        }

        private void rOTATELEFTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!has_image) return;

            do_rotate(0.5);
            draw_corner_select();
            bg.Render();
        }

    }
}
