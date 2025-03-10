﻿namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelConsumption;
        private double fuelQuantity;
        private Engine engine;
        private Tire[] tires;

        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model, int year) : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model,
            year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption,Engine engine, Tire[] tires) : this(make,model,year,fuelQuantity,fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public Tire[] Tires
        {
            get
            {  
                return tires;
            }
            set
            {
                tires = value;
            }
        }

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        public void Drive(double distance)
        {

            if (fuelQuantity - distance * (fuelConsumption / 100) < 0)
            {
                Console.WriteLine($"Not enough fuel to perform this trip!");
            }
            else
            {
                fuelQuantity -= distance * (fuelConsumption / 100); 
            }
        }

        public void WhoAmI()
        {
            Console.WriteLine($"Make: {Make}\nModel: {Model}\nYear: {Year}\nFuel: {fuelQuantity:F2}");
        }
    }
}