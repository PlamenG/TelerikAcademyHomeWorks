// Write a method that returns the last digit of given integer as an 
// English word. Examples: 512  "two", 1024  "four", 12309  "nine".


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.LastDigit
{
    class LastDigit
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please, enter a number: ");
            int Value = int.Parse(Console.ReadLine());

            string ToPrint = LastDigitToString(Value);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The last digit is {0}.", ToPrint);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static string LastDigitToString(int Value)
        {
            byte Result = (byte)(Value % 10);
            string ToPrint = "";
            switch (Result)
            {
                case 1:
                    ToPrint = "one";
                    break;
                case 2:
                    ToPrint = "two";
                    break;
                case 3:
                    ToPrint = "three";
                    break;
                case 4:
                    ToPrint = "four";
                    break;
                case 5:
                    ToPrint = "five";
                    break;
                case 6:
                    ToPrint = "six";
                    break;
                case 7:
                    ToPrint = "seven";
                    break;
                case 8:
                    ToPrint = "eight";
                    break;
                case 9:
                    ToPrint = "nine";
                    break;
                case 0:
                    ToPrint = "zero";
                    break;
                default:
                    break;
            }
            return ToPrint;
        }
    }
}
