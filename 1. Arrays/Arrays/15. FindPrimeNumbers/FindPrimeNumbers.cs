// Write a program that finds all prime numbers in the range [1...10 000 000]. 
// Use the sieve of Eratosthenes algorithm (find it in Wikipedia). http://en.wikipedia.org/wiki/Sieve_of_Eratosthenes

// Below is my solution which works correctly but it is slow : - ) 
// Here you can find some more optimized solution for this algorithm - http://www.codeproject.com/Articles/490085/Eratosthenes-Sundaram-Atkins-Sieve-Implementation



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.FindPrimeNumbers
{
    class FindPrimeNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The following programm calculates all prime numbers in the range [1...10 000 000].");

            int count = 0;
            List<int?> Numbers = new List<int?>(); // int? allows null values
            for (int i = 0; i <= 10000000; i++)
            {
                Numbers.Add(0 + count);
                count += 1;
            }
            count = 1;
            int p = 2;
            int n = 2;
            int position = 0;
            
            while (true)
            {
                
                while (true)
                {
                    position = n * p;
                    if (position < 10000000) // Starting from p each increment (without p) is marked with null as it is not a prime number.
                    {
                        Numbers[position] = null;
                        n += 1;
                    }
                    else // the cycle is not needed anymore and n is resetted.
                    {
                        n = 2;
                        break;
                    }
                }
                
                while (true)
                {

                    if (p + count >= 10000000) // The whole cycle will stop after p is equal or bigger than 10 000 000.
                    {
                        break;
                    }
                    if (Numbers[p+count] != null) // p will have the value of the next prime number
                    {
                        p = (int)(Numbers[p+count]);
                        count = 1;
                        break;
                    }
                    else
	                {
                        count += 1;
	                }
                }
                
            }

            Numbers.RemoveAll(null);

            for (int i = 0; i < Numbers.Count; i++) // Loop through List with for
            {
                Console.WriteLine(Numbers[i]);
            }
        }
    }
}
