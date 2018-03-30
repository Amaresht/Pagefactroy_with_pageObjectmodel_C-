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
    class AddSurvey : BaseDriver
    {

        [Test]
        [TestCase("sample course1")]
        public void createSurvey(string coursename)
        {
            if (prop.getProperty("surveyTest").Trim().Equals("false"))
                Assert.Ignore("Survey create omitted.");
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

                Assert.AreEqual(cs.ValidationMess1().Text, "Title is required");
                //Assert.AreEqual(cs.ValidationMess2().Text, "Start Date is required");
                //Assert.AreEqual(cs.ValidationMess3().Text, "End Date is required");
                _test.Log(LogStatus.Pass, "Assert Pass as condition is true");
                _extent.EndTest(_test);
                //			Test Case #02: Start date is greater than end date validation check
                //logger.debug("Test Case #02: Start date is greater than end date validation check");
                //cs.Title().SendKeys(prop.getProperty("surveyTitle"));
                //cs.StartDate().SendKeys(prop.getProperty("SurveystartDateT1"));
                //cs.EndDate().SendKeys(prop.getProperty("SurveyendDateT1"));
                //cs.NextButton().Click();
                //Assert.AreEqual(cs.ValidationMess1().Text, "End Date must be greaterthan startdate");

                ////			Test Case #03: previous date validation for start and end date
                ////logger.debug("Test Case #03: previous date validation for start and end date");
                //cs.title().clear();
                //cs.startDate().clear();
                //cs.endDate().clear();
                //cs.title().sendKeys(prop.getProperty("surveyTitle"));
                //cs.startDate().sendKeys(prop.getProperty("SurveystartDateT2"));
                //cs.endDate().sendKeys(prop.getProperty("SurveyendDateT2"));
                //TimeUnit.SECONDS.sleep(2);
                //js.executeScript("document.getElementById('btnAssessmentCreate').scrollIntoView();");
                //cs.nextButton().click();

                //Assert.assertEquals(cs.validationMess1().getText(), "Start Date can not be previous date");
                //Assert.assertEquals(cs.validationMess2().getText(), "End Date can not be previous date");
                //			Test Case #04: correct values
                //logger.debug("Test Case #04: correct values");
                //cs.title().clear();
                //cs.startDate().clear();
                //cs.endDate().clear();
                _test = _extent.StartTest("Test Case #02: Valid data");
                cs.Title().SendKeys(prop.getProperty("surveyTitle"));
                //cs.StartDate().sendKeys(prop.getProperty("SurveystartDate"));
                //cs.endDate().sendKeys(prop.getProperty("SurveyendDate"));
                js.ExecuteScript("document.getElementById('btnAssessmentCreate').scrollIntoView();");
                cs.NextButton().Click();
                _test.Log(LogStatus.Pass, "Assert Pass as condition is true");
                _extent.EndTest(_test);
            }
            catch (Exception e)
            {
                //logger.error(e.getMessage());
                screenShotObj.GetScreenshot(driver, "createSurvey");
                _test.Log(LogStatus.Fail, "Assert Fail as condition is false");
                _extent.EndTest(_test);
            }
            _extent.Flush();
            _extent.Close();
        }


//    @Test(priority= 2)

//    public void createQuestion() throws InterruptedException, Exception {
//		if(prop.getProperty("surveyTest").trim().equals("false"))
//			throw new SkipException("Create Survey skipped");
//		try {
//			JavascriptExecutor js = (JavascriptExecutor)driver;

//        AssessmentQuestions questions = new AssessmentQuestions(driver);

//        questions.newQuestion().click();

//        AddQuestion addQuestion = new AddQuestion(driver);

//        TimeUnit.SECONDS.sleep(2);
//			addQuestion.addQuestionText(prop.getProperty("addQuestionText"));
//			js.executeScript("document.getElementById('txtOption-1').scrollIntoView();");

//			addQuestion.option1Data().sendKeys(prop.getProperty("option1Data"));
//			js.executeScript("document.getElementById('txtOption-2').scrollIntoView();");
////			TimeUnit.SECONDS.sleep(1);
//			addQuestion.option2Data().sendKeys(prop.getProperty("option2Data"));
//			js.executeScript("document.getElementById('txtOption-3').scrollIntoView();");
////			TimeUnit.SECONDS.sleep(1);
//			addQuestion.option3Data().sendKeys(prop.getProperty("option3Data"));
//			js.executeScript("document.getElementById('txtOption-4').scrollIntoView();");
////			TimeUnit.SECONDS.sleep(1);
//			addQuestion.option4Data().sendKeys(prop.getProperty("option4Data"));
////			TimeUnit.SECONDS.sleep(1);
////			addQuestion.option4RDButton().click();
			
////			TimeUnit.SECONDS.sleep(1);
////			addQuestion.weightage().sendKeys("20");
//			addQuestion.saveQuestion().click();
//        logger.debug("Question is created..");
			
////			Next to publish
//			questions.nextToPublish().click();

//    }catch (Exception e) {
//			logger.error(e.getMessage());
//			screenShotObj.getScreenshot(driver, "AddQuestionInSurvey");	
//		}
//	}


//    @Test(priority= 3)

//    public void publish() throws Exception
//{
//		if(prop.getProperty("surveyTest").trim().equals("false"))
//			throw new SkipException("Create Survey skipped");
//		try {
////			Test Case1: Publish Assessment Acknowledge check validation message check
//			logger.debug("Publish Assessment Acknowledge check validation message check");
//			JavascriptExecutor js = (JavascriptExecutor)driver;

//PublishAssessment pa = new PublishAssessment(driver);
//pa.publish().click();

//pa.sweetAlertYesButton().click();

//js.executeScript("document.getElementById('divValidMsg').scrollIntoView();");
//			Assert.assertEquals(pa.validationMessage().getText(), "Please Check the Acknowledge.");
			
////			Test Case2: Publishing the Assessment
//			logger.debug("Publishing the Assessment");
			
//			pa.acknowledge().click();
//pa.publish().click();

//pa.sweetAlertYesButton().click();
			
//		}catch(Exception e) {
//			logger.error(e.getMessage());
//			screenShotObj.getScreenshot(driver, "publishSurvey");
//		}
		
//	}
//    }
    }

}
