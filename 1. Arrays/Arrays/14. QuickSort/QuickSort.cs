// Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).
// About the algorithm - http://en.wikipedia.org/wiki/Quicksort


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.QuickSort
{
    class QuickSort
    {
        static void Main(string[] args)
        {
            // Create an unsorted array of string elements

            Console.Write("Please, enter how long the array should be: ");
            int Length = int.Parse(Console.ReadLine());

            string[] unsorted = new string[Length];
            for (int i = 0; i < Length; i++)
            {
                unsorted[i] = Console.ReadLine();
            }
 
            
            Console.WriteLine();
 
            // Sort the array
            Quicksort(unsorted, 0, unsorted.Length - 1);
 
            // Print the sorted array
            Console.WriteLine("The array now sorted");
            for (int i = 0; i < unsorted.Length; i++)
            {
                Console.Write(unsorted[i] + " ");
            }
 
            Console.WriteLine();
 

        }

        public static void Quicksort(IComparable[] elements, int leftSide, int rightSide) // More information about IComparable - http://www.dotnetperls.com/icomparable
        {
            int i = leftSide, j = rightSide;
            IComparable Pivot = elements[(leftSide + rightSide) / 2];
 
            while (i <= j)
            {
                while (elements[i].CompareTo(Pivot) < 0) // Checks if the element preceeds the pivot
                {
                    i++; // The next element from the beginning will be checked
                }
 
                while (elements[j].CompareTo(Pivot) > 0) // Checks if the elemnt is after the pivot
                {
                    j--; // The left element (from the last) will be checked
                }
 
                if (i <= j)
                {
                    // The elements are swapped in order to be sorted
                    IComparable tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;
 
                    i++;
                    j--;
                }
            }
            
            // Recursive calls
            if (leftSide < j)
            {
                Quicksort(elements, leftSide, j);
            }
 
            if (i < rightSide)
            {
                Quicksort(elements, i, rightSide);
            }
        }
    }
}

