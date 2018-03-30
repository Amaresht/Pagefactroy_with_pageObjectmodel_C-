using log4net;
using log4net.Core;
using log4net.Repository.Hierarchy;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMSAutomation.Pages.Courses;
using LMSAutomation.Base;
using RelevantCodes.ExtentReports;

namespace LMSAutomation.Tests.CourseConsumption
{
    class ExploreCourses : BaseDriver
    {
        [Test]
        public void SubscribeCourse()
        {
            try
            {
                _test = _extent.StartTest("Test Case #01: subscribing course from Explore course");
                Pages.CourseConsumption.ExploreCourses ec = new Pages.CourseConsumption.ExploreCourses(driver);
                Pages.CourseConsumption.CourseInformation ci = new Pages.CourseConsumption.CourseInformation(driver);

                ec.SubscribeGivenCourse("Course22").Click();
                ec.SweetSuccessOkButton().Click();

                _test.Log(LogStatus.Pass, "Assert Pass as condition is true");
                _extent.EndTest(_test);

                _test = _extent.StartTest("Test Case #02: Viewing subscribed Course");
                Pages.CourseConsumption.MyCourses mc = new Pages.CourseConsumption.MyCourses(driver);

                System.Threading.Thread.Sleep(2000);
                mc.CourseFilter().SendKeys("Course22");
                mc.ResumeCourse().Click();

                System.Threading.Thread.Sleep(2000);
                ci.TakeCourse().Click();

                _test.Log(LogStatus.Pass, "Assert Pass as condition is true");
                _extent.EndTest(_test);
            }
            catch (Exception e)
            {
                screenShotObj.GetScreenshot(driver, "createSurvey");
                _test.Log(LogStatus.Fail, "Assert Fail as condition is false");
                _extent.EndTest(_test);
            }

            _extent.Flush();
            _extent.Close();
        }
    }
}
