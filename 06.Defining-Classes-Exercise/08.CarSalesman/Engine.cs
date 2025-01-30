namespace _08.CarSalesman;

public class Engine
{
    public Engine(string model, int power, int displacement, string efficiency)
    {
        Model = model;
        Power = power;
        Displacement = displacement;
        Efficiency = efficiency;
    }

    public string Model { get; set; }
    public int Power { get; set; }
    public int Displacement { get; set; }
    public string Efficiency { get; set; }

    public override string ToString()
    {
        return $"{Model}:\n"
               + $"    Power: {Power}\n"
               + $"    Displacement: {(Displacement != 0 ? Displacement.ToString() : "n/a")}\n"
               + $"    Efficiency: {(string.IsNullOrEmpty(Efficiency) ? "n/a" : Efficiency)}";
    }
}