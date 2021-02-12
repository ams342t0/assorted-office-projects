using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;


namespace aforgevidcap
{
    public partial class Form1 : Form
    {
        FilterInfoCollection fic;
        VideoCaptureDevice vcd;
        Sharpen sh;
        bool started = false;
        int frame_counter = 0;
        long counter=0;
        Bitmap realsnap;

        public Form1()
        {
            InitializeComponent();
            fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo fi in fic)
            {
                comboBox1.Items.Add(fi.Name);
            }
            sh = new Sharpen();
            sh.Threshold = 10;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            mnuReset.Text = counter.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbRes.Items.Clear();
            vcd = new VideoCaptureDevice(fic[comboBox1.SelectedIndex].MonikerString);
            foreach (VideoCapabilities v in vcd.VideoCapabilities)
            {
                cbRes.Items.Add(v.FrameSize.Width.ToString() + "x" + v.FrameSize.Height.ToString());
            }
            cbRes.SelectedIndex = 0;
            
            cbPicRes.Items.Clear();
            foreach (VideoCapabilities v in vcd.SnapshotCapabilities)
            {
                cbPicRes.Items.Add(v.FrameSize.Width.ToString() + "x" + v.FrameSize.Height.ToString());
            }
            //cbPicRes.SelectedIndex = 0;
        }

        public void nfh(Object sender,NewFrameEventArgs e)
        {
            if (frame_counter == 0)
            {
                Bitmap b = (Bitmap)e.Frame.Clone();
                if (mnuHFlip.Checked)
                    b.RotateFlip(RotateFlipType.Rotate180FlipY);
                if (mnuVFlip.Checked)
                    b.RotateFlip(RotateFlipType.Rotate180FlipX);
                pictureBox1.Image = b;

            }
            frame_counter++;
            if (frame_counter == 2)
                frame_counter = 0;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (vcd != null)
            vcd.Stop();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void mnuCapture_Click(object sender, EventArgs e)
        {
            long t;
            if (vcd==null)
                return;
            t = DateTime.Now.ToFileTime();
            pictureBox1.Image.Save(textBox1.Text + "\\" + t.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            MessageBox.Show("Saved");
            counter++;
            mnuReset.Text = counter.ToString();
        }

        private void mnuReset_Click(object sender, EventArgs e)
        {
            counter = 0;
            mnuReset.Text = counter.ToString();
        }

        private void sTARTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            started = !started;

            comboBox1.Enabled = !started;
            cbRes.Enabled = !started;

            if (started)
            {
                if (vcd != null)
                {
                    if (vcd.IsRunning)
                        vcd.Stop();
                }
                vcd = new VideoCaptureDevice(fic[comboBox1.SelectedIndex].MonikerString);
                vcd.ProvideSnapshots = true;
                vcd.NewFrame += new NewFrameEventHandler(nfh);
                vcd.SnapshotFrame +=new NewFrameEventHandler(vcd_SnapshotFrame);
                vcd.VideoResolution = vcd.VideoCapabilities[cbRes.SelectedIndex];
                vcd.Start();
                sTARTToolStripMenuItem.Text = "STOP";
                
            }
            else
            {
                vcd.Stop();
                sTARTToolStripMenuItem.Text = "START";
            }
        }

        public void vcd_SnapshotFrame(Object sender, NewFrameEventArgs a)
        {
            long t;
            t = DateTime.Now.ToFileTime();
            if (vcd == null)
                return;
            realsnap = (Bitmap)a.Frame.Clone();
            if (mnuHFlip.Checked)
                realsnap.RotateFlip(RotateFlipType.Rotate180FlipY);
            if (mnuVFlip.Checked)
                realsnap.RotateFlip(RotateFlipType.Rotate180FlipX);
            realsnap.Save(textBox1.Text + "\\" + t.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            MessageBox.Show("Saved");
            counter++;
            mnuReset.Text = counter.ToString();
        }
    }
}
