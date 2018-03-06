using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using Microsoft.VisualBasic;
using System.Threading;
using System.Diagnostics;


namespace qadd
{
	public partial class profile : Form
	{
		OleDbCommand dbcmd;
		OleDbDataReader dbr;
		OdbcCommand Odbcmd;
		OdbcDataReader Odbr;
		long sid;
		
		public profile()
		{
			InitializeComponent();
		}

        bool fileexists(string f)
        {
            return File.Exists(f);
        }


        void loadglobals()
        {
            Program.loadpaths();

            if (!Directory.Exists(Program.rootfolder))
            {
                MessageBox.Show("Choose Root folder.");
                fbd.SelectedPath = "";
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    Program.rootfolder = fbd.SelectedPath;
                else
                    MessageBox.Show("Choose valid root folder.");
            }


            if (Program.dataSource == Program.DataSources.MySQL)
            {
                if (!Program.TryMysql())
                {
                    //terminate_all("Problem connecting to Mysql backend.");
                    MessageBox.Show("Retry connecting to host.");
                }
            }
            else
            {
                if (!fileexists(Program.maindb))
                {
                    ofd.Title = "MAIN ACCESS BACKEND";
                    ofd.Filter = "BACKEND DB | backend.mdb";
                    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Program.maindb = ofd.FileName;
                    }
                    else
                        MessageBox.Show("Select valid access backend.");
                    //terminate_all("Main backend not found.");
                }
                if (!Program.TryAccess())
                {
                    //terminate_all("Problem connecting to Access main backend.");
                    MessageBox.Show("Select valid access backend.");
                }
            }
            Program.savepaths();
        }


		private void profile_Load(object sender, EventArgs e)
		{
            this.Left = 0;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            loadglobals();

			if (Program.dataSource == Program.DataSources.Access)
				dbcmd = Program.maindbCon.CreateCommand();
			else
				Odbcmd = Program.OmaindbCon.CreateCommand();

			fill_cb(ref cbCenter, "centers", "centerid", "centername");
			fill_cb(ref cbLevel, "levels", "levelid", "levelprefix");
			fill_cb(ref cbSex, "sexes", "sexid", "sex");
			fill_cb(ref cbSchedule, "schedules", "scheduleid", "quickdescription");
			fill_profile();
		}

		long cb_value(ComboBox cb)
		{
			return ((cbitem)cb.SelectedItem).Value;
		}

		void fill_profile()
		{
            txtName.Focus();
            txtName.Text = "";
            txtSchool.Text = "";
            txtRemark.Text = "";
            txtEmail1.Text = "";
            txtShirtSize.Text = "";
    		chkQualified.Checked = true;
			chkDepSlip.Checked = true;
			chkEmailed.Checked = false;
		}

		void sel_cb(ref ComboBox cb,long v)
		{
			int index = 0;
			foreach (cbitem c in cb.Items)
			{
				if (c.Value == v)
				{
					break;
				}
				index++;
			}
			cb.SelectedIndex = index;
		}

		void fill_cb(ref ComboBox cb,string table,string columnindex,string columnname)
		{
			cb.Items.Clear();
			if (Program.dataSource == Program.DataSources.Access)
			{
				try
				{
					dbcmd.CommandText = "select * from " + table + " order by " + columnname;
					dbr = dbcmd.ExecuteReader();
					while (dbr.Read())
					{
						cbitem c = new cbitem();
						c.Text = getString(columnname);
						c.Value = (int)getLong(columnindex);
						cb.Items.Add(c);
					}
					cb.SelectedIndex = 0;
					dbr.Close();
				}
				catch (Exception ie)
				{
					MessageBox.Show(ie.Message);
					this.Close();
				}
			}
			else
			{
				try
				{
					Odbcmd.CommandText = "select * from " + table + " order by " + columnname;
					Odbr = Odbcmd.ExecuteReader();
					while (Odbr.Read())
					{
						cbitem c = new cbitem();
						c.Text = getString(columnname);
						c.Value = (int)getLong(columnindex);
						cb.Items.Add(c);
					}
					cb.SelectedIndex = 0;
					Odbr.Close();
				}
				catch (Exception ie)
				{
					MessageBox.Show(ie.Message);
					this.Close();
				}
			}
		}


