// You are given a sequence of positive integer values written into a string, separated by spaces. 
// Write a function that reads these values from given string and calculates their sum. Example:
//		string = "43 68 9 23 318"  result = 461


using System;

using System.Text.RegularExpressions; // needed in order to be able to use Regex - source http://www.dotnetperls.com/regex-split-numbers

namespace _6.CalculateSumFromString
{
    class CalculateSumFromString
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            const string input = "43 68 9 % *23 318"; // you may enter other strings with numbers
            // Split on one or more non-digit characters.
            string[] numbers = Regex.Split(input, @"\D+");
            int Sum = 0;
            foreach (string value in numbers)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    int i = int.Parse(value);
                    Sum += i;  
                }   
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The sum of the numbers in the string is {0}", Sum);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
