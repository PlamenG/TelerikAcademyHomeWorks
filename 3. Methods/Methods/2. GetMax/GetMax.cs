// Write a method GetMax() with two parameters that returns the bigger of two integers. 
// Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.GetMax
{
    public class GetMax
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please, enter how many numbers will be compared: ");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine("Please, enter {0} numbers:", N);

            int[] NumberArr = new int[N];
            for (int i = 0; i < N; i++)
            {
                NumberArr[i] = int.Parse(Console.ReadLine());
            }
            int Result = GetMaximalNum(NumberArr);

            PrintResult(Result);
        }

        private static void PrintResult(int Result)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The biggest number is {0}.", Result);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static int GetMaximalNum(int[] NumberArr)
        {
            int Max = 0;
            if (NumberArr[0] > NumberArr[1])
            {
                Max = NumberArr[0];
            }
            else if (NumberArr[1] > NumberArr[0])
            {
                Max = NumberArr[1];
            }
            else
            {
                // both are equal so the one with a lower index is taken as a Max number
                Max = NumberArr[0];
            }
            for (int i = 1; i < NumberArr.Length; i++)
            {
                if (NumberArr[i] > Max)
                {
                    Max = NumberArr[i];
                }
            }
            return Max;
        }
    }
}
