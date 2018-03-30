using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace LMSAutomation.Pages.UserManagement
{
    class RegisterUser
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        By firstName = By.Id("btnCreateuser");

        public RegisterUser(IWebDriver driver)
        {
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }
    }
}
