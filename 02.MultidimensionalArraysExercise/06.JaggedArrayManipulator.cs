namespace _06.JaggedArrayManipulator;

public class Program
{
    public static void Main()
    {
        int height = int.Parse(Console.ReadLine());
        double[][] jaggedArray = new double[height][];
        for (int row = 0; row < height; row++)
        {
            double[] lineRow = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            jaggedArray[row] = lineRow;

            if (row > 0)
            {
                if (jaggedArray[row].Length == jaggedArray[row - 1].Length)
                {
                    ProcessRow(jaggedArray, row, true);
                }
                else
                {
                    ProcessRow(jaggedArray, row, false);
                }
            }
        }
        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] tokens = command.Split();

            int row = int.Parse(tokens[1]);
            int col = int.Parse(tokens[2]);
            int value = int.Parse(tokens[3]);

            if (!IsValidIndex(jaggedArray, row, col))
            {
                continue;
            }
            switch (tokens[0])
            {
                case "Add":
                    jaggedArray[row][col] += value;
                    break;
                case "Subtract":
                    jaggedArray[row][col] -= value;
                    break;
            }
        }
        foreach (double[] row in jaggedArray)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
    static bool IsValidIndex(double[][] jaggedArray, int row, int col)
    {
        return row >= 0 && row < jaggedArray.Length &&
      col >= 0 && col < jaggedArray[row].Length;
    }

    static double[][] ProcessRow(double[][] jaggedArray, int row, bool shouldMultiply)
    {
        double number = shouldMultiply == true ? 2 : 0.5;

        for (int i = 0; i < jaggedArray[row].Length; i++)
        {
            jaggedArray[row][i] *= number;

        }
        for (int i = 0; i < jaggedArray[row - 1].Length; i++)
        {
            jaggedArray[row - 1][i] *= number;
        }

        return jaggedArray;
    }
}

