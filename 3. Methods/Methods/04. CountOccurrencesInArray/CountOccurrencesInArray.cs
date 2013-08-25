// Write a method that counts how many times given number appears in given array. 
// Write a test program to check if the method is working correctly.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CountOccurrencesInArray
{
    class CountOccurrencesInArray
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int[] ValuesStored = IputArray();

            Console.Write("Please, enter a number that is part from the array: ");
            int Value = int.Parse(Console.ReadLine());

            int ToPrint = CountOccurrences(Value, ValuesStored);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The value {0} was entered {1} times.", Value, ToPrint);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static int CountOccurrences(int Value, int[] ValuesStored)
        {
            int Count = 0;
            for (int i = 0; i < ValuesStored.Length; i++)
            {
                if (Value == ValuesStored[i])
                {
                    Count++;
                }
            }
            return Count;
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
