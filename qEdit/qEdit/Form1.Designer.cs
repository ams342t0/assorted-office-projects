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
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sOURCEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sAVEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fOCUSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sEARCHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iNSERTToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.uPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dOWNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fIRSTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bOTTOMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.fILEToolStripMenuItem,
            this.sEARCHToolStripMenuItem,
            this.iNSERTToolStripMenuItem1,
            this.uPToolStripMenuItem,
            this.dOWNToolStripMenuItem,
            this.fIRSTToolStripMenuItem,
            this.bOTTOMToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(446, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sOURCEToolStripMenuItem,
            this.sAVEToolStripMenuItem,
            this.fOCUSToolStripMenuItem,
            this.eXITToolStripMenuItem});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fILEToolStripMenuItem.Text = "FILE";
            // 
            // sOURCEToolStripMenuItem
            // 
            this.sOURCEToolStripMenuItem.Name = "sOURCEToolStripMenuItem";
            this.sOURCEToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.sOURCEToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.sOURCEToolStripMenuItem.Text = "OPEN SOURCE...";
            this.sOURCEToolStripMenuItem.Click += new System.EventHandler(this.sOURCEToolStripMenuItem_Click);
            // 
            // sAVEToolStripMenuItem
            // 
            this.sAVEToolStripMenuItem.Name = "sAVEToolStripMenuItem";
            this.sAVEToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.sAVEToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.sAVEToolStripMenuItem.Text = "SAVE";
            this.sAVEToolStripMenuItem.Click += new System.EventHandler(this.sAVEToolStripMenuItem_Click);
            // 
            // fOCUSToolStripMenuItem
            // 
            this.fOCUSToolStripMenuItem.Name = "fOCUSToolStripMenuItem";
            this.fOCUSToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.fOCUSToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.fOCUSToolStripMenuItem.Text = "VIEW SOURCE";
            this.fOCUSToolStripMenuItem.Click += new System.EventHandler(this.fOCUSToolStripMenuItem_Click);
            // 
            // eXITToolStripMenuItem
            // 
            this.eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            this.eXITToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.eXITToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.eXITToolStripMenuItem.Text = "EXIT";
            this.eXITToolStripMenuItem.Click += new System.EventHandler(this.eXITToolStripMenuItem_Click);
            // 
            // sEARCHToolStripMenuItem
            // 
            this.sEARCHToolStripMenuItem.Name = "sEARCHToolStripMenuItem";
            this.sEARCHToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.sEARCHToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.sEARCHToolStripMenuItem.Text = "&SEARCH";
            this.sEARCHToolStripMenuItem.Click += new System.EventHandler(this.sEARCHToolStripMenuItem_Click);
            // 
            // iNSERTToolStripMenuItem1
            // 
            this.iNSERTToolStripMenuItem1.Name = "iNSERTToolStripMenuItem1";
            this.iNSERTToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.iNSERTToolStripMenuItem1.Size = new System.Drawing.Size(57, 20);
            this.iNSERTToolStripMenuItem1.Text = "&INSERT";
            this.iNSERTToolStripMenuItem1.Click += new System.EventHandler(this.iNSERTToolStripMenuItem1_Click);
            // 
            // uPToolStripMenuItem
            // 
            this.uPToolStripMenuItem.Name = "uPToolStripMenuItem";
            this.uPToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.U)));
            this.uPToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this.uPToolStripMenuItem.Text = "&UP";
            this.uPToolStripMenuItem.Click += new System.EventHandler(this.uPToolStripMenuItem_Click);
            // 
            // dOWNToolStripMenuItem
            // 
            this.dOWNToolStripMenuItem.Name = "dOWNToolStripMenuItem";
            this.dOWNToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.dOWNToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.dOWNToolStripMenuItem.Text = "&DOWN";
            this.dOWNToolStripMenuItem.Click += new System.EventHandler(this.dOWNToolStripMenuItem_Click);
            // 
            // fIRSTToolStripMenuItem
            // 
            this.fIRSTToolStripMenuItem.Name = "fIRSTToolStripMenuItem";
            this.fIRSTToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.fIRSTToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.fIRSTToolStripMenuItem.Text = "&TOP";
            this.fIRSTToolStripMenuItem.Click += new System.EventHandler(this.fIRSTToolStripMenuItem_Click);
            // 
            // bOTTOMToolStripMenuItem
            // 
            this.bOTTOMToolStripMenuItem.Name = "bOTTOMToolStripMenuItem";
            this.bOTTOMToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.B)));
            this.bOTTOMToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.bOTTOMToolStripMenuItem.Text = "&BOTTOM";
            this.bOTTOMToolStripMenuItem.Click += new System.EventHandler(this.bOTTOMToolStripMenuItem_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.status.Location = new System.Drawing.Point(0, 144);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(446, 22);
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
            this.cbSheet.Size = new System.Drawing.Size(345, 26);
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
            this.cbColumn.Size = new System.Drawing.Size(345, 26);
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
            this.cbValue.Size = new System.Drawing.Size(345, 26);
            this.cbValue.TabIndex = 4;
            this.cbValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbValue_KeyDown);
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
            this.ClientSize = new System.Drawing.Size(446, 166);
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
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sOURCEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXITToolStripMenuItem;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ComboBox cbSheet;
        private System.Windows.Forms.ComboBox cbColumn;
        private System.Windows.Forms.ComboBox cbValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem fOCUSToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown lStartRow;
        private System.Windows.Forms.NumericUpDown lStartColumn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem iNSERTToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fIRSTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dOWNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bOTTOMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sAVEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sEARCHToolStripMenuItem;
    }
}

