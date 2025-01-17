namespace _05.CountSymbols;
internal class Program
{
    static void Main()
    {
        char[] charArray = Console.ReadLine().ToCharArray();

        Dictionary<char, int> map = new();

        for (int i = 0; i < charArray.Length; i++)
        {
            if (!map.ContainsKey(charArray[i]))
            {
                map.Add(charArray[i],0);
            }
            map[charArray[i]]++;
        }
      
        foreach (var ch in map.OrderBy(c => c.Key))
        {
            Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
        }
    }
}
