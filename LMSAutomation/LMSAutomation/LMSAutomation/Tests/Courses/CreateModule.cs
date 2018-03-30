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
    class CreateModule : BaseDriver
    {
        [Test]
        [TestCase("sample course1")]
        public void Createmodule(String coursename)
        {
            try
            {

                Pages.Courses.Courses coursepage = new Pages.Courses.Courses(driver);
                System.Threading.Thread.Sleep(2000);
                coursepage.CourseName().SendKeys(coursename);
                // TimeUnit.SECONDS.sleep(1);
                coursepage.CourseSelect().Click();
                CourseContent cc = new CourseContent(driver);
                cc.Module().Click();

                //			Test Case 01: Required Field Validation
                // logger.debug("Test Case 01: Required Field Validation");
                _test = _extent.StartTest("Test Case 01: Required Field Validation in Module create");
                Module m = new Module(driver);
                m.SubmitButton().SendKeys(Keys.Enter);
                Assert.AreEqual(m.ValidationMess().Text, "Course Module Name is required");
                _test.Log(LogStatus.Pass, "Assert Pass as condition is true");
                _extent.EndTest(_test);

                //			Test Case 02: Valid data  
                //logger.debug("Test Case 02: Valid data");
                _test = _extent.StartTest("Test Case 02: Valid Data check");
                m.ModuleName().SendKeys(prop.getProperty("moduleName"));
                m.SubmitButton().Click();
                _test.Log(LogStatus.Pass, "Assert Pass as condition is true");
                _extent.EndTest(_test);
            }
            catch (Exception e)
            {
                //logger.error(e.getMessage());
                screenShotObj.GetScreenshot(driver, "createModule");
                _test.Log(LogStatus.Fail, "Assert Fail as condition is false");
                _extent.EndTest(_test);
            }

            _extent.Flush();
            _extent.Close();
        }
    }
}
