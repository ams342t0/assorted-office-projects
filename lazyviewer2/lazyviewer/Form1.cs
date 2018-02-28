using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Data.OleDb;
using System.Linq;

namespace lazyviewer
{
    public partial class Form1 : Form
    {
        List<string> jpgfiles;
        long jpgindex=0;
		long selid;
        BufferedGraphics bg;
        BufferedGraphicsContext bgc;
        Graphics mg;
        int sx, sy, cx, cy,px,py;
        string imagepath;
        OleDbConnection dbcon;
        OleDbCommand dbcmd;
        OleDbDataReader dbdr;
		string dbpath;

        public Form1()
        {
            InitializeComponent();
            mnuBack.Enabled = false;
            mnuForward.Enabled = false;
            jpgfiles = new List<string>();
            bgc = BufferedGraphicsManager.Current;

            if (Program.f.Length > 0)
            {
                jpgfiles.Add(Program.f);
            }

            loadreg();

			if (!File.Exists(dbpath))
			{
				openFileDialog1.Filter = "backend|backend.mdb";
				openFileDialog1.Title = "OPEN BACKEND";
				if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					dbpath = openFileDialog1.FileName;
				}
				else
				{
					MessageBox.Show("Can't find backend. Exiting.");
					Environment.Exit(-1);
				}
			}
            dbcon = new OleDbConnection("Provider=Microsoft.jet.oledb.4.0;data source=" + dbpath);
            dbcon.Open();
            dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = "select studid,fullname from students order by fullname";
            dbdr = dbcmd.ExecuteReader();
            cbNameLookup.Items.Clear();

			cbNameLookup.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			cbNameLookup.AutoCompleteSource = AutoCompleteSource.ListItems;

            while (dbdr.Read())
            {
                cbitem c = new cbitem();
                c.Text = dbdr.GetString(dbdr.GetOrdinal("fullname"));
                c.Value = dbdr.GetInt32(dbdr.GetOrdinal("studid"));
                cbNameLookup.Items.Add(c);
            }
            dbdr.Close();
        }

        void showpic()
        {
            cmdOpen.Enabled = false;
            try
            {
                Bitmap b;

                if (jpgfiles.Count == 0)
                    return;

                Text = jpgfiles[(int)jpgindex] + " (" + (jpgindex + 1) + " of " + jpgfiles.Count + ")";
                b = new Bitmap(jpgfiles[(int)jpgindex]);
                if (mnuVFlip.Checked)
                    b.RotateFlip(RotateFlipType.Rotate180FlipX);
                if (mnuHFlip.Checked)
                    b.RotateFlip(RotateFlipType.Rotate180FlipY);

                if (rOTLEFTToolStripMenuItem.Checked)
                    b.RotateFlip(RotateFlipType.Rotate270FlipNone);

                if (rOTRIGHTToolStripMenuItem.Checked)
                    b.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    
                if (mnuZoomed.Checked)
                {
                    mg.FillRectangle(Brushes.Gray, DisplayRectangle);
                    mg.DrawImage(b, px + cx - sx, py + cy - sy);
                }
                else
                    mg.DrawImage(b, DisplayRectangle);
                bg.Render();
            }
            catch (Exception e)
            {
                cmdOpen.Enabled = true;
                mg.FillRectangle(Brushes.Black, DisplayRectangle);
                mg.DrawString(jpgfiles[(int)jpgindex], new Font("Impact", 32), Brushes.White, new Point(10, 50));
                bg.Render();
            }
        }

        void showblank()
        {
            mg.FillRectangle(Brushes.Gray, DisplayRectangle);
            bg.Render();
        }

