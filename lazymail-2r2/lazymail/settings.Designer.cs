namespace lazymail
{
	partial class settings
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
            this.txtEmailDB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRootFolder = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.browseEmailDB = new System.Windows.Forms.Button();
            this.purgeEmailDB = new System.Windows.Forms.Button();
            this.browseRootFolder = new System.Windows.Forms.Button();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdTest = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDBDB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDBPwd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDBUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDBHost = new System.Windows.Forms.TextBox();
            this.chkMySQL = new System.Windows.Forms.RadioButton();
            this.chkAccess = new System.Windows.Forms.RadioButton();
            this.browseMainDB = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMainDB = new System.Windows.Forms.TextBox();
            this.txtQHost = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtQPW = new System.Windows.Forms.TextBox();
            this.txtQID = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEmailDB
            // 
            this.txtEmailDB.Location = new System.Drawing.Point(67, 230);
            this.txtEmailDB.Name = "txtEmailDB";
            this.txtEmailDB.Size = new System.Drawing.Size(239, 20);
            this.txtEmailDB.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email DB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Root Folder";
            // 
            // txtRootFolder
            // 
            this.txtRootFolder.Location = new System.Drawing.Point(85, 8);
            this.txtRootFolder.Name = "txtRootFolder";
            this.txtRootFolder.Size = new System.Drawing.Size(239, 20);
            this.txtRootFolder.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(16, 257);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 101);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IMAP Client Log-in";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "PW";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "ID";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(51, 68);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(168, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(51, 42);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(168, 20);
            this.txtID.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Host";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(341, 364);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "&CLOSE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // browseEmailDB
            // 
            this.browseEmailDB.Location = new System.Drawing.Point(312, 228);
            this.browseEmailDB.Name = "browseEmailDB";
            this.browseEmailDB.Size = new System.Drawing.Size(49, 23);
            this.browseEmailDB.TabIndex = 4;
            this.browseEmailDB.Text = "...";
            this.browseEmailDB.UseVisualStyleBackColor = true;
            this.browseEmailDB.Click += new System.EventHandler(this.browseEmailDB_Click);
            // 
            // purgeEmailDB
            // 
            this.purgeEmailDB.Location = new System.Drawing.Point(367, 228);
            this.purgeEmailDB.Name = "purgeEmailDB";
            this.purgeEmailDB.Size = new System.Drawing.Size(49, 23);
            this.purgeEmailDB.TabIndex = 5;
            this.purgeEmailDB.Text = "Purge";
            this.purgeEmailDB.UseVisualStyleBackColor = true;
            this.purgeEmailDB.Click += new System.EventHandler(this.purgeEmailDB_Click);
            // 
            // browseRootFolder
            // 
            this.browseRootFolder.Location = new System.Drawing.Point(330, 8);
            this.browseRootFolder.Name = "browseRootFolder";
            this.browseRootFolder.Size = new System.Drawing.Size(49, 23);
            this.browseRootFolder.TabIndex = 1;
            this.browseRootFolder.Text = "...";
            this.browseRootFolder.UseVisualStyleBackColor = true;
            this.browseRootFolder.Click += new System.EventHandler(this.browseRootFolder_Click);
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(67, 273);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(168, 20);
            this.txtHost.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(249, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "&SAVE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdTest);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtDBDB);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtDBPwd);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtDBUser);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtDBHost);
            this.groupBox2.Controls.Add(this.chkMySQL);
            this.groupBox2.Controls.Add(this.chkAccess);
            this.groupBox2.Controls.Add(this.browseMainDB);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtMainDB);
            this.groupBox2.Location = new System.Drawing.Point(14, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 183);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Backend Data Source";
            // 
            // cmdTest
            // 
            this.cmdTest.Location = new System.Drawing.Point(316, 147);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(49, 23);
            this.cmdTest.TabIndex = 8;
            this.cmdTest.Text = "TEST";
            this.cmdTest.UseVisualStyleBackColor = true;
            this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Database";
            // 
            // txtDBDB
            // 
            this.txtDBDB.Location = new System.Drawing.Point(70, 149);
            this.txtDBDB.Name = "txtDBDB";
            this.txtDBDB.Size = new System.Drawing.Size(239, 20);
            this.txtDBDB.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Password";
            // 
            // txtDBPwd
            // 
            this.txtDBPwd.Location = new System.Drawing.Point(70, 123);
            this.txtDBPwd.Name = "txtDBPwd";
            this.txtDBPwd.Size = new System.Drawing.Size(239, 20);
            this.txtDBPwd.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "User";
            // 
            // txtDBUser
            // 
            this.txtDBUser.Location = new System.Drawing.Point(70, 97);
            this.txtDBUser.Name = "txtDBUser";
            this.txtDBUser.Size = new System.Drawing.Size(239, 20);
            this.txtDBUser.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Host";
            // 
            // txtDBHost
            // 
            this.txtDBHost.Location = new System.Drawing.Point(71, 71);
            this.txtDBHost.Name = "txtDBHost";
            this.txtDBHost.Size = new System.Drawing.Size(239, 20);
            this.txtDBHost.TabIndex = 4;
            // 
            // chkMySQL
            // 
            this.chkMySQL.AutoSize = true;
            this.chkMySQL.Location = new System.Drawing.Point(118, 20);
            this.chkMySQL.Name = "chkMySQL";
            this.chkMySQL.Size = new System.Drawing.Size(60, 17);
            this.chkMySQL.TabIndex = 1;
            this.chkMySQL.TabStop = true;
            this.chkMySQL.Text = "MySQL";
            this.chkMySQL.UseVisualStyleBackColor = true;
            this.chkMySQL.CheckedChanged += new System.EventHandler(this.chkMySQL_CheckedChanged);
            // 
            // chkAccess
            // 
            this.chkAccess.AutoSize = true;
            this.chkAccess.Location = new System.Drawing.Point(11, 20);
            this.chkAccess.Name = "chkAccess";
            this.chkAccess.Size = new System.Drawing.Size(87, 17);
            this.chkAccess.TabIndex = 0;
            this.chkAccess.TabStop = true;
            this.chkAccess.Text = "Access MDB";
            this.chkAccess.UseVisualStyleBackColor = true;
            this.chkAccess.CheckedChanged += new System.EventHandler(this.chkAccess_CheckedChanged);
            // 
            // browseMainDB
            // 
            this.browseMainDB.Location = new System.Drawing.Point(316, 45);
            this.browseMainDB.Name = "browseMainDB";
            this.browseMainDB.Size = new System.Drawing.Size(49, 23);
            this.browseMainDB.TabIndex = 3;
            this.browseMainDB.Text = "...";
            this.browseMainDB.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Main DB";
            // 
            // txtMainDB
            // 
            this.txtMainDB.Location = new System.Drawing.Point(71, 45);
            this.txtMainDB.Name = "txtMainDB";
            this.txtMainDB.Size = new System.Drawing.Size(239, 20);
            this.txtMainDB.TabIndex = 2;
            // 
            // txtQHost
            // 
            this.txtQHost.Location = new System.Drawing.Point(287, 273);
            this.txtQHost.Name = "txtQHost";
            this.txtQHost.Size = new System.Drawing.Size(168, 20);
            this.txtQHost.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtQPW);
            this.groupBox3.Controls.Add(this.txtQID);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Location = new System.Drawing.Point(248, 257);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(215, 101);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MOSTP IMAP Client";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "PW";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "ID";
            // 
            // txtQPW
            // 
            this.txtQPW.Location = new System.Drawing.Point(39, 68);
            this.txtQPW.Name = "txtQPW";
            this.txtQPW.PasswordChar = '*';
            this.txtQPW.Size = new System.Drawing.Size(168, 20);
            this.txtQPW.TabIndex = 1;
            // 
            // txtQID
            // 
            this.txtQID.Location = new System.Drawing.Point(39, 42);
            this.txtQID.Name = "txtQID";
            this.txtQID.Size = new System.Drawing.Size(168, 20);
            this.txtQID.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Host";
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 392);
            this.Controls.Add(this.txtQHost);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.browseRootFolder);
            this.Controls.Add(this.purgeEmailDB);
            this.Controls.Add(this.browseEmailDB);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRootFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmailDB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "settings";
            this.Text = "SETTINGS";
            this.Load += new System.EventHandler(this.settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtEmailDB;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtRootFolder;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button browseEmailDB;
		private System.Windows.Forms.Button purgeEmailDB;
		private System.Windows.Forms.Button browseRootFolder;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtID;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtHost;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.FolderBrowserDialog fbd;
		private System.Windows.Forms.OpenFileDialog ofd;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button browseMainDB;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtMainDB;
		private System.Windows.Forms.RadioButton chkMySQL;
		private System.Windows.Forms.RadioButton chkAccess;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtDBDB;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtDBPwd;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtDBUser;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtDBHost;
		private System.Windows.Forms.Button cmdTest;
        private System.Windows.Forms.TextBox txtQHost;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtQPW;
        private System.Windows.Forms.TextBox txtQID;
        private System.Windows.Forms.Label label13;
	}
}