using Facebook.PageObjectModel;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SeleQuick_Framework.Config;
using SeleQuick_Framework.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace Facebook.Steps
{
    [Binding]

    public sealed class LoginStepDefinitions : CommonSteps
    {
        LoginPagePageObjects Lp = new LoginPagePageObjects(driver);
        WelcomePagePageObjects Wp = new WelcomePagePageObjects(driver);

        [Given(@"I have entered username into the Website")]
        public void GivenIHaveEnteredUsernameIntoTheWebsite()
        {

           
            var name = Settings.AdminUsername;
            Lp.UsernameTextBox.SendKeys(Settings.AdminUsername);
            //Lp.UsernameTextBox.SendKeys(Settings.AdminUsername);
            //Log.Write("Entered Wrong password");

            Log.Write("Entered Wrong username");

            System.Threading.Thread.Sleep(5000);
        }



        [Given(@"I have entered password into the website")]
        public void GivenIHaveEnteredPasswordIntoTheWebsite()
        {
            Lp.PasswordTextBox.SendKeys(Settings.AdminPassword);
            Log.Write("Entered Wrong password");

            System.Threading.Thread.Sleep(5000);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            Lp.LoginBtn.Click();
            Log.Write("clicked login button");


            System.Threading.Thread.Sleep(5000);
        }

        [Then(@"i should see the welcome page")]
        public void ThenIShouldSeeTheWelcomePage()
        {
            bool iswelcomepagedisplayed = Wp.FirstNameTextBox.Displayed;



            System.Threading.Thread.Sleep(5000);

        }

        [Then(@"i should not see the welcome page")]
        public void ThenIShouldNotSeeTheWelcomePage()
        {

            
            //ScenarioContext.Current.Pending();

            System.Threading.Thread.Sleep(5000);
        }





        }
    }




