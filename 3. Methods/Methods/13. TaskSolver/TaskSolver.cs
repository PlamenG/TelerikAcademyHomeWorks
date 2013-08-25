// Write a program that can solve these tasks:
// Reverses the digits of a number
// Calculates the average of a sequence of integers
// Solves a linear equation a * x + b = 0
// 		Create appropriate methods.
// 		Provide a simple text-based menu for the user to choose which task to solve.
// 		Validate the input data:
// The decimal number should be non-negative
// The sequence should not be empty
// a should not be equal to 0


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.TaskSolver
{
    class TaskSolver
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture; // The '.' is recognised as a mathematical character from the console
            Console.ForegroundColor = ConsoleColor.Blue;
            
            Console.WriteLine("1. reverses the digits of a number");
            Console.WriteLine("2. calculates the average of a sequence of integers");
            Console.WriteLine("3. solves a linear equation a * x + b = 0");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Please, choose what you would like to do: ");
            byte Task = byte.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            
            if (Task == 1)
            {
                string Value = InputDigitToReserve();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The reversed decimal number is {0}", ReverseDigits(Value));
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (Task == 2)
            {
                int[] ValuesArr = IputArray();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The average value is {0}.", CalculateAverageValue(ValuesArr));
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (Task == 3)
            {
                Console.WriteLine("The following linear equation will be solved: a*x + b = 0");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("x equals {0:0.00}", LinearEquation());
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static decimal LinearEquation()
        {
            Console.ForegroundColor = ConsoleColor.White;
            decimal A = InputForA();
            CheckIfZero(A);
            while (CheckIfZero(A) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please, try again to enter a value different from 0!");
                Console.ForegroundColor = ConsoleColor.White;
                A = InputForA();
                CheckIfZero(A);
            }

            Console.Write("for b: ");
            decimal B = decimal.Parse(Console.ReadLine());
            // solving the equation:
            decimal Result = (-B) / A;
            return Result;
        }

        private static decimal InputForA()
        {
            Console.WriteLine("Please, enter value:");
            Console.Write("for a: ");
            decimal A = decimal.Parse(Console.ReadLine());
            
            return A;
        }

        public static bool CheckIfZero(decimal A)
        {
            bool Result = false;
            if (A == 0)
            {
                return Result;
            }
            else
            {
                Result = true;
                return Result;
            }
            
        }

        public static float CalculateAverageValue(int[] ValuesArr)
        {
            float Sum = 0;
            for (int i = 0; i < ValuesArr.Length; i++)
            {
                Sum += ValuesArr[i];
            }
            float AvarageValue = Sum / ValuesArr.Length + Sum % ValuesArr.Length;
            return AvarageValue;
        }

        public static int[] IputArray()
        {
            Console.Write("Please, enter how long the array should be: ");
            int N = int.Parse(Console.ReadLine());
            int[] InputArr = new int[N];
            Console.WriteLine("Please, enter {0} values:", N);
            for (int i = 0; i < N; i++)
            {
                string Check = Console.ReadLine(); // Checking if a correct value was entered - non-empty and int number
                try
                {
                    InputArr[i] = int.Parse(Check);
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please, enter a correct value!");
                    Console.ForegroundColor = ConsoleColor.White;
                    IputArray();
                    break;
                }
                
                InputArr[i] = int.Parse(Check);
                
            }
            return InputArr;
        }

        public static string InputDigitToReserve()
        {
            Console.Write("Please, enter a number to reverse: ");
            string Value = Console.ReadLine();
            CheckInputDecimal(Value);
            while (CheckInputDecimal(Value) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You did not enter a non-negative value! Please, try again.");
                Console.ForegroundColor = ConsoleColor.White;
                Value = InputDigitToReserve();
                CheckInputDecimal(Value);
            }
            return Value;
        }

        public static bool CheckInputDecimal(string Name) // Checking if the input consists is non negative
        {
            bool result = false;
            for (int i = 0; i < Name.Length; i++)
            {
                if (Char.IsDigit(Name[i]) && decimal.Parse(Name) >= 0)
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
