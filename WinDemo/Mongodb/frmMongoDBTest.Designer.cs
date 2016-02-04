namespace WinDemo
{
    partial class frmMongoDBTest
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
            this.txtThreadCount = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserCount = new System.Windows.Forms.TextBox();
            this.txtConnStr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtThreadCount2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserCount2 = new System.Windows.Forms.TextBox();
            this.txtConnStr2 = new System.Windows.Forms.TextBox();
            this.btnRun2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "线程数";
            // 
            // txtThreadCount
            // 
            this.txtThreadCount.Location = new System.Drawing.Point(79, 6);
            this.txtThreadCount.Name = "txtThreadCount";
            this.txtThreadCount.Size = new System.Drawing.Size(100, 21);
            this.txtThreadCount.TabIndex = 1;
            this.txtThreadCount.Text = "200";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(23, 91);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 21);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "启动";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "每个线程操作记录数";
            // 
            // txtUserCount
            // 
            this.txtUserCount.Location = new System.Drawing.Point(319, 6);
            this.txtUserCount.Name = "txtUserCount";
            this.txtUserCount.Size = new System.Drawing.Size(100, 21);
            this.txtUserCount.TabIndex = 1;
            this.txtUserCount.Text = "10";
            // 
            // txtConnStr
            // 
            this.txtConnStr.Location = new System.Drawing.Point(79, 46);
            this.txtConnStr.Name = "txtConnStr";
            this.txtConnStr.Size = new System.Drawing.Size(637, 21);
            this.txtConnStr.TabIndex = 1;
            this.txtConnStr.Text = "mongodb://WL00070357:27016,WL00070357:27017,WL00070357:27018/?safe=true;readprefe" +
    "rence=primaryPreferred";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "连接串";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "线程数";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "连接串";
            // 
            // txtThreadCount2
            // 
            this.txtThreadCount2.Location = new System.Drawing.Point(79, 165);
            this.txtThreadCount2.Name = "txtThreadCount2";
            this.txtThreadCount2.Size = new System.Drawing.Size(100, 21);
            this.txtThreadCount2.TabIndex = 1;
            this.txtThreadCount2.Text = "200";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "每个线程操作记录数";
            // 
            // txtUserCount2
            // 
            this.txtUserCount2.Location = new System.Drawing.Point(319, 165);
            this.txtUserCount2.Name = "txtUserCount2";
            this.txtUserCount2.Size = new System.Drawing.Size(100, 21);
            this.txtUserCount2.TabIndex = 1;
            this.txtUserCount2.Text = "10";
            // 
            // txtConnStr2
            // 
            this.txtConnStr2.Location = new System.Drawing.Point(79, 205);
            this.txtConnStr2.Name = "txtConnStr2";
            this.txtConnStr2.Size = new System.Drawing.Size(637, 21);
            this.txtConnStr2.TabIndex = 1;
            this.txtConnStr2.Text = "mongodb://WL00070357:27016,WL00070357:27017,WL00070357:27018/?safe=false;readpref" +
    "erence=primaryPreferred";
            // 
            // btnRun2
            // 
            this.btnRun2.Location = new System.Drawing.Point(23, 250);
            this.btnRun2.Name = "btnRun2";
            this.btnRun2.Size = new System.Drawing.Size(75, 21);
            this.btnRun2.TabIndex = 2;
            this.btnRun2.Text = "启动";
            this.btnRun2.UseVisualStyleBackColor = true;
            this.btnRun2.Click += new System.EventHandler(this.btnRun2_Click);
            // 
            // frmMongoDBTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 356);
            this.Controls.Add(this.btnRun2);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtConnStr2);
            this.Controls.Add(this.txtUserCount2);
            this.Controls.Add(this.txtConnStr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUserCount);
            this.Controls.Add(this.txtThreadCount2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtThreadCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "frmMongoDBTest";
            this.Text = "frmMongoDBTest";
            this.Load += new System.EventHandler(this.frmMongoDBTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtThreadCount;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserCount;
        private System.Windows.Forms.TextBox txtConnStr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtThreadCount2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUserCount2;
        private System.Windows.Forms.TextBox txtConnStr2;
        private System.Windows.Forms.Button btnRun2;
    }
}