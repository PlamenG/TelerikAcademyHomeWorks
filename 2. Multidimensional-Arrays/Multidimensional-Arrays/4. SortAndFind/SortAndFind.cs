using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.SortAndFind
{
    class SortAndFind
    {
        static void Main(string[] args)
        {
            Console.Write("Please, enter a value for N: ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("Please, enter a value for K: ");
            int K = int.Parse(Console.ReadLine());

            Console.WriteLine("Please, fill the array of {0} numbers:", N);
            int[] theArray = new int[N];
            for (int i = 0; i < N; i++)
            {
                theArray[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(theArray);
            Console.WriteLine("The array is now sorted:");
            for (int i = 0; i < N; i++)
            {
                Console.Write(theArray[i]);
            }
            Console.WriteLine();

            int Result = Array.BinarySearch(theArray, K);

            if (Result > 0)
            {
                Console.WriteLine("\nThe target value of {0} is at index {1}.\n", K, Result);
            }
            else
            {

                int lowIndex = 0;
                int highIndex = N - 1;
                int midIndex = 0;

                while (theArray[midIndex] != K)
                {
                    midIndex = lowIndex + ((highIndex - lowIndex) / 2);
                    
                    if (highIndex - lowIndex <= 1)
                    {
                        if (theArray[lowIndex] <= K && theArray[highIndex] <= K)
                        {
                            Result = Math.Max(theArray[lowIndex], theArray[highIndex]);
                            Console.WriteLine("The nearest number to {0} which is smaller than it is {1}", K, Result);
                            break;
                        }
                        else if (theArray[lowIndex] <= K)
                        {
                            Console.WriteLine("The nearest number to {0} which is smaller than it is {1}", K, theArray[lowIndex]);
                            break;
                        }
                        else if (theArray[highIndex] <= K)
                        {
                            Console.WriteLine("The nearest number to {0} which is smaller than it is {1}", K, theArray[highIndex]);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The nearest number to {0} which is smaller than it is {1}", K, theArray[midIndex - 1]);
                            break;
                        }

                    }
                    else if (theArray[midIndex] < K)
                    {
                        lowIndex = midIndex + 1;
                    }
                    else if (theArray[midIndex] > K)
                    {
                        highIndex = midIndex - 1;
                    }

                }
            }


        }
    }
}
