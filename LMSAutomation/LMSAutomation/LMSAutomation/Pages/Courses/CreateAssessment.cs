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
    class CreateAssessment
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        By title = By.XPath(".//*[@id='AssessmentTitle']");
        By timeLimit = By.XPath(".//*[@id='TimeLimit']");
        By startDate = By.XPath(".//*[@id='StartDate']");
        By endDate = By.XPath(".//*[@id='EndDate']");
        By passPercentage = By.XPath(".//*[@id='Passpercentage']");
        By questionsCount = By.XPath(".//*[@id='CertificationQuestionCount']");
        By maxAttempts = By.XPath(".//*[@id='MaxAttempts']");
        By nextButton = By.XPath(".//*[@id='btnAssessmentCreate']");
        By validationMess1 = By.XPath(".//*[@id='StripDiv']/div/p[1]");
        By validationMess2 = By.XPath(".//*[@id='StripDiv']/div/p[2]");
        By validationMess3 = By.XPath(".//*[@id='StripDiv']/div/p[3]");
        By validationMess4 = By.XPath(".//*[@id='StripDiv']/div/p[4]");
        By validationMess5 = By.XPath(".//*[@id='StripDiv']/div/p[5]");
        By validationMess6 = By.XPath(".//*[@id='StripDiv']/div/p[6]");
        By publish = By.XPath(".//*[@id='aViewPublish']");

        public CreateAssessment(IWebDriver driver)
        {
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement Title()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(title));
        }

        public IWebElement TimeLimit()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(timeLimit));
        }

        public IWebElement StartDate()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(startDate));
        }

        public IWebElement EndDate()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(endDate));
        }

        public IWebElement PassPercentage()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(passPercentage));
        }

        public IWebElement QuestionsCount()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(questionsCount));
        }

        public IWebElement MaxAttempts()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(maxAttempts));
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

        public IWebElement ValidationMess4()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(validationMess4));
        }

        public IWebElement ValidationMess5()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(validationMess5));
        }

        public IWebElement ValidationMess6()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(validationMess6));
        }
        public IWebElement NextButton()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(nextButton));
        }

        public IWebElement Publish()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(publish));
        }
    }
}
