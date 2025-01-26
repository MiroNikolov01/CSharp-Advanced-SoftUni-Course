namespace _01.SortEvenNumbers;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(string.Join(", ",Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(n => int.Parse(n))
            .Where(n => n % 2 == 0)
            .OrderBy(n => n)
            .ToArray()));

    }
}