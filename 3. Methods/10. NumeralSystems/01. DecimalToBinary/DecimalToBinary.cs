// Write a program to convert decimal numbers to their binary representation.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DecimalToBinary
{
    class DecimalToBinary
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please, enter a decimal number: ");
            // string ValueStr = Console.ReadLine();
            int ValueInt = int.Parse(Console.ReadLine());
            byte NumeralBase = 2; // base to the next numeral system

            int[] Result = ConvertDecimalToBinary(ValueInt, NumeralBase);
            Print(Result, ValueInt);
        }

        private static void Print(int[] Result, int ValueInt)
        {
            Console.WriteLine("The binary representation of the decimal number {0} is:", ValueInt);
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = Result.Length - 1; i >= 0; i--)
            {
                Console.Write(Result[i]);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static int[] ConvertDecimalToBinary(int ValueInt, byte NumeralBase)
        {
            int Remainder = 1;
            int Result = 0;
            int SaveInputValue = ValueInt;

            int[] Binary = new int[32];
            byte index = 0;

            while (Remainder != 0) // it is not known how many times we should devide with the base
            {
                Remainder = ValueInt / NumeralBase; // saving value

                if (ValueInt % NumeralBase != 0)
                {
                    Result = 1;
                }
                else
                {
                    Result = 0;
                }
                ValueInt = Remainder;
                Binary[index] = Result;
                index++;
            }
            if (SaveInputValue >= 0)
            {
                return Binary;
            }
            else
            {
                Binary[31] = 1; // the number is negative and the sign bit is set
                return Binary;
            }
        }
    }
}
