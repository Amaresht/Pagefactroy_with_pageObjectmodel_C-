using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelevantCodes.ExtentReports;
using OpenQA.Selenium.Support.UI;

namespace LMSAutomation.Pages.Courses
{
    class Module
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        By moduleName = By.XPath(".//*[@id='CourseModuleName']");
        By description = By.XPath(".//*[@id='Description']");
        By submitButton = By.XPath(".//*[@id='btnCreateModule']");
        By cancelButton = By.XPath(".//*[@id='btnClose']");
        By validationMess = By.XPath(".//*[@id='StripDiv1']/p");

        public Module(IWebDriver driver)
        {
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement ModuleName()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(moduleName));
        }

        public IWebElement Description()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(description));
        }

        public IWebElement SubmitButton()
        {
            explicitWait.Until(ExpectedConditions.ElementExists(submitButton));
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(submitButton));
        }

        public IWebElement CancelButton()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(cancelButton));
        }

        public IWebElement ValidationMess()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(validationMess));
        }
    }
}
