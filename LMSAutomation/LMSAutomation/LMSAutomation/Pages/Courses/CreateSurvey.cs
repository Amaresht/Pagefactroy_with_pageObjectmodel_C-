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
    class CreateSurvey
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        By title = By.XPath(".//*[@id='AssessmentTitle']");
        By type = By.XPath(".//*[@id='ddlAssessmentType']");
        By startDate = By.XPath(".//*[@id='StartDate']");
        By endDate = By.XPath(".//*[@id='EndDate']");
        By nextButton = By.XPath(".//*[@id='btnAssessmentCreate']");
        By cancelButton = By.XPath(".//*[@id='btnCancelCreate']");
        By validationMess1 = By.XPath(".//*[@id='StripDiv']/div/p[1]");
        By validationMess2 = By.XPath(".//*[@id='StripDiv']/div/p[2]");
        By validationMess3 = By.XPath(".//*[@id='StripDiv']/div/p[3]");
        //	By allQuestion = By.xpath(".//*[@id='rbnAll']");


        public CreateSurvey(IWebDriver driver)
        {
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement Title()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(title));
        }

        public IWebElement Type()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(type));
        }

        public IWebElement StartDate()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(startDate));
        }

        public IWebElement EndDate()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(endDate));
        }

        public IWebElement NextButton()
        {
            explicitWait.Until(ExpectedConditions.ElementExists(nextButton));
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(nextButton));
        }

        public IWebElement CancelButton()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(cancelButton));
        }

        public IWebElement ValidationMess1()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(validationMess1));
        }

        public IWebElement ValidationMess2()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(validationMess2));
        }

        public IWebElement ValidationMess3()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(validationMess3));
        }
    }
}
