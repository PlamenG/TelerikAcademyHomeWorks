// You are given an array of strings. Write a method that sorts the array 
// by the length of its elements (the number of characters composing them).


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.SortByLenghtOfElementsInStr
{
    class SortByLenghtOfElementsInStr
    {
        // Declaring our method 
        static void Main(string[] args)
        {
            string[] ToBeSorted = { "12", "1", "123456789", "1234", "1234567", "123", "12", "1", "123456", "123", "123", "1235678", "123456789" };
            
            int[] StrLength = new int[ToBeSorted.Length];
            for (int i = 0; i < StrLength.Length; i++)
            {
                StrLength[i] = ToBeSorted[i].Length;
            }



            for (int i = 0; i < StrLength.Length; i++) // Insertion Sort - http://community.topcoder.com/tc?module=Static&d1=tutorials&d2=sorting
            {
                int j = i;
                while (j > 0 && StrLength[i] < StrLength[j - 1]) // find the index of the element which will be moved
                {
                    j--;
                }
                int tmp = StrLength[i]; // store the element which will be moved
                string tmpStr = ToBeSorted[i];
                for (int k = i; k > j; k--) // make place for the element which will be moved
                {
                    StrLength[k] = StrLength[k - 1];
                    ToBeSorted[k] = ToBeSorted[k - 1];
                }
                StrLength[j] = tmp;
                ToBeSorted[j] = tmpStr;
            }
            Console.WriteLine("The array is now sorted array by the length of its elements:");
            for (int i = 0; i < ToBeSorted.Length; i++)
            {
                Console.WriteLine(ToBeSorted[i]);
            }
        }
    }
}
