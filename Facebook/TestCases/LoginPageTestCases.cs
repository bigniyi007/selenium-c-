using Facebook.PageObjectModel;
using NUnit.Framework;
using SeleQuick_Framework.Config;
using SeleQuick_Framework.Helper;
using System.Reflection;

namespace Facebook.TestCases
{

    [TestFixture]
   public class LoginPageTestCases : CommonSteps
    {

       

        LoginPagePageObjects Lp = new LoginPagePageObjects(driver);
        WelcomePagePageObjects Wp = new WelcomePagePageObjects(driver);

        [SetUp]
        public void Setup()
        {
            HtmlReports.StartHtmlReports(TestContext.CurrentContext.Test.Name, null, MethodBase.GetCurrentMethod().DeclaringType.Name);
        }

        [Test]
        [Category("Smoke"), Category("Regression")]
        public void LoginWithWrongUsername()

        {

            /// type in wrong username
            Lp.UsernameTextBox.SendKeys(Settings.AdminUsername);
            Log.Write("Entered Wrong username");

            /// type in password 
            Lp.PasswordTextBox.SendKeys(Settings.AdminPassword);
            Log.Write("Entered Wrong password");

            /// click the the login button 
            Lp.LoginBtn.Click();
            Log.Write("clicked login button");
           
           
            
            

        }



        [Test, Category("Smoke")]
        public void LoginWithWrongPassword()
        {

            Assert.Fail();



        }

        [Test]
        public void LoginWithRightDetails()
        {

            Assert.Pass();

        }


    }
}
