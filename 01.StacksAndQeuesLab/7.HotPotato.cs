namespace _7.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            int hotPotatoNumber = int.Parse(Console.ReadLine());

            Queue<string> kids = new Queue<string>(names);
            while (kids.Count > 1)
            {
                for (int i = 1; i <= hotPotatoNumber; i++)
                {
                    if (i == hotPotatoNumber)
                    {
                        string lostPlayer = kids.Dequeue();
                        Console.WriteLine($"Removed {lostPlayer}");
                    }
                    else
                    {
                        string lastPlayer = kids.Dequeue();
                        kids.Enqueue(lastPlayer);
                    }
                }
            }
            string winner = kids.Dequeue();
            Console.WriteLine($"Last is {winner}");

        }
    }
}
