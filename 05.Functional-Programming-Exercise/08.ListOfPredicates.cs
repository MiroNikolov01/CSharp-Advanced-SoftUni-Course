namespace _08.ListOfPredicates;

class Program
{
    static void Main(string[] args)
    {
        int rangeNumber = int.Parse(Console.ReadLine());

        int[] dividers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        
        Func<int, bool>[] conditions = new Func<int, bool>[dividers.Length];
        for (int i = 0; i < dividers.Length; i++)
        {
            int currentDivider = dividers[i];
            conditions[i] = x => x % currentDivider == 0;
        }
        List<int> result = Filter(1,rangeNumber,conditions);
        Console.WriteLine(string.Join(" ", result));
    }

    static List<int> Filter(int start, int end, Func<int, bool>[] conditions)
    {
        List<int> result = new List<int>();
        for (int i = start; i <= end; i++)
        {
            bool isMatch = true;
            for (int j = 0; isMatch && j < conditions.Length; j++)
            {
                isMatch = conditions[j](i);
            }
            if(isMatch) result.Add(i);
        }

        return result;
    }

    /*
10
1 1 1 2
     */
}