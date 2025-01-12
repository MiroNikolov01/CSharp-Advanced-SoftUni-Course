namespace _03.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            (int rows, int cols) = (matrixSizes[0], matrixSizes[1]);

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] charRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = charRow[col];
                }
            }
            int maxSum = int.MinValue;
            int sum = 0;
            int maxRow = -1;
            int maxCol = -1;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    sum = Calculate3x3Sum(matrix, row, col);

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
            PrintMaxElements(matrix, maxRow, maxCol, maxSum);

        }
        static int Calculate3x3Sum(int[,] matrix, int row, int col)
        {
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sum += matrix[row + i, col + j];
                }
            }
            return sum;
        }
        static void PrintMaxElements(int[,] matrix,int maxRow,int maxCol,int maxSum)
        {
            Console.WriteLine("Sum = " + maxSum);
            for (int i = maxRow; i <= maxRow + 2; i++)
            {
                for (int j = maxCol; j <= maxCol + 2; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}




