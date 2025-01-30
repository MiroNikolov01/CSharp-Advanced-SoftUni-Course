namespace _07.RawData;

public class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        int countCars = int.Parse(Console.ReadLine());
        for (int i = 0; i < countCars; i++)
        {
            string[] carData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = carData[0];
            int engineSpeed = int.Parse(carData[1]);
            int enginePower = int.Parse(carData[2]);
            int cargoWeight = int.Parse(carData[3]);
            string cargoType = carData[4];
            
            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoWeight, cargoType);

            // Initializing the tires
            Tire[] tires = new Tire[4];
                                            /*Pressure1, Age1*/
            tires[0] = new Tire(double.Parse(carData[5]), int.Parse(carData[6]));
                                            /*Pressure2, Age2*/
            tires[1] = new Tire(double.Parse(carData[7]), int.Parse(carData[8]));
                                            /*Pressure3, Age3*/
            tires[2] = new Tire(double.Parse(carData[9]), int.Parse(carData[10]));
                                            /*Pressure4, Age4*/
            tires[3] = new Tire(double.Parse(carData[11]), int.Parse(carData[12]));
            
            Car car = new Car(model,engine, cargo, tires);
            
            cars.Add(car);
        }
        
        string command = Console.ReadLine();
        Func<Car, bool>? filter = command switch
        {
            "fragile" => c => c.Tires.Any(t => t.Pressure < 1),
            "flammable" => c => c.Engine.Power > 250,
            _=> null
        };

        foreach (var car in cars.Where(filter))
        {
            Console.WriteLine(car.Model);
        }
    }
}