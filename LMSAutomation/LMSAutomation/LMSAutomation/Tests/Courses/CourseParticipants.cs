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
using LMSAutomation.Base;
using LMSAutomation.Pages.Courses;

namespace LMSAutomation.Tests.Courses
{
    class CourseParticipants : BaseDriver
    {
        [Test]
        [TestCase("sample course1")]
        public void addParticipants(String coursename)
        {
            try
            {

                Pages.Courses.Courses c = new Pages.Courses.Courses(driver);
                c.CourseName().SendKeys(coursename);
                c.CourseSelect().Click();
                CourseContent cc = new CourseContent(driver);
                cc.CourseWidget().Click();

                cc.AddParticipants().Click();

                Pages.Courses.CourseParticipants cp = new Pages.Courses.CourseParticipants(driver);

                //		Test Case #1: All field validation check
                //logger.debug("Test Case #1: All field validation check");
                cp.SubscribeParticipants().Click();
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("document.getElementById('StripDiv').scrollIntoView();");
                Assert.AreEqual(cp.ValdationMessage1().Text, "Start Date is required");
                Assert.AreEqual(cp.ValdationMessage2().Text, "End Date is required");
                Assert.AreEqual(cp.ValdationMessage3().Text, "Please select the User(s) from Select Learners / Instructors List.");

                //		Test Case #2: start date is greater than end date validation check
                //logger.debug("Test Case #2: start date is greater than end date validation check");
                cp.SelectParticipants("test learner");
                cp.SetParticipants().Click();
                cp.StartDate().SendKeys(prop.getProperty("startDateTestParticipantT1"));
                cp.EndDate().SendKeys(prop.getProperty("endDateTestParticipantT1"));
                cp.SubscribeParticipants().Click();
                Assert.AreEqual(cp.ValdationMessage1().Text, "Subscription End Date must be greater than Subscription Start Date");

                //		valid data
                //logger.debug("valid data");
                cp.SelectParticipants("test learner");
                cp.SetParticipants().Click();
                cp.StartDate().Clear();
                cp.EndDate().Clear();
                cp.StartDate().SendKeys(prop.getProperty("startDateforParticipant"));
                cp.EndDate().SendKeys(prop.getProperty("endDateforParticipant"));
                cp.SubscribeParticipants().Click();

            }
            catch (Exception e)
            {
                //logger.error(e.getMessage());
                screenShotObj.GetScreenshot(driver, "creatingCourse");
            }

        }
    }
}
