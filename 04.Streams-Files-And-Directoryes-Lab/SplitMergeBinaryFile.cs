namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (var inputFileReaderStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            {
                int firstPartSize = (int)(inputFileReaderStream.Length / 2 + inputFileReaderStream.Length % 2);
                
                using (var firstPartStream = new FileStream(partOneFilePath, FileMode.Create, FileAccess.Write))
                {
                    CopyExact(inputFileReaderStream, firstPartStream, firstPartSize);
                }

                int secondPartSize = (int)inputFileReaderStream.Length / 2;
                
                using (var secondPartStream = new FileStream(partTwoFilePath, FileMode.Create, FileAccess.Write))
                {
                    CopyExact(inputFileReaderStream, secondPartStream,secondPartSize);
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (var outputStream = new FileStream(joinedFilePath, FileMode.Create, FileAccess.Write))
            {
                using(var firstPartStream = new FileStream(partOneFilePath, FileMode.Open, FileAccess.Read))
                {
                    firstPartStream.CopyTo(outputStream);
                }
                using (var secondPartStream = new FileStream(partTwoFilePath, FileMode.Open, FileAccess.Read))
                {
                    secondPartStream.CopyTo(outputStream);
                }
            }
        }

        private static void CopyExact(FileStream input, FileStream output, int count)
        {
            byte[] buffer = new byte[1024];
            
            int countReadedBytes = 0;
            while (countReadedBytes < count)
            {
                int readBytes = input.Read(buffer, 0, Math.Min(buffer.Length, count - countReadedBytes));
                output.Write(buffer, 0, readBytes);
                countReadedBytes += readBytes;
            }
        }
    }
}