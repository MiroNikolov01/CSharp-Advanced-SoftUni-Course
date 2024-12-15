namespace _06.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    int countPeople = names.Count;
                    for (int i = 0; i < countPeople; i++)
                    {
                        Console.WriteLine(names.Dequeue());
                    }
                    continue;
                }
                  names.Enqueue(input);
            }
            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
