namespace CarManufacturer;

public class Engine
{
    public Engine(int horsePower, double cubicCapacity)
    {
        this.horsePower = horsePower;
        this.cubicCapacity = cubicCapacity;
    }

    private int horsePower;
    private double cubicCapacity;

    public int HorsePower
    {
        get
        {
            return horsePower;
        }
        set
        {
            horsePower = value;
        }
    }

    public double CubicCapacity
    {
        get
        {
            return cubicCapacity;
        }
        set
        {
            cubicCapacity = value;
        }
    }
}