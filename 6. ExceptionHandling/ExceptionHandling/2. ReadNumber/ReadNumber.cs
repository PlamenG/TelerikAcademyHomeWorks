// Write a method ReadNumber(int start, int end) that enters an integer 
// number in given range [start…end]. If an invalid number or non-number 
// text is entered, the method should throw an exception. Using this 
// method write a program that enters 10 numbers:
//			a1, a2, … a10, such that 1 < a1 < … < a10 < 100


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.ReadNumber
{
    class ReadNumber
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please, enter two numbers for a start and end of a range:");
            Console.Write("Start: ");
            int Start = int.Parse(Console.ReadLine());
            Console.Write("End: ");
            int End = int.Parse(Console.ReadLine());

            string[] SaveInput = new string[10];
            Console.WriteLine("Please, enter 10 numbers:");
            for (int i = 0; i < 10; i++)
            {
                string EnteredValue = Console.ReadLine(); // it is not known
                while (TestForException(EnteredValue, Start, End) == false)
                {
                    EnteredValue = Console.ReadLine();
                }
                SaveInput[i] = EnteredValue;
            }

            Console.Write("Correctly entered numbers are: ");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0}, ", SaveInput[i]);
                if (i == 9)
                {
                    Console.WriteLine("{0}", SaveInput[i]);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static bool TestForException(string CheckInput, int Start, int End)
        {
            bool Result = true;
            try
            {
                int Number = int.Parse(CheckInput);
                
                if (Number < Start || Number > End) // checking if the number is out of range
                {
                    var ex = new OutOfRangeException();
                    throw ex;
                }

                return Result;    
            }
            catch (OutOfRangeException) // our own exception is needed
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Number - out of given range!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Please, try again: ");
                Console.ForegroundColor = ConsoleColor.White;
                Result = false;
                return Result;
            }
            catch (NullReferenceException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Number - value cannot be null!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Please, try again: ");
                Console.ForegroundColor = ConsoleColor.White;
                Result = false;
                return Result;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Number - input is not a number!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Please, try again: ");
                Console.ForegroundColor = ConsoleColor.White;
                Result = false;
                return Result;
            }
        }
    }

    class OutOfRangeException : Exception
    {
        
    }
}
