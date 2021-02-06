using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Threading;
using System.Collections;

namespace lazymail
{
    public partial class kartero : Form
    {
		public delegate void filldelegate();
        public NetworkCredential nc;
        public string query_string;
        public string query_filter;
        public ListViewColumnSorter lcs;
		filldelegate fill_async;
		bool filling = false;
		public static MailMessage []messages;
        
        public kartero()
        {
            InitializeComponent();
        }

        private void kartero_Load(object sender, EventArgs e)
        {
			Program.k = this;

            nc = new NetworkCredential(Program.userid,Program.password);

            query_string = "select s.studid,s.fullname,s.ilevel,c.centername,s.school,s.s_email,s.email,s.is_qualified,s.is_emailed, " + 
                           "s.depslip,s.is_registered,s.haspicture,s.profilescan,is_noted,s.shirtsize from students as s inner join " +
                           "centers as c on s.center=c.centerid";
            lcs = new ListViewColumnSorter();
            lvList.ListViewItemSorter = lcs;
            lvList.Sorting = SortOrder.None;
            lcs.Order = SortOrder.None;
			sbcount.Text = "0";
			messages = new MailMessage[30];
        }

        void buildfilter()
        {
            query_filter = "";

            if (chkDepslip.Checked)
                query_filter = " where s.depslip<0";
            else
                query_filter = " where s.depslip=0";

            if (chkEmailed.Checked)
                if (query_filter.Length == 0)
                    query_filter = " where s.is_emailed<0";
                else
                    query_filter += " and s.is_emailed < 0";
			else
				if (query_filter.Length == 0)
					query_filter = " where s.is_emailed=0";
				else
					query_filter += " and s.is_emailed = 0";

            if (chkQualified.Checked)
                if (query_filter.Length == 0)
                    query_filter = " where s.is_qualified<0";
                else
                    query_filter += " and s.is_qualified < 0";
            else
                if (query_filter.Length == 0)
                    query_filter = " where s.is_qualified=0";
                else
                    query_filter += " and s.is_qualified = 0";

        }

        string retbool(long i)
        {
            if (i == 0)
                return "NO";
            else
                return "YES";
        }

        void fill_list_OLEDB()
        {
			lvList.Visible = false;
            lvList.Items.Clear();
            lvList.Sorting = SortOrder.None;
            lcs.Order = SortOrder.None;
            lcs.SortColumn = 0;
            Program.setcmd(ref Program.maindbCmd, query_string + query_filter);
            Program.maindr = Program.runcmd_ret(Program.maindbCmd);
			filling = true;
            while (Program.maindr.Read() && filling)
            {
                ListViewItem l = lvList.Items.Add(Program.getString(Program.maindr,"fullname"));
                l.Tag = Program.getLong(Program.maindr,"studid");
                l.SubItems.Add(Program.getString(Program.maindr,"school"));
                l.SubItems.Add(Program.getString(Program.maindr,"centername"));
                l.SubItems.Add(Program.getString(Program.maindr,"s_email"));
                l.SubItems.Add(Program.getString(Program.maindr,"profilescan"));
                l.SubItems.Add(retbool(Program.getLong(Program.maindr,"is_qualified")));
                l.SubItems.Add(retbool(Program.getLong(Program.maindr,"depslip")));
                l.SubItems.Add(retbool(Program.getLong(Program.maindr,"is_noted")));
				l.SubItems.Add("");
				l.SubItems.Add(Program.getString(Program.maindr,"shirtsize"));
				l.SubItems.Add(retbool(Program.getLong(Program.maindr, "haspicture")));
				l.SubItems.Add(Program.getLong(Program.maindr, "ilevel").ToString("00"));

				if (Program.getString(Program.maindr, "email").Length > 0)
				{
					ListViewItem l2 = lvList.Items.Add(Program.getString(Program.maindr, "fullname"));
					l2.Tag = Program.getLong(Program.maindr, "studid");
					l2.SubItems.Add(Program.getString(Program.maindr, "school"));
					l2.SubItems.Add(Program.getString(Program.maindr, "centername"));
					l2.SubItems.Add(Program.getString(Program.maindr, "email"));
					l2.SubItems.Add(Program.getString(Program.maindr, "profilescan"));
					l2.SubItems.Add(retbool(Program.getLong(Program.maindr, "is_qualified")));
					l2.SubItems.Add(retbool(Program.getLong(Program.maindr, "depslip")));
					l2.SubItems.Add(retbool(Program.getLong(Program.maindr, "is_noted")));
					l2.SubItems.Add("");
					l2.SubItems.Add(Program.getString(Program.maindr, "shirtsize"));
					l2.SubItems.Add(retbool(Program.getLong(Program.maindr, "haspicture")));
					l2.SubItems.Add(Program.getLong(Program.maindr, "ilevel").ToString("00"));

				}
            }
            Program.maindr.Close();
            sbcount.Text = lvList.Items.Count.ToString();
			filling = false;
			lvList.Visible = true;
        }

