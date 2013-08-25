// Write a method that returns the index of the first element in array 
// that is bigger than its neighbors, or -1, if there’s no such element.
// Use the method from the previous exercise.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ReturnIndexOfBiggerNum
{
    class ReturnIndexOfBiggerNum
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int[] ValuesArr = IputArray();

            for (int i = 1; i < ValuesArr.Length - 1; i++) // it is not needed to check the first and the last elemens as they do not have two neighbours.
            {
                sbyte Check = CompareNeighboursInArr(ValuesArr, i);
                if (Check == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The index of the first element in array that is bigger than its neighbors is {0}.", i);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                else if (i == ValuesArr.Length - 2 && Check == -1) // if the last checked element is not bigger than its neighbours than:
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("No such element: {0}", Check);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
            }
        }

        public static sbyte CompareNeighboursInArr(int[] ValuesArr, int Position)
        {
            sbyte Result = 0;
            if (ValuesArr[Position] > ValuesArr[Position - 1] && ValuesArr[Position] > ValuesArr[Position + 1])
            {
                Result = 1;
                return Result;
            }
            else
            {
                Result = -1;
                return Result;
            }
        }

        public static int[] IputArray()
        {
            Console.Write("Please, enter how long the array should be: ");
            int N = int.Parse(Console.ReadLine());
            int[] InputArr = new int[N];
            Console.WriteLine("Please, enter {0} values:", N);
            for (int i = 0; i < N; i++)
            {
                InputArr[i] = int.Parse(Console.ReadLine());
            }
            return InputArr;
        }
    }
}
