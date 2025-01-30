namespace _12312;

class Program
{
    static Predicate<int> isEven = n => n % 2 == 0;
    static Predicate<int> isOdd = n => n % 2 != 0;

    static void Main()
    {
        int[] numbersRange = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        
        (int start, int end) = (numbersRange[0], numbersRange[1]);

        string command = Console.ReadLine();

        var list = new List<int>();
        
        var oddOrEven = command == "even" ? isEven : isOdd;
        
        var outputNumbers = For(start, end, list, oddOrEven);
        Console.WriteLine(string.Join(" ", outputNumbers));
    }

    static List<int> For(int start, int end, List<int> outputList, Predicate<int> filterPredicate) //Handmade for-loop
    {
        outputList.Add(start);
        if (start == end) return outputList.Where(n => filterPredicate(n)).ToList(); // filtering every number to odd or even

        return For(start + 1, end, outputList, filterPredicate); // using recursion to generate through the numbers
    }
}