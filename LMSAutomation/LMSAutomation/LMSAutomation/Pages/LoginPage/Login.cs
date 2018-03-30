using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LMSAutomation.Pages.LoginPage
{
    class Login
    {
        IWebDriver driver;

        By userNameId = By.XPath(".//*[@id='SubmitLoginDetailsForm']/div/div[2]/div[1]/div/input");
        By passwordId = By.XPath(".//*[@id='SubmitLoginDetailsForm']/div/div[2]/div[2]/div/input");
        By loginButton = By.XPath(".//button[@id='SubmitLoginDetailsForm']");

        public Login(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement Username()
        {
            return driver.FindElement(userNameId);
        }

        public IWebElement Password()
        {
            return driver.FindElement(passwordId);
        }

        public IWebElement LoginButton()
        {
            return driver.FindElement(loginButton);
        }
    }
}
