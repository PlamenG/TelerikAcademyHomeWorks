using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _06.ArrangeStrings
{
    class ArrangeStrings
    {
        static void Main(string[] args)
        {
            String Input = File.ReadAllText("Names.txt");

            List<string> Names = new List<string>();
            
            foreach (var line in Input.Split('\n'))
            {   
                // All not wanted tab characters and new line characters will be removed before saving them to a list:
                string temp = line.Replace("\r", String.Empty);
                temp = temp.Replace("\t", String.Empty);
                Names.Add(temp);
                
            }

            Names.Sort();

            StreamWriter writer = new StreamWriter("Result.txt");
            using (writer)
            {
                foreach (var name in Names)
                {
                    writer.WriteLine(name);
                }
                
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"You can find the new file at [your path here]\06. ArrangeStrings\bin\Debug folder.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
