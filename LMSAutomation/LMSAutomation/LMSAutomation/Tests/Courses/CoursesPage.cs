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
    class CoursesPage : BaseDriver
    {
        [Test]
        public void searchCourses()
        {
            try
            {

                Pages.Courses.Courses coursepage = new Pages.Courses.Courses(driver);

                //			Test Case#01: Check the reset button
                //			logger.debug("Test Case#01: Check the reset button");
                //			coursepage.selectCategoryName("Basic Programming");
                //			coursepage.courseName().sendKeys("sample course auto");
                //			coursepage.reset().click();

                //			Assert.assertEquals(coursepage.selectCategoryName().getText(), "Any", "The Category Name is not Any by default. The Reason:  ");
                //			Assert.assertEquals(coursepage.courseName().getText(), "", "The course name field should be empty by default. The Reason:  ");

                //			Test Case#02: Check the course categories button.
                //			coursepage.courseCategoryButton().click();
                //			Assert.assertEquals(driver.getTitle(), "Pravtek LMS - CourseCategoryDetails");
                //			driver.findElement(By.xpath(".//*[@id='leftLI-Course']/a")).click();


                //			Test Case#03: Search by category name and course name. Check the searched course
                //logger.debug("Search by category name and course name. Check the searched course");
                coursepage.SelectCategoryName(prop.getProperty("categoryNameforsearch"));
                coursepage.CourseName().SendKeys(prop.getProperty("courseNameforsearch"));
                //			coursepage.search().click();
                //TimeUnit.SECONDS.sleep(10); // Here thread sleep is required for loading searched courses name. Otherwise it takes the names from pre search.
                Assert.AreEqual(coursepage.SearchCourse().Text, prop.getProperty("courseNameforsearch"), "The search name is not expected. The Reason:  ");
                //coursepage.SearchCourse().Click();

                /*
                 * Pending things
                 * 1. Automation in Grid view
                 *   
                 */
                //			Test Case#03: Category Name field check

                //			Test Case#04: Repeated Course name validation check


                //			New Course Create

            }
            catch (Exception e)
            {
                //logger.error(e.getMessage());
                screenShotObj.GetScreenshot(driver, "searchCourse");
            }

        }


        //    @Test(priority= 2)

        //    public void editCourse() throws InterruptedException
        //{
        //		try {
        //        Courses coursepage = new Courses(driver);
        //        //			TimeUnit.SECONDS.sleep(5);
        //        coursepage.gridView().click();
        //        TimeUnit.SECONDS.sleep(2);
        //        List<String> courseNames = coursepage.getCourseNames();
        //        ListIterator<String> iterator = courseNames.listIterator();
        //        int i = 1;
        //        while (iterator.hasNext())
        //        {
        //            iterator.next();
        //            coursepage.courseEdit(i).click();
        //            TimeUnit.SECONDS.sleep(2);
        //            driver.get("http://lms.pravtek.com/Course/CourseDetailsOfCategory");
        //            TimeUnit.SECONDS.sleep(2);
        //            coursepage.gridView().click();
        //            i++;
        //        }
        //    } catch (Exception e) {
        //        // TODO: handle exception
        //        System.out.println(e.getMessage());
        //    }

        //}

        //@AfterTest
        //    public void closeWindow()
        //{
        //    //		driver.close();
        //}

        [Test]
        public void DeleteCourse()
        {
            try
            {
                _test = _extent.StartTest("Test Case #01: Course deleted check");
                System.Threading.Thread.Sleep(1000);
                Pages.Courses.Courses coursepage = new Pages.Courses.Courses(driver);
                coursepage.FilterText().SendKeys("sample course12");
                coursepage.DeleteCourse().Click();
                coursepage.SweetAlterYes().Click();

                System.Threading.Thread.Sleep(1000);
                coursepage.FilterText().SendKeys("sample course12");

                System.Threading.Thread.Sleep(1000);
                if (coursepage.FirstCourseName().Displayed)
                {
                    if (coursepage.FirstCourseName().Text == "sample course12")
                    {
                        _test.Log(LogStatus.Fail, "Course is not deleted");
                        _extent.EndTest(_test);
                    }
                    else {
                        _test.Log(LogStatus.Pass, "Course deleted successfully");
                        _extent.EndTest(_test);
                    }
                }
                else {
                    _test.Log(LogStatus.Pass, "Course deleted successfully");
                    _extent.EndTest(_test);
                }
            }
            catch (Exception e)
            {
                _test.Log(LogStatus.Fail, "Failed " + e.Message);
                screenShotObj.GetScreenshot(driver, "ErrorOccuredInElective");
            }
            _extent.Flush();
            _extent.Close();

            System.Threading.Thread.Sleep(1000);
        }
    }
}
