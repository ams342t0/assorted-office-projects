using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Data.OleDb;
using System.Data.Odbc;
using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.IO;


namespace lazymail
{
	static class Program
	{
		public enum DataSources {Access=1,MySQL=2};
		public static kartero k;
		public static string emaildb;
		public static string maindb;
		public static string host;
		public static string userid;
		public static string password;
		public static string rootfolder;
		public static string ds_Host;
		public static string ds_Uid;
		public static string ds_Pwd;
		public static string ds_DB;
		public static DataSources dataSource = DataSources.Access;

		public static long lstudid;
		public static OleDbConnection emaildbCon;
		public static OleDbCommand emaildbCmd;
		public static OleDbDataReader emdr;

		public static OleDbConnection maindbCon;
		public static OleDbCommand maindbCmd;
		public static OleDbDataReader maindr;

		public static OdbcConnection OmaindbCon;
		public static OdbcCommand OmaindbCmd;
		public static OdbcDataReader Omaindr;

		public static picview pv;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
			System.Windows.Forms.Application.Run(new Form1());
			
		}

		public static string enq(string s)
		{
			return "\"" + s + "\"";
		}

		public static void loadpaths()
		{
			rootfolder = (string)Registry.CurrentUser.CreateSubKey("lazymail", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("root", (string)@"rootworkfolder");
			emaildb = (string)Registry.CurrentUser.CreateSubKey("lazymail", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("emaildb", (string)@"d:\emails");
			maindb = (string)Registry.CurrentUser.CreateSubKey("lazymail", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("backenddb", (string)@"d:\backend.mdb");
			host = (string)Registry.CurrentUser.CreateSubKey("lazymail", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("host", (string)"mailserver.com");
			userid = (string)Registry.CurrentUser.CreateSubKey("lazymail", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("userid", (string)"youemail");
			password = (string)Registry.CurrentUser.CreateSubKey("lazymail", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("password", (string)"yourpassword");
			dataSource = (DataSources)Registry.CurrentUser.CreateSubKey("lazymail", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("data source", (DataSources)1);
			ds_Host=(string)Registry.CurrentUser.CreateSubKey("lazymail", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("mysql host", (string)"localhost");
			ds_Uid = (string)Registry.CurrentUser.CreateSubKey("lazymail", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("mysql userid", (string)"dbloginid");
			ds_Pwd = (string)Registry.CurrentUser.CreateSubKey("lazymail", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("mysql password", (string)"dbloginpw");
			ds_DB = (string)Registry.CurrentUser.CreateSubKey("lazymail", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("mysql database", (string)"dbname");
		}

		public static void savepaths()
		{
			Registry.CurrentUser.OpenSubKey("lazymail", true).SetValue("root", (string)Program.rootfolder);
			Registry.CurrentUser.OpenSubKey("lazymail", true).SetValue("emaildb", (string)Program.emaildb);
			Registry.CurrentUser.OpenSubKey("lazymail", true).SetValue("backenddb", (string)Program.maindb);
			Registry.CurrentUser.OpenSubKey("lazymail", true).SetValue("host", (string)Program.host);
			Registry.CurrentUser.OpenSubKey("lazymail", true).SetValue("userid", (string)Program.userid);
			Registry.CurrentUser.OpenSubKey("lazymail", true).SetValue("password", (string)Program.password);
			Registry.CurrentUser.OpenSubKey("lazymail", true).SetValue("data source", (int)Program.dataSource);
			Registry.CurrentUser.OpenSubKey("lazymail", true).SetValue("mysql host", (string)Program.ds_Host);
			Registry.CurrentUser.OpenSubKey("lazymail", true).SetValue("mysql userid", (string)Program.ds_Uid);
			Registry.CurrentUser.OpenSubKey("lazymail", true).SetValue("mysql password", (string)Program.ds_Pwd);
			Registry.CurrentUser.OpenSubKey("lazymail", true).SetValue("mysql database", (string)Program.ds_DB);
		}

		public static bool getBool(OleDbDataReader dr, string cn)
		{
			try
			{
				return dr.GetBoolean(dr.GetOrdinal(cn));
			}
			catch (InvalidCastException ice)
			{
				return false;
			}
		}

		public static string getString(OleDbDataReader dr, string cn)
		{
			try
			{
				return dr.GetString(dr.GetOrdinal(cn));
			}
			catch (InvalidCastException ice)
			{
				return "";
			}
		}

		public static long getLong(OleDbDataReader dr, string cn)
		{
			try
			{
				return dr.GetInt32(dr.GetOrdinal(cn));
			}
			catch (InvalidCastException ice)
			{
				return 0;
			}
		}

		public static void setcmd(ref OleDbCommand dbcmd, string s)
		{
			dbcmd.CommandText = s;
		}

		public static bool runcmd(OleDbCommand dbcmd)
		{
			try
			{
				dbcmd.ExecuteNonQuery();
				return true;
			}
			catch (InvalidOperationException ie)
			{
				MessageBox.Show(ie.Message);
				return false;
			}
		}

		public static OleDbDataReader runcmd_ret(OleDbCommand dbcmd)
		{
			try
			{
				return dbcmd.ExecuteReader();
			}
			catch (InvalidOperationException ie)
			{
				return null;
			}
		}

		//overloaded for ODBC
		public static bool getBool(OdbcDataReader dr, string cn)
		{
			try
			{
				return dr.GetBoolean(dr.GetOrdinal(cn));
			}
			catch (InvalidCastException ice)
			{
				return false;
			}
		}

		public static string getString(OdbcDataReader dr, string cn)
		{
			try
			{
				return dr.GetString(dr.GetOrdinal(cn));
			}
			catch (InvalidCastException ice)
			{
				return "";
			}
		}

		public static long getLong(OdbcDataReader dr, string cn)
		{
			try
			{
				return dr.GetInt32(dr.GetOrdinal(cn));
			}
			catch (InvalidCastException ice)
			{
				return 0;
			}
		}

		public static void setcmd(ref OdbcCommand dbcmd, string s)
		{
			dbcmd.CommandText = s;
		}

		public static bool runcmd(OdbcCommand dbcmd)
		{
			try
			{
				dbcmd.ExecuteNonQuery();
				return true;
			}
			catch (InvalidOperationException ie)
			{
				MessageBox.Show(ie.Message);
				return false;
			}
		}

		public static OdbcDataReader runcmd_ret(OdbcCommand dbcmd)
		{
			try
			{
				return dbcmd.ExecuteReader();
			}
			catch (InvalidOperationException ie)
			{
				return null;
			}
		}
// ***

		public static void createbarcode(long code)
		{
			string fcode = code.ToString("00000");
			string opath = enq(Path.Combine(rootfolder, "BARCODES", fcode + ".png"));
			Process p = new Process();
			p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			p.StartInfo.FileName = Path.Combine(rootfolder, "zint", "zint.exe");
			p.StartInfo.Arguments = "-b 9 --height=40 -w 5 -o " + opath + " -d " + "YMIITP-"+fcode;
			p.Start();
		}

		public static string createprofile_OLEDB(long code, bool overwrite)
		{
			Microsoft.Office.Interop.Word.Application wa;
			Microsoft.Office.Interop.Word.Document d;
			Object template = Path.Combine(rootfolder, "template", "email.dotx");
			Object o = System.Reflection.Missing.Value;
			Table t;
			string sCode = code.ToString("00000");
			Object fname;
			Object ftype = 17;
			OleDbDataReader r;
			OleDbCommand c;

			c = maindbCon.CreateCommand();

			fname = Path.Combine(rootfolder, "ERF", sCode + ".pdf");

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
				wa = new Microsoft.Office.Interop.Word.Application();

				d = wa.Documents.Add(ref template, ref o, ref o, ref o);
				t = d.Tables[2];
				t.Cell(2, 1).Range.Text = getString(r, "fullname");
				t.Cell(2, 2).Range.Text = getString(r, "leveltext");

				t = d.Tables[3];
				t.Cell(2, 1).Range.Text = getString(r, "school");
				t.Cell(2, 2).Range.Text = getString(r, "centername");


				t = d.Tables[4];
				t.Cell(2, 1).Range.Text = sCode;
				t.Cell(2, 2).Range.Text = getString(r, "sex");
				t.Cell(2, 3).Range.Text = "";
				t.Cell(2, 4).Range.Text = getString(r, "shirtsize");

				t = d.Tables[5];
				t.Cell(2, 1).Range.Text = getString(r, "quickdescription") + "\n" + getString(r, "venue") + "\n" + getString(r, "city") + "\n" + getString(r, "schedule");
				t.Cell(2, 2).Range.InlineShapes.AddPicture(Path.Combine(rootfolder, "BARCODES", sCode+".png"));

				d.Saved = true;
				d.SaveAs(ref fname, ref ftype);
				wa.Quit();
				r.Close();
				return "OK";
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}


		public static string createprofile_ODBC(long code,bool overwrite)
		{
			Microsoft.Office.Interop.Word.Application wa;
			Microsoft.Office.Interop.Word.Document d;
			Object template = Path.Combine(rootfolder, "template", "email.dotx");
			Object o = System.Reflection.Missing.Value;
			Table t;
			string sCode = code.ToString("00000");
			Object fname;
			Object ftype = 17;
			OdbcDataReader r;
			OdbcCommand c;

			c = OmaindbCon.CreateCommand();

			fname = Path.Combine(rootfolder, "ERF", sCode + ".pdf");

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
				wa = new Microsoft.Office.Interop.Word.Application();

				d = wa.Documents.Add(ref template, ref o, ref o, ref o);
				t = d.Tables[2];
				t.Cell(2, 1).Range.Text = getString(r, "fullname");
				t.Cell(2, 2).Range.Text = getString(r, "leveltext");

				t = d.Tables[3];
				t.Cell(2, 1).Range.Text = getString(r, "school");
				t.Cell(2, 2).Range.Text = getString(r, "centername");


				t = d.Tables[4];
				t.Cell(2, 1).Range.Text = sCode;
				t.Cell(2, 2).Range.Text = getString(r, "sex");
				t.Cell(2, 3).Range.Text = "";
				t.Cell(2, 4).Range.Text = getString(r, "shirtsize");

				t = d.Tables[5];
				t.Cell(2, 1).Range.Text = getString(r, "quickdescription") + "\n" + getString(r, "venue") + "\n" + getString(r, "city") + "\n" + getString(r, "schedule");
				t.Cell(2, 2).Range.InlineShapes.AddPicture(Path.Combine(rootfolder, "BARCODES", sCode + ".png"));

				d.Saved = true;
				d.SaveAs(ref fname, ref ftype);
				wa.Quit();
				r.Close();
				return "OK";
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}

		public static bool TryAccess()
		{
			try
			{
				Program.maindbCon = new OleDbConnection();
				Program.maindbCon.ConnectionString = "Provider=Microsoft.jet.oledb.4.0; data source = " + Program.maindb;
				Program.maindbCon.Open();
				Program.maindbCmd = Program.maindbCon.CreateCommand();
			}
			catch (Exception ex2)
			{
				MessageBox.Show("Problem connecting to main backend.\n" + ex2.Message);
				return false;
			}
			return true;
		}

		public static bool TryMysql()
		{
			try
			{
				Program.OmaindbCon = new OdbcConnection();
				Program.OmaindbCon.ConnectionString = "Driver=MySQL ODBC 5.1 Driver;server=" + Program.ds_Host + "; database=" + Program.ds_DB + ";uid=" + Program.ds_Uid + ";pwd=" + Program.ds_Pwd;
				Program.OmaindbCon.Open();
				Program.OmaindbCmd = Program.OmaindbCon.CreateCommand();
			}
			catch (Exception ex2)
			{
				try
				{
					Program.OmaindbCon = new OdbcConnection();
					Program.OmaindbCon.ConnectionString = "Driver=MySQL ODBC 5.2a Driver;server=" + Program.ds_Host + "; database=" + Program.ds_DB + ";uid=" + Program.ds_Uid + "; pwd=" + Program.ds_Pwd;
					Program.OmaindbCon.Open();
					Program.OmaindbCmd = Program.OmaindbCon.CreateCommand();
				}
				catch (Exception ex2a)
				{
					MessageBox.Show(ex2a.Message);
					return false;
				}
				return false;
			}
			return true;
		}
	}
}
