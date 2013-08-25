// You may test with http://www.cleavebooks.co.uk/scol/calnumba.htm


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.AnyNumeraConversion
{
    class AnyNumeraConversion
    {
        static int ConvertToDecimal(string ValueStr, int NumeralBase)
        {
            int[] NumSystemNumber = new int[ValueStr.Length];
            for (int i = 0; i < ValueStr.Length; i++)
            {
                string Numeral = Convert.ToString(ValueStr[i]); // the character is stored in a string in order to be able to operate with it
                int Try;
                if (int.TryParse(Numeral, out Try) == false) // if it is not a number than it is a letter
                {
                    switch (Numeral)
                    {
                        case "A":
                            NumSystemNumber[i] = 10;
                            break;
                        case "B":
                            NumSystemNumber[i] = 11;
                            break;
                        case "C":
                            NumSystemNumber[i] = 12;
                            break;
                        case "D":
                            NumSystemNumber[i] = 13;
                            break;
                        case "E":
                            NumSystemNumber[i] = 14;
                            break;
                        case "F":
                            NumSystemNumber[i] = 15;
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    NumSystemNumber[i] = int.Parse(Numeral);
                }

            }
            int DecimalNumber = 0;
            Array.Reverse(NumSystemNumber);
            for (int i = 0; i < NumSystemNumber.Length; i++) // the rightmost bit must be ignored as it represents only the sign of the number
            {
                DecimalNumber += NumSystemNumber[i] * (int)(Math.Pow(NumeralBase, i));
            }

            return DecimalNumber;
        }
        static  string[] ConvertFromDecimal(int ValueInt, int NumeralBase)
        {
            int Remainder = 1;
            string Result = "";
            int SaveInputValue = ValueInt;

            string[] NumSystemNumber = new string[32];
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
                NumSystemNumber[index] = Result;
                index++;
            }
            return NumSystemNumber;
        }
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please enter a number: ");
            string number = (Console.ReadLine()).ToUpper();
            Console.Write("Please enter the numeral system FROM: ");
            int s = int.Parse(Console.ReadLine());
            Console.Write("Please enter the numeral system TO: ");
            int d = int.Parse(Console.ReadLine());
    
            if (s < 2 || d < 2 || s > 16 || d > 16)
            {
                Console.WriteLine("The numeral systems must be in the range [2 .. 16]");
            }
            else
            {
                int ConvertedToDecimal = ConvertToDecimal(number, s);
                string[] ConvertedFromDecimal = ConvertFromDecimal(ConvertedToDecimal, d);
                Array.Reverse(ConvertedFromDecimal);
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var item in ConvertedFromDecimal)
                {
                    Console.Write(item);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
        }
    }
}
    
    