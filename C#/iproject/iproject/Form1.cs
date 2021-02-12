using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using iproject;

namespace iproject
{
    public partial class Form1 : Form
    {
        OleDbConnection cn;
        OleDbCommand cmd;
        OleDbDataReader dr;
        iproject.cbojbect co;
        int uid;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = new OleDbConnection();
            cn.ConnectionString = "Provider=Microsoft.jet.oledb.4.0;Data Source=\\\\Juriel\\Data$\\OKT08.mdb;jet oledb:database password=ocomokt2008";
            try
            {
                cn.Open();
                cmd = cn.CreateCommand();
                cmd.Connection = cn;
                cmd.CommandText = "select p_num,p_name from ren_per_info order by p_name";
                cbNames.Items.Clear();
                dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    co = new cbojbect();
                    co.Text = dr.GetString(dr.GetOrdinal("p_name"));
                    co.Value = Int32.Parse((string)dr.GetValue(dr.GetOrdinal("p_num")));
                    cbNames.Items.Add("");
                    cbNames.Items[cbNames.Items.Count - 1] = (iproject.cbojbect)co;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            co =(iproject.cbojbect)cbNames.SelectedItem;
            uid = (int)co.Value;
            filllist();
        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {
            dateTo.Value = dateFrom.Value;
        }

        void filllist()
        {
            string cs,s1,s2;
            DateTime d;
            ListViewItem i;

            lvlist.Items.Clear();

            d = dateFrom.Value;
            while (d.CompareTo(dateTo.Value)<=0)
            {
                cs = "select format(t.date_time,'mm/dd/yyyy') as xdate,format(t.date_time,'hh:mm ampm') as xtime,t.date_time,t.id " +
                     " from ren_per_info as e left join record_ta as t on e.p_code = t.card_number " +
                     " where datevalue(t.date_time) = #" + d.Date.ToString("d") + "# and e.p_code = '" + uid + "' order by t.date_time";
                cmd.CommandText = cs;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    s1 = "#%#";
                    while (dr.Read())
                    {
                        s2 = dr.GetValue(dr.GetOrdinal("xtime")).ToString();
                        if (String.Compare(s1,s2)!=0)
                        {
                            i = lvlist.Items.Add(d.Date.ToString("d"));
                            i.SubItems.Add(s2);
                            i.SubItems.Add(dr.GetString(dr.GetOrdinal("date_time")));
                            i.SubItems.Add(dr.GetValue(dr.GetOrdinal("id")).ToString());
                            s1 = s2;
                        }
                    }
                }
                dr.Close();
                d = d.AddDays(1);                

            }
            
        }

        private void dateTo_ValueChanged(object sender, EventArgs e)
        {
            filllist();
        }

        private void lvlist_MouseClick(object sender, MouseEventArgs e)
        {
            mnuDelete.Enabled = !(lvlist.Items.Count == 0);
            mnuEdit.Enabled = !(lvlist.Items.Count == 0);

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                mnuContext.Show(lvlist, e.Location);
            }
        }

        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime oldtime;
            ListViewItem li;
            inputbox b;
            string cs;

            li = lvlist.SelectedItems[0];
            oldtime = Convert.ToDateTime(li.SubItems[2].Text);
            //b = new inputbox(String.Format("{0:yyyy}-{0:MM}-{0:dd} {0:HH}:{0:mm}:{0:ss}", oldtime));
            b = new inputbox(oldtime);
            b.ShowDialog(this);

            if (b.result)
            {
                try
                {
                    //td = Convert.ToDateTime(b.txtInput.Text);
                    //cs = "update record_ta set date_time = '" + b.txtInput.Text + "' where id=" + li.SubItems[3].Text;
                    cs = "update record_ta set date_time = '" + b.dtDateTime.Text + "' where id=" + li.SubItems[3].Text;
                    cmd.CommandText = cs;
                    cmd.ExecuteNonQuery();
                    filllist();
                }
                catch (Exception er)
                {
                    MessageBox.Show("invalid value" + " " + er.Message);
                }

            }
        }

        private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem li;
            string cs;

            if (MessageBox.Show("Delete?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                return;

            li = lvlist.SelectedItems[0];

                try
                {
                    cs = "Delete from record_ta where id=" + li.SubItems[3].Text;
                    cmd.CommandText = cs;
                    cmd.ExecuteNonQuery();
                    filllist();
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error" + " " + er.Message);
                }
        }

        private void iNSERTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem li;
            inputbox b;
            string cs;

            if (lvlist.SelectedItems.Count > 0)
            {
                li = lvlist.SelectedItems[0];
                b = new inputbox(Convert.ToDateTime(li.SubItems[2].Text));
                b.ShowDialog(this);
            }
            else
            {
                b = new inputbox();
                b.ShowDialog(this);
            }


            if (b.result)
            {
                try
                {
                    //td = Convert.ToDateTime(b.txtInput.Text);
                    cs = "insert into record_ta(Mach_no,pinfo_id,card_number,date_time,fun_key,in_out) values('1'," + uid + ",'" + uid + "','" + b.dtDateTime.Text + "',0,0)";
                    cmd.CommandText = cs;
                    cmd.ExecuteNonQuery();
                    filllist();
                }
                catch (Exception er)
                {
                    MessageBox.Show("invalid value" + " " + er.Message);
                }

            }

        }

        private void iNSERTToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            mnuInsert.PerformClick();
        }
    }


    public class cbojbect
    {
        public object Value {get;set;}
        public string Text {get;set;}
        public override string ToString()
        {
            return Text;
        }
    }
}
