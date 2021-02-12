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
    public partial class qkartero : Form
    {
		public delegate void filldelegate();
        public NetworkCredential nc;
        public string query_string;
        public string query_filter;
        public ListViewColumnSorter lcs;
		filldelegate fill_async;
		bool filling = false;
		public static MailMessage []messages;
        
        public qkartero()
        {
            InitializeComponent();
        }

        private void qkartero_Load(object sender, EventArgs e)
        {
			Program.qk = this;

            nc = new NetworkCredential(Program.q_userid,Program.q_password);
            query_string = "select s.studid,s.fullname,s.ilevel,c.centername,s.school,s.s_email,s.is_qualified, " + 
                           "s.result from students as s inner join " +
                           "centers as c on s.center=c.centerid";
            lcs = new ListViewColumnSorter();
            lvList.ListViewItemSorter = lcs;
            lvList.Sorting = SortOrder.None;
            lcs.Order = SortOrder.None;
			sbcount.Text = "0";
			messages = new MailMessage[30];

            cbResult.Items.Add("QUALIFIER");
            cbResult.Items.Add("ALTERNATE");
            cbName.Items.Add("MATHDAP");
            cbName.Items.Add("MTGPHIL");
            cbResult.SelectedIndex = 0;
            cbName.SelectedIndex = 0;
        }

        void buildfilter()
        {
            query_filter = "";

            if (cbName.SelectedIndex == 0) 
                query_filter = " where s.result = 'Q'";
            else
                query_filter = " where s.result = 'A'";
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
            string[] emails;
            string str_email;

            while (Program.maindr.Read() && filling)
            {

                str_email = Program.getString(Program.maindr, "s_email");
                if (str_email.Length > 0)
                {
                    emails = str_email.Split(';', ',');

                    foreach (string email in emails)
                    {
                        ListViewItem l = lvList.Items.Add(Program.getString(Program.maindr, "fullname"));
                        l.Tag = Program.getLong(Program.maindr, "studid");
                        l.SubItems.Add(Program.getString(Program.maindr, "school"));
                        l.SubItems.Add(Program.getString(Program.maindr, "centername"));
                        l.SubItems.Add(email.Trim());
                        l.SubItems.Add(Program.getLong(Program.maindr, "ilevel").ToString("00"));
                        l.SubItems.Add(Program.getString(Program.maindr, "result"));
                        l.SubItems.Add("");
                    }
                }
            }
            Program.maindr.Close();
            sbcount.Text = lvList.Items.Count.ToString();
			filling = false;
			lvList.Visible = true;
        }

		void fill_list_ODBC()
		{
            string str_email;
            string[] emails;
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
                str_email = Program.getString(Program.Omaindr, "s_email");
                if (str_email.Length > 0)
                {
                    emails = str_email.Split(';', ',');

                    foreach (string email in emails)
                    {
                        ListViewItem l = lvList.Items.Add(Program.getString(Program.Omaindr, "fullname"));
                        l.Tag = Program.getLong(Program.Omaindr, "studid");
                        l.SubItems.Add(Program.getString(Program.Omaindr, "school"));
                        l.SubItems.Add(Program.getString(Program.Omaindr, "centername"));
                        l.SubItems.Add(email.Trim());
                        l.SubItems.Add(Program.getLong(Program.Omaindr, "ilevel").ToString("00"));
                        l.SubItems.Add(Program.getString(Program.Omaindr, "result"));
                        l.SubItems.Add("");
                    }
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
					if (l.Checked && l.SubItems[6].Text.ToUpper().Equals("SENDING..."))
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


		void send_mregistrationform()
		{
			string msgs;
			int mi=0;
            string bodycontent="";
            string txthost = "";

            bodycontent = "confirmERF.html";
			if (lvList.Items.Count > 0)
			{
				foreach (ListViewItem l in lvList.Items)
				{
					if (!l.Checked)
						continue;

					if (l.SubItems[3].Text.Length == 0)
					{
						l.SubItems[6].Text = "No email!";
						continue;
					}

                    /*if (cbName.SelectedIndex == 0)
                        txthost = "confirmation.mostp@mathdap.com";
                    else
                        txthost = "confirmation.mostp@mtgphil.com";*/
                    txthost = "ams342t0@gmail.com";

                    msgs = (File.OpenText(Path.Combine(Program.rootfolder, @"TEMPLATE", bodycontent))).ReadToEnd();
                    msgs = msgs.Replace("nName",Program.getFirstName(l.Text));
					messages[mi] = new MailMessage(txthost, l.SubItems[3].Text, txtSubject.Text + " : " + l.Text, msgs);
                    messages[mi].From = new MailAddress(txthost,cbName.Text);
                    messages[mi].IsBodyHtml = true;
                    messages[mi].BodyEncoding = ASCIIEncoding.Default;
					qcmailer c = new qcmailer(nc);
					c.send(messages[mi],new qdummyobject(l,2,mi));
					mi++;
				}
			}
		}


		private void sTANDARDREPLYToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (busy())
			{
				MessageBox.Show("Still busy sending messages.");
				return;
			}
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
			if (MessageBox.Show("Continue sending MOSTP invitation?", "MOSTP EMAIL", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				send_mregistrationform();
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


        private void mESSAGEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Program.rootfolder + @"\TEMPLATE";
            openFileDialog1.Filter = "HTML|*html|TEXT|*.txt";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        private void aUTOSENDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cHECKALLToolStripMenuItem_Click(sender, e);
            aUTOSENDToolStripMenuItem_Click(sender, e);
        }

    }

	public class qdummyobject
	{
		public ListViewItem lvi;
		public int flag;
		public long id;
		public int msg_id;

		public qdummyobject(ListViewItem li, int f,int mid)
		{
			this.lvi = li;
			this.flag = f;
			this.id = Int32.Parse(li.Tag.ToString());
			this.msg_id = mid;
		}
	}

    public class qcmailer
    {
        public SmtpClient client;

        public qcmailer(NetworkCredential n)
        {
            client = new SmtpClient("smtp."+Program.q_host);
            client.Port = 587;
            client.EnableSsl = true;
			client.Credentials = n;
			client.SendCompleted +=new SendCompletedEventHandler(client_SendCompleted);
        }

		public void send(MailMessage m,qdummyobject i)
		{
			try
			{
				client.SendAsync(m,i);
				i.lvi.SubItems[6].Text = "Sending...";
			}
			catch (SmtpException sx)
			{
				i.lvi.SubItems[6].Text = "Can't send: " + sx.Message;
			}
		}

		private static void client_SendCompleted(object o, AsyncCompletedEventArgs s)
		{
			long id = ((qdummyobject)s.UserState).id;
			int flag = ((qdummyobject)s.UserState).flag;
			ListViewItem li = ((qdummyobject)s.UserState).lvi;
			if (s.Error != null)
				li.SubItems[6].Text = "Sending failed: " +  s.Error.Message + ", " + s.Error.ToString();
			else
			{
				li.SubItems[6].Text = "OK";
				li.Checked = false;
			}
			((SmtpClient)o).Dispose();
			qkartero.messages[((qdummyobject)s.UserState).msg_id].Dispose();						
		}
    }


    public class qListViewColumnSorter : IComparer
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
        public qListViewColumnSorter()
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
