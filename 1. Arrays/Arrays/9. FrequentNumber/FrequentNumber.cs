// Write a program that finds the most frequent number in an array. Example:
//	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.FrequentNumber
{
    class FrequentNumber
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

            int[] Count = new int[Length];

            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    else
                    {
                        if (theArray[i] == theArray[j])
                        {
                            Count[i] += 1;
                        }
                    }
                }
            }

            for (int i = 0; i < Length; i++)
            {
                if (Count[i] == Count.Max())
                {
                    Console.WriteLine("\n{0} ({1} times)", theArray[i], Count[i] + 1); // +1 becouse the value itself was not yet counted.
                    break;
                }
            }
        }
    }
}
