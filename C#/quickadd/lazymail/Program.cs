using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Diagnostics;
using System.IO;



namespace qadd
{
	static class Program
	{
		public enum DataSources {Access=1,MySQL=2};
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

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
			System.Windows.Forms.Application.Run(new profile());
			
		}

		public static string enq(string s)
		{
			return "\"" + s + "\"";
		}

		public static void loadpaths()
		{
			rootfolder = (string)Registry.CurrentUser.CreateSubKey("qadd", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("root", (string)@"d:\database 2015");
			emaildb = (string)Registry.CurrentUser.CreateSubKey("qadd", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("emaildb", (string)@"d:\emails.mdb");
			maindb = (string)Registry.CurrentUser.CreateSubKey("qadd", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("backenddb", (string)@"d:\backend.mdb");
			host = (string)Registry.CurrentUser.CreateSubKey("qadd", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("host", (string)"googlemail.com");
			userid = (string)Registry.CurrentUser.CreateSubKey("qadd", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("userid", (string)"mtg2015inhouse");
			password = (string)Registry.CurrentUser.CreateSubKey("qadd", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("password", (string)"inhouse2015");
			dataSource = (DataSources)Registry.CurrentUser.CreateSubKey("qadd", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("data source", (DataSources)1);
			ds_Host=(string)Registry.CurrentUser.CreateSubKey("qadd", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("mysql host", (string)"localhost");
			ds_Uid = (string)Registry.CurrentUser.CreateSubKey("qadd", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("mysql userid", (string)"mtguser");
			ds_Pwd = (string)Registry.CurrentUser.CreateSubKey("qadd", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("mysql password", (string)"mtgp2015");
			ds_DB = (string)Registry.CurrentUser.CreateSubKey("qadd", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("mysql database", (string)"ih2015");
		}

		public static void savepaths()
		{
			Registry.CurrentUser.OpenSubKey("qadd", true).SetValue("root", (string)Program.rootfolder);
			Registry.CurrentUser.OpenSubKey("qadd", true).SetValue("emaildb", (string)Program.emaildb);
			Registry.CurrentUser.OpenSubKey("qadd", true).SetValue("backenddb", (string)Program.maindb);
			Registry.CurrentUser.OpenSubKey("qadd", true).SetValue("host", (string)Program.host);
			Registry.CurrentUser.OpenSubKey("qadd", true).SetValue("userid", (string)Program.userid);
			Registry.CurrentUser.OpenSubKey("qadd", true).SetValue("password", (string)Program.password);
			Registry.CurrentUser.OpenSubKey("qadd", true).SetValue("data source", (int)Program.dataSource);
			Registry.CurrentUser.OpenSubKey("qadd", true).SetValue("mysql host", (string)Program.ds_Host);
			Registry.CurrentUser.OpenSubKey("qadd", true).SetValue("mysql userid", (string)Program.ds_Uid);
			Registry.CurrentUser.OpenSubKey("qadd", true).SetValue("mysql password", (string)Program.ds_Pwd);
			Registry.CurrentUser.OpenSubKey("qadd", true).SetValue("mysql database", (string)Program.ds_DB);
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
