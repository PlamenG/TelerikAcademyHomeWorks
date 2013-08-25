using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.WeekDay
{
    class WeekDay
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture; // The week will be displayed in English. Comment this line to display the day in your PC language
            Console.ForegroundColor = ConsoleColor.White;
            DateTime Day = DateTime.Now;
            string Format = "dddd"; // it is specified what needs to be displayed
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The current day of the week is {0}.",Day.ToString(Format));
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
