using System.Threading.Channels;

namespace _07.PredicateForNames;

class Program
{
    static void Main(string[] args)
    {
        int length = int.Parse(Console.ReadLine());
        
        string[] names = Console
            .ReadLine()
            .Split(' ',StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        var result = FilterNames(names, n => n.Length <= length);
        Console.WriteLine(string.Join(Environment.NewLine, result));
     }
    static List<string> FilterNames(string[] names, Func<string, bool> func)
    {
        List<string> filteredNames = new List<string>();
        for (int i = 0; i < names.Length; i++)
        {
            if (func(names[i]))
            {
                filteredNames.Add(names[i]);
            }  
        }
        
        return filteredNames;
    }
}