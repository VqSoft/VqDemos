using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinDemo
{
    public class ConfigUtil
    {
        public static string GetAppSetting(string setting)
        {
            if (ConfigurationManager.AppSettings[setting] != null)
            {
                return ConfigurationManager.AppSettings[setting];
            }
            else
            {
                throw new NullReferenceException(string.Format("The app setting {0} was not found on machine {1}", setting, Environment.MachineName));
            }
        }
    }
}
