using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinDemo
{
    public static class BaseConst
    {

        public const string ChurchCode = "dc";
        public const int ChurchID = 15;
        public const string Version = "v1";

        private static string GetRealmBaseUrl(Realm realm)
        {
            string rlm = string.Empty;
            if (realm != Realm.People)
            {
                rlm = realm.ToString().ToLower() + "/";
            }

            string url = string.Empty;
            switch (ConfigUtil.GetAppSetting("Application.Environment"))
            {
                case "local":
                    url = "http://" + ChurchCode + ".fellowshiponeapi.local/" + rlm + Version;
                    break;
                case "development":
                    url = "http://" + ChurchCode + ".api.dev.corp.local/" + rlm + Version;
                    break;
                case "integration":
                    url = "http://" + ChurchCode + ".apiqa.dev.corp.local/" + rlm + Version;
                    break;
                case "staging":
                    url = "https://" + ChurchCode + ".staging.fellowshiponeapi.com/" + rlm + Version;
                    break;
                case "production":
                    url = "https://" + ChurchCode + ".fellowshiponeapi.com/" + rlm + Version;
                    break;
                default:
                    url = "http://" + ChurchCode + ".fellowshiponeapi.local/" + rlm + Version;
                    break;
            }
            return url;
        }


        public static string ApiURL
        {
            get
            {
                return GetRealmBaseUrl(Realm.People);
            }
        }

        public static string ApiGivingURL
        {
            get
            {
                return GetRealmBaseUrl(Realm.Giving);
            }
        }

        public static string ApiGroupsURL
        {
            get
            {
                return GetRealmBaseUrl(Realm.Groups);
            }
        }

        public static string ApiEventsURL
        {
            get
            {
                return GetRealmBaseUrl(Realm.Events);
            }
        }

        // Giving URL Enviornments 
        //public const string ApiGivingURL = "http://" + ChurchCode + ".fellowshiponeapi.local/giving/" + Version;
        //public const string ApiGivingURL = "http://" + ChurchCode + ".fellowshiponeapi.test.dev.corp.local/Giving/" + Version;
        //public const string ApiGivingURL = "http://" + ChurchCode + ".apiqa.dev.corp.local/Giving/" + Version;
        //public const string ApiGivingURL = "https://" + ChurchCode + ".staging.fellowshiponeapi.com/giving/" + Version;
        //public const string ApiGivingURL = "https://" + ChurchCode + ".fellowshiponeapi.com/Giving/" + Version;

        // Groups URL Enviornments 
        //public const string ApiGroupsURL = "http://" + ChurchCode + ".fellowshiponeapi.local/groups/" + Version;
        //public const string ApiGroupsURL = "http://" + ChurchCode + ".fellowshiponeapi.local/groups/" + Version;
        //public const string ApiGroupsURL = "http://" + ChurchCode + ".apiqa.dev.corp.local/groups/" + Version;
        //public const string ApiGroupsURL = "https://" + ChurchCode + ".fellowshiponeapi.com/groups/" + Version;

        // Events URL Enviornments 
        //public const string ApiEventsURL = "http://" + ChurchCode + ".fellowshiponeapi.local/events/" + Version;
        //public const string ApiEventsURL = "http://" + ChurchCode + ".fellowshiponeapi.local/events/" + Version;
        //public const string ApiEventsURL = "http://" + ChurchCode + ".apiqa.dev.corp.local/events/" + Version;
        //public const string ApiEventsURL = "https://" + ChurchCode + ".fellowshiponeapi.com/events/" + Version;



        // Consumer keys
        public const string ConsumerKey1stParty = "6";
        public const string ConsumerKey2ndParty = "2";
        public const string ConsumerKey3rdParty = "1";
        public const string ConsumerKeyInvalid = "3";

        // Consumer secrets
        public const string ConsumerSecret1stParty = "6fd61bc9-2965-4a0d-bb48-1a134bec6875";
        public const string ConsumerSecret2ndParty = "f7d02059-a105-45e0-85c9-7387565f322b";
        public const string ConsumerSecret3rdParty = "5095e32f-150f-4662-95ea-953b0373df04";
        public const string ConsumerSecretInvalid = "f7d02059-a105-45e0-85c9-7387565f322c";

        //OAuth
        public const string RequestTokenURL = "/Tokens/RequestToken";
        public const string RequestCallbackURL = "";
        public const string WeblinkUserAuthURL = "/WeblinkUser/Login";
        public const string PortalUserAuthURL = "/PortalUser/Login";
        public const string UserUserAuthURL = "/User/Login";
        public const string WeblinkAccessTokenURL = "/WeblinkUser/AccessToken";
        public const string PortalAccessTokenURL = "/PortalUser/AccessToken";
        public const string UserAccessTokenURL = "/User/AccessToken";

        // User credentials
        public const string WeblinkUserName = "nfloyd123";
        public const string WeblinkUserPassword = "nfloyd123";
        public const string WeblinkUserNameMergedOut = "weblinkmergedout";
        public const string WeblinkUserPasswordMergedOut = "Pa$$w0rd";
        public const string WeblinkWebUserAsEmail = "test@test.com";
        public const string WeblinkPasswordAsEmail = "Pa$$w0rd";
        public const string PortalUserName = "tcoulson";
        public const string PortalUserPassword = "FT.Admin1";
        public const string PortalUserNameInactive = "inactivePortal";
        public const string PortalUserPasswordInactive = "Pa$$w0rd";
        public const string UserUserName = "msneeden@fellowshiptech.com";
        public const string UserUserPassword = "Pa$$w0rd";
        public const string UserUserNameMergedOut = "sneedenm@msoe.edu";
        public const string UserUserPasswordMergedOut = "Pa$$w0rd";

        //Vendor tokens
        public const string VendorToken = "5095e32f-150f-4662-95ea-953b0373df04";

        public enum Realm
        {
            People = 1,
            Giving = 2,
            Events = 3,
            Groups = 4
        }

        public enum TokenType
        {
            UnauthenticatedRequestToken = 1,
            RequestToken = 2,
            AccessToken = 3,
            UserAuthorization = 4
        }

        public enum UserType
        {
            Portal = 1,
            Weblink = 2,
            User = 3
        }
    }
}
