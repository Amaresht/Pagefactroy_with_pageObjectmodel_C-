using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSAutomation.Pages.Courses
{
    class CourseParticipants
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        By selectparticipants = By.XPath(".//*[@id='pkUserId']");
        By setParticipants = By.XPath(".//*[@id='imgAdd']");
        By startDate = By.XPath(".//*[@id='StartDate']");
        By endDate = By.XPath(".//*[@id='EndDate']");
        By subscribeParticipants = By.XPath(".//*[@id='btnSubmitParticipants']");
        By valdationMessage1 = By.XPath(".//*[@id='StripDiv']/div/p[1]");
        By valdationMessage2 = By.XPath(".//*[@id='StripDiv']/div/p[2]");
        By valdationMessage3 = By.XPath(".//*[@id='StripDiv']/div/p[3]");

        public CourseParticipants(IWebDriver driver)
        {
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public void SelectParticipants(String name)
        {
            IWebElement categories = explicitWait.Until(ExpectedConditions.ElementExists(selectparticipants));
            String index = "";
            SelectElement categorieslist = new SelectElement(categories);
            IList<IWebElement> learners = categorieslist.Options;
            foreach (IWebElement el in learners)
            {
                if (el.Text.Equals(name.Trim()))
                {
                    index = el.GetAttribute("value");
                }
            }
            if (!index.Equals(""))
                categorieslist.SelectByValue(index);
        }

        public IWebElement StartDate()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(startDate));
        }

        public IWebElement EndDate()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(endDate));
        }

        public IWebElement SubscribeParticipants()
        {
            return explicitWait.Until(ExpectedConditions.ElementToBeClickable(subscribeParticipants));
        }

        public IWebElement SetParticipants()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(setParticipants));
        }

        public IWebElement ValdationMessage1()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(valdationMessage1));
        }

        public IWebElement ValdationMessage2()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(valdationMessage2));
        }

        public IWebElement ValdationMessage3()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(valdationMessage3));
        }
    }
}
