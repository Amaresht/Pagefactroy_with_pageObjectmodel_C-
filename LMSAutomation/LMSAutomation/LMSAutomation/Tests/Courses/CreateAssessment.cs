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
using log4net;

namespace LMSAutomation.Tests.Courses
{
    class CreateAssessment : BaseDriver
    {
        [Test]
        [TestCase("sample course1")]
        public void Createassessment(String coursename)
        {
            //if(prop.getProperty("AssessmentTest").Trim().Equals("false"))
            //throw new SkipException("create Assessment skipped");
            try
            {
                Pages.Courses.Courses c = new Pages.Courses.Courses(driver);
                c.CourseName().SendKeys(coursename);
                c.CourseSelect().Click();
                CourseContent cc = new CourseContent(driver);
                cc.CourseWidget().Click();

                cc.CreateAssessment().Click();

                Pages.Courses.CreateAssessment ca = new Pages.Courses.CreateAssessment(driver);

                //			Test Case #01: Check all field validation message
                //logger.debug("Test Case #01: Check all field validation message");
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                //TimeUnit.SECONDS.sleep(2);
                js.ExecuteScript("document.getElementById('btnAssessmentCreate').scrollIntoView();");
                ca.NextButton().Click();
                //  TimeUnit.SECONDS.sleep(2);
                js.ExecuteScript("document.getElementById('StripDiv').scrollIntoView();");
                //Verify.verify(ca.validationMess1().Text.Equals("Title is required"));
                Assert.AreEqual(ca.ValidationMess1().Text, "Title is required");
                Assert.AreEqual(ca.ValidationMess2().Text, "Time limit is required");
                Assert.AreEqual(ca.ValidationMess3().Text, "Start Date is required");
                Assert.AreEqual(ca.ValidationMess4().Text, "End Date is required");
                Assert.AreEqual(ca.ValidationMess6().Text, "Questions Count is required");
                Assert.AreEqual(ca.ValidationMess5().Text, "Pass Percentage is required");

                //			Test Case #02: Check the date validation by checking from date is greater
                //logger.debug("Test Case #02: Check the date validation by checking from date is greater");
                ca.Title().SendKeys(prop.getProperty("assessmentTitle"));
                ca.TimeLimit().SendKeys(prop.getProperty("assessmenttimeLimit"));
                ca.StartDate().SendKeys(prop.getProperty("assessmentstartDateT1"));
                ca.EndDate().SendKeys(prop.getProperty("assessmentendDateT1"));
                ca.PassPercentage().SendKeys(prop.getProperty("assessmentpassPercentage"));
                ca.QuestionsCount().SendKeys(prop.getProperty("assessmentquestionsCount"));
                ca.MaxAttempts().SendKeys(prop.getProperty("assessmentmaxAttempts"));
                ca.NextButton().Click();
                Assert.AreEqual(ca.ValidationMess1().Text, "End Date must be greaterthan startdate");


                //			Test Case #03: Check the previous date validation for start date and end date.
                //logger.debug("Test Case #03: Check the previous date validation for start date and end date");
                ca.Title().Clear();
                ca.TimeLimit().Clear();
                ca.StartDate().Clear();
                ca.EndDate().Clear();
                ca.PassPercentage().Clear();
                ca.QuestionsCount().Clear();
                ca.MaxAttempts().Clear();
                ca.Title().SendKeys(prop.getProperty("assessmentTitle"));
                ca.TimeLimit().SendKeys(prop.getProperty("assessmenttimeLimit"));
                ca.StartDate().SendKeys(prop.getProperty("assessmentstartDateT2"));
                ca.EndDate().SendKeys(prop.getProperty("assessmentendDateT2"));
                ca.PassPercentage().SendKeys(prop.getProperty("assessmentpassPercentage"));
                ca.QuestionsCount().SendKeys(prop.getProperty("assessmentquestionsCount"));
                ca.MaxAttempts().SendKeys(prop.getProperty("assessmentmaxAttempts"));
                js.ExecuteScript("document.getElementById('btnAssessmentCreate').scrollIntoView();");
                ca.NextButton().Click();
                js.ExecuteScript("document.getElementById('StripDiv').scrollIntoView();");
                Assert.AreEqual(ca.ValidationMess1().Text, "Start Date can not be previous date");
                Assert.AreEqual(ca.ValidationMess2().Text, "End Date can not be previous date");

                //			Assessment creation with data
                //logger.debug("Creating assessment with data");
                ca.Title().Clear();
                ca.TimeLimit().Clear();
                ca.StartDate().Clear();
                ca.EndDate().Clear();
                ca.PassPercentage().Clear();
                ca.QuestionsCount().Clear();
                ca.MaxAttempts().Clear();
                ca.Title().SendKeys(prop.getProperty("assessmentTitle"));
                ca.TimeLimit().SendKeys(prop.getProperty("assessmenttimeLimit"));
                ca.StartDate().SendKeys(prop.getProperty("assessmentstartDate"));
                ca.EndDate().SendKeys(prop.getProperty("assessmentendDate"));
                ca.PassPercentage().SendKeys(prop.getProperty("assessmentpassPercentage"));
                ca.QuestionsCount().SendKeys(prop.getProperty("assessmentquestionsCount"));
                ca.MaxAttempts().SendKeys(prop.getProperty("assessmentmaxAttempts"));
                js.ExecuteScript("document.getElementById('btnAssessmentCreate').scrollIntoView();");
                ca.NextButton().Click();
            }
            catch (Exception e)
            {
                //logger.error(e.getMessage());
                screenShotObj.GetScreenshot(driver, "creatingAssessment");
            }
        }


