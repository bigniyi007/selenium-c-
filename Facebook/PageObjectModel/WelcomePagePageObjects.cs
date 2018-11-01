using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.PageObjectModel
{
   public class WelcomePagePageObjects
    {
        public WelcomePagePageObjects(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='TitleId']")]
        public IWebElement TitleDropDown { get; set; }

       

        
        [FindsBy(How = How.XPath, Using = ".//*[@id='FirstName']")]
        public IWebElement FirstNameTextBox { get; set; }

      

        [FindsBy(How = How.XPath, Using = ".//*[@id='details']/table/tbody/tr[7]/td/input")]
        public IWebElement SaveButton { get; set; }

        
    }
}
