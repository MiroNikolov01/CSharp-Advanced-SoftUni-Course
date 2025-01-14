namespace _03.Largest3Numbers;

static class Program
{
    static void Main()
    {
        int[] numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .OrderByDescending(x => x)
            .Take(3)
            .ToArray();

        Console.WriteLine(string.Join(' ',numbers));
    }
}