        [Test]

        public void CreateQuestion()
        {
            //if(prop.getProperty("AssessmentTest").trim().Equals("false"))
            //throw new SkipException("create Assessment skipped");
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                AssessmentQuestions questions = new AssessmentQuestions(driver);

                //TimeUnit.SECONDS.sleep(3);
                questions.NewQuestion().Click();

                AddQuestion addQuestion = new AddQuestion(driver);

                //TimeUnit.SECONDS.sleep(5); // Data load will get time
                addQuestion.ModuleName(prop.getProperty("moduleName"));
                //TimeUnit.SECONDS.sleep(2);
                addQuestion.AddQuestionText(prop.getProperty("addQuestionText"));
                js.ExecuteScript("document.getElementById('txtOption-1').scrollIntoView();");

                addQuestion.Option1Data().SendKeys(prop.getProperty("option1Data"));
                js.ExecuteScript("document.getElementById('txtOption-2').scrollIntoView();");

                addQuestion.Option2Data().SendKeys(prop.getProperty("option2Data"));
                js.ExecuteScript("document.getElementById('txtOption-3').scrollIntoView();");

                addQuestion.Option3Data().SendKeys(prop.getProperty("option3Data"));
                js.ExecuteScript("document.getElementById('txtOption-4').scrollIntoView();");

                addQuestion.Option4Data().SendKeys(prop.getProperty("option4Data"));

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

                addQuestion.Weightage().SendKeys(prop.getProperty("weightage"));
                addQuestion.SaveQuestion().Click();
                //logger.debug("Question is created..");

                //			Next to publish
                questions.NextToPublish().Click();

            }
            catch (Exception e)
            {
                //logger.error(e.getMessage());
                screenShotObj.GetScreenshot(driver, "AddQuestion");
            }
        }


        [Test]

        public void PublishAssessment()
        {
            //if(prop.getProperty("AssessmentTest").trim().Equals("false"))
            //throw new SkipException("create Assessment skipped");
            try
            {
                //			Test Case1: Publish Assessment Acknowledge check validation message check
                //logger.debug("Publish Assessment Acknowledge check validation message check");

                PublishAssessment pa = new PublishAssessment(driver);
                pa.Publish().Click();

                pa.SweetAlertYesButton().Click();

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("document.getElementById('divValidMsg').scrollIntoView();");
                Assert.AreEqual(pa.ValidationMessage().Text, "Please Check the Acknowledge.");

                //			Test Case2: Publishing the Assessment
                //logger.debug("Publishing the Assessment");

                pa.Acknowledge().Click();
                pa.Publish().Click();

                pa.SweetAlertYesButton().Click();
                //TimeUnit.SECONDS.sleep(5);

            }
            catch (Exception e)
            {
                //logger.error(e.getMessage());
                screenShotObj.GetScreenshot(driver, "publishAssessment");
            }

        }
    }
}
