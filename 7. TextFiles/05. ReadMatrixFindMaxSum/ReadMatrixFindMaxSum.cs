using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _05.ReadMatrixFindMaxSum
{
    class ReadMatrixFindMaxSum
    {
        static void Main(string[] args)
        {
            String Input = File.ReadAllText("Matrix.txt");

            int x = 0, y = 0;
            int[,] ValuesInMatrix = new int[5, 4];
            foreach (var line in Input.Split('\n'))
            {
                y = 0;
                foreach (var column in line.Trim().Split(' '))
                {
                    ValuesInMatrix[x, y] = int.Parse(column.Trim());
                    y++;
                }
                x++;
            }

            int Result = FindMaxSum(ValuesInMatrix);

            StreamWriter writer = new StreamWriter("Result.txt");
            using (writer)
            {
                writer.WriteLine(Result);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"You can find the new file at [your path here]\05. ReadMatrixFindMaxSum\bin\Debug folder.");
            Console.ForegroundColor = ConsoleColor.White;
            
        }

        private static int FindMaxSum(int[,] ValuesInMatrix)
        {

            int bestSum = int.MinValue;

            int bestRow = 0;

            int bestCol = 0;



            for (int row = 0; row <= ValuesInMatrix.GetLength(0) - 2; row++)
            {

                for (int col = 0; col <= ValuesInMatrix.GetLength(1) - 2; col++)
                {

                    int sum = ValuesInMatrix[row, col] + ValuesInMatrix[row, col + 1] +
                                ValuesInMatrix[row + 1, col] + ValuesInMatrix[row + 1, col + 1];

                    if (sum > bestSum)
                    {

                        bestSum = sum;

                        bestRow = row;

                        bestCol = col;

                    }

                }

            }

            return bestSum;
        }
    }
}
