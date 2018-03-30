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
using OpenQA.Selenium.Support.UI;

namespace LMSAutomation.Pages.Courses
{
    class UploadContent
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        By module = By.XPath(".//*[@id='hdnCourseModuleId']");
        By fileName = By.XPath(".//*[@id='txtDocumentNam']");
        By duration = By.XPath(".//*[@id='txtDuration']");
        By uploadFileCheckButton = By.XPath(".//*[@id='rbnUpload']");
        By uploadURLFileCheckButton = By.XPath(".//*[@id='rbnMap']");
        //	By selectAFile = By.xpath(".//div[contains(@class,'k-upload-button')]");
        By selectAFile = By.XPath(".//input[@id='Uploadattachments']/..");
        By submitButton = By.XPath(".//*[@id='btnSubmitDoc']");
        By cancelButton = By.XPath(".//*[@id='btnCancelDocUpload']");
        By validationMess1 = By.XPath(".//*[@id='StripDiv']/p[1]");
        By validationMess2 = By.XPath(".//*[@id='StripDiv']/p[2]");
        By validationMess3 = By.XPath(".//*[@id='StripDiv']/p[3]");

        public UploadContent(IWebDriver driver)
        {
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement Module()
        {
            return driver.FindElement(module);
        }

        public IWebElement FileName()
        {
            return driver.FindElement(fileName);
        }

        public IWebElement Duration()
        {
            return driver.FindElement(duration);
        }

        public IWebElement UploadFileCheckButton()
        {
            return driver.FindElement(uploadFileCheckButton);
        }

        public IWebElement UploadURLFileCheckButton()
        {
            return driver.FindElement(uploadURLFileCheckButton);
        }

        public IWebElement SelectAFile()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(selectAFile));
        }

        public IWebElement SubmitButton()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(submitButton));
        }

        public IWebElement CancelButton()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(cancelButton));
        }

        public IWebElement ValidationMess1()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(validationMess1));
        }

        public IWebElement ValidationMess2()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(validationMess2));
        }

        public IWebElement ValidationMess3()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(validationMess3));
        }
    }
}
