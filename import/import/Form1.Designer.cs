namespace import
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
            this.txtBackend = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdBackend = new System.Windows.Forms.Button();
            this.cmdSource = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.cbCenter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdImport = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.txtStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBackend
            // 
            this.txtBackend.Location = new System.Drawing.Point(76, 12);
            this.txtBackend.Name = "txtBackend";
            this.txtBackend.Size = new System.Drawing.Size(233, 20);
            this.txtBackend.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "BACKEND";
            // 
            // cmdBackend
            // 
            this.cmdBackend.Location = new System.Drawing.Point(315, 10);
            this.cmdBackend.Name = "cmdBackend";
            this.cmdBackend.Size = new System.Drawing.Size(47, 23);
            this.cmdBackend.TabIndex = 2;
            this.cmdBackend.Text = "...";
            this.cmdBackend.UseVisualStyleBackColor = true;
            this.cmdBackend.Click += new System.EventHandler(this.cmdBackend_Click);
            // 
            // cmdSource
            // 
            this.cmdSource.Location = new System.Drawing.Point(315, 36);
            this.cmdSource.Name = "cmdSource";
            this.cmdSource.Size = new System.Drawing.Size(47, 23);
            this.cmdSource.TabIndex = 5;
            this.cmdSource.Text = "...";
            this.cmdSource.UseVisualStyleBackColor = true;
            this.cmdSource.Click += new System.EventHandler(this.cmdSource_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "SOURCE";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(76, 38);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(233, 20);
            this.txtSource.TabIndex = 3;
            // 
            // cbCenter
            // 
            this.cbCenter.FormattingEnabled = true;
            this.cbCenter.Location = new System.Drawing.Point(76, 64);
            this.cbCenter.Name = "cbCenter";
            this.cbCenter.Size = new System.Drawing.Size(233, 21);
            this.cbCenter.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "CENTER";
            // 
            // cmdImport
            // 
            this.cmdImport.Location = new System.Drawing.Point(234, 91);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(75, 23);
            this.cmdImport.TabIndex = 8;
            this.cmdImport.Text = "IMPORT";
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.AutoSize = true;
            this.txtStatus.Location = new System.Drawing.Point(12, 117);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(35, 13);
            this.txtStatus.TabIndex = 11;
            this.txtStatus.Text = "label5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 137);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.cmdImport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbCenter);
            this.Controls.Add(this.cmdSource);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.cmdBackend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBackend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "IMPORT";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBackend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdBackend;
        private System.Windows.Forms.Button cmdSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.ComboBox cbCenter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdImport;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Label txtStatus;
    }
}

