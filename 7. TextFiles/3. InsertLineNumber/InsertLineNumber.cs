// Write a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to another text file.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3.InsertLineNumber
{
    class InsertLineNumber
    {
        static void Main(string[] args)
        {

            StreamReader reader = new StreamReader(@"..\..\..\Cheat_Sheet_.txt");
            using (reader)
            {
                int count = 1;
                string line;
                StreamWriter writer = new StreamWriter(@"output.txt");
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"You can find the new file at [your path here]\3. InsertLineNumber\bin\Debug folder.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
