using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.FindMaximalElementInPortion
{
    class FindMaximalElementInPortion
    {
        static void Main(string[] args)
        {
            int[] ValuesArr = IputArray();
            Console.Write("At which index to start: ");
            int Start = int.Parse(Console.ReadLine());
            Console.Write("How long the portion should be: ");
            int Portion = int.Parse(Console.ReadLine());

            

            int? Result = GetMaximalNum(ValuesArr, Start, Portion);
            if (Result == null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The portion is too long. Please, enter a lower value");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                PrintResult(Result);
            }
            
        }

        private static void PrintResult(int? Result)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The biggest number in the selected portion is {0}.", Result);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static int? GetMaximalNum(int[] NumberArr, int Start, int Length)
        {
            int Max = 0;

            if (Start + Length > NumberArr.Length)
            {
                return null;
            }

            for (int i = Start; i <= Start + Length; i++)
            {
                if (NumberArr[i] > Max)
                {
                    Max = NumberArr[i];
                }
            }
            return Max;
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
