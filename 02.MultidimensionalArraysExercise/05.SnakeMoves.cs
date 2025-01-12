using System.Data.Common;

namespace _05.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string snakeText = Console.ReadLine();

            (int row, int col) = (matrixSize[0], matrixSize[1]);
            char[,] matrix = new char[row, col];

            int currentIndex = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = snakeText[currentIndex % snakeText.Length];
                    currentIndex++;
                }
            }
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                if (rows % 2 == 0)
                {
                    for (int cols = 0; cols < matrix.GetLength(1); cols++)
                    {
                        Console.Write(matrix[rows, cols]);
                    }
                }
                else
                {
                    for (int cols = matrix.GetLength(1) - 1; cols >= 0; cols--)
                    {
                        Console.Write(matrix[rows, cols]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
