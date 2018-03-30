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
    class MyCourses
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        //Course filter
        By courseFilter = By.XPath(".//*[@id='divrendercontent']/div[5]/div[1]/div/input");
        By firstCourseInList = By.XPath(".//*[@id='inCompletedGrid']/div/div[2]/div[1]/p");
        By firstCourseInListStatus = By.XPath(".//*[@id='inCompletedGrid']/div/div[2]/div[4]/p");
        By CourseToBeComplted = By.XPath(".//*[@id='inCompletedGridandTiles']/div[1]/div[1]/div");
        By CompltedCourse = By.XPath(".//*[@id='completedGridandTiles']/div[1]/div[1]/div");
        By resumeCourseButton = By.XPath(".//*[@id='inCompletedGridandTiles']/div[1]/div[1]/div[2]/div[5]/p");

        public MyCourses(IWebDriver driver) {
            driver.Url = "http://lms.pravtek.com/Course/MyCourseDetails";
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement CourseFilter() {
            return driver.FindElement(courseFilter);
        }

        public IWebElement FirstCourseInList()
        {
            return driver.FindElement(firstCourseInList);
        }

        public IWebElement FirstCourseInListStatus()
        {
            return driver.FindElement(firstCourseInListStatus);
        }

        public bool CheckSubscribeCourse(string courseName) {
            int coursesCount = driver.FindElements(CourseToBeComplted).Count;
            for (int i = 2; i <= coursesCount; i++) {
                string cNameInList = driver.FindElement(By.XPath(".//*[@id='inCompletedGridandTiles']/div[1]/div[1]/div[" + i + "]/div[1]/p")).Text;
                if (courseName == cNameInList.Trim()) {
                    return true;
                }
            }
            return false;
        }

        public bool CheckSubscribeCourseStatus(string courseNameStatus)
        {
            int coursesCount = driver.FindElements(CourseToBeComplted).Count;
            for (int i = 2; i <= coursesCount; i++)
            {
                string cNameInListStatus = driver.FindElement(By.XPath(".//*[@id='inCompletedGridandTiles']/div[1]/div[1]/div[" + i + "]/div[4]/p")).Text;
                if (courseNameStatus == cNameInListStatus.Trim())
                {
                    return true;
                }
            }
            return false;
        }

        public IWebElement ResumeCourse() {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(resumeCourseButton));
        }
    }
}
