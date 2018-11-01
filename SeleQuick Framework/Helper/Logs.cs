using SeleQuick_Framework.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleQuick_Framework.Helper
{
    //This class creates a log text file which contains logging from the framework
    public class Log
    {
        private static StreamWriter _writer = null;
        private static string _logfilename = string.Format("{0:dd-mm-yyyy}", DateTime.Today);


        //This method creates the log file and its named based on the current date.
        //Log.CreateLogFile();
        public static void CreateLogFile()
        {
            if (Settings.EnableLog == "Yes")
            {
                var dir = FolderBuilder.LogsSubFolder + "\\" + _logfilename + ".log";
                if (Directory.Exists(FolderBuilder.MainFolder))

                    _writer = File.AppendText(dir);
                else
                {
                    throw new DirectoryNotFoundException("Log directory has not being created");
                }
            }
        }


        //This methods is responsible for writing the text to the log file created. 
        // Log.Write("Hello Everyone");
        public static void Write(string logmessage)
        {
            if (Settings.EnableLog == "Yes")
            {
                _writer.Write($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                _writer.WriteLine(" " + logmessage);
                _writer.Flush();
            }
        }
    }
}
