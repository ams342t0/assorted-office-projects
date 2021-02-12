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


	public partial class barcodereg : Form
	{
		[DllImport("user32.dll")]
		extern static bool HideCaret(Int32 w);

		string query,filter;
		int codelength = 12;
		long id;
		OleDbDataReader dr1;
		OdbcDataReader dr2;

		public barcodereg()
		{
			InitializeComponent();
			query = "select s.studid,s.fullname,x.sex,l.leveltext,s.school,r.roomname,s.shirtsize, " +
					"c.centername,s.room,t.quickdescription from " +
					"((((students as s inner join  centers as c on s.center = c.centerid) " +
					"inner join sexes as x on s.sex = x.sexid) " +
					"inner join levels as l on s.ilevel = l.levelid) " +
					"left outer join rooms as r on r.roomid = s.room) " +
					"inner join schedules as t on t.scheduleid = s.schedule";
		}

		void attempt_connect()
		{
			if (Program.dsource == Program.dsources.Access)
				Program.connectAccess();
			else
				Program.connectMySQL();
		}

		void clear_fields()
		{
			txtName.Text = "";
			txtSex.Text = "";
			txtLevel.Text = "";
			txtSchool.Text = "";
			txtCenter.Text = "";
			txtRoom.Text = "";
			txtStatus.Text = "";
			txtID.Text = "";
			txtSchedule.Text = "";
			txtShirt.Text = "";
			txtStatus.BackColor = Color.Black;
		}

		
		void fill_up()
		{
			OleDbCommand dc1;
			OdbcCommand dc2;

			filter = " WHERE studid = " + id.ToString();

			try
			{
				if (Program.dsource == Program.dsources.Access)
				{
					dc1 = Program.conA.CreateCommand();
					dc1.CommandText = query + filter;
					dr1 = dc1.ExecuteReader();
				}
				else
				{
					dc2 = Program.conM.CreateCommand();
					dc2.CommandText = query + filter;
					dr2 = dc2.ExecuteReader();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				new selectsource().ShowDialog(this);
				return;
			}

			bool r;

			try
			{
				if (Program.dsource == Program.dsources.Access)
					r = dr1.Read();
				else
					r = dr2.Read();
			}
			catch (Exception ex1)
			{
				txtStatus.ForeColor = Color.Red;
				MessageBox.Show("Error: " + ex1.Message);
				return;
			}

			if (!r)
			{
				txtStatus.BackColor = Color.Red;
				txtStatus.ForeColor = Color.Yellow;
				txtStatus.Text = "Student not found!";
			}
			else
			{
				txtName.Text = getstring("fullname");
				txtSex.Text = getstring("sex");
				txtLevel.Text = getstring("leveltext");
				txtSchool.Text = getstring("school");
				txtCenter.Text = getstring("centername");
				txtRoom.Text = getstring("roomname");
				txtSchedule.Text = getstring("quickdescription");
				txtID.Text = id.ToString("00000");
				txtStatus.Text = "REGISTERED";
				txtShirt.Text = getstring("shirtsize");
				txtStatus.BackColor = Color.LawnGreen;
				txtStatus.ForeColor = Color.DarkBlue;

				try
				{
					if (Program.dsource == Program.dsources.Access)
					{
						OleDbCommand c = Program.conA.CreateCommand();
						c.CommandText = "UPDATE students set is_registered = -1,TS = \"" + DateTime.Now + "\" where studid = " + id.ToString();
						c.ExecuteNonQuery();
					}
					else
					{
						OdbcCommand c = Program.conM.CreateCommand();
                        c.CommandText = "UPDATE students set is_registered = -1,TS = \"" + DateTime.Now + "\" where studid = " + id.ToString();
						c.ExecuteNonQuery();
					}
				}
				catch (Exception ioe)
				{
					clear_fields();
					txtStatus.BackColor = Color.Red;
					txtStatus.ForeColor = Color.Yellow;
					txtStatus.Text = "Try again. : " + ioe.Message;
					return;
				}
			}

			if (Program.dsource == Program.dsources.Access)
				dr1.Close();
			else
				dr2.Close();
		}


		string getstring(string c)
		{
			try
			{
				if (Program.dsource == Program.dsources.Access)
					return dr1.GetString(dr1.GetOrdinal(c));
				else
					return dr2.GetString(dr2.GetOrdinal(c));
			}
			catch (InvalidCastException ie)
			{
				return "";
			}
		}

		void show_wait()
		{
			txtStatus.BackColor = Color.Black;
			txtStatus.ForeColor = Color.White;
			txtStatus.Text = "WAIT...";
			Application.DoEvents();
		}

		private void txtCode_KeyUp(object sender, KeyEventArgs e)
		{
			HideCaret((int)txtCode.Handle);


			//if (txtCode.Text.Length > 0 && txtCode.Text.Substring(0, 1).Equals("/"))
			//{
			//    if (e.KeyCode == Keys.Enter)
			//    {
			//        new namelist(txtCode.Text).ShowDialog(this);

			//        if (Program.selectedID < 99999)
			//        {
			//            if (MessageBox.Show("Register " + Program.selectedID.ToString() + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
			//            {
			//                clear_fields();
			//                show_wait();
			//                id = Program.selectedID;
			//                fill_up();
			//            }
			//        }
			//        else
			//            clear_fields();
			//        txtCode.Text = "";
			//    }
			//    return;
			//}

            if (txtCode.Text.Length > 0 && txtCode.Text.Substring(0, 1).Equals("#"))
            {
                if (e.KeyCode == Keys.Enter)
                {
					if (MessageBox.Show("Register " + txtCode.Text + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
					{
						clear_fields();
						show_wait();

						if (getcode_2())
							fill_up();
						else
						{
							txtStatus.BackColor = Color.Red;
							txtStatus.ForeColor = Color.Yellow;
							txtStatus.Text = "INVALID BARCODE!";
						}
						txtCode.Text = "";
					}
                }
            }

            if (txtCode.Text.Length>0 &&  txtCode.Text.Substring(0, 1).ToUpper().Equals("Y"))
            {
                    if (txtCode.Text.Length >= codelength)
                    {
						clear_fields();
						show_wait();

                        if (getcode())
                            fill_up();
                        else
                        {
							txtStatus.BackColor = Color.Red;
							txtStatus.ForeColor = Color.Yellow;
							txtStatus.Text = "INVALID BARCODE!";
                        }
                        txtCode.Text = "";
                    }
                }
            if (txtCode.Text.Length>0 &&  txtCode.Text.Substring(0, 1).ToUpper().Equals("A"))
                {
                    if (txtCode.Text.Length >= codelength+1)
                    {
						clear_fields();
						show_wait();

                        if (getcode_A())
                            fill_up();
                        else
                        {
							clear_fields();
							txtStatus.BackColor = Color.Red;
							txtStatus.ForeColor = Color.Yellow;
							txtStatus.Text = "INVALID BARCODE!";
                        }
                        txtCode.Text = "";
                    }
                }
            
		}

		bool getcode()
		{
            id = 99999;
			if (txtCode.Text.Substring(0, 7).ToUpper().Equals("YMIITP-"))
			{
                try
                {
                    id = Int32.Parse(txtCode.Text.Substring(7, 5));
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
			}
			else
				return false;
		}

        bool getcode_A()
        {
            id = 99999;

            if (txtCode.Text.Length == 0)
                return false;

            if (txtCode.Text.Substring(0, 8).ToUpper().Equals("AYMIITP-") || txtCode.Text.Substring(0, 8).ToUpper().Equals("GYMIITP-"))
            {
                try
                {
                    id = Int32.Parse(txtCode.Text.Substring(8, 5));
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            else
                return false;
        }


        bool getcode_2()
        {
            id = 99999;
            try
            {
                try
                {
                    id = Int32.Parse(txtCode.Text.Substring(1, txtCode.Text.Length - 1));
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
          catch (Exception e)
            {
                return false;
            }
        }

		private void barcodereg_Shown(object sender, EventArgs e)
		{
			HideCaret((int)txtCode.Handle);
			new selectsource().ShowDialog(this);
			HideCaret((int)txtCode.Handle);
		}

		private void barcodereg_Load(object sender, EventArgs e)
		{
			clear_fields();
		}

		private void txtCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				txtCode.Text = "";
                clear_fields();
			}
		}

		private void txtStatus_Click(object sender, EventArgs e)
		{

		}
	}
}
