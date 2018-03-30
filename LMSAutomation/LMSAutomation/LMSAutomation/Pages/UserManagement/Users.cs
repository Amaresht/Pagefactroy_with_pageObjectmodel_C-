using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace LMSAutomation.Pages.UserManagement
{
    class Users
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        By newUser = By.Id("btnCreateuser");

        public Users(IWebDriver driver)
        {
            driver.Url = "http://lms.pravtek.com/Users/RegisterUser";
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement NewUser() {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(newUser));
        }


    }
}
