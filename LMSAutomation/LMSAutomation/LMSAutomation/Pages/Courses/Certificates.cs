using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSAutomation.Pages.Courses
{
    class Certificates
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        By certificates = By.XPath(".//*[@id='tabCertificates']/a");
        By createCertificate = By.XPath(".//*[@id='btnCertficicate']");
        By title = By.XPath(".//*[@id='certificateTitle']");
        By badgeLevel = By.XPath(".//*[@id='manageBadge']");
        By proficiency = By.XPath(".//*[@id='certificateProficiency']");
        By next = By.XPath(".//*[@id='aNext']");
        By previous = By.XPath(".//*[@id='aPrevious']");
        By isActive = By.XPath(".//*[@id='BadgeCertificate_IsActive']");
        By submitButton = By.XPath(".//*[@id='btnCertificateSubmit']");
        By cancelButton = By.XPath(".//*[@id='btnCertificateClose']");
        By validationMessforTitle = By.XPath(".//*[@id='stripDiv1']/div");
        By validationMess = By.XPath(".//*[@id='stripDiv1']/div/p");


        public Certificates(IWebDriver driver)
        {
            this.driver = driver;
            explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        //public IWebElement Certificates()
        //{
        //    explicitWait.Until(ExpectedConditions.ElementIsVisible(certificates));
        //    return explicitWait.Until(ExpectedConditions.ElementToBeClickable(certificates));
        //}

        public IWebElement CreateCertificate()
        {
            return explicitWait.Until(ExpectedConditions.ElementIsVisible(createCertificate));
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
            return driver.FindElement(proficiency);
        }

        public IWebElement Next()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(next));
        }

        public IWebElement Previous()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(previous));
        }

        public IWebElement SubmitButton()
        {
            explicitWait.Until(ExpectedConditions.ElementIsVisible(submitButton));
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(submitButton));
        }

        public IWebElement CancelButton()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(cancelButton));
        }

        public IWebElement ValidationMess()
        {
            return explicitWait.Until(ExpectedConditions.ElementIsVisible(validationMess));
        }

        public IWebElement ValidationMessforTitle()
        {
            return explicitWait.Until(ExpectedConditions.ElementIsVisible(validationMessforTitle));
        }
    }
}
