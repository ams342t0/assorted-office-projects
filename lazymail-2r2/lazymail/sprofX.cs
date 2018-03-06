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


namespace lazymail
{
	public partial class profileX : Form
	{
		OleDbCommand dbcmd;
		OleDbDataReader dbr;
		OdbcCommand Odbcmd;
		OdbcDataReader Odbr;
		long sid;
		
		public profileX()
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
            loadglobals();

			if (Program.dataSource == Program.DataSources.Access)
				dbcmd = Program.maindbCon.CreateCommand();
			else
				Odbcmd = Program.OmaindbCon.CreateCommand();

            fill_schools();
            fill_scheds();
            fill_grades();
            txtSchool.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSchool.AutoCompleteSource = AutoCompleteSource.ListItems;
            //fill_cb(ref cbSchedule, "schedules", "scheduleid", "quickdescription");
            //fill_cb(ref cbLevel, "levels", "levelid", "levelprefix");
            fill_cb(ref cbCenter, "centers", "centerid", "centername");
			
			fill_cb(ref cbSex, "sexes", "sexid", "sex");
			
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


        void fill_schools()
        {
            txtSchool.Items.Clear();
            if (Program.dataSource == Program.DataSources.Access)
            {
                try
                {
                    dbcmd.CommandText = "select distinct school from students order by school";
                    dbr = dbcmd.ExecuteReader();
                    while (dbr.Read())
                    {
                        txtSchool.Items.Add(getString("school"));
                    }
                    txtSchool.SelectedIndex = 0;
                    dbr.Close();
                }
                catch (Exception ie)
                {
                    MessageBox.Show(ie.Message + ie.StackTrace);
                    this.Close();
                }
            }
            else
            {
                try
                {
                    Odbcmd.CommandText = "select distinct school from students order by school";
                    Odbr = Odbcmd.ExecuteReader();
                    while (Odbr.Read())
                    {
                        txtSchool.Items.Add(getString("school"));
                    }
                    txtSchool.SelectedIndex = 0;
                    Odbr.Close();
                }
                catch (Exception ie)
                {
                    MessageBox.Show(ie.Message + ie.StackTrace);
                    this.Close();
                }
            }
        }


        void fill_scheds()
        {
           cbSchedule.Items.Clear();
            if (Program.dataSource == Program.DataSources.Access)
            {
                try
                {
                    dbcmd.CommandText = "select scheduleid, quickdescription from schedules order by scheduleid";
                    dbr = dbcmd.ExecuteReader();
                    while (dbr.Read())
                    {
                        cbitem k;
                        k = new cbitem();
                        k.Value = getLong("scheduleid");
                        k.Text = getString("quickdescription");
                        cbSchedule.Items.Add(k);
                    }
                    cbSchedule.SelectedIndex = 0;
                    dbr.Close();
                }
                catch (Exception ie)
                {
                    MessageBox.Show(ie.Message + ie.StackTrace);
                    this.Close();
                }
            }
            else
            {
                try
                {
                    Odbcmd.CommandText = "select scheduleid, quickdescription from schedules order by scheduleid";
                    Odbr = Odbcmd.ExecuteReader();
                    while (Odbr.Read())
                    {
                        cbitem k;
                        k = new cbitem();
                        k.Value = getLong("scheduleid");
                        k.Text = getString("quickdescription");
                        cbSchedule.Items.Add(k);
                    }
                    cbSchedule.SelectedIndex = 0;
                    Odbr.Close();
                }
                catch (Exception ie)
                {
                    MessageBox.Show(ie.Message + ie.StackTrace);
                    this.Close();
                }

            }
        }

        void fill_grades()
        {
            cbLevel.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                cbitem k = new cbitem();
                k.Value = i;
                k.Text = i.ToString();
                cbLevel.Items.Add(k);
            }
            cbLevel.SelectedIndex = 0;
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
            dbcmd.CommandText = "INSERT INTO STUDENTS (studid,fullname,sex,ilevel,school,center,shirtsize,schedule,s_email,is_qualified,depslip,remarks,is_emailed,email) VALUES (" +
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
                                 chktol(chkEmailed.Checked).ToString() + "," + 
                                 q(DateTime.Now.ToString()+" (NEW)") +  ")";
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
            Odbcmd.CommandText = "INSERT INTO STUDENTS (studid,fullname,sex,ilevel,school,center,shirtsize,schedule,s_email,is_qualified,depslip,remarks,is_emailed,email) VALUES (" +
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
                                 chktol(chkEmailed.Checked).ToString() + "," +
                                 q(DateTime.Now.ToString() + " (NEW)") + ")";
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

