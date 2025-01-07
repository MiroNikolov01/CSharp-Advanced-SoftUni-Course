using System.Data;

namespace _06.JaggedArrayModification
{
    public static class Program
    {
        static void Main()
        {
            int countArrays = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[countArrays][];
            for (int i = 0; i < countArrays; i++)
            {
                jaggedArray[i] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            }
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split();

                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (!IsValidIndex(row, col, jaggedArray))
                {
                    Console.WriteLine("Invalid coordinates");
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
            foreach (int[] row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
        static bool IsValidIndex(int indexRow, int indexCol, int[][] jaggedArray)
        {
            try
            {
                return indexRow >= 0 && indexCol >= 0 &&
                indexRow < jaggedArray[indexRow].Length &&
                indexCol < jaggedArray[indexRow].Length;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
