namespace _02.SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = ReadArray();
            int[,] matrix = new int[matrixSize[0], matrixSize[1]];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] numbers = ReadArray();
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = numbers[cols];
                }
            }
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                int sum = 0;
                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    sum += matrix[rows, cols];
                }
                Console.WriteLine(sum);
            }
        }
        static int[] ReadArray()
        {
            return Console.ReadLine()
                    .Split(new string[] { ", "," " },StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray(); ;
        }
    }
}
