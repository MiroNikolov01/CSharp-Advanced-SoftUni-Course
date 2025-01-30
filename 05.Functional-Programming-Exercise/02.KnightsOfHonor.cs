namespace _02.KnightsOfHonor;

class Program
{
    static void Main(string[] args)
    {
        Action<string> print = n => Console.WriteLine("Sir " + n);
        Console
            .ReadLine()
            .Split()
            .ToList()
            .ForEach(print);
    }
}