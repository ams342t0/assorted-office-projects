using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using AForge;
using AForge.Imaging;
using AForge.Video.DirectShow;
using AForge.Video;


namespace iCapture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool started = false;
        BrightnessCorrection bc;
        ContrastCorrection cc;
        Bitmap bf;
        VideoCaptureDevice vcd;
        FilterInfoCollection fic;
        string destfolder;
        

        private void Form1_Load(object sender, EventArgs e)
        {
            destfolder = Application.StartupPath;
            textBox1.Text = destfolder;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //b = new Bitmap("d:\\test.jpg");
            bc = new BrightnessCorrection();
            cc = new ContrastCorrection();
            fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo f in fic)
            {
                comboBox1.Items.Add(f.Name);
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!started) button2.Text = "STOP";
            else button2.Text = "START";
            started = !started;
            if (started)
            {
                vcd.Start();
            }
            else
            {
                vcd.Stop();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            vcd = new VideoCaptureDevice(fic[comboBox1.SelectedIndex].MonikerString);
            vcd.DesiredFrameRate = 10;
            vcd.NewFrame  += new NewFrameEventHandler(vcdnf);
        }

        public void vcdnf(Object sender, NewFrameEventArgs e)
        {
            bf = (Bitmap)e.Frame.Clone();
            bc.AdjustValue = trackBar1.Value;
            cc.Factor = trackBar2.Value;
            pictureBox1.Image = cc.Apply(bc.Apply(bf));
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = destfolder;
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                destfolder = folderBrowserDialog1.SelectedPath;
                textBox1.Text = destfolder;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (started) vcd.Stop();
        }
    }
}
