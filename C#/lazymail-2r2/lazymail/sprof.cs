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


namespace lazymail
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

		private void profile_Load(object sender, EventArgs e)
		{
			sid = Program.lstudid;
			if (Program.dataSource == Program.DataSources.Access)
				dbcmd = Program.maindbCon.CreateCommand();
			else
				Odbcmd = Program.OmaindbCon.CreateCommand();

			fill_cb(ref cbCenter, "centers", "centerid", "centername");
			fill_cb(ref cbLevel, "levels", "levelid", "leveltext");
			fill_cb(ref cbSex, "sexes", "sexid", "sex");
			fill_cb(ref cbSchedule, "schedules", "scheduleid", "quickdescription");
            cbCenter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbCenter.AutoCompleteSource = AutoCompleteSource.ListItems;
			fill_profile();
		}

		long cb_value(ComboBox cb)
		{
			return ((cbitem)cb.SelectedItem).Value;
		}

		void fill_profile()
		{
			if (Program.dataSource == Program.DataSources.Access)
			{
				try
				{
					dbcmd.CommandText = "select * from students where studid = " + sid.ToString();
					dbr = dbcmd.ExecuteReader();
					dbr.Read();
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
					Odbcmd.CommandText = "select * from students where studid = " + sid.ToString();
					Odbr = Odbcmd.ExecuteReader();
					Odbr.Read();
				}
				catch (Exception ie)
				{
					MessageBox.Show(ie.Message);
					this.Close();
				}
			}

			txtID.Text = getLong("studid").ToString();
			txtName.Text = getString("fullname");
			sel_cb(ref cbSex, getLong("sex"));
			sel_cb(ref cbLevel,getLong("ilevel"));
			txtSchool.Text = getString("school");
			sel_cb(ref cbCenter,getLong("center"));
			txtShirtSize.Text = getString("shirtsize");
			sel_cb(ref cbSchedule,getLong("schedule"));
			txtEmail1.Text = getString("s_email");
			txtEmail2.Text = getString("email");
			txtRemarks.Text = getString("remarks");
			txtProfile.Text = getString("profilescan");
			txtDepSlip.Text = getString("depslipscan");

			if (getLong("is_qualified") < 0)
				chkQualified.Checked = true;
			else
				chkQualified.Checked = false;

			if (getLong("depslip") < 0)
				chkDepSlip.Checked = true;
			else
				chkDepSlip.Checked = false;

			if (getLong("is_emailed") < 0)
				chkEmailed.Checked = true;
			else
				chkEmailed.Checked = false;

			if (Program.dataSource == Program.DataSources.Access)
				dbr.Close();
			else
				Odbr.Close();
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
			dbcmd = Program.maindbCon.CreateCommand();
			dbcmd.CommandText = "UPDATE students set fullname = " + q(txtName.Text) + "," +
								 "sex = " + cb_value(cbSex) + "," +
								 "ilevel = " + cb_value(cbLevel) + "," +
								 "school = " + q(txtSchool.Text) + "," +
								 "center = " + cb_value(cbCenter) + "," +
								 "shirtsize=" + q(txtShirtSize.Text) + "," +
								 "schedule = " + cb_value(cbSchedule) + "," +
								 "s_email = " + q(txtEmail1.Text) + "," +
								 "email = " + q(txtEmail2.Text) + "," +
								 "remarks = " + q(txtRemarks.Text) + "," +
								 "profilescan=" + q(txtProfile.Text) + "," +
								 "is_qualified = " + chktol(chkQualified.Checked).ToString() + "," +
								 "depslip = " + chktol(chkDepSlip.Checked).ToString() + "," +
								 "is_emailed = " + chktol(chkEmailed.Checked).ToString() + "," +
                                 "ts = " + q(DateTime.Now.ToString()) +
								 " WHERE studid = " + sid.ToString();
			try
			{
				dbcmd.ExecuteNonQuery();
				MessageBox.Show("Update successful.");

				if (MessageBox.Show("Create ERF?", "ERF", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{
					Program.createbarcode(sid);
					MessageBox.Show(Program.createprofile_OLEDB(sid, true));
					dbcmd.CommandText = "UPDATE students SET is_emailed = 0 where studid = " + sid.ToString();
					dbcmd.ExecuteNonQuery();
				}
			}
			catch (Exception er)
			{
				MessageBox.Show(er.Message);
			}
		}

		void doupdateODBC()
		{
			Odbcmd = Program.OmaindbCon.CreateCommand();
			Odbcmd.CommandText = "UPDATE students set fullname = " + q(txtName.Text) + "," +
								 "sex = " + cb_value(cbSex) + "," +
								 "ilevel = " + cb_value(cbLevel) + "," +
								 "school = " + q(txtSchool.Text) + "," +
								 "center = " + cb_value(cbCenter) + "," +
								 "shirtsize=" + q(txtShirtSize.Text) + "," +
								 "schedule = " + cb_value(cbSchedule) + "," +
								 "s_email = " + q(txtEmail1.Text) + "," +
								 "email = " + q(txtEmail2.Text) + "," +
								 "remarks = " + q(txtRemarks.Text) + "," +
								 "profilescan=" + q(txtProfile.Text) + "," +
								 "is_qualified = " + chktol(chkQualified.Checked).ToString() + "," +
								 "depslip = " + chktol(chkDepSlip.Checked).ToString() + "," +
								 "is_emailed = " + chktol(chkEmailed.Checked).ToString() + "," +
                                 "ts = " + q(DateTime.Now.ToString()) + 
								 " WHERE studid = " + sid.ToString();
			try
			{
				Odbcmd.ExecuteNonQuery();
				MessageBox.Show("Update successful.");

				if (MessageBox.Show("Create ERF?", "ERF", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{
					Program.createbarcode(sid);
					MessageBox.Show(Program.createprofile_ODBC(sid, true));
					Odbcmd.CommandText = "UPDATE students SET is_emailed = 0 where studid = " + sid.ToString();
					Odbcmd.ExecuteNonQuery();
				}
			}
			catch (Exception er)
			{
				MessageBox.Show(er.Message);
			}
		}

		private void cmdUpdate_Click(object sender, EventArgs e)
		{
			if (Program.dataSource == Program.DataSources.Access)
				doupdateOLEDB();
			else
				doupdateODBC();
		}

		private void cmdClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void cmdERF_Click(object sender, EventArgs e)
		{
			Program.createbarcode(sid);
			if (Program.dataSource == Program.DataSources.Access)
			{
				MessageBox.Show(Program.createprofile_OLEDB(sid, true));
				dbcmd = Program.maindbCon.CreateCommand();
				dbcmd.CommandText = "UPDATE students SET is_emailed = 0 where studid = " + sid.ToString();
				dbcmd.ExecuteNonQuery();
			}
			else
			{
				MessageBox.Show(Program.createprofile_ODBC(sid, true));
				Odbcmd = Program.OmaindbCon.CreateCommand();
				Odbcmd.CommandText = "UPDATE students SET is_emailed = 0 where studid = " + sid.ToString();
				Odbcmd.ExecuteNonQuery();
			}
		}

		private void cmdViewProfile_Click(object sender, EventArgs e)
		{
			string path=Path.Combine(Program.rootfolder,"PF",txtProfile.Text);
			if (File.Exists(path)) 
				System.Diagnostics.Process.Start(path);
		}

		private void cmdViewDepslip_Click(object sender, EventArgs e)
		{
			string path=Path.Combine(Program.rootfolder,"REPLIES",txtDepSlip.Text);
			if (File.Exists(path)) 
				System.Diagnostics.Process.Start(path);
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
