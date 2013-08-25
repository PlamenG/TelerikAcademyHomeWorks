using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.BinarySearch
{
    class BinarySearch
    {
        static void Main(string[] args)
        {
            Console.Write("Please, enter how long the array should be: ");
            int Length = int.Parse(Console.ReadLine());

            Console.WriteLine("Please, enter {0} values:", Length);

            int[] theArray = new int[Length];

            for (int i = 0; i < Length; i++)
            {
                theArray[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Please, enter the value that you would like to find: ");
            int TargetValue = int.Parse(Console.ReadLine());

            // Array.BinarySearch(theArray, TargetValue); This is the .NET Framework implementation of this algorithm.

            // On the following link you can find a detailed explanation how binary search works:
            // http://community.topcoder.com/tc?module=Static&d1=tutorials&d2=binarySearch
            // Below is my interpretation in C# - a modification in the condition of the while loop was needed because it was infinete with the statement from the link:
            int lowIndex = 0;
            int highIndex = Length - 1;
            int midIndex = 0;

            while (theArray[midIndex] != TargetValue)
            {
                midIndex = lowIndex + ((highIndex - lowIndex) / 2);
                if (theArray[midIndex] == TargetValue)
                {
                    Console.WriteLine("\nThe target value of {0} is at index {1}.\n", TargetValue, midIndex);
                }
                else if (theArray[midIndex] < TargetValue)
                {
                    lowIndex = midIndex + 1;
                }
                else if (theArray[midIndex] > TargetValue)
                {
                    highIndex = midIndex - 1;
                }
                else
                {
                    Console.WriteLine("The target value is not in the given array.", TargetValue, midIndex);
                }
            }
        }
    }
}
