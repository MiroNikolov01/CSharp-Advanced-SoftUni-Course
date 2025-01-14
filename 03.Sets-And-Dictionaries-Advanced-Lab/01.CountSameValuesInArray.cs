namespace _01.CountSameValuesInArray;

static class Program
{
    static void Main()
    {
        double[] inputNumbers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();
        Dictionary<double, int> numbersMap = new();
        foreach (double num in inputNumbers)
        {
            if (!numbersMap.ContainsKey(num))
            {
                numbersMap.Add(num, 1);
            }
            else
            {
                numbersMap[num]++;
            }
        }
        foreach (KeyValuePair<double, int> number in numbersMap)
        {
            Console.WriteLine($"{number.Key} - {number.Value} times");
        }
    }
}
