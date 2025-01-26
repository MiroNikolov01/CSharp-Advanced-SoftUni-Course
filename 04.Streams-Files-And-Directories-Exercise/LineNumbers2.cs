using System.IO;

namespace LineNumbers
{
    using System;

    public class LineNumbers2
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader inputReader = new StreamReader(inputFilePath))
            {
                using (StreamWriter outputWriter = new StreamWriter(outputFilePath))
                {
                    int count = 1;
                    while (!inputReader.EndOfStream)
                    {
                        string line = inputReader.ReadLine();

                        (int countLetters, int countPunctuations) = CountLettersAndPunctuations(line);

                        outputWriter.WriteLine($"Line{count++}: {line} ({countLetters})({countPunctuations})");
                    }
                }
            }
        }

        static (int letters, int punctuations) CountLettersAndPunctuations(string text)
        {
            int letters = 0;
            int punctuations = 0;

            char[] elements = text.ToCharArray();

            foreach (var element in elements)
            {
                if (char.IsLetter(element))
                {
                    letters++;
                }
                else if (char.IsPunctuation(element))
                {
                    punctuations++;
                }
            }

            return (letters, punctuations);
        }
    }
}