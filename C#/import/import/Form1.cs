using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Data.OleDb;
using System.Data.Odbc;
using Microsoft.Office.Interop.Excel;

namespace import
{
    public partial class Form1 : Form
    {
        String backendpath, sourcepath;
        //OdbcConnection cn;
        OleDbConnection cn;
        OleDbCommand cmd;

        public Form1()
        {
            InitializeComponent();
            txtStatus.Text = "";
        }

        private void cmdBackend_Click(object sender, EventArgs e)
        {
            ofd.Filter = "ACCDB|*.accdb|MDB|*.mdb";
            if (backendpath != null)
                ofd.InitialDirectory = Path.GetDirectoryName(backendpath);
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                    backendpath = ofd.FileName;
                    txtBackend.Text = backendpath;
                    backend_connect();
                    get_centers();
                    save_registry();
            }
            backend_connect();
        }

        void backend_connect()
        {
            try
            {
                cn = new OleDbConnection();
                //cn = new OdbcConnection();
                cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; data source=" + backendpath;
                //cn.ConnectionString = "Driver=MySQL ODBC 5.3 ANSI Driver; server = slc-as300c; database=ih17;uid=mu17;pwd=ih17";
                cn.Open();
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }
        }

        void load_registry()
        {
            backendpath = (String) Registry.GetValue("HKEY_CURRENT_USER\\IMPORT", "backend", "");
            sourcepath = (String)Registry.GetValue("HKEY_CURRENT_USER\\IMPORT", "sourcepath", "");
            if (backendpath != null)
                txtBackend.Text = backendpath;
            if (sourcepath != null)
                txtSource.Text = sourcepath;
        }

        void save_registry()
        {
            if (backendpath != null)
                Registry.SetValue("HKEY_CURRENT_USER\\IMPORT", "backend",(String)backendpath);
            if (sourcepath != null)
                Registry.SetValue("HKEY_CURRENT_USER\\IMPORT", "sourcepath", (String)sourcepath);
        }

