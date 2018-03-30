using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;

namespace Pagefactory_wtih_pageobjectmodel
{
    [TestFixture]
   public  class LoginTest:BaseTest
    {


        string TestCaseName = "LoginTest";
        
        [Test]
        public void Login()
        {
            test = extent.StartTest(TestCaseName);

            init("Mozilla");
            takeScreenShot();
            LaunchingPage lanchingpage = new LaunchingPage(driver,test);
            PageFactory.InitElements(driver, lanchingpage);
            LoginPage loginpage= lanchingpage.OpenApplication();
            takeScreenShot();
            PageFactory.InitElements(driver, loginpage);
            loginpage.Login();
            takeScreenShot();      
            test.Log(LogStatus.Pass, TestCaseName+"Test Case is pass");
           
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
