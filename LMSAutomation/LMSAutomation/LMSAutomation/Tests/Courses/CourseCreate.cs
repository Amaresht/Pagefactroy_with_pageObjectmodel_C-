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
using LMSAutomation.Pages.CourseConsumption;

namespace LMSAutomation.Tests.Courses
{
    class CourseCreate : BaseDriver
    {

        //[Test]
        public void createCourseValidations()
        {

            Pages.Courses.Courses coursepage = new Pages.Courses.Courses(driver);
            CreateCourse createcourse = new CreateCourse(driver);
            coursepage.NewCourse().Click();

            //Test Case#01: Empty fields check
            //logger.debug("Test Case#01: Empty fields check");
            _test = _extent.StartTest("Test Case#01: Empty fields check");
            System.Threading.Thread.Sleep(1000);
            createcourse.CourseCreate().Click();
            if (createcourse.ValidationMess1().Text.Trim() == "Category is required" && createcourse.ValidationMess2().Text.Trim() == "Course name is required")
            {
                _test.Log(LogStatus.Pass, "Assert Pass as condition is true");
            }
            else
            {
                _test.Log(LogStatus.Fail, "Assert Fail as condition is Fail");
            }
            _extent.EndTest(_test);
            //     Assert.assertEquals(createcourse.validationMess1().getText(), "Category is required");
            //Assert.assertEquals(createcourse.validationMess2().getText(), "Course name is required");

            //Test Case#02: Course Name field check
            //logger.debug("Test Case#02: Course Name field check");
            _test = _extent.StartTest("Test Case#02: Course Name field check");
            createcourse.SetCategory("newCategory");
            createcourse.CourseCreate().Click();
            if (createcourse.ValidationMess1().Text == "Course name is required")
            {
                _test.Log(LogStatus.Pass, "Assert Pass as condition is true");
            }
            else
            {
                _test.Log(LogStatus.Fail, "Assert Fail as condition is Fail");
            }
            _extent.EndTest(_test);
            //Assert.assertEquals(createcourse.validationMess1().getText(), "Course name is required");

            //Test Case#03: Category Name field check
            //logger.debug("Test Case#03: Category Name field check");
            _test = _extent.StartTest("Test Case#03: Category Name field check");
            createcourse.SetCategory("--Select--");
            createcourse.CourseTitle().SendKeys("sample course auto24");
            createcourse.CourseCreate().Click();
            if (createcourse.ValidationMess1().Text == "Category is required")
            {
                _test.Log(LogStatus.Pass, "Assert Pass as condition is true");
            }
            else
            {
                _test.Log(LogStatus.Fail, "Assert Fail as condition is Fail");
            }
            _extent.EndTest(_test);
            //     Assert.assertEquals(createcourse.validationMess1().getText(), "Category is required");

            //Test Case#04: Repeated Course name validation check
            //logger.debug("Test Case#04: Repeated Course name validation check");
            _test = _extent.StartTest("Test Case#04: Repeated Course name validation check");
            createcourse.SetCategory("newCategory");
            createcourse.CourseTitle().Clear();
            createcourse.CourseTitle().SendKeys("sample course");
            createcourse.CourseCreate().Click();
            if (createcourse.ValidationMess3().Text == "Course name already exists")
            {
                _test.Log(LogStatus.Pass, "Assert Pass as condition is true");
            }
            else
            {
                _test.Log(LogStatus.Fail, "Assert Fail as condition is Fail");
            }
            _extent.EndTest(_test);
            //Assert.assertEquals(createcourse.validationMess3().getText(), "Course name already exists");

            //Test Case#05: New Course Create
            //logger.debug("Test Case#05: New Course Create");
            _test = _extent.StartTest("Test Case#05: New Course Create");
            createcourse.SetCategory("newCategory");
            createcourse.CourseTitle().Clear();
            createcourse.CourseTitle().SendKeys("sample course3");
            //createcourse.CourseImageUpload().SendKeys(@"C:\Users\Ansuman\Desktop\172.16.1.99\LMS\index.jpg");
            //TimeUnit.SECONDS.sleep(2);
            //js.executeScript("document.getElementById('btnCourseCreate').scrollIntoView();");
            createcourse.CourseCreate().Click();
            _test.Log(LogStatus.Pass, "New Course Created");
            _extent.EndTest(_test);

            _extent.Flush();
            _extent.Close();

            System.Threading.Thread.Sleep(1000);
            driver.Close();
        }

