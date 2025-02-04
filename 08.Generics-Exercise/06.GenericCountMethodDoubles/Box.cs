using System.Net.Http.Headers;

namespace _06.GenericCountMethodDoubles;

public class Box<T> where T : IComparable<T>
{
    public T Value { get; }

    public Box(T value)
    {
        Value = value;
    }

    public static int Compare(List<Box<T>> boxes, T comparable)
    {
        int count = 0;
        foreach (var box in boxes)
        {
            int result = comparable.CompareTo(box.Value);
            if (result < 0) count++;
        }
        return count;
    }
}