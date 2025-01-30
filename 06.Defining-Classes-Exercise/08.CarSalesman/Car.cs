namespace _08.CarSalesman;

public class Car
{
    public Car(string model, Engine engine, int weight, string color)
    {
        Model = model;
        Engine = engine;
        Weight = weight;
        Color = color;
    }

    public string Model { get; set; }
    public Engine Engine { get; set; }
    public int Weight { get; set; }
    public string Color { get; set; }

    public override string ToString()
    {
        string weight = Weight != 0 ? Weight.ToString() : "n/a";
        string color = !string.IsNullOrEmpty(Color) ? Color : "n/a";

        return $"{Model}:\n"
               + $"  {Engine}\n"
               + $"  Weight: {weight}\n"
               + $"  Color: {color}";
    }
}