        void loadreg()
        {
            try
            {
                long v = 0;
                imagepath = (string)Registry.CurrentUser.CreateSubKey("lazyref2", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("imgroot",(string) @"d:\");
                jpgindex = Int32.Parse((string)Registry.CurrentUser.CreateSubKey("lazyref2", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("jpgindex",(string) "0"));
                dbpath = (string)Registry.CurrentUser.CreateSubKey("lazyref2", RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue("dbpath", (string)@"D:\database 2015\backend.mdb");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void savereg()
        {
            Registry.CurrentUser.CreateSubKey("lazyref2", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("imgroot", (string)imagepath);
            Registry.CurrentUser.CreateSubKey("lazyref2", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("jpgindex", (string)jpgindex.ToString());
            Registry.CurrentUser.CreateSubKey("lazyref2", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("dbpath", (string)dbpath);
        }

        private void open_imagefolder()
        {
            RegistryKey k;

            k = Registry.CurrentUser.CreateSubKey("lazyref2",RegistryKeyPermissionCheck.ReadWriteSubTree);
            
            folderBrowserDialog1.SelectedPath = (string)k.GetValue("imgroot", (string)"");

            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                resetview();
                mnuBack.Enabled = false;
                mnuForward.Enabled = false;
                jpgfiles.Clear();
                imagepath = folderBrowserDialog1.SelectedPath;
                Text = "lazyviewer";
                k.SetValue("imgroot", (string)imagepath);
                refresh_contents();
            }
        }

        void refresh_contents()
        {
            jpgfiles.Clear();

            var f = new DirectoryInfo(imagepath).GetFiles().OrderBy(fx => fx.LastWriteTime).ToList();

            foreach (FileInfo s in f)
            {
               jpgfiles.Add(s.FullName);
            }

            if (jpgindex >= jpgfiles.Count)
            {
                jpgindex = jpgfiles.Count - 1;
            }

            if (jpgfiles.Count > 0)
            {
                if (jpgfiles.Count > 1)
                    mnuForward.Enabled = true;
                showpic();
            }
            else
                showblank();
        }

        void resetview()
        {
            px = 0;
            py = 0;
            cx = 0;
            cy = 0;
            sx = 0;
            sy = 0;
            mnuHFlip.Checked = false;
            mnuVFlip.Checked = false;
            mnuZoomed.Checked = false;
            mnuZoomed.Text = "&ZOOM";
        }

        private void mnuForward_Click(object sender, EventArgs e)
        {
            mnuBack.Enabled = true;
            if (jpgindex < jpgfiles.Count - 1)
            {
                jpgindex++;
            }
            if (jpgindex == jpgfiles.Count - 1)
                mnuForward.Enabled = false;
            resetview();
            showpic();
        }

        private void mnuBack_Click(object sender, EventArgs e)
        {
            mnuForward.Enabled = true;
            if (jpgindex > 0)
                jpgindex--;
            if (jpgindex == 0)
                mnuBack.Enabled = false;
            resetview();
            showpic();
        }


        bool entryexists()
        {
            OleDbCommand c = dbcon.CreateCommand();
            c.CommandText = "select count(filename) as n from studfiles where studid = " + selid.ToString() + " and filename like \"" + jpgfiles[(int)jpgindex] + "\"";
            OleDbDataReader r = c.ExecuteReader();
            r.Read();
            long i = r.GetInt32(r.GetOrdinal("n"));
            if (i > 0)
                return true;
            else
                return false;
        }

        void append()
        {
            if (jpgfiles.Count == 0 || selid == 0 || entryexists())
            {
                MessageBox.Show("skipped");
                return;
            }

			dbcmd.CommandText = "insert into studfiles values(" + selid.ToString() + ",\"" + jpgfiles[(int)jpgindex] + "\")";
			try
			{
				dbcmd.ExecuteNonQuery();
				MessageBox.Show("Ok");
			}
			catch (Exception x)
			{
				MessageBox.Show(x.Message);
			}
			mnuForward_Click(null, null);
        }

        void zoom()
        {
            if (mnuZoomed.Checked)
            {
                mnuZoomed.Text = "UN&ZOOM";
                px = 0;
                py = 0;
                cx = 0;
                cy = 0;
                sx = 0;
                sy = 0;
            }
            else
                mnuZoomed.Text = "&ZOOM";
            showpic();
        }

        private void mnuHFlip_Click(object sender, EventArgs e)
        {
            showpic();
        }

        private void mnuVFlip_Click(object sender, EventArgs e)
        {
            showpic();
        }


        private void iMAGEPATHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open_imagefolder();
        }

		string bs(long i)
		{
			if (i < 0)
				return "YES";
			else
				return "NO";
		}


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            showpic();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            sx=e.X;
            sy = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button == System.Windows.Forms.MouseButtons.Left) && mnuZoomed.Checked)
            {
                cx = e.X;
                cy = e.Y;
                showpic();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            bg = bgc.Allocate(CreateGraphics(), DisplayRectangle);
            mg = bg.Graphics;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            px += cx - sx;
            py += cy - sy;
        }


        private void eITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }


        string getimgroot(string path)
        {
            string[] roots = Path.GetDirectoryName(path).Split('\\');
            return roots[2] + "\\" + Path.GetFileName(path);
        }

		string getstring(OleDbDataReader r, string c)
		{
			return r.GetString(r.GetOrdinal(c));
		}

		long getlong(OleDbDataReader r, string c)
		{
			return r.GetInt32(r.GetOrdinal(c));
		}

		private void cbNameLookup_SelectedIndexChanged(object sender, EventArgs e)
		{
			OleDbCommand c;
			OleDbDataReader dr;

			selid = ((cbitem)cbNameLookup.SelectedItem).Value;
			
			c = dbcon.CreateCommand();
			c.CommandText = "select s.school,s.sex,s.ilevel,s.is_qualified,s.depslip,s.depslipscan,s.profilescan,c.centername from students as s inner join centers as c on s.center = c.centerid where studid = " + selid.ToString();
			dr = c.ExecuteReader();
			dr.Read();
			txtDetails.Text = getstring(dr,"school").Substring(0,7) + " ; " + getstring(dr,"centername").Substring(0,7) + " ; " + getlong(dr, "ilevel").ToString() + " ; " + getlong(dr,"sex").ToString() + " ; " + bs(getlong(dr,"is_qualified")) + " ; " + bs(getlong(dr,"depslip")) + " ; " + getstring(dr,"depslipscan").Substring(0,7) + " ; " + getstring(dr,"profilescan").Substring(0,7);
			dr.Close();
		}

        private void rEFRESHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refresh_contents();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            savereg();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //refresh_contents();
        }

        private void sOURCEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            open_imagefolder();
        }

        private void rEFRESHToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            refresh_contents();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void aPPENDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            append();
        }

        private void rOTLEFTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showpic();
        }

        private void rOTRIGHTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showpic();
        }

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(jpgfiles[(int)jpgindex]);
        }

    }


    class cbitem
    {
        public int Value {get;set;}
        public string Text { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
}




