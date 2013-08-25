using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.DecimalToHexadecimal
{
    class DecimalToHexadecimal
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please, enter a decimal number: ");
            // string ValueStr = Console.ReadLine();
            int ValueInt = int.Parse(Console.ReadLine());
            byte NumeralBase = 16; // base to the next numeral system

            string[] Result = ConvertDecimalToHexadecimal(ValueInt, NumeralBase);
            Print(Result, ValueInt);
        }
        private static void Print(string[] Result, int ValueInt)
        {
            Console.WriteLine("The Hexadecimal representation of the decimal number {0} is:", ValueInt);
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = Result.Length - 1; i >= 0; i--)
            {
                Console.Write(Result[i]);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static string[] ConvertDecimalToHexadecimal(int ValueInt, byte NumeralBase)
        {
            int Remainder = 1;
            string Result = "";
            int SaveInputValue = ValueInt;

            string[] Hexadecimal = new string[32];
            byte index = 0;

            while (Remainder != 0) // it is not known how many times we should devide with the base
            {
                Remainder = ValueInt / NumeralBase; // saving value

                switch (ValueInt % NumeralBase)
                {
                    case 0:
                        Result = "0";
                        break;
                    case 1:
                        Result = "1";
                        break;
                    case 2:
                        Result = "2";
                        break;
                    case 3:
                        Result = "3";
                        break;
                    case 4:
                        Result = "4";
                        break;
                    case 5:
                        Result = "5";
                        break;
                    case 6:
                        Result = "6";
                        break;
                    case 7:
                        Result = "7";
                        break;
                    case 8:
                        Result = "8";
                        break;
                    case 9:
                        Result = "9";
                        break;
                    case 10:
                        Result = "A";
                        break;
                    case 11:
                        Result = "B";
                        break;
                    case 12:
                        Result = "C";
                        break;
                    case 13:
                        Result = "D";
                        break;
                    case 14:
                        Result = "E";
                        break;
                    case 15:
                        Result = "F";
                        break;

                    default:
                        break;
                }

                ValueInt = Remainder;
                Hexadecimal[index] = Result;
                index++;
            }
            return Hexadecimal;
        }
    }
}
