namespace _04.GenericSwapMethodInteger;

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