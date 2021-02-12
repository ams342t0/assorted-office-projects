using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.OleDb;

namespace BARCODEREG
{
	static class Program
	{
		public enum dsources { Access, MySQL };
		public static dsources dsource = dsources.Access;
		public static string accessfile;
		public static string host;
		public static string uid;
		public static string pwd;
		public static string database;
        public static string driver;
		public static OleDbConnection conA;
		public static OdbcConnection conM;
		public static long selectedID;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new barcodereg());
		}

		public static bool connectAccess()
		{
			try
			{
				conA = new System.Data.OleDb.OleDbConnection();
				conA.ConnectionString = "Provider=Microsoft.jet.oledb.4.0; data source = " + Program.accessfile;
				conA.Open();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				return false;
			}
			return true;
		}

		public static bool connectMySQL()
		{
            conM = new System.Data.Odbc.OdbcConnection();
			try
			{
				conM.ConnectionString = "Driver=" + Program.driver + "; server=" + Program.host + ";uid=" + Program.uid + ";pwd=" + Program.pwd + ";database=" + Program.database;
				conM.Open();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				return false;
			}
			return true;
		}

	}
}
