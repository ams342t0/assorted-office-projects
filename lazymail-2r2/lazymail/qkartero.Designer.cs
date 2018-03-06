namespace lazymail
{
    partial class qkartero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(qkartero));
            this.lvList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sENDSOMETHINGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEGISTRATIONFORMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mESSAGEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qUERYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cHECKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cHECKALLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uNCHECKALLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEFRESHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pROFILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sbcount = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbResult = new System.Windows.Forms.ComboBox();
            this.cbName = new System.Windows.Forms.ComboBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
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
            this.columnHeader12,
            this.columnHeader7,
            this.columnHeader9});
            this.lvList.FullRowSelect = true;
            this.lvList.GridLines = true;
            this.lvList.HideSelection = false;
            this.lvList.Location = new System.Drawing.Point(0, 31);
            this.lvList.MultiSelect = false;
            this.lvList.Name = "lvList";
            this.lvList.Size = new System.Drawing.Size(913, 418);
            this.lvList.TabIndex = 0;
            this.lvList.UseCompatibleStateImageBehavior = false;
            this.lvList.View = System.Windows.Forms.View.Details;
            this.lvList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvList_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "School";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Center";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Email";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Level";
            this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Result";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 56;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Status";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 116;
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
            this.menuStrip1.Size = new System.Drawing.Size(912, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sENDSOMETHINGToolStripMenuItem
            // 
            this.sENDSOMETHINGToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rEGISTRATIONFORMToolStripMenuItem,
            this.mESSAGEToolStripMenuItem,
            this.qUERYToolStripMenuItem});
            this.sENDSOMETHINGToolStripMenuItem.Name = "sENDSOMETHINGToolStripMenuItem";
            this.sENDSOMETHINGToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.sENDSOMETHINGToolStripMenuItem.Text = "&SEND";
            // 
            // rEGISTRATIONFORMToolStripMenuItem
            // 
            this.rEGISTRATIONFORMToolStripMenuItem.Name = "rEGISTRATIONFORMToolStripMenuItem";
            this.rEGISTRATIONFORMToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.rEGISTRATIONFORMToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.rEGISTRATIONFORMToolStripMenuItem.Text = "REGISTRATION FORM";
            this.rEGISTRATIONFORMToolStripMenuItem.Click += new System.EventHandler(this.rEGISTRATIONFORMToolStripMenuItem_Click);
            // 
            // mESSAGEToolStripMenuItem
            // 
            this.mESSAGEToolStripMenuItem.Name = "mESSAGEToolStripMenuItem";
            this.mESSAGEToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.mESSAGEToolStripMenuItem.Text = "MESSAGE...";
            this.mESSAGEToolStripMenuItem.Click += new System.EventHandler(this.mESSAGEToolStripMenuItem_Click);
            // 
            // qUERYToolStripMenuItem
            // 
            this.qUERYToolStripMenuItem.Name = "qUERYToolStripMenuItem";
            this.qUERYToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.qUERYToolStripMenuItem.Text = "QUERY";
            // 
            // cHECKToolStripMenuItem
            // 
            this.cHECKToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cHECKALLToolStripMenuItem,
            this.uNCHECKALLToolStripMenuItem});
            this.cHECKToolStripMenuItem.Name = "cHECKToolStripMenuItem";
            this.cHECKToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.cHECKToolStripMenuItem.Text = "&CHECK";
            // 
            // cHECKALLToolStripMenuItem
            // 
            this.cHECKALLToolStripMenuItem.Name = "cHECKALLToolStripMenuItem";
            this.cHECKALLToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.cHECKALLToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.cHECKALLToolStripMenuItem.Text = "CHECK ALL";
            this.cHECKALLToolStripMenuItem.Click += new System.EventHandler(this.cHECKALLToolStripMenuItem_Click);
            // 
            // uNCHECKALLToolStripMenuItem
            // 
            this.uNCHECKALLToolStripMenuItem.Name = "uNCHECKALLToolStripMenuItem";
            this.uNCHECKALLToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.uNCHECKALLToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.uNCHECKALLToolStripMenuItem.Text = "UNCHECK ALL";
            this.uNCHECKALLToolStripMenuItem.Click += new System.EventHandler(this.uNCHECKALLToolStripMenuItem_Click);
            // 
            // rEFRESHToolStripMenuItem
            // 
            this.rEFRESHToolStripMenuItem.Name = "rEFRESHToolStripMenuItem";
            this.rEFRESHToolStripMenuItem.ShortcutKeyDisplayString = "F5";
            this.rEFRESHToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.rEFRESHToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.rEFRESHToolStripMenuItem.Text = "&REFRESH";
            this.rEFRESHToolStripMenuItem.Click += new System.EventHandler(this.rEFRESHToolStripMenuItem_Click);
            // 
            // pROFILEToolStripMenuItem
            // 
            this.pROFILEToolStripMenuItem.Name = "pROFILEToolStripMenuItem";
            this.pROFILEToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.pROFILEToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.pROFILEToolStripMenuItem.Text = "PROFILE";
            this.pROFILEToolStripMenuItem.Click += new System.EventHandler(this.pROFILEToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbcount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 452);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(912, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sbcount
            // 
            this.sbcount.Name = "sbcount";
            this.sbcount.Size = new System.Drawing.Size(63, 17);
            this.sbcount.Text = "sbCount";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cbResult
            // 
            this.cbResult.FormattingEnabled = true;
            this.cbResult.Location = new System.Drawing.Point(282, 0);
            this.cbResult.Name = "cbResult";
            this.cbResult.Size = new System.Drawing.Size(148, 21);
            this.cbResult.TabIndex = 10;
            // 
            // cbName
            // 
            this.cbName.FormattingEnabled = true;
            this.cbName.Location = new System.Drawing.Point(436, -1);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(148, 21);
            this.cbName.TabIndex = 13;
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(590, 0);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(249, 20);
            this.txtSubject.TabIndex = 14;
            // 
            // qkartero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 474);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.cbName);
            this.Controls.Add(this.cbResult);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lvList);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "qkartero";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MOSTP MAILER";
            this.Load += new System.EventHandler(this.qkartero_Load);
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
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ToolStripMenuItem rEFRESHToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sbcount;
		private System.Windows.Forms.ToolStripMenuItem rEGISTRATIONFORMToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cHECKToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cHECKALLToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem uNCHECKALLToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ToolStripMenuItem pROFILEToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ToolStripMenuItem mESSAGEToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem qUERYToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbResult;
        private System.Windows.Forms.ComboBox cbName;
        private System.Windows.Forms.TextBox txtSubject;
    }
}