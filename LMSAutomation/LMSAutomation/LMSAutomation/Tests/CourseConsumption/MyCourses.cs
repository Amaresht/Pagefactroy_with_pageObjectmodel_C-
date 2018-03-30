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
    class MyCourses : BaseDriver
    {
        [Test]
        [TestCase("sample course1")]
        public void MycourseTest(string coursename)
        {
            try
            {
                Pages.Courses.Courses c = new Pages.Courses.Courses(driver);
                System.Threading.Thread.Sleep(2000);
                c.CourseName().SendKeys(coursename);
                c.CourseSelect().Click();
                CourseContent cc = new CourseContent(driver);
                System.Threading.Thread.Sleep(2000);
                cc.CourseWidget().Click();
                cc.CreateSurvey().Click();

                CreateSurvey cs = new CreateSurvey(driver);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                //			Test Case #01: Empty fields validation
                //logger.debug("Test Case #01: Empty fields validation");
                _test = _extent.StartTest("Test Case #01: Empty fields validation in Survey create");
                cs.NextButton().Click();
            }
            catch (Exception e)
            {

            }
        }
    }
}
