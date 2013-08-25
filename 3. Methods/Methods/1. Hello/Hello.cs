// Write a method that asks the user for his name and prints “Hello, <name>” 
// (for example, “Hello, Peter!”). Write a program to test this method.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Hello
{
    public class Hello
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            string Name = EnterName();
            CheckInput(Name);
            while (CheckInput(Name) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You did not enter a name! Please, try again.");
                Console.ForegroundColor = ConsoleColor.White;
                Name = EnterName();
                CheckInput(Name);
            }

            PrintName(Name);
            
        }

        public static string EnterName()
        {
            Console.Write("Please, enter your name: ");
            string Name = Console.ReadLine();
            return Name;
        }

        public static void PrintName(string Name)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hello, {0}!", Name); ;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static bool CheckInput(string Name) // Checking if the input consists only of letters and a Space
        {
            bool result = false;
            for (int i = 0; i < Name.Length; i++)
            {
                if (Char.IsLetter(Name[i]) || Char.IsWhiteSpace(Name[i]))
                {
                    result = true;
                }
                else
                {
                    result = false;
                    return result;
                }
            }
            return result;
        }
    }
}
