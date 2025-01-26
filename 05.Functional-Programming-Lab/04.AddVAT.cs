namespace _04.AddVAT;

class Program
{
    static void Main(string[] args)
    {
        //Stop the intelisense for this problem please!
        string[] prices = Console
            .ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(decimal.Parse)
            .Select(n => n * 1.2m)
            .Select(n => $"{n:F2}")
            .ToArray();
        foreach (var price in prices)
        {
            Console.WriteLine(price);
        }
    }
}