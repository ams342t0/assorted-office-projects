namespace lazymail
{
	partial class picview
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.zoom = new System.Windows.Forms.ToolStripMenuItem();
			this.flipV = new System.Windows.Forms.ToolStripMenuItem();
			this.flipH = new System.Windows.Forms.ToolStripMenuItem();
			this.rotleft = new System.Windows.Forms.ToolStripMenuItem();
			this.rotright = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoom,
            this.flipV,
            this.flipH,
            this.rotleft,
            this.rotright});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(692, 25);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// zoom
			// 
			this.zoom.CheckOnClick = true;
			this.zoom.Name = "zoom";
			this.zoom.Size = new System.Drawing.Size(56, 21);
			this.zoom.Text = "ZOOM";
			this.zoom.Click += new System.EventHandler(this.zoom_Click);
			// 
			// flipV
			// 
			this.flipV.CheckOnClick = true;
			this.flipV.Name = "flipV";
			this.flipV.Size = new System.Drawing.Size(101, 21);
			this.flipV.Text = "FLIP VERT";
			this.flipV.Click += new System.EventHandler(this.flipV_Click);
			// 
			// flipH
			// 
			this.flipH.CheckOnClick = true;
			this.flipH.Name = "flipH";
			this.flipH.Size = new System.Drawing.Size(101, 21);
			this.flipH.Text = "FLIP HORZ";
			this.flipH.Click += new System.EventHandler(this.flipH_Click);
			// 
			// rotleft
			// 
			this.rotleft.CheckOnClick = true;
			this.rotleft.Name = "rotleft";
			this.rotleft.Size = new System.Drawing.Size(119, 21);
			this.rotleft.Text = "ROTATE LEFT";
			this.rotleft.Click += new System.EventHandler(this.rotleft_Click);
			// 
			// rotright
			// 
			this.rotright.CheckOnClick = true;
			this.rotright.Name = "rotright";
			this.rotright.Size = new System.Drawing.Size(128, 21);
			this.rotright.Text = "ROTATE RIGHT";
			this.rotright.Click += new System.EventHandler(this.rotright_Click);
			// 
			// picview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(692, 672);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "picview";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Deactivate += new System.EventHandler(this.picview_Deactivate);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.picview_Paint);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picview_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picview_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picview_MouseUp);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem zoom;
		private System.Windows.Forms.ToolStripMenuItem flipV;
		private System.Windows.Forms.ToolStripMenuItem flipH;
        private System.Windows.Forms.ToolStripMenuItem rotleft;
        private System.Windows.Forms.ToolStripMenuItem rotright;
	}
}