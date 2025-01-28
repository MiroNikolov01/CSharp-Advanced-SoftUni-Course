namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()

        {
            List<Tire[]> tires = new List<Tire[]>();

            string tireCommand;
            while ((tireCommand = Console.ReadLine()) != "No more tires")
            {
                string[] tireData = tireCommand
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Tire[] tireSet = new Tire[tireData.Length / 2];

                for (int i = 0; i < tireData.Length; i += 2)
                {
                    int year = int.Parse(tireData[i]);
                    double pressure = double.Parse(tireData[i + 1]);
                    
                    tireSet[i / 2] = new Tire(year, pressure);
                }

                tires.Add(tireSet);
            }

            List<Engine> engines = new List<Engine>();

            string engineCommnad;
            while ((engineCommnad = Console.ReadLine()) != "Engines done")
            {
                string[] engineData = engineCommnad
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                
                int horsePower = int.Parse(engineData[0]);
                double cubicCapacity = double.Parse(engineData[1]);
                
                engines.Add(new Engine(horsePower, cubicCapacity));
            }

            List<Car> specialCars = new List<Car>();
            string specialCarCommand;
            while ((specialCarCommand = Console.ReadLine()) != "Show special")
            {
                string[] carData = specialCarCommand
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string carMake = carData[0];
                string carModel = carData[1];
                int carYear = int.Parse(carData[2]);
                double fuelQuantity = double.Parse(carData[3]);
                double fuelConsumption = double.Parse(carData[4]);
                int engineIndex = int.Parse(carData[5]);
                int tiresIndex = int.Parse(carData[6]);

               Engine engine = engines[engineIndex];
               Tire[] tireSet = tires[tiresIndex];
               
                Car specialCar = new Car(carMake,
                    carModel,
                    carYear,
                    fuelQuantity,
                    fuelConsumption,
                    engine,
                    tireSet);
                specialCars.Add(specialCar);
            }

            foreach (var car in specialCars)
            {
                double totalTirePressure = car.Tires.Sum(t => t.Pressure);
                if (car.Year >= 2017 &&
                    car.Engine.HorsePower > 330 &&
                    totalTirePressure >= 9 &&
                    totalTirePressure <= 10)
                {
                    car.Drive(20);
                    Console.WriteLine($"Make: {car.Make}\n" +
                                      $"Model: {car.Model}\n" +
                                      $"Year: {car.Year}\n" +
                                      $"HorsePowers: {car.Engine.HorsePower}\n" +
                                      $"FuelQuantity: {car.FuelQuantity}");
                }
                
            }
        }
    }
}
/*
2 2.6 3 1.6 2 3.6 3 1.6 
1 3.3 2 1.6 5 2.4 1 3.2 
No more tires 
331 2.2 
145 2.0 
Engines done 
Audi A5 2017 200 12 0 0 
BMW X5 2007 175 18 1 1 
Show special 
 */