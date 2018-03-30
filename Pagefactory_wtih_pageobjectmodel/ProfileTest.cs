using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Pagefactory_wtih_pageobjectmodel
{
    [TestFixture]
    public class ProfileTest:BaseTest
    {

        string TestCaseName = "ProfileTest";
        [Test]
        public void ProFileTest()
        {
            test=  extent.StartTest(TestCaseName);
            init("Mozilla");
           
            LaunchingPage lanchingpage = new LaunchingPage(driver,test);
            PageFactory.InitElements(driver, lanchingpage);
            LoginPage loginpage = lanchingpage.OpenApplication();
            takeScreenShot();
            PageFactory.InitElements(driver, loginpage);
            loginpage.Login();
            takeScreenShot();
          

            test.Log(LogStatus.Pass, TestCaseName+"Test Case is is pass");
            
        }
        [TearDown]
        public void EndTest()
        {
            extent.EndTest(test);

            extent.Flush();
            extent.Close();
        }
       
    }
}
