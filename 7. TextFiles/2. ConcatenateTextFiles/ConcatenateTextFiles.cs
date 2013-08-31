// Write a program that concatenates two text files into another text file.

// source of the solution - http://stackoverflow.com/questions/6311358/efficient-way-to-combine-multiple-text-files

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2.ConcatenateTextFiles
{
    class ConcatenateTextFiles
    {
        const int chunkSize = 2 * 1024; // 2KB - the output will be written in chunks of 2 KB;

        static void Main(string[] args)
        {

            var inputFiles = new[] { @"..\..\..\Cheat_Sheet_.txt", @"..\..\..\Bitwise_Tricks.txt" };
            using (var output = File.Create("output.txt"))
            {
                foreach (var file in inputFiles)
                {
                    using (var input = File.OpenRead(file))
                    {
                        var buffer = new byte[chunkSize];
                        int bytesRead;
                        while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            output.Write(buffer, 0, bytesRead);
                        }
                        input.Close();
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"File output.txt is created in [your path here]\2. ConcatenateTextFiles\bin\Debug folder.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
