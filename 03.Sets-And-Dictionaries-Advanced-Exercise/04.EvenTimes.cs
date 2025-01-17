namespace _04.EvenTimes;
internal class Program
{
    static void Main()
    {
        int countOfNumbers = int.Parse(Console.ReadLine());
        Dictionary<int, int> map = new Dictionary<int, int>();
        for (int i = 0; i < countOfNumbers; i++)
        {
            int number = int.Parse(Console.ReadLine());
            if (!map.ContainsKey(number))
            {
                map.Add(number,0);
            }
            map[number]++;
        }
        foreach (var number in map)
        {
            if (number.Value % 2 == 0)
            {
                Console.WriteLine(number.Key);
            }
        }
    }
}
