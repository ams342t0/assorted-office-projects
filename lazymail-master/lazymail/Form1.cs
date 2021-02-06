using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Limilabs.Mail;
using Limilabs.Mail.MIME;
using Limilabs.Client.IMAP;
using System.Data.OleDb;
using System.Data.Odbc;
using Microsoft.Win32;
using System.IO;
using System.Threading;


namespace lazymail
{
	public partial class Form1 : Form
	{
		public delegate void fillmaildelegate(int v);
		fillmaildelegate fm;
		Imap imapclient;
		List<long> mail_ids;

		bool filling_students=false;
		bool logged_in;
		bool updating_emails = false;
		public ListViewColumnSorter lvcs;

		public Form1()
		{
			InitializeComponent();
			fm = new fillmaildelegate(update_emails);
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			Environment.Exit(0);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			sbText.Text = "Starting...";
			logged_in = clientlogin();
			lvcs = new ListViewColumnSorter();
			lvemails.ListViewItemSorter = lvcs;
			lvcs.Order = SortOrder.None;
			lvcs.SortColumn = 0;
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			loadglobals();
			Program.pv = new picview();
			fill_emails();
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

		private void listImages_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listImages.SelectedItems.Count > 0) 
				txtscanfile.Text = ((cust_listitem)listImages.SelectedItem).Text;
		}

		private void lvemails_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			txtemailaddress.Text = e.Item.SubItems[1].Text;
			txtbody.Text = getbodymsg(e.Item.Tag.ToString());
			txtscanfile.Text = "";
			txtName.Text = "";
			fill_images(Int32.Parse(e.Item.Tag.ToString()));
			Program.lstudid = 999999;
		}

        private void lvstudents_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Program.lstudid = Int32.Parse(e.Item.Tag.ToString());
            txtName.Text = e.Item.Text;
        }

		private void lvemails_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if (lvcs.SortColumn != e.Column)
				lvcs.SortColumn = e.Column;

			if (lvcs.Order == SortOrder.Ascending)
				lvcs.Order = SortOrder.Descending;
			else
				lvcs.Order = SortOrder.Ascending;
			lvemails.Sort();
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
			lvemails.Focus();
		}

		private void uPDATEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (txtscanfile.Text.Length > 0 && txtemailaddress.Text.Length > 0 && txtName.Text.Length > 0)
			{
				if (lvstudents.SelectedItems[0].Checked)
				{
					if (MessageBox.Show(lvstudents.SelectedItems[0].Text + " already updated. Still proceed?", "USE CURRENT UPDATE", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
					{
						return;
					}
				}
				try
				{

					if (Program.dataSource == Program.DataSources.Access)
					{
						Program.maindbCmd.CommandText = "update students set depslip=-1,depslipscan =" + Program.enq(txtscanfile.Text) + ",s_email=" + Program.enq(txtemailaddress.Text) + ",fullname=" + Program.enq(txtName.Text) + " where studid = " + Program.lstudid.ToString();
						Program.maindbCmd.ExecuteNonQuery();
					}
					else
					{
						Program.OmaindbCmd.CommandText = "update students set depslip=-1,depslipscan =" + Program.enq(txtscanfile.Text) + ",s_email=" + Program.enq(txtemailaddress.Text) + ",fullname=" + Program.enq(txtName.Text) + " where studid = " + Program.lstudid.ToString();
						Program.OmaindbCmd.ExecuteNonQuery();
					}

					Program.emaildbCmd.CommandText = "update emails set processed = true where uid = " + lvemails.SelectedItems[0].Tag.ToString();
					Program.emaildbCmd.ExecuteNonQuery();

					lvemails.SelectedItems[0].Checked = true;
					lvstudents.SelectedItems[0].Checked = true;
					lvemails.SelectedItems[0].SubItems[4].Text = "";
					MessageBox.Show("Updated");
				}
				catch (InvalidOperationException ioe)
				{
					MessageBox.Show("Failed to update: " + ioe.Message);
				}
			}
			else
				MessageBox.Show("Nothing to update.");
			lvemails.Focus();
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

		private void vIEWSCANToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (listImages.Items.Count > 0)
			{
				Program.pv = new picview();
				Program.pv.fpath = Path.Combine(Program.rootfolder, @"REPLIES", ((cust_listitem)listImages.SelectedItem).Text);
				Program.pv.redo();
				Program.pv.Show(this);
			}
			lvemails.Focus();
		}

		private void sETTINGSToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			new settings().ShowDialog(this);
			loadglobals();
			fill_emails();
		}

		private void mAILERToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			new kartero().Show(this);
		}

		private void gETMAILSToolStripMenuItem_Click(object sender, EventArgs e)
		{
			getmails();
		}

