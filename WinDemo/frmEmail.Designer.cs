namespace WinDemo
{
    partial class frmEmail
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSmtpServer = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSMTPUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFromName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtToAddress = new System.Windows.Forms.TextBox();
            this.txtMailBody = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSMTPPwd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtReplyTo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SMTPserver";
            // 
            // txtSmtpServer
            // 
            this.txtSmtpServer.Location = new System.Drawing.Point(107, 16);
            this.txtSmtpServer.Name = "txtSmtpServer";
            this.txtSmtpServer.Size = new System.Drawing.Size(100, 20);
            this.txtSmtpServer.TabIndex = 1;
            this.txtSmtpServer.Text = "ext-mta";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(541, 331);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "SMTPUser";
            // 
            // txtSMTPUser
            // 
            this.txtSMTPUser.Location = new System.Drawing.Point(316, 16);
            this.txtSMTPUser.Name = "txtSMTPUser";
            this.txtSMTPUser.Size = new System.Drawing.Size(100, 20);
            this.txtSMTPUser.TabIndex = 1;
            this.txtSMTPUser.Text = "useremail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "FromName";
            // 
            // txtFromName
            // 
            this.txtFromName.Location = new System.Drawing.Point(107, 63);
            this.txtFromName.Name = "txtFromName";
            this.txtFromName.Size = new System.Drawing.Size(100, 20);
            this.txtFromName.TabIndex = 1;
            this.txtFromName.Text = "Eric Tang";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "ToAddress";
            // 
            // txtToAddress
            // 
            this.txtToAddress.Location = new System.Drawing.Point(316, 63);
            this.txtToAddress.Name = "txtToAddress";
            this.txtToAddress.Size = new System.Drawing.Size(100, 20);
            this.txtToAddress.TabIndex = 1;
            this.txtToAddress.Text = "Eric.Zhao@active.com";
            // 
            // txtMailBody
            // 
            this.txtMailBody.Location = new System.Drawing.Point(36, 138);
            this.txtMailBody.Name = "txtMailBody";
            this.txtMailBody.Size = new System.Drawing.Size(485, 222);
            this.txtMailBody.TabIndex = 3;
            this.txtMailBody.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(436, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "SMTPPwd";
            // 
            // txtSMTPPwd
            // 
            this.txtSMTPPwd.Location = new System.Drawing.Point(513, 16);
            this.txtSMTPPwd.Name = "txtSMTPPwd";
            this.txtSMTPPwd.Size = new System.Drawing.Size(100, 20);
            this.txtSMTPPwd.TabIndex = 1;
            this.txtSMTPPwd.Text = "useremail";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(436, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "ReplyTo";
            // 
            // txtReplyTo
            // 
            this.txtReplyTo.Location = new System.Drawing.Point(513, 63);
            this.txtReplyTo.Name = "txtReplyTo";
            this.txtReplyTo.Size = new System.Drawing.Size(100, 20);
            this.txtReplyTo.TabIndex = 1;
            this.txtReplyTo.Text = "Eric.Zhao@active.com";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Subject";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(107, 101);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(506, 20);
            this.txtSubject.TabIndex = 1;
            this.txtSubject.Text = "Mail Subject";
            // 
            // frmEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 372);
            this.Controls.Add(this.txtMailBody);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtReplyTo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtToAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFromName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSMTPPwd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSMTPUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSmtpServer);
            this.Controls.Add(this.label1);
            this.Name = "frmEmail";
            this.Text = "frmEmail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSmtpServer;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSMTPUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFromName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtToAddress;
        private System.Windows.Forms.RichTextBox txtMailBody;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSMTPPwd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtReplyTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSubject;
    }
}