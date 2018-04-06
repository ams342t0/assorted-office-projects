using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office;


namespace qEdit
{
    public partial class qEdit : Form
    {
        bool isnew;

        public qEdit()
        {
            InitializeComponent();
            init_controls(false);
        }

        private void sOURCEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "New Excel (XLSX)|*.xlsx|New Excel with Macro (XLSM)| *.xlsm|Old Excel (XLS)|*.xls";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Program.excel_file = openFileDialog1.FileName;
                Program.excelapp = new Microsoft.Office.Interop.Excel.Application();
                Program.book = Program.excelapp.Workbooks.Open(Program.excel_file);
                Program.book.BeforeClose +=new Microsoft.Office.Interop.Excel.WorkbookEvents_BeforeCloseEventHandler(book_BeforeClose);
                Program.sheet = Program.book.Worksheets[1];
                Program.sheet.Change += new Microsoft.Office.Interop.Excel.DocEvents_ChangeEventHandler(sheet_Change);
                load_sheets();
                init_controls(true);
                Program.excelapp.Visible = true;
            }
        }

        void sheet_Change(Microsoft.Office.Interop.Excel.Range target)
        {
            //MessageBox.Show("Source was externally modified. Reload source to synchronize.");
        }

        void book_BeforeClose(ref bool cancel)
        {
            if (MessageBox.Show("Source workbook is being closed. Continue?", "CLOSING SOURCE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                cancel = false;
                init_controls(false);
            }
            else
                cancel = true;
        }

        void load_sheets()
        {
            cbSheet.Items.Clear();
            int i = 1;
            foreach(Microsoft.Office.Interop.Excel.Worksheet ws in Program.book.Worksheets)
            {
                cbitem item = new cbitem(i, ws.Name);
                cbSheet.Items.Add(item);
                i++;
            }
            Program.start_row = (long)lStartRow.Value + 1;
            Program.row = Program.start_row;
            cbSheet.SelectedIndex = 0;
        }

        void select_sheet()
        {
            Program.sheet = Program.book.Worksheets[cbSheet.SelectedIndex + 1];
            Program.sheet.Activate();
            get_columnheads();
            show_status();
        }


        void get_columnheads()
        {
            cbColumn.Items.Clear();
            cbColumn.Text = "";
            AutoCompleteStringCollection nac;
            Program.start_row = (long)lStartRow.Value;
            Program.col_values = new List<AutoCompleteStringCollection>();
            Program.all_cells = new List<List<string>>();
            Program.col_index = new List<long>();
            for (int c = 1; c <= 50; c++)
            {
                if (Program.sheet.Cells[Program.start_row, c].Value != null)
                {
                    if (Program.sheet.Cells[Program.start_row, c].Value.ToString().Length > 0)
                    {
                        cbitem i = new cbitem(c, Program.sheet.Cells[Program.start_row, c].Value.ToString());
                        cbColumn.Items.Add(i);
                        Program.col_index.Add(c);
                        nac = new AutoCompleteStringCollection();
                        List<string> ts = new List<string>();
                        fill_col_values(ref nac,ref ts,c);
                        Program.col_values.Add(nac);
                        Program.all_cells.Add(ts);
                    }
                }
            }
            isnew = false;
            if (cbColumn.Items.Count > 0)
                cbColumn.SelectedIndex = 0;
        }

        long get_lastrow()
        {
            long retval = (long)lStartRow.Value;
            do
            {
                retval++;
            } while (Program.sheet.Cells[retval, lStartColumn.Value].Value != null);

            return retval;
        }

        void fill_col_values(ref AutoCompleteStringCollection ac,ref List<string> s,long c)
        {
            string v;
            long lastrow = get_lastrow();
            
            status.Items[0].Text = "Preparing lookup values...";
            ac.Clear();
            s.Clear();

            for(long k=(long)lStartRow.Value+1;k<= lastrow;k++)
            {
                if (Program.sheet.Cells[k, c].Value != null)
                {
                    v = Program.sheet.Cells[k, c].Value.ToString();
                    s.Add(v);
                    if (!ac.Contains(v) && v.Length > 0)
                        ac.Add(v);
                }
                else
                {
                    s.Add("");
                }
            }
        }

        
        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            select_sheet();
        }

        private void qEdit_Load(object sender, EventArgs e)
        {
            cbSheet.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbSheet.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbColumn.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbColumn.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbValue.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public void show_status()
        {
            if (Program.book == null)
                return;

            status.Items[0].Text = "Row: " + Program.row.ToString() + ", Column: " + Program.column.ToString();
            cbValue.Text = Program.get_cell(Program.row,Program.column);
            Program.sheet.Cells[Program.row, Program.column].Select();
        }

        private void cbColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.column = Program.col_index[cbColumn.SelectedIndex];
            isnew = false;
            cbValue.Focus();
            show_status();
            cbValue.AutoCompleteCustomSource = Program.col_values[cbColumn.SelectedIndex];
        }


        private void iNSERTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            isnew = true;
            Program.row = get_lastrow();
            if (cbColumn.Items.Count > 0)
            {
                cbColumn.SelectedIndex = 0;
            }
            show_status();
            cbValue.Text = (Program.row - 1).ToString();
            cbValue.SelectAll();
            cbValue.Focus();
        }

        private void sAVEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Proceed saving?","SAVE",MessageBoxButtons.YesNo)== System.Windows.Forms.DialogResult.Yes)
                    Program.book.Save();
        }

        private void fOCUSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isnew)
                new Form2().ShowDialog(this);
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit?", "EXIT", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                Application.Exit();
        }

        private void uPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.row > ((long)lStartRow.Value + 1))
            {
                Program.row--;
                if (cbColumn.Items.Count > 0)
                    cbColumn.SelectedIndex = 0;
            }
            isnew = false;
            show_status();
        }

        private void bOTTOMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.row = get_lastrow() - 1;
            if (cbColumn.Items.Count > 0)
                cbColumn.SelectedIndex = 0;
            show_status();
            isnew = false;
        }

        private void fIRSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.row = (long)lStartRow.Value + 1;
            if (cbColumn.Items.Count > 0)
                cbColumn.SelectedIndex = 0;
            show_status();
            isnew = false;
        }

        private void dOWNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.row < get_lastrow() - 1)
            {
                Program.row++;
                if (cbColumn.Items.Count > 0)
                    cbColumn.SelectedIndex = 0;

            }
            isnew = false;
            show_status();
        }

        private void cbValue_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (isnew)
                    {
                        long l;
                        l = Program.all_cells[0].Count;
                        Program.all_cells.Add(new List<string>());
                        for (int k = 0; k < l; k++)
                            Program.all_cells[Program.all_cells.Count-1].Add("");
                    }

                    if (!Program.col_values[cbColumn.SelectedIndex].Contains(cbValue.Text))
                        Program.col_values[cbColumn.SelectedIndex].Add(cbValue.Text);

                    Program.all_cells[cbColumn.SelectedIndex][(int)Program.row - 2] = cbValue.Text;
                    Program.set_cell(cbValue.Text.ToUpper(),Program.row,Program.column);
                    
                    if (cbColumn.SelectedIndex < cbColumn.Items.Count - 1)
                        cbColumn.SelectedIndex++;
                    isnew = false;
                    break;

                case Keys.Escape:
                    cbValue.Text = Program.get_cell(Program.row,Program.column);
                    break;
            }

        }


        void init_controls(bool enabled)
        {
            menuStrip1.Items["inserttoolstripmenuitem1"].Enabled = enabled;
            menuStrip1.Items["uptoolstripmenuitem"].Enabled = enabled;
            menuStrip1.Items["downtoolstripmenuitem"].Enabled = enabled;
            menuStrip1.Items["firsttoolstripmenuitem"].Enabled = enabled;
            menuStrip1.Items["bottomtoolstripmenuitem"].Enabled = enabled;
            sEARCHToolStripMenuItem.Enabled = enabled;
            sAVEToolStripMenuItem.Enabled = enabled;
            fOCUSToolStripMenuItem.Enabled = enabled;
            cbSheet.Enabled = enabled;
            cbColumn.Enabled = enabled;
            cbValue.Enabled = enabled;
        }

        private void sEARCHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog(this);
        }

        private void qEdit_Activated(object sender, EventArgs e)
        {
            try
            {
                show_status();
            }
            catch (Exception exc)
            {
                
            }
        }
    }




    public class cbitem
    {
        public override string ToString()
        {
            return this.Text;
        }
        public cbitem(int i, string v)
        {
            Value= i;
            Text= v;
        }
        public long Value{ get; set; }
        public string Text{ get; set; }
    }

}
