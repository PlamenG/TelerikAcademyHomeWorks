// Write a program that reads a text file and prints on the console its odd lines.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadPrint
{
    class ReadPrint
    {
        static void Main(string[] args)
        {
            string oddLine = "";
            int lineIndex = 1;

            using (StreamReader reader = new StreamReader (@"..\..\..\Cheat_Sheet_.txt"))
            {
                ReadOddLines(ref oddLine, ref lineIndex, reader);
            }

        }

        private static void ReadOddLines(ref string oddLine, ref int lineIndex, StreamReader reader)
        {
            var lineCount = File.ReadLines(@"..\..\..\Cheat_Sheet_.txt").Count(); // count the lines in the file
            while (lineIndex <= lineCount) // the loop will be made unless the line index is bigger than the line count
            {
                if (lineIndex % 2 != 0) // only the odd lines will be printed on the console
                {
                    oddLine = reader.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Line {0}: {1}", lineIndex, oddLine);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    oddLine = reader.ReadLine();
                }
                lineIndex ++;
            }
        }
    }
}