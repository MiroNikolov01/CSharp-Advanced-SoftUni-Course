using System.Collections.Generic;

namespace ExtractSpecialBytes
{
    using System;
    using System.IO;

    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            HashSet<byte> specialBytes = new HashSet<byte>();
            using (var speacilBytesReader = new StreamReader(bytesFilePath))
            {
                while (!speacilBytesReader.EndOfStream)
                {
                    byte specialByteSymbol = byte.Parse(speacilBytesReader.ReadLine());
                    specialBytes.Add(specialByteSymbol);
                }
            }

            using (var inputStream = new FileStream(binaryFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[1024];
                    int readBytes;
                    while ((readBytes = inputStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        int countSpecialBytes = 0;
                        for (int i = 0; i < readBytes; i++)
                        {
                            if (specialBytes.Contains(buffer[i]))
                            {
                                buffer[countSpecialBytes++] = buffer[i];
                            }
                        }

                        outputStream.Write(buffer, 0, countSpecialBytes);
                    }
                }
            }
        }
    }
}