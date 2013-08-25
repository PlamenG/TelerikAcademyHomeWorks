// Write a program that reads two arrays from the console and compares them element by element.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.CompareArrays
{
    class CompareArrays
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter the members of the first array (10):");
            int[] FirstArray = new int[10];
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Member {0} is: ", i);
                FirstArray[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nPlease, enter the members of the second array (10):");
            int[] SecondArray = new int[10];
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Member {0} is: ", i);
                SecondArray[i] = int.Parse(Console.ReadLine());
            }

            byte countTrue = 0;
            byte countFalse = 0;
            byte countEquals = 0;

            for (int i = 0; i < 10; i++)
            {
                if (FirstArray[i] > SecondArray[i])
                {
                    countTrue += 1;
                }
                else if (FirstArray[i] == SecondArray[i])
                {
                    countEquals += 1;
                }
                else
                {
                    countFalse += 1;
                }
            }

            Console.WriteLine("The first and second arrays were compared:");
            Console.WriteLine("There are {0} members that are equal", countEquals);
            Console.WriteLine("There are {0} members from the first array that are bigger compared to their counter part in the second array", countTrue);
            Console.WriteLine("There are {0} members from the second array that are bigger compared to their counter part in the first array", countFalse);
        }
    }
}
