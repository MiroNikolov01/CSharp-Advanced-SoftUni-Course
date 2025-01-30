namespace _05.AppliedArithmetics;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Action<int, int[]>> functionsMap = new()
        {
            ["add"] = (x, arr) => arr[x] += 1,
            ["multiply"] = (x, arr) => arr[x] *= 2,
            ["subtract"] = (x, arr) => arr[x] -= 1,
            ["print"] = (x, arr) => Console.Write(arr[x] + " ")
        };

        int[] numbers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            if (functionsMap.ContainsKey(command))
            {
                Aggregate(numbers, functionsMap[command]);
            }
            if (command == "print") Console.WriteLine();
        }
    }

    static void Aggregate(int[] numbers, Action<int, int[]> func)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            func(i, numbers);
        }
    }
}