using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;
using SeleQuick_Framework.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace SeleQuick_Framework.Helper
{

    public class HtmlReports
    { 
    static ExtentReports _extent;
    static ExtentTest _test;
       


        //This Method is the first which sets all the variables 
        // HtmlReports.SetupHtmlReport();
        public static ExtentReports SetUpHtmlReport()
    {

        if (Settings.EnableReport == "Yes")
        {
            _extent = new ExtentReports(FolderBuilder.ReportSubFolder + "\\Result.html", false, DisplayOrder.NewestFirst);
            _extent.LoadConfig(@"C:\Users\tbell\OneDrive\Desktop\Standard4(Automation)_copy\Framework\Helper\ExtentConfig.xml");
            return _extent;

        }
        return null;
    }

    // This methods creates the report and assigns the catergory
    // HtmlReports.StartHtmlReports("LoginTestCase",null,"SmokeTest");
    public static void StartHtmlReports(string Name, string desc = null, string catergory = null)
    {
        if (Settings.EnableReport == "Yes")
        {
            _test = _extent.StartTest(Name, desc).AssignCategory(catergory);
        }
    }
        public static void ProcesSpecFlowReports(string status, string failedtestcase, string scenarioname)
        {
            LogStatus logstatus;

            if (Settings.EnableReport == "Yes")
            {

                if(status == null)
                {
                    logstatus = LogStatus.Pass;
                }
                else
                {
                    logstatus = LogStatus.Fail;
                }
         

                if (logstatus == LogStatus.Fail)
                {
                    var failedimage = _test.AddScreenCapture(failedtestcase);
                    _test.Log(logstatus, scenarioname, failedimage);
                }
                else
                {
                    scenarioname = null;
                    _test.Log(logstatus, scenarioname + logstatus);

                }

                _extent.EndTest(_test);

            }
        }

    // This methods applies the passed and failed testcases to the report
    // HtmlReports.ProcessHtmlReports();
    public static void ProcesHtmlReports(TestStatus status, string failedtestcase)
    {
        LogStatus logstatus;

        if (Settings.EnableReport == "Yes")
        {


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
                case TestStatus.Passed:
                    logstatus = LogStatus.Pass;
                    break;
                default:
                    logstatus = LogStatus.Pass;
                    break;
            }

            if (logstatus == LogStatus.Fail)
            {
                var failedimage = _test.AddScreenCapture(failedtestcase);
                _test.Log(logstatus, TestContext.CurrentContext.Test.Name, failedimage);
            }
            else
            {
                _test.Log(logstatus, TestContext.CurrentContext.Test.Name + logstatus);

            }

               

                _extent.EndTest(_test);

        }
    }

    // This methods saves all the changes made to the report and saves it.
    // HtmlReports.FlushCloseReport();
    public static void FlushCloseHtmlReport()
    {
        if (Settings.EnableReport == "Yes")
        {
            _extent.Flush();

            _extent.Close();
        }

    }
}
}

