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
    class CourseMainContentView : BaseDriver
    {
        [Test]
        public void CourseView()
        {
            try
            {
                _test = _extent.StartTest("Test Case #01: Course View by learner");
                Pages.CourseConsumption.MyCourses mc = new Pages.CourseConsumption.MyCourses(driver);
                Pages.CourseConsumption.CourseMainContent objCourseMainContent = new Pages.CourseConsumption.CourseMainContent(driver);

                System.Threading.Thread.Sleep(2000);
                mc.CourseFilter().SendKeys("Course22");
                mc.ResumeCourse().Click();

                System.Threading.Thread.Sleep(2000);
                int totalMod = objCourseMainContent.TotalModules();
                for (int i = 2; i <= totalMod; i++) {
                    int totalDoc = objCourseMainContent.TotalDocsInModule(i.ToString());
                    System.Threading.Thread.Sleep(2000);
                    objCourseMainContent.ModuleExpand(i.ToString()).Click();
                    for (int j = 2; j <= totalDoc; i++) {
                        System.Threading.Thread.Sleep(2000);
                        objCourseMainContent.ModuleDoc(i.ToString(), j.ToString()).Click();
                    }
                }

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
