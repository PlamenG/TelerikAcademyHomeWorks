using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.HexadecimalToBinary
{
    class HexadecimalToBinary
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please, enter a hexadecimal number:  ");

            string ValueStr = Console.ReadLine();

            string[] HexadecimalNumber = new string[ValueStr.Length];
            string SaveValue = ValueStr;
            ValueStr = Reverse(ValueStr); // it is needed that the string is reversed for the logic of the calculation

            string[] Result = ConvertHexadecimalToBinary(ValueStr);
            Print(Result, SaveValue);
        }

        public static string[] ConvertHexadecimalToBinary(string ValueStr)
        {
            string[] BinaryNumber = new string[ValueStr.Length];
            for (int i = 0; i < ValueStr.Length; i++)
            {
                string Numeral = Convert.ToString(ValueStr[i]); // the character is stored in a string in order to be able to operate with it
                int Try;
                if (int.TryParse(Numeral, out Try) == false) // if it is not a number than it is a letter
                {
                    switch (Numeral)
                    {
                        case "A":
                            BinaryNumber[i] = "1010";
                            break;
                        case "B":
                            BinaryNumber[i] = "1011";
                            break;
                        case "C":
                            BinaryNumber[i] = "1100";
                            break;
                        case "D":
                            BinaryNumber[i] = "1101";
                            break;
                        case "E":
                            BinaryNumber[i] = "1110";
                            break;
                        case "F":
                            BinaryNumber[i] = "1111";
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    BinaryNumber[i] = Convert.ToString(int.Parse(Numeral), 2).PadLeft(4, '0'); // the decimal value will be saved as a binary string
                }

            }
            return BinaryNumber;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static void Print(string[] Binary, string Hexadecimal)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The binary value of the hexadecimal number {0} is: ", Hexadecimal);
            for (int i = Binary.Length - 1; i >= 0 ; i--)
            {
                Console.Write(Binary[i]);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }
}
