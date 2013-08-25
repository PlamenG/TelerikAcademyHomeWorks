// Write a program that reads an integer number and calculates and prints its square root. 
// If the number is invalid or negative, print "Invalid number". In all cases finally print 
// "Good bye". Use try-catch-finally.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.ReadAndPrintSqrt
{
    class ReadAndPrintSqrt
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture; // The '.' is recognised as a mathematical character from the console
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please, enter a number to find its root: ");
            string CheckInput = Console.ReadLine();
            TestForException(CheckInput);
 
        }

        private static void TestForException(string CheckInput)
        {
            try
            {
                int Number = int.Parse(CheckInput);
                double CheckForNan = Math.Sqrt((double)(Number));
                if (double.IsNaN(CheckForNan) == true) // checking if the result is a number
                {
                    var ex = new NumberiNanException();
                    throw ex;
                }
                CalculateSqrt(Number);
            }
            catch (NumberiNanException) // our own exception is needed
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid Number");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (NullReferenceException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid Number");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid Number");
                Console.ForegroundColor = ConsoleColor.White;
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nGood Bye\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void CalculateSqrt(int Number)
        {
            
            double Result = Math.Sqrt((double)(Number));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe square root of {0} is {1:0.000}.", Number, Result);
        }
    }
    class NumberiNanException : Exception // the class is needed in order to declare the new exception. This class enherits all properties from the Exception .Net class.
    {
        
    }
}