        long getNewID()
        {
            long retval=-1;

            if (Program.dataSource == Program.DataSources.Access)
            {
                try
                {
                    dbcmd.CommandText = "select max(studid) as newid from students";
                    dbr = dbcmd.ExecuteReader();
                    while (dbr.Read())
                    {
                        retval = getLong("newid");
                    }
                    dbr.Close();
                }
                catch (Exception ie)
                {
                    MessageBox.Show(ie.Message);
                    this.Close();
                }
            }
            else
            {
                try
                {
                    Odbcmd.CommandText = "select max(studid) as newid from students";
                    Odbr = Odbcmd.ExecuteReader();
                    while (Odbr.Read())
                    {
                        retval = getLong("newid");
                    }
                    Odbr.Close();
                }
                catch (Exception ie)
                {
                    MessageBox.Show(ie.Message);
                    this.Close();
                }
            }
            return retval+1;
        }


		public bool getBool(string cn)
		{
			try
			{
				if (Program.dataSource == Program.DataSources.Access)
					return dbr.GetBoolean(dbr.GetOrdinal(cn));
				else
					return Odbr.GetBoolean(Odbr.GetOrdinal(cn));
			}
			catch (InvalidCastException ice)
			{
				return false;
			}
		}

		public string getString(string cn)
		{
			try
			{
				if (Program.dataSource == Program.DataSources.Access)
					return dbr.GetString(dbr.GetOrdinal(cn));
				else
					return Odbr.GetString(Odbr.GetOrdinal(cn));

			}
			catch (InvalidCastException ice)
			{
				return "";
			}
		}

		public long getLong(string cn)
		{
			try
			{
				if (Program.dataSource == Program.DataSources.Access)
					return dbr.GetInt32(dbr.GetOrdinal(cn));
				else
					return Odbr.GetInt32(Odbr.GetOrdinal(cn));
			}
			catch (InvalidCastException ice)
			{
				return 0;
			}
		}

		long chktol(bool c)
		{
			if (c)
				return -1;
			else
				return 0;
		}

		string q(string s)
		{
			return "\"" + s + "\"";	
		}

		void doupdateOLEDB()
		{
            sid = getNewID();
			dbcmd = Program.maindbCon.CreateCommand();
            dbcmd.CommandText = "INSERT INTO STUDENTS (studid,fullname,sex,ilevel,school,center,shirtsize,schedule,s_email,is_qualified,depslip,remarks,is_emailed) VALUES (" +
                                 sid.ToString() + "," +
                                 q(txtName.Text.ToUpper()) + "," +
                                 cb_value(cbSex) + "," +
                                 cb_value(cbLevel) + "," +
                                 q(txtSchool.Text.ToUpper()) + "," +
                                 cb_value(cbCenter) + "," +
                                 q(txtShirtSize.Text.ToUpper()) + "," +
                                 cb_value(cbSchedule) + "," +
                                 q(txtEmail1.Text) + "," +
                                 chktol(chkQualified.Checked).ToString() + "," +
                                 chktol(chkDepSlip.Checked).ToString() + "," +
                                 q(txtRemark.Text) + "," +
                                 chktol(chkEmailed.Checked).ToString() + ")";
			try
			{
				dbcmd.ExecuteNonQuery();
				MessageBox.Show("OK");
			}
			catch (Exception er)
			{
				MessageBox.Show(er.Message);
			}
		}


		void doupdateODBC()
		{
            sid = getNewID();
			Odbcmd = Program.OmaindbCon.CreateCommand();
            Odbcmd.CommandText = "INSERT INTO STUDENTS (studid,fullname,sex,ilevel,school,center,shirtsize,schedule,s_email,is_qualified,depslip,remarks,is_emailed) VALUES (" +
                                 sid.ToString() + "," +
                                 q(txtName.Text.ToUpper()) + "," +
                                 cb_value(cbSex) + "," +
                                 cb_value(cbLevel) + "," +
                                 q(txtSchool.Text.ToUpper()) + "," +
                                 cb_value(cbCenter) + "," +
                                 q(txtShirtSize.Text.ToUpper()) + "," +
                                 cb_value(cbSchedule) + "," +
                                 q(txtEmail1.Text) + "," +
                                 chktol(chkQualified.Checked).ToString() + "," +
                                 chktol(chkDepSlip.Checked).ToString() + "," +
                                 q(txtRemark.Text) + "," +
                                 chktol(chkEmailed.Checked).ToString() + ")";
			try
			{
				Odbcmd.ExecuteNonQuery();
				MessageBox.Show("OK");
			}
			catch (Exception er)
			{
				MessageBox.Show(er.Message);
			}
		}


