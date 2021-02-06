namespace lazymail
{
    partial class kartero
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kartero));
			this.lvList = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.sENDSOMETHINGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sTANDARDREPLYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rEGISTRATIONFORMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cHANGEVENUEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mODIFIEDREGFORMBCODEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cHECKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cHECKALLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uNCHECKALLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rEFRESHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pROFILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.chkQualified = new System.Windows.Forms.CheckBox();
			this.chkDepslip = new System.Windows.Forms.CheckBox();
			this.chkEmailed = new System.Windows.Forms.CheckBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.sbcount = new System.Windows.Forms.ToolStripStatusLabel();
			this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvList
			// 
			this.lvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lvList.CheckBoxes = true;
			this.lvList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader8,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
			this.lvList.FullRowSelect = true;
			this.lvList.GridLines = true;
			this.lvList.HideSelection = false;
			this.lvList.Location = new System.Drawing.Point(0, 31);
			this.lvList.MultiSelect = false;
			this.lvList.Name = "lvList";
			this.lvList.Size = new System.Drawing.Size(985, 418);
			this.lvList.TabIndex = 0;
			this.lvList.UseCompatibleStateImageBehavior = false;
			this.lvList.View = System.Windows.Forms.View.Details;
			this.lvList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvList_ColumnClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 198;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "School";
			this.columnHeader2.Width = 134;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Center";
			this.columnHeader3.Width = 103;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Email";
			this.columnHeader4.Width = 114;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "profile";
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Qualified";
			this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader5.Width = 50;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Dep Slip";
			this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader6.Width = 52;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Noted";
			this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader7.Width = 56;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Status";
			this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader9.Width = 116;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Size";
			this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "Picture";
			this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sENDSOMETHINGToolStripMenuItem,
            this.cHECKToolStripMenuItem,
            this.rEFRESHToolStripMenuItem,
            this.pROFILEToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(984, 25);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// sENDSOMETHINGToolStripMenuItem
			// 
			this.sENDSOMETHINGToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sTANDARDREPLYToolStripMenuItem,
            this.rEGISTRATIONFORMToolStripMenuItem,
            this.cHANGEVENUEToolStripMenuItem,
            this.mODIFIEDREGFORMBCODEToolStripMenuItem});
			this.sENDSOMETHINGToolStripMenuItem.Name = "sENDSOMETHINGToolStripMenuItem";
			this.sENDSOMETHINGToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
			this.sENDSOMETHINGToolStripMenuItem.Text = "&SEND";
			// 
			// sTANDARDREPLYToolStripMenuItem
			// 
			this.sTANDARDREPLYToolStripMenuItem.Name = "sTANDARDREPLYToolStripMenuItem";
			this.sTANDARDREPLYToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.sTANDARDREPLYToolStripMenuItem.Text = "STANDARD REPLY";
			this.sTANDARDREPLYToolStripMenuItem.Click += new System.EventHandler(this.sTANDARDREPLYToolStripMenuItem_Click);
			// 
			// rEGISTRATIONFORMToolStripMenuItem
			// 
			this.rEGISTRATIONFORMToolStripMenuItem.Name = "rEGISTRATIONFORMToolStripMenuItem";
			this.rEGISTRATIONFORMToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.rEGISTRATIONFORMToolStripMenuItem.Text = "REGISTRATION FORM";
			this.rEGISTRATIONFORMToolStripMenuItem.Click += new System.EventHandler(this.rEGISTRATIONFORMToolStripMenuItem_Click);
			// 
			// cHANGEVENUEToolStripMenuItem
			// 
			this.cHANGEVENUEToolStripMenuItem.Name = "cHANGEVENUEToolStripMenuItem";
			this.cHANGEVENUEToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.cHANGEVENUEToolStripMenuItem.Text = "CHANGE VENUE";
			this.cHANGEVENUEToolStripMenuItem.Click += new System.EventHandler(this.cHANGEVENUEToolStripMenuItem_Click);
			// 
			// mODIFIEDREGFORMBCODEToolStripMenuItem
			// 
			this.mODIFIEDREGFORMBCODEToolStripMenuItem.Name = "mODIFIEDREGFORMBCODEToolStripMenuItem";
			this.mODIFIEDREGFORMBCODEToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
			this.mODIFIEDREGFORMBCODEToolStripMenuItem.Text = "!MODIFIED BARCODE";
			this.mODIFIEDREGFORMBCODEToolStripMenuItem.Click += new System.EventHandler(this.mODIFIEDREGFORMBCODEToolStripMenuItem_Click);
			// 
			// cHECKToolStripMenuItem
			// 
			this.cHECKToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cHECKALLToolStripMenuItem,
            this.uNCHECKALLToolStripMenuItem});
			this.cHECKToolStripMenuItem.Name = "cHECKToolStripMenuItem";
			this.cHECKToolStripMenuItem.Size = new System.Drawing.Size(65, 21);
			this.cHECKToolStripMenuItem.Text = "&CHECK";
			// 
			// cHECKALLToolStripMenuItem
			// 
			this.cHECKALLToolStripMenuItem.Name = "cHECKALLToolStripMenuItem";
			this.cHECKALLToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.cHECKALLToolStripMenuItem.Text = "CHECK ALL";
			this.cHECKALLToolStripMenuItem.Click += new System.EventHandler(this.cHECKALLToolStripMenuItem_Click);
			// 
			// uNCHECKALLToolStripMenuItem
			// 
			this.uNCHECKALLToolStripMenuItem.Name = "uNCHECKALLToolStripMenuItem";
			this.uNCHECKALLToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.uNCHECKALLToolStripMenuItem.Text = "UNCHECK ALL";
			this.uNCHECKALLToolStripMenuItem.Click += new System.EventHandler(this.uNCHECKALLToolStripMenuItem_Click);
			// 
			// rEFRESHToolStripMenuItem
			// 
			this.rEFRESHToolStripMenuItem.Name = "rEFRESHToolStripMenuItem";
			this.rEFRESHToolStripMenuItem.ShortcutKeyDisplayString = "F5";
			this.rEFRESHToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.rEFRESHToolStripMenuItem.Size = new System.Drawing.Size(83, 21);
			this.rEFRESHToolStripMenuItem.Text = "&REFRESH";
			this.rEFRESHToolStripMenuItem.Click += new System.EventHandler(this.rEFRESHToolStripMenuItem_Click);
			// 
			// pROFILEToolStripMenuItem
			// 
			this.pROFILEToolStripMenuItem.Name = "pROFILEToolStripMenuItem";
			this.pROFILEToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
			this.pROFILEToolStripMenuItem.Size = new System.Drawing.Size(83, 21);
			this.pROFILEToolStripMenuItem.Text = "PROFILE";
			this.pROFILEToolStripMenuItem.Click += new System.EventHandler(this.pROFILEToolStripMenuItem_Click);
			// 
			// chkQualified
			// 
			this.chkQualified.AutoSize = true;
			this.chkQualified.Checked = true;
			this.chkQualified.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkQualified.Location = new System.Drawing.Point(443, 4);
			this.chkQualified.Name = "chkQualified";
			this.chkQualified.Size = new System.Drawing.Size(67, 17);
			this.chkQualified.TabIndex = 2;
			this.chkQualified.Text = "Qualified";
			this.chkQualified.UseVisualStyleBackColor = true;
			// 
			// chkDepslip
			// 
			this.chkDepslip.AutoSize = true;
			this.chkDepslip.Checked = true;
			this.chkDepslip.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkDepslip.Location = new System.Drawing.Point(542, 4);
			this.chkDepslip.Name = "chkDepslip";
			this.chkDepslip.Size = new System.Drawing.Size(66, 17);
			this.chkDepslip.TabIndex = 3;
			this.chkDepslip.Text = "Dep Slip";
			this.chkDepslip.UseVisualStyleBackColor = true;
			// 
			// chkEmailed
			// 
			this.chkEmailed.AutoSize = true;
			this.chkEmailed.Location = new System.Drawing.Point(640, 4);
			this.chkEmailed.Name = "chkEmailed";
			this.chkEmailed.Size = new System.Drawing.Size(80, 17);
			this.chkEmailed.TabIndex = 4;
			this.chkEmailed.Text = "Emailed BC";
			this.chkEmailed.UseVisualStyleBackColor = true;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbcount});
			this.statusStrip1.Location = new System.Drawing.Point(0, 452);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(984, 22);
			this.statusStrip1.TabIndex = 9;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// sbcount
			// 
			this.sbcount.Name = "sbcount";
			this.sbcount.Size = new System.Drawing.Size(71, 17);
			this.sbcount.Text = "sbCount";
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "Level";
			this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// kartero
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 474);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.chkEmailed);
			this.Controls.Add(this.chkDepslip);
			this.Controls.Add(this.chkQualified);
			this.Controls.Add(this.lvList);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "kartero";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "MAILER";
			this.Load += new System.EventHandler(this.kartero_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sENDSOMETHINGToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkQualified;
		private System.Windows.Forms.CheckBox chkDepslip;
		private System.Windows.Forms.CheckBox chkEmailed;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ToolStripMenuItem rEFRESHToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sbcount;
		private System.Windows.Forms.ToolStripMenuItem sTANDARDREPLYToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rEGISTRATIONFORMToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cHECKToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cHECKALLToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem uNCHECKALLToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ToolStripMenuItem cHANGEVENUEToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pROFILEToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ToolStripMenuItem mODIFIEDREGFORMBCODEToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
    }
}