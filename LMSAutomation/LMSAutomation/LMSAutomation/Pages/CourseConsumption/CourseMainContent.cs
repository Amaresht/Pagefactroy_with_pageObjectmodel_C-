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

namespace LMSAutomation.Pages.CourseConsumption
{
    class CourseMainContent
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        //Course filter
        By courseModuleList = By.XPath(".//*[@id='navigation']/div/div/div[1]/div/div/div[1]/div/div[1]/div");
        By singleModuleList = By.XPath(".//*[@id='navigation']/div/div/div[1]/div/div/div[1]/div/div[1]/div[2]/div");

        By moduleExists = By.CssSelector("img[src='/Content/Images/arrow-right.png']");

        public CourseMainContent(IWebDriver driver)
        {
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public int TotalModules() {
            return explicitWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(courseModuleList)).Count;
        }

        //public int TotalContentInnerModule(string index)
        //{
        //    return explicitWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@id='navigation']/div/div/div[1]/div/div/div[1]/div/div["+ index+"]"))).Count;
        //}

        public IWebElement ModuleExpand(string index) {
            return explicitWait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='navigation']/div/div/div[1]/div/div/div[1]/div/div[1]/div["+index+ "]/div/div/img[2]")));
        }

        public int TotalDocsInModule(string index) {
            return explicitWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@id='navigation']/div/div/div[1]/div/div/div[1]/div/div/div[" + index + "]/div"))).Count;
        }

        public IWebElement ModuleDoc(string mindex, string docindex) {
            return explicitWait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='navigation']/div/div/div[1]/div/div/div[1]/div/div/div[" + mindex + "]/div[" + docindex + "]/div/div")));
        }

    }
}
