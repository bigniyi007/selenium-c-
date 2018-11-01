using OpenQA.Selenium;
using SeleQuick_Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Facebook
{
    [Binding]
    public sealed class Hooks : TestHooke
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
        [BeforeTestRun]
        public static void beforeTest()
        {
            Console.WriteLine();
        }

        [AfterTestRun]
        public static void aftertest()
        {
            Console.WriteLine();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            

            //InitializeSettings();
            //NaviateSite();

            driver = DriverContext.Driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {

            driver.Quit();

            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
