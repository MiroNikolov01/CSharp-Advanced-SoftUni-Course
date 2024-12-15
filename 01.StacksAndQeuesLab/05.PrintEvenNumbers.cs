using System.Net.Quic;

namespace _05.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>(arrNums);
            for (int i = 0; i < arrNums.Length; i++)
            {
                if (arrNums[i] % 2 != 0)
                {
                    queue.Dequeue();
                }
                else
                {
                    int even = queue.Dequeue();
                    queue.Enqueue(even);
                }
            }
            Console.WriteLine(string.Join(", ",queue));
        }
    }
}
