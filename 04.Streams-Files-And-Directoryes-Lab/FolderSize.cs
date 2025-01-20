using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            Queue<string> files = new Queue<string>();

            long totalFileSize = 0;
            files.Enqueue(folderPath);
            while (files.Count > 0)
            {
                string currentFile = files.Dequeue();
                foreach (var file in Directory.GetFiles(currentFile))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    totalFileSize += fileInfo.Length;
                }

                foreach (var dir in Directory.GetDirectories(currentFile))
                {
                    files.Enqueue(dir);
                }
            }
            File.WriteAllText(outputFilePath, $"{totalFileSize / 1024m} KB");
        }
    }
}
