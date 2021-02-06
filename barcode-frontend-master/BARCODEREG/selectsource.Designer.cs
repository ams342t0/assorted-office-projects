namespace BARCODEREG
{
	partial class selectsource
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdTest = new System.Windows.Forms.Button();
            this.txtDB = new System.Windows.Forms.TextBox();
            this.txtPWD = new System.Windows.Forms.TextBox();
            this.txtUID = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.txtDBFile = new System.Windows.Forms.TextBox();
            this.opMSQL = new System.Windows.Forms.RadioButton();
            this.opAccess = new System.Windows.Forms.RadioButton();
            this.cmdSave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbDriver = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDriver);
            this.groupBox1.Controls.Add(this.cmdTest);
            this.groupBox1.Controls.Add(this.txtDB);
            this.groupBox1.Controls.Add(this.txtPWD);
            this.groupBox1.Controls.Add(this.txtUID);
            this.groupBox1.Controls.Add(this.txtHost);
            this.groupBox1.Controls.Add(this.cmdOpen);
            this.groupBox1.Controls.Add(this.txtDBFile);
            this.groupBox1.Controls.Add(this.opMSQL);
            this.groupBox1.Controls.Add(this.opAccess);
            this.groupBox1.Location = new System.Drawing.Point(7, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 196);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmdTest
            // 
            this.cmdTest.Location = new System.Drawing.Point(301, 167);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(54, 23);
            this.cmdTest.TabIndex = 8;
            this.cmdTest.Text = "TEST";
            this.cmdTest.UseVisualStyleBackColor = true;
            this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
            // 
            // txtDB
            // 
            this.txtDB.Location = new System.Drawing.Point(19, 170);
            this.txtDB.Name = "txtDB";
            this.txtDB.Size = new System.Drawing.Size(276, 20);
            this.txtDB.TabIndex = 7;
            // 
            // txtPWD
            // 
            this.txtPWD.Location = new System.Drawing.Point(19, 119);
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.Size = new System.Drawing.Size(276, 20);
            this.txtPWD.TabIndex = 6;
            // 
            // txtUID
            // 
            this.txtUID.Location = new System.Drawing.Point(19, 93);
            this.txtUID.Name = "txtUID";
            this.txtUID.Size = new System.Drawing.Size(276, 20);
            this.txtUID.TabIndex = 5;
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(19, 67);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(276, 20);
            this.txtHost.TabIndex = 4;
            // 
            // cmdOpen
            // 
            this.cmdOpen.Location = new System.Drawing.Point(301, 41);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(54, 23);
            this.cmdOpen.TabIndex = 3;
            this.cmdOpen.Text = "OPEN";
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // txtDBFile
            // 
            this.txtDBFile.Location = new System.Drawing.Point(19, 41);
            this.txtDBFile.Name = "txtDBFile";
            this.txtDBFile.Size = new System.Drawing.Size(276, 20);
            this.txtDBFile.TabIndex = 2;
            // 
            // opMSQL
            // 
            this.opMSQL.AutoSize = true;
            this.opMSQL.Location = new System.Drawing.Point(128, 18);
            this.opMSQL.Name = "opMSQL";
            this.opMSQL.Size = new System.Drawing.Size(60, 17);
            this.opMSQL.TabIndex = 1;
            this.opMSQL.TabStop = true;
            this.opMSQL.Text = "MySQL";
            this.opMSQL.UseVisualStyleBackColor = true;
            this.opMSQL.Click += new System.EventHandler(this.opMSQL_Click);
            // 
            // opAccess
            // 
            this.opAccess.AutoSize = true;
            this.opAccess.Location = new System.Drawing.Point(19, 18);
            this.opAccess.Name = "opAccess";
            this.opAccess.Size = new System.Drawing.Size(79, 17);
            this.opAccess.TabIndex = 0;
            this.opAccess.TabStop = true;
            this.opAccess.Text = "Access File";
            this.opAccess.UseVisualStyleBackColor = true;
            this.opAccess.Click += new System.EventHandler(this.opAccess_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(320, 207);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(54, 23);
            this.cmdSave.TabIndex = 9;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cbDriver
            // 
            this.cbDriver.FormattingEnabled = true;
            this.cbDriver.Location = new System.Drawing.Point(19, 143);
            this.cbDriver.Name = "cbDriver";
            this.cbDriver.Size = new System.Drawing.Size(276, 21);
            this.cbDriver.TabIndex = 9;
            // 
            // selectsource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 234);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "selectsource";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DATA SOURCE";
            this.Load += new System.EventHandler(this.selectsource_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button cmdTest;
		private System.Windows.Forms.TextBox txtDB;
		private System.Windows.Forms.TextBox txtPWD;
		private System.Windows.Forms.TextBox txtUID;
		private System.Windows.Forms.TextBox txtHost;
		private System.Windows.Forms.Button cmdOpen;
		private System.Windows.Forms.TextBox txtDBFile;
		private System.Windows.Forms.RadioButton opMSQL;
		private System.Windows.Forms.RadioButton opAccess;
		private System.Windows.Forms.Button cmdSave;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cbDriver;
	}
}