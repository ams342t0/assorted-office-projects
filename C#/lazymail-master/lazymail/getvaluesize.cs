using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lazymail
{
	public partial class getvaluesize : Form
	{
		public long v=0;

		public getvaluesize()
		{
			InitializeComponent();
		}

		private void txtValue_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				try
				{
					v = Int32.Parse(txtValue.Text);
				}
				catch (FormatException ex)
				{
					v = 0;
				}
				this.Close();
			}
		}

		private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
		{

		}
	}
}
