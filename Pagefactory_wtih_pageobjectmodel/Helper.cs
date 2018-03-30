using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagefactory_wtih_pageobjectmodel
{
    public class Helper
    {
        public static string GetAppConfig(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();

        }
    }
}
