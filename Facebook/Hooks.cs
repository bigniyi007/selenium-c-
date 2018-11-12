using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SeleQuick_Framework.Base;
using SeleQuick_Framework.Helper;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Facebook
{
    [Binding]
    public class Hooks 
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private static IWebDriver _driver;

        public static IWebDriver driver
        {

            get
            {

                return _driver;
            }
            set
            {
                _driver = value;
            }
        }
        // I ADDED THIS HERE. 
        string currentScenarioTitle = ScenarioContext.Current.ScenarioInfo.Title.ToString();
         string  featurename = FeatureContext.Current.FeatureInfo.Title.ToString();
        string scenarioname = ScenarioContext.Current.ScenarioInfo.Title.ToString();
        
 
        [BeforeTestRun]
        public static void BeforeTest()
        {
           HtmlReports.SetUpHtmlReport();
           Console.WriteLine();
        }

        [AfterTestRun]
        public static void Aftertest()
        {
            // flush the report here.
            HtmlReports.FlushCloseHtmlReport();
            //Console.WriteLine();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            
           // Log.Write("Executing Scenario " + scenarioname);
            HtmlReports.StartHtmlReports(scenarioname,null,featurename + " Feature");
            Console.WriteLine("Executing::" + TestContext.CurrentContext.Test.Name);


            //Log.Write("");
            //Log.Write("=======Executing::" + TestContext.CurrentContext.Test.Name.ToUpper() + "=========");


            //InitializeSettings();
            //NaviateSite();

            driver = DriverContext.Driver;
        }

        [AfterScenario]
        public void AfterScenario()

        {
            // process report here 
            //HtmlReports.ProcesHtmlReports(TestContext.CurrentContext.Result.Outcome.Status, FolderBuilder.FailedSubFolder + "\\Failed " +
            //TestContext.CurrentContext.Test.Name + " screenshot " + ".png");
            Console.WriteLine();

            if (ScenarioContext.Current.TestError != null)
            {
                HtmlReports.ProcesSpecFlowReports("fail",currentScenarioTitle , currentScenarioTitle);
                ScreenShotTaker();
            }
            else{
                HtmlReports.ProcesSpecFlowReports(null, null, currentScenarioTitle);
            }
                        //TODO: implement logic that has to run after executing each scenario
        }
         void ScreenShotTaker()
        {
              var capturedimage = ((ITakesScreenshot)driver).GetScreenshot();

                   capturedimage.SaveAsFile(FolderBuilder.FailedSubFolder + "\\Failed " +
                "DEMO" + " screenshot " + ".png", ScreenshotImageFormat.Png);
                
        }
        private void TakeScreenshot(IWebDriver driver)
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









