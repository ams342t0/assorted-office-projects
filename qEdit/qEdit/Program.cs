using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.Office;

namespace qEdit
{
    static class Program
    {
        public static string excel_file;
        public static Microsoft.Office.Interop.Excel.Workbook  book;
        public static Microsoft.Office.Interop.Excel.Worksheet sheet;
        public static Microsoft.Office.Interop.Excel.Application excelapp;
        public static long row, column,start_row,start_column;
        
        public static List<long> col_index;
        public static List<AutoCompleteStringCollection> col_values;
        public static List<List<string>> all_cells;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new qEdit());
        }


        public static void set_cell(string s,long r,long c)
        {
            Program.sheet.Cells[r, c].Value = s;
        }

        public static string get_cell(long r,long c)
        {
            if (Program.sheet.Cells[r, c].Value != null)
                return Program.sheet.Cells[r,c].Value.ToString();
            else
                return "";
        }

    }
}
