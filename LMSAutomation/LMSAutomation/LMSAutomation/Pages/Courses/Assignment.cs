using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSAutomation.Pages.Courses
{
    class Assignment
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        By title = By.XPath(".//*[@id='StudentSubmission_Title']");
        By openDate = By.XPath(".//*[@id='StudentSubmission_OpenDate']");
        By dueDate = By.XPath(".//*[@id='StudentSubmission_DueDate']");
        By acceptTillDate = By.XPath(".//*[@id='StudentSubmission_AcceptUntilDate']");
        By submissionType = By.XPath(".//*[@id='StudentSubmission_SubmissionType']");
        By gradeScale = By.XPath(".//*[@id='StudentSubmission_Scale']");
        By gradePoints = By.XPath(".//*[@id='StudentSubmission_GradePoint']");
        By honorPledge = By.XPath(".//*[@id='StudentSubmission_AddHonorPledge']");
        By nextToPublishAssignment = By.XPath(".//*[@id='btnAssignmentCreate']");



        public Assignment(IWebDriver driver)
        {
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement Title()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(title));
        }

        public IWebElement OpenDate()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(openDate));
        }

        public IWebElement DueDate()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(dueDate));
        }

        public IWebElement AcceptTillDate()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(acceptTillDate));
        }


        public void SubmissionType(String name)
        {
            IWebElement type = driver.FindElement(submissionType);
            SelectElement typelist = new SelectElement(type);
            typelist.SelectByValue(name);
        }

        public void GradeScale(String points)
        {
            IWebElement grade = driver.FindElement(gradeScale);
            SelectElement gradelist = new SelectElement(grade);
            gradelist.SelectByValue(points);
        }

        public IWebElement GradePoints()
        {
            return driver.FindElement(gradePoints);
        }


        public IWebElement HonorPledge()
        {
            return explicitWait.Until(ExpectedConditions.ElementIsVisible(honorPledge));
        }

        public IWebElement NextToPublishAssignment()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(nextToPublishAssignment));
        }
    }
}
