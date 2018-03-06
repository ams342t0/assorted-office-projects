using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace qadd
{
	public partial class settings : Form
	{
		public settings()
		{
			InitializeComponent();
		}

		private void settings_Load(object sender, EventArgs e)
		{
			Program.loadpaths();
			txtMainDB.Text = Program.maindb;
			txtRootFolder.Text = Program.rootfolder;
			txtHost.Text = Program.host;
			txtID.Text = Program.userid;
			txtPassword.Text = Program.password;
			txtDBHost.Text = Program.ds_Host;
			txtDBUser.Text = Program.ds_Uid;
			txtDBPwd.Text = Program.ds_Pwd;
			txtDBDB.Text = Program.ds_DB;
			if (Program.dataSource == Program.DataSources.Access)
				chkAccess.Checked = true;
			else
				chkMySQL.Checked = true;
			toggle_ds();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Program.maindb = txtMainDB.Text;
			Program.rootfolder = txtRootFolder.Text;
			Program.host = txtHost.Text;
			Program.userid = txtID.Text;
			Program.password = txtPassword.Text;
			Program.ds_DB = txtDBDB.Text;
			Program.ds_Host = txtDBHost.Text;
			Program.ds_Pwd = txtDBPwd.Text;
			Program.ds_Uid = txtDBUser.Text;

			if (chkAccess.Checked)
				Program.dataSource = Program.DataSources.Access;
			else
				Program.dataSource = Program.DataSources.MySQL;
			Program.savepaths();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		void toggle_ds()
		{
				txtMainDB.Enabled = chkAccess.Checked;
				txtDBHost.Enabled = chkMySQL.Checked;
				txtDBPwd.Enabled = chkMySQL.Checked;
				txtDBUser.Enabled = chkMySQL.Checked;
				txtDBDB.Enabled = chkMySQL.Checked;
				cmdTest.Enabled = chkMySQL.Checked;
		}



		private void browseMainDB_Click(object sender, EventArgs e)
		{
			ofd.Title = "MAIN DB";
			ofd.Filter = "Main DB | backend.mdb";
			ofd.FileName = txtMainDB.Text;
			if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				txtMainDB.Text = ofd.FileName;
			}
		}

		private void browseRootFolder_Click(object sender, EventArgs e)
		{
			fbd.SelectedPath = txtRootFolder.Text;
			if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				txtRootFolder.Text = fbd.SelectedPath;
			}
		}


		private void chkMySQL_CheckedChanged(object sender, EventArgs e)
		{
			toggle_ds();
		}

		private void chkAccess_CheckedChanged(object sender, EventArgs e)
		{
			toggle_ds();
		}

		private void cmdTest_Click(object sender, EventArgs e)
		{
			if (Program.TryMysql())
				MessageBox.Show("Connection successful.");
		}

	}
}
