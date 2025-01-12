namespace _09.Miner;

public class Program
{
    public static void Main()
    {
        int matrixSize = int.Parse(Console.ReadLine());

        string[,] gameField = new string[matrixSize, matrixSize];

        string[] directions = ReadArrayFromConsole();

        int totalCoals = 0;

        (int rowPosition, int colPosition) = (0, 0);
        for (int rows = 0; rows < matrixSize; rows++)
        {
            string[] elements = ReadArrayFromConsole();
            for (int cols = 0; cols < matrixSize; cols++)
            {
                gameField[rows, cols] = elements[cols];
                if (gameField[rows, cols] == "s")
                {
                    rowPosition = rows;
                    colPosition = cols;
                }
                else if (gameField[rows, cols] == "c")
                {
                    totalCoals++;
                }
            }
        }
        int movedPositionRow = rowPosition;
        int movedPositionCol = colPosition;
        int coalsCollected = 0;
        for (int i = 0; i < directions.Length; i++)
        {
            string command = directions[i];
            if (command == "left")
            {
                movedPositionCol = colPosition - 1;
            }
            else if (command == "right")
            {
                movedPositionCol = colPosition + 1;
            }
            else if (command == "up")
            {
                movedPositionRow = rowPosition - 1;
            }
            else if (command == "down")
            {
                movedPositionRow = rowPosition + 1;
            }

            if (CanMove(movedPositionRow, movedPositionCol, gameField))
            {
                if (gameField[movedPositionRow, movedPositionCol] == "c")
                {
                    coalsCollected++;
                    gameField[movedPositionRow, movedPositionCol] = "*";
                }
                else if (gameField[movedPositionRow, movedPositionCol] == "e")
                {
                    Console.WriteLine($"Game over! ({movedPositionRow}, {movedPositionCol})");
                    return;
                }
                rowPosition = movedPositionRow;
                colPosition = movedPositionCol;
            }
            else
            {
                movedPositionRow = rowPosition;
                movedPositionCol = colPosition;
            }

            if (HasCollectedAllCoals(gameField))
            {
                Console.WriteLine($"You collected all coals! ({rowPosition}, {colPosition})");
                return;
            }
        }

        Console.WriteLine($"{totalCoals - coalsCollected} coals left. ({rowPosition}, {colPosition})");
    }

    public static bool HasCollectedAllCoals(string[,] gameField)
    {
        for (int rows = 0; rows < gameField.GetLength(0); rows++)
        {
            for (int cols = 0; cols < gameField.GetLength(1); cols++)
            {
                if (gameField[rows, cols] == "c")
                {
                    return false;
                }
            }
        }
        return true;
    }
    public static string[] ReadArrayFromConsole()
    {
        return Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
    }
    public static bool CanMove(int row, int col, string[,] field)
    {
        return row >= 0 && row < field.GetLength(0) &&
            col >= 0 && col < field.GetLength(1);
    }
}
