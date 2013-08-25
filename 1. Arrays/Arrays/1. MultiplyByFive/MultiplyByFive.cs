// Write a program that allocates array of 20 integers and initializes each element 
// by its index multiplied by 5. Print the obtained array on the console.




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.MultiplyByFive
{
    class MultiplyByFive
    {
        static void Main(string[] args)
        {
            int[] NewIntArray = new int[20];

            for (int i = 0; i < 20; i++)
            {
                NewIntArray[i] = i * 5; // Each element in the array is initialized by multiplying its index by 5.
            }

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Array member {0} has a value of {1}", i, NewIntArray[i]);
            }

        }
    }
}
