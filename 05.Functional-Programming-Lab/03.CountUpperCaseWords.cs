using System.Numerics;

namespace _03.CountUpperCaseWords;

class Program
{
    public static Func<string, bool> IsUpperLetter = (c) => char.IsUpper(c[0]) &&
                                                            !string.IsNullOrEmpty(c);

    static void Main()
    {
        Console
            .ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Where(IsUpperLetter)
            .ToList()
            .ForEach(w => Console.WriteLine(w));
    }
}