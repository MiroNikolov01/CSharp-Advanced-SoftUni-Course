namespace MergeFiles
{
    using System;
    using System.IO;

    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader firstFileReader = new StreamReader(firstInputFilePath))
            {
                using (StreamReader SecondFileReader = new StreamReader(secondInputFilePath))
                {
                    using (StreamWriter outputFileWriter = new StreamWriter(outputFilePath))
                    {
                        int currentIteration = 0;
                        string line;
                        
                        while (!firstFileReader.EndOfStream || !SecondFileReader.EndOfStream)
                        {
                            if (currentIteration % 2 == 0)
                            {
                                line = firstFileReader.ReadLine();
                                outputFileWriter.WriteLine(line);
                            }
                            else
                            {
                                line = SecondFileReader.ReadLine();
                                outputFileWriter.WriteLine(line);
                            }
                            currentIteration++;
                        }
                    }
                }
            }
        }
    }
}