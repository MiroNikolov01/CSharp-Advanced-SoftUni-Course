using System.Data.SqlTypes;

namespace _03.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSquareSize = Convert.ToInt32(Console.ReadLine());

            int[,] squereMatrix = new int[matrixSquareSize, matrixSquareSize];

            for (int rows = 0; rows < squereMatrix.GetLength(0); rows++)
            {
                int[] numbersRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int cols = 0; cols < squereMatrix.GetLength(1); cols++)
                {
                    squereMatrix[rows, cols] = numbersRow[cols];
                }
            }

            int[] numbers = new int[squereMatrix.GetLength(0)];

            int count = 0;
            for (int rows = 0; rows < squereMatrix.GetLength(0); rows++)
            {
                numbers[rows] = squereMatrix[rows, count];
                count++;
            }
            Stack<int> stackNumbers = new Stack<int>(numbers.Reverse());

            int result = 0;
            while (stackNumbers.Count > 0)
            {
                result += stackNumbers.Pop();
            }
            Console.WriteLine(result);

        }
    }
}
