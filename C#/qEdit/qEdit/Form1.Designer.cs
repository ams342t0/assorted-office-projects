namespace qEdit
{
    partial class qEdit
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
            this.mFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mView = new System.Windows.Forms.ToolStripMenuItem();
            this.mExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.mInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.mUp = new System.Windows.Forms.ToolStripMenuItem();
            this.mDown = new System.Windows.Forms.ToolStripMenuItem();
            this.mTop = new System.Windows.Forms.ToolStripMenuItem();
            this.mBottom = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbSheet = new System.Windows.Forms.ComboBox();
            this.cbColumn = new System.Windows.Forms.ComboBox();
            this.cbValue = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.lStartRow = new System.Windows.Forms.NumericUpDown();
            this.lStartColumn = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lStartRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lStartColumn)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mFile,
            this.mSearch,
            this.mInsert,
            this.mUp,
            this.mDown,
            this.mTop,
            this.mBottom});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(386, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mFile
            // 
            this.mFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mOpen,
            this.mSave,
            this.mView,
            this.mExit});
            this.mFile.Name = "mFile";
            this.mFile.Size = new System.Drawing.Size(40, 20);
            this.mFile.Text = "FILE";
            // 
            // mOpen
            // 
            this.mOpen.Name = "mOpen";
            this.mOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mOpen.Size = new System.Drawing.Size(204, 22);
            this.mOpen.Text = "OPEN SOURCE...";
            this.mOpen.Click += new System.EventHandler(this.sOURCEToolStripMenuItem_Click);
            // 
            // mSave
            // 
            this.mSave.Name = "mSave";
            this.mSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mSave.Size = new System.Drawing.Size(204, 22);
            this.mSave.Text = "SAVE";
            this.mSave.Click += new System.EventHandler(this.sAVEToolStripMenuItem_Click);
            // 
            // mView
            // 
            this.mView.Name = "mView";
            this.mView.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.mView.Size = new System.Drawing.Size(204, 22);
            this.mView.Text = "VIEW SOURCE";
            this.mView.Click += new System.EventHandler(this.fOCUSToolStripMenuItem_Click);
            // 
            // mExit
            // 
            this.mExit.Name = "mExit";
            this.mExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mExit.Size = new System.Drawing.Size(204, 22);
            this.mExit.Text = "EXIT";
            this.mExit.Click += new System.EventHandler(this.eXITToolStripMenuItem_Click);
            // 
            // mSearch
            // 
            this.mSearch.Name = "mSearch";
            this.mSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.mSearch.Size = new System.Drawing.Size(63, 20);
            this.mSearch.Text = "&SEARCH";
            this.mSearch.Click += new System.EventHandler(this.sEARCHToolStripMenuItem_Click);
            // 
            // mInsert
            // 
            this.mInsert.Name = "mInsert";
            this.mInsert.Size = new System.Drawing.Size(57, 20);
            this.mInsert.Text = "&INSERT";
            this.mInsert.Click += new System.EventHandler(this.iNSERTToolStripMenuItem1_Click);
            // 
            // mUp
            // 
            this.mUp.Name = "mUp";
            this.mUp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mUp.Size = new System.Drawing.Size(34, 20);
            this.mUp.Text = "&UP";
            this.mUp.Click += new System.EventHandler(this.uPToolStripMenuItem_Click);
            // 
            // mDown
            // 
            this.mDown.Name = "mDown";
            this.mDown.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mDown.Size = new System.Drawing.Size(56, 20);
            this.mDown.Text = "D&OWN";
            this.mDown.Click += new System.EventHandler(this.dOWNToolStripMenuItem_Click);
            // 
            // mTop
            // 
            this.mTop.Name = "mTop";
            this.mTop.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.mTop.Size = new System.Drawing.Size(42, 20);
            this.mTop.Text = "&TOP";
            this.mTop.Click += new System.EventHandler(this.fIRSTToolStripMenuItem_Click);
            // 
            // mBottom
            // 
            this.mBottom.Name = "mBottom";
            this.mBottom.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.mBottom.Size = new System.Drawing.Size(69, 20);
            this.mBottom.Text = "&BOTTOM";
            this.mBottom.Click += new System.EventHandler(this.bOTTOMToolStripMenuItem_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.status.Location = new System.Drawing.Point(0, 144);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(386, 22);
            this.status.TabIndex = 1;
            this.status.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // cbSheet
            // 
            this.cbSheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSheet.FormattingEnabled = true;
            this.cbSheet.Location = new System.Drawing.Point(89, 55);
            this.cbSheet.Name = "cbSheet";
            this.cbSheet.Size = new System.Drawing.Size(285, 26);
            this.cbSheet.TabIndex = 2;
            this.cbSheet.SelectedIndexChanged += new System.EventHandler(this.cbSheet_SelectedIndexChanged);
            // 
            // cbColumn
            // 
            this.cbColumn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbColumn.FormattingEnabled = true;
            this.cbColumn.Location = new System.Drawing.Point(89, 82);
            this.cbColumn.Name = "cbColumn";
            this.cbColumn.Size = new System.Drawing.Size(285, 26);
            this.cbColumn.TabIndex = 3;
            this.cbColumn.SelectedIndexChanged += new System.EventHandler(this.cbColumn_SelectedIndexChanged);
            // 
            // cbValue
            // 
            this.cbValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbValue.FormattingEnabled = true;
            this.cbValue.Location = new System.Drawing.Point(89, 109);
            this.cbValue.Name = "cbValue";
            this.cbValue.Size = new System.Drawing.Size(285, 26);
            this.cbValue.TabIndex = 4;
            this.cbValue.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cbValue_PreviewKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "SHEET";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "COLUMN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "VALUE";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "START ROW";
            // 
            // lStartRow
            // 
            this.lStartRow.Location = new System.Drawing.Point(89, 29);
            this.lStartRow.Name = "lStartRow";
            this.lStartRow.Size = new System.Drawing.Size(51, 20);
            this.lStartRow.TabIndex = 10;
            this.lStartRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lStartRow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lStartColumn
            // 
            this.lStartColumn.Location = new System.Drawing.Point(253, 27);
            this.lStartColumn.Name = "lStartColumn";
            this.lStartColumn.Size = new System.Drawing.Size(51, 20);
            this.lStartColumn.TabIndex = 12;
            this.lStartColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lStartColumn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "START COLUMN";
            // 
            // qEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 166);
            this.Controls.Add(this.lStartColumn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lStartRow);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbValue);
            this.Controls.Add(this.cbColumn);
            this.Controls.Add(this.cbSheet);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "qEdit";
            this.ShowIcon = false;
            this.Text = "QEDIT";
            this.Activated += new System.EventHandler(this.qEdit_Activated);
            this.Load += new System.EventHandler(this.qEdit_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lStartRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lStartColumn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mFile;
        private System.Windows.Forms.ToolStripMenuItem mOpen;
        private System.Windows.Forms.ToolStripMenuItem mExit;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ComboBox cbSheet;
        private System.Windows.Forms.ComboBox cbColumn;
        private System.Windows.Forms.ComboBox cbValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem mView;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown lStartRow;
        private System.Windows.Forms.NumericUpDown lStartColumn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem mInsert;
        private System.Windows.Forms.ToolStripMenuItem mTop;
        private System.Windows.Forms.ToolStripMenuItem mUp;
        private System.Windows.Forms.ToolStripMenuItem mDown;
        private System.Windows.Forms.ToolStripMenuItem mBottom;
        private System.Windows.Forms.ToolStripMenuItem mSave;
        private System.Windows.Forms.ToolStripMenuItem mSearch;
    }
}

