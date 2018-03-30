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
    class ExploreCourses
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        //Filter
        By filter = By.XPath(".//input[contains(@class,'form-control')]");

        //first explore course
        By firstExploreCourse = By.XPath(".//*[@id='ExploralGrid']/div[2]/div[2]/div[1]/p");
        By sweetAlertOkButton = By.XPath(".//*[@id='mainBody']/div[4]/div/button[1]");
        By sweetSuccessOkButton = By.XPath(".//*[@id='mainBody']/div[4]/div/button[1]");
        By subscribeButton = By.XPath(".//*[@id='ExploralGrid']/div[2]/div[2]/div[3]/a");

        public ExploreCourses(IWebDriver driver) {
            driver.Url = "http://lms.pravtek.com/Course/ExploreCourses";
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement FirstExploreCourse() {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(firstExploreCourse));
        }

        public IWebElement SweetAlertOkButton()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(sweetAlertOkButton));
        }

        public IWebElement SweetSuccessOkButton()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(sweetSuccessOkButton));
        }

        public IWebElement SubscribeGivenCourse(string course)
        {
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(filter).SendKeys(course);
            System.Threading.Thread.Sleep(1000);
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(subscribeButton));
        }

        public IWebElement Filter() {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(filter));
        }
    }
}
