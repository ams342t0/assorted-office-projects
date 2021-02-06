namespace BARCODEREG
{
	partial class barcodereg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(barcodereg));
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.Label();
            this.txtRoom = new System.Windows.Forms.Label();
            this.txtCenter = new System.Windows.Forms.Label();
            this.txtSchool = new System.Windows.Forms.Label();
            this.txtLevel = new System.Windows.Forms.Label();
            this.txtSex = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.Label();
            this.txtSchedule = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtShirt = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.BackColor = System.Drawing.Color.White;
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCode.Font = new System.Drawing.Font("Arial Black", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.ForeColor = System.Drawing.Color.Black;
            this.txtCode.Location = new System.Drawing.Point(142, 18);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(410, 53);
            this.txtCode.TabIndex = 2;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            this.txtCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyUp);
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.BackColor = System.Drawing.Color.Lime;
            this.txtStatus.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.ForeColor = System.Drawing.Color.White;
            this.txtStatus.Location = new System.Drawing.Point(142, 73);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(410, 64);
            this.txtStatus.TabIndex = 16;
            this.txtStatus.Text = "Student not found!";
            this.txtStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtStatus.Click += new System.EventHandler(this.txtStatus_Click);
            // 
            // txtRoom
            // 
            this.txtRoom.Font = new System.Drawing.Font("Impact", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtRoom.Location = new System.Drawing.Point(205, 582);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(817, 81);
            this.txtRoom.TabIndex = 15;
            this.txtRoom.Text = "ROOM:";
            this.txtRoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCenter
            // 
            this.txtCenter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCenter.Font = new System.Drawing.Font("Impact", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCenter.ForeColor = System.Drawing.Color.Yellow;
            this.txtCenter.Location = new System.Drawing.Point(206, 423);
            this.txtCenter.Name = "txtCenter";
            this.txtCenter.Size = new System.Drawing.Size(1156, 81);
            this.txtCenter.TabIndex = 14;
            this.txtCenter.Text = "CENTER:";
            this.txtCenter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSchool
            // 
            this.txtSchool.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSchool.Font = new System.Drawing.Font("Impact", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSchool.ForeColor = System.Drawing.Color.Yellow;
            this.txtSchool.Location = new System.Drawing.Point(206, 342);
            this.txtSchool.Name = "txtSchool";
            this.txtSchool.Size = new System.Drawing.Size(1156, 81);
            this.txtSchool.TabIndex = 13;
            this.txtSchool.Text = "SCHOOL:";
            this.txtSchool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLevel
            // 
            this.txtLevel.Font = new System.Drawing.Font("Impact", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLevel.ForeColor = System.Drawing.Color.Yellow;
            this.txtLevel.Location = new System.Drawing.Point(592, 245);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(369, 81);
            this.txtLevel.TabIndex = 12;
            this.txtLevel.Text = "GR./YR.:";
            this.txtLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSex
            // 
            this.txtSex.Font = new System.Drawing.Font("Impact", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSex.ForeColor = System.Drawing.Color.Yellow;
            this.txtSex.Location = new System.Drawing.Point(205, 245);
            this.txtSex.Name = "txtSex";
            this.txtSex.Size = new System.Drawing.Size(223, 81);
            this.txtSex.TabIndex = 11;
            this.txtSex.Text = "SEX:";
            this.txtSex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Font = new System.Drawing.Font("Impact", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.Yellow;
            this.txtName.Location = new System.Drawing.Point(203, 164);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(1182, 81);
            this.txtName.TabIndex = 10;
            this.txtName.Text = "NAME:";
            this.txtName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSchedule
            // 
            this.txtSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSchedule.Font = new System.Drawing.Font("Impact", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSchedule.ForeColor = System.Drawing.Color.Yellow;
            this.txtSchedule.Location = new System.Drawing.Point(206, 504);
            this.txtSchedule.Name = "txtSchedule";
            this.txtSchedule.Size = new System.Drawing.Size(1154, 81);
            this.txtSchedule.TabIndex = 17;
            this.txtSchedule.Text = "ROOM:";
            this.txtSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Impact", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.ForeColor = System.Drawing.Color.Yellow;
            this.txtID.Location = new System.Drawing.Point(1174, 245);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(285, 81);
            this.txtID.TabIndex = 18;
            this.txtID.Text = "GR./YR.:";
            this.txtID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Impact", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(23, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 81);
            this.label2.TabIndex = 19;
            this.label2.Text = "Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Impact", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(72, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 81);
            this.label3.TabIndex = 20;
            this.label3.Text = "Sex:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Impact", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(410, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 81);
            this.label4.TabIndex = 21;
            this.label4.Text = "Gr./Yr.:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Impact", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(1028, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 81);
            this.label5.TabIndex = 22;
            this.label5.Text = "Code:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Impact", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(0, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 81);
            this.label6.TabIndex = 23;
            this.label6.Text = "School:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Impact", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(0, 423);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 81);
            this.label7.TabIndex = 24;
            this.label7.Text = "Center:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Impact", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Silver;
            this.label8.Location = new System.Drawing.Point(24, 504);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(176, 81);
            this.label8.TabIndex = 25;
            this.label8.Text = "Batch:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Impact", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Silver;
            this.label9.Location = new System.Drawing.Point(24, 582);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 81);
            this.label9.TabIndex = 26;
            this.label9.Text = "Room:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Impact", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Silver;
            this.label10.Location = new System.Drawing.Point(1011, 582);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(212, 81);
            this.label10.TabIndex = 28;
            this.label10.Text = "T-Shirt:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShirt
            // 
            this.txtShirt.Font = new System.Drawing.Font("Impact", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShirt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtShirt.Location = new System.Drawing.Point(1215, 582);
            this.txtShirt.Name = "txtShirt";
            this.txtShirt.Size = new System.Drawing.Size(186, 81);
            this.txtShirt.TabIndex = 27;
            this.txtShirt.Text = "ROOM:";
            this.txtShirt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BARCODEREG.Properties.Resources.MTG;
            this.pictureBox1.Location = new System.Drawing.Point(12, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // barcodereg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1362, 735);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtShirt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtSchedule);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtRoom);
            this.Controls.Add(this.txtCenter);
            this.Controls.Add(this.txtSchool);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.txtSex);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "barcodereg";
            this.Text = "REGISTRATION";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.barcodereg_Load);
            this.Shown += new System.EventHandler(this.barcodereg_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.TextBox txtCode;
		private System.Windows.Forms.Label txtStatus;
		private System.Windows.Forms.Label txtRoom;
		private System.Windows.Forms.Label txtCenter;
		private System.Windows.Forms.Label txtSchool;
		private System.Windows.Forms.Label txtLevel;
		private System.Windows.Forms.Label txtSex;
		private System.Windows.Forms.Label txtName;
		private System.Windows.Forms.Label txtSchedule;
		private System.Windows.Forms.Label txtID;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label txtShirt;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}

