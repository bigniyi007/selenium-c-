using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Control
{
   public class CommonMethods
    {



        public static void SelectStringFromDropdown(string value, IWebElement dropdown)
        {
            SelectElement Dropdown3 = new SelectElement(dropdown);
            Dropdown3.SelectByText(value);
        }

    }
}
