using System.Data.Common;
using System.Security;

namespace _05.SquareWithMaximumSum
{
    public static class Program
    {
        public static void Main()
        {
            int[] matrixSizes = ReadArray();

            int[,] matrix = new int[matrixSizes[0], matrixSizes[1]];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {

                int[] numberRows = ReadArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = numberRows[cols];
                }
            }

            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;
            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
                {
                    int sum = matrix[rows, cols] +
                        matrix[rows, cols + 1] +
                        matrix[rows + 1, cols] + 
                        matrix[rows + 1, cols + 1];

                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        maxRow = rows;
                        maxCol = cols;
                    }
                }
            }
            Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]}");
            Console.WriteLine($"{matrix[maxRow + 1, maxCol]} {matrix[maxRow + 1, maxCol + 1]}");
            Console.WriteLine(maxSum);
        }
        public static int[] ReadArray()
        {
            return Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
        }
    }
}
