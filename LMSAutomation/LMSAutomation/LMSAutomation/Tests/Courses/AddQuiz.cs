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

namespace LMSAutomation.Tests.Courses
{
    class AddQuiz : BaseDriver
    {

        [Test]
        [TestCase("sample course1")]
        public void CreateQuiz(String coursename)
        {
            //if(prop.getProperty("quizTest").trim().equals("false"))
            //	throw new SkipException("Create Quiz skipped");
            try
            {
                Pages.Courses.Courses c = new Pages.Courses.Courses(driver);
                System.Threading.Thread.Sleep(1000);
                c.CourseName().SendKeys(coursename);
                //TimeUnit.SECONDS.sleep(3);
                c.CourseSelect().Click();
                CourseContent cc = new CourseContent(driver);
                //TimeUnit.SECONDS.sleep(3);
                System.Threading.Thread.Sleep(1000);
                cc.AddQuiz().Click();

                CreateQuiz cq = new CreateQuiz(driver);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                //			Test Case #01: Empty fields validation
                //logger.Debug("Test Case #01: Empty fields validation");
                _test = _extent.StartTest("Test Case #01: Empty fields validation in create quiz");

                //TimeUnit.SECONDS.sleep(2);
                System.Threading.Thread.Sleep(1000);
                cq.NextButton().Click();

                //TimeUnit.SECONDS.sleep(2);
                Assert.AreEqual(cq.ValidationMess1().Text.Trim(), "Title is required");
                Assert.AreEqual(cq.ValidationMess2().Text.Trim(), "Time limit is required");
                //Assert.AreEqual(cq.ValidationMess3().Text.Trim(), "Start Date is required");
                //Assert.AreEqual(cq.ValidationMess4().Text.Trim(), "End Date is required");
                Assert.AreEqual(cq.ValidationMess3().Text.Trim(), "Pass Percentage is required");
                Assert.AreEqual(cq.ValidationMess4().Text.Trim(), "Questions Count is required");
                _test.Log(LogStatus.Pass, "Assert Pass as condition is true");
                _extent.EndTest(_test);

                //			Test Case #02: Start date is greater than end date validation check
                //logger.Debug("Test Case #02: Start date is greater than end date validation check");
                //_test = _extent.StartTest("Test Case #02: Start date is greater than end date validation check");
                ////TimeUnit.SECONDS.sleep(2);
                //cq.Title().SendKeys(prop.getProperty("quizTitle"));
                //cq.TimeLimit().SendKeys(prop.getProperty("quiztimeLimit"));
                ////cq.StartDate().SendKeys(prop.getProperty("quizstartDateT1"));
                ////cq.EndDate().SendKeys(prop.getProperty("quizendDateT1"));
                //cq.PassPercentage().SendKeys(prop.getProperty("quizpassPercentage"));
                //cq.QuestionCount().SendKeys(prop.getProperty("quizquestionCount"));
                //cq.NextButton().Click();

                ////TimeUnit.SECONDS.sleep(2);
                //Assert.AreEqual(cq.ValidationMess1().Text.Trim(), "End Date must be greaterthan startdate");
                //_test.Log(LogStatus.Pass, "Assert Pass as condition is true");
                //_extent.EndTest(_test);

                //			Test Case #03: previous date validation for start and end date
                //logger.Debug("Test Case #03: previous date validation for start and end date");
                //_test = _extent.StartTest("Test Case #03: previous date validation for start and end date");
                //// TimeUnit.SECONDS.sleep(2);
                //cq.Title().Clear();
                //cq.TimeLimit().Clear();
                //cq.StartDate().Clear();
                //cq.EndDate().Clear();
                //cq.Title().SendKeys(prop.getProperty("quizTitle"));
                //cq.TimeLimit().SendKeys(prop.getProperty("quiztimeLimit"));
                //cq.StartDate().SendKeys(prop.getProperty("quizstartDateT2"));
                //cq.EndDate().SendKeys(prop.getProperty("quizendDateT2"));
                ////TimeUnit.SECONDS.sleep(2);
                //js.ExecuteScript("document.getElementById('btnAssessmentCreate').scrollIntoView();");
                //cq.NextButton().Click();

                //// TimeUnit.SECONDS.sleep(2);
                //Assert.AreEqual(cq.ValidationMess1().Text.Trim(), "Start Date can not be previous date");
                //Assert.AreEqual(cq.ValidationMess2().Text.Trim(), "End Date can not be previous date");
                //_test.Log(LogStatus.Pass, "Assert Pass as condition is true");
                //_extent.EndTest(_test);

                //			Test Case #04: correct values
                //logger.Debug("Test Case #04: correct values");
                _test = _extent.StartTest("Test Case #02: correct values");
                //TimeUnit.SECONDS.sleep(2);
                //cq.Title().Clear();
                //cq.StartDate().Clear();
                //cq.EndDate().Clear();
                //cq.TimeLimit().Clear();
                //cq.PassPercentage().Clear();
                //cq.QuestionCount().Clear();
                cq.Title().SendKeys(prop.getProperty("quizTitle"));
                cq.TimeLimit().SendKeys(prop.getProperty("quiztimeLimit"));
                //cq.StartDate().SendKeys(prop.getProperty("quizstartDate"));
                //cq.EndDate().SendKeys(prop.getProperty("quizendDate"));
                cq.PassPercentage().SendKeys(prop.getProperty("quizpassPercentage"));
                js.ExecuteScript("document.getElementById('btnAssessmentCreate').scrollIntoView();");
                cq.QuestionCount().SendKeys(prop.getProperty("quizquestionCount"));
                cq.NextButton().Click();
                _test.Log(LogStatus.Pass, "Assert Pass as condition is true");
                _extent.EndTest(_test);

            }
            catch (Exception e)
            {
                //logger.Error(e.Message);
                screenShotObj.GetScreenshot(driver, "createQuiz");
                _test.Log(LogStatus.Fail, e.Message);
                _extent.EndTest(_test);
            }
            _extent.Flush();
            _extent.Close();
        }


