namespace _03.CustomMinFunction;

class Program
{
    static void Main(string[] args)
    {
        var numbers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        
        int minNum = Min(numbers,(x,y) => x > y  ? y : x,int.MaxValue);
        Console.WriteLine(minNum);
    }

    static int Min(int[] array,Func<int,int,int> func,int initalValue)
    {
       int currentNum = initalValue;
       foreach (var number in array)
       {
           currentNum = func(number,currentNum);
       }
       return currentNum;
    }
}