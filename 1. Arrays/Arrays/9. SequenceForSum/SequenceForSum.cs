// Write a program that finds in given array of integers a sequence of given sum S (if present). 
// Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}	


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.SequenceForSum
{
    class SequenceForSum
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

            Console.Write("Please, enter the Sum: ");
            long inputSum = int.Parse(Console.ReadLine());

            List<int?> List = new List<int?>(); // list for the sequence of K elemts;

            int?[] ArrayResult = new int?[Length]; //the result with the elements will be saved here. Int? is used in order to have a null value as a default;


            long Sum = 0;
            
            for (int i = 0; i < Length - 1; i++) 
            {
                for (int j = i; j < Length; j++) // To the current element i will be added the next one and it will be compared to the sum. The currently checked numbers are stored in a list.
                {
                    Sum += theArray[j];
                    List.Add(theArray[j]);
                    if (Sum == inputSum)
                    {
                        List.CopyTo(ArrayResult);
                        break; // The answer is already stored and we do not need to check for more possible sequences.
                    }
                }

                List.Clear();
                Sum = 0;

            }

            for (int i = 0; i < Length; i++)
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

            Console.Write(" {0}", "}");
            Console.WriteLine();
        }
    }
}
