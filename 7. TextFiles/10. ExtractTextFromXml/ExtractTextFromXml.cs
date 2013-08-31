using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class ExtractTextFromXml
{
    static void Main()
    {
        using (StreamReader input = new StreamReader("input.txt"))
        {
            for (int i; (i = input.Read()) != -1; ) // Read char by char
            {
                if (i == '>') // Inside text node
                {
                    string text = String.Empty;

                    while ((i = input.Read()) != -1 && i != '<')
                    {
                        text += (char)i; // Character by character the text is written
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (!String.IsNullOrWhiteSpace(text)) Console.WriteLine(text.Trim()); // The text between > and < is printed if it is not null
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}