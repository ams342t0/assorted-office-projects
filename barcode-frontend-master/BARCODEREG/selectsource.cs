using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace BARCODEREG
{
	public partial class selectsource : Form
	{
		public selectsource()
		{
			InitializeComponent();
		}

		private void selectsource_Load(object sender, EventArgs e)
		{
			fillFields();
			if (Program.dsource == Program.dsources.Access)
				opAccess.Checked = true;
			else
				opMSQL.Checked = true;

			toggleLock();
		}

		void fillFields()
		{
			Program.dsource = (Program.dsources)Registry.CurrentUser.CreateSubKey("BARCODE", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("dsource", (Program.dsources)Program.dsources.Access); 
			Program.accessfile = (string)Registry.CurrentUser.CreateSubKey("BARCODE", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("dbfile", (string)@"d:\database 2015\backend.mdb");
			Program.host = (string)Registry.CurrentUser.CreateSubKey("BARCODE", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("host", (string)"localhost");
			Program.uid = (string)Registry.CurrentUser.CreateSubKey("BARCODE", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("uid", (string)"dbuserid");
			Program.pwd = (string)Registry.CurrentUser.CreateSubKey("BARCODE", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("pwd", (string)"dbuserpw");
			Program.database = (string)Registry.CurrentUser.CreateSubKey("BARCODE", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("db", (string)"dbname");
            Program.driver = (string)Registry.CurrentUser.CreateSubKey("BARCODE", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("driver", (string)"MySQL ODBC 5.1 driver");
			txtDBFile.Text = Program.accessfile;
			txtHost.Text = Program.host;
			txtUID.Text = Program.uid;
			txtPWD.Text = Program.pwd;
			txtDB.Text = Program.database;

            RegistryKey k = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\ODBC\ODBCINST.INI\ODBC Drivers");

            cbDriver.Items.Clear();

            foreach(string ks in k.GetValueNames())
            {
                if (ks.ToUpper().Contains("MYSQL"))
                    cbDriver.Items.Add(ks);
            }

            cbDriver.Text = Program.driver;
			if (Program.dsource == Program.dsources.Access)
				Program.connectAccess();
			else
				Program.connectMySQL();
		}


		void saveFields()
		{
			Program.accessfile = txtDBFile.Text;
			Program.host = txtHost.Text;
			Program.uid = txtUID.Text;
			Program.pwd = txtPWD.Text;
			Program.database = txtDB.Text;
            Program.driver = cbDriver.Text;
			Registry.CurrentUser.CreateSubKey("BARCODE", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("dsource", (int)Program.dsource);
			Registry.CurrentUser.CreateSubKey("BARCODE", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("dbfile", (string)Program.accessfile);
			Registry.CurrentUser.CreateSubKey("BARCODE", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("host", (string)Program.host);
			Registry.CurrentUser.CreateSubKey("BARCODE", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("uid", (string)Program.uid);
			Registry.CurrentUser.CreateSubKey("BARCODE", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("pwd", (string)Program.pwd);
			Registry.CurrentUser.CreateSubKey("BARCODE", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("db", (string)Program.database);
            Registry.CurrentUser.CreateSubKey("BARCODE", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("driver", (string)Program.driver);
		}

		void toggleLock()
		{
			txtDBFile.Enabled = opAccess.Checked;
			txtHost.Enabled = opMSQL.Checked;
			txtUID.Enabled = opMSQL.Checked;
			txtPWD.Enabled = opMSQL.Checked;
			txtDB.Enabled = opMSQL.Checked;
            cbDriver.Enabled = opMSQL.Checked;
			cmdTest.Enabled = opMSQL.Checked;
			cmdOpen.Enabled = opAccess.Checked;
		}

		private void cmdSave_Click(object sender, EventArgs e)
		{
			saveFields();
			Close();
		}

		private void cmdTest_Click(object sender, EventArgs e)
		{
			if (Program.connectMySQL())
				MessageBox.Show("Checks out!");
		}

		private void cmdOpen_Click(object sender, EventArgs e)
		{
			openFileDialog1.Title = "BACKEND";
			openFileDialog1.Filter = "BACKEND|backend*.*b";
			if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				Program.accessfile = openFileDialog1.FileName;
				txtDBFile.Text = Program.accessfile;
				if (Program.connectAccess())
					MessageBox.Show("Checks out!");
			}
		}

		private void opAccess_Click(object sender, EventArgs e)
		{
			Program.dsource = Program.dsources.Access;
			toggleLock();
		}

		private void opMSQL_Click(object sender, EventArgs e)
		{
			Program.dsource = Program.dsources.MySQL;
			toggleLock();
		}
	}
}
