using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinDemo
{
    public partial class frmContainer : Form
    {

        #region 子窗体
        private static frmMongoDBTest mongodbTestForm = null;

        #endregion
        public frmContainer()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void mongoDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mongodbTestForm == null || mongodbTestForm.IsDisposed)
            {
                mongodbTestForm = new frmMongoDBTest();
                mongodbTestForm.MdiParent = this;
                mongodbTestForm.WindowState = FormWindowState.Maximized;
            }
            mongodbTestForm.Show();
        }
    }
}
