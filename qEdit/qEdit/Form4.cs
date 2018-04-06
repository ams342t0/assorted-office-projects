using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace qEdit
{
    public partial class Form4 : Form
    {
        public string itext;
        public long row, column,itemindex;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.Text = itext;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }

        void save()
        {
            itext = textBox1.Text.ToUpper();
            Program.set_cell(itext, row, column);

            if (!Program.col_values[(int)itemindex].Contains(itext))
                Program.col_values[(int)itemindex].Add(itext);

            Program.all_cells[(int)itemindex][(int)row - 2] = itext;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    save();
                    break;

                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
    }
}
