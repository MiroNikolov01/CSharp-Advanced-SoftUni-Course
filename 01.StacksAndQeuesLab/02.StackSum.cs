using System.Reflection.Metadata;

namespace _02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            Stack<int> stackNumbers = new Stack<int>(numbers);
            string command;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] tokens = command.Split(' ');
                switch (tokens[0])
                {
                    case "add":
                        for (int i = 1; i <= 2; i++)
                        {
                            stackNumbers.Push(int.Parse(tokens[i]));
                        }
                        break;
                    case "remove":
                        int countNumbers = int.Parse(tokens[1]);
                        if (countNumbers <= stackNumbers.Count)
                        {
                            for (int i = 0; i < countNumbers; i++)
                            {
                            stackNumbers.Pop();
                            }
                        }
                            break;
                }
            }
            Console.WriteLine($"Sum: {stackNumbers.Sum()}");
        }
    }
}