		void fill_list_ODBC()
		{
			lvList.Visible = false;
			lvList.Items.Clear();
			lvList.Sorting = SortOrder.None;
			lcs.Order = SortOrder.None;
			lcs.SortColumn = 0;
			Program.setcmd(ref Program.OmaindbCmd, query_string + query_filter);
			Program.Omaindr = Program.runcmd_ret(Program.OmaindbCmd);
			filling = true;
			while (Program.Omaindr.Read() && filling)
			{
				ListViewItem l = lvList.Items.Add(Program.getString(Program.Omaindr, "fullname"));
				l.Tag = Program.getLong(Program.Omaindr, "studid");
				l.SubItems.Add(Program.getString(Program.Omaindr, "school"));
				l.SubItems.Add(Program.getString(Program.Omaindr, "centername"));
				l.SubItems.Add(Program.getString(Program.Omaindr, "s_email"));
				l.SubItems.Add(Program.getString(Program.Omaindr, "profilescan"));
				l.SubItems.Add(retbool(Program.getLong(Program.Omaindr, "is_qualified")));
				l.SubItems.Add(retbool(Program.getLong(Program.Omaindr, "depslip")));
				l.SubItems.Add(retbool(Program.getLong(Program.Omaindr, "is_noted")));
				l.SubItems.Add("");
				l.SubItems.Add(Program.getString(Program.Omaindr, "shirtsize"));
				l.SubItems.Add(retbool(Program.getLong(Program.Omaindr, "haspicture")));
				l.SubItems.Add(Program.getLong(Program.Omaindr, "ilevel").ToString("00"));

				if (Program.getString(Program.Omaindr, "email").Length > 0)
				{
					ListViewItem l2 = lvList.Items.Add(Program.getString(Program.Omaindr, "fullname"));
					l2.Tag = Program.getLong(Program.Omaindr, "studid");
					l2.SubItems.Add(Program.getString(Program.Omaindr, "school"));
					l2.SubItems.Add(Program.getString(Program.Omaindr, "centername"));
					l2.SubItems.Add(Program.getString(Program.Omaindr, "email"));
					l2.SubItems.Add(Program.getString(Program.Omaindr, "profilescan"));
					l2.SubItems.Add(retbool(Program.getLong(Program.Omaindr, "is_qualified")));
					l2.SubItems.Add(retbool(Program.getLong(Program.Omaindr, "depslip")));
					l2.SubItems.Add(retbool(Program.getLong(Program.Omaindr, "is_noted")));
					l2.SubItems.Add("");
					l2.SubItems.Add(Program.getString(Program.Omaindr, "shirtsize"));
					l2.SubItems.Add(retbool(Program.getLong(Program.Omaindr, "haspicture")));
					l2.SubItems.Add(Program.getLong(Program.Omaindr, "ilevel").ToString("00"));

				}
			}
			Program.Omaindr.Close();
			sbcount.Text = lvList.Items.Count.ToString();
			filling = false;
			lvList.Visible = true;
		}


		bool busy()
		{
			if (lvList.Items.Count > 0)
			{
				foreach (ListViewItem l in lvList.Items)
				{
					if (l.Checked && l.SubItems[8].Text.ToUpper().Equals("SENDING..."))
						return true;
				}
			}
			return false;
		}

        private void rEFRESHToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if (busy())
			{
				return;
			}

			if (filling)
			{
				filling = false;
				return;
			}

            buildfilter();

			if (Program.dataSource == Program.DataSources.Access)
				fill_async = new filldelegate(fill_list_OLEDB);
			else
				fill_async = new filldelegate(fill_list_ODBC);

			fill_async.BeginInvoke(null, null);
        }

