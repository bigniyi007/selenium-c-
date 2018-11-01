using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SeleQuick_Framework.Config;
using SeleQuick_Framework.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleQuick_Framework.Base
{
    
    public abstract class TestHooke : Base
    {
        public static void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFramework();

            //Set Log
            Log.CreateLogFile();

            //Open Browser
            OpenBrowser(Settings.Browser);

            //   DriverContext.Browser.GoToUrl(Settings.Url);
          

            Log.Write("Initialized framework");

        }

        private static void OpenBrowser(BrowserType browserType = BrowserType.FireFox)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.FireFox:
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Users\tbell\OneDrive\Desktop\");
                    service.FirefoxBinaryPath = (@"C:\Program Files\Mozilla Firefox\firefox.exe");
                    DriverContext.Driver = new FirefoxDriver(service);
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }



        }

        public virtual void NaviateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.Url);
            DriverContext.Driver.Manage().Window.Maximize();
            Log.Write("Opened the browser !!!");
        }



    }
}
