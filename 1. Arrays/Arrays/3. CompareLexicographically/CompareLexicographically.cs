// Write a program that compares two char arrays lexicographically (letter by letter).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.CompareLexicographically
{
    class CompareLexicographically
    {
        static void Main(string[] args)
        {
            // Please, note that the arrays are in char which means that only one character may be given as an input - otherwise an exception will be thrown.
            
            Console.WriteLine("Please, enter the members of the first array (10):");
            char[] FirstArray = new char[10];
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Member {0} is: ", i);
                FirstArray[i] = Convert.ToChar(Console.ReadLine());
            }

            Console.WriteLine("\nPlease, enter the members of the second array (10):");
            char[] SecondArray = new char[10];
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Member {0} is: ", i);
                SecondArray[i] = Convert.ToChar(Console.ReadLine());
            }

            
            byte countEquals = 0;

            for (int i = 0; i < 10; i++)
            {
                
                if (FirstArray[i] == SecondArray[i])
                {
                    countEquals += 1;
                }
                
            }

            Console.WriteLine("The first and second arrays were compared:");
            Console.WriteLine("There are {0} members that are equal", countEquals);
        }
    }
}

