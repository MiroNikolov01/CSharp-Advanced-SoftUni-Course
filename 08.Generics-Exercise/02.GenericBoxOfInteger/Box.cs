namespace _02.GenericBoxOfInteger;

public class Box<T>
{
    public T Value { get; set; }

    public Box(object value)
    {
        Value = (T)value;
    }

    public override string ToString()
    {
        return $"{typeof(T)}: {Value}";
    }
}