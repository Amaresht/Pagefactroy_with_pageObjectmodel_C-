using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace LMSAutomation.Pages.Courses
{
    class AddQuestion
    {
        IWebDriver driver;
        WebDriverWait explicitWait;

        By moduleName = By.XPath(".//select[@id='FKCourseModuleId']");
        By questionTypeSelection = By.XPath(".//*[@id='FKAssessmentQuestionTypeId']");
        By multipleAnsCheckBox = By.XPath(".//*[@id='IsMultipleAnswersCorrect']");
        By option1Data = By.XPath(".//*[@id='txtOption-1']");
        By option2Data = By.XPath(".//*[@id='txtOption-2']");
        By option3Data = By.XPath(".//*[@id='txtOption-3']");
        By option4Data = By.XPath(".//*[@id='txtOption-4']");
        By option1RDButton = By.XPath(".//*[@id='rdOption-1']");
        By option2RDButton = By.XPath(".//*[@id='rdOption-2']");
        By option3RDButton = By.XPath(".//*[@id='rdOption-3']");
        By option4RDButton = By.XPath(".//*[@id='rdOption-4']");
        By weightage = By.XPath(".//*[@id='PointValue']");
        By randomizeAns = By.XPath(".//*[@id='RandomizeAnswers']");
        By saveQuestion = By.XPath(".//*[@id='btnAddQuestion']");
        By saveAndAddAnotherQ = By.XPath(".//*[@id='btnSaveAndAddQuestion']");
        By backToCourseButton = By.XPath(".//*[@id='btnCancelQuesitonAdd']");
        //	By questionTextArea = By.id("QuestionText");

        public AddQuestion(IWebDriver driver)
        {
            this.driver = driver;
            this.explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public void ModuleName(String name)
        {
            IWebElement modules = explicitWait.Until(ExpectedConditions.ElementExists(moduleName));
            //	     Select moduleslist = new Select(modules);
            String index = "";
           
            var moduleslist = new SelectElement(modules); 
            
            IList<IWebElement> moduleNames = moduleslist.Options;
           
            foreach (IWebElement el in moduleNames)
            {
                if (el.Text.Equals(name))
                {
                    index = el.GetAttribute("value");
                }
            }
            if (index.Equals(""))
            {
                //System.out.println("Name not found.............");
                moduleslist.SelectByValue("977");
            }
            else
                moduleslist.SelectByValue(index);
        }

        public IWebElement QuestionTypeSelection()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(questionTypeSelection));
        }

        public IWebElement MultipleAnsCheckBox()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(multipleAnsCheckBox));
        }

        public IWebElement Option1Data()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(option1Data));
        }

        public IWebElement Option2Data()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(option2Data));
        }

        public IWebElement Option3Data()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(option3Data));
        }

        public IWebElement Option4Data()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(option4Data));
        }

        public IWebElement Option1RDButton()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(option1RDButton));
        }


        public IWebElement Option2RDButton()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(option2RDButton));
        }

        public IWebElement Option3RDButton()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(option3RDButton));
        }

        public IWebElement Option4RDButton()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(option4RDButton));
        }

        public IWebElement Weightage()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(weightage));
        }

        public IWebElement RandomizeAns()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(randomizeAns));
        }

        public IWebElement SaveQuestion()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(saveQuestion));
        }

        public IWebElement SaveAndAddAnotherQ()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(saveAndAddAnotherQ));
        }

        public IWebElement BackToCourseButton()
        {
            return explicitWait.Until(ExpectedConditions.ElementExists(backToCourseButton));
        }

        //	public IWebElement questionTextArea() {
        //		return driver.findElement(questionTextArea);
        //	}

        public void AddQuestionText(String name)
        {
            //		System.out.println( "Total frames size--------> " +driver.findElements(By.tagName("iframe")).size());;

            driver.SwitchTo().Frame(0);
            driver.FindElement(By.XPath(".//body")).SendKeys(name);
            driver.SwitchTo().DefaultContent();
        }
    }
}
