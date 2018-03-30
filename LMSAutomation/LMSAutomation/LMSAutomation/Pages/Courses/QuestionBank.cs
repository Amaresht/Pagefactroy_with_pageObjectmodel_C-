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

namespace LMSAutomation.Pages.Courses
{
    class QuestionBank
    {
        IWebDriver driver;

        By addQuestion = By.XPath(".//*[contains(@id,'btnNewQuestion')]");
        By importFromExcel = By.XPath(".//*[@id='btnUploadQuestionBank']");
        By backToCourse = By.XPath(".//*[@id='divrendercontent']/div[2]/input[1]");

        public QuestionBank(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement AddQuestion(String name)
        {
            return driver.FindElement(addQuestion);
        }

        public IWebElement ImportFromExcel()
        {
            return driver.FindElement(importFromExcel);
        }

        public IWebElement BackToCourse()
        {
            return driver.FindElement(backToCourse);
        }
    }
}
