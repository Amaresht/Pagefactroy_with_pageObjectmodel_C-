using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSAutomation.Pages.Courses
{
    class AssessmentQuestions
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        By newSection = By.XPath(".//*[@id='aCreatePart']");
        By newQuestion = By.XPath(".//a[contains(@id,'addQuestion')]");
        By importQuestions = By.XPath(".//*[@id='AssessmentPart']/table/tbody/tr[1]/td[5]/a/img");
        By editSection = By.XPath(".//*[@id='AssessmentPart']/table/tbody/tr[1]/td[6]/a/img");
        By deleteSection = By.XPath(".//*[@id='AssessmentPart']/table/tbody/tr[1]/td[7]/a/img");
        By nextToPublish = By.XPath(".//*[@id='btnPublishContent']");
        By backToCourseButton = By.XPath(".//*[@id='btnAssignment1']");

        public AssessmentQuestions(IWebDriver driver)
        {
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement NewQuestion()
        {
            explicitWait.Until(ExpectedConditions.ElementIsVisible(newQuestion));
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(newQuestion));
        }

        public IWebElement NewSection()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(newSection));
        }

        public IWebElement NextToPublish()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(nextToPublish));
        }

        public IWebElement ImportQuestions()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(importQuestions));
        }

    }
}
