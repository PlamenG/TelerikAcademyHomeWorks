// Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. Example:
//	N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20.VariationInSet
{
    class VariationInSet
    {
        public static int[] sett;

        public static void Print(int[] arr)  // Prints the array
        {
            Console.Write("{0} ", "{");
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("{0}", "}");
        }

        public static void ClearSubset(int[] arr, int index)
        // Gives value of 1 to all elements of the array, starting from 0 to ending with index
        {
            for (int i = 0; i <= index; i++)
            {
                arr[i] = 1;
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Please, enter N: ");

            int n = int.Parse(Console.ReadLine());

            Console.Write("Please, enter K (<N): ");

            int k = int.Parse(Console.ReadLine());

            sett = new int[k];



            ClearSubset(sett, k - 1);

            // all elements of sett[] have value of 1

            int count = 1;
            while (sett[k - 1] <= n) // the total num of variations
            {
                for (int i = 1; i <= n; i++)
                {
                    sett[0] = i;

                    Print(sett);
                }

                sett[1]++;

                for (int i = 0; i < k - 1; i++) // updates the current element
                {
                    if (sett[i] == n + 1)
                    {
                        sett[i + 1]++;
                        ClearSubset(sett, i); // all elements before the current update should have
                        // value of 1

                    }
                }
                count++;
            }
        }
    }
}