		private void cmdUpdate_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Proceed?", "ADD", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (Program.dataSource == Program.DataSources.Access)
                {
                    doupdateOLEDB();
                    Program.createprofile_OLEDB(sid, true);
                }
                else
                {
                    doupdateODBC();
                    Program.createprofile_ODBC(sid, true);
                }
                this.Dispose();
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
            //Environment.Exit(0);
        }


        long get_area(long center)
        {
            long retval=0;

            if (Program.dataSource == Program.DataSources.Access)
            {
                try
                {
                    dbcmd = Program.maindbCon.CreateCommand();
                    dbcmd.CommandText = "select area from regions where regionid in (select region from centers where centerid = " + center.ToString() + ")";
                    dbr = dbcmd.ExecuteReader();
                    while (dbr.Read())
                    {
                        retval = dbr.GetInt32(dbr.GetOrdinal("area"));
                    }
                    dbr.Close();
                }
                catch (Exception ie)
                {
                    MessageBox.Show(ie.Message);
                   // this.Close();
                }
            }
            else
            {
                try
                {
                    Odbcmd = Program.OmaindbCon.CreateCommand();
                    Odbcmd.CommandText = "select area from regions where regionid in (select region from centers where centerid = " + center.ToString() + ")";
                    Odbr = Odbcmd.ExecuteReader();
                    while (Odbr.Read())
                    {
                        retval = Odbr.GetInt32(Odbr.GetOrdinal("area"));
                    }
                    Odbr.Close();
                }
                catch (Exception ie)
                {
                    MessageBox.Show(ie.Message);
                    //this.Close();
                }
            }

            return retval;
        }

        long get_schedule(long level, long area)
        {
            long retval=0;
            string s_l;

            if (level > 6)
                s_l = "h" + level.ToString();
            else
                s_l = "g" + level.ToString();

            if (Program.dataSource == Program.DataSources.Access)
            {
                try
                {
                    dbcmd = Program.maindbCon.CreateCommand();
                    dbcmd.CommandText = "select scheduleid from schedules where instr(scope_areas,'a" + area.ToString() + "') > 0 and instr(scope_levels,'" + s_l + "')>0";
                    dbr = dbcmd.ExecuteReader();
                    while (dbr.Read())
                    {
                        retval = dbr.GetInt32(dbr.GetOrdinal("scheduleid"));
                    }
                    dbr.Close();
                }
                catch (Exception ie)
                {
                    MessageBox.Show(ie.Message);
                    //this.Close();
                }
            }
            else
            {
                try
                {
                    Odbcmd = Program.OmaindbCon.CreateCommand();
                    Odbcmd.CommandText = "select scheduleid from schedules where instr(scope_areas,'a" + area.ToString() + "') > 0 and instr(scope_levels,'" + s_l + "')>0";
                    Odbr = Odbcmd.ExecuteReader();
                    while (Odbr.Read())
                    {
                       retval = Odbr.GetInt32(Odbr.GetOrdinal("scheduleid"));
                    }
                    Odbr.Close();
                }
                catch (Exception ie)
                {
                    MessageBox.Show(ie.Message);
//                    this.Close();
                }
            }


            return retval;
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

        private void gRABEMAILToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                txtEmail1.Focus();
                Clipboard.Clear();
                Interaction.AppActivate("Mozilla Thunderbird");
                SendKeys.SendWait("+{F10}Q");
                Thread.Sleep(300);
                Interaction.AppActivate("Mozilla Thunderbird");
                SendKeys.SendWait("^c~");
                txtEmail1.Text = Clipboard.GetText();
                this.Activate();
            }
            catch (Exception x)
            {
            }

        }

        private void cbCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            long a;
            long s;
            a = get_area(cb_value(cbCenter));
            s = get_schedule(cb_value(cbLevel),a);
            cbSchedule.SelectedIndex = (int)s-1;
        }

	}
}
