using System.Globalization;

namespace _01.SumMatrix
{
    public static class Program
    {
        public static void Main()
        {
            int[] matrixSize = ReadArray();
            int[,] matrix = new int[matrixSize[0], matrixSize[1]];

            int sum = 0;
            for (int rows = 0; rows < matrixSize[0]; rows++)
            {
                int[] numbersInMatric = ReadArray();

                for (int cols = 0; cols <= numbersInMatric.Length - 1; cols++)
                {
                    matrix[rows, cols] = numbersInMatric[cols];
                    sum += numbersInMatric[cols];
                }
            }
            Console.WriteLine($"{matrixSize[0]}\n" +
                              $"{matrixSize[1]}\n" +
                              $"{sum}");
        }
        static int[] ReadArray()
        {
            return Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();
        }
    }
}