        //[Test]
        public void createQuestion()
        {
            if (prop.getProperty("quizTest").Trim().Equals("false"))
                //throw new SkipException("Create Quiz skipped");
                try
                {


                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                    AssessmentQuestions questions = new AssessmentQuestions(driver);
                    _test = _extent.StartTest("AddQuestion");
                    // TimeUnit.SECONDS.sleep(3);
                    questions.NewQuestion().Click();

                    AddQuestion addQuestion = new AddQuestion(driver);

                    // TimeUnit.SECONDS.sleep(3);
                    //			addQuestion.moduleName("1_introduction");
                    //TimeUnit.SECONDS.sleep(1);
                    addQuestion.AddQuestionText(prop.getProperty("addQuestionText"));
                    js.ExecuteScript("document.getElementById('txtOption-1').scrollIntoView();");
                    addQuestion.Option1Data().SendKeys(prop.getProperty("option1Data"));
                    js.ExecuteScript("document.getElementById('txtOption-2').scrollIntoView();");
                    addQuestion.Option2Data().SendKeys(prop.getProperty("option2Data"));
                    js.ExecuteScript("document.getElementById('txtOption-3').scrollIntoView();");
                    addQuestion.Option3Data().SendKeys(prop.getProperty("option3Data"));
                    js.ExecuteScript("document.getElementById('txtOption-4').scrollIntoView();");
                    addQuestion.Option4Data().SendKeys(prop.getProperty("option4Data"));

                    //TimeUnit.SECONDS.sleep(1);
                    if (prop.getProperty("option1RDButton").Equals("1"))
                    {
                        addQuestion.Option1RDButton().Click();
                    }

                    if (prop.getProperty("option2RDButton").Equals("1"))
                    {
                        addQuestion.Option2RDButton().Click();
                    }

                    if (prop.getProperty("option3RDButton").Equals("1"))
                    {
                        addQuestion.Option3RDButton().Click();
                    }

                    if (prop.getProperty("option4RDButton").Equals("1"))
                    {
                        addQuestion.Option4RDButton().Click();
                    }

                    //TimeUnit.SECONDS.sleep(1);
                    addQuestion.Weightage().SendKeys(prop.getProperty("weightage"));
                    addQuestion.SaveQuestion().Click();
                    //logger.Debug("Question is created..");

                    //			Next to publish
                    questions.NextToPublish().Click();
                    _test.Log(LogStatus.Pass, "Assert Pass as condition is true");
                    _extent.EndTest(_test);
                }
                catch (Exception e)
                {
                    //logger.Error(e.Message);
                    screenShotObj.GetScreenshot(driver, "AddQuestion");
                }
        }


