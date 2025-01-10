using System.Security;

namespace _12.CupsAndBottles;

public class Program
{
    public static void Main()
    {
        Queue<int> cupCapacity = new Queue<int>(ReadArrayFromConsole());
        Stack<int> bottleCapacity = new Stack<int>(ReadArrayFromConsole());

        int wastedWater = 0;
        while (cupCapacity.Count > 0)
        {
            int currentBottleValue = bottleCapacity.Pop();
            int currentCupValue = cupCapacity.Peek();

            if (currentBottleValue >= cupCapacity.Peek())
            {
                currentBottleValue -= cupCapacity.Dequeue();
                if (currentBottleValue > 0)
                {
                    wastedWater += currentBottleValue;
                }
            }
            else
            {
                currentCupValue -= currentBottleValue;

                while (currentCupValue > 0)
                {
                    currentBottleValue = bottleCapacity.Pop();
                    if (currentBottleValue > currentCupValue)
                    {
                        wastedWater += currentBottleValue - currentCupValue;
                    }
                    currentCupValue -= currentBottleValue;
                }
                cupCapacity.Dequeue();
            }
            if (bottleCapacity.Count == 0)
            {
                break;
            }
        }
        
        PrintLeftCupsOrBottles(bottleCapacity,cupCapacity);
        Console.WriteLine("Wasted litters of water: {0}", wastedWater);


    }
    static int[] ReadArrayFromConsole()
    {
        return Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
    static void PrintLeftCupsOrBottles(Stack<int> bottles,Queue<int> cups)
    {
        if (cups.Count == 0)
        {
            Console.Write("Bottles: ");
            while (bottles.Count > 0)
            {
                Console.Write(bottles.Pop() + " ");
            }
        }
        else if (bottles.Count == 0)
        {
            Console.Write("Cups: ");
            while (cups.Count > 0)
            {
                Console.Write(cups.Dequeue() + " ");
            }
        }
        Console.WriteLine();
    }
}
