// Sorting an array means to arrange its elements in increasing order. 
// Write a program to sort an array. Use the "selection sort" algorithm: 
// Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.SortArray
{
    class SortArray
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter {0} values:", 10);

            int[] theArray = new int[10];

            for (int i = 0; i < 10; i++)
            {
                theArray[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(theArray); // The easiest way to sort an array in ascending order.

            Console.WriteLine("The Array is now sorted:");
            
            foreach (int value in theArray)
            {
                Console.Write(value);
                Console.Write(' ');
            }
            Console.WriteLine();

        }
    }
}