        private void lvList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lcs.SortColumn != e.Column)
                lcs.SortColumn = e.Column;
            
            if (lcs.Order == SortOrder.Ascending)
                lcs.Order = SortOrder.Descending;
            else
                lcs.Order = SortOrder.Ascending;

            lvList.Sort();
        }

		void send_standardreply()
		{
			string msgs;
            msgs = (File.OpenText(Path.Combine(Program.rootfolder,@"MSGS","regformtxt.txt"))).ReadToEnd();
			int mi = 0;
			if (lvList.Items.Count > 0)
			{
				foreach (ListViewItem l in lvList.Items)
				{
					if (!l.Checked)
						continue;

					if (l.SubItems[3].Text.Length == 0)
					{
						l.SubItems[8].Text = "No email!";
						continue;
					}
					
					//MailMessage m = new MailMessage("mtg2015inhouse@gmail.com", l.SubItems[3].Text, "Reminders about registration form", msgs);
					messages[mi] = new MailMessage("mtg2015inhouse@gmail.com", l.SubItems[3].Text, "Reminders about registration form", msgs);
					cmailer c = new cmailer(nc);
					c.send(messages[mi], new dummyobject(l,1,mi));
					mi++;
				}
			}
		}

		void send_registrationform()
		{
			string msgs;
			string att_path;
			int mi=0;

			if (lvList.Items.Count > 0)
			{
				foreach (ListViewItem l in lvList.Items)
				{
					if (!l.Checked)
						continue;

					if (l.SubItems[3].Text.Length == 0)
					{
						l.SubItems[8].Text = "No email!";
						continue;
					}

					att_path = fetchregform(Int32.Parse(l.Tag.ToString()));

					if (att_path.Length==0)
					{
						l.SubItems[8].Text = "Registration form not found.";
						continue;
					}

					msgs = (File.OpenText(Path.Combine(Program.rootfolder, @"MSGS", "regformtxt.txt"))).ReadToEnd();

					//MailMessage m = new MailMessage("mtg2015inhouse@gmail.com", l.SubItems[3].Text, "Electronic Reply Form of " + l.Text, msgs);
					messages[mi] = new MailMessage("mtg2015inhouse@gmail.com", l.SubItems[3].Text, "Electronic Reply Form of " + l.Text, msgs);
					messages[mi].Attachments.Add(new Attachment(att_path));
					cmailer c = new cmailer(nc);
					c.send(messages[mi],new dummyobject(l,2,mi));
					mi++;
				}
			}
		}

		void send_modified_erf()
		{
			string msgs;
			string att_path;
			int mi=0;
			if (lvList.Items.Count > 0)
			{
				foreach (ListViewItem l in lvList.Items)
				{
					if (!l.Checked)
						continue;

					if (l.SubItems[3].Text.Length == 0)
					{
						l.SubItems[8].Text = "No email!";
						continue;
					}

					att_path = fetchregform(Int32.Parse(l.Tag.ToString()));

					if (att_path.Length == 0)
					{
						l.SubItems[8].Text = "Registration form not found.";
						continue;
					}

					msgs = (File.OpenText(Path.Combine(Program.rootfolder, @"MSGS", "modreg.txt"))).ReadToEnd();

					//MailMessage m = new MailMessage("mtg2015inhouse@gmail.com", l.SubItems[3].Text, "UPDATED Electronic Reply Form (ERF) of " + l.Text, msgs);
					messages[mi] = new MailMessage("mtg2015inhouse@gmail.com", l.SubItems[3].Text, "UPDATED Electronic Reply Form (ERF) of " + l.Text, msgs);
					messages[mi].Attachments.Add(new Attachment(att_path));
					cmailer c = new cmailer(nc);
					c.send(messages[mi], new dummyobject(l, 2,mi));
					mi++;
				}
			}
		}


		void send_changevenue()
		{
			string msgs;
			int mi = 0;
			if (lvList.Items.Count > 0)
			{
				foreach (ListViewItem l in lvList.Items)
				{
					if (!l.Checked)
						continue;

					if (l.SubItems[3].Text.Length == 0)
					{
						l.SubItems[8].Text = "No email!";
						continue;
					}

					msgs = (File.OpenText(Path.Combine(Program.rootfolder, @"MSGS", "changevenue.txt"))).ReadToEnd();

					//MailMessage m = new MailMessage("mtg2015inhouse@gmail.com", l.SubItems[3].Text, "Change of venue", msgs);
					messages[mi] = new MailMessage("mtg2015inhouse@gmail.com", l.SubItems[3].Text, "Change of venue", msgs);
					cmailer c = new cmailer(nc);
					c.send(messages[mi], new dummyobject(l, 3,mi));
					mi++;
				}
			}
		}


		string fetchregform(long id)
		{
			string path =Path.Combine(Program.rootfolder,@"ERF", id.ToString("00000") + ".pdf");
			if (File.Exists(path))
				return path;
			else
				return "";
		}

		private void sTANDARDREPLYToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (busy())
			{
				MessageBox.Show("Still busy sending messages.");
				return;
			}

			if (MessageBox.Show("Continue sending standard emails to checked students?","STANDARD EMAIL",MessageBoxButtons.YesNo)== System.Windows.Forms.DialogResult.Yes)
				send_standardreply();
		}

		private void cHECKALLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (busy())
			{
				MessageBox.Show("Still busy sending messages.");
				return;
			}

			if (lvList.Items.Count == 0)
				return;
			int count = 0;
			foreach (ListViewItem l in lvList.Items)
			{
				l.Checked = true;
				count++;
				if (count == 30)
					return;
			}
		}

		private void uNCHECKALLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (busy())
			{
				MessageBox.Show("Still busy sending messages.");
				return;
			}

			if (lvList.Items.Count == 0)
				return;

			foreach (ListViewItem l in lvList.Items)
			{
				l.Checked = false;
			}
		}

		private void rEGISTRATIONFORMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (busy())
			{
				MessageBox.Show("Still busy sending messages.");
				return;
			}

			if (MessageBox.Show("Continue sending ERF to checked students?", "ERF EMAIL", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				send_registrationform();
		}

		private void cHANGEVENUEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (busy())
			{
				MessageBox.Show("Still busy sending messages.");
				return;
			}

			if (MessageBox.Show("Continue sending emails to checked students?", "EMAIL", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				send_changevenue();
		}

		void open_profile()
		{
			if (lvList.SelectedItems.Count > 0)
			{
				Program.lstudid = Int32.Parse(lvList.SelectedItems[0].Tag.ToString());
				new profile().ShowDialog(this);
			}
		}

		private void pROFILEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			open_profile();
		}

		private void mODIFIEDREGFORMBCODEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (busy())
			{
				MessageBox.Show("Still busy sending messages.");
				return;
			}

			if (MessageBox.Show("Continue sending modified ERF to checked students?", "ERF EMAIL", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				send_modified_erf();
		}
    }

	public class dummyobject
	{
		public ListViewItem lvi;
		public int flag;
		public long id;
		public int msg_id;

		public dummyobject(ListViewItem li, int f,int mid)
		{
			this.lvi = li;
			this.flag = f;
			this.id = Int32.Parse(li.Tag.ToString());
			this.msg_id = mid;
		}
	}

    public class cmailer
    {
        public SmtpClient client;

        public cmailer(NetworkCredential n)
        {
            client = new SmtpClient("smtp."+Program.host);
            client.Port = 587;
            client.EnableSsl = true;
			client.Credentials = n;
			client.SendCompleted +=new SendCompletedEventHandler(client_SendCompleted);
        }

		public void send(MailMessage m,dummyobject i)
		{
			try
			{
				client.SendAsync(m,i);
				i.lvi.SubItems[8].Text = "Sending...";
			}
			catch (SmtpException sx)
			{
				i.lvi.SubItems[8].Text = "Can't send: " + sx.Message;
			}
		}



		private static void client_SendCompleted(object o, AsyncCompletedEventArgs s)
		{
			long id = ((dummyobject)s.UserState).id;
			int flag = ((dummyobject)s.UserState).flag;
			ListViewItem li = ((dummyobject)s.UserState).lvi;
			if (s.Error != null)
				li.SubItems[8].Text = "Sending failed: " +  s.Error.Message + ", " + s.Error.ToString();
			else
			{
				switch (flag)
				{
					case 1:
						if (Program.dataSource == Program.DataSources.Access)
						{
							Program.setcmd(ref Program.maindbCmd, "update students set is_noted = -1 where studid = " + id.ToString());
							Program.runcmd(Program.maindbCmd);
						}
						else
						{
							Program.setcmd(ref Program.OmaindbCmd, "update students set is_noted = -1 where studid = " + id.ToString());
							Program.runcmd(Program.OmaindbCmd);
						}
						break;

					case 2:
						if (Program.dataSource == Program.DataSources.Access)
						{
							Program.setcmd(ref Program.maindbCmd, "update students set is_emailed = -1,is_noted=-1 where studid = " + id.ToString());
							Program.runcmd(Program.maindbCmd);
						}
						else
						{
							Program.setcmd(ref Program.OmaindbCmd, "update students set is_emailed = -1,is_noted=-1 where studid = " + id.ToString());
							Program.runcmd(Program.OmaindbCmd);
						}
						break;

					default:
						break;
				}
				li.SubItems[8].Text = "OK";
				li.Checked = false;
			}
			((SmtpClient)o).Dispose();
			kartero.messages[((dummyobject)s.UserState).msg_id].Dispose();						
		}
    }


    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int ColumnToSort;
        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder OrderOfSort;
        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult=0;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare the two items
            compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

    }
}
