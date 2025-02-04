namespace BoxOfT;

public class Box<T>
{
    private Stack<T> box;
    private int count;

    public Box()
    {
        box = new Stack<T>();
    }

    public int Count => count;

    public void Add(T element)
    {
        box.Push(element);
        count++;
    }

    public T Remove()
    {
        if (count == 0)
        {
            throw new InvalidOperationException("box is empty");
        }

        count--;
        return box.Pop();
    }
    
        
}