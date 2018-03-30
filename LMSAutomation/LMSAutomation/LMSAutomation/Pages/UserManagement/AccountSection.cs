using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace LMSAutomation.Pages.UserManagement
{
    class AccountSection
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        By account = By.XPath(".//*[@id='loginButton']/i");
        By signout = By.XPath(".//*[@id='signoutmrgnmobile']/a");

        public AccountSection(IWebDriver driver)
        {
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement Account()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(account));
        }

        public IWebElement Signout()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(signout));
        }
    }
}
