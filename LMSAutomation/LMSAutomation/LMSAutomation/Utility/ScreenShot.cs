using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSAutomation.Utility
{
    class ScreenShot
    {
        public void GetScreenshot(IWebDriver driver, String name)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screen = ts.GetScreenshot();
            screen.SaveAsFile(@"D:\Prakash\Ez2enlight\LMSAutomation\LMSAutomation\ScreenShots\" + name + ".png");
        }
    }
}
