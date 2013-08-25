using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.BinaryToHexadecimal
{
    class BinaryToHexadecimal
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please, enter a binary number (up to 32 bits): ");
            
            string ValueInt = Console.ReadLine().PadLeft(32, '0');

            string[] Result = ConvertBinaryToHexadecimal(ValueInt);
            Array.Reverse(Result); // to be correct it must be reversed.
            Print(Result, ValueInt);
        }

        private static void Print(string[] Result, string ValueInt)
        {
            Console.Write("The Hexadecimal representation of the 32 bit binary number \n{0} is:", ValueInt);
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = Result.Length - 1; i >= 0; i--)
            {
                Console.Write(Result[i]);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static string[] ConvertBinaryToHexadecimal(string ValueInt)
        {
            string[] HalfBytes = new string[8]; // Arranging tha halfbytes (4 bits):
            byte Index = 7;
            for (int i = 0; i < 32; i+=4)
            {
                for (int j = i;  j < i + 4; j++)
                {
                    HalfBytes[Index] += ValueInt[j];
                    
                }
                Index--;
            }
            List<string> Hexadecimal = new List<string>(); // the result is saved here and it is not known how long the number would be
            Index = 7;
            bool Check = true;
            while (HalfBytes[Index] == "0000") // the leading zeros will not be needed
            {
                if (Index == 0)
                {
                    Hexadecimal.Add("0"); // border case when binary value is 0
                    Check = false;
                    break;
                }
                Index--;
            }
            
             if (Check) // if true the binary number is bigger than 0
            {
                for (int i = Index; i >= 0; i--)
                {
                    
                    switch (HalfBytes[i])
                    {
                        case "0000":
                            Hexadecimal.Add("0");
                            break;
                        case "0001":
                            Hexadecimal.Add("1");
                            break;
                        case "0010":
                            Hexadecimal.Add("2");
                            break;
                        case "0011":
                            Hexadecimal.Add("3");
                            break;
                        case "0100":
                            Hexadecimal.Add("4");
                            break;
                        case "0101":
                            Hexadecimal.Add("5");
                            break;
                        case "0110":
                            Hexadecimal.Add("6");
                            break;
                        case "0111":
                            Hexadecimal.Add("7");
                            break;
                        case "1000":
                            Hexadecimal.Add("8");
                            break;
                        case "1001":
                            Hexadecimal.Add("9");
                            break;
                        case "1010":
                            Hexadecimal.Add("A");
                            break;
                        case "1011":
                            Hexadecimal.Add("B");
                            break;
                        case "1100":
                            Hexadecimal.Add("C");
                            break;
                        case "1101":
                            Hexadecimal.Add("D");
                            break;
                        case "1110":
                            Hexadecimal.Add("E");
                            break;
                        case "1111":
                            Hexadecimal.Add("F");
                            break;

                        default:
                            break;
                    }
                }
            }
            return Hexadecimal.ToArray();
        }
    }
}
