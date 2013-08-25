// Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.LeapYear
{
    class LeapYear
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int Year = Input();

            Result(Year);
        }

        private static void Result(int Year)
        {
            bool IsLeapYear = DateTime.IsLeapYear(Year);
            Console.ForegroundColor = ConsoleColor.Green;
            if (IsLeapYear)
            {
                Console.WriteLine("The {0} is a leap year.", Year);
            }
            else
            {
                Console.WriteLine("The {0} is NOT a leap year.", Year);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static int Input()
        {
            Console.Write("Please, enter a year: ");
            int Year = int.Parse(Console.ReadLine());
            return Year;
        }
    }
}
