using System.Reflection.PortableExecutable;

namespace _04.SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeMatrix, sizeMatrix];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                char[] symbols = Console.ReadLine().ToCharArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = symbols[cols];
                }
            }
            char expectedSymbol = char.Parse(Console.ReadLine());

            int[] coordinates = new int[2];
            bool isFound = false;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (matrix[rows, cols] == expectedSymbol)
                    {
                        isFound = true;
                        coordinates[0] = rows;
                        coordinates[1] = cols;
                        break;
                    }
                }
                if (isFound)
                {
                    break;
                }
            }
            if (isFound)
            {
                Console.WriteLine($"({string.Join(", ", coordinates)})");
                Environment.Exit(0);
            }
            Console.WriteLine($"{expectedSymbol} does not occur in the matrix");
        }
    }
}
