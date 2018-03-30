using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelevantCodes.ExtentReports;
using LMSAutomation.Pages.LoginPage;
using System.IO;
using LMSAutomation.Pages.UserManagement;
using System.Configuration;
using LMSAutomation.Utility;

namespace LMSAutomation.Base
{
   public class Prop
    {
        public static Dictionary<string, string> data = new Dictionary<string, string>();
        public Prop()
        {
            foreach (var row in File.ReadAllLines(ConfigurationManager.AppSettings["Properties"].ToString())) {
                if(!data.ContainsKey(row.Split('=')[0].Trim()) && row.Split('=').Length > 1)
                    data.Add(row.Split('=')[0].Trim(), row.Split('=')[1].Trim());
            }
                
        }

        public String getProperty(string name)
        {
            return data[name];
        }
    }
    class BaseDriver
    {
        public IWebDriver driver;
        public ExtentReports _extent;
        public ExtentTest _test;
        public Prop prop;

        public Utility.ScreenShot screenShotObj = new Utility.ScreenShot();
        // private static readonly ILog logger = LogManager.GetLogger(typeof(AddQuiz));

        public BaseDriver() {

            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(Helper.GetAppconfigValues("BrowserDrivers"));
            service.FirefoxBinaryPath = Helper.GetAppconfigValues("FirefoxBinaryPath");
            driver = new FirefoxDriver(service);

            prop = new Prop();
            //driver = new ChromeDriver(Helper.GetWebconfigValues("BrowserDrivers"));
            //driver = new InternetExplorerDriver(Helper.GetWebconfigValues("BrowserDrivers"));

            _extent = new ExtentReports(Helper.GetAppconfigValues("ExtentReportPath"));
            _extent.AddSystemInfo("Host Name", Helper.GetAppconfigValues("HostName")).AddSystemInfo("Environment", Helper.GetAppconfigValues("Environment")).AddSystemInfo("User Name", Helper.GetAppconfigValues("UserName"));
            _extent.LoadConfig(Helper.GetAppconfigValues("ExtentLoadConfPath"));

            driver.Url = Helper.GetAppconfigValues("AppTestURL");

            Login login = new Login(driver);

            login.Password().SendKeys("abc@1234");
            login.Username().SendKeys("FirstName927.LastName714@testadp.com");
            //login.Username().SendKeys("FirstName2.LastName112@testadp.com");
            login.LoginButton().Click();
        }

        public void SwitchUserLogin(IWebDriver driver) {
            AccountSection objAccountSection = new AccountSection(driver);
            objAccountSection.Account().Click();
            objAccountSection.Signout().Click();
            Login login = new Login(driver);
            login.Password().SendKeys("abc@1234");
            //login.Username().SendKeys("FirstName927.LastName714@testadp.com");
            login.Username().SendKeys("FirstName337.LastName490@testadp.com");
            login.LoginButton().Click();
        }
        
    }
}
