using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Diagnostics;
using System.IO;


namespace lazymail
{
	static class Program
	{
		public enum DataSources {Access=1,MySQL=2};
        public static int nc_index=0;
		public static kartero k;
        public static qkartero qk;
		public static string emaildb;
		public static string maindb;
		
        public static string host;
		public static string userid;
		public static string password;

        public static string q_host;
        public static string q_userid;
        public static string q_password;

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
			rootfolder = (string)Registry.CurrentUser.CreateSubKey("lzm2", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("root", (string)@"d:\database 2015");
			emaildb = (string)Registry.CurrentUser.CreateSubKey("lzm2", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("emaildb", (string)@"d:\emails.mdb");
			maindb = (string)Registry.CurrentUser.CreateSubKey("lzm2", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("backenddb", (string)@"d:\backend.mdb");
			host = (string)Registry.CurrentUser.CreateSubKey("lzm2", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("host", (string)"googlemail.com");
			userid = (string)Registry.CurrentUser.CreateSubKey("lzm2", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("userid", (string)"mtg2015inhouse");
			password = (string)Registry.CurrentUser.CreateSubKey("lzm2", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("password", (string)"inhouse2015");

            q_host = (string)Registry.CurrentUser.CreateSubKey("lzm2", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("qhost", (string)"googlemail.com");
            q_userid = (string)Registry.CurrentUser.CreateSubKey("lzm2", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("quserid", (string)"confirmation.mostp@mtgphil.org");
            q_password = (string)Registry.CurrentUser.CreateSubKey("lzm2", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("qpassword", (string)"mostp13579");
            
            
            dataSource = (DataSources)Registry.CurrentUser.CreateSubKey("lzm2", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("data source", (DataSources)1);
			ds_Host=(string)Registry.CurrentUser.CreateSubKey("lzm2", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("mysql host", (string)"localhost");
			ds_Uid = (string)Registry.CurrentUser.CreateSubKey("lzm2", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("mysql userid", (string)"mtguser");
			ds_Pwd = (string)Registry.CurrentUser.CreateSubKey("lzm2", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("mysql password", (string)"mtgp2015");
			ds_DB = (string)Registry.CurrentUser.CreateSubKey("lzm2", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("mysql database", (string)"ih2015");
		}

		public static void savepaths()
		{
			Registry.CurrentUser.OpenSubKey("lzm2", true).SetValue("root", (string)Program.rootfolder);
			Registry.CurrentUser.OpenSubKey("lzm2", true).SetValue("emaildb", (string)Program.emaildb);
			Registry.CurrentUser.OpenSubKey("lzm2", true).SetValue("backenddb", (string)Program.maindb);
			Registry.CurrentUser.OpenSubKey("lzm2", true).SetValue("host", (string)Program.host);
			Registry.CurrentUser.OpenSubKey("lzm2", true).SetValue("userid", (string)Program.userid);
			Registry.CurrentUser.OpenSubKey("lzm2", true).SetValue("password", (string)Program.password);
			Registry.CurrentUser.OpenSubKey("lzm2", true).SetValue("data source", (int)Program.dataSource);
			Registry.CurrentUser.OpenSubKey("lzm2", true).SetValue("mysql host", (string)Program.ds_Host);
			Registry.CurrentUser.OpenSubKey("lzm2", true).SetValue("mysql userid", (string)Program.ds_Uid);
			Registry.CurrentUser.OpenSubKey("lzm2", true).SetValue("mysql password", (string)Program.ds_Pwd);
			Registry.CurrentUser.OpenSubKey("lzm2", true).SetValue("mysql database", (string)Program.ds_DB);
            Registry.CurrentUser.OpenSubKey("lzm2", true).SetValue("qhost", (string)Program.q_host);
            Registry.CurrentUser.OpenSubKey("lzm2", true).SetValue("quserid", (string)Program.q_userid);
            Registry.CurrentUser.OpenSubKey("lzm2", true).SetValue("qpassword", (string)Program.q_password);

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
			string opath = enq(Path.Combine(rootfolder, "TEMPLATE", "BARCODE.png"));
			Process p = new Process();
			p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			p.StartInfo.FileName = Path.Combine(rootfolder, "bin\\zint", "zint.exe");
			p.StartInfo.Arguments = "-b 9 --height=40 -w 5 -o " + opath + " -d " + "YMIITP-"+fcode;
			p.Start();
		}

        public static void createERFfile(long code)
        {
            string fcode = code.ToString("00000");
            string opath = enq(Path.Combine(rootfolder, "ERF",fcode +  ".pdf"));
            Process p = new Process();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = Path.Combine(rootfolder, @"bin\wkhtmltopdf\bin", "wkhtmltopdf.exe");
            p.StartInfo.Arguments = "--page-width 215.9 --page-height 139.7 " + enq(Path.Combine(rootfolder,"TEMPLATE","TMP.HTML"))  + " " +  opath;
            p.Start();
        }

		public static string createprofile_OLEDB(long code, bool overwrite)
		{
            OleDbDataReader r;
            OleDbCommand c;

            string sCode = code.ToString("00000");
            string fname = Path.Combine(rootfolder, "ERF", sCode + ".pdf");
            string msg_template= File.ReadAllText(Path.Combine(rootfolder, "template", "erf.html"));

			c = maindbCon.CreateCommand();

			if (File.Exists(fname))
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
                
                msg_template = msg_template.Replace("NFULLNAME",getString(r, "fullname"));
                msg_template = msg_template.Replace("NYEARLEVEL", getString(r, "leveltext"));
                msg_template = msg_template.Replace("NSCHOOL", getString(r, "school"));
                msg_template = msg_template.Replace("NCENTER", getString(r, "centername"));
                msg_template = msg_template = msg_template.Replace("NCODE", sCode);
                msg_template = msg_template.Replace("NGENDER", getString(r, "sex"));
                msg_template = msg_template.Replace("NROOM", "");
                msg_template = msg_template.Replace("NSHIRT", getString(r, "shirtsize"));
                msg_template = msg_template.Replace("NLINE1", getString(r, "quickdescription"));
                msg_template = msg_template.Replace("NLINE2", getString(r, "venue"));
                msg_template = msg_template.Replace("NLINE3", getString(r, "city"));
                msg_template = msg_template.Replace("NLINE4", getString(r, "schedule"));
                r.Close();

                File.WriteAllText(Path.Combine(rootfolder, "template", "TMP.html"),msg_template);
                
                createbarcode(code);
                createERFfile(code);
				
                return "OK";
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}


		public static string createprofile_ODBC(long code,bool overwrite)
		{
			OdbcDataReader r;
			OdbcCommand c;

            string sCode = code.ToString("00000");
            string fname = Path.Combine(rootfolder, "ERF", sCode + ".pdf");
            string msg_template = File.ReadAllText(Path.Combine(rootfolder, "template", "erf.html"));


			c = OmaindbCon.CreateCommand();

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
                msg_template = msg_template.Replace("NFULLNAME", getString(r, "fullname"));
                msg_template = msg_template.Replace("NYEARLEVEL", getString(r, "leveltext"));
                msg_template = msg_template.Replace("NSCHOOL", getString(r, "school"));
                msg_template = msg_template.Replace("NCENTER", getString(r, "centername"));
                msg_template = msg_template.Replace("NCODE", sCode);
                msg_template = msg_template.Replace("NGENDER", getString(r, "sex"));
                msg_template = msg_template.Replace("NROOM", "");
                msg_template = msg_template.Replace("NSHIRT", getString(r, "shirtsize"));
                msg_template = msg_template.Replace("NLINE1", getString(r, "quickdescription"));
                msg_template = msg_template.Replace("NLINE2", getString(r, "venue"));
                msg_template = msg_template.Replace("NLINE3", getString(r, "city"));
                msg_template = msg_template.Replace("NLINE4", getString(r, "schedule"));
                r.Close();
                
                File.WriteAllText(Path.Combine(rootfolder, "template", "TMP.html"), msg_template);

                createbarcode(code);
                createERFfile(code);

                
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
				Program.maindbCon.ConnectionString = "Provider=Microsoft.ACE.OleDB.12.0; data source = " + Program.maindb;
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

        public static string getFirstName(string n)
        {
            string retval="";

            if (n.Contains(','))
                n = n.Substring(n.IndexOf(',') + 1, n.Length - n.IndexOf(',') - 1).Trim();

            if (!n.Contains("."))
                return n;

            foreach (string u in n.Split(' '))
            {
                if (!u.Contains('.'))
                    retval += u + " ";
            }
            return retval.TrimEnd();
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
