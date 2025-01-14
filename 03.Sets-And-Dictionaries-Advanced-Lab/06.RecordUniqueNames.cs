using System.Collections;

namespace _06.RecordUniqueNames;

internal class Program
{
    static void Main()
    {
        int countNames = int.Parse(Console.ReadLine());

        HashSet<string> names = new HashSet<string>();

        for (int i = 0; i < countNames; i++)
        {
            names.Add(Console.ReadLine());
        }

        Console.WriteLine(string.Join("\n", names));
    }
}