        [Test]
        public void AutoAssignCheck()
        {
            try
            {
                Pages.Courses.Courses coursepage = new Pages.Courses.Courses(driver);
                CreateCourse createcourse = new CreateCourse(driver);
                CourseContent cc = new CourseContent(driver);
                coursepage.NewCourse().Click();

                //Test Case#01: Auto Assign Check
                //logger.debug("Test Case#01: Auto Assign Check");
                _test = _extent.StartTest("Test Case#01: Auto Assign Check");
                System.Threading.Thread.Sleep(1000);
                createcourse.SetCategory("newCategory");
                createcourse.CourseTitle().SendKeys("sample course14");
                createcourse.AutoAssign().Click();
                createcourse.CourseImageUpload(@"C:\Users\Ansuman\Desktop\172.16.1.99\LMS\index.jpg");
                createcourse.CourseCreate().Click();
                System.Threading.Thread.Sleep(1000);
                string widgetSummary = cc.WidgetSummary().GetAttribute("innerText");
                string[] totalParticipants = widgetSummary.Substring(widgetSummary.LastIndexOf("Total Participants:") + "Total Participants:".Length, widgetSummary.IndexOf("Total Assignment: ") - (widgetSummary.LastIndexOf("Total Participants:") + "Total Participants:".Length)).Split('/');
                string totalParticipants1 = totalParticipants[0].Trim();
                string totalParticipants2 = totalParticipants[1].Trim();
                Assert.AreEqual(totalParticipants1, totalParticipants2);
                _test.Log(LogStatus.Pass, "Total Participants are auto assigned. Total Participants:" + totalParticipants1 + " Total auto assigned Participants:" + totalParticipants2);
                _extent.EndTest(_test);
            }
            catch
            {
                _test.Log(LogStatus.Fail, "Total Participants are not auto assigned");
                screenShotObj.GetScreenshot(driver, "AutoAssign");
            }
            _extent.Flush();
            _extent.Close();

            System.Threading.Thread.Sleep(1000);
            //driver.Close();
        }

        [Test]
        public void ElectiveCourse() {
            try
            {
                Pages.Courses.Courses coursepage = new Pages.Courses.Courses(driver);
                CreateCourse createcourse = new CreateCourse(driver);
                CourseContent cc = new CourseContent(driver);
                coursepage.NewCourse().Click();

                //Test Case#01: Elective Course Check
                //logger.debug("Test Case#01: Elective Course Check");
                _test = _extent.StartTest("Test Case#01: Elective Course Create and Validate");
                System.Threading.Thread.Sleep(1000);
                createcourse.SetCategory("newCategory");
                createcourse.CourseTitle().SendKeys("sample course22");
                createcourse.Elective().Click();
                createcourse.CourseImageUpload(@"C:\Users\Ansuman\Desktop\172.16.1.99\LMS\index.jpg");
                createcourse.CourseCreate().Click();
                System.Threading.Thread.Sleep(1000);

                cc.Module().Click();
                Module m = new Module(driver);
                m.ModuleName().SendKeys(prop.getProperty("moduleName"));
                m.SubmitButton().Click();

                System.Threading.Thread.Sleep(1000);
                cc.SuccessAlert().Click();

                System.Threading.Thread.Sleep(1000);
                cc.CheckBoxForPublish().Click();
                cc.PublishButton().Click();

                System.Threading.Thread.Sleep(5000);
                PublishCourse objPublishCourse = new PublishCourse(driver);
                objPublishCourse.PublishCourseButton().Click();
                System.Threading.Thread.Sleep(1000);
                objPublishCourse.PublishSwAlert().Click();
                System.Threading.Thread.Sleep(1000);
                cc.PublishButton().Click();

                SwitchUserLogin(driver);

                //Checking in Explore courses
                ExploreCourses objExploreCourses = new ExploreCourses(driver);
                objExploreCourses.Filter().SendKeys("sample course22");

                Assert.AreEqual("sample course22", objExploreCourses.FirstExploreCourse().Text);
                _test.Log(LogStatus.Pass, "Course is checked with " + objExploreCourses.FirstExploreCourse().Text + " Success");
                _extent.EndTest(_test);
            }
            catch(Exception e)
            {
                _test.Log(LogStatus.Fail, "Failed " + e.Message);
                screenShotObj.GetScreenshot(driver, "ErrorOccuredInElective");
            }
            _extent.Flush();
            _extent.Close();

            System.Threading.Thread.Sleep(1000);
            //driver.Close();
        }
    }
}
