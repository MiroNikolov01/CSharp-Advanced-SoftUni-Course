namespace _06.SpeedRacing;

public class Program
{
    static void Main()
    {
        Dictionary<string, Car> carsMap = new Dictionary<string, Car>();
        int carsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < carsCount; i++)
        {
            string[] carData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string carModel = carData[0];
            double fuelAmount = double.Parse(carData[1]);
            double fuelConsumption = double.Parse(carData[2]);

            Car car = new Car(carModel, fuelAmount, fuelConsumption);
            if (carsMap.ContainsKey(carModel) == false)
            {
                carsMap[carModel] = car;
            }
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] driveTokens = command
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (driveTokens[0] != "Drive")
            {
                Console.WriteLine("Invalid command!");
                continue;
            }

            string carModel = driveTokens[1];
            double distance = double.Parse(driveTokens[2]);

            if (carsMap.ContainsKey(carModel))
            {
                Car car = carsMap[carModel];
                car.Drive(distance);
            }
        }

        foreach (var car in carsMap)
        {
            Console.WriteLine($"{car.Key} {car.Value.FuelAmount:F2} {car.Value.TravelledDistance}");
        }
    }
}