// Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.IncreasingSequence
{
    class IncreasingSequence
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter 10 values:");

            int[] Array = new int[10];

            for (int i = 0; i < 10; i++)
            {
                Array[i] = int.Parse(Console.ReadLine());
            }

            byte counter1 = 1; // will count the first sequence;
            byte counter2 = 0; // will count the next sequence in order to compare with the first;
            byte counterSaved = 1;
            int valueSaved = 0;

            List<int> List1 = new List<int>(); // list for the first sequence (counter1);
            List<int> List2 = new List<int>(); // list for the next sequence (counter2);

            for (int i = 1; i < 10; i++)
            {
                if (counter2 == 0)
                {
                    if (Array[i - 1] + 1 == Array[i])
                    {
                        counter1 += 1;
                        List1.Add(Array[i-1]);
                    }
                    else
                    {
                        counter2 = 1; // counter2 is resetted so the first if is false;
                    }
                    if (counter1 > counterSaved)
                    {
                        // Here the result is stored:
                        counterSaved = counter1;
                        valueSaved = List1[0];
                    }

                }
                else
                {
                    if (Array[i - 1] + 1 == Array[i])
                    {
                        counter2 += 1;
                        List2.Add(Array[i-1]);
                    }
                    else // If there are consecutive sequences the following must be checked:
                    {
                        if (counter1 > counter2 && counter1 > counterSaved)
                        {
                            // Here the result is stored:
                            counterSaved = counter1;
                            valueSaved = List1[0];
                        }
                        else if (counter2 > counter1 && counter2 > counterSaved)
                        {
                            counterSaved = counter2;
                            valueSaved = List2[0];
                        }
                        counter1 = 1;
                        counter2 = 0;
                        List1.Clear();
                        List2.Clear();
                    }
                }
            }

            Console.Write("{0} {1}, ", "{", valueSaved);
            byte toIncreaseNumber = 1;

            for (int i = 0; i < counterSaved - 1; i++)
            {
                
                if (i < counterSaved - 2)
                {
                    Console.Write("{0}, ", valueSaved + toIncreaseNumber);
                    toIncreaseNumber += 1;
                }
                else
                {
                    Console.WriteLine("{0} {1}", valueSaved + counterSaved - 1, "}");
                }
            }
        }
    }
}
