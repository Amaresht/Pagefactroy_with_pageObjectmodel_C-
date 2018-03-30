using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagefactory_wtih_pageobjectmodel
{
    public class LaunchingPage:BasePage
    {
        public LaunchingPage(IWebDriver driver,ExtentTest test)
        {
            this.driver = driver;
            this.test = test;
        }
        public LoginPage OpenApplication()
        {
            driver.Url = "http://www.facebook.com/";
            test.Log(LogStatus.Info, "Url open Sucessusfully");
            LoginPage loginpage = new LoginPage(driver,test);
            PageFactory.InitElements(driver, loginpage);
            return loginpage;
        }
    }
}
