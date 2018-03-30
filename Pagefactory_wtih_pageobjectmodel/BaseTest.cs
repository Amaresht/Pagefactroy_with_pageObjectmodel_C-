using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagefactory_wtih_pageobjectmodel
{
    public class BaseTest:BasePage
    {
        public ExtentReports extent = ExtentManager.getInstance();

        public void init(String bType)
        {
          
            test.Log(LogStatus.Info, "Opening browser " + bType);
            if (bType.Equals("Mozilla"))
            {

                driver = new FirefoxDriver();
                test.Log(LogStatus.Info, bType + " browser successfully ");
            }
            else if (bType.Equals("Chrome"))
            {
                driver = new ChromeDriver();
                test.Log(LogStatus.Info, bType + " browser successfully ");
            }
            
        }
    }
}
