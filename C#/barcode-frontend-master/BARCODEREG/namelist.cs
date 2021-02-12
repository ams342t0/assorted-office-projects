using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;

namespace BARCODEREG
{
	public partial class namelist : Form
	{
		string qs;

		public namelist()
		{
			InitializeComponent();
		}


		public namelist(string q)
		{
			qs = q;
			InitializeComponent();
		}

		private void listView1_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Program.selectedID = 99999;
				this.Close();
			}

			if (e.KeyCode == Keys.Return)
			{
				Program.selectedID = Int32.Parse(listView1.SelectedItems[0].Tag.ToString());
				this.Close();
			}
		}

		void filllist()
		{
			ListViewItem li;
			OleDbCommand dc1;
			OdbcCommand dc2;

			if (Program.dsource == Program.dsources.Access)
			{
				dc1 = Program.conA.CreateCommand();
				
			}
			else
			{
				try
				{
					dc2 = Program.conM.CreateCommand();
					dc2.CommandText = "select * from students where fullname like \"%" + qs.Substring(1,qs.Length-1).Trim() + "%\" order by fullname";
					OdbcDataReader dr = dc2.ExecuteReader();
					if (!dr.HasRows)
					{
						MessageBox.Show("No match found!");
						this.Close();
						Program.selectedID = 99999;
					}
					while (dr.Read())
					{
						li = listView1.Items.Add(dr.GetInt32(dr.GetOrdinal("studid")).ToString("00000"));
						li.Tag = dr.GetInt32(dr.GetOrdinal("studid"));
						li.SubItems.Add(dr.GetString(dr.GetOrdinal("fullname")));
						li.SubItems.Add(dr.GetInt32(dr.GetOrdinal("sex")).ToString());
						li.SubItems.Add(dr.GetInt32(dr.GetOrdinal("ilevel")).ToString());
						li.SubItems.Add(dr.GetString(dr.GetOrdinal("school")));
						li.SubItems.Add(dr.GetInt32(dr.GetOrdinal("center")).ToString());
					}
					listView1.Items[0].Selected = true;
					dr.Close();
				}
				catch (Exception x)
				{
					MessageBox.Show(x.Message);
				}
			}
		}

		private void namelist_Shown(object sender, EventArgs e)
		{
			filllist();
		}
	}

	
}
