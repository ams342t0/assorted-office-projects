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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            fill_view();   
        }

        void fill_view()
        {
            ListViewItem li;
            listView1.Items.Clear();

            foreach (long i in Program.col_index)
            {
                li = listView1.Items.Add(Program.get_cell(Program.start_row, i));
                li.SubItems.Add(Program.get_cell(Program.row, i));
            }
        }

        void view_details()
        {
            Form4 f = new Form4();
            f.row = Program.row;
            f.itemindex = listView1.SelectedIndices[0];
            f.column = Program.col_index[listView1.SelectedIndices[0]];
            f.itext = listView1.SelectedItems[0].SubItems[1].Text;
            f.Text = listView1.SelectedItems[0].Text;
            f.ShowDialog(this);
            listView1.SelectedItems[0].SubItems[1].Text = Program.get_cell(Program.row, Program.col_index[listView1.SelectedIndices[0]]);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            view_details();
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
                if (listView1.SelectedItems.Count > 0)
                    view_details();
        }
    }
}
