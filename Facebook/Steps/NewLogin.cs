using Facebook.PageObjectModel;
using RelevantCodes.ExtentReports.Model;
using SeleQuick_Framework.Config;
using SeleQuick_Framework.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Facebook.Steps
{
    [Binding]
    public sealed class NewLogin : CommonSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef


        LoginPagePageObjects Lp = new LoginPagePageObjects(driver);
        WelcomePagePageObjects Wp = new WelcomePagePageObjects(driver);


        [Given("I have entered username '<username>' and password '<password>")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(int number)
        {
            var name = Settings.AdminUsername;
            Lp.UsernameTextBox.SendKeys(Settings.AdminUsername);
            //Lp.UsernameTextBox.SendKeys(Settings.AdminUsername);
            //Log.Write("Entered Wrong password");

            SeleQuick_Framework.Helper.Log.Write("Entered Wrong username");

            System.Threading.Thread.Sleep(5000);


        }

        [When("I login")]
        public void WhenIPressAdd()
        {

            Lp.PasswordTextBox.SendKeys(Settings.AdminPassword);
            SeleQuick_Framework.Helper.Log.Write("Entered Wrong password");

            System.Threading.Thread.Sleep(5000);

            //TODO: implement act (action) logic

            //ScenarioContext.Current.Pending();
        }

        [Then("I should be informed that login '<result>")]
        public void ThenTheResultShouldBe()
        {

           
            //TODO: implement assert (verification) logic

            ScenarioContext.Current.Pending();
        }
    }
}
