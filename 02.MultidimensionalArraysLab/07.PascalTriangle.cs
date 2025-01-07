using System.Dynamic;

namespace _07.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int triangleHeight = int.Parse(Console.ReadLine());

            int[][] pascalTriangle = new int[triangleHeight][];

            for (int rows = 0; rows < triangleHeight; rows++)
            {
                pascalTriangle[rows] = new int[rows + 1];
                pascalTriangle[rows][0] = 1;
                pascalTriangle[rows][rows] = 1;

                for (int cols = 1; cols < rows; cols++)
                {
                    pascalTriangle[rows][cols] = pascalTriangle[rows - 1][cols - 1] + 
                        pascalTriangle[rows - 1][cols];
                }
            }
            foreach (int[] row in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ",row));
            }

        }
    }
}
