﻿using System.IO.Compression;

namespace ZipAndExtract
{
    using System;
    using System.IO;
    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            using (ZipArchive archive = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Create))
            {
                string fileName = Path.GetFileName(inputFilePath);
                archive.CreateEntryFromFile(inputFilePath, fileName);
            }
        }
    
        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using (ZipArchive archive = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Read))
            {
                ZipArchiveEntry entry = archive.GetEntry(fileName);

                if (entry is null)
                {
                    throw new InvalidOperationException("File not found in archive.");
                }
                entry.ExtractToFile(outputFilePath);
            }
        }
    }
}