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
using System.Xml;

namespace WinDemo
{
    public partial class frmBase : Form
    {
        public frmBase()
        {
            InitializeComponent();
        }

        #region properties
        private string _accessToken = null;
        public string AccessToken
        {
            get { return _accessToken; }
            set { _accessToken = value; }
        }

        public string AccessTokenSecret
        {
            get;
            set;
        }

        #endregion

        protected void GetDefaultAccountByUrl(string url, out WinDemo.BaseConst.Realm rlm, out string userName, out string pwd,
            out string consumerKey, out string consumerSecret)
        {
            rlm = BaseConst.Realm.People;
            userName = BaseConst.PortalUserName;
            consumerKey = BaseConst.ConsumerKey1stParty;
            consumerSecret = BaseConst.ConsumerSecret1stParty;

            pwd = BaseConst.PortalUserPassword;

            if (url.Contains(WinDemo.BaseConst.Realm.People.ToString()))
            {
                userName = BaseConst.PortalUserName;
                pwd = BaseConst.PortalUserPassword;
                rlm = BaseConst.Realm.People;
            }
            else if (url.Contains(WinDemo.BaseConst.Realm.Groups.ToString()))
            {
                //TODO  userName

                rlm = BaseConst.Realm.Groups;
            }
            else if (url.Contains(WinDemo.BaseConst.Realm.Giving.ToString()))
            {
                //TODO userName

                rlm = WinDemo.BaseConst.Realm.Giving;
            }
            else if (url.Contains(WinDemo.BaseConst.Realm.Events.ToString()))
            {
                //

                rlm = BaseConst.Realm.Events;
            }

        }

        public string GetTokenURI(BaseConst.Realm realm, string urlPart)
        {
            string uri = string.Empty;

            switch (realm)
            {
                case BaseConst.Realm.People:
                    uri = BaseConst.ApiURL + urlPart;
                    break;
                case BaseConst.Realm.Groups:
                    uri = BaseConst.ApiGroupsURL + urlPart;
                    break;
                case BaseConst.Realm.Giving:
                    uri = BaseConst.ApiGivingURL + urlPart;
                    break;
                case BaseConst.Realm.Events:
                    uri = BaseConst.ApiEventsURL + urlPart;
                    break;
                default:
                    uri = BaseConst.ApiURL + urlPart;
                    break;
            }
            return uri;
        }

        public string GetAccessTokenForPortalUser(string username, string password, BaseConst.Realm realm, string consumerKey, string consumerSecret)
        {
            OAuthBase oAuth = new OAuthBase();

            string url = GetTokenURI(realm, BaseConst.PortalAccessTokenURL);

            string creds = OAuthBase.BuildCredentials(username, password);

            string results = null;

            //begin
            WebResponse webResponse = GetWebResponse(realm, OAuthBase.HMACSHA1SignatureType, "appliation/xml", "POST", url, creds, consumerKey, consumerSecret);
            StreamReader sr = new StreamReader(webResponse.GetResponseStream());

            if (webResponse.Headers["oauth_token"] != null)
            {
                AccessToken = webResponse.Headers["oauth_token"].ToString();
            }
            if (webResponse.Headers["oauth_token_secret"] != null)
            {
                AccessTokenSecret = webResponse.Headers["oauth_token_secret"].ToString();
            }

            results = sr.ReadToEnd().Trim();
            webResponse.Close();
            //end

            return results;
        }


        public WebResponse GetWebResponse(BaseConst.Realm realm, string signatureType, string contentType, string httpMethod, string urlPath, string parm, string consumerKey, string consumerSecret)
        {
            OAuthBase oAuth = new OAuthBase();
            Uri url = new Uri(urlPath);
            string statusCode = string.Empty;

            string nonce = oAuth.GenerateNonce();
            string timestamp = oAuth.GenerateTimeStamp();
            string normalizedUrl = string.Empty;
            string normalizedReqParms = string.Empty;

            string sig = oAuth.GenerateSignature(url, consumerKey, consumerSecret, AccessToken, AccessTokenSecret, httpMethod, timestamp, nonce, signatureType, out normalizedUrl, out normalizedReqParms);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

            string authHeader = OAuthBase.BuildOAuthHeader(consumerKey, nonce, sig, signatureType, timestamp, AccessToken);
            request.Headers.Add("Authorization", authHeader);
            request.Accept = contentType;
            request.Method = httpMethod;

            if (!string.IsNullOrEmpty(parm))
            {
                request.ContentLength = parm.Length;

                // Write the request
                StreamWriter stOut = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
                stOut.Write(parm);
                stOut.Close();
            }

            WebResponse webResponse = request.GetResponse();
            return webResponse;

        }//class
    }
}
