using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.ElementsWithMaxSum
{
    class ElementsWithMaxSum
    {
        static void Main(string[] args)
        {
            Console.Write("Please, enter a value for N: ");
            int N = int.Parse(Console.ReadLine());

            Console.Write("Please, enter a value for K (<N): ");
            int K = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Please, enter {0} values:", 10);

            int[] Array = new int[N];

            for (int i = 0; i < N; i++)
            {
                Array[i] = int.Parse(Console.ReadLine());
            }

            List<int> List = new List<int>(); // list for the sequence of K elemts;
            
            int[] ArrayResult = new int[K]; //the result with the elements will be saved here;

            long Sum = 0;
            long SumResult = 0;

            for (int i = 0; i < N - K; i++)
            {
                for (int j = i; j < i + K; j++)
                {
                    Sum += Array[j];
                    List.Add(Array[j]);
                }
                if (Sum > SumResult)
                {
                    SumResult = Sum;
                    List.CopyTo(ArrayResult);
                    
                }
                List.Clear();
                Sum = 0;

            }

            for (int i = 0; i < K; i++)
            {
                if (i == 0)
                {
                    Console.Write("{0} {1}, ", "{", ArrayResult[i]);
                }
                else if (i == K - 1)
                {
                    Console.Write("{1} {0}\n", "}", ArrayResult[i]);
                }
                else
                {
                    Console.Write("{0} ,", ArrayResult[i]);
                }
            }

        }
    }
}
