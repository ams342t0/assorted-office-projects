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
using Microsoft.Win32;
using System.IO;
using System.Threading;
using Microsoft.VisualBasic;


namespace lazymail
{
	public partial class Form1 : Form
	{
		public delegate void fillmaildelegate(int v);
		fillmaildelegate fm;
		bool filling_students=false;
		public ListViewColumnSorter lvcs;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			Environment.Exit(0);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			lvcs = new ListViewColumnSorter();
			lvcs.Order = SortOrder.None;
			lvcs.SortColumn = 0;

			//Program.pv = new picview();
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			loadglobals();
		}


		private void txtsearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (filling_students)
					filling_students = false;
				else
				{
					fillmaildelegate f = new fillmaildelegate(fill_students);
					filling_students = true;
					IAsyncResult ira = f.BeginInvoke(1,null, null);
				}
				txtsearch.SelectAll();
				lvstudents.Focus();
			}
		}


        private void lvstudents_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Program.lstudid = Int32.Parse(e.Item.Tag.ToString());
            txtName.Text = e.Item.Text;
            txtemailaddress.Text = e.Item.SubItems[5].Text;
            txtscanfile.Text = "(see other files)";
            txtemailaddress.Focus();
        }


		private void bYNAMEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			txtsearch.Focus();
			if (txtsearch.Text.Length > 0)
				txtsearch.SelectAll();
		}

		private void bYEMAILToolStripMenuItem_Click(object sender, EventArgs e)
		{
			fillmaildelegate f = new fillmaildelegate(fill_students);
			filling_students = true;
			IAsyncResult ira = f.BeginInvoke(2, null, null);
		}

		private void uPDATEToolStripMenuItem_Click(object sender, EventArgs e)
		{
            string s_email;

			if (txtemailaddress.Text.Length > 0 && txtName.Text.Length > 0 && lvstudents.SelectedItems.Count > 0)
			{
				if (lvstudents.SelectedItems[0].Checked)
					if (MessageBox.Show(lvstudents.SelectedItems[0].Text + " already updated. Still proceed?", "USE CURRENT UPDATE", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						return;

				try
				{
                    s_email = getEmailAddress(1, Program.lstudid);

					if (Program.dataSource == Program.DataSources.Access)
					{
                        if (s_email.Length == 0)
                            Program.maindbCmd.CommandText = "update students set set remarks = \"NEWLY PAID\", is_qualified = -1,depslip=-1,depslipscan =" + Program.enq(txtscanfile.Text) + ",s_email=" + Program.enq(txtemailaddress.Text) + " where studid = " + Program.lstudid.ToString();
                        else
                        {
                            if (!s_email.ToLower().Contains(txtemailaddress.Text.ToLower()))
                                Program.maindbCmd.CommandText = "update students set is_qualified = -1, depslip=-1,depslipscan =" + Program.enq(txtscanfile.Text) + ",s_email=" + Program.enq(s_email + ";" + txtemailaddress.Text) + " where studid = " + Program.lstudid.ToString();
                        }

                        Program.maindbCmd.ExecuteNonQuery();

                        if (txtscanfile.Text.Length > 0)
                        {
                            Program.maindbCmd.CommandText = "update students set is_qualified = -1,depslipscan =" + Program.enq(txtscanfile.Text) + " where studid = " + Program.lstudid.ToString();
                            Program.maindbCmd.ExecuteNonQuery();
                        }
                        //Program.createERFfile(Program.lstudid);
                        Program.createprofile_OLEDB(Program.lstudid,true);
					}

                        //not yet modifield for myslq! modify above section!
					else
					{
                        MessageBox.Show(s_email.Length.ToString());
                        if (s_email.Length == 0)
                            Program.OmaindbCmd.CommandText = "update students set remarks='NEWLY PAID', is_qualified = -1,depslip=-1,depslipscan =" + Program.enq(txtscanfile.Text) + ",s_email=" + Program.enq(txtemailaddress.Text) + ",email = \"" + DateTime.Now.ToString() + "\" where studid = " + Program.lstudid.ToString();
                        else
                        {
                            if (!s_email.ToLower().Contains(txtemailaddress.Text.ToLower()))
                                Program.OmaindbCmd.CommandText = "update students set is_qualified = -1,depslip=-1,depslipscan =" + Program.enq(txtscanfile.Text) + ",s_email=" + Program.enq(s_email + ";" + txtemailaddress.Text) + " where studid = " + Program.lstudid.ToString();
                        }
                        Program.OmaindbCmd.ExecuteNonQuery();

                        if (txtscanfile.Text.Length > 0)
                        {
                            Program.OmaindbCmd.CommandText = "update students set is_qualified = -1,depslipscan =" + Program.enq(txtscanfile.Text) + " where studid = " + Program.lstudid.ToString();
                            Program.OmaindbCmd.ExecuteNonQuery();
                        }
                        Program.createprofile_ODBC(Program.lstudid, true);
                    }

					lvstudents.SelectedItems[0].Checked = true;
					
					MessageBox.Show("Updated");
				}
				catch (InvalidOperationException ioe)
				{
					MessageBox.Show("Failed to update: " + ioe.Message);
				}
			}
			else
				MessageBox.Show("Nothing to update.");
		}

		private void cOPYEMAILToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			try
			{
				Clipboard.SetText(txtemailaddress.Text);
			}
			catch (Exception ie)
			{
				MessageBox.Show(ie.Message);
			}
		}

		private void pROFILEToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			open_profile();
		}

		private void qUICKEMAILToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			quick_email();
		}

		private void sETTINGSToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			new settings().ShowDialog(this);
			loadglobals();
		}

		private void mAILERToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			new kartero().Show(this);
		}



		string getRemarks(long sid)
		{
			OleDbCommand c1;
			OdbcCommand c2;
			OleDbDataReader r1;
			OdbcDataReader r2;

			if (Program.dataSource == Program.DataSources.Access)
			{
				c1 = Program.maindbCon.CreateCommand();
				c1.CommandText = "SELECT remarks from students where studid = " + sid.ToString();
				r1 = c1.ExecuteReader();
				r1.Read();
				return Program.getString(r1, "remarks");
			}
			else
			{
				c2 = Program.OmaindbCon.CreateCommand();
				c2.CommandText = "SELECT remarks from students where studid = " + sid.ToString();
				r2 = c2.ExecuteReader();
				r2.Read();
				return Program.getString(r2, "remarks");
			}
		}

		string getEmailAddress(int p,long sid)
		{
			OleDbCommand c1;
			OdbcCommand c2;
			OleDbDataReader r1;
			OdbcDataReader r2;

			if (Program.dataSource == Program.DataSources.Access)
			{
				c1 = Program.maindbCon.CreateCommand();
				if (p == 1)
				{
					c1.CommandText = "SELECT s_email from students where studid = " + sid.ToString();
					r1 = c1.ExecuteReader();
					r1.Read();
					return Program.getString(r1, "s_email");
				}
				else
				{
					c1.CommandText = "SELECT email from students where studid = " + sid.ToString();
					r1 = c1.ExecuteReader();
					r1.Read();
					return Program.getString(r1, "email");
				}
			}
			else
			{
				c2 = Program.OmaindbCon.CreateCommand();
				if (p == 1)
				{
					c2.CommandText = "SELECT s_email from students where studid = " + sid.ToString();
					r2 = c2.ExecuteReader();
					r2.Read();
					return Program.getString(r2, "s_email");
				}
				else
				{
					c2.CommandText = "SELECT email from students where studid = " + sid.ToString();
					r2 = c2.ExecuteReader();
					r2.Read();
					return Program.getString(r2, "email");
				}
			}
		}



		void terminate_all(string m)
		{
			MessageBox.Show(m);
			Environment.Exit(-1);
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
					sbSource.Text = "MySQL: No valid host";
				}
				else
					sbSource.Text = "Source: " + Program.ds_Host;
			}
			else
			{
				if (!fileexists(Program.maindb))
				{
					ofd.Title = "MAIN ACCESS BACKEND";
					ofd.Filter = "Access Old|*.mdb|Access New|*.accdb";
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
				sbSource.Text = "Source: " + Program.maindb;
			}

			Program.savepaths();
		}

		private bool id_exists(long id)
		{
			bool retval;
			Program.emaildbCmd.CommandText = "select uid from emails where uid = " + id.ToString();
			Program.emdr = Program.emaildbCmd.ExecuteReader();
			retval = Program.emdr.Read();
			Program.emdr.Close();
			return retval;
		}

		private bool msgid_exists(string id)
		{
			bool retval;
			Program.emaildbCmd.CommandText = "select msgid from emails where msgid like " + Program.enq(id);
			Program.emdr = Program.emaildbCmd.ExecuteReader();
			retval = Program.emdr.Read();
			Program.emdr.Close();
			return retval;
		}

		void runcommand(string command)
		{
			Program.emaildbCmd.CommandText = command;
			Program.emaildbCmd.ExecuteNonQuery();
		}

		long newmsguid()
		{
			OleDbDataReader dr;
			OleDbCommand c;
			long retval;
			c = Program.emaildbCon.CreateCommand();
			c.CommandText = "SELECT MAX(UID) AS NEWID FROM EMAILS";
			dr = c.ExecuteReader();
			dr.Read();
			retval = dr.GetInt32(dr.GetOrdinal("NEWID"))+1;
			dr.Close();
			return retval;
		}


		void fill_students(int searchby)
		{
			switch (searchby)
			{
				case 1:
					if (Program.dataSource == Program.DataSources.Access)
						Program.maindbCmd.CommandText = "select s.s_email,s.studid,s.fullname,c.centername,s.ilevel,s.depslip,s.school,s.shirtsize from students as s inner join centers as c on s.center=c.centerid where s.fullname like \"%" + txtsearch.Text + "%\" order by s.fullname";
					else
						Program.OmaindbCmd.CommandText = "select s.s_email,s.studid,s.fullname,c.centername,s.ilevel,s.depslip,s.school,s.shirtsize from students as s inner join centers as c on s.center=c.centerid where s.fullname like \"%" + txtsearch.Text + "%\" order by s.fullname";
					break;

				case 2:
					if (Program.dataSource == Program.DataSources.Access)
						Program.maindbCmd.CommandText = "select s.s_email,s.studid,s.fullname,c.centername,s.ilevel,s.depslip,s.school,s.shirtsize from students as s inner join centers as c on s.center=c.centerid where s.s_email like \"%" + txtemailaddress.Text + "%\" or s.email like \"%" + txtemailaddress.Text + "%\"";
					else
						Program.OmaindbCmd.CommandText = "select s.s_email,s.studid,s.fullname,c.centername,s.ilevel,s.depslip,s.school,s.shirtsize from students as s inner join centers as c on s.center=c.centerid where s.s_email like \"%" + txtemailaddress.Text + "%\" or s.email like \"%" + txtemailaddress.Text + "%\"";
					break;
			}

			if (Program.dataSource == Program.DataSources.Access)
			{
				try
				{
					Program.maindr = Program.maindbCmd.ExecuteReader();

				}
				catch (Exception e1)
				{
					MessageBox.Show(e1.Message);
					filling_students = false;
					return;
				}
			}
			else
			{
				try
				{
					Program.Omaindr = Program.OmaindbCmd.ExecuteReader();
				}
				catch (Exception e1)
				{
					if (!Program.TryMysql())
						MessageBox.Show(e1.Message);
					    filling_students = false;
					return;
				}
			}
			
			lvstudents.Items.Clear();
			lvstudents.Visible = false;


			if (Program.dataSource == Program.DataSources.Access)
			{
				while (Program.maindr.Read() && filling_students)
				{
					string tx = Program.getString(Program.maindr, "fullname");
					long ix = Program.getLong(Program.maindr, "studid");
					ListViewItem l = lvstudents.Items.Add(tx);
					l.Tag = ix;
					l.SubItems.Add("");
					l.SubItems.Add("");
					l.SubItems.Add("");
					l.SubItems.Add("");
                    l.SubItems.Add("");
					l.SubItems[1].Text = Program.getString(Program.maindr, "centername");
					l.SubItems[2].Text = Program.getString(Program.maindr, "school");
					l.SubItems[3].Text = Program.getString(Program.maindr, "shirtsize");
					l.SubItems[4].Text = Program.getLong(Program.maindr, "ilevel").ToString();
                    l.SubItems[5].Text = Program.getString(Program.maindr, "s_email").ToString();
					if (Program.getLong(Program.maindr, "depslip") < 0)
						l.Checked = true;
				}
				Program.maindr.Close();
			}
			else
			{
				while (Program.Omaindr.Read() && filling_students)
				{
					string tx = Program.getString(Program.Omaindr, "fullname");
					long ix = Program.getLong(Program.Omaindr, "studid");
					ListViewItem l = lvstudents.Items.Add(tx);
					l.Tag = ix;
					l.SubItems.Add("");
					l.SubItems.Add("");
					l.SubItems.Add("");
					l.SubItems.Add("");
                    l.SubItems.Add("");
					l.SubItems[1].Text = Program.getString(Program.Omaindr, "centername");
					l.SubItems[2].Text = Program.getString(Program.Omaindr, "school");
					l.SubItems[3].Text = Program.getString(Program.Omaindr, "shirtsize");
					l.SubItems[4].Text = Program.getLong(Program.Omaindr, "ilevel").ToString();
                    l.SubItems[5].Text = Program.getString(Program.Omaindr, "s_email").ToString();
					if (Program.getLong(Program.Omaindr, "depslip") < 0)
						l.Checked = true;
				}
				Program.Omaindr.Close();
			}
			filling_students = false;
			if (lvstudents.Items.Count > 0 && searchby == 1)
			{
				lvstudents.Focus();
				lvstudents.Items[0].Selected = true;
			}
			lvstudents.Visible = true;
		}


		void quick_email()
		{
			d_send d = new d_send();
			d.txtTo.Text = txtemailaddress.Text;
			d.ShowDialog(this);
		}

		void open_profile()
		{
			if (lvstudents.SelectedItems.Count > 0)
			{
				Program.lstudid = Int32.Parse(lvstudents.SelectedItems[0].Tag.ToString());
				new profile().ShowDialog(this);
			}
		}

		private void aBOUTToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new about().ShowDialog(this);
		}

        private void gRABEMAILToolStripMenuItem_Click(object sender, EventArgs e)
        {
    

        }

        private void gRABEMAILToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                txtemailaddress.Focus();
                Clipboard.Clear();
                Interaction.AppActivate("Mozilla Thunderbird");
                SendKeys.SendWait("+{F10}Q");
                Thread.Sleep(300);
                Interaction.AppActivate("Mozilla Thunderbird");
                SendKeys.SendWait("^c~");
                txtemailaddress.Text = Clipboard.GetText();
                this.Activate();
            }
            catch (Exception x)
            {
            }
        }

        private void nEWPROFILEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new profileX().Show(this);
        }

        private void mOSTPMAILERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new qkartero().Show(this);
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void cONNECTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadglobals();
        }
	}


	class cust_listitem
	{
		public long Value { get; set; }
		public string Text { get; set; }
		public override string ToString()
		{
			return Text;
		}
		public cust_listitem(string t, long v)
		{
			this.Text = t;
			this.Value = v;
		}
	}
}