//private methods
		void fill_images(long id)
		{
			listImages.Items.Clear();

			Program.emaildbCmd.CommandText = "select filename from files where uid = " + id.ToString();
			Program.emdr = Program.emaildbCmd.ExecuteReader();
			long i = 0;
			while (Program.emdr.Read())
			{
				listImages.Items.Add(new cust_listitem(Program.getString(Program.emdr, "filename"), i++));
			}

			if (listImages.Items.Count > 0)
			{
				txtscanfile.Text = ((cust_listitem)listImages.Items[0]).Text;
				listImages.SelectedIndex = 0;
			}

			Program.emdr.Close();
		}

		bool clientlogin()
		{
			sbText.Text = "Connecting to server...";
			imapclient = new Imap();
			try
			{
				imapclient.ConnectSSL("imap." + Program.host);
			}
			catch (Limilabs.Client.ServerException ix)
			{
				sbText.Text = "Unable to connect to server: " + ix.Message;
				return false;
			}

			try
			{
				imapclient.UseBestLogin(Program.userid, Program.password);
				imapclient.Compress();
			}
			catch (Limilabs.Client.IMAP.ImapResponseException ix2)
			{
				sbText.Text = "Unable to login: " + ix2.Message;
				return false;
			}
			return true;
		}

		void getmails()
		{
			if (!logged_in)
				logged_in = clientlogin();

			if (logged_in)
			{
				sbText.Text = "Checking new messages...";
				try
				{
					if (!updating_emails)
					{
                        if (!imapclient.IsCompressed)
                            imapclient.Compress();
						imapclient.SelectInbox();
						mail_ids = imapclient.Search(Flag.All);
						sbText.Text = mail_ids.Count.ToString() + " messages found.";
						updating_emails = true;
						fm.BeginInvoke(0, null, null);
					}
					else
						MessageBox.Show("Currently updating emails");
				}
				catch (Limilabs.Client.ServerException i)
				{
					sbText.Text = "Unable to update emails:" + i.Message;
					logged_in = false;
				}
			}
			else
			{
				sbText.Text = "Not logged in.";
			}
		}

		string getbodymsg(string id)
		{
			string s = "";
			Program.emaildbCmd.CommandText = "select body from emails where uid = " + id;
			Program.emdr = Program.emaildbCmd.ExecuteReader();
			while (Program.emdr.Read())
			{
				s = Program.getString(Program.emdr, "body");
			}
			Program.emdr.Close();
			return s;
		}


		//could've used random temp filename to avoid duplication, but what the heck... 
		// keep adding '$' at the end of filename until there are no duplicates
		private string check_file(string f)
		{
			string sp;

			if (File.Exists(Path.Combine(Program.rootfolder, @"REPLIES", f)))
			{
				sp = check_file(Path.Combine(Program.rootfolder, @"REPLIES", Path.GetFileNameWithoutExtension(f) + "$" + Path.GetExtension(f)));
				return sp;
			}
			else
			{
				sp = Path.Combine(Program.rootfolder, @"REPLIES", f);
				return sp;
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


			if (!fileexists(Program.emaildb))
			{
				ofd.Title = "EMAIL ACCESS BACKEND";
				ofd.Filter = "EMAIL DB | emails.mdb";
				if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					Program.emaildb = ofd.FileName;
				else
					MessageBox.Show("Select valid email backend db.");
			}

			try
			{
				Program.emaildbCon = new OleDbConnection();
				Program.emaildbCon.ConnectionString = "Provider=Microsoft.jet.oledb.4.0; data source = " + Program.emaildb;
				Program.emaildbCon.Open();
				Program.emaildbCmd = Program.emaildbCon.CreateCommand();
			}
			catch (Exception ex1)
			{
				//terminate_all("Problem connecting to email backend\n" + ex1.Message);
				MessageBox.Show("Problem connecting to email backend\n" + ex1.Message);
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

		void runcommand(string command)
		{
			Program.emaildbCmd.CommandText = command;
			Program.emaildbCmd.ExecuteNonQuery();
		}

		void update_emails(int v)
		{
			string sFrom, sSubject, sBody, sAddr;
			long c = 0;
			IMail mail;
			bool m_error = false;
            MessageInfo mi;
            
			lvemails.Sorting = SortOrder.None;
			lvcs.Order = SortOrder.None;
			lvcs.SortColumn = 0;

			sbText.Text = "Checking new emails...";

			foreach (long i in mail_ids)
			{
				if (!updating_emails)
					break;

				c++;
				if (id_exists(i))
					continue;

                mi = imapclient.GetMessageInfoByUID(i);
                if (((long)mi.Envelope.Size) > 2000000)
                {
                    sbText.Text = "Skipped: (" + mi.Envelope.From[0].Address + ", " + ((long)mi.Envelope.Size/1048576.0f).ToString("0.00") + " mb), " + c.ToString() + " of " + mail_ids.Count.ToString();
                    continue;
                }
				sbText.Text = "Opening message: (" + mi.Envelope.From[0].Address + ", " +  mi.Envelope.Size.ToString() + " bytes), " +  c.ToString() + " of " + mail_ids.Count.ToString();

				try
				{
					mail = new MailBuilder().CreateFromEml(imapclient.GetMessageByUID(i));
				}
				catch (Limilabs.Client.IMAP.ImapResponseException ire)
				{
					updating_emails = false;
					sbText.Text = "Failed to open message: " + ire.Message;
					return;
				}

				sFrom = mail.From[0].Name;
				sAddr = mail.From[0].Address;
				sSubject = mail.Subject.Replace("\"", "^");
				sBody = mail.GetBodyAsText().Replace("\"", "^");
				ListViewItem li = lvemails.Items.Add(i.ToString("00000"));
				li.Tag = i;
				li.SubItems.Add(sAddr);
				li.SubItems.Add(sSubject);
				if (sBody.Length > 15)
					li.SubItems.Add(sBody.Substring(0, 14) + "...");
				else
					li.SubItems.Add(sBody);
				li.SubItems.Add("NEW");

				sbText.Text = "Adding " + sAddr + "...";
				runcommand("insert into emails(uid,sfrom,emailaddress,subject,body,processed) values(" + i.ToString() + "," + Program.enq(sFrom) + "," + Program.enq(sAddr) + "," + Program.enq(sSubject) + "," + Program.enq(sBody) + ",false)");

				m_error = false;
				foreach (MimeData md in mail.Attachments)
				{

					if (!Path.GetExtension(md.SafeFileName).ToUpper().Equals(".TXT"))
					{
						string sp = check_file(Path.Combine(Program.rootfolder, @"REPLIES", md.SafeFileName));
						runcommand("insert into files values(" + i.ToString() + "," + Program.enq(Path.GetFileName(sp)) + ")");
						try
						{
							sbText.Text = "Saving " + sFrom + " file: " + sp + "...";
							md.Save(sp);
						}
						catch (Limilabs.Client.ServerException e)
						{
							sbText.Text = "Can't save file: " + e.Message;
							m_error = true;
						}
					}
				}

				if (!m_error)
				{
					foreach (MimeData md2 in mail.Visuals)
					{
						if (!Path.GetExtension(md2.SafeFileName).ToUpper().Equals(".TXT"))
						{
							string sp2 = check_file(Path.Combine(Program.rootfolder, @"REPLIES", md2.SafeFileName));
							runcommand("insert into files values(" + i.ToString() + ",\"" + Path.GetFileName(sp2) + "\")");
							try
							{
								sbText.Text = "Saving " + sFrom + " file: " + sp2 + "...";
								md2.Save(sp2);
							}
							catch (Limilabs.Client.ServerException e)
								{
									sbText.Text = "Can't save: " + e.Message;
									m_error = true;
								}
						}
					}
				}
				if (m_error)
				{
					Program.emaildbCmd.CommandText = "delete * from emails where uid = " + i.ToString();
					Program.emaildbCmd.ExecuteNonQuery();
					Program.emaildbCmd.CommandText = "delete * from files where uid = " + i.ToString();
					Program.emaildbCmd.ExecuteNonQuery();
					li.SubItems[1].Text = "Can't open";
				}
			}
			updating_emails = false;
			if (lvemails.Items.Count > 0)
			{
				lvemails.Items[lvemails.Items.Count - 1].Selected = true;
				lvemails.Items[lvemails.Items.Count - 1].EnsureVisible();
			}
			mailcount.Text = "Mails: " + lvemails.Items.Count.ToString();
			if (!m_error)
				sbText.Text = "Done.";
		}

		void fill_emails()
		{
			string b;
			lvemails.Visible = false;
			lvemails.Items.Clear();
			lvemails.Sorting = SortOrder.None;
			lvcs.Order = SortOrder.None;
			lvcs.SortColumn = 0;

			Program.emaildbCmd.CommandText = "select * from emails order by refnum";
			Program.emdr = Program.emaildbCmd.ExecuteReader();
			while (Program.emdr.Read())
			{
				ListViewItem li = lvemails.Items.Add(Program.getLong(Program.emdr, "uid").ToString("00000"));
				li.Tag = Program.getLong(Program.emdr, "uid");
				li.SubItems.Add(Program.getString(Program.emdr, "emailaddress"));
				li.SubItems.Add(Program.getString(Program.emdr, "subject"));
				b = Program.getString(Program.emdr, "body");
				if (b.Length > 25)
					li.SubItems.Add(b.Substring(0, 24) + "...");
				else
					li.SubItems.Add(b);
				li.Checked = Program.getBool(Program.emdr, "processed");
				li.SubItems.Add("done");
			}
			Program.emdr.Close();
			sbText.Text = "Loaded emails.";
			mailcount.Text = "Mails: " + lvemails.Items.Count.ToString();
			lvemails.Visible = true;

			if (lvemails.Items.Count > 0)
			{
				lvemails.Items[lvemails.Items.Count - 1].Selected = true;
				lvemails.Items[lvemails.Items.Count - 1].EnsureVisible();
				lvemails.Focus();
			}

		}

		void fill_students(int searchby)
		{
			switch (searchby)
			{
				case 1:
					if (Program.dataSource == Program.DataSources.Access)
						Program.maindbCmd.CommandText = "select s.studid,s.fullname,c.centername,s.ilevel,s.depslip,s.school,s.shirtsize from students as s inner join centers as c on s.center=c.centerid where s.fullname like \"%" + txtsearch.Text + "%\" order by s.fullname";
					else
						Program.OmaindbCmd.CommandText = "select s.studid,s.fullname,c.centername,s.ilevel,s.depslip,s.school,s.shirtsize from students as s inner join centers as c on s.center=c.centerid where s.fullname like \"%" + txtsearch.Text + "%\" order by s.fullname";
					break;

				case 2:
					if (Program.dataSource == Program.DataSources.Access)
						Program.maindbCmd.CommandText = "select s.studid,s.fullname,c.centername,s.ilevel,s.depslip,s.school,s.shirtsize from students as s inner join centers as c on s.center=c.centerid where s.s_email like \"%" + txtemailaddress.Text + "%\" or s.email like \"%" + txtemailaddress.Text + "%\"";
					else
						Program.OmaindbCmd.CommandText = "select s.studid,s.fullname,c.centername,s.ilevel,s.depslip,s.school,s.shirtsize from students as s inner join centers as c on s.center=c.centerid where s.s_email like \"%" + txtemailaddress.Text + "%\" or s.email like \"%" + txtemailaddress.Text + "%\"";

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
					l.SubItems[1].Text = Program.getString(Program.maindr, "centername");
					l.SubItems[2].Text = Program.getString(Program.maindr, "school");
					l.SubItems[3].Text = Program.getString(Program.maindr, "shirtsize");
					l.SubItems[4].Text = Program.getLong(Program.maindr, "ilevel").ToString();
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
					l.SubItems[1].Text = Program.getString(Program.Omaindr, "centername");
					l.SubItems[2].Text = Program.getString(Program.Omaindr, "school");
					l.SubItems[3].Text = Program.getString(Program.Omaindr, "shirtsize");
					l.SubItems[4].Text = Program.getLong(Program.Omaindr, "ilevel").ToString();
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
				lvemails.Focus();
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

		private void rEFERENCEFILEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listImages.SelectedItems.Count > 0 && Program.lstudid < 999999) 
			{
				if (Program.dataSource == Program.DataSources.Access)
				{
					Program.maindbCmd.CommandText = "INSERT INTO STUDFILES VALUES(" + Program.lstudid.ToString() + "," + Program.enq(((cust_listitem)listImages.SelectedItem).Text) +")";
					Program.maindbCmd.ExecuteNonQuery();
				}
				else
				{
					Program.OmaindbCmd.CommandText = "INSERT INTO STUDFILES VALUES(" + Program.lstudid.ToString() + "," + Program.enq(((cust_listitem)listImages.SelectedItem).Text) + ")";
					Program.OmaindbCmd.ExecuteNonQuery();
				}
			}
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
