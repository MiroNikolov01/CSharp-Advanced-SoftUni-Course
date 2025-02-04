namespace BoxOfT;

class StartUp
{
    static void Main(string[] args)
    {
        Box<int> box = new Box<int>();
        
        Console.WriteLine(box.Remove());

    }
}