using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSAutomation.Utility
{
    class Helper
    {
        public static string GetAppconfigValues(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
