namespace lazyviewer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbNameLookup = new System.Windows.Forms.ComboBox();
            this.mnuBack = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuForward = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuZoomed = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHFlip = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVFlip = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sOURCEToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rEFRESHToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aPPENDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rOTLEFTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rOTRIGHTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDetails
            // 
            this.txtDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetails.Location = new System.Drawing.Point(1029, 4);
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(245, 20);
            this.txtDetails.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cbNameLookup
            // 
            this.cbNameLookup.FormattingEnabled = true;
            this.cbNameLookup.Location = new System.Drawing.Point(760, 3);
            this.cbNameLookup.Name = "cbNameLookup";
            this.cbNameLookup.Size = new System.Drawing.Size(263, 21);
            this.cbNameLookup.TabIndex = 1;
            this.cbNameLookup.SelectedIndexChanged += new System.EventHandler(this.cbNameLookup_SelectedIndexChanged);
            // 
            // mnuBack
            // 
            this.mnuBack.Name = "mnuBack";
            this.mnuBack.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.mnuBack.Size = new System.Drawing.Size(58, 24);
            this.mnuBack.Text = "&BACK";
            this.mnuBack.Click += new System.EventHandler(this.mnuBack_Click);
            // 
            // mnuForward
            // 
            this.mnuForward.Name = "mnuForward";
            this.mnuForward.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.mnuForward.Size = new System.Drawing.Size(92, 24);
            this.mnuForward.Text = "&FORWARD";
            this.mnuForward.Click += new System.EventHandler(this.mnuForward_Click);
            // 
            // mnuZoomed
            // 
            this.mnuZoomed.CheckOnClick = true;
            this.mnuZoomed.Name = "mnuZoomed";
            this.mnuZoomed.Size = new System.Drawing.Size(65, 24);
            this.mnuZoomed.Text = "&ZOOM";
            // 
            // mnuHFlip
            // 
            this.mnuHFlip.CheckOnClick = true;
            this.mnuHFlip.Name = "mnuHFlip";
            this.mnuHFlip.Size = new System.Drawing.Size(80, 24);
            this.mnuHFlip.Text = "HFLIP (&1)";
            this.mnuHFlip.Click += new System.EventHandler(this.mnuHFlip_Click);
            // 
            // mnuVFlip
            // 
            this.mnuVFlip.CheckOnClick = true;
            this.mnuVFlip.Name = "mnuVFlip";
            this.mnuVFlip.Size = new System.Drawing.Size(78, 24);
            this.mnuVFlip.Text = "VFLIP (&2)";
            this.mnuVFlip.Click += new System.EventHandler(this.mnuVFlip_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.mnuZoomed,
            this.mnuBack,
            this.mnuForward,
            this.mnuHFlip,
            this.mnuVFlip,
            this.rOTLEFTToolStripMenuItem,
            this.rOTRIGHTToolStripMenuItem,
            this.cmdOpen});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1274, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sOURCEToolStripMenuItem1,
            this.rEFRESHToolStripMenuItem1,
            this.aPPENDToolStripMenuItem,
            this.eXITToolStripMenuItem});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.fILEToolStripMenuItem.Text = "FILE";
            // 
            // sOURCEToolStripMenuItem1
            // 
            this.sOURCEToolStripMenuItem1.Name = "sOURCEToolStripMenuItem1";
            this.sOURCEToolStripMenuItem1.Size = new System.Drawing.Size(183, 24);
            this.sOURCEToolStripMenuItem1.Text = "SOURCE";
            this.sOURCEToolStripMenuItem1.Click += new System.EventHandler(this.sOURCEToolStripMenuItem1_Click);
            // 
            // rEFRESHToolStripMenuItem1
            // 
            this.rEFRESHToolStripMenuItem1.Name = "rEFRESHToolStripMenuItem1";
            this.rEFRESHToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.rEFRESHToolStripMenuItem1.Size = new System.Drawing.Size(183, 24);
            this.rEFRESHToolStripMenuItem1.Text = "REFRESH";
            this.rEFRESHToolStripMenuItem1.Click += new System.EventHandler(this.rEFRESHToolStripMenuItem1_Click);
            // 
            // aPPENDToolStripMenuItem
            // 
            this.aPPENDToolStripMenuItem.Name = "aPPENDToolStripMenuItem";
            this.aPPENDToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.aPPENDToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.aPPENDToolStripMenuItem.Text = "APPEN&D";
            this.aPPENDToolStripMenuItem.Click += new System.EventHandler(this.aPPENDToolStripMenuItem_Click);
            // 
            // eXITToolStripMenuItem
            // 
            this.eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            this.eXITToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.eXITToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.eXITToolStripMenuItem.Text = "EXIT";
            this.eXITToolStripMenuItem.Click += new System.EventHandler(this.eXITToolStripMenuItem_Click);
            // 
            // rOTLEFTToolStripMenuItem
            // 
            this.rOTLEFTToolStripMenuItem.CheckOnClick = true;
            this.rOTLEFTToolStripMenuItem.Name = "rOTLEFTToolStripMenuItem";
            this.rOTLEFTToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.rOTLEFTToolStripMenuItem.Text = "ROT LEFT";
            this.rOTLEFTToolStripMenuItem.Click += new System.EventHandler(this.rOTLEFTToolStripMenuItem_Click);
            // 
            // rOTRIGHTToolStripMenuItem
            // 
            this.rOTRIGHTToolStripMenuItem.CheckOnClick = true;
            this.rOTRIGHTToolStripMenuItem.Name = "rOTRIGHTToolStripMenuItem";
            this.rOTRIGHTToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.rOTRIGHTToolStripMenuItem.Text = "ROT RIGHT";
            this.rOTRIGHTToolStripMenuItem.Click += new System.EventHandler(this.rOTRIGHTToolStripMenuItem_Click);
            // 
            // cmdOpen
            // 
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(59, 24);
            this.cmdOpen.Text = "OPEN";
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 486);
            this.Controls.Add(this.cbNameLookup);
            this.Controls.Add(this.txtDetails);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "lazyviewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cbNameLookup;
		private System.Windows.Forms.ToolStripMenuItem mnuBack;
		private System.Windows.Forms.ToolStripMenuItem mnuForward;
		private System.Windows.Forms.ToolStripMenuItem mnuZoomed;
		private System.Windows.Forms.ToolStripMenuItem mnuHFlip;
        private System.Windows.Forms.ToolStripMenuItem mnuVFlip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sOURCEToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rEFRESHToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aPPENDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rOTLEFTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rOTRIGHTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmdOpen;
    }
}

