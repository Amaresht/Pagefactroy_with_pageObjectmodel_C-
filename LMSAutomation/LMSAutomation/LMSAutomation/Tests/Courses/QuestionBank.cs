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
    class QuestionBank : BaseDriver
    {
        [Test]
        public void createQuestion()
        {
            try
            {

                Pages.Courses.Courses c = new Pages.Courses.Courses(driver);
                c.CourseSelect().Click();
                CourseContent cc = new CourseContent(driver);
                cc.CourseWidget().Click();
                //TimeUnit.SECONDS.sleep(3);
                cc.CreateSurvey().Click();

                CreateSurvey cs = new CreateSurvey(driver);
                //			Test Case #01: Empty fields validation
                //logger.debug("Test Case #01: Empty fields validation");
                //TimeUnit.SECONDS.sleep(2);
                _test = _extent.StartTest("Test Case #01: Empty fields validation");
                cs.NextButton().Click();

                //TimeUnit.SECONDS.sleep(2);
                Assert.AreEqual(cs.ValidationMess1().Text, "Title is required");
                Assert.AreEqual(cs.ValidationMess2().Text, "Start Date is required");
                Assert.AreEqual(cs.ValidationMess3().Text, "End Date is required");

                //			Test Case #02: Start date is greater than end date validation check
                //logger.debug("Test Case #02: Start date is greater than end date validation check");
                //TimeUnit.SECONDS.sleep(2);
                cs.Title().SendKeys("auto");
                cs.StartDate().SendKeys("07/29/2017");
                cs.EndDate().SendKeys("07/27/2017");
                cs.NextButton().Click();

                //TimeUnit.SECONDS.sleep(2);
                Assert.AreEqual(cs.ValidationMess1().Text, "End Date must be greaterthan startdate");

                //			Test Case #03: previous date validation for start and end date
                //logger.debug("Test Case #03: previous date validation for start and end date");
                //TimeUnit.SECONDS.sleep(2);
                cs.Title().Clear();
                cs.StartDate().Clear();
                cs.EndDate().Clear();
                cs.Title().SendKeys("auto");
                cs.StartDate().SendKeys("07/20/2017");
                cs.EndDate().SendKeys("07/21/2017");
                cs.NextButton().Click();

                //TimeUnit.SECONDS.sleep(2);
                Assert.AreEqual(cs.ValidationMess1().Text, "Start Date can not be previous date");
                Assert.AreEqual(cs.ValidationMess2().Text, "End Date can not be previous date");

                //			Test Case #04: correct values
                //logger.debug("Test Case #04: correct values");
                //TimeUnit.SECONDS.sleep(2);
                cs.Title().Clear();
                cs.StartDate().Clear();
                cs.EndDate().Clear();
                cs.Title().SendKeys("auto");
                cs.StartDate().SendKeys("07/28/2017");
                cs.EndDate().SendKeys("07/31/2017");
                cs.NextButton().Click();

            }
            catch (Exception e)
            {
                //logger.error(e.getMessage());
                screenShotObj.GetScreenshot(driver, "CreateSurvey");
            }
        }


        //    @Test(priority= 2)

        //    public void createQuestion() throws InterruptedException, Exception {
        //		try {
        ////			Assessment creation with data
        //			Courses c = new Courses(driver);
        //c.courseSelect().click();
        //CourseContent cc = new CourseContent(driver);
        //TimeUnit.SECONDS.sleep(3);
        //			cc.courseWidget().click();
        //TimeUnit.SECONDS.sleep(3);

        //			cc.createSurvey().click();

        //CreateSurvey cs = new CreateSurvey(driver);
        //JavascriptExecutor js = (JavascriptExecutor)driver;

        //logger.debug("creating with correct values..");
        //			TimeUnit.SECONDS.sleep(2);
        //			cs.title().clear();
        //cs.startDate().clear();
        //cs.endDate().clear();
        //cs.title().sendKeys("auto");
        //cs.startDate().sendKeys("07/28/2017");
        //cs.endDate().sendKeys("07/31/2017");
        //cs.nextButton().click();

        //AssessmentQuestions questions = new AssessmentQuestions(driver);

        //TimeUnit.SECONDS.sleep(3);
        //			questions.newQuestion().click();

        //AddQuestion addQuestion = new AddQuestion(driver);

        //TimeUnit.SECONDS.sleep(3);
        //			addQuestion.moduleName("1_introduction");
        //			TimeUnit.SECONDS.sleep(1);
        //			addQuestion.addQuestionText("Hello this is auto generated text for question");
        //			js.executeScript("document.getElementById('txtOption-1').scrollIntoView();");
        //			TimeUnit.SECONDS.sleep(1);
        //			addQuestion.option1Data().sendKeys("1");
        //js.executeScript("document.getElementById('txtOption-2').scrollIntoView();");
        //			TimeUnit.SECONDS.sleep(1);
        //			addQuestion.option2Data().sendKeys("1");
        //js.executeScript("document.getElementById('txtOption-3').scrollIntoView();");
        //			TimeUnit.SECONDS.sleep(1);
        //			addQuestion.option3Data().sendKeys("1");
        //js.executeScript("document.getElementById('txtOption-4').scrollIntoView();");
        //			TimeUnit.SECONDS.sleep(1);
        //			addQuestion.option4Data().sendKeys("1");
        //TimeUnit.SECONDS.sleep(1);
        //			addQuestion.option4RDButton().click();

        //TimeUnit.SECONDS.sleep(1);
        //			addQuestion.weightage().sendKeys("20");
        //addQuestion.saveQuestion().click();
        //logger.debug("Question is created..");

        ////			Next to publish
        //			questions.nextToPublish().click();

        //		}catch (Exception e) {
        //			logger.error(e.getMessage());
        //			screenShotObj.getScreenshot(driver, "AddQuestion");	
        //		}
        //	}


        //    @Test(priority= 3)

        //    public void publishAssessment() throws Exception
        //{
        //		try {
        //        //			Test Case1: Publish Assessment Acknowledge check validation message check
        //        logger.debug("Publish Assessment Acknowledge check validation message check");

        //        //			.//*[@id='divrendercontent']/div/div[4]/div[1]/ul/li[2]/div/div/div[2]/a[2]
        //        Courses c = new Courses(driver);
        //        TimeUnit.SECONDS.sleep(1);
        //        c.courseSelect().click();

        //        TimeUnit.SECONDS.sleep(1);
        //        driver.findElement(By.xpath(".//*[@id='divrendercontent']/div/div[4]/div[1]/ul/li[2]/div/div/div[2]/a[2]")).click();

        //        com.pages.courses.CreateAssessment ca = new com.pages.courses.CreateAssessment(driver);
        //        TimeUnit.SECONDS.sleep(1);
        //        ca.publish().click();

        //        PublishAssessment pa = new PublishAssessment(driver);
        //        TimeUnit.SECONDS.sleep(1);
        //        pa.publish().click();

        //        TimeUnit.SECONDS.sleep(1);
        //        pa.sweetAlertYesButton().click();

        //        JavascriptExecutor js = (JavascriptExecutor)driver;
        //        js.executeScript("document.getElementById('divValidMsg').scrollIntoView();");
        //        Assert.assertEquals(pa.validationMessage().getText(), "Please Check the Acknowledge.");

        //        //			Test Case2: Publishing the Assessment
        //        logger.debug("Publishing the Assessment");

        //        TimeUnit.SECONDS.sleep(3);
        //        pa.acknowledge().click();
        //        pa.publish().click();

        //        TimeUnit.SECONDS.sleep(1);
        //        pa.sweetAlertYesButton().click();

        //    }catch(Exception e) {
        //        logger.error(e.getMessage());
        //        screenShotObj.getScreenshot(driver, "publishAssessment");
        //    }

        //}
    }
}
