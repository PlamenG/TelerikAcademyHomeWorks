using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.SequenceOfMaximalSum
{
    class SequenceOfMaximalSum
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

            List<int?> List = new List<int?>(); // list for the sequence of K elemts;

            int?[] ArrayResult = new int?[Length]; //the result with the elements will be saved here. Int? is used in order to have a null value as a default;
          

            long Sum = 0;
            long SumResult = theArray.Sum(); // this is the sum of all elements and it is possible that it is the biggest sequence.

            for (int i = 0; i < Length - 1; i++) // Well, the entered array will be cycled one time : - )
            {
                for (int j = i; j < Length; j++) // To the current element i will be added the next one and it will be compared to the total sum of the array. The currently checked numbers are stored in a list.
                {
                    Sum += theArray[j];
                    List.Add(theArray[j]);
                    if (Sum > SumResult)
                    {
                        SumResult = Sum;
                        Array.Clear(ArrayResult, 0, Length); // The ArrayResult is cleared because it may store previous elemts which are no longer needed.
                        List.CopyTo(ArrayResult);

                    }
                }
                
                List.Clear();
                Sum = 0;

            }

            for (int i = 0; i < Length; i++)
            {
                if (SumResult == theArray.Sum())
                {
                    if (i == 0)
                    {
                        Console.Write("{0} {1}", "{", theArray[i]);
                    }

                    else
                    {
                        Console.Write(", {0}", theArray[i]);
                    }
                }
                else
                {
                    if (ArrayResult[i] != null) // The element will have a null value if there is nothing stored in it.
                    {
                        if (i == 0)
                        {
                            Console.Write("{0} {1}", "{", ArrayResult[i]);
                        }

                        else
                        {
                            Console.Write(", {0}", ArrayResult[i]);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                
                
                
            }
            Console.Write(" {0}", "}");
            Console.WriteLine();
        }
    }
}
