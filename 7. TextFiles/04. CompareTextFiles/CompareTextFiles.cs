// Write a program that compares two text files line by line and prints the number of 
// lines that are the same and the number of lines that are different. Assume the files have equal number of lines.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _04.CompareTextFiles
{
    class CompareTextFiles
    {
        static void Main(string[] args)
        {

            StreamReader readerFirstFile = new StreamReader(@"..\..\..\Bitwise_Tricks.txt");
            StreamReader readerSecondFile = new StreamReader(@"..\..\..\Bitwise_Tricks - Copy.txt"); // only some lines were changed manually here

            using (readerFirstFile)
            {
                using (readerSecondFile)
                {

                    string FirstFileline;
                    string SecondFileline;
                    StreamWriter writer = new StreamWriter(@"output.txt");
                    using (writer)
                    {
                        while ((FirstFileline = readerFirstFile.ReadLine()) != null)
                        {
                            SecondFileline = readerSecondFile.ReadLine();
                            if (FirstFileline == SecondFileline)
                            {
                                writer.WriteLine(FirstFileline);
                            }
                        }

                    }
                }

            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"You can find the new file at [your path here]\04. CompareTextFiles\bin\Debug folder.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
