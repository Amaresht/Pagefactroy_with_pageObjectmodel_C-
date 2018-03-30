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
    class UploadCaptivate
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        By fileName = By.XPath(".//*[@id='txtDocumentName']");
        By selectFileButton = By.XPath(".//input[@id='UploadCaptivate']/..");
        By submitButton = By.XPath(".//*[@id='btnSubmitCaptivate']");
        By validationMess = By.XPath(".//*[@id='StripDiv2']/p");

        public UploadCaptivate(IWebDriver driver)
        {
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement FileName()
        {
            return driver.FindElement(fileName);
        }

        public IWebElement SelectFileButton()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(selectFileButton));
        }

        public IWebElement SubmitButton()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(submitButton));
        }

        public IWebElement ValidationMess()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(validationMess));
        }
    }
}
