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

            GetAccessTokenForPortalUser(txtUserName.Text.Trim(),txtPwd.Text.Trim(), 
                BaseConst.Realm.People,txtConsumerKey.Text.Trim(),txtConsumerSecret.Text.Trim());

            OAuthBase oAuth = new OAuthBase();
            OAuthTicket oauthTicket = new OAuthTicket();

            oauthTicket.ConsumerKey = txtConsumerKey.Text.Trim();
            oauthTicket.ConsumerSecret = txtConsumerSecret.Text.Trim();

            Uri url = new Uri(txtApiUrl.Text.Trim());

           
            string nonce = oAuth.GenerateNonce();
            string timestamp = oAuth.GenerateTimeStamp();
            string normalizedUrl = string.Empty;
            string normalizedReqParms = string.Empty;
            string sig = oAuth.GenerateSignature(url, oauthTicket.ConsumerKey, oauthTicket.ConsumerSecret, AccessToken, AccessTokenSecret,
                txtHttpMethod.Text.Trim(), timestamp, nonce,OAuthBase.HMACSHA1SignatureType, out normalizedUrl, out normalizedReqParms);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            string authHeader = OAuthBase.BuildOAuthHeader(oauthTicket.ConsumerKey, nonce, sig, OAuthBase.HMACSHA1SignatureType, timestamp, "");
            request.Headers.Add("Authorization", authHeader);
            request.ContentType = "appliation/xml";
            request.Method = txtHttpMethod.Text.Trim();

            string creds = OAuthBase.BuildCredentials(txtUserName.Text.Trim(), txtPwd.Text.Trim());

            request.ContentLength = creds.Length;

            // Write the request
            StreamWriter stOut = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            stOut.Write(creds);
            stOut.Close();

            string results = null;
            try
            {
                WebResponse webResponse = request.GetResponse();
                StreamReader sr = new StreamReader(webResponse.GetResponseStream());

                if (webResponse.Headers["oauth_token"] != null)
                {
                    oauthTicket.AccessToken = webResponse.Headers["oauth_token"].ToString();
                }
                if (webResponse.Headers["oauth_token_secret"] != null)
                {
                    oauthTicket.AccessTokenSecret = webResponse.Headers["oauth_token_secret"].ToString();
                }

                results = sr.ReadToEnd().Trim();
                txtResponseContent.AppendText("Success! \n");
                txtResponseContent.AppendText(results);
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
