// 7. Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).
// 8. Modify the solution of the previous problem to replace only whole words (not substrings).


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace _07.ReplaceSubstring
{
    class ReplaceSubstring
    {
        const int chunkSize = 2 * 1024; // 2KB - the output will be written in chunks of 2 KB;

        static void Main(string[] args)
        {
            GenerateLargeFile();

            using (StreamReader input = new StreamReader("input.txt"))
            
            using (StreamWriter output = new StreamWriter("output.txt"))
            {
                for (string line; (line = input.ReadLine()) != null; )
                {
                    var buffer = new char[chunkSize];
                    int bytesRead;
                    while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0) // Chunk by chunk the file is rewritten
                    {
                        output.WriteLine(line.Replace("start", "finish")); // task 7.
                        // output.WriteLine(Regex.Replace(line, @"\bstart\b", "finish")); // task 8.
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("output.txt created - job done!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void GenerateLargeFile() // it takes some minutes to fill the file - you can delete this if you already have a 100 MB file
        {
            string inputPath = "input.txt";
            using (StreamWriter writer = new StreamWriter(inputPath))
            {
                long fileSize = 0;
                long maxSize = 100000000; // ~100 MB

                while (fileSize < maxSize)
                {
                    writer.WriteLine("start");
                    FileInfo file = new FileInfo("input.txt");
                    fileSize = file.Length;
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("input.txt created");
        }      
    }
}
