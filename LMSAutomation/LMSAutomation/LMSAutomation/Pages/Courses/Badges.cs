using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSAutomation.Pages.Courses
{
    class Badges
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        By newBadge = By.XPath(".//*[@id='btnAddBadge']");
        By title = By.XPath(".//*[@id='title']");
        By badgeLevel = By.XPath(".//*[@id='ManageBadge']");
        By proficiency = By.XPath(".//*[@id='Proficiency']");
        By level = By.XPath(".//*[@id='CourseBadge_Level']");
        By isActive = By.XPath(".//*[@id='CourseBadge_IsActive']");
        By submitButton = By.XPath(".//*[@id='btnCreateBadge']");
        By cancelButton = By.XPath(".//*[@id='btnClose']");
        By validationMessforImage = By.XPath(".//*[@id='StripDiv']/div");
        By validationMess1 = By.XPath(".//*[@id='StripDiv']/div/p[1]");
        By validationMess2 = By.XPath(".//*[@id='StripDiv']/div/p[2]");
        By validationMess3 = By.XPath(".//*[@id='StripDiv']/div/p[3]");
        By badgeImage = By.XPath(".//div[@id='myModal']/div/div/div[3]/div[10]/div/div/div");


        public Badges(IWebDriver driver)
        {
            this.driver = driver;
            explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement NewBadge()
        {
            return explicitWait.Until(ExpectedConditions.ElementIsVisible(newBadge));
        }

        public IWebElement Title()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(title));
        }

        public void BadgeLevel(String name)
        {
            IWebElement badgeLevels = explicitWait.Until(ExpectedConditions.ElementExists(badgeLevel));
            SelectElement levels = new SelectElement(badgeLevels);
            levels.SelectByValue(name);
        }

        public IWebElement Proficiency()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(proficiency));
        }

        public void Level(String name)
        {
            IWebElement Levels = explicitWait.Until(ExpectedConditions.ElementExists(level));
            SelectElement levelList = new SelectElement(Levels);
            levelList.SelectByValue(name);
        }

        public IWebElement IsActive()
        {
            return driver.FindElement(isActive);
        }

        //public void BadgeImage(String fileLocation)
        //{
        //    explicitWait.Until(ExpectedConditions.ElementToBeClickable(badgeImage)).Click();
        //    FileUpload.uploadFile(fileLocation);
        //}

        public IWebElement SubmitButton()
        {
            explicitWait.Until(ExpectedConditions.ElementIsVisible(submitButton));
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(submitButton));
        }

        public IWebElement CancelButton()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(cancelButton));
        }

        public IWebElement ValidationMess1()
        {
            return explicitWait.Until(ExpectedConditions.ElementIsVisible(validationMess1));
        }

        public IWebElement ValidationMess2()
        {
            return explicitWait.Until(ExpectedConditions.ElementIsVisible(validationMess2));
        }

        public IWebElement ValidationMess3()
        {
            return explicitWait.Until(ExpectedConditions.ElementIsVisible(validationMess3));
        }

        public IWebElement ValidationMessforImage()
        {
            return explicitWait.Until(ExpectedConditions.ElementIsVisible(validationMessforImage));
        }
    }
}
