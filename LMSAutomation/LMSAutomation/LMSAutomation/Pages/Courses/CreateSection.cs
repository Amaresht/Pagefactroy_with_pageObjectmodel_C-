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
    class CreateSection
    {
        IWebDriver driver;

        By title = By.XPath(".//*[@id='Title']");
        By createSection = By.XPath(".//*[@id='btnAssessmentPartCreate']/");
        By validationForTitle = By.XPath(".//*[@id='asessmntvaldtn']/div/p");

        public CreateSection(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement CreateSectionButton()
        {
            return driver.FindElement(createSection);
        }

        public IWebElement Title()
        {
            return driver.FindElement(title);
        }

        public IWebElement ValidationForTitle()
        {
            return driver.FindElement(validationForTitle);
        }
    }
}
