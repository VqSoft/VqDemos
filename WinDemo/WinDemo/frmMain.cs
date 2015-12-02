using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinDemo
{
    public partial class frmMain : frmBase
    {
        public frmMain()
        {
            InitializeComponent();

            //txtHttpMethod.ReadOnly = true;
        }

        #region request


        private void SendRequest()
        {
            WinDemo.BaseConst.Realm rlm = BaseConst.Realm.People;
            string userName = "";
            string pwd = "";
            string consumerKey = "";
            string consumerSecret = "";

            GetDefaultAccountByUrl(txtApiUrl.Text.Trim(),out rlm, out userName, out pwd,out consumerKey,out consumerSecret);

            txtUserName.Text = userName;
            txtPwd.Text = pwd;
            txtConsumerKey.Text = consumerKey;
            txtConsumerSecret.Text = consumerSecret;

            try
            {
                GetAccessTokenForPortalUser(txtUserName.Text.Trim(), txtPwd.Text.Trim(), rlm, consumerKey, consumerSecret);

                using (WebResponse responseObj = GetWebResponse(rlm, OAuthBase.HMACSHA1SignatureType, "application/xml", txtHttpMethod.Text.Trim(), txtApiUrl.Text.Trim(),null,
                    txtConsumerKey.Text.Trim(), txtConsumerSecret.Text.Trim()))
                {
                    using (StreamReader sr = new StreamReader(responseObj.GetResponseStream()))
                    {
                        txtResponseContent.AppendText("Success! The response content is : \n");
                        txtResponseContent.AppendText(sr.ReadToEnd());
                    }
                }
            }
            catch (WebException we)
            {
                txtResponseContent.AppendText(we.GetType() + "\n");
                txtResponseContent.AppendText(we.Message + "\n");
                txtResponseContent.AppendText("-------------------------------------");
                
                txtResponseContent.AppendText(we.StackTrace);

            }
            catch (System.Net.ProtocolViolationException pve)
            {
                txtResponseContent.AppendText(pve.GetType() + "\n");
                txtResponseContent.AppendText(pve.Message + "\n");
                txtResponseContent.AppendText("-------------------------------------");

                txtResponseContent.AppendText(pve.StackTrace);
            }

        }

        private void GetConfig()
        {
            
        }

        private void SaveConfig()
        {

        }

        #endregion

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            try
            {
                btnSendRequest.Enabled = false;

                SendRequest();
                
                SaveConfig();
            }
            catch (Exception ex)
            {
                txtResponseContent.AppendText("btnSendRequest_Click ex: \n");
                txtResponseContent.AppendText(ex.Message + "\n");
                txtResponseContent.AppendText("-------------------------------------");
                txtResponseContent.AppendText(ex.StackTrace);
            }
            finally
            {
                btnSendRequest.Enabled = true;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           
            GetConfig();
        }
    }
}
