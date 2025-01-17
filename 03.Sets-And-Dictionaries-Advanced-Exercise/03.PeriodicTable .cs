using System.Security.Authentication;

namespace _03.PeriodicTable;
internal class Program
{
    static void Main()
    {
        HashSet<string> periodicTable = new HashSet<string>();
        int countElements = int.Parse(Console.ReadLine());
        for (int i = 0; i < countElements; i++)
        {
            string[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < elements.Length; j++)
            {
                periodicTable.Add(elements[j]);
            }
        }
        foreach (var chemical in periodicTable.OrderBy(x=>x))
        {
            Console.Write(chemical + " ");
        }
    }
}
