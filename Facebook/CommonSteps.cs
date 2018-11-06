using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SeleQuick_Framework.Helper;
using System;
using TechTalk.SpecFlow;

namespace Facebook
{
    [TestFixture]
    public class CommonSteps
    {
        public static IWebDriver driver = Config.Driver;





        /// <summary>
        /// OneTimeSetup(ONCE BEFORE THE 1st TEST CASE)
        /// create blank html report
        /// 
        /// Setup(BEFORE EVERY TEST CASE)
        /// writing the testcase name to the log file 
        /// //TESTCASE Loginwithwrongusername
        /// Teardown(AFTER EVERY TEST CASE)
        /// processing the result of the testcase in the html report 
        /// writng the result of the test case in the log file
        /// 
        /// 
        ///  /// Setup(BEFORE EVERY TEST CASE)
        /// writing the testcase name to the log file 
        /// //TESTCASE Loginwithwrongpassowrd
        /// Teardown(AFTER EVERY TEST CASE)
        /// processing the result of the testcase in the html report 
        /// writng the result of the test case in the log file
        /// 
        /// 
        /// OneTimeTearDown(ONE AFTER THE LAST TEST CASE)
        /// saving the  Html report. 
        /// 
        /// </summary>

        [OneTimeSetUp]
        public void Setup()
        {

            //  extent = new ExtentReports(_myLocal, true, DisplayOrder.NewestFirst);

            HtmlReports.SetUpHtmlReport();






        }

        [OneTimeTearDown]
        public void TearDowns()
        {
            Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::::::");


            driver.SwitchTo().DefaultContent();


            HtmlReports.FlushCloseHtmlReport();


        }



        // This method is executed before everyTest case is executed and currently what it does 
        // is it logs the test case name in the log file created 
        
        [SetUp]
        public void Set()
        {


            Console.WriteLine("Executing::" + TestContext.CurrentContext.Test.Name);


            Log.Write("");
            Log.Write("=======Executing::" + TestContext.CurrentContext.Test.Name.ToUpper() + "=========");
            



            
        }





        //This method is executed after every testcase is completed 
        // currently its get the result of the testcase and add its to the html report
        // it also takes a screenshot and saves that in the html report aswell 
        // it also adds a failure log in the log file and adds the line where the error occured
        [TearDown]
        public void Teardown()
        {

            Console.WriteLine(String.Format("{0}: {1}", TestContext.CurrentContext.Test.Name,
                TestContext.CurrentContext.Result.Outcome.Status));

            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);

            }
            catch (Exception)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            }

            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorline = TestContext.CurrentContext.Result.StackTrace;
            var errormessage = TestContext.CurrentContext.Result.Message;



            LogStatus logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = LogStatus.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = LogStatus.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = LogStatus.Skip;
                    break;
                default: 
                //case TestStatus.Passed:
                    logstatus = LogStatus.Pass;
                    break;
            }
            var FailedTestCase = @"G:\Standard4(Automation)\Standard4\Failed TestCase ScreenShot\"
                                 + " Failed " + TestContext.CurrentContext.Test.Name + "screenshot" + ".png";
            var FailedTestCase1 = "G:\\Standard4(Automation)\\Standard4\\ " + TestContext.CurrentContext.Test.Name +
                                  " screenshot " + ".png";
            var ftc = @"C:\Users\tbell\OneDrive\Desktop\SeleQuick\failed\" + " Failed " +
                      TestContext.CurrentContext.Test.Name + " screenshot " + ".png";

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {


                var capturedimage = ((ITakesScreenshot)driver).GetScreenshot();

                capturedimage.SaveAsFile(FolderBuilder.FailedSubFolder + "\\Failed " +
                TestContext.CurrentContext.Test.Name + " screenshot " + ".png", ScreenshotImageFormat.Png);
                //Console.WriteLine(FailedTestCaseMessage);


            }
            HtmlReports.ProcesHtmlReports(TestContext.CurrentContext.Result.Outcome.Status, FolderBuilder.FailedSubFolder + "\\Failed " +
                TestContext.CurrentContext.Test.Name + " screenshot " + ".png");


            if (logstatus == LogStatus.Fail)
            {
                Log.Write(errormessage + "" + errorline);
                Console.WriteLine($" Error Message = {errormessage} : Error Line = {errorline}");
                Log.Write(" ");
                
                Log.Write(TestContext.CurrentContext.Test.Name + ":::::" +
                         TestContext.CurrentContext.Result.Outcome.Status);
            }
            else
            {
                Log.Write(TestContext.CurrentContext.Test.Name + ":::::" +
                          TestContext.CurrentContext.Result.Outcome.Status);
                Log.Write(" ");
            }

            var PassTestCase = @"G:\Standard4(Automation)\Standard4\Pass TestCase ScreenShot\"
                                 + " Passed " + TestContext.CurrentContext.Test.Name + "screenshot" + ".png";
            var PassTestCase1 = "G:\\Standard4(Automation)\\Standard4\\ " + TestContext.CurrentContext.Test.Name +
                                  " screenshot " + ".png";
            var ptc = @"C:\Users\tbell\OneDrive\Desktop\SeleQuick\screenshot\" + " Pass " +
                      TestContext.CurrentContext.Test.Name + " screenshot " + ".png";

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {


                var capturedimage = ((ITakesScreenshot)driver).GetScreenshot();

                capturedimage.SaveAsFile(FolderBuilder.ScreenShotSubFolder + "\\Passed " +
                TestContext.CurrentContext.Test.Name + " screenshot " + ".png", ScreenshotImageFormat.Png);
                //Console.WriteLine(FailedTestCaseMessage);


            }
            HtmlReports.ProcesHtmlReports(TestContext.CurrentContext.Result.Outcome.Status, FolderBuilder.ScreenShotSubFolder + "\\Passed " +
                TestContext.CurrentContext.Test.Name + " screenshot " + ".png");


            if (logstatus == LogStatus.Pass)
            {
                Log.Write(errormessage + "" + errorline);
                Console.WriteLine($"Passed");
                Log.Write(" ");

                Log.Write(TestContext.CurrentContext.Test.Name + ":::::" +
                         TestContext.CurrentContext.Result.Outcome.Status);
            }
            else
            {
                Log.Write(TestContext.CurrentContext.Test.Name + ":::::" +
                          TestContext.CurrentContext.Result.Outcome.Status);
                Log.Write(" ");
            }



        }
    }
}