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
    public partial class output : Form
    {
        public output()
        {
            InitializeComponent();
        }

        private void output_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Capture = false;
                Message m = Message.Create(this.Handle, 161, (IntPtr)2, IntPtr.Zero);

                this.WndProc(ref m);

                Program.xform.offsetX.Value = Left;
                Program.xform.offsetY.Value = Top;

            }
                       
        }

        private void output_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
            }
        }
    }
}
