using SeleQuick_Framework.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleQuick_Framework.Helper
{
    public class FolderBuilder
    {
        private string foldername;

        // This are the list of names of folders that will get built
        public static string MainFolder;
        public static string ReportSubFolder;
        public static string ScreenShotSubFolder;
        public static string FailedSubFolder;
        public static string LogsSubFolder;

        public FolderBuilder(string _name)
        {
            _name = foldername;
        }

        //FolderBuilder.BuildFolderStructure();
        public static void BuildFolderStructure()
        {

            // This is the method that actually does the building
            ReportSubFolder = Settings.Location + "\\Reports";
            MainFolder = Settings.Location;
            ScreenShotSubFolder = Settings.Location + "\\screenshot";
            FailedSubFolder = Settings.Location + "\\failed";
            LogsSubFolder = Settings.Location + "\\Logs";


            CreateFolder(MainFolder);
            CreateFolder(ReportSubFolder);
            CreateFolder(ScreenShotSubFolder);
            CreateFolder(FailedSubFolder);
            CreateFolder(LogsSubFolder);
        }



        public static void Delete(string _directortytoDelete)
        {

            Directory.Delete(_directortytoDelete, true);
        }

        static void CreateFolder(string _name)
        {
            if (!Directory.Exists(_name))

                Directory.CreateDirectory(_name).Create();
            File.SetAttributes(_name, FileAttributes.Normal);
        }


        public static void DeleteFolder(string _name)
        {
            if (Directory.Exists(_name))
                Directory.Delete(_name, true);
        }



    }
}
