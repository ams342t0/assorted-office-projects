namespace pixel_test
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cLIPBOARDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pATTERNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dUMPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.th = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.grid = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.th)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 27);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.cLIPBOARDToolStripMenuItem,
            this.pATTERNToolStripMenuItem,
            this.dUMPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(768, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fILEToolStripMenuItem.Text = "FILE";
            this.fILEToolStripMenuItem.Click += new System.EventHandler(this.fILEToolStripMenuItem_Click);
            // 
            // cLIPBOARDToolStripMenuItem
            // 
            this.cLIPBOARDToolStripMenuItem.Name = "cLIPBOARDToolStripMenuItem";
            this.cLIPBOARDToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.cLIPBOARDToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.cLIPBOARDToolStripMenuItem.Text = "CLIPBOARD";
            this.cLIPBOARDToolStripMenuItem.Click += new System.EventHandler(this.cLIPBOARDToolStripMenuItem_Click);
            // 
            // pATTERNToolStripMenuItem
            // 
            this.pATTERNToolStripMenuItem.Name = "pATTERNToolStripMenuItem";
            this.pATTERNToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.pATTERNToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.pATTERNToolStripMenuItem.Text = "PATTERN";
            this.pATTERNToolStripMenuItem.Click += new System.EventHandler(this.pATTERNToolStripMenuItem_Click);
            // 
            // dUMPToolStripMenuItem
            // 
            this.dUMPToolStripMenuItem.Name = "dUMPToolStripMenuItem";
            this.dUMPToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.dUMPToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.dUMPToolStripMenuItem.Text = "DUMP";
            this.dUMPToolStripMenuItem.Click += new System.EventHandler(this.dUMPToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Threshold";
            // 
            // th
            // 
            this.th.Location = new System.Drawing.Point(385, 27);
            this.th.Name = "th";
            this.th.Size = new System.Drawing.Size(97, 20);
            this.th.TabIndex = 6;
            this.th.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // grid
            // 
            this.grid.AutoSize = true;
            this.grid.Location = new System.Drawing.Point(508, 26);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(45, 17);
            this.grid.TabIndex = 7;
            this.grid.Text = "Grid";
            this.grid.UseVisualStyleBackColor = true;
            this.grid.CheckedChanged += new System.EventHandler(this.grid_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 336);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.th);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.th)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pATTERNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dUMPToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown th;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem cLIPBOARDToolStripMenuItem;
        private System.Windows.Forms.CheckBox grid;
    }
}

