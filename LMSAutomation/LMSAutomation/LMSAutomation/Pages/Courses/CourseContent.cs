using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSAutomation.Pages.Courses
{
    class CourseContent
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        By courseWidget = By.XPath(".//*[@id='courseWidget']");

        //	Course Widget items
        By addParticipants = By.XPath(".//*[@id='addParticipants']");
        By createAssignment = By.XPath(".//*[@id='btnassignment']");
        By createAssessment = By.XPath(".//*[@id='dvcoursewidgets']/div[1]/button[3]");
        //	By createSurvey = By.XPath(".//*[@id='dvcoursewidgets']/div[1]/button[4]");
        By createSurvey = By.XPath(".//*[@id='dvcoursewidgets']/div[1]/button[4]");
        By manageAccolades = By.XPath(".//*[@id='dvcoursewidgets']/div[1]/button[5]");
        By uploadCaptivate = By.XPath(".//*[@id='uploadCaptivateContnetId']");

        //	Module Widget
        //	By moduleWidget = By.XPath(".//*[@id='divrendercontent']/div/div[4]/div[1]/ul/li[1]/div/div/div[2]/a[1]");
        //By moduleWidget = By.XPath(".//*[@id='divrendercontent']/div/div[5]/div[1]/ul/li/div/div/div[2]/a[1]");
        By moduleWidget = By.XPath(".//*[contains(@class, 'moduleWidget')]/img");
        By uploadContent = By.XPath(".//*[@id='uploadContnetId']");
        By questionBank = By.XPath(".//*[@id='dvModulewidgets']/div[1]/button[2]");
        By addQuiz = By.XPath(".//*[@id='dvModulewidgets']/div[1]/button[3]");

        By module = By.XPath(".//*[@id='addModuleButton']");
        By editCourse = By.XPath(".//*[@id='courseEdit']");

        //Widget summary
        By widgetSummary = By.XPath(".//*[@id='dvDefaultwidgets']/div");

        //Publish
        By checkBoxForPublish = By.XPath(".//*[@id='dvModulewidgets']/input");
        By publishButton = By.XPath(".//*[@id='dvModulewidgets']/button");

        //SuccessAlert
        By successAlert = By.XPath(".//button[contains(@class,'swal2-confirm swal2-styled')]");

        public CourseContent(IWebDriver driver)
        {
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(180));
        }

        public IWebElement CourseWidget()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(courseWidget));
        }

        public IWebElement ModuleWidget()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(moduleWidget));
        }

        public IWebElement AddParticipants()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(addParticipants));
        }

        public IWebElement CreateAssignment()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(createAssignment));
        }

        public IWebElement CreateAssessment()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(createAssessment));
        }

        public IWebElement Module()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(module));
        }

        public IWebElement EditCourse()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(editCourse));
        }

        public IWebElement CreateSurvey()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(createSurvey));
        }

        public IWebElement ManageAccolades()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(manageAccolades));
        }

        public IWebElement AddQuiz()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(addQuiz));
        }

        public IWebElement UploadContent()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(uploadContent));
        }

        public IWebElement UploadCaptivate()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(uploadCaptivate));
        }

        public IWebElement WidgetSummary() {
            return explicitWait.Until(ExpectedConditions.ElementIsVisible(widgetSummary));
        }

        public IWebElement CheckBoxForPublish()
        {
            return explicitWait.Until(ExpectedConditions.ElementIsVisible(checkBoxForPublish));
        }

        public IWebElement PublishButton()
        {
            return explicitWait.Until(ExpectedConditions.ElementIsVisible(publishButton));
        }

        public IWebElement SuccessAlert()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(successAlert));
        }
    }
}
