// Write a program that creates an array containing all letters from the alphabet (A-Z). 
// Read a word from the console and print the index of each of its letters in the array.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.AlphabetArray
{
    class AlphabetArray
    {
        static void Main(string[] args)
        {
            char[] Alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            int[] AlphabetAscii = new int[26];
            byte Begin = 97; // decimal code for letter 'a' in http://www.asciitable.com/
            for (int i = 0; i < 26; i++)
            {
                AlphabetAscii[i] = Begin;
                Begin += 1;                
            }
            
            Console.Write("Please, enter a word (small case only): ");
            string Word = Console.ReadLine();

            char checkedChar = '.';

            int WordLength = Word.Length;
            int targetValue = 0;
            int index = 0;
            for (int i = 0; i < WordLength; i++)
            {
                checkedChar = Word[i]; // The characters are checked one after another;
                targetValue = (int)checkedChar; // The ASCII code of the character is saved;
                index = Array.BinarySearch(AlphabetAscii, targetValue); // the .NET Framework build in binary search;
                Console.WriteLine("The index of the letter {0} is {1}.", checkedChar, index);
            }
        }
    }
}
