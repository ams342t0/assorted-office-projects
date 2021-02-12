using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace qEdit
{
    public partial class Form3 : Form
    {
        List<long> row_index;
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();

            if (e.KeyCode == Keys.Enter && textBox1.Text.Length > 0)
            {
                row_index = new List<long>();
                row_index.Clear();
                listBox1.Items.Clear();
                foreach (List<string> l in Program.all_cells)
                {
                    for(int n=0;n<l.Count;n++)
                    {
                        if (l[n].ToLower().Contains(textBox1.Text.ToLower()))
                        {
                            row_index.Add(n+Program.start_row+1);
                            listBox1.Items.Add(l[n] + " (" + (n+Program.start_row+1) + ")");
                        }
                    }
                }
                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;
                    listBox1.Focus();
                }
                else
                    textBox1.SelectAll();
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            Program.row = row_index[listBox1.SelectedIndex];
            this.Close();
        }

   
        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();

            if (e.KeyCode == Keys.Enter)
            {
                if (listBox1.SelectedItems.Count == 0)
                    return;
                Program.row = row_index[listBox1.SelectedIndex];
                this.Close();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }
    }
}
