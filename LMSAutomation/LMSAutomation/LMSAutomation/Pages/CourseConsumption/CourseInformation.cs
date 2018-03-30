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

namespace LMSAutomation.Pages.CourseConsumption
{
    class CourseInformation
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        By takeCourse = By.XPath(".//*[@id='divrendercontent']/div[3]/div/div[2]/div[3]/a");

        public CourseInformation(IWebDriver driver) {
            this.driver = driver;
        }

        public IWebElement TakeCourse() {
            return driver.FindElement(takeCourse);
        }

    }
}
