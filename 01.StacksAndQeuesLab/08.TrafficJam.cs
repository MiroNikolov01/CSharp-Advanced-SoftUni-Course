namespace _08.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsCanPass = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string command;
            int carsPassed = 0;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < carsCanPass; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            carsPassed++;
                        }
                    }
                    continue;
                }
                cars.Enqueue(command);
            }
            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}
