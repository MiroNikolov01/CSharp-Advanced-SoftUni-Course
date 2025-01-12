namespace _10.RadioactiveMutantVampireBunnies;

public class Program
{
    public static void Main()
    {
        int[] matrixSize = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        (int rows, int cols) = (matrixSize[0], matrixSize[1]);

        char[,] gameField = new char[rows, cols];

        (int playerRow, int playerCol) = (0, 0);

        for (int row = 0; row < gameField.GetLength(0); row++)
        {
            char[] elementsRow = ReadCharArray();
            for (int col = 0; col < gameField.GetLength(1); col++)
            {
                gameField[row, col] = elementsRow[col];
                if (gameField[row, col] == 'P')
                {
                    playerRow = row; playerCol = col;
                }
            }
        }
        char[] movingCommands = ReadCharArray();
        Queue<int[]> bunnyCoordinates = new Queue<int[]>();
        for (int i = 0; i < movingCommands.Length; i++)
        {
            int currentRow = playerRow;
            int currentCol = playerCol;
            switch (movingCommands[i])
            {
                case 'U':
                    playerRow -= 1;
                    break;
                case 'D':
                    playerRow += 1;
                    break;
                case 'R':
                    playerCol += 1;
                    break;
                case 'L':
                    playerCol -= 1;
                    break;
            }
            gameField[currentRow, currentCol] = '.';

            for (int row = 0; row < gameField.GetLength(0); row++)
            {
                for (int col = 0; col < gameField.GetLength(1); col++)
                {
                    if (gameField[row, col] == 'B')
                    {
                        bunnyCoordinates.Enqueue(new int[] { row, col });
                    }
                }
            }
            int length = bunnyCoordinates.Count;
            for (int queueIteration = 0; queueIteration < length; queueIteration++)
            {
                var pairBunnyCoordinates = bunnyCoordinates.Dequeue();
                SpreadBunnyes(pairBunnyCoordinates[0], pairBunnyCoordinates[1], gameField);
            }
           
            if (!CanMovePlayer(playerRow, playerCol, gameField))
            {

                PrintGameFieldRows(gameField);
                Console.WriteLine($"won: {currentRow} {currentCol}");
                return;
            }
            if (gameField[playerRow, playerCol] == 'B')
            {
                PrintGameFieldRows(gameField);
                Console.WriteLine($"dead: {playerRow} {playerCol}");
                return;
            }

        }
    }
    static void PrintGameFieldRows(char[,] gameField)
    {
        for (int rows = 0; rows < gameField.GetLength(0); rows++)
        {
            for (int cols = 0; cols < gameField.GetLength(1); cols++)
            {
                Console.Write($"{gameField[rows, cols]}");
            }
            Console.WriteLine();
        }
    }
    static char[,] SpreadBunnyes(int row, int col, char[,] gameField)
    {
        //Up
        if (CanSpreadBunnyes(row - 1, col, gameField))
        {
            gameField[row - 1, col] = 'B';

        }
        //Down
        if (CanSpreadBunnyes(row + 1, col, gameField))
        {
            
            gameField[row + 1, col] = 'B';
        }
        //Left
        if (CanSpreadBunnyes(row, col - 1, gameField))
        {
           
            gameField[row, col - 1] = 'B';
        }
        //Right
        if (CanSpreadBunnyes(row, col + 1, gameField))
        {
            gameField[row, col + 1] = 'B';
        }
        return gameField;
    }
    static char[] ReadCharArray()
    {
        return Console.ReadLine().ToCharArray();
    }
    static bool CanSpreadBunnyes(int row, int col, char[,] gameField)
    {
        return row >= 0 && row < gameField.GetLength(0) &&
            col >= 0 && col < gameField.GetLength(1);
    }
    static bool CanMovePlayer(int row, int col, char[,] gameField)
    {
        return row >= 0 && row < gameField.GetLength(0) &&
           col >= 0 && col < gameField.GetLength(1);
    }
}
