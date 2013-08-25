using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.HexadecimalToDecimal
{
    class HexadecimalToDecimal
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please, enter a hexadecimal number:  ");
            
            string ValueStr = Console.ReadLine();

            string[] HexadecimalNumber = new string[ValueStr.Length];
            string SaveValue = ValueStr;
            ValueStr = Reverse(ValueStr); // it is needed that the string is reversed for the logic of the calculation

            int Result = ConvertHexadecimalToDecimal(ValueStr);
            Print(Result, SaveValue);
        }

        public static int ConvertHexadecimalToDecimal(string ValueStr)
        {
            int[] HexadecimalNumber = new int[ValueStr.Length];
            for (int i = 0; i < ValueStr.Length; i++)
            {
                string Numeral = Convert.ToString(ValueStr[i]); // the character is stored in a string in order to be able to operate with it
                int Try;
                if (int.TryParse(Numeral, out Try) == false) // if it is not a number than it is a letter
                {
                    switch (Numeral)
                    {
                        case "A":
                            HexadecimalNumber[i] = 10;
                            break;
                        case "B":
                            HexadecimalNumber[i] = 11;
                            break;
                        case "C":
                            HexadecimalNumber[i] = 12;
                            break;
                        case "D":
                            HexadecimalNumber[i] = 13;
                            break;
                        case "E":
                            HexadecimalNumber[i] = 14;
                            break;
                        case "F":
                            HexadecimalNumber[i] = 15;
                            break;

                        default:
                            break;
                    }
                }
                else
	            {
                    HexadecimalNumber[i] = int.Parse(Numeral);
	            }
                
            }
            int DecimalNumber = 0;
            for (int i = 0; i < HexadecimalNumber.Length; i++) // the rightmost bit must be ignored as it represents only the sign of the number
            {
                DecimalNumber += HexadecimalNumber[i] * (int)(Math.Pow(16, i));
            }
            
            return DecimalNumber;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static void Print(int Result, string Hexadecimal)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The decimal value of the hexadecimal number {0} is: {1}", Hexadecimal, Result);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
