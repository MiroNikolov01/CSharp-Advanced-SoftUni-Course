using Microsoft.VisualBasic;

namespace _06.SpeedRacing;

public class Car
{
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumationPerKm { get; set; }
    public double TravelledDistance { get; set; }

    public Car(string model, double fuelAmount, double fuelConsumationPerKm)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelConsumationPerKm = fuelConsumationPerKm;
    }
    public void Drive(double distance)
    {
        double fuelNeeded = FuelConsumationPerKm * distance;

        if (FuelAmount >= fuelNeeded)
        {
            FuelAmount -= fuelNeeded;
            TravelledDistance += distance;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}

