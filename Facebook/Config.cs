using System;

using SeleQuick_Framework.Base;
using SeleQuick_Framework.Config;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Facebook
{
    [SetUpFixture]
    public class Config : TestHooke
    {


        private static IWebDriver _driver;

        public static IWebDriver Driver
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


        // This entire block of code will be executed once before any testcase is run and its main function 
        // is open the browser and navigate to the website.

        [OneTimeSetUp]
        public void SetUp()
        {
            InitializeSettings();
            NaviateSite();

            Driver = DriverContext.Driver;

            //Login(Settings.AdminUsername, Settings.AdminPassword);

            Console.WriteLine("Login Successful.");
        }

        //This entire block of code will be executed once after all the test cases have being executed
        // this method will close down the browser. 
        [OneTimeTearDown]
        public void TearDown()
        {
            // close browser. 
            Driver.Close();

           
        }
 

        private enum Browser
        {
            Firefox,
            Chrome,
            IE,
            Edge

        }


        public static void Login(string a, string b)
        {
           // throw NotImplementedException();
        }


        public static void Logout()
        {
           // throw NotImplementedException();
        }
    }
}
