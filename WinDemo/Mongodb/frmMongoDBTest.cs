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
    /// <summary>
    /// 连接串示例： mongodb://WL00070357:27016,WL00070357:27017,WL00070357:27018/?connect=replicaSet;replicaset=thomas_test;readpreference=primaryPreferred;WaitQueueSize=30000
    /// mongodb://WL00070357:27016,WL00070357:27017,WL00070357:27018/?safe=true;readpreference=primaryPreferred
    /// mongodb://WL00070357:27016,WL00070357:27017,WL00070357:27018/?safe=false;readpreference=primaryPreferred
    /// </summary>
    public partial class frmMongoDBTest : frmBase
    {


        public frmMongoDBTest()
        {
            InitializeComponent();
        }

        private Mongodb.MongodbHelper mongoHelper = null;

        private Mongodb.MongodbHelper mongoHelper2 = null;

        private void frmMongoDBTest_Load(object sender, EventArgs e)
        {

        }

        

        private void btnRun_Click(object sender, EventArgs e)
        {
            mongoHelper = new Mongodb.MongodbHelper(txtConnStr.Text.Trim(), "SessionState");

            int threadCount = int.Parse(txtThreadCount.Text.Trim());
            int userCount = int.Parse(txtUserCount.Text.Trim());

            for (int i = 0; i < threadCount; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < userCount; j++)
                    {
                        MongoSessionDocument session = new MongoSessionDocument();
                        mongoHelper.InsertAndUpdate(session);
                    }

                });
            }
        }

        private void btnRun2_Click(object sender, EventArgs e)
        {
            mongoHelper2 = new Mongodb.MongodbHelper(txtConnStr2.Text.Trim(), "SessionState");

            int threadCount = int.Parse(txtThreadCount2.Text.Trim());
            int userCount = int.Parse(txtUserCount2.Text.Trim());

            for (int i = 0; i < threadCount; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < userCount; j++)
                    {
                        MongoSessionDocument session = new MongoSessionDocument();
                        mongoHelper.InsertAndUpdate(session);
                    }

                });
            }
        }
    }
}
