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

namespace LMSAutomation.Tests.Courses
{
    class UploadContent : BaseDriver
    {
        [Test]
        [TestCase("sample course1")]
        public void UploadContentTest(String coursename)
        {
            try
            {
                Pages.Courses.Courses c = new Pages.Courses.Courses(driver);
                System.Threading.Thread.Sleep(2000);
                c.CourseName().SendKeys(coursename);
                c.CourseSelect().Click();
                CourseContent cc = new CourseContent(driver);
                System.Threading.Thread.Sleep(2000);
                cc.ModuleWidget().Click();
                cc.UploadContent().Click();

                Pages.Courses.UploadContent uc = new Pages.Courses.UploadContent(driver);
                //			Test Case #01: Empty fields validation
                //logger.debug("Test Case #01: Empty fields validation");
                //			TimeUnit.SECONDS.sleep(2);
                _test = _extent.StartTest("Test Case #01: Empty fields validation in upload content");
                uc.SubmitButton().Click();

                Assert.AreEqual(uc.ValidationMess1().Text, "Please enter File name");
                Assert.AreEqual(uc.ValidationMess2().Text, "Duration cannot be empty");
                Assert.AreEqual(uc.ValidationMess3().Text, "Please select Module File");
                _test.Log(LogStatus.Pass, "Assert Pass as condition is true");
                _extent.EndTest(_test);

                //			Valid data
                // logger.debug("Valid data");
                _test = _extent.StartTest("Test Case #02: Valid data");
                uc.FileName().SendKeys(prop.getProperty("uploadcontentFileName"));
                uc.Duration().SendKeys(prop.getProperty("durationforUploaded"));
                uc.SelectAFile().Click();
                // FileUpload.uploadFile(prop.getProperty("uploadcontentPath"));
                //SendKeys.SendWait(prop.getProperty("uploadcontentPath"));
                //SendKeys.SendWait(@"{Enter}");
                Utility.FileUpload.UploadFile(@"C:\Users\Ansuman\Desktop\172.16.1.99\LMS\Instructure_Login_Test_17_Nov_18.doc");
                uc.SubmitButton().Click();
                _test.Log(LogStatus.Pass, "Assert Pass as condition is true");
                _extent.EndTest(_test);
                // TimeUnit.SECONDS.sleep(5);
            }
            catch (Exception e)
            {
                // logger.error(e.getMessage());
                screenShotObj.GetScreenshot(driver, "UploadCOntent");
                _test.Log(LogStatus.Fail, "Assert Fail as condition is false");
                _extent.EndTest(_test);
            }

            _extent.Flush();
            _extent.Close();
        }

        [Test]
        [TestCase("course sample4")]
        public void AllDocsUpload(string coursename) {
            try {
                Pages.Courses.Courses c = new Pages.Courses.Courses(driver);
                System.Threading.Thread.Sleep(2000);
                c.CourseName().SendKeys(coursename);
                c.CourseSelect().Click();
                CourseContent cc = new CourseContent(driver);
                System.Threading.Thread.Sleep(2000);
                _test = _extent.StartTest("Test Case#01: All type of Docs Upload functionality check");

                Pages.Courses.UploadContent uc = new Pages.Courses.UploadContent(driver);
                System.IO.DirectoryInfo root = new System.IO.DirectoryInfo(@"D:\Prakash\Ez2enlight\LMSAutomation\LMSAutomation\Data\AllDocs");
                var files = root.GetFileSystemInfos("*.*").ToArray();
                foreach (var file in files)
                {
                    cc.UploadContent().Click();
                    uc.FileName().SendKeys(file.Name);
                    uc.Duration().SendKeys(prop.getProperty("durationforUploaded"));
                    uc.SelectAFile().Click();
                    Utility.FileUpload.UploadFile(@"D:\Prakash\Ez2enlight\LMSAutomation\LMSAutomation\Data\AllDocs\" + file.Name);
                    uc.SubmitButton().Click();
                    cc.SuccessAlert().Click();
                }

                cc.CheckBoxForPublish().Click();
                cc.PublishButton().Click();
                PublishCourse objPublishCourse = new PublishCourse(driver);
                objPublishCourse.FirstMod().Click();
                Assert.AreEqual(files.Length, objPublishCourse.TotalImagesFiles().Count);
                _test.Log(LogStatus.Pass, "Upload files are successfully visible in preview");
                _extent.EndTest(_test);
            }
            catch(Exception e) {
                screenShotObj.GetScreenshot(driver, "UploadCOntent" + e.Message);
                _test.Log(LogStatus.Fail, "Some files are missing in preview course");
                _extent.EndTest(_test);
            }

            _extent.Flush();
            _extent.Close();
        }
    }
}
