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
using LMSAutomation.Utility;

namespace LMSAutomation.Pages.Courses
{
    class CreateCourse
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        By selectCategory = By.XPath(".//*[@id='FKCategoryId']");
        By courseName = By.XPath(".//*[@id='CourseName']");
        By courseDescription = By.XPath(".//*[@id='courseDescription']");
        By createCourse = By.XPath(".//*[@id='btnCourseCreate']");
        //By courseImage = By.XPath(".//*[@id='AddCourseForm']/div/div[2]/div[3]/div/div[2]/div[2]/div[3]/div");
        By courseImage = By.XPath(".//input[@id='UploadCourseImage']/..");
        By addDescription = By.XPath("html/body");
        By validationMess1 = By.XPath(".//*[@id='StripDiv']/div/p[1]");
        By validationMess2 = By.XPath(".//*[@id='StripDiv']/div/p[2]");
        By validationMess3 = By.XPath(".//*[@id='CourseNameError1']");

        //By check boxes
        By autoassign = By.XPath(".//*[@id='IsAutoRegister']");
        By elective = By.XPath(".//*[@id='IsElective']");
        By classroom = By.XPath(".//*[@id='IsClassRoomtraining']");

        public CreateCourse(IWebDriver driver)
        {
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public void SetCategory(String category)
        {
            IWebElement categories = explicitWait.Until(ExpectedConditions.ElementToBeClickable(selectCategory));
            SelectElement categorieslist = new SelectElement(categories);
            categorieslist.SelectByText(category.Trim());
        }

        public IWebElement CourseTitle()
        {
            return driver.FindElement(courseName);
        }

        public IWebElement CourseDescription()
        {
            return driver.FindElement(courseDescription);
        }

        public IWebElement CourseCreate()
        {
            //Actions builder = new Actions(driver);
            //builder.moveToElement(explicitWait.until(ExpectedConditions.elementToBeClickable(createCourse))).perform();
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(createCourse));
        }

        public void CourseImageUpload(string image)
        {
            driver.FindElement(courseImage).Click();
            FileUpload.UploadFile(image);
        }

        public IWebElement AddDescription()
        {
            return explicitWait.Until(ExpectedConditions.ElementIsVisible(addDescription));
            
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

        public IWebElement AutoAssign()
        {
            return driver.FindElement(autoassign);
        }

        public IWebElement Elective()
        {
            return driver.FindElement(elective);
        }

        public IWebElement Classroom()
        {
            return driver.FindElement(classroom);
        }
    }
}
