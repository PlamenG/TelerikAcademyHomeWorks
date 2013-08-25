// Write a program to calculate n! for each n in the range [1..100]. 
// Hint: Implement first a method that multiplies a number represented as array of digits by given integer number. 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _10.Factorial
{
    class Factorial
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            BigInteger[] Result = StoreFactorial();

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine("{0}! equals:", i);
                Console.WriteLine(Result[i]);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static BigInteger[] StoreFactorial()
        {
            BigInteger[] StoreFactorial = new BigInteger[101];

            for (int i = 0; i < StoreFactorial.Length; i++)
            {
                StoreFactorial[i] = 1;
            }

            for (int i = 1; i <= 100; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    StoreFactorial[i] *= j;
                }
            }
            return StoreFactorial;
        }
    }
}
