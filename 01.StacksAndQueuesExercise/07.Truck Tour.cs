namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int petrolPumpCount = int.Parse(Console.ReadLine());

            Queue<Pump> stations = new Queue<Pump>();

            for (int i = 0; i < petrolPumpCount; i++)
            {
                int[] pumpInfo = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                Pump pump = new Pump()
                {
                    Petrol = pumpInfo[0],
                    Distance= pumpInfo[1],
                };
                stations.Enqueue(pump);
            }

            for (int i = 0; i < stations.Count; i++)
            {
                if (CanFinish(stations))
                {
                    Console.WriteLine(i);
                    break;
                }

                stations.Enqueue(stations.Dequeue());

            }
        }
        static bool CanFinish(Queue<Pump> stations)
        {
            int petrol = 0;
            bool canFinish = true;
            
            for (int i = 0; i < stations.Count; i++)
            {
                Pump pumpInfo = stations.Dequeue();

                petrol += pumpInfo.Petrol - pumpInfo.Distance;
                canFinish = canFinish == true && petrol >= 0;

                stations.Enqueue(pumpInfo);
            }

            return canFinish;
        }
    }
    class Pump
    {
        public int Petrol { get; set; }
        public int Distance { get; set; }
    }
}
