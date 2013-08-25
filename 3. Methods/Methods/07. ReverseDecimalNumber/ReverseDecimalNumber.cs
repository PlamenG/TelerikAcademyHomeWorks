using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.ReverseDecimalNumber
{
    class ReverseDecimalNumber
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture; // The '.' is recognised as a mathematical character from the console
            Console.ForegroundColor = ConsoleColor.White;
            string Value = InputDigitToReserve();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The reversed decimal number is {0}", ReverseDigits(Value));
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static string InputDigitToReserve()
        {
            Console.Write("Please, enter a number: ");
            string Value = Console.ReadLine();
            return Value;
        }

        public static decimal ReverseDigits(string Value)
        {
            string ValueReversed = "";
            for (int i = Value.Length - 1; i >= 0; i--)
            {
                ValueReversed += Value[i];
            }
            decimal Result = decimal.Parse(ValueReversed);
            return Result;
        }
    }
}
