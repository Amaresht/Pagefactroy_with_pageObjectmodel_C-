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
    class ImportQuestions
    {
        IWebDriver driver;

        By checkBoxFirstQ = By.XPath(".//input[contains(@id, 'chkQuestion')]");
        By importQuestion = By.XPath(".//input[contains(@id, 'btnImportTypeUp')]");

        public ImportQuestions(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement CheckBoxFirstQ()
        {
            return driver.FindElement(checkBoxFirstQ);
        }

        public IWebElement ImportQuestion()
        {
            return driver.FindElement(importQuestion);
        }


    }
}