        //[Test]
        public void publish()
        {
            if (prop.getProperty("quizTest").Trim().Equals("false"))
                //throw new SkipException("Create Quiz skipped");
                try
                {
                    //			Test Case1: Publish Assessment Acknowledge check validation message check
                    //logger.Debug("Publish Assessment Acknowledge check validation message check");

                    PublishAssessment pa = new PublishAssessment(driver);
                    //TimeUnit.SECONDS.sleep(1);
                    pa.Publish().Click();

                    //TimeUnit.SECONDS.sleep(1);
                    pa.SweetAlertYesButton().Click();

                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript("document.getElementById('divValidMsg').scrollIntoView();");
                    Assert.AreEqual(pa.ValidationMessage().Text, "Please Check the Acknowledge.");

                    //			Test Case2: Publishing the Assessment
                    //logger.Debug("Publishing the Assessment");

                    //TimeUnit.SECONDS.sleep(3);
                    pa.Acknowledge().Click();
                    pa.Publish().Click();

                    //TimeUnit.SECONDS.sleep(1);
                    pa.SweetAlertYesButton().Click();
                    //TimeUnit.SECONDS.sleep(5);
                }
                catch (Exception e)
                {
                    //logger.Error(e.Message);
                    screenShotObj.GetScreenshot(driver, "publishAssessment");
                }

        }

        [Test]
        [TestCase("sample course4")]
        public void AddQAndImportQ(string coursename)
        {
            try
            {
                Pages.Courses.Courses c = new Pages.Courses.Courses(driver);
                System.Threading.Thread.Sleep(1000);
                c.CourseName().SendKeys(coursename);
                c.CourseSelect().Click();
                CourseContent cc = new CourseContent(driver);
                System.Threading.Thread.Sleep(1000);
                cc.AddQuiz().Click();

                CreateQuiz cq = new CreateQuiz(driver);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                _test = _extent.StartTest("Test Case #01: Add Quiz");
                System.Threading.Thread.Sleep(1000);
                cq.Title().SendKeys("sample Q1");
                cq.TimeLimit().SendKeys("30");
                //cq.StartDate().SendKeys(prop.getProperty("quizstartDate"));
                //cq.EndDate().SendKeys(prop.getProperty("quizendDate"));
                cq.PassPercentage().SendKeys("50");
                js.ExecuteScript("document.getElementById('btnAssessmentCreate').scrollIntoView();");
                cq.QuestionCount().SendKeys("1");
                cq.NextButton().Click();
                _test.Log(LogStatus.Pass, "Quiz is added successfully");


                _test = _extent.StartTest("Test Case #02: Import Questions in Quiz test");
                //AssessmentQuestions objAssessmentQuestions = new AssessmentQuestions(driver);
                //objAssessmentQuestions.ImportQuestions().Click();
                driver.FindElement(By.XPath(".//*[contains(@id,'addQuestion')]/../a[2]")).Click();
                System.Threading.Thread.Sleep(1000);
                ImportQuestions objImportQuestions = new ImportQuestions(driver);
                objImportQuestions.CheckBoxFirstQ().Click();
                objImportQuestions.ImportQuestion().Click();
                System.Threading.Thread.Sleep(1000);
                //objAssessmentQuestions.NextToPublish().Click();
                driver.FindElement(By.Id("btnPublishContent")).Click();
                _test.Log(LogStatus.Pass, "Successfully added Questions to Quiz");

                _test = _extent.StartTest("Test Case #03: Publish");
                System.Threading.Thread.Sleep(1000);
                PublishAssessment pa = new PublishAssessment(driver);
                pa.Publish().Click();
                pa.SweetAlertYesButton().Click();
                _test.Log(LogStatus.Pass, "Successfully published");
                _extent.EndTest(_test);
            }
            catch (Exception e)
            {
                screenShotObj.GetScreenshot(driver, "AddedQuiz" + e.Message);
                _test.Log(LogStatus.Fail, "Failed" + e.Message);
                _extent.EndTest(_test);
            }

            _extent.Flush();
            _extent.Close();
        }
    }
}
