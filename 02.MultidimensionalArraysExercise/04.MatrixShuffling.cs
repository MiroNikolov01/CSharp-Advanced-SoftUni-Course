namespace _04.MatrixShuffling
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

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] numbersRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbersRow[col];
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] coordinates = command.Split();
                if (coordinates[0] == "swap")
                {
                    if (coordinates.Length > 5 || coordinates.Length < 5)
                    {
                        PrintInvalidMessage();
                        continue;
                    }

                    (int row1, int col1, int row2, int col2) =
                        (int.Parse(coordinates[1]),
                        int.Parse(coordinates[2]),
                        int.Parse(coordinates[3]),
                        int.Parse(coordinates[4]));

                    if (IsValidIndex(matrix, row1, col1, row2, col2))
                    {
                        string temp = matrix[row2, col2];
                        matrix[row2, col2] = matrix[row1, col1];
                        matrix[row1, col1] = temp;
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        PrintInvalidMessage();
                    }
                }
            }
        }
        static bool IsValidIndex(string[,] matrix, int row1, int col1, int row2, int col2)
        {
            return row1 >= 0 && row1 < matrix.GetLength(0) &&
                col1 >= 0 && col1 < matrix.GetLength(1) &&
                row2 >= 0 && row2 < matrix.GetLength(0) &&
                col2 >= 0 && col2 < matrix.GetLength(1);
        }
        static void PrintInvalidMessage()
        {
            Console.WriteLine("Invalid input!");
        }
    }
}
