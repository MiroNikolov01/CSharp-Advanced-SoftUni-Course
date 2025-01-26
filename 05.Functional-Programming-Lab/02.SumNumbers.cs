namespace _02.SumNumbers;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Aggregate(
                (Length: 0,Sum: 0)
                , (acc,n) => (acc.Length + 1, acc.Sum + n),
                result => $"{result.Length}\n{result.Sum}"
                ));


    }
}