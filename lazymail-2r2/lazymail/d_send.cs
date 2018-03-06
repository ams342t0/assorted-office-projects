using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.IO;

namespace lazymail
{
    public partial class d_send : Form
    {
        public SmtpClient sc;
        public MailMessage m;
        public NetworkCredential nc;
		public static bool sending = false;
        public MailAddress ma;

        public d_send()
        {
            InitializeComponent();
        }

        private void d_send_Load(object sender, EventArgs e)
        {
            nc = new NetworkCredential(Program.userid,Program.password);
            sc = new SmtpClient("smtp.googlemail.com");
            sc.Port = 587;
            sc.EnableSsl = true;
            sc.Credentials = nc;
            sc.SendCompleted +=new SendCompletedEventHandler(sc_SendCompleted);
			pbar.Visible = false;
            ma = new MailAddress(Program.userid + "@gmail.com", "MTGPHIL");
        }

        private static void sc_SendCompleted(object o,AsyncCompletedEventArgs s)
        {
			sending = false;
            if (s.Error != null)
            {
                MessageBox.Show("Failed to send");
            }
            else
                MessageBox.Show("Message sent.");
        }

        void send_msg()
        {
            if (txtMessage.Text.Length > 0 && txtTo.Text.Length > 0)
            {
                m = new MailMessage(Program.userid + "@gmail.com", txtTo.Text, txtSubject.Text, txtMessage.Text);
                m.From = ma;
                m.IsBodyHtml = true;
                m.BodyEncoding = ASCIIEncoding.Default;
				sending = true;
                sc.SendAsync(m, null);
				pbar.Visible = true;
				sENDToolStripMenuItem.Enabled = false;
				while (sending)
				{
					Application.DoEvents();
				}
				sENDToolStripMenuItem.Enabled = true;
				pbar.Visible = false;
            }
        }

		private void sENDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			send_msg();
		}

		void erfguide()
		{
			txtMessage.Text = (File.OpenText(Path.Combine(Program.rootfolder, @"TEMPLATE", "mainreply.html"))).ReadToEnd();
			txtSubject.Text = "REMINDERS RE. ELECTRONIC REPLY FORM (ERF)";
		}

		void noreplyform()
		{
            txtMessage.Text = (File.OpenText(Path.Combine(Program.rootfolder, @"TEMPLATE", "repdepslip.html"))).ReadToEnd();
			txtSubject.Text = "NO REPLY FORM OR DEPOSIT SLIP RECEIVED";
			
		}

		void changevenue()
		{
			txtSubject.Text = "REQUEST CHANGE OF TRAINING VENUE";
			txtMessage.Text = (File.OpenText(Path.Combine(Program.rootfolder, @"TEMPLATE", "changevenue.html"))).ReadToEnd();
		}

		private void eRFGUIDELINEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			erfguide();
		}

		private void cHANGEVENUEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			changevenue();
		}

		private void nOREPLYFORMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			noreplyform();
		}

		private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

    }
}
