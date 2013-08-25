// Write a method that checks if the element at given position in given 
// array of integers is bigger than its two neighbors (when such exist).


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CompareNeighbours
{
    class CompareNeighbours
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int[] ValuesArr = IputArray();

            Console.Write("Please, enter which position should be compared: ");
            int Position = int.Parse(Console.ReadLine());

            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The number {0} {1} than its neighbours.", ValuesArr[Position], CompareNeighboursInArr(ValuesArr, Position));
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static string CompareNeighboursInArr(int[] ValuesArr, int Position)
        {
            string Result = "";
            if (ValuesArr[Position] > ValuesArr[Position - 1] && ValuesArr[Position] > ValuesArr[Position + 1])
            {
                Result = "is bigger";
                return Result;
            }
            else
            {
                Result = "is not bigger";
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
