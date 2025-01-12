namespace _01.DiagonalDifference
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];

            for (int rows = 0; rows < matrixSize; rows++)
            {
                int[] numbersRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int cols = 0; cols < matrixSize; cols++)
                {
                    matrix[rows, cols] = numbersRow[cols];
                }
            }
            int count = 0;
            int sumLeft = 0;
            for (int rows = 0; rows < matrixSize; rows++)
            {
                sumLeft += matrix[rows, count];
                count++;
                if (count == matrixSize) break;
                
            }
            int sumRight = 0;
            for (int rows = 0; rows < matrixSize; rows++)
            {
                sumRight += matrix[rows, count - 1];
                count--;
                if (count == 0) break;
                
            }
            Console.WriteLine(Math.Abs(sumLeft - sumRight));
        }
    }
}
