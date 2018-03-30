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
    class CreateQuiz
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        By moduleName = By.XPath(".//*[@id='FKModuleId']");
        By title = By.XPath(".//*[@id='AssessmentTitle']");
        By type = By.XPath(".//*[@id='ddlAssessmentType']");
        By timeLimit = By.XPath(".//*[@id='TimeLimit']");
        By startDate = By.XPath(".//*[@id='StartDate']");
        By endDate = By.XPath(".//*[@id='EndDate']");
        By passPercentage = By.XPath(".//*[@id='Passpercentage']");
        By questionCount = By.XPath(".//*[@id='CertificationQuestionCount']");
        By maximumAttempts = By.XPath(".//*[@id='MaxAttempts']");

        By nextButton = By.XPath(".//*[@id='btnAssessmentCreate']");
        By cancelButton = By.XPath(".//*[@id='btnCancelCreate']");
        By validationMess1 = By.XPath(".//*[@id='StripDiv']/div/p[1]");
        By validationMess2 = By.XPath(".//*[@id='StripDiv']/div/p[2]");
        By validationMess3 = By.XPath(".//*[@id='StripDiv']/div/p[3]");
        By validationMess4 = By.XPath(".//*[@id='StripDiv']/div/p[4]");
        By validationMess5 = By.XPath(".//*[@id='StripDiv']/div/p[5]");
        By validationMess6 = By.XPath(".//*[@id='StripDiv']/div/p[6]");

        public CreateQuiz(IWebDriver driver)
        {
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement Title()
        {
            return explicitWait.Until(ExpectedConditions.ElementIsVisible(title));
        }

        public IWebElement Type()
        {
            return driver.FindElement(type);
        }

        public IWebElement StartDate()
        {
            return driver.FindElement(startDate);
        }

        public IWebElement TimeLimit()
        {
            return driver.FindElement(timeLimit);
        }

        public IWebElement EndDate()
        {
            return driver.FindElement(endDate);
        }

        public IWebElement PassPercentage()
        {
            return driver.FindElement(passPercentage);
        }

        public IWebElement QuestionCount()
        {
            return driver.FindElement(questionCount);
        }

        public IWebElement MaximumAttempts()
        {
            return driver.FindElement(maximumAttempts);
        }
        public IWebElement NextButton()
        {
            return driver.FindElement(nextButton);
        }

        public IWebElement CancelButton()
        {
            return driver.FindElement(cancelButton);
        }

        public IWebElement ValidationMess2()
        {
            return driver.FindElement(validationMess2);
        }

        public IWebElement ValidationMess3()
        {
            return driver.FindElement(validationMess3);
        }

        public IWebElement ValidationMess1()
        {
            return driver.FindElement(validationMess1);
        }

        public IWebElement ValidationMess4()
        {
            return driver.FindElement(validationMess4);
        }

        public IWebElement ValidationMess5()
        {
            return driver.FindElement(validationMess5);
        }

        public IWebElement ValidationMess6()
        {
            return driver.FindElement(validationMess6);
        }
    }
}
