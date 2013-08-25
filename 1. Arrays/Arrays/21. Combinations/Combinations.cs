// Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. Example:
//	N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21.Combinations
{
    class Combinations
    {
        public static int[] sett;

        public static bool IsThereRepetition(int[] arr)
        // Checks if there is repeating elements in the array
        // returns true if there are repeating elements
        {
            bool isRepeating = false;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        isRepeating = true;
                        goto Exit;

                    }
                }

            }

        Exit: { };

            return isRepeating;
        }

        public static void Print(int[] arr) // Prints array
        {
            Console.Write("{0} ", "{");
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("{0}", "}");
        }

        public static void ClearSubset(int[] arr, int index)
        // Gives value 1 to all elements of the array, starting from 0 to ending with index
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


            int count = 1;

            int index = 1;
            while (sett[k - 1] <= n) // make sure that all posible permotations are reviewed
            {

                for (int i = index; i <= n; i++)
                {
                    sett[0] = i;

                    if (IsThereRepetition(sett) == false)
                    // checks if there are repeating elements in the current array
                    {

                        Print(sett); // Print current combination

                    }

                }
                index++;

                if (index == n)
                {
                    break;
                }

                sett[1]++;

                for (int i = 0; i < k - 1; i++)
                {
                    if (sett[i] == n + 1)
                    {
                        sett[i + 1]++;
                        ClearSubset(sett, i); // updates all elements before the updated with value of 1
                    }
                }
                count++;
            }
        }
    }
}
