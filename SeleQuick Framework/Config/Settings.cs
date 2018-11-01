using SeleQuick_Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleQuick_Framework.Config
{
    public class Settings
    {
        // This class is just a mapping class the values from the xml file will get mapped to this values.
        public static string Location { get; set; }
        public static string EnableReport { get; set; }
        public static string AdminPassword { get; set; }
        public static string Url { get; set; }
        public static string EnableLog { get; set; }
        public static string DataBaseConnectionString { get; set; }
        public static string AdminUsername { get; set; }

        public static BrowserType Browser { get; set; }
    }
}
