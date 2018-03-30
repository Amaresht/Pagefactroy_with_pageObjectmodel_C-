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
using LMSAutomation.Base;
using LMSAutomation.Pages.Categories;
using log4net;
using System.IO;
using System.Data.OleDb;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace LMSAutomation.Tests.Categories
{

    class ExcelDataParser
    {
        static string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        static string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
        static string projectPath = new Uri(actualPath).LocalPath;
        static string excelPath = projectPath + @"Data\";

        public static IEnumerable<TestCaseData> BudgetData
        {
            get
            {
                String strExcelConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=D:\\Prakash\\Ez2enlight\\LMSAutomation\\LMSAutomation\\Data\\AcheterBudgetData.xls;" + "Extended Properties='Excel 8.0;HDR=Yes'";
                List<TestCaseData> testCaseDataList = new ExcelReader().ReadExcelData(strExcelConn);

                if (testCaseDataList != null)
                    foreach (TestCaseData testCaseData in testCaseDataList)
                        yield return testCaseData;
            }
        }
    }
    //https://stackoverflow.com/questions/44260816/c-sharp-nunit-3-data-driven-from-excel
    class ExcelReader
    {
        public List<TestCaseData> ReadExcelData(string excelFile, string cmdText = "SELECT * FROM [Sheet1$]")
        {
            //if (!File.Exists(excelFile))
            //    throw new Exception(string.Format("File name: {0}", excelFile), new FileNotFoundException());
            string connectionStr = string.Format(excelFile);
            var ret = new List<TestCaseData>();
            using (var connection = new OleDbConnection(connectionStr))
            {
                connection.Open();
                var command = new OleDbCommand(cmdText, connection);
                var reader = command.ExecuteReader();
                //if (reader == null)
                //    throw new Exception(string.Format("No data return from file, file name:{0}", excelFile));
                while (reader.Read())
                {
                    var row = new List<string>();
                    var feildCnt = reader.FieldCount;
                    for (var i = 0; i < feildCnt; i++)
                        row.Add(reader.GetValue(i).ToString());
                    ret.Add(new TestCaseData(row.ToArray()));
                }
            }
            return ret;
        }
    }
    class CreateCategoryTest : BaseDriver
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(CreateCategoryTest));
        [Test]
        [TestCaseSource(typeof(ExcelDataParser), "BudgetData")]
        public void CreateCategory(string coursename)
        {
            driver.Url = "http://google.com/";
            //logger.Debug("Test Case #01: Empty fields validation");
            //CreateCourseCategory createcategory = new CreateCourseCategory(driver); 
            //System.Threading.Thread.Sleep(1000);
            //createcategory.NewCategoryButton().Click();

            //_test = _extent.StartTest("Test Case#01: Category required field validation check");
            //System.Threading.Thread.Sleep(1000);
            //createcategory.CreateButton().Click();
            //if (createcategory.ValidationMess().Text == "Category name is required")
            //{
            //    _test.Log(LogStatus.Pass, "Assert Pass as condition is true");
            //}
            //else
            //{
            //    _test.Log(LogStatus.Fail, "Assert Fail as condition is Fail");
            //}
            //_extent.EndTest(_test);

            //_test = _extent.StartTest("Test Case#02: Category name already exists validation check");
            //System.Threading.Thread.Sleep(1000);
            //createcategory.CategoryName().SendKeys(coursename);
            //createcategory.CreateButton().Click();
            //if (createcategory.AlreadyExistsVal().Text == "Category name already exists")
            //{
            //    _test.Log(LogStatus.Pass, "Assert Pass as condition is true");
            //}
            //else
            //{
            //    _test.Log(LogStatus.Fail, "Assert Fail as condition is Fail");
            //}
            //_extent.EndTest(_test);

            //_extent.Flush();
            //_extent.Close();

            //System.Threading.Thread.Sleep(1000);
            //driver.Close();
        }
    }

}
