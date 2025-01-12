using System.Net;
using System.Security.AccessControl;

namespace _08.Bombs;

public class Program
{
    public static void Main()
    {
        int fieldSize = int.Parse(Console.ReadLine());
        int[,] field = new int[fieldSize, fieldSize];

        for (int rows = 0; rows < fieldSize; rows++)
        {
            int[] fieldRow = ReadArrayFromConsole();
            for (int cols = 0; cols < fieldSize; cols++)
            {
                field[rows, cols] = fieldRow[cols];
            }
        }
        int[] bombCoordinates = ReadArrayFromConsole();

        for (int i = 0; i < bombCoordinates.Length; i += 2)
        {
            int row = bombCoordinates[i];
            int col = bombCoordinates[i + 1];

            if (field[row, col] <= 0)
            {
                continue;
            }

            int bombValue = field[row, col];
            //Left
            if (CanExplode(row, col - 1, field) && field[row, col - 1] > 0)
            {
                field[row, col -1] -= bombValue;
            }
            //Right
            if (CanExplode(row, col + 1, field) && field[row, col + 1] > 0)
            {
                field[row, col + 1] -= bombValue;
            }
            //Up
            if (CanExplode(row + 1, col, field) && field[row + 1, col] > 0)
            {
                field[row + 1, col] -= bombValue;
            }
            //Down
            if (CanExplode(row - 1, col, field) && field[row - 1, col] > 0)
            {
                field[row - 1, col] -= bombValue;
            }
            //Up-Left
            if (CanExplode(row + 1, col - 1, field) && field[row + 1, col - 1] > 0)
            {
                field[row + 1, col - 1] -= bombValue;
            }
            //Up-Right
            if (CanExplode(row + 1, col + 1, field) && field[row+1, col + 1] > 0)
            {
                field[row + 1 , col + 1] -= bombValue;
            }
            //Down-Left
            if (CanExplode(row - 1, col - 1, field) && field[row - 1, col - 1] > 0)
            {
                field[row - 1, col - 1] -= bombValue;
            }
            //Down-Right
            if (CanExplode(row - 1, col + 1, field) && field[row - 1, col + 1] > 0)
            {
                field[row -1 , col + 1] -= bombValue;
            }

            field[row, col] = 0;
        }
        int countAliveCells = 0;
        int sum = 0;
        for (int row = 0; row < field.GetLength(0); row++)
        {
            for (int col = 0; col < field.GetLength(1); col++)
            {
                if (field[row, col] > 0)
                {
                    countAliveCells++;
                    sum += field[row, col];
                }
            }
        }

        Console.WriteLine($"Alive cells: {countAliveCells}");
        Console.WriteLine($"Sum: {sum}");

        for (int row = 0; row < field.GetLength(0); row++)
        {
            for (int col = 0; col < field.GetLength(1); col++)
            {
                Console.Write(field[row, col] + " ");
            }
            Console.WriteLine();
        }


    }
    public static int[] ReadArrayFromConsole()
    {
        return Console.ReadLine()
            .Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
    public static bool CanExplode(int row, int col, int[,] matrix)
    {
        return row >= 0 && row < matrix.GetLength(0) &&
            col >= 0 && col < matrix.GetLength(1);
    }
}
