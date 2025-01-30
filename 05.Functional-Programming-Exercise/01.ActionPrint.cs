namespace _01.ActionPrint;

class Program
{
    static void Main()
    {
        Action<string> print = n => Console.WriteLine(n);
        Console
            .ReadLine()
            .Split()
            .ToList()
            .ForEach(print);
    }
}