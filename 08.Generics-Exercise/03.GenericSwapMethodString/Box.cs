namespace _03.GenericSwapMethodString;

public class Box<T>
{
    public T Value { get; }

    public Box(T value)
    {
        Value = value;
    }


    public override string ToString()
    {
        return $"{typeof(T).FullName}: {Value}";
    }
}