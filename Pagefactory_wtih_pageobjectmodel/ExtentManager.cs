using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagefactory_wtih_pageobjectmodel
{
    public class ExtentManager
    {
        private static ExtentReports extent;
        public static ExtentReports getInstance()
        {
            if (extent == null)
            {
                string filename = DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".html";
                string reportpath = @"D:\Selenium\ExtentReports\" + filename;
                extent = new ExtentReports(reportpath, true, DisplayOrder.NewestFirst);
                extent.LoadConfig(@"C: \Users\Deccansoft6\Documents\visual studio 2015\Projects\Pagefactory_wtih_pageobjectmodel\Pagefactory_wtih_pageobjectmodel\Extent - Config.xml");
                extent.AddSystemInfo("Selenium Version", "Selenium 3.8").AddSystemInfo("Environment", "QA").AddSystemInfo("TesterName", "Amaresh");

            }
            return extent;
        }
    }
}
