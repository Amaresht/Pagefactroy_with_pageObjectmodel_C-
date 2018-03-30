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
using System.Windows.Forms;
using LMSAutomation.Utility;

namespace LMSAutomation.Tests.Courses
{
    class UploadCaptivateTest : BaseDriver
    {
        [Test]
        [TestCase("sample course1")]
        public void UploadCaptivate(String coursename)
        {
            try
            {
                Pages.Courses.Courses c = new Pages.Courses.Courses(driver);
                System.Threading.Thread.Sleep(2000);
                c.CourseName().SendKeys(coursename);
                c.CourseSelect().Click();
                CourseContent cc = new CourseContent(driver);

                driver.Navigate().Refresh();

                System.Threading.Thread.Sleep(2000);
                cc.CourseWidget().Click();
                cc.UploadCaptivate().Click();

                UploadCaptivate cp = new UploadCaptivate(driver);
                //			Test Case #01: Empty fields validation
                //logger.debug("Test Case #01: Empty fields validation");
                _test = _extent.StartTest("Test Case #01: Empty fields validation in captivate course");
                cp.SubmitButton().Click();

                Assert.AreEqual(cp.ValidationMess().Text, "Please enter File name");
                _test.Log(LogStatus.Pass, "Assert Pass as condition is true");
                _extent.EndTest(_test);

                //	logger.debug("Test Case #02: check file type");
                _test = _extent.StartTest("Test Case #02: check file type");
                cp.FileName().SendKeys("sampleFile");
                cp.SubmitButton().Click();
                Assert.AreEqual(driver.SwitchTo().Alert().Text, "Please Select Zip File");
                driver.SwitchTo().Alert().Accept();
                driver.SwitchTo().DefaultContent();
                _test.Log(LogStatus.Pass, "Assert Pass as condition is true");
                _extent.EndTest(_test);

                //  logger.debug("Valid data");
                _test = _extent.StartTest("Test Case #03: Valid captivate upload check");
                cp.FileName().Clear();
                cp.FileName().SendKeys("sampleFile");
                cp.SelectFileButton().Click();
                FileUpload.UploadFile(@"C:\Users\Ansuman\Desktop\172.16.1.99\LMS\peace.zip");
                cp.SubmitButton().Click();
                _test.Log(LogStatus.Pass, "Assert Pass as condition is true");
                _extent.EndTest(_test);
            }
            catch (Exception e)
            {
                //logger.error(e.GetMessage());
                screenShotObj.GetScreenshot(driver, "UploadCaptivate");
                _test.Log(LogStatus.Fail, "Assert Fail as condition is false");
                _extent.EndTest(_test);
            }
            _extent.Flush();
            _extent.Close();
        }
    }
}
