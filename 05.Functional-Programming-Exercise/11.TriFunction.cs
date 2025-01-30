namespace _11.TriFunction;

class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        string name = FindName(names, (name, sum) => sum >= number);
        Console.WriteLine(name);
    }

    static string FindName(string[] array, Func<string, int, bool> filter)
    {
        foreach (var name in array)
        {
            int sum = 0;
            foreach (char ch in name)
            {
                sum += ch; 
            }
        
            if (filter(name, sum))
            {
                return name; 
            }
        }

        return string.Empty;
    }
}