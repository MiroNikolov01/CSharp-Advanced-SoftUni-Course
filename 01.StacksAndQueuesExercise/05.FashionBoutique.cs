using System.Net.Quic;
using System.Threading.Channels;

namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clothes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse();
            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> clothesStack = new Stack<int>(clothes);

            int sum = 0;
            int rackCount = 1;

            while (clothesStack.Count > 0)
            {
                int currentClothes = clothesStack.Pop();
                
                if (sum + currentClothes <= rackCapacity)
                {
                    sum += currentClothes;
                }
                else
                {
                    rackCount++;
                    sum = currentClothes;
                }

            }
            Console.WriteLine(rackCount);
        }
    }
}
