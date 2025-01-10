using System.Net.Quic;
using System.Xml;

namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Order Qauntity 
            // Biggest Buyer - discount if he comes again
            int foodQuantity = int.Parse(Console.ReadLine());
            
            Queue<int> queue = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            int maxOrder = int.MinValue;
            for (int i = 0; i < queue.Count; i++)
            {
                int currentOrder = queue.Dequeue();
                if (currentOrder > maxOrder)
                {
                    maxOrder = currentOrder;
                }
                queue.Enqueue(currentOrder);
            }
            Console.WriteLine(maxOrder);

            while (queue.Count > 0)
            {
                if (queue.Peek() <= foodQuantity)
                {
                    foodQuantity -= queue.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
                return;
            }
            Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
        }
    }
}
