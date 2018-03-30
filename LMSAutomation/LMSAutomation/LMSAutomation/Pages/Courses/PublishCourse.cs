using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSAutomation.Pages.Courses
{
    class PublishCourse
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        By publishCourseButton = By.XPath(".//*[@id='btnConfirm']");
        By publishSwAlert = By.XPath(".//button[contains(@class,'swal2-confirm swal2-styled')]");
        By totalImagesFiles = By.XPath(".//div[contains(@class, 'divDocuments')]/div/div/img");
        By firstMod = By.XPath(".//div[contains(@class, 'keywords')]/div");

        public PublishCourse(IWebDriver driver)
        {
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement PublishCourseButton()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(publishCourseButton));
        }

        public IWebElement PublishSwAlert()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(publishSwAlert));
        }

        public List<IWebElement> TotalImagesFiles()
        {
            return explicitWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(totalImagesFiles)).ToList();
        }

        public IWebElement FirstMod()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(firstMod));
        }

    }
}
