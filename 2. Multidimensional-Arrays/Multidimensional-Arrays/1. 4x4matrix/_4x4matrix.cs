// Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4x4matrix
{
    class _4x4matrix
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"The following matrix will be printed:
1   5   9   13
2   6   10  14
3   7   11  15
4   8   12  16
");
            int[,] arrA = new int[4, 4];
            arrA[0, 0] = 1;
            for (int i = 0; i < arrA.GetLength(0) ; i++) // the rows
            {
                for (int j = 0; j < arrA.GetLength(0); j++) // the columns
                {
                    if (i == 0 && j == 0) // skip the assigned [0,0]
                    {
                        continue;
                    }
                    if (j == 0)
                    {
                        arrA[i,j] = arrA[i-1, 0] + 1;
                    }
                    else if (j >= 1)
                    {
                        arrA[i, j] = arrA[i, j - 1] + 4;
                    }
                }
            }
            for (int i = 0; i < arrA.GetLength(0); i++)
            {
                for (int j = 0; j < arrA.GetLength(1); j++)
                {
                    Console.Write(@"{0}    ", arrA[i,j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n*******************************************************\n");
            Console.WriteLine(@"The following matrix will be printed:
1   8   9   16
2   7   10  15
3   6   11  14
4   5   12  13
");
            int[,] arrB = new int[4, 4];
            arrB[0, 0] = 1;
            for (int i = 1; i < arrB.GetLength(0); i++) // initialise the 1st members of each row
            {
                arrB[i, 0] = arrB[i - 1, 0] + 1;
            }
            for (int i = arrB.GetLength(0) - 1; i >= 0; i--)
			{
			 
			}
            
            int rowIndex = 3;
            int colIndex = 1;
            
            while (arrB[0,3] == 0) // while the last element is not filled
            {
                if (colIndex%2 != 0) // filling the odd column indexes
                {
                    if (rowIndex == 3)
                    {
                        arrB[rowIndex, colIndex] = arrB[rowIndex, colIndex - 1] + 1;
                        rowIndex -= 1;
                    }
                    else if (rowIndex <= 2 && rowIndex >= 0)
                    {
                        arrB[rowIndex, colIndex] = arrB[rowIndex + 1, colIndex] + 1;
                        rowIndex -= 1;
                    }
                    else if (rowIndex < 0)
                    {
                        rowIndex = 0;
                        colIndex += 1;
                    }
                }
                else if (colIndex % 2 == 0) // filling the even column indexes
                {
                    if (rowIndex == 0)
                    {
                        arrB[rowIndex, colIndex] = arrB[rowIndex, colIndex - 1] + 1;
                        rowIndex += 1;
                    }
                    else if (rowIndex <= 3)
                    {
                        arrB[rowIndex, colIndex] = arrB[rowIndex - 1, colIndex] + 1;
                        rowIndex += 1;
                    }
                    else if (rowIndex > 3)
                    {
                        rowIndex = 3;
                        colIndex += 1;
                    }
                }
            }
            for (int i = 0; i < arrB.GetLength(0); i++) // print the matrix
            {
                for (int j = 0; j < arrB.GetLength(1); j++)
                {
                    Console.Write(@"{0}    ", arrB[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n*******************************************************\n");
            

            
            Console.WriteLine(@"The following matrix will be printed:
7   11  14  16
4   8   12  15
2   5   9   13
1   3   6   10
");
            
            int[,] arrC = new int[4, 4];
            int number = 1;
            arrC[3, 0] = number;
            rowIndex = 2;
            int rowSaved = rowIndex;
            colIndex = 0;
            int colSaved = colIndex;

            
            // going through the diagonal for 2/3 of the matrix
            while (rowSaved >= 0)
            {
                number += 1;
                if (rowIndex < 3)
                {
                    arrC[rowIndex, colIndex] = number;
                    rowIndex += 1;
                    colIndex += 1;
                }
                else if (rowIndex == 3) // end of the diagonal
                {
                    arrC[rowIndex, colIndex] = number;
                    rowIndex = rowSaved - 1;
                    colIndex = 0;
                    rowSaved -= 1;
                }
            }
            
            // filling the rest of the matrix
            rowSaved = 0;
            colSaved = 1;
            rowIndex = rowSaved;
            colIndex = colSaved;
            while (colSaved <= 3)
            {
                number += 1;
                if (colIndex < 3)
                {
                    arrC[rowIndex, colIndex] = number;
                    rowIndex += 1;
                    colIndex += 1;
                }
                else if (colIndex == 3) // end of the diagonal
                {
                    arrC[rowIndex, colIndex] = number;
                    colIndex = colSaved + 1;
                    rowIndex = 0;
                    colSaved += 1;
                }
                
            }
            for (int i = 0; i < arrC.GetLength(0); i++) // print the matrix
            {
                for (int j = 0; j < arrC.GetLength(1); j++)
                {
                    Console.Write(@"{0}    ", arrC[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n*******************************************************\n");

            Console.WriteLine(@"The following matrix will be printed:
1   12  11  10
2   13  16  9
3   14  15  8
4   5   6   7
");

            int[,] arrD = new int[4, 4];
            number = 1;
            rowSaved = 0;
            colSaved = 0;
            rowIndex = rowSaved;
            colIndex = colSaved;
            // for the directions:
            int offset = 0;

            while (number <= 4*4)
            {
                //Move down
                for (rowIndex = offset; rowIndex < 4 - offset; rowIndex++)
                {
                    colIndex = offset;
                    arrD[rowIndex, colIndex] = number;
                    number++;
                }
                //Move right
                for (colIndex = 1 + offset; colIndex < 4 - offset; colIndex++)
                {
                    rowIndex = 4 - 1 - offset;
                    arrD[rowIndex, colIndex] = number;
                    number++;
                }
                
                //Move up
                for (rowIndex = 4 - 2 - offset; rowIndex >= offset; rowIndex--)
                {
                    colIndex = 4 - 1 - offset;
                    arrD[rowIndex, colIndex] = number;
                    number++;
                }
                //Move left
                for (colIndex = 4 - 2 - offset; colIndex >= offset + 1; colIndex--)
                {
                    rowIndex = offset;
                    arrD[rowIndex, colIndex] = number;
                    number++;
                }
                offset++;
            }
            for (int i = 0; i < arrD.GetLength(0); i++) // print the matrix
            {
                for (int j = 0; j < arrD.GetLength(1); j++)
                {
                    Console.Write(@"{0}    ", arrD[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
