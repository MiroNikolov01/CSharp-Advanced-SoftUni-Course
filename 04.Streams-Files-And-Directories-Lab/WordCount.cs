using System.Text.RegularExpressions;

namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamReader wordsReader = new StreamReader(wordsFilePath))
            {
                //Reading words.txt
                string wordLine = wordsReader.ReadLine();
                string[] words = File.ReadAllLines(wordsFilePath)
                    .SelectMany(line => line.Split(' ',StringSplitOptions.RemoveEmptyEntries))
                    .ToArray();

                Dictionary<string, int> wordsMap = new Dictionary<string, int>();
                foreach (var word in words)
                {
                    if (!wordsMap.ContainsKey(word))
                    {
                        wordsMap.Add(word, 0);
                    }
                }

                using (StreamReader textReader = new StreamReader(textFilePath))
                {
                    while (!textReader.EndOfStream)
                    {
                        string textLine = textReader.ReadLine();
                        foreach (Match match in Regex.Matches(textLine.ToLower(), @"\w+"))
                        {
                            string word = match.Value;
                            if (wordsMap.ContainsKey(word))
                            {
                                wordsMap[word]++;
                            }
                        }
                    }
                    using (StreamWriter outputWriter = new StreamWriter(outputFilePath))
                    {
                        foreach (var word in wordsMap.OrderByDescending(x => x.Value))
                        {
                            outputWriter.WriteLine($"{word.Key} - {word.Value}");
                        }
                    }
                }
            }
        }
    }
}