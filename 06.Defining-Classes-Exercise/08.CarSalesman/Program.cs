namespace _08.CarSalesman;

public class Program
{
    static void Main(string[] args)
    {
        int countEngines = int.Parse(Console.ReadLine());
        List<Engine> engines = new List<Engine>();

        // Parse Engines
        for (int i = 0; i < countEngines; i++)
        {
            string[] engineData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string engineModel = engineData[0];
            int enginePower = int.Parse(engineData[1]);

            int displacement = 0;
            string efficiency = "n/a";

            if (engineData.Length == 3)
            {
                if (int.TryParse(engineData[2], out int parsedDisplacement))
                {
                    displacement = parsedDisplacement;
                }
                else
                {
                    efficiency = engineData[2];
                }
            }
            else if (engineData.Length == 4)
            {
                displacement = int.Parse(engineData[2]);
                efficiency = engineData[3];
            }

            engines.Add(new Engine(engineModel, enginePower, displacement, efficiency));
        }

        int carCount = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        // Parse Cars
        for (int i = 0; i < carCount; i++)
        {
            string[] carData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string carModel = carData[0];
            Engine engine = engines.FirstOrDefault(e => e.Model == carData[1]);

            int weight = 0;
            string color = "n/a";

            if (carData.Length == 3)
            {
                if (int.TryParse(carData[2], out int parsedWeight))
                {
                    weight = parsedWeight;
                }
                else
                {
                    color = carData[2];
                }
            }
            else if (carData.Length == 4)
            {
                weight = int.Parse(carData[2]);
                color = carData[3];
            }

            cars.Add(new Car(carModel, engine, weight, color));
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}
