namespace _02.SquaresInMatrix
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

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] charRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = charRow[col];
                }
            }
            int countSquareMatix = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row, col] == matrix[row + 1, col] && 
                        matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        countSquareMatix++;
                    }
                }
            }
            Console.WriteLine(countSquareMatix);

        }
    }
}
