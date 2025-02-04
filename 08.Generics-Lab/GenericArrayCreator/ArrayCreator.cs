namespace GenericArrayCreator;

public class ArrayCreator
{
    public static T[] Create<T>(int length, T value)
    {
        T[] array = new T[length];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = value;
        }

        return array;
    }
}