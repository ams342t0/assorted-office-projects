namespace ads
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listpictures = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuaddfiles = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStartStop = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.owidth = new System.Windows.Forms.NumericUpDown();
            this.oheight = new System.Windows.Forms.NumericUpDown();
            this.offsetX = new System.Windows.Forms.NumericUpDown();
            this.offsetY = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.owidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oheight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetY)).BeginInit();
            this.SuspendLayout();
            // 
            // listpictures
            // 
            this.listpictures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listpictures.FormattingEnabled = true;
            this.listpictures.Location = new System.Drawing.Point(12, 38);
            this.listpictures.Name = "listpictures";
            this.listpictures.ScrollAlwaysVisible = true;
            this.listpictures.Size = new System.Drawing.Size(395, 225);
            this.listpictures.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuaddfiles,
            this.mnuStartStop});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(419, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "ops";
            // 
            // mnuaddfiles
            // 
            this.mnuaddfiles.Name = "mnuaddfiles";
            this.mnuaddfiles.Size = new System.Drawing.Size(128, 21);
            this.mnuaddfiles.Text = "Add Pictures";
            this.mnuaddfiles.Click += new System.EventHandler(this.mnuaddfiles_Click);
            // 
            // mnuStartStop
            // 
            this.mnuStartStop.Name = "mnuStartStop";
            this.mnuStartStop.Size = new System.Drawing.Size(65, 21);
            this.mnuStartStop.Text = "Start";
            this.mnuStartStop.Click += new System.EventHandler(this.mnuStartStop_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(285, 269);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(12, 269);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown1.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // owidth
            // 
            this.owidth.Location = new System.Drawing.Point(12, 295);
            this.owidth.Name = "owidth";
            this.owidth.Size = new System.Drawing.Size(83, 20);
            this.owidth.TabIndex = 4;
            // 
            // oheight
            // 
            this.oheight.Location = new System.Drawing.Point(12, 321);
            this.oheight.Name = "oheight";
            this.oheight.Size = new System.Drawing.Size(83, 20);
            this.oheight.TabIndex = 5;
            // 
            // offsetX
            // 
            this.offsetX.Location = new System.Drawing.Point(113, 269);
            this.offsetX.Name = "offsetX";
            this.offsetX.Size = new System.Drawing.Size(83, 20);
            this.offsetX.TabIndex = 6;
            // 
            // offsetY
            // 
            this.offsetY.Location = new System.Drawing.Point(113, 295);
            this.offsetY.Name = "offsetY";
            this.offsetY.Size = new System.Drawing.Size(83, 20);
            this.offsetY.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 362);
            this.Controls.Add(this.offsetY);
            this.Controls.Add(this.offsetX);
            this.Controls.Add(this.oheight);
            this.Controls.Add(this.owidth);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listpictures);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.owidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oheight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listpictures;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuaddfiles;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ToolStripMenuItem mnuStartStop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown owidth;
        private System.Windows.Forms.NumericUpDown oheight;
        public System.Windows.Forms.NumericUpDown offsetX;
        public System.Windows.Forms.NumericUpDown offsetY;
    }
}

