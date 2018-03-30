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
    class Courses
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        //	Buttons
        By newCourseButton = By.XPath(".//*[@id='btnCourseCreateNew']");
        By courseCategoryButton = By.XPath(".//*[@id='divrendercontent']/div[2]/div[2]/div/input[3]");
        By exportToExcelButton = By.XPath(".//*[@id='divrendercontent']/div[2]/div[2]/div/input[4]");

        //By courseSelect = By.XPath(".//*[@id='tailsGrid']/div/div[1]/div[1]/div/div[3]/center/h3/b/a");
        By courseSelect = By.XPath(".//a[contains(@class,'ng-binding')]");
        String xpathForCourseRows = ".//*[@id='tailsGrid']/div/div";
        String xpathForCourse = "div[3]/div/div[3]/center/h3/b/a";
        By selectCategoryName = By.XPath(".//*[@id='CategoryId']");
        //By courseName = By.XPath(".//*[@id='CourseName']");
        By courseName = By.XPath(".//input[contains(@class,'form-control')]");
        By search = By.XPath(".//*[@id='btnFilter']");
        By reset = By.XPath(".//*[@id='btnReset']");

        //This is delete is for first course
        By deleteCourse = By.XPath(".//*[contains(@id,'delete-')]/img");
        By firstCourseName = By.XPath(".//a[contains(@class,'ng-binding')]");

        By sweetAlterYes = By.XPath(".//button[contains(@class,'swal2-confirm swal2-styled')]");

        //filter
        By filterText = By.XPath(".//input[contains(@class,'form-control')]");

        public Courses(IWebDriver driver)
        {
            driver.Url = "http://lms.pravtek.com/Course/CourseDetailsOfCategory";
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement NewCourse()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(newCourseButton));
        }

        public IWebElement CourseSelect()
        {
            //		courseName().sendKeys("newCourse");
            //TimeUnit.SECONDS.sleep(6);
            return explicitWait.Until(ExpectedConditions.ElementIsVisible(courseSelect));
        }

        //public IWebElement FindCourseName(String courseName)
        //{
        //    List<WebElement> rows = driver.findElements(By.xpath(xpathForCourseRows));
        //    WebElement requiredCourse = null;
        //    for (WebElement el:rows)
        //    {
        //        if (el.findElement(By.xpath(xpathForCourse)).getText().equals(courseName))
        //        {
        //            requiredCourse = el.findElement(By.xpath(xpathForCourse));
        //        }
        //    }
        //    return requiredCourse;
        //}


        public IWebElement CourseCategoryButton()
        {
            return driver.FindElement(courseCategoryButton);
        }

        public IWebElement ExportToExcelButton()
        {
            return driver.FindElement(exportToExcelButton);
        }

        public void SelectCategoryName(String categoryName)
        {
            //		TimeUnit.SECONDS.sleep(3);
            IWebElement categories = explicitWait.Until(ExpectedConditions.ElementToBeClickable(selectCategoryName));
            SelectElement categorieslist = new SelectElement(categories);
            categorieslist.SelectByText(categoryName);
        }

        public IWebElement CourseName()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(courseName));
        }

        public IWebElement Search()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(search));
            
        }

        public IWebElement Reset()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(reset));
           
        }

        //public IWebElement selectCategoryName()
        //{
        //    WebElement categories = explicitWait.until(ExpectedConditions.presenceOfElementLocated(selectCategoryName));
        //    Select categorieslist = new Select(categories);
        //    return categorieslist.getFirstSelectedOption();
        //}

        public IWebElement SearchCourse()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(courseSelect));
           
        }

        public IWebElement DeleteCourse()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(deleteCourse));
        }

        public IWebElement SweetAlterYes()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(sweetAlterYes));
        }

        public IWebElement FilterText()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(filterText));
        }

        public IWebElement FirstCourseName()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(firstCourseName));
        }
    }
}
