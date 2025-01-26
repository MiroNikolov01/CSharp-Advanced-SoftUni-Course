using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    using System;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"report.txt";
            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);


            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            Dictionary<string, List<string>> filesMap = new Dictionary<string, List<string>>();

            var files = Directory.GetFiles(inputFolderPath);
            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);
                string extension = Path.GetExtension(file);
                if (!filesMap.ContainsKey(extension))
                {
                    filesMap.Add(extension, new List<string>());
                }

                filesMap[extension].Add(fileName);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var (extenstion, file) in filesMap
                         .OrderByDescending(v => v.Value.Count)
                         .ThenBy(v => v.Key))
            {
                sb.AppendLine(extenstion);
                foreach (var fileName in file)
                {
                    FileInfo fileInfo = new FileInfo(fileName);
                    int info = (int)fileInfo.Length;
                    sb.AppendLine($"--{fileName} - {info / 1024m}kb");
                }
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string dekstopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string filePath = Path.Combine(dekstopPath, reportFileName);
            
           File.WriteAllText(filePath, textContent);
        }
    }
}