        private void cmdSource_Click(object sender, EventArgs e)
        {
            ofd.Filter = "EXCEL 2007|*.xlsx|EXCEL 2000|*.xls";
            if (sourcepath != null && sourcepath.Length>0)
                ofd.InitialDirectory = Path.GetDirectoryName(sourcepath);
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                    sourcepath= ofd.FileName;
                    txtSource.Text = sourcepath;
                    save_registry();
            }
        }

        void get_centers()
        {
            //OdbcDataReader dr;
            OleDbDataReader dr;

            try
            {
                cmd = new OleDbCommand();
                //cmd = new OdbcCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT CENTERID,CENTERNAME FROM CENTERS ORDER BY CENTERNAME";
                dr = cmd.ExecuteReader();

                cbCenter.Items.Clear();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cbitem i = new cbitem();
                        i.Text = dr.GetString(dr.GetOrdinal("CENTERNAME"));
                        i.Value = dr.GetInt32(dr.GetOrdinal("CENTERID"));
                        cbCenter.Items.Add(i);
                    }
                    cbCenter.SelectedIndex = 0;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
            }
        }

        bool row_exists(string n)
        {
            OleDbDataReader dr;
            OleDbCommand cmd;
            /*OdbcDataReader dr;
            OdbcCommand cmd;*/

            bool retval = false;

            cmd = new OleDbCommand();
            //cmd = new OdbcCommand();
            cmd.Connection = cn;
            cmd.CommandText = "SELECT STUDID FROM STUDENTS WHERE FULLNAME = \"" + n + "\"";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
                retval = true;
            dr.Close();
            return retval;
        }

        long get_last_id()
        {
            OleDbDataReader dr;
//            OdbcDataReader dr;
            long retval = 0;

            cmd = new OleDbCommand();
            //cmd = new OdbcCommand();
            cmd.Connection = cn;
            cmd.CommandText = "SELECT STUDID FROM STUDENTS ORDER BY STUDID DESC";
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                if (dr.GetValue(dr.GetOrdinal("STUDID")) != null)
                   retval = long.Parse(dr.GetValue(dr.GetOrdinal("STUDID")).ToString());
                
            }

            dr.Close();
            return retval+1;
        }


        void read_source()
        {
            OleDbCommand cmd;
            //OdbcCommand cmd;
            Workbook wb;
            long count = 0;

            Microsoft.Office.Interop.Excel.Application a;
            a = new Microsoft.Office.Interop.Excel.Application();
            wb = a.Workbooks.Open(sourcepath);
            long studid,
                studentcode,
                sex,
                level,
                center,sched;
            double qscore;
            string  idnumber,
                fullname="",
                school;
            foreach (Worksheet ws in wb.Worksheets)
            {
                int i = 6;
                while (ws.Cells[i, 2].Value != null && ((string)ws.Cells[i, 2].Value).Length > 3)
                {
                    if (!row_exists((string)ws.Cells[i, 2].Value))
                    {
                        cmd = new OleDbCommand();
                        //cmd = new OdbcCommand();
                        cmd.Connection = cn;
                        try
                        {
                            studid = get_last_id();
                            studentcode = studid;
                            idnumber = studid.ToString();
                            fullname = "\"" + (string)ws.Cells[i, 2].Value + "\"";
                            sex = sex_val((string)ws.Cells[i, 5].Value);
                            level = (long)ws.Cells[i, 4].Value;
                            school = "\"" + (string)ws.Cells[i, 3].Value + "\"";
                            center = ((cbitem)cbCenter.SelectedItem).Value;

                            if (level < 7)
                                sched = 14;
                            else
                                sched = 15;

                            qscore = (double)ws.Cells[i, 27].Value;
                            cmd.CommandText = "INSERT INTO STUDENTS(STUDID,STUDENTCODE,IDNUMBER,FULLNAME,SEX,ILEVEL,SCHOOL," +
                                        "CENTER,SCHEDULE,QSCORE,IS_QUALIFIED,DEPSLIP,IS_EMAILED,S_EMAIL) VALUES(" +
                                        studid + "," +
                                        studentcode + "," +
                                        idnumber + "," +
                                        fullname.ToUpper() + "," +
                                        sex + "," +
                                        level + "," +
                                        school.ToUpper() + "," +
                                        center + "," +
                                        sched + "," +
                                        qscore +
                                        ",-1,-1,0,\"rjd182001@yahoo.com\")";
                            txtStatus.Text = "Adding " + fullname;
                            cmd.ExecuteNonQuery();
                            txtStatus.Text = "Added " + fullname + " (" + studid.ToString() + ")";
                            count++;
                        }
                        catch (Exception kk)
                        {
                            txtBackend.Text = cmd.CommandText;
                            txtStatus.Text = "Error at Sheet " + ws.Name + ", row " + i;
                            MessageBox.Show(kk.Message + "\n" + kk.StackTrace);
                            a.Visible = true;
                            wb.Activate();
                            ws.Activate();
                            ws.Rows[i].Select();
                            return;
                        }
                    }
                    else
                        txtStatus.Text = "Skipping row " + i + ", Sheet " + ws.Index.ToString();
                    i++;
                }
            }
            MessageBox.Show("DONE!");
            txtStatus.Text = count.ToString() + " rows added";
            wb.Saved = true;
            wb.Close();
            a.Visible = true;
            a.Quit();
        }

        long sex_val(string s)
        {
            if (s.ToLower().Trim().Equals("f") || s.ToLower().Trim().Equals("female") || s.ToLower().Trim().Equals("girl") || s.ToLower().Trim().Equals("G"))
                return 2;
            return 1;
        }

        private void cmdImport_Click(object sender, EventArgs e)
        {
            read_source();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            load_registry();
            backend_connect();
            get_centers();
        }

        /*long get_area(long center)
        {
            OleDbCommand cmd;
            OleDbDataReader dr;
            long retval=0;

            cmd = new OleDbCommand();
            cmd.Connection = cn;
            cmd.CommandText = "SELECT AREA FROM REGIONS WHERE REGIONID IN (SELECT REGION FROM CENTERS WHERE CENTERID = " + center + ")";
            dr = cmd.ExecuteReader();
            if (dr.Read())
                retval =long.Parse(dr.GetValue(dr.GetOrdinal("AREA")).ToString());
            dr.Close();
            return retval;
        }

        long get_schedule(long l, long area)
        {
            OleDbCommand cmd;
            OleDbDataReader dr;
            Int32 retval = -1;
            string s;

            if (l > 6)
                s = "h" + l.ToString();
            else
                s = "g" + l.ToString();

            cmd = new OleDbCommand();
            cmd.Connection = cn;
            cmd.CommandText = "SELECT SCHEDULEID FROM SCHEDULES WHERE INSTR(SCOPE_LEVELS,'" + s + "')>0 and INSTR(SCOPE_AREAS,'a" + area.ToString() + "')>0";
            dr = cmd.ExecuteReader();
            dr.Read();
            retval = dr.GetInt32(dr.GetOrdinal("SCHEDULEID"));
            return retval;
        }*/

        long get_schedule(long l)
        {
            long retval = 0;
            if (l < 7)
                retval = 14;
            else
                retval = 15;
            return retval;
        }

    
    }

    public class cbitem
    {
        public long Value { get; set; }
        public string Text { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
}
