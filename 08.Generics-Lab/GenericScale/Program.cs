namespace GenericScale;

class StartUp
{
    static void Main(string[] args)
    {
        EqualityScale<int> scale = new EqualityScale<int>(5, 5);
        Console.WriteLine(scale.AreEqual());

    }
}