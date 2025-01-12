using System.ComponentModel;

namespace _07.KnightGame;

public class Program
{
    public static void Main()
    {
        int matrixSize = int.Parse(Console.ReadLine());

        char[,] matrix = new char[matrixSize, matrixSize];

        if (matrixSize < 3)
        {
            Console.WriteLine(0);
            return;
        }

        for (int rows = 0; rows < matrixSize; rows++)
        {
            char[] elemetsRow = Console.ReadLine().ToCharArray();

            for (int cols = 0; cols < matrixSize; cols++)
            {
                matrix[rows, cols] = elemetsRow[cols];
            }
        }

        int countRemoved = 0;
        while (true)
        {
            int maxAttack = 0;
            int maxRow = 0;
            int maxCol = 0;
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    char currentElement = matrix[row, col];
                    if (currentElement == 'K')
                    {
                        int attackedKnights = CaclculateKnightAttacks(matrix, row, col);
                        if (attackedKnights > maxAttack)
                        {
                            maxAttack = attackedKnights;
                            maxRow = row;
                            maxCol = col;
                        }
                    }
                }
            }
            if (maxAttack == 0)
            {
                break;
            }
            else
            {
                matrix[maxRow, maxCol] = '0';
                countRemoved++;
            }
        }
        Console.WriteLine(countRemoved);
    }
    static int CaclculateKnightAttacks(char[,] matrix, int row, int col)
    {
        int count = 0;

        if (IsValidIndex(matrix, row - 2, col - 1))
        {
            if (matrix[row - 2, col - 1] == 'K')
            {
                count++;
            }
        }

        if (IsValidIndex(matrix, row - 2, col + 1))
        {
            if (matrix[row - 2, col + 1] == 'K')
            {
                count++;
            }
        } 

        if (IsValidIndex(matrix, row + 2, col + 1))
        {
            if (matrix[row + 2, col + 1] == 'K')
            {
                count++;
            }
        }

        if (IsValidIndex(matrix, row + 2, col - 1))
        {
            if (matrix[row + 2, col - 1] == 'K')
            {
                count++;
            }
        }

        if (IsValidIndex(matrix, row - 1, col + 2))
        {
            if (matrix[row - 1, col + 2] == 'K')
            {
                count++;
            }
        }


        if (IsValidIndex(matrix, row + 1, col + 2))
        {
            if (matrix[row + 1, col + 2] == 'K')
            {
                count++;
            }
        }


        if (IsValidIndex(matrix, row - 1, col - 2))
        {
            if (matrix[row - 1, col - 2] == 'K')
            {
                count++;
            }
        }

        if (IsValidIndex(matrix, row + 1, col - 2))
        {
            if (matrix[row + 1, col - 2] == 'K')
            {
                count++;
            }
        }
        return count;
    }
    static bool IsValidIndex(char[,] matrix, int row, int col)
    {
        return row >= 0 && row < matrix.GetLength(0) &&
            col >= 0 && col < matrix.GetLength(1);
    }
}
