namespace lazymail
{
    partial class d_send
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
			this.txtTo = new System.Windows.Forms.TextBox();
			this.txtSubject = new System.Windows.Forms.TextBox();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.mESSAGESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.eRFGUIDELINEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cHANGEVENUEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sHIRTSIZESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nOREPLYFORMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sENDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.eXITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pbar = new System.Windows.Forms.ProgressBar();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtTo
			// 
			this.txtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTo.Location = new System.Drawing.Point(0, 27);
			this.txtTo.Name = "txtTo";
			this.txtTo.Size = new System.Drawing.Size(382, 22);
			this.txtTo.TabIndex = 0;
			// 
			// txtSubject
			// 
			this.txtSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSubject.Location = new System.Drawing.Point(0, 53);
			this.txtSubject.Name = "txtSubject";
			this.txtSubject.Size = new System.Drawing.Size(382, 22);
			this.txtSubject.TabIndex = 2;
			// 
			// txtMessage
			// 
			this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMessage.Location = new System.Drawing.Point(0, 79);
			this.txtMessage.Multiline = true;
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtMessage.Size = new System.Drawing.Size(382, 265);
			this.txtMessage.TabIndex = 4;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mESSAGESToolStripMenuItem,
            this.sENDToolStripMenuItem,
            this.eXITToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(383, 25);
			this.menuStrip1.TabIndex = 6;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// mESSAGESToolStripMenuItem
			// 
			this.mESSAGESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eRFGUIDELINEToolStripMenuItem,
            this.cHANGEVENUEToolStripMenuItem,
            this.nOREPLYFORMToolStripMenuItem,
            this.sHIRTSIZESToolStripMenuItem});
			this.mESSAGESToolStripMenuItem.Name = "mESSAGESToolStripMenuItem";
			this.mESSAGESToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
			this.mESSAGESToolStripMenuItem.Text = "MESSAGES";
			// 
			// eRFGUIDELINEToolStripMenuItem
			// 
			this.eRFGUIDELINEToolStripMenuItem.Name = "eRFGUIDELINEToolStripMenuItem";
			this.eRFGUIDELINEToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
			this.eRFGUIDELINEToolStripMenuItem.Text = "ERF GUIDELINE";
			this.eRFGUIDELINEToolStripMenuItem.Click += new System.EventHandler(this.eRFGUIDELINEToolStripMenuItem_Click);
			// 
			// cHANGEVENUEToolStripMenuItem
			// 
			this.cHANGEVENUEToolStripMenuItem.Name = "cHANGEVENUEToolStripMenuItem";
			this.cHANGEVENUEToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
			this.cHANGEVENUEToolStripMenuItem.Text = "CHANGE VENUE";
			this.cHANGEVENUEToolStripMenuItem.Click += new System.EventHandler(this.cHANGEVENUEToolStripMenuItem_Click);
			// 
			// sHIRTSIZESToolStripMenuItem
			// 
			this.sHIRTSIZESToolStripMenuItem.Name = "sHIRTSIZESToolStripMenuItem";
			this.sHIRTSIZESToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
			this.sHIRTSIZESToolStripMenuItem.Text = "SHIRT SIZES";
			// 
			// nOREPLYFORMToolStripMenuItem
			// 
			this.nOREPLYFORMToolStripMenuItem.Name = "nOREPLYFORMToolStripMenuItem";
			this.nOREPLYFORMToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
			this.nOREPLYFORMToolStripMenuItem.Text = "NO REPLY FORM";
			this.nOREPLYFORMToolStripMenuItem.Click += new System.EventHandler(this.nOREPLYFORMToolStripMenuItem_Click);
			// 
			// sENDToolStripMenuItem
			// 
			this.sENDToolStripMenuItem.Name = "sENDToolStripMenuItem";
			this.sENDToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
			this.sENDToolStripMenuItem.Text = "&SEND";
			this.sENDToolStripMenuItem.Click += new System.EventHandler(this.sENDToolStripMenuItem_Click);
			// 
			// eXITToolStripMenuItem
			// 
			this.eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
			this.eXITToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
			this.eXITToolStripMenuItem.Text = "E&XIT";
			this.eXITToolStripMenuItem.Click += new System.EventHandler(this.eXITToolStripMenuItem_Click);
			// 
			// pbar
			// 
			this.pbar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pbar.Location = new System.Drawing.Point(0, 346);
			this.pbar.Name = "pbar";
			this.pbar.Size = new System.Drawing.Size(382, 23);
			this.pbar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.pbar.TabIndex = 7;
			// 
			// d_send
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(383, 369);
			this.Controls.Add(this.pbar);
			this.Controls.Add(this.txtMessage);
			this.Controls.Add(this.txtSubject);
			this.Controls.Add(this.txtTo);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "d_send";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "DIRECT MAILER";
			this.Load += new System.EventHandler(this.d_send_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		public System.Windows.Forms.TextBox txtTo;
        public System.Windows.Forms.TextBox txtSubject;
        public System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem mESSAGESToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem eRFGUIDELINEToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cHANGEVENUEToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sHIRTSIZESToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nOREPLYFORMToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sENDToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem eXITToolStripMenuItem;
		private System.Windows.Forms.ProgressBar pbar;
    }
}