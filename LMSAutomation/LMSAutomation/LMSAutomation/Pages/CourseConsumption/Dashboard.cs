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
    class Dashboard
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        //My course completion progress items
        By myCourseList = By.XPath(".//*[@id='cousespersantages']/div/div[1]/div/div");
        By myCourseText = By.XPath(".//*[@id='coursesprogresspercentages']/div/div[1]/div/p");

        public Dashboard(IWebDriver driver) {
            driver.Url = "http://lms.pravtek.com/DashBoard/Index";
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public int TotalCourses() {
            return driver.FindElements(myCourseList).Count;
        }

        public IWebElement MyCourseText() {
            return explicitWait.Until(ExpectedConditions.ElementExists(myCourseText));
        }
    }
}
