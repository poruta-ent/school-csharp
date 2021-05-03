using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace linqu
{
    public static class MyFilesWithoutLinqu
    {
        public static void ShowFilesInDir()
        {
            var myDirPath = @"C:\Windows";
            FileInfo[] myFiles = new DirectoryInfo(myDirPath).GetFiles();
            Array.Sort(myFiles, new FileComparer());

            for (int i = 0; i < 5; i++)
            {
                FileInfo file = myFiles[i];
                Console.WriteLine($"{file.Name, -20}:{file.Length, 10:N0}");
            }
        }
    }

    public class FileComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }

    public class MyFilesWithClassicLinqu
    {
        public void ShowFilesInDir()
        {
            var myDirPath = @"C:\Windows";
            var myFilesQuery = from file in new DirectoryInfo(myDirPath).GetFiles()
                                orderby file.Length descending
                                select file;
            foreach (var file in myFilesQuery.Take(5))
            {
                Console.WriteLine($"{file.Name, -20}:{file.Length, 10:N0}");               
            }
        }                       
    }

    public class MyFilesWithShortLinqu
    {
        public void ShowFilesInDir()
        {
            var myDirPath = @"C:\Windows";
            var myFilesQuery = new DirectoryInfo(myDirPath).GetFiles().OrderByDescending(f => f.Length).Take(5);
            foreach (var file in myFilesQuery)
            {
                Console.WriteLine($"{file.Name, -20}:{file.Length, 10:N0}");               
            }
        }                       
    }
}