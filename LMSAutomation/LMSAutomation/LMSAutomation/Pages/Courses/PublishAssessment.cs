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
    class PublishAssessment
    {
        IWebDriver driver;
        WebDriverWait explicitWait;
        By acknowledge = By.XPath(".//*[@id='DefaultIsActive']");
        By publishCheckBox = By.XPath(".//*[@id='PublishAssessmentasAnnouncement']");
        By publish = By.XPath(".//*[@id='btnPublishAssessment']");
        By cancel = By.XPath(".//*[@id='btnCancelPublish']");
        By validationMessage = By.XPath(".//*[@id='divValidMsg']");
        By sweetAlertYesButton = By.XPath(".//body/div[3]/div/button[1]");
        By sweetAlertCancelButton = By.XPath(".//body/div[3]/div/button[2]");

        public PublishAssessment(IWebDriver driver)
        {
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement Acknowledge()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(acknowledge));
        }

        public IWebElement PublishCheckBox()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(publishCheckBox));
        }

        public IWebElement Publish()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(publish));
        }

        public IWebElement Cancel()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(cancel));
        }

        public IWebElement ValidationMessage()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(validationMessage));
        }

        public IWebElement SweetAlertYesButton()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(sweetAlertYesButton));
        }

        public IWebElement SweetAlertCancelButton()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(sweetAlertCancelButton));
        }
    }
}
