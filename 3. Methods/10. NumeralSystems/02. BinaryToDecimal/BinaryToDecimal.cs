using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BinaryToDecimal
{
    class BinaryToDecimal
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("If you would like to convert a negative number you must give the binary number with all 32 bits.");
            Console.Write("Please, enter a 32 bit binary number:  ");
            // example for a signed number - 10000000000000000000000010010100 (-148)
            string ValueStr = Console.ReadLine();
            // int ValueInt = int.Parse(ValueStr);
            // byte NumeralBase = 10; // base to the next numeral system

            byte[] BinaryNumber = new byte[32];
            string SaveValue = ValueStr;
            ValueStr = Reverse(ValueStr); // it is needed that the string is reversed
            
            int Result = ConvertBinaryToDecimal(ValueStr, BinaryNumber);
            Print(Result, SaveValue);
        }

        public static int ConvertBinaryToDecimal(string ValueStr, byte[] BinaryNumber)
        {
            for (int i = 0; i < ValueStr.Length; i++)
            {
                BinaryNumber[i] = byte.Parse(Convert.ToString(ValueStr[i]));
            }
            int DecimalNumber = 0;
            for (int i = 0; i < BinaryNumber.Length - 1; i++) // the rightmost bit must be ignored as it represents only the sign of the number
            {
                DecimalNumber += BinaryNumber[i] * (int)(Math.Pow(2, i));
            }
            if (BinaryNumber[31] == 1)
            {
                // the leftmost bit is signed therefore the number is negative
                DecimalNumber = DecimalNumber * (-1);
                return DecimalNumber;
            }
            else
	        {
                return DecimalNumber;
	        }
            
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static void Print(int Result, string Binary)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The decimal value of the binary number {0} is: {1}", Binary, Result);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
