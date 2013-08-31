// Write a program that deletes from given text file all odd lines. The result should be in the same file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _09.DeleteOddLines
{
    class DeleteOddLines
    {
        static void Main(string[] args)
        {

            InsertLineNumbers(); // the file is created and the lines are numbered

            // The solution:
            // - the input is read
            // - only the even lines are saved to temp file
            // - original file is deleted
            // - data from temp file is copied to a new file with the same name of the original
            // - temp file is deleted

            string tempFile = Path.GetTempFileName();
            using (var sr = new StreamReader("file.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                int count = 1;

                while ((line = sr.ReadLine()) != null)
                {
                    if (count % 2 == 0)
                    {
                        if (line != "removeme")
                            sw.WriteLine(line);
                    }
                    count++;
                }
            }

            File.Delete("file.txt");
            File.Move(tempFile, "file.txt");
            File.Delete(tempFile);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"You can find the new file at [your path here]\09. InsertLineNumber\bin\Debug folder.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void InsertLineNumbers()
        {
            StreamReader reader = new StreamReader(@"..\..\..\Cheat_Sheet_.txt");
            using (reader)
            {
                int count = 1;
                string line;
                StreamWriter writer = new StreamWriter(@"file.txt");
                using (writer)
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        writer.Write("Line {0}: ", count);
                        Console.ForegroundColor = ConsoleColor.White;
                        writer.WriteLine(line);
                        count++;
                    }

                }

            }
        }
    }
}
