using System.IO;

namespace CopyBinaryFile
{
    using System;
    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream fileStreamInput = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream fileStreamOutput = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[1024];
                    int bytesReadCount = 0;
                    
                    while ((bytesReadCount = fileStreamInput.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        fileStreamOutput.Write(buffer, 0, bytesReadCount);
                    }
                }
            }
        }
    }
}