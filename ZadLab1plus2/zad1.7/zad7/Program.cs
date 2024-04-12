using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace zad7
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string sourceFilePath = "sourceFile.txt";

           
            string destinationFilePath = "destinationFile.txt";

            
            int fileSizeMB = 300;

            
            GenerateFile(sourceFilePath, fileSizeMB);

            
            Stopwatch stopwatch = Stopwatch.StartNew();
            CopyFileUsingFileStream(sourceFilePath, destinationFilePath);
            stopwatch.Stop();

            Console.WriteLine($"Czas kopiowania pliku za pomocą FileStream: {stopwatch.ElapsedMilliseconds} ms");

            
            File.Delete(sourceFilePath);
            File.Delete(destinationFilePath);
        }

        static void GenerateFile(string filePath, int fileSizeMB)
        {
            byte[] buffer = new byte[1024 * 1024]; // 1 MB

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                for (int i = 0; i < fileSizeMB; i++)
                {
                    fs.Write(buffer, 0, buffer.Length);
                }
            }
        }

        static void CopyFileUsingFileStream(string sourceFilePath, string destinationFilePath)
        {
            using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[1024 * 1024]; // 1 MB
                    int bytesRead;

                    while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        destinationStream.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }

}
