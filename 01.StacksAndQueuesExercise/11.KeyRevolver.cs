using System.Security;

namespace _11.KeyRevolver;

internal class Program
{
    static void Main(string[] args)
    {
        int priceOfBullet = int.Parse(Console.ReadLine());
        int sizeOfGunBarrel = int.Parse(Console.ReadLine());

        int[] bulletSequence = ReadArrayFromConsole();
        int[] lockSequence = ReadArrayFromConsole();

        int valueOfInteligence = int.Parse(Console.ReadLine());

        Queue<int> locks = new Queue<int>(lockSequence);
        Stack<int> bullets = new Stack<int>(bulletSequence);

        int shots = 0;
        while (bullets.Count > 0)
        {
            int currentGunBarrel = sizeOfGunBarrel;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                if (bullets.Pop() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                shots++;
                currentGunBarrel--;
                if (currentGunBarrel == 0)
                {
                    if (bullets.Count > 0)
                    {
                        Console.WriteLine("Reloading!");
                    }
                    break;
                }
            }
            if (locks.Count == 0)
            {
                break;
            }
        }
        if (locks.Count == 0)
        {
            Console.WriteLine($"{bulletSequence.Length - shots} bullets left. Earned ${valueOfInteligence - (shots * priceOfBullet)}");
        }
        else if (bullets.Count == 0 && locks.Count > 0)
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }


    }
    static int[] ReadArrayFromConsole()
    {
        return Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}
