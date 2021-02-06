namespace quickOCR
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lOADToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rELOADLASTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOMMANDSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cLIPBOARDPASTEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xCAPTUREToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sNAPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOPYTEXTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOPYIMAGEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPPENDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOPYAPPENDEDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rESETCAMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tEXTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cLEANUPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cLEANCOPYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cLEANDIGITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cLEARCOMPILEDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.camview = new System.Windows.Forms.PictureBox();
            this.txtCompiledText = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.nBrightness = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nContrast = new System.Windows.Forms.NumericUpDown();
            this.richText = new System.Windows.Forms.RichTextBox();
            this.selection = new System.Windows.Forms.PictureBox();
            this.cbCamera = new System.Windows.Forms.ComboBox();
            this.cbRes = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dogrid = new System.Windows.Forms.CheckBox();
            this.cOPYCOMPILEDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.camview)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selection)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.cOMMANDSToolStripMenuItem,
            this.tEXTToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1023, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lOADToolStripMenuItem,
            this.rELOADLASTToolStripMenuItem,
            this.eXITToolStripMenuItem});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fILEToolStripMenuItem.Text = "FILE";
            this.fILEToolStripMenuItem.Click += new System.EventHandler(this.fILEToolStripMenuItem_Click);
            // 
            // lOADToolStripMenuItem
            // 
            this.lOADToolStripMenuItem.Name = "lOADToolStripMenuItem";
            this.lOADToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.lOADToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.lOADToolStripMenuItem.Text = "LOAD IMAGE...";
            this.lOADToolStripMenuItem.Click += new System.EventHandler(this.lOADToolStripMenuItem_Click);
            // 
            // rELOADLASTToolStripMenuItem
            // 
            this.rELOADLASTToolStripMenuItem.Name = "rELOADLASTToolStripMenuItem";
            this.rELOADLASTToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F1)));
            this.rELOADLASTToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.rELOADLASTToolStripMenuItem.Text = "RELOAD LAST";
            this.rELOADLASTToolStripMenuItem.Click += new System.EventHandler(this.rELOADLASTToolStripMenuItem_Click);
            // 
            // eXITToolStripMenuItem
            // 
            this.eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            this.eXITToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.eXITToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.eXITToolStripMenuItem.Text = "EXIT";
            // 
            // cOMMANDSToolStripMenuItem
            // 
            this.cOMMANDSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cLIPBOARDPASTEToolStripMenuItem,
            this.xCAPTUREToolStripMenuItem,
            this.sNAPToolStripMenuItem,
            this.cOPYTEXTToolStripMenuItem,
            this.cOPYIMAGEToolStripMenuItem,
            this.aPPENDToolStripMenuItem,
            this.cOPYAPPENDEDToolStripMenuItem,
            this.rESETCAMToolStripMenuItem});
            this.cOMMANDSToolStripMenuItem.Name = "cOMMANDSToolStripMenuItem";
            this.cOMMANDSToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.cOMMANDSToolStripMenuItem.Text = "COMMANDS";
            // 
            // cLIPBOARDPASTEToolStripMenuItem
            // 
            this.cLIPBOARDPASTEToolStripMenuItem.Name = "cLIPBOARDPASTEToolStripMenuItem";
            this.cLIPBOARDPASTEToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.cLIPBOARDPASTEToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.cLIPBOARDPASTEToolStripMenuItem.Text = "CLIPBOARD PASTE";
            this.cLIPBOARDPASTEToolStripMenuItem.Click += new System.EventHandler(this.cLIPBOARDPASTEToolStripMenuItem_Click);
            // 
            // xCAPTUREToolStripMenuItem
            // 
            this.xCAPTUREToolStripMenuItem.Name = "xCAPTUREToolStripMenuItem";
            this.xCAPTUREToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.xCAPTUREToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.xCAPTUREToolStripMenuItem.Text = "CAPTURE";
            this.xCAPTUREToolStripMenuItem.Click += new System.EventHandler(this.xCAPTUREToolStripMenuItem_Click);
            // 
            // sNAPToolStripMenuItem
            // 
            this.sNAPToolStripMenuItem.Name = "sNAPToolStripMenuItem";
            this.sNAPToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.sNAPToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.sNAPToolStripMenuItem.Text = "SNAP";
            this.sNAPToolStripMenuItem.Click += new System.EventHandler(this.sNAPToolStripMenuItem_Click);
            // 
            // cOPYTEXTToolStripMenuItem
            // 
            this.cOPYTEXTToolStripMenuItem.Name = "cOPYTEXTToolStripMenuItem";
            this.cOPYTEXTToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.cOPYTEXTToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.cOPYTEXTToolStripMenuItem.Text = "COPY TEXT";
            this.cOPYTEXTToolStripMenuItem.Click += new System.EventHandler(this.cOPYTEXTToolStripMenuItem_Click);
            // 
            // cOPYIMAGEToolStripMenuItem
            // 
            this.cOPYIMAGEToolStripMenuItem.Name = "cOPYIMAGEToolStripMenuItem";
            this.cOPYIMAGEToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.cOPYIMAGEToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.cOPYIMAGEToolStripMenuItem.Text = "COPY IMAGE";
            this.cOPYIMAGEToolStripMenuItem.Click += new System.EventHandler(this.cOPYIMAGEToolStripMenuItem_Click);
            // 
            // aPPENDToolStripMenuItem
            // 
            this.aPPENDToolStripMenuItem.Name = "aPPENDToolStripMenuItem";
            this.aPPENDToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.aPPENDToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.aPPENDToolStripMenuItem.Text = "APPEND";
            this.aPPENDToolStripMenuItem.Click += new System.EventHandler(this.aPPENDToolStripMenuItem_Click);
            // 
            // cOPYAPPENDEDToolStripMenuItem
            // 
            this.cOPYAPPENDEDToolStripMenuItem.Name = "cOPYAPPENDEDToolStripMenuItem";
            this.cOPYAPPENDEDToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.cOPYAPPENDEDToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.cOPYAPPENDEDToolStripMenuItem.Text = "COPY APPENDED";
            this.cOPYAPPENDEDToolStripMenuItem.Click += new System.EventHandler(this.cOPYAPPENDEDToolStripMenuItem_Click);
            // 
            // rESETCAMToolStripMenuItem
            // 
            this.rESETCAMToolStripMenuItem.Name = "rESETCAMToolStripMenuItem";
            this.rESETCAMToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.rESETCAMToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.rESETCAMToolStripMenuItem.Text = "RESETCAM";
            this.rESETCAMToolStripMenuItem.Click += new System.EventHandler(this.rESETCAMToolStripMenuItem_Click);
            // 
            // tEXTToolStripMenuItem
            // 
            this.tEXTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cLEANUPToolStripMenuItem,
            this.cLEANCOPYToolStripMenuItem,
            this.cLEANDIGITToolStripMenuItem,
            this.cLEARCOMPILEDToolStripMenuItem,
            this.cOPYCOMPILEDToolStripMenuItem});
            this.tEXTToolStripMenuItem.Name = "tEXTToolStripMenuItem";
            this.tEXTToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.tEXTToolStripMenuItem.Text = "TEXT";
            // 
            // cLEANUPToolStripMenuItem
            // 
            this.cLEANUPToolStripMenuItem.Name = "cLEANUPToolStripMenuItem";
            this.cLEANUPToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.cLEANUPToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.cLEANUPToolStripMenuItem.Text = "CLEAN UP";
            this.cLEANUPToolStripMenuItem.Click += new System.EventHandler(this.cLEANUPToolStripMenuItem_Click);
            // 
            // cLEANCOPYToolStripMenuItem
            // 
            this.cLEANCOPYToolStripMenuItem.Name = "cLEANCOPYToolStripMenuItem";
            this.cLEANCOPYToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                        | System.Windows.Forms.Keys.C)));
            this.cLEANCOPYToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.cLEANCOPYToolStripMenuItem.Text = "COPY CLEAN";
            this.cLEANCOPYToolStripMenuItem.Click += new System.EventHandler(this.cLEANCOPYToolStripMenuItem_Click);
            // 
            // cLEANDIGITToolStripMenuItem
            // 
            this.cLEANDIGITToolStripMenuItem.Name = "cLEANDIGITToolStripMenuItem";
            this.cLEANDIGITToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.C)));
            this.cLEANDIGITToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.cLEANDIGITToolStripMenuItem.Text = "CLEAN DIGIT";
            this.cLEANDIGITToolStripMenuItem.Click += new System.EventHandler(this.cLEANDIGITToolStripMenuItem_Click);
            // 
            // cLEARCOMPILEDToolStripMenuItem
            // 
            this.cLEARCOMPILEDToolStripMenuItem.Name = "cLEARCOMPILEDToolStripMenuItem";
            this.cLEARCOMPILEDToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.X)));
            this.cLEARCOMPILEDToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.cLEARCOMPILEDToolStripMenuItem.Text = "CLEAR COMPILED";
            this.cLEARCOMPILEDToolStripMenuItem.Click += new System.EventHandler(this.cLEARCOMPILEDToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.camview);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtCompiledText);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.richText);
            this.splitContainer1.Panel2.Controls.Add(this.selection);
            this.splitContainer1.Size = new System.Drawing.Size(1023, 490);
            this.splitContainer1.SplitterDistance = 561;
            this.splitContainer1.TabIndex = 14;
            // 
            // camview
            // 
            this.camview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.camview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.camview.Location = new System.Drawing.Point(3, 3);
            this.camview.Name = "camview";
            this.camview.Size = new System.Drawing.Size(555, 490);
            this.camview.TabIndex = 1;
            this.camview.TabStop = false;
            this.camview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.camview_MouseDown);
            this.camview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.camview_MouseMove);
            this.camview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.camview_MouseUp);
            this.camview.Resize += new System.EventHandler(this.camview_Resize);
            // 
            // txtCompiledText
            // 
            this.txtCompiledText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompiledText.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompiledText.Location = new System.Drawing.Point(3, 359);
            this.txtCompiledText.Name = "txtCompiledText";
            this.txtCompiledText.Size = new System.Drawing.Size(452, 132);
            this.txtCompiledText.TabIndex = 15;
            this.txtCompiledText.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.nBrightness);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nContrast);
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 86);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adjust";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(157, 57);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(137, 17);
            this.radioButton3.TabIndex = 11;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "EXTRA HI-CONTRAST";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(157, 34);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(98, 17);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "HI-CONTRAST";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(157, 11);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 17);
            this.radioButton1.TabIndex = 9;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "NORMAL";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // nBrightness
            // 
            this.nBrightness.Location = new System.Drawing.Point(70, 19);
            this.nBrightness.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nBrightness.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.nBrightness.Name = "nBrightness";
            this.nBrightness.Size = new System.Drawing.Size(63, 20);
            this.nBrightness.TabIndex = 5;
            this.nBrightness.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nBrightness.ValueChanged += new System.EventHandler(this.nBrightness_ValueChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Contrast";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Brightness";
            // 
            // nContrast
            // 
            this.nContrast.Location = new System.Drawing.Point(70, 45);
            this.nContrast.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nContrast.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.nContrast.Name = "nContrast";
            this.nContrast.Size = new System.Drawing.Size(63, 20);
            this.nContrast.TabIndex = 7;
            this.nContrast.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // richText
            // 
            this.richText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richText.Location = new System.Drawing.Point(3, 213);
            this.richText.Name = "richText";
            this.richText.Size = new System.Drawing.Size(452, 140);
            this.richText.TabIndex = 13;
            this.richText.Text = "";
            // 
            // selection
            // 
            this.selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.selection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.selection.Location = new System.Drawing.Point(3, 93);
            this.selection.Name = "selection";
            this.selection.Size = new System.Drawing.Size(452, 114);
            this.selection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.selection.TabIndex = 12;
            this.selection.TabStop = false;
            // 
            // cbCamera
            // 
            this.cbCamera.FormattingEnabled = true;
            this.cbCamera.Location = new System.Drawing.Point(235, 0);
            this.cbCamera.Name = "cbCamera";
            this.cbCamera.Size = new System.Drawing.Size(217, 21);
            this.cbCamera.TabIndex = 15;
            this.cbCamera.SelectedIndexChanged += new System.EventHandler(this.cbCamera_SelectedIndexChanged);
            // 
            // cbRes
            // 
            this.cbRes.FormattingEnabled = true;
            this.cbRes.Location = new System.Drawing.Point(470, 0);
            this.cbRes.Name = "cbRes";
            this.cbRes.Size = new System.Drawing.Size(179, 21);
            this.cbRes.TabIndex = 16;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(692, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(94, 17);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "DIGITS ONLY";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // dogrid
            // 
            this.dogrid.AutoSize = true;
            this.dogrid.Location = new System.Drawing.Point(821, 4);
            this.dogrid.Name = "dogrid";
            this.dogrid.Size = new System.Drawing.Size(72, 17);
            this.dogrid.TabIndex = 18;
            this.dogrid.Text = "DO GRID";
            this.dogrid.UseVisualStyleBackColor = true;
            // 
            // cOPYCOMPILEDToolStripMenuItem
            // 
            this.cOPYCOMPILEDToolStripMenuItem.Name = "cOPYCOMPILEDToolStripMenuItem";
            this.cOPYCOMPILEDToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.cOPYCOMPILEDToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.cOPYCOMPILEDToolStripMenuItem.Text = "COPY COMPILED";
            this.cOPYCOMPILEDToolStripMenuItem.Click += new System.EventHandler(this.cOPYCOMPILEDToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 517);
            this.Controls.Add(this.dogrid);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cbRes);
            this.Controls.Add(this.cbCamera);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "QOCR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.camview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lOADToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOMMANDSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xCAPTUREToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sNAPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOPYTEXTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOPYIMAGEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPPENDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXITToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox camview;
        private System.Windows.Forms.RichTextBox txtCompiledText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.NumericUpDown nBrightness;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nContrast;
        private System.Windows.Forms.RichTextBox richText;
        private System.Windows.Forms.PictureBox selection;
        private System.Windows.Forms.ToolStripMenuItem tEXTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cLEANUPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOPYAPPENDEDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cLEANCOPYToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbCamera;
        private System.Windows.Forms.ComboBox cbRes;
        private System.Windows.Forms.ToolStripMenuItem rESETCAMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cLIPBOARDPASTEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rELOADLASTToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripMenuItem cLEANDIGITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cLEARCOMPILEDToolStripMenuItem;
        private System.Windows.Forms.CheckBox dogrid;
        private System.Windows.Forms.ToolStripMenuItem cOPYCOMPILEDToolStripMenuItem;
    }
}

