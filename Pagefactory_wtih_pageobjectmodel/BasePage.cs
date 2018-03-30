using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Extensions;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagefactory_wtih_pageobjectmodel
{
   public  class BasePage
    {
       public IWebDriver driver;
       public ExtentTest test;

      public void takeScreenShot()
        {
            Screenshot screen = driver.TakeScreenshot();
            string filname =  DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
            string capturepath = @"D:\Selenium\ExtentReports\ScreenShots\" + filname;
            screen.SaveAsFile(capturepath, ScreenshotImageFormat.Png);
            test.Log(LogStatus.Info, test.AddScreenCapture(capturepath));
        }

           
        }
    }

