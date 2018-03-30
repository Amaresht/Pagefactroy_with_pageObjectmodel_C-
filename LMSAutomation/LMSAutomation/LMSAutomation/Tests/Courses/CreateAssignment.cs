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
using OpenQA.Selenium.Support.UI;

namespace LMSAutomation.Tests.Courses
{
    class CreateAssignment : BaseDriver
    {

        [Test]
        [TestCase("sample course")]
        public void CreateAssigment()
        {
            try
            {
                _test = _extent.StartTest("Test Case#05: Assignment Creation");
                //if(prop.getProperty("AssignmentTest").trim().equals("false"))
                //	throw new SkipException("create Assignment skipped");
                Pages.Courses.Courses c = new Pages.Courses.Courses(driver);
                c.CourseName().SendKeys("sample course");
                c.CourseSelect().Click();

                CourseContent cc = new CourseContent(driver);
                System.Threading.Thread.Sleep(1000);
                cc.CourseWidget().Click();

                cc.CreateAssignment().Click();

                Assignment ca = new Assignment(driver);

                ca.Title().SendKeys("Auto Assignment3");
                ca.OpenDate().SendKeys("12/10/2017");
                ca.DueDate().SendKeys("12/19/2017");
                ca.AcceptTillDate().SendKeys("12/20/2017");
                ca.SubmissionType("InlineOnly");

                ca.GradeScale("Points");
                ca.GradePoints().SendKeys("10");
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("document.getElementById('StudentSubmission_AddHonorPledge').scrollIntoView();");
                ca.HonorPledge().Click();
                js.ExecuteScript("document.getElementById('StudentSubmission_AddHonorPledge').checked=true");
                js.ExecuteScript("document.getElementById('btnAssignmentCreate').scrollIntoView();");
                ca.NextToPublishAssignment().Click();
                _test.Log(LogStatus.Pass, "Assert Pass as condition is true");
            }
            catch(Exception e) {
                _test.Log(LogStatus.Fail, e.Message);
            }

            _extent.EndTest(_test);

            _extent.Flush();
            _extent.Close();

            System.Threading.Thread.Sleep(1000);
            //driver.Close();
        }

    }
}
