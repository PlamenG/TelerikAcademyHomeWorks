// Write a program that generates and prints to the console 10 random values in the range [100, 200].

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.RandomPrint
{
    class RandomPrint
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 10; i++)
            {
                GenerateRandomNumber(); // Every instance has its own timeslot in order to generate random numbers
            }
        }

        static Random randomNumber = new Random(); // the random class is declared
        static void GenerateRandomNumber()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int n = randomNumber.Next(100, 201); // The lower bound is inclusive, but the upper one isn't. 
            // Can return between 100 ..... and 200
            Console.WriteLine(n);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
