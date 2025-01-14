using System.Diagnostics.Tracing;

namespace _08.SoftUniParty;

internal class Program
{
    static void Main()
    {
        HashSet<string> regularGuests = new HashSet<string>();
        HashSet<string> vipGuests = new HashSet<string>();

        string input;
        while ((input = Console.ReadLine()) != "PARTY")
        {
            if (!char.IsDigit(input[0]))
            {
                regularGuests.Add(input);
                continue;
            }
            vipGuests.Add(input);
        }
        while ((input = Console.ReadLine()) != "END")
        {
            regularGuests.Remove(input);
            vipGuests.Remove(input);
        }
        Console.WriteLine(regularGuests.Count + vipGuests.Count);

        if (vipGuests.Count > 0)
        {
            Console.WriteLine(string.Join('\n', vipGuests));
        }
        if (regularGuests.Count > 0)
        {
            Console.WriteLine(string.Join('\n', regularGuests));
        }
    }
}
