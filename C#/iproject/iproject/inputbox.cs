using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iproject
{
    public partial class inputbox : Form
    {
        public bool result=false;
        DateTime ts;

        public inputbox()
        {
            ts = DateTime.Now;
            InitializeComponent();
        }

        public inputbox(DateTime d)
        {
            ts = d;
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            result = true;
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            result = false;
            Close();
        }


        private void inputbox_Shown(object sender, EventArgs e)
        {
            //txtInput.Text = ts;
            dtDateTime.Value = ts;
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdOK.PerformClick();
            }
        }

    }
}
