using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinDemo.Mongodb;

namespace WinDemo
{
    public partial class frmMongoDBTest : frmBase
    {
        public frmMongoDBTest()
        {
            InitializeComponent();
        }

        private Mongodb.MongodbHelper mongoHelper = null;

        private void frmMongoDBTest_Load(object sender, EventArgs e)
        {
            txtConnStr.Text = @"mongodb://WL00070357:27016,WL00070357:27017,WL00070357:27018/?connect=replicaSet;replicaset=thomas_test;readpreference=primaryPreferred";
            txtThreadCount.Text = "30";
            txtUserCount.Text = "200";
        }

        

        private void btnRun_Click(object sender, EventArgs e)
        {
            mongoHelper = new Mongodb.MongodbHelper(txtConnStr.Text.Trim(), "SessionState");

            Random rdm = new Random(100);

            int threadCount = int.Parse(txtThreadCount.Text.Trim());
            int userCount = int.Parse(txtUserCount.Text.Trim());

            for (int i = 0; i < threadCount; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < userCount; j++)
                    {
                        MongoSessionDocument session = new MongoSessionDocument();
                        mongoHelper.Test(session);
                    }

                    Task.Delay(rdm.Next(1, 20));

                });
            }
        }
    }
}
