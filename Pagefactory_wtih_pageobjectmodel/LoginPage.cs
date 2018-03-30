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
    public class LoginPage:BasePage
    {
        public LoginPage(IWebDriver driver,ExtentTest test)
        {
            this.driver = driver;
            this.test = test;
        }
        [FindsBy(How = How.XPath, Using = ".//*[@id='email']")]
         public IWebElement Email;
        [FindsBy(How = How.XPath, Using = ".//*[@id='pass']")]
        public IWebElement Password; 
        public void Login()
        {
            Email.SendKeys(Helper.GetAppConfig("Email"));

            Password.SendKeys(Helper.GetAppConfig("Password"));
            test.Log(LogStatus.Info, "Useerename :" + Helper.GetAppConfig("Email") + " /" + "Password :" + Helper.GetAppConfig("Password"));
            Password.SendKeys(Keys.Enter);
        }
    }
}
