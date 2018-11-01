using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace Facebook.PageObjectModel
{
    public class LoginPagePageObjects
    {
        // constructor
        public LoginPagePageObjects(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Driver.FindElements(By.xpath(""))
        // username textbox 
        [FindsBy(How = How.Name, Using = "UserName")]
        public IWebElement UsernameTextBox { get; set; }

        

        

        // password text box 
        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement PasswordTextBox { get; set; }

        // login button 
        [FindsBy(How = How.XPath, Using = ".//*[@id='userName']/p[3]/input")]
        public IWebElement LoginBtn { get; set; }
    }
}
                
        ///string anita = "90dhdfsosdvso90";
        /// int number = 2017;


// constructor
// properties
///  string name { get; set; }
/// int age { get; set; }

/// public void SpeakFrench()
//{

//}

/// public string Whatshisname()
//        {
//            return "John";
//        }

//        public int Tellmehisage()
//        {
//            return 9;
//        }


//    }
//}
