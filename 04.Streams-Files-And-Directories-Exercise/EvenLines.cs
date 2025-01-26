using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace EvenLines
{
    using System;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new StringBuilder();
            using (var streamReader = new StreamReader(inputFilePath))
            {
                int row = 0;
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    
                    line = ReplaceSymbols(line);
                    
                    if (row % 2 == 0)
                    {
                        string reversedLine = ReverseWords(line);

                        sb.AppendLine(reversedLine);
                    }

                    row++;
                }
            }

            return sb.ToString();
        }

        static string ReplaceSymbols(string line)
        {
            string[] symbols = new string[]
            {
                "!", ",", ".", "?", "-"
            };

            foreach (var symbol in symbols)
            {
                line = line.Replace(symbol, "@");
            }

            return line;
        }
        static string ReverseWords(string line)
        {
            string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words); 
            return string.Join(' ', words); 
        }
    }
}