        public static void createbarcode(long code)
        {
            string fcode = code.ToString("00000");
            string opath = Program.enq(Path.Combine(Program.rootfolder, "TEMPLATE", "BARCODE.png"));
            Process p = new Process();
            
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = Path.Combine(Program.rootfolder, "zint", "zint.exe");
            p.StartInfo.Arguments = "-b 9 --height=40 -w 5 -o " + opath + " -d " + "YMIITP-" + fcode;
            p.Start();
        }

        public static void createERFfile(long code)
        {
            string fcode = code.ToString("00000");
            string opath = Program.enq(Path.Combine(Program.rootfolder, "ERF", fcode + ".pdf"));
            Process p = new Process();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = Path.Combine(Program.rootfolder, @"wkhtmltopdf\bin", "wkhtmltopdf.exe");
            p.StartInfo.Arguments = "-s letter " + Program.enq(Path.Combine(Program.rootfolder, "TEMPLATE", "TMP.HTML")) + " " + opath;
            p.Start();
        }

        public static string createprofile_OLEDB(long code, bool overwrite)
        {
            OleDbDataReader r;
            OleDbCommand c;

            string sCode = code.ToString("00000");
            string fname = Path.Combine(Program.rootfolder, "ERF", sCode + ".pdf");
            string msg_template = File.ReadAllText(Path.Combine(Program.rootfolder, "template", "erf.html"));

            c = Program.maindbCon.CreateCommand();

            if (File.Exists(fname))
            {
                if (!overwrite)
                    return "Skipped";
            }

            try
            {
                c.CommandText = "select studid,fullname,school,shirtsize,s.sex,c.centername,l.leveltext,x.quickdescription,x.venue,x.city,x.schedule from " +
                                        "(((students as t inner join sexes as s on s.sexid = t.sex) inner join centers as c on c.centerid=t.center) " +
                                        " inner join levels as l on l.levelid = t.ilevel) inner join schedules as x on  x.scheduleid = t.schedule " +
                                        " where studid = " + code.ToString();

                r = c.ExecuteReader();
                r.Read();

                msg_template = msg_template.Replace("NFULLNAME", Program.getString(r, "fullname"));
                msg_template = msg_template.Replace("NYEARLEVEL", Program.getString(r, "leveltext"));
                msg_template = msg_template.Replace("NSCHOOL", Program.getString(r, "school"));
                msg_template = msg_template.Replace("NCENTER", Program.getString(r, "centername"));
                msg_template = msg_template = msg_template.Replace("NCODE", sCode);
                msg_template = msg_template.Replace("NGENDER", Program.getString(r, "sex"));
                msg_template = msg_template.Replace("NROOM", "");
                msg_template = msg_template.Replace("NSHIRT", Program.getString(r, "shirtsize"));
                msg_template = msg_template.Replace("NLINE1", Program.getString(r, "quickdescription"));
                msg_template = msg_template.Replace("NLINE2", Program.getString(r, "venue"));
                msg_template = msg_template.Replace("NLINE3", Program.getString(r, "city"));
                msg_template = msg_template.Replace("NLINE4", Program.getString(r, "schedule"));
                r.Close();

                File.WriteAllText(Path.Combine(Program.rootfolder, "template", "TMP.html"), msg_template);

                createbarcode(code);
                createERFfile(code);

                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public static string createprofile_ODBC(long code, bool overwrite)
        {
            OdbcDataReader r;
            OdbcCommand c;

            string sCode = code.ToString("00000");
            string fname = Path.Combine(Program.rootfolder, "ERF", sCode + ".pdf");
            string msg_template = File.ReadAllText(Path.Combine(Program.rootfolder, "template", "erf.html"));


            c = Program.OmaindbCon.CreateCommand();

            if (File.Exists(fname.ToString()))
            {
                if (!overwrite)
                    return "Skipped";
            }

            try
            {
                c.CommandText = "select studid,fullname,school,shirtsize,s.sex,c.centername,l.leveltext,x.quickdescription,x.venue,x.city,x.schedule from " +
                                        "(((students as t inner join sexes as s on s.sexid = t.sex) inner join centers as c on c.centerid=t.center) " +
                                        " inner join levels as l on l.levelid = t.ilevel) inner join schedules as x on  x.scheduleid = t.schedule " +
                                        " where studid = " + code.ToString();

                r = c.ExecuteReader();
                r.Read();
                msg_template = msg_template.Replace("NFULLNAME", Program.getString(r, "fullname"));
                msg_template = msg_template.Replace("NYEARLEVEL", Program.getString(r, "leveltext"));
                msg_template = msg_template.Replace("NSCHOOL", Program.getString(r, "school"));
                msg_template = msg_template.Replace("NCENTER", Program.getString(r, "centername"));
                msg_template = msg_template.Replace("NCODE", sCode);
                msg_template = msg_template.Replace("NGENDER", Program.getString(r, "sex"));
                msg_template = msg_template.Replace("NROOM", "");
                msg_template = msg_template.Replace("NSHIRT", Program.getString(r, "shirtsize"));
                msg_template = msg_template.Replace("NLINE1", Program.getString(r, "quickdescription"));
                msg_template = msg_template.Replace("NLINE2", Program.getString(r, "venue"));
                msg_template = msg_template.Replace("NLINE3", Program.getString(r, "city"));
                msg_template = msg_template.Replace("NLINE4", Program.getString(r, "schedule"));
                r.Close();

                File.WriteAllText(Path.Combine(Program.rootfolder, "template", "TMP.html"), msg_template);

                createbarcode(code);
                createERFfile(code);


                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


		private void cmdUpdate_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Proceed?", "ADD", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (Program.dataSource == Program.DataSources.Access)
                {
                    doupdateOLEDB();
                    createprofile_OLEDB(sid, true);
                }
                else
                {
                    doupdateODBC();
                    createprofile_OLEDB(sid, true);
                }

            }
		}

		private void cmdClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void button1_Click(object sender, EventArgs e)
        {
            //System.Windows.Forms.Application.Run(new settings());
            settings s = new settings();
            s.Visible = true;
            s.Activate();
        }

        private void button2_Click(object sender,EventArgs e)
        {
            fill_profile();
        }

        private void profile_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void cbCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cb_value(cbCenter))
                {
                    case 1:
                    case 8:
                    case 11:
                    case 22:
                    case 65:
                    case 66:
                    case 5:
                    case 19:
                    case 30:
                    case 44:
                    case 77:
                    case 34:
                    case 15:
                    case 24:
                    case 51:
                    case 3:
                    case 10:
                    case 13:
                    case 7:
                    case 9:
                    case 12:
                    case 70:
                    case 45:
                        if (cb_value(cbLevel) < 3)
                            sel_cb(ref cbSchedule, 5);
                        else
                            sel_cb(ref cbSchedule, 3);
                        break;

                    case 27:
                    case 60:
                    case 2:
                    case 4:
                    case 26:
                    case 41:
                    case 69:
                    case 71:
                    case 72:
                    case 55:
                    case 14:
                    case 25:
                        sel_cb(ref cbSchedule, 4);
                        break;

                    default:
                        if (cb_value(cbLevel) >= 3 && cb_value(cbLevel) <= 6)
                            sel_cb(ref cbSchedule, 1);
                        else
                            sel_cb(ref cbSchedule, 2);
                        break;
                }
            }
            catch (Exception x1)
            {
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.Clear();
                Interaction.AppActivate("Mozilla Thunderbird");
                SendKeys.Send("+{F10}Q");
                Thread.Sleep(300);                
                Interaction.AppActivate("Mozilla Thunderbird");
                SendKeys.Send("^c~");
                txtEmail1.Text = Clipboard.GetText();
                this.Activate();
            }
            catch (Exception x)
            {
            }
        }

        private void cbSex_Enter(object sender, EventArgs e)
        {
            cbSex.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbSex.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cbLevel_Enter(object sender, EventArgs e)
        {
            cbLevel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbLevel.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cbCenter_Enter(object sender, EventArgs e)
        {
            cbCenter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbCenter.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

	}

	class cbitem
	{
		public string Text { get; set; }
		public long Value { get; set; }
		public override string ToString()
		{
			return this.Text;
		}
	}
}
