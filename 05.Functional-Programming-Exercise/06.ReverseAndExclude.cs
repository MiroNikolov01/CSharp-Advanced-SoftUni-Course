namespace _06.ReverseAndExclude;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int divisibleNum = int.Parse(Console.ReadLine());

        var result = Action(numbers, x => x % divisibleNum != 0);
        Console.WriteLine(string.Join(" ", result));
    }

    static List<int> Action(int[] array, Func<int, bool> func)
    {
        List<int> result = new List<int>();
        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (func(array[i]))
            {
                result.Add(array[i]);
            }
        }
        return result;
    }
}