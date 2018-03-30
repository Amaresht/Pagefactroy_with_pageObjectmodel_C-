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


namespace LMSAutomation.Pages.Categories
{
    class CreateCourseCategory
    {
        IWebDriver driver;

        By newCategoryButton = By.XPath(".//*[@id='divrendercontent']/div[1]/div[2]/div/input[1]");
        By categoryRows = By.XPath(".//*[@id='tilesGrid']/div/div/div");
        By checkCategoryHeading = By.XPath(".//*[@id='divrendercontent']/div[1]/div[1]/span");
        By tilesView = By.XPath(".//*[@id='divrendercontent']/div[1]/div[4]/span[1]");
        By gridView = By.XPath(".//*[@id='divrendercontent']/div[1]/div[4]/span[2]");
        By gridCategoryRows = By.XPath(".//*[@id='divrendercontent']/div[3]/div/table/tbody/tr");
        By categoryName = By.XPath(".//*[@id='CategoryName']");
        By isActiveField = By.XPath(".//*[@id='IsActive']");
        By createButton = By.XPath(".//*[@id='btnCreateCourseCategory']");
        By cancelButton = By.XPath(".//*[@id='btnCancelCourseCategory']");
        By alreadyExistsVal = By.XPath(".//*[@id='CategoryNameError']");
        By validationMess = By.XPath(".//*[@id='crsecatvalidation']/div/p");

        public CreateCourseCategory(IWebDriver driver)
        {
            driver.Url = "http://lms.pravtek.com/CourseCategory/coursecategorydetails";
            this.driver = driver;
        }

        public IWebElement NewCategoryButton()
        {
            return driver.FindElement(newCategoryButton);
        }

        public IWebElement CategoryName()
        {
            return driver.FindElement(categoryName);
        }

        public IWebElement CreateButton()
        {
            return driver.FindElement(createButton);
        }

        public IWebElement CancelButton()
        {
            return driver.FindElement(cancelButton);
        }

        public IWebElement AlreadyExistsVal()
        {
            return driver.FindElement(alreadyExistsVal);
        }

        //public void setIsActiveField(String name)
        //{
        //    WebElement categories = explicitWait.until(ExpectedConditions.elementToBeClickable(isActiveField));
        //    Select categorieslist = new Select(categories);
        //    categorieslist.selectByVisibleText(name);
        //}

        public IWebElement ValidationMess()
        {
            return driver.FindElement(validationMess);
        }
    }